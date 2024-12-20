Build started...
Build succeeded.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Service] (
    [ServiceId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [PathFoto] nvarchar(max) NOT NULL,
    [Duration] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Service] PRIMARY KEY ([ServiceId])
);
GO

CREATE TABLE [User] (
    [UserId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Client] (
    [UserId] int NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [DateOfBirth] nvarchar(max) NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    [Street] nvarchar(max) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [District] nvarchar(max) NOT NULL,
    [Number] int NOT NULL,
    [Complement] nvarchar(max) NULL,
    [State] nvarchar(max) NOT NULL,
    [Cep] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK_Client_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Employee] (
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK_Employee_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ClientServices] (
    [ClientServiceId] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [ServiceId] int NOT NULL,
    [DateTime] datetime2 NOT NULL,
    [Status] int NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_ClientServices] PRIMARY KEY ([ClientServiceId]),
    CONSTRAINT [FK_ClientServices_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Client] ([UserId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClientServices_Service_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Service] ([ServiceId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ClientServices_ClientId] ON [ClientServices] ([ClientId]);
GO

CREATE INDEX [IX_ClientServices_ServiceId] ON [ClientServices] ([ServiceId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241109150644_InitialCreate', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClientServices]') AND [c].[name] = N'Status');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ClientServices] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ClientServices] DROP COLUMN [Status];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241110134607_RemoveStatus', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Client]') AND [c].[name] = N'Gender');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Client] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Client] DROP COLUMN [Gender];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241113165131_RemoveGender', N'8.0.8');
GO

COMMIT;
GO


