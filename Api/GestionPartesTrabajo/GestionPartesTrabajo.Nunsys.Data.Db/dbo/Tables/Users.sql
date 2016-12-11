CREATE TABLE [dbo].[Users] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NULL,
    [Surname1]   NVARCHAR (50)  NULL,
    [Surname2]   NVARCHAR (50)  NULL,
    [IdNetUser]  NVARCHAR (128) NOT NULL,
    [SisVersion] ROWVERSION     NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

