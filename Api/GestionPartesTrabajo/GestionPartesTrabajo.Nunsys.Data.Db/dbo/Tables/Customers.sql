CREATE TABLE [dbo].[Customers] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Number]     NVARCHAR (50)  NULL,
    [Name]       NVARCHAR (100) NULL,
    [SisVersion] ROWVERSION     NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

