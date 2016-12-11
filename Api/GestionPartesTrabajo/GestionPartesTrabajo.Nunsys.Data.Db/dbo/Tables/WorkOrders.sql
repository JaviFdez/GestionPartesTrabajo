CREATE TABLE [dbo].[WorkOrders] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [OTCode]            NVARCHAR (50)  NOT NULL,
    [Description]       NVARCHAR (100) NOT NULL,
    [IdProjectTask]     INT            NOT NULL,
    [IdUser]            INT            NOT NULL,
    [PlannedDate]       DATE           NULL,
    [EstimatedDuration] INT            CONSTRAINT [DF_WorkOrders_EstimatedDuration] DEFAULT ((0)) NOT NULL,
    [RemainingDuration] INT            CONSTRAINT [DF_WorkOrders_RemainingDuration] DEFAULT ((0)) NOT NULL,
    [WorkOrderStatus]   INT            NOT NULL,
    [SisVersion]        ROWVERSION     NOT NULL,
    CONSTRAINT [PK_WorkOrders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WorkOrders_ProjectTasks] FOREIGN KEY ([IdProjectTask]) REFERENCES [dbo].[ProjectTasks] ([Id]),
    CONSTRAINT [FK_WorkOrders_Users] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[Users] ([Id])
);

