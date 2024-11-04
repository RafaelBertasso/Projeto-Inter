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

CREATE TABLE [Services] (
    [ServiceId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [PathFoto] nvarchar(max) NOT NULL,
    [Duration] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY ([ServiceId])
);
GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Discriminator] nvarchar(8) NOT NULL,
    [ClientId] int NULL,
    [Phone] nvarchar(max) NULL,
    [DateOfBirth] nvarchar(max) NULL,
    [Gender] nvarchar(max) NULL,
    [Street] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [District] nvarchar(max) NULL,
    [Number] int NULL,
    [Complement] nvarchar(max) NULL,
    [State] nvarchar(max) NULL,
    [Cep] nvarchar(max) NULL,
    [EmployeeId] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [UserServices] (
    [UserServiceId] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [ServiceId] int NOT NULL,
    [DateTime] datetime2 NOT NULL,
    [Status] int NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_UserServices] PRIMARY KEY ([UserServiceId]),
    CONSTRAINT [FK_UserServices_Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([ServiceId]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserServices_Users_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_UserServices_ClientId] ON [UserServices] ([ClientId]);
GO

CREATE INDEX [IX_UserServices_ServiceId] ON [UserServices] ([ServiceId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241102174918_InitialCreate', N'8.0.8');
GO

COMMIT;
GO


