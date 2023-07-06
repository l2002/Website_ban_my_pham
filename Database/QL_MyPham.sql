CREATE DATABASE [QLmypham]

ON  PRIMARY 
( NAME = N'QLmypham', 
  FILENAME = N'C:\QLmypham.mdf' , 
  SIZE = 20MB , 
  MAXSIZE = 100MB, 
  FILEGROWTH = 10MB )
LOG ON 
( 
	NAME = N'QLmypham_log', 
	FILENAME = N'C:\QLmypham_log.ldf' , 
	SIZE = 20MB , 
	MAXSIZE = 100MB , 
	FILEGROWTH = 5MB 
)


USE [QLmypham]
GO

CREATE TABLE [dbo].[Chitietdonhang](
	[Madon] [int] NOT NULL,
	[Masp] [int] NOT NULL,
	[Soluong] [int] NULL,
	[Dongia] [decimal](18, 0) NULL,
	CONSTRAINT [PK_Chitietdonhang] PRIMARY KEY ([Madon],[Masp])
)

CREATE TABLE [dbo].[Donhang](
	[Madon] [int] NOT NULL,
	[Ngaydat] [datetime] NULL,
	[Tinhtrang] [int] NULL,
	[MaNguoidung] [int] NULL,
 CONSTRAINT [PK_Donhang] PRIMARY KEY ([Madon]) 
)

CREATE TABLE [dbo].[Hangsanxuat](
	[Mahang] [int] IDENTITY(1,1) NOT NULL,
	[Tenhang] [nchar](30) NULL,
 CONSTRAINT [PK_Hangsanxuat] PRIMARY KEY ([Mahang]) 
)

CREATE TABLE [dbo].[Thuonghieu](
	[Math] [int] IDENTITY(1,1) NOT NULL,
	[Tenth] [nchar](30) NULL,
 CONSTRAINT [PK_Thuonghieu] PRIMARY KEY ([Math]) 
)

CREATE TABLE [dbo].[Nguoidung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[Hoten] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Dienthoai] [nchar](12) NULL,
	[Matkhau] [varchar](50) NULL,
	[IDQuyen] [int] NULL,
	[Diachi] [nvarchar](100) NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY ([MaNguoiDung]) 
)

CREATE TABLE [dbo].[PhanQuyen](
	[IDQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](20) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY ([IDQuyen]) 
)

CREATE TABLE [dbo].[Sanpham](
	[Masp] [int] IDENTITY(1,1) NOT NULL,
	[Tensp] [nvarchar](50) NULL,
	[Giatien] [decimal](18, 0) NULL,
	[Soluong] [int] NULL,
	[Mota] [ntext] NULL,
	[Sanphammoi] [bit] NULL,
	[Anhbia] [nvarchar](20) NULL,
	[Mahang] [int] NULL,
	[Math] [int] NULL,
 CONSTRAINT [PK_Sanpham] PRIMARY KEY ([Masp]) 
)

ALTER TABLE [dbo].[Nguoidung] ADD  CONSTRAINT [DF_Nguoidung_IDQuyen]  DEFAULT ((0)) FOR [IDQuyen]
GO
ALTER TABLE [dbo].[Chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_Chitietdonhang_Donhang] FOREIGN KEY([Madon])
REFERENCES [dbo].[Donhang] ([Madon])
GO
ALTER TABLE [dbo].[Chitietdonhang] CHECK CONSTRAINT [FK_Chitietdonhang_Donhang]
GO
ALTER TABLE [dbo].[Chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_Chitietdonhang_Sanpham] FOREIGN KEY([Masp])
REFERENCES [dbo].[Sanpham] ([Masp])
GO
ALTER TABLE [dbo].[Chitietdonhang] CHECK CONSTRAINT [FK_Chitietdonhang_Sanpham]
GO
ALTER TABLE [dbo].[Donhang]  WITH CHECK ADD  CONSTRAINT [FK_Donhang_Khachhang] FOREIGN KEY([MaNguoidung])
REFERENCES [dbo].[Nguoidung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[Donhang] CHECK CONSTRAINT [FK_Donhang_Khachhang]
GO
ALTER TABLE [dbo].[Nguoidung]  WITH CHECK ADD  CONSTRAINT [FK_Nguoidung_Nguoidung] FOREIGN KEY([IDQuyen])
REFERENCES [dbo].[PhanQuyen] ([IDQuyen])
GO
ALTER TABLE [dbo].[Nguoidung] CHECK CONSTRAINT [FK_Nguoidung_Nguoidung]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_Hangsanxuat] FOREIGN KEY([Mahang])
REFERENCES [dbo].[Hangsanxuat] ([Mahang])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_Hangsanxuat]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_Thuonghieu] FOREIGN KEY([Math])
REFERENCES [dbo].[Thuonghieu] ([Math])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_Thuonghieu]
GO

ALTER TABLE [dbo].[Sanpham]
ALTER COLUMN [Tensp] [nvarchar](100) NULL

SET IDENTITY_INSERT [dbo].[Hangsanxuat] ON 

INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (1, N'Phú Cường Cosmetics')
INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (2, N'Kanna – Kanna Cosmetics')
INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (3, N'La’p Việt Nam')
INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (4, N'Tân Ngọc Phát')
INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (5, N'Lahy’s')
SET IDENTITY_INSERT [dbo].[Hangsanxuat] OFF
GO

SET IDENTITY_INSERT [dbo].[Thuonghieu] ON 
INSERT [dbo].[Thuonghieu] ([Math], [Tenth]) VALUES (1, N'Clinique')
INSERT [dbo].[Thuonghieu] ([Math], [Tenth]) VALUES (2, N'MAC')
INSERT [dbo].[Thuonghieu] ([Math], [Tenth]) VALUES (3, N'Maybelline')
SET IDENTITY_INSERT [dbo].[Thuonghieu] OFF
GO

SET IDENTITY_INSERT [dbo].[Thuonghieu] ON 
INSERT [dbo].[Thuonghieu] ([Math], [Tenth]) VALUES (4, N'Dior')
INSERT [dbo].[Thuonghieu] ([Math], [Tenth]) VALUES (5, N'MD Dermatics')
SET IDENTITY_INSERT [dbo].[Thuonghieu] OFF
GO

SET IDENTITY_INSERT [dbo].[Nguoidung] ON 

INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (14, N'Lê Bá Cháy', N'Admin@gmail.com', N'0812883636', N'12345678', 2, NULL)
INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (15, N'Sòng A Sáng', N'test@gmail.com', N'0812883636', N'12345678', NULL, NULL)
INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (16, N'Huỳnh Hữu Hóa', N'Khach@gmail.com', N'0812883636', N'12345678', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Nguoidung] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([IDQuyen], [TenQuyen]) VALUES (1, N'Member')
INSERT [dbo].[PhanQuyen] ([IDQuyen], [TenQuyen]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
GO

SET IDENTITY_INSERT [dbo].[Sanpham] ON 
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Sanphammoi], [Anhbia], [Mahang], [Math]) VALUES (1, N'FANCL Mild Cleansing Oil - Dầu tẩy trang', CAST(2000000 AS Decimal(18, 0)), 9, N'FANCL Mild Cleansing Oil - Dầu tẩy trang', 1, N'nh1.png', 2, 2)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Sanphammoi], [Anhbia], [Mahang], [Math]) VALUES (2, N'LA MER The Treatment Lotion Hydrating Mask - Mặt nạ tái tạo da', CAST(2000000 AS Decimal(18, 0)), 10, N'LA MER The Treatment Lotion Hydrating Mask - Mặt nạ tái tạo da', 1, N'nh2.png', 2, 2)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Sanphammoi], [Anhbia], [Mahang], [Math]) VALUES (3, N'HUXLEY Cleansing Water; Be Clean, Be Moist - Nước tẩy trang', CAST(2000000 AS Decimal(18, 0)), 10, N'HUXLEY Cleansing Water; Be Clean, Be Moist - Nước tẩy trang', 1, N'nh3.png', 2, 2)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Sanphammoi], [Anhbia], [Mahang], [Math]) VALUES (4, N'BIODERMA Solution Micellaire Demaquillante - Nước tẩy trang (Da nhạy cảm) 500ml', CAST(2000000 AS Decimal(18, 0)), 2, N'BIODERMA Solution Micellaire Demaquillante - Nước tẩy trang (Da nhạy cảm) 500ml', 1, N'nh4.png', 2, 2)
SET IDENTITY_INSERT [dbo].[Sanpham] OFF
GO

SET IDENTITY_INSERT [dbo].[Sanpham] ON 
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Sanphammoi], [Anhbia], [Mahang], [Math]) VALUES (15, N'Son Dưỡng Môi Dior Ladies Addict Lip Glow Reviving Lip Balm (Nobox) #001 & #004 ', CAST(595000 AS Decimal(18, 0)), 100, N'Mùi hương vani dịu nhẹ, không quá ngọt sắc hay đậm mùi hương liệu nhân tạo.', 1, N'dior1.jpg', 3, 4)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Sanphammoi], [Anhbia], [Mahang], [Math]) VALUES (16, N'Son Dưỡng Dior Addict Lip Maximizer 6ml #020 Mahogany ', CAST(450000 AS Decimal(18, 0)), 200, N'Mùi hương vani dịu nhẹ, không quá ngọt sắc hay đậm mùi hương liệu nhân tạo.', 1, N'dior2.jpg', 3, 4)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Sanphammoi], [Anhbia], [Mahang], [Math]) VALUES (17, N'Son Dưỡng Dior Addict Lip Maximizer 6ml #020 Mahogany ', CAST(650000 AS Decimal(18, 0)), 150, N'Bổ sung dầu anh đào dưỡng ẩm môi cả ngày dài, mang tới cảm giác thoải mái lâu dài.', 1, N'dior3.jpg', 3, 4)
SET IDENTITY_INSERT [dbo].[Sanpham] OFF
GO

select * from PhanQuyen
select * from Donhang
select * from Sanpham
select * from Chitietdonhang
select * from Nguoidung
select * from Thuonghieu
select * from Hangsanxuat