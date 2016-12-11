CREATE TABLE [dbo].[Imputations] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [IdUser]        INT            NOT NULL,
    [IdWorkOrder]   INT            NULL,
    [IdProjectTask] INT            NOT NULL,
    [Description]   NVARCHAR (100) NOT NULL,
    [StartDateTime] DATETIME       NULL,
    [EndDateTime]   DATETIME       NULL,
    [Hours]         FLOAT (53)     NULL,
    [SisVersion]    ROWVERSION     NOT NULL,
    CONSTRAINT [FK_Imputations_ProjectTasks] FOREIGN KEY ([IdProjectTask]) REFERENCES [dbo].[ProjectTasks] ([Id]),
    CONSTRAINT [FK_Imputations_Users] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_Imputations_WorkOrders] FOREIGN KEY ([IdWorkOrder]) REFERENCES [dbo].[WorkOrders] ([Id])
);

