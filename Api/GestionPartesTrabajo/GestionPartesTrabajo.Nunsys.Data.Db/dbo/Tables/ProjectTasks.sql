CREATE TABLE [dbo].[ProjectTasks] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [IdProyect]   INT            NOT NULL,
    [TaskCode]    NVARCHAR (50)  NULL,
    [Description] NVARCHAR (100) NULL,
    [SisVersion]  ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ProjectTasks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectTasks_Projects] FOREIGN KEY ([IdProyect]) REFERENCES [dbo].[Projects] ([Id])
);

