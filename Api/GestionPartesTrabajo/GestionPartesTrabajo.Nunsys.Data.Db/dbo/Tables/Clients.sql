CREATE TABLE [dbo].[Clients] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Secret]               NVARCHAR (MAX) NOT NULL,
    [Name]                 NVARCHAR (256) NOT NULL,
    [ApplicationType]      INT            NOT NULL,
    [Active]               BIT            NOT NULL,
    [RefreshTokenLifeTime] INT            NOT NULL,
    [AllowedOrigin]        NVARCHAR (256) NULL
);

