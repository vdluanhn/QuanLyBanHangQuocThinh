USE [DBQuocThinh]
GO

/****** Object:  Table [dbo].[DanhMucCauHinh]    Script Date: 31-Mar-21 1:41:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DanhMucCauHinh](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NULL,
	[code] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[value] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[status] [numeric](18, 0) NULL,
	[created_date] [datetime] NULL,
 CONSTRAINT [PK_DanhMucCauHinh] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) 
GO
USE [DBQuocThinh]
GO

/****** Object:  Table [dbo].[NhapXuatTon]    Script Date: 31-Mar-21 1:42:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NhapXuatTon](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[product_code] [nvarchar](50) NULL,
	[color_code] [nvarchar](50) NULL,
	[size_code] [nvarchar](50) NULL,
	[quantity] [numeric](18, 0) NULL,
	[price] [numeric](18, 0) NULL,
	[type] [numeric](18, 0) NULL,
	[created_date] [datetime] NULL,
	[nxt_date] [datetime] NULL,
 CONSTRAINT [PK_NhapXuatTon] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [DBQuocThinh]
GO

/****** Object:  Table [dbo].[SanPham]    Script Date: 31-Mar-21 1:42:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SanPham](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NOT NULL,
	[name] [nvarchar](500) NULL,
	[created_date] [datetime] NULL,
	[supplier] [nvarchar](50) NULL,
	[price] [numeric](18, 0) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [DBQuocThinh]
GO

/****** Object:  StoredProcedure [dbo].[PROC_SEARCH_DANHMUCCAUHINH]    Script Date: 31-Mar-21 1:43:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_SEARCH_DANHMUCCAUHINH]
    @v_keyword VARCHAR(50),
    @v_type VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	select *
	from DanhMucCauHinh dd 
	
	where 1=1 
		and (dd.type = @v_type)
		and (dd.code like  CONCAT('%', upper(@v_keyword),'%') or upper(dd.name) like  CONCAT('%', upper(@v_keyword),'%') )
		and dd.status = 1

END
;
--exec  [PROC_SEARCH_SANPHAM] 'Tất cả', 'TATCA', '','',''
GO

USE [DBQuocThinh]
GO

/****** Object:  StoredProcedure [dbo].[PROC_SEARCH_NHAPXUATTON]    Script Date: 31-Mar-21 1:43:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_SEARCH_NHAPXUATTON]
    @v_keyword VARCHAR(50),
    @v_type NUMERIC,
	@v_fromDate date,
	@v_toDate date
AS
BEGIN
	SET NOCOUNT ON;
	select dd.*, sp.name product_name, cl.name color, sz.name size, case when dd.type = 1 then N'Nhập' when dd.type = 2 then N'Xuất' else N'Không xác định' end as type_name
	from NhapXuatTon dd 
	left join SanPham sp ON sp.code = dd.product_code
	left join DanhMucCauHinh cl ON cl.code = dd.color_code
	left join DanhMucCauHinh sz ON sz.code = dd.size_code
	 
	where 1=1 
		and (dd.nxt_date is null or ( (@v_fromDate is null or dd.nxt_date  > @v_fromDate) and (@v_toDate is null or dd.nxt_date  < @v_toDate)))
		and (dd.product_code like  CONCAT('%', upper(@v_keyword),'%') or dd.color_code like  CONCAT('%', upper(@v_keyword),'%') or dd.size_code like  CONCAT('%', upper(@v_keyword),'%') )
		and (@v_type=0 or @v_type is null or dd.type = @v_type)

END
;
--exec  [PROC_SEARCH_SANPHAM] 'Tất cả', 'TATCA', '','',''
GO

USE [DBQuocThinh]
GO

/****** Object:  StoredProcedure [dbo].[PROC_SEARCH_NHAPXUATTON_SANPHAM]    Script Date: 31-Mar-21 1:43:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_SEARCH_NHAPXUATTON_SANPHAM]
    @v_keyword VARCHAR(50),
	@v_fromDate date,
	@v_toDate date
AS
BEGIN
	SET NOCOUNT ON;
	select sp.code, sp.name,truoc.slTon as slTonDau, trong.slNhap,trong.slXuat,  truoc.slTon+trong.slNhap-trong.slXuat as slTon 
	from SanPham sp
	left join (
	select sp.code, sum(isnull(nhap.sl,0)) as  slNhap,  sum(isnull(xuat.sl,0)) as slXuat, sum(isnull(nhap.sl,0))-sum(isnull(xuat.sl,0)) as slTon
	from SanPham sp
	left join (
	--so luong nhap
	select nxt.product_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 1
	and nxt_date < @v_fromDate
	group by nxt.product_code) nhap ON sp.code = nhap.product_code 
	left join (
	--so luong xuat
	select nxt.product_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 2
	and nxt_date < @v_fromDate
	group by nxt.product_code) xuat ON sp.code = xuat.product_code 
	group by sp.code) truoc ON truoc.code = sp.code

	left join (
	select sp.code, sum(isnull(nhap.sl,0)) as  slNhap,  sum(isnull(xuat.sl,0)) as slXuat, sum(isnull(nhap.sl,0))-sum(isnull(xuat.sl,0)) as slTon
	from SanPham sp
	left join (
	--so luong nhap
	select nxt.product_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 1
	and nxt.nxt_date >= @v_fromDate and nxt.nxt_date<=@v_toDate
	group by nxt.product_code) nhap ON sp.code = nhap.product_code 
	left join (
	--so luong xuat
	select nxt.product_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 2
	and nxt.nxt_date >= @v_fromDate and nxt.nxt_date<=@v_toDate
	group by nxt.product_code) xuat ON sp.code = xuat.product_code 
	group by sp.code) trong ON trong.code = sp.code

	where 1=1
		and (sp.code like  CONCAT('%', upper(@v_keyword),'%') or upper(sp.name) like  CONCAT('%', upper(@v_keyword),'%') )

END
;
GO

USE [DBQuocThinh]
GO

/****** Object:  StoredProcedure [dbo].[PROC_SEARCH_NHAPXUATTON_SANPHAMCOLOR]    Script Date: 31-Mar-21 1:43:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_SEARCH_NHAPXUATTON_SANPHAMCOLOR]
    @v_keyword VARCHAR(50),
	@v_fromDate date,
	@v_toDate date
AS
BEGIN
	SET NOCOUNT ON;
	select sp.product_code, sp.name, sp.color_code,truoc.slTon as slTonDau, trong.slNhap,trong.slXuat,  truoc.slTon+trong.slNhap-trong.slXuat as slTon 
	from (select sp.code product_code, sp.name, cl.code color_code, cl.name color from DanhMucCauHinh cl, SanPham sp where cl.type = 'COLOR') sp
	left join (
	select sp.product_code, sp.name, sp.color_code, sum(isnull(nhap.sl,0)) as  slNhap,  sum(isnull(xuat.sl,0)) as slXuat, sum(isnull(nhap.sl,0))-sum(isnull(xuat.sl,0)) as slTon
	from (select sp.code product_code, sp.name, cl.code color_code, cl.name color from DanhMucCauHinh cl, SanPham sp where cl.type = 'COLOR') sp
	left join (
	--so luong nhap
	select nxt.product_code, nxt.color_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 1
	and nxt_date < @v_fromDate
	group by nxt.product_code, nxt.color_code) nhap ON sp.product_code = nhap.product_code and sp.color_code = nhap.color_code 
	left join (
	--so luong xuat
	select nxt.product_code, nxt.color_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 2
	and nxt_date < @v_fromDate
	group by nxt.product_code, nxt.color_code) xuat ON sp.product_code = xuat.product_code and sp.color_code = xuat.color_code
	group by sp.product_code, sp.name, sp.color_code) truoc ON truoc.product_code = sp.product_code  and sp.color_code = truoc.color_code

	left join (
	select sp.product_code, sp.name, sp.color_code, sum(isnull(nhap.sl,0)) as  slNhap,  sum(isnull(xuat.sl,0)) as slXuat, sum(isnull(nhap.sl,0))-sum(isnull(xuat.sl,0)) as slTon
	from (select sp.code product_code, sp.name, cl.code color_code, cl.name color from DanhMucCauHinh cl, SanPham sp where cl.type = 'COLOR' ) sp
	left join (
	--so luong nhap
	select nxt.product_code, nxt.color_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 1
	and nxt.nxt_date >=@v_fromDate and nxt.nxt_date<=@v_toDate
	group by nxt.product_code, nxt.color_code) nhap ON sp.product_code = nhap.product_code and sp.color_code = nhap.color_code
	left join (
	--so luong xuat
	select nxt.product_code, nxt.color_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 2
	and nxt.nxt_date >=@v_fromDate and nxt.nxt_date<=@v_toDate
	group by nxt.product_code, nxt.color_code) xuat ON sp.product_code = xuat.product_code and sp.color_code = xuat.color_code
	group by sp.product_code, sp.name, sp.color_code) trong ON trong.product_code = sp.product_code  and sp.color_code = trong.color_code 

	where 1=1
		and (sp.product_code like  CONCAT('%', upper(@v_keyword),'%') or upper(sp.name) like  CONCAT('%', upper(@v_keyword),'%') )

END
;
GO

USE [DBQuocThinh]
GO

/****** Object:  StoredProcedure [dbo].[PROC_SEARCH_NHAPXUATTON_SANPHAMCOLORSIZE]    Script Date: 31-Mar-21 1:44:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_SEARCH_NHAPXUATTON_SANPHAMCOLORSIZE]
    @v_keyword VARCHAR(50),
	@v_fromDate date,
	@v_toDate date
AS
BEGIN
	SET NOCOUNT ON;
	select sp.product_code, sp.name, sp.color_code, sp.size_code, truoc.slTon as slTonDau, trong.slNhap,trong.slXuat,  truoc.slTon+trong.slNhap-trong.slXuat as slTon 
	from (select sp.code product_code, sp.name, cl.code color_code, cl.name color, sz.code size_code, sz.name size from DanhMucCauHinh cl,DanhMucCauHinh sz, SanPham sp where cl.type = 'COLOR' and sz.type='SIZE') sp
	left join (
	select sp.product_code, sp.name, sp.color_code, sp.size_code, sum(isnull(nhap.sl,0)) as  slNhap,  sum(isnull(xuat.sl,0)) as slXuat, sum(isnull(nhap.sl,0))-sum(isnull(xuat.sl,0)) as slTon
	from (select sp.code product_code, sp.name, cl.code color_code, cl.name color, sz.code size_code, sz.name size from DanhMucCauHinh cl,DanhMucCauHinh sz, SanPham sp where cl.type = 'COLOR' and sz.type='SIZE') sp
	left join (
	--so luong nhap
	select nxt.product_code, nxt.color_code, nxt.size_code, nxt.price, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 1
	and nxt_date < @v_fromDate
	group by nxt.product_code, nxt.color_code, nxt.size_code, nxt.price) nhap ON sp.product_code = nhap.product_code and sp.color_code = nhap.color_code and sp.size_code = nhap.size_code
	left join (
	--so luong xuat
	select nxt.product_code, nxt.color_code, nxt.size_code, nxt.price, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 2
	and nxt_date < @v_fromDate
	group by nxt.product_code, nxt.color_code, nxt.size_code, nxt.price) xuat ON sp.product_code = xuat.product_code and sp.color_code = xuat.color_code and sp.size_code = xuat.size_code
	group by sp.product_code, sp.name, sp.color_code, sp.size_code) truoc ON truoc.product_code = sp.product_code  and sp.color_code = truoc.color_code and sp.size_code = truoc.size_code

	left join (
	select sp.product_code, sp.name, sp.color_code, sp.size_code, sum(isnull(nhap.sl,0)) as  slNhap,  sum(isnull(xuat.sl,0)) as slXuat, sum(isnull(nhap.sl,0))-sum(isnull(xuat.sl,0)) as slTon
	from (select sp.code product_code, sp.name, cl.code color_code, cl.name color, sz.code size_code, sz.name size from DanhMucCauHinh cl,DanhMucCauHinh sz, SanPham sp where cl.type = 'COLOR' and sz.type='SIZE') sp
	left join (
	--so luong nhap
	select nxt.product_code, nxt.color_code, nxt.size_code, nxt.price, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 1
	and nxt.nxt_date >=@v_fromDate and nxt.nxt_date<=@v_toDate
	group by nxt.product_code, nxt.color_code, nxt.size_code, nxt.price) nhap ON sp.product_code = nhap.product_code and sp.color_code = nhap.color_code and sp.size_code = nhap.size_code
	left join (
	--so luong xuat
	select nxt.product_code, nxt.color_code, nxt.size_code, nxt.price, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 2
	and nxt.nxt_date >=@v_fromDate and nxt.nxt_date<=@v_toDate
	group by nxt.product_code, nxt.color_code, nxt.size_code, nxt.price) xuat ON sp.product_code = xuat.product_code and sp.color_code = xuat.color_code and sp.size_code = xuat.size_code
	group by sp.product_code, sp.name, sp.color_code, sp.size_code) trong ON trong.product_code = sp.product_code  and sp.color_code = trong.color_code and sp.size_code = trong.size_code

	where 1=1
		and (sp.product_code like  CONCAT('%', upper(@v_keyword),'%') or upper(sp.name) like  CONCAT('%', upper(@v_keyword),'%') )

END
;
GO

USE [DBQuocThinh]
GO

/****** Object:  StoredProcedure [dbo].[PROC_SEARCH_NHAPXUATTON_SANPHAMSIZE]    Script Date: 31-Mar-21 1:44:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[PROC_SEARCH_NHAPXUATTON_SANPHAMSIZE]
    @v_keyword VARCHAR(50),
	@v_fromDate date,
	@v_toDate date
AS
BEGIN
	SET NOCOUNT ON;
	select sp.product_code, sp.name, sp.size_code, truoc.slTon as slTonDau, trong.slNhap,trong.slXuat,  truoc.slTon+trong.slNhap-trong.slXuat as slTon 
	from (select sp.code product_code, sp.name,  sz.code size_code, sz.name size from DanhMucCauHinh sz, SanPham sp where sz.type='SIZE') sp
	left join (
	select sp.product_code, sp.name,  sp.size_code, sum(isnull(nhap.sl,0)) as  slNhap,  sum(isnull(xuat.sl,0)) as slXuat, sum(isnull(nhap.sl,0))-sum(isnull(xuat.sl,0)) as slTon
	from (select sp.code product_code, sp.name,  sz.code size_code, sz.name size from DanhMucCauHinh sz, SanPham sp where  sz.type='SIZE') sp
	left join (
	--so luong nhap
	select nxt.product_code, nxt.size_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 1
	and nxt_date < @v_fromDate
	group by nxt.product_code, nxt.size_code) nhap ON sp.product_code = nhap.product_code and sp.size_code = nhap.size_code
	left join (
	--so luong xuat
	select nxt.product_code, nxt.size_code,  sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 2
	and nxt_date < @v_fromDate
	group by nxt.product_code, nxt.size_code) xuat ON sp.product_code = xuat.product_code and sp.size_code = xuat.size_code
	group by sp.product_code, sp.name, sp.size_code) truoc ON truoc.product_code = sp.product_code and sp.size_code = truoc.size_code

	left join (
	select sp.product_code, sp.name, sp.size_code, sum(isnull(nhap.sl,0)) as  slNhap,  sum(isnull(xuat.sl,0)) as slXuat, sum(isnull(nhap.sl,0))-sum(isnull(xuat.sl,0)) as slTon
	from (select sp.code product_code, sp.name, sz.code size_code, sz.name size from DanhMucCauHinh sz, SanPham sp where sz.type='SIZE') sp
	left join (
	--so luong nhap
	select nxt.product_code,  nxt.size_code,  sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 1
	and nxt.nxt_date >=@v_fromDate and nxt.nxt_date<=@v_toDate
	group by nxt.product_code, nxt.size_code) nhap ON sp.product_code = nhap.product_code and sp.size_code = nhap.size_code
	left join (
	--so luong xuat
	select nxt.product_code, nxt.size_code, sum(isnull(nxt.quantity,0)) sl
	from NhapXuatTon nxt
	where nxt.type = 2
	and nxt.nxt_date >=@v_fromDate and nxt.nxt_date<=@v_toDate
	group by nxt.product_code, nxt.size_code) xuat ON sp.product_code = xuat.product_code and sp.size_code = xuat.size_code
	group by sp.product_code, sp.name,  sp.size_code) trong ON trong.product_code = sp.product_code  and sp.size_code = trong.size_code

	where 1=1
		and (sp.product_code like  CONCAT('%', upper(@v_keyword),'%') or upper(sp.name) like  CONCAT('%', upper(@v_keyword),'%') )

END
;
GO

USE [DBQuocThinh]
GO

/****** Object:  StoredProcedure [dbo].[PROC_SEARCH_SANPHAM]    Script Date: 31-Mar-21 1:44:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_SEARCH_SANPHAM]
    @v_keyword VARCHAR(50),
	@v_fromDate date,
	@v_toDate date
AS
BEGIN
	SET NOCOUNT ON;
	select *
	from SanPham dd 
	
	where 1=1 
		and (dd.created_date is null or ( (@v_fromDate is null or dd.created_date  > @v_fromDate) and (@v_toDate is null or dd.created_date  < @v_toDate)))
		and (dd.code like  CONCAT('%', upper(@v_keyword),'%') or upper(dd.name) like  CONCAT('%', upper(@v_keyword),'%') )

END
;
--exec  [PROC_SEARCH_SANPHAM] 'Tất cả', 'TATCA', '','',''
GO


