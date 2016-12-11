USE [XXX]
GO


-- borrar tablas
-- aspnet identity
--delete from AspNetRoles
--delete from AspNetUserClaims
--delete from AspNetUserLogins
--delete from AspNetUserRoles
--delete from AspNetUsers
--delete from Clients
--delete from RefreshTokens

---- datos
-- TODO (establecer tablas)
-- ...



---- configuracion
-- TODO (establecer tablas)
-- ...







INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrador')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'User')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1d8e6418-ae5c-4fb8-a36b-6f2092bf3b57', N'admin@netuser.com', 0, N'AMEKIhtbxXADBGJwY0MAhCOakMeJO/Qfd2ZoaL1GHUouOO8PxDBj7aigClZ6U7rgKg==', N'a7852642-a6d9-4c05-b7c6-9de2128366e0', NULL, 0, 0, NULL, 0, 0, N'admin1')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'30861f8a-baf1-429a-b015-36a1c492aa8a', N'user@prueba.com', 0, N'AMiYMNfiWLzefxDxJAOgRHP5pS6pFw7umAbwGci3XeNGAnRMLpjra0sZRuglXWMmlQ==', N'19f7c674-5bca-4d05-ba34-c43b5069a39b', NULL, 0, 0, NULL, 0, 0, N'user1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1d8e6418-ae5c-4fb8-a36b-6f2092bf3b57', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'30861f8a-baf1-429a-b015-36a1c492aa8a', N'2')
GO

INSERT [dbo].[Clients] ([Id], [Secret], [Name], [ApplicationType], [Active], [RefreshTokenLifeTime], [AllowedOrigin]) VALUES (N'ngAuthApp', N'QsSwaakic1Tz+Nn3YFNpd3BLc7FhqnK1sqL9rA1hzgw=', N'Angular App ', 0, 1, 7200, N'*')
GO
