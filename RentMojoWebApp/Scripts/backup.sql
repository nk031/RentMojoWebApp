INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9f84bd10-1b1e-4e47-9876-2c5f84ac698b', N'admin', N'admin', N'5c2f9cb0-2c5f-49b3-881d-8f577acddf74')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9f47b49a-8911-4f0c-975e-caf2a72de63e', N'user@rentmojo.com', N'USER@RENTMOJO.COM', N'user@rentmojo.com', N'USER@RENTMOJO.COM', 1, N'AQAAAAEAACcQAAAAEOJlmU7AUP1nZPW1CArgXg7HuaV97IHwwIDIj4v/U9iLDZHx6WEd9Ia6WVBre/TLHQ==', N'NA33KMEWSUILKYQX4TSBFTZOTRESA35L', N'0bc64a1f-c3cd-4733-8a83-fbbc5f233da3', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c4c68bb8-0067-4907-896a-fc81ebe635d0', N'admin@rentmojo.com', N'ADMIN@RENTMOJO.COM', N'admin@rentmojo.com', N'ADMIN@RENTMOJO.COM', 1, N'AQAAAAEAACcQAAAAEGHrRW/UcUEO65GsNshEj+Zw0xTg2TjykHT8/Fi59Tw3pPqn6G6zINCI7SUUBFmZwA==', N'RPKG5UZB77XRHBMJXBP52NKHXEMM5Z7G', N'451d5cfb-79e3-43fc-ab75-d6ac72c5b7db', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd2184b65-33aa-4d26-9239-4514ff0ac50a', N'admins@rentmojo.com', N'ADMINS@RENTMOJO.COM', N'admins@rentmojo.com', N'ADMINS@RENTMOJO.COM', 1, N'AQAAAAEAACcQAAAAEM4f8WtsxqnQesTd4ajKJDGNVCH8c5zHcKX6F4w8S75l15z3yRmJy9tMqeKA+kZg4g==', N'ACKRKSEMMGBEWYH4YERTB2PANJV7N7OL', N'98b75c37-dc50-442f-b23b-9bef909acc0e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd2184b65-33aa-4d26-9239-4514ff0ac50a', N'9f84bd10-1b1e-4e47-9876-2c5f84ac698b')
GO
SET IDENTITY_INSERT [dbo].[RentTypes] ON  
GO
INSERT [dbo].[RentTypes] ([TypeID], [TypeName], [Extension]) VALUES (1, N'Furniture', N'.PNG')
GO
INSERT [dbo].[RentTypes] ([TypeID], [TypeName], [Extension]) VALUES (2, N'Appliances', N'.PNG')
GO
INSERT [dbo].[RentTypes] ([TypeID], [TypeName], [Extension]) VALUES (3, N'Electronics', N'.PNG')
GO
SET IDENTITY_INSERT [dbo].[RentTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[RentSubTypes] ON 
GO
INSERT [dbo].[RentSubTypes] ([SubTypeID], [SubTypeName], [Extension], [TypeID]) VALUES (1, N'Bedroom', N'.PNG', 1)
GO
INSERT [dbo].[RentSubTypes] ([SubTypeID], [SubTypeName], [Extension], [TypeID]) VALUES (2, N'Kitchen & Dining', N'.PNG', 1)
GO
INSERT [dbo].[RentSubTypes] ([SubTypeID], [SubTypeName], [Extension], [TypeID]) VALUES (3, N'Living Room', N'.PNG', 1)
GO
INSERT [dbo].[RentSubTypes] ([SubTypeID], [SubTypeName], [Extension], [TypeID]) VALUES (4, N'Smartphones', N'.PNG', 3)
GO
INSERT [dbo].[RentSubTypes] ([SubTypeID], [SubTypeName], [Extension], [TypeID]) VALUES (5, N'Smart Devices', N'.PNG', 3)
GO
INSERT [dbo].[RentSubTypes] ([SubTypeID], [SubTypeName], [Extension], [TypeID]) VALUES (6, N'Laptops', N'.PNG', 3)
GO
INSERT [dbo].[RentSubTypes] ([SubTypeID], [SubTypeName], [Extension], [TypeID]) VALUES (7, N'Air Conditioners', N'.PNG', 2)
GO
INSERT [dbo].[RentSubTypes] ([SubTypeID], [SubTypeName], [Extension], [TypeID]) VALUES (8, N'Refrigerators & Freezers', N'.PNG', 2)
GO
INSERT [dbo].[RentSubTypes] ([SubTypeID], [SubTypeName], [Extension], [TypeID]) VALUES (9, N'Televisions', N'.PNG', 2)
GO
SET IDENTITY_INSERT [dbo].[RentSubTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (1, N'Hiber Storage Daybed', N'5 days', 81, 29, N'.jpg', 1)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (2, N'Hiber Queen Storage Bed', N'3 days', 158, 57, N'.jpg', 1)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (3, N'Kipper Queen Bed', N'3 days', 128, 46, N'.jpg', 1)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (4, N'Felix 1-Seater Sofa', N'3 days', 131, 47, N'.jpg', 3)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (5, N'Felix 3-Seater Sofa', N'5 days', 238, 86, N'.jpg', 3)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (6, N'Saddle Shoe Rack (L)', N'2 days', 70, 25, N'.jpg', 3)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (7, N'Alton 4-Seater Dining Set', N'3 days', 120, 43, N'.jpg', 2)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (8, N'Downey Bar Unit', N'4 days', 48, 17, N'.jpg', 2)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (9, N'Caramel 4-Seater Coffee Table', N'2 days', 120, 43, N'.jpg', 2)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (10, N'Single Door Fridge (210 Litre)', N'6 days', 101, 65, N'.jpg', 8)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (11, N'Single Door Fridge (190 Litre)', N'5 days', 101, 59, N'.jpg', 8)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (12, N'Single Door Fridge (170 Litre)', N'7 days', 91, 42, N'.jpg', 8)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (13, N'LED TV - 32"', N'3 days', 101, 49, N'.jpg', 9)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (14, N'LED TV - 40"', N'5 days', 205, 74, N'.jpg', 9)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (15, N'Smart LED TV - 43"', N'4 days', 249, 99, N'.jpg', 9)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (16, N'Inverter Air Conditioner 1 Ton', N'4 days', 386, 154, N'.jpg', 7)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (17, N'Air Conditioner 1 Ton', N'3 days', 349, 139, N'.jpg', 7)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (18, N'Google Home', N'5 days', 112, 44, N'.jpg', 5)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (19, N'Amazon Echo', N'4 days', 91, 39, N'.jpg', 5)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (20, N'Amazon Fire TV Stick', N'2 days', 50, 34, N'.jpg', 5)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (21, N'Dell XPS 13 , Intel Core i5 processor , 8th Gen - ( 8 GB / 256 GB SSD / Win 10 Pro OS , 13.3 inch,Silver )', N'4 days', 1019, 477, N'.jpg', 6)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (22, N'MacBook Air Intel Core i5 processor , 5th Gen - ( 8 GB / 128 GB SSD / Mac High Sierra OS , 13.3 inch, Silver )', N'3 days', 684, 389, N'.jpg', 6)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (23, N'MacBook Pro Intel Core i5 processor , 7th Gen - ( 8 GB / 128 GB SSD / Mac High Sierra OS,13.3 inch,Space Grey )', N'5 days', 1009, 428, N'.jpg', 6)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (24, N'Apple iPhone X (Space Grey)', N'3 days', 586, 234, N'.jpg', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (25, N'Apple iPhone 8 (Space Grey)', N'4 days', 424, 169, N'.jpg', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (26, N'Google Pixel 2 (Black)', N'3 days', 324, 129, N'.jpg', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (27, N'Samsung Galaxy S9 (Black)', N'2 days', 311, 124, N'.jpg', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (28, N'OnePlus 7 (Mirror Gray)', N'4 days', 264, 119, N'.jpg', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (29, N'Oppo A5 (Blue)', N'2 days', 117, 42, N'.jpg', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (30, N'Apple iPhone XS Max (Silver)', N'3 days', 661, 264, N'.jpg', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Name], [TagLine], [Deposit], [MonthlyRent], [Extension], [SubTypeID]) VALUES (31, N'Apple iPhone XS Max (Gold)', N'3 days', 649, 259, N'.jpg', 4)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderID], [Address], [OrderDate], [UserID], [Deposit], [MonthlyRent], [ProductID]) VALUES (1, N'Near Auckland', CAST(N'2021-04-24T11:43:32.3413300' AS DateTime2), N'user@rentmojo.com', 158, 57, 2)
GO
INSERT [dbo].[Orders] ([OrderID], [Address], [OrderDate], [UserID], [Deposit], [MonthlyRent], [ProductID]) VALUES (2, N'NEar China Town ', CAST(N'2021-04-24T11:43:53.2602335' AS DateTime2), N'user@rentmojo.com', 120, 43, 7)
GO
INSERT [dbo].[Orders] ([OrderID], [Address], [OrderDate], [UserID], [Deposit], [MonthlyRent], [ProductID]) VALUES (3, N'Near Auckland', CAST(N'2021-04-24T11:44:07.4426857' AS DateTime2), N'user@rentmojo.com', 91, 42, 12)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
