
/****** Object:  Table [dbo].[PhoneBook]    Script Date: 22/07/2020 16:51:40 ******/
DROP TABLE IF EXISTS [dbo].[PhoneBook]
GO

/****** Object:  Table [dbo].[PhoneBook]    Script Date: 22/07/2020 16:51:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT [dbo].[PhoneBook] ON
GO

INSERT [dbo].[PhoneBook] ([Id], [FirstName], [LastName], [HomeNumber], [WorkNumber], [PhoneNumber]) VALUES (1, N'Name1', N'Surname1', N'020123456', N'0204567989', N'+44123789')
GO

INSERT [dbo].[PhoneBook] ([Id], [FirstName], [LastName], [HomeNumber], [WorkNumber], [PhoneNumber]) VALUES (2, N'Name2', N'Surname2', N'020223456', N'0205567989', N'+44223789')
GO

INSERT [dbo].[PhoneBook] ([Id], [FirstName], [LastName], [HomeNumber], [WorkNumber], [PhoneNumber]) VALUES (3, N'Name3', N'Surname3', N'020323456', N'0206567989', N'+44323789')
GO

SET IDENTITY_INSERT [dbo].[PhoneBook] OFF
GO
