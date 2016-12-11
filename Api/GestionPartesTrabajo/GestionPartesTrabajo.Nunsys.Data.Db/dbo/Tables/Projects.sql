CREATE TABLE [dbo].[Projects] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ProjectCode] NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (100) NOT NULL,
    [IdCustomer]  INT            NOT NULL,
    [SisVersion]  ROWVERSION     NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Projects_Customers] FOREIGN KEY ([IdCustomer]) REFERENCES [dbo].[Customers] ([Id])
);

