IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    CREATE TABLE [Countries] (
        [CountryID] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([CountryID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    CREATE TABLE [Products] (
        [ProductID] int NOT NULL IDENTITY,
        [ProductCode] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [YearlyPrice] decimal(8,2) NOT NULL,
        [ReleaseDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    CREATE TABLE [Technicians] (
        [TechnicianID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Technicians] PRIMARY KEY ([TechnicianID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    CREATE TABLE [Customers] (
        [CustomerID] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [State] nvarchar(max) NOT NULL,
        [PostalCode] nvarchar(max) NOT NULL,
        [CountryID] nvarchar(450) NOT NULL,
        [Phone] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID]),
        CONSTRAINT [FK_Customers_Countries_CountryID] FOREIGN KEY ([CountryID]) REFERENCES [Countries] ([CountryID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    CREATE TABLE [Incidents] (
        [IncidentID] int NOT NULL IDENTITY,
        [CustomerID] int NOT NULL,
        [ProductID] int NOT NULL,
        [TechnicianID] int NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [DateOpened] datetime2 NOT NULL,
        [DateClosed] datetime2 NULL,
        CONSTRAINT [PK_Incidents] PRIMARY KEY ([IncidentID]),
        CONSTRAINT [FK_Incidents_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([CustomerID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Incidents_Products_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [Products] ([ProductID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Incidents_Technicians_TechnicianID] FOREIGN KEY ([TechnicianID]) REFERENCES [Technicians] ([TechnicianID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CountryID', N'Name') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    INSERT INTO [Countries] ([CountryID], [Name])
    VALUES (N'AU', N'Australia'),
    (N'NZ', N'New Zealand'),
    (N'NG', N'Nigeria'),
    (N'PH', N'Philippines'),
    (N'PR', N'Puerto Rico'),
    (N'QA', N'Qatar'),
    (N'SG', N'Singapore'),
    (N'ES', N'Spain'),
    (N'SE', N'Sweden'),
    (N'CH', N'Switzerland'),
    (N'TH', N'Thailand'),
    (N'TR', N'Turkey'),
    (N'UA', N'Ukraine'),
    (N'AE', N'United Arab Emirates'),
    (N'GB', N'United Kingdom'),
    (N'US', N'United States'),
    (N'VN', N'Vietnam'),
    (N'ZW', N'Zimbabwe'),
    (N'NL', N'Netherlands'),
    (N'MX', N'Mexico'),
    (N'PT', N'Portugal'),
    (N'LR', N'Liberia'),
    (N'AT', N'Austria'),
    (N'BE', N'Belgium'),
    (N'BR', N'Brazil'),
    (N'MY', N'Malaysia'),
    (N'CN', N'China'),
    (N'DK', N'Denmark'),
    (N'FI', N'Finland'),
    (N'FR', N'France'),
    (N'GR', N'Greece'),
    (N'CA', N'Canada'),
    (N'HK', N'Hong Kong'),
    (N'IS', N'Iceland'),
    (N'IN', N'India'),
    (N'IE', N'Ireland'),
    (N'IL', N'Israel'),
    (N'IT', N'Italy'),
    (N'JP', N'Japan'),
    (N'GL', N'Greenland');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CountryID', N'Name') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'Name', N'ProductCode', N'ReleaseDate', N'YearlyPrice') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    INSERT INTO [Products] ([ProductID], [Name], [ProductCode], [ReleaseDate], [YearlyPrice])
    VALUES (7, N'Tournament Master 2.0', N'TRNY20', '2018-02-15T00:00:00.0000000', 5.99),
    (6, N'Tournament Master 1.0', N'TRNY10', '2015-12-01T00:00:00.0000000', 4.99),
    (5, N'Team Manager 1.0', N'TEAM10', '2017-05-01T00:00:00.0000000', 4.99),
    (2, N'Draft Manager 2.0', N'DRAFT20', '2019-07-15T00:00:00.0000000', 5.99),
    (3, N'League Scheduler 1.0', N'LEAG10', '2016-05-01T00:00:00.0000000', 4.99),
    (1, N'Draft Manager 1.0', N'DRAFT10', '2017-02-01T00:00:00.0000000', 4.99),
    (4, N'League Scheduler Deluxe 1.0', N'LEAGD10', '2016-08-01T00:00:00.0000000', 7.99);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'Name', N'ProductCode', N'ReleaseDate', N'YearlyPrice') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TechnicianID', N'Email', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Technicians]'))
        SET IDENTITY_INSERT [Technicians] ON;
    INSERT INTO [Technicians] ([TechnicianID], [Email], [Name], [Phone])
    VALUES (14, N'gunter@sportsprosoftware.com', N'Gunter Wendt', N'800-555-0400'),
    (11, N'alison@sportsprosoftware.com', N'Alison Diaz', N'800-555-0443'),
    (12, N'jason@sportsprosoftware.com', N'Jason Lee', N'800-555-0444'),
    (13, N'awilson@sportsprosoftware.com', N'Andrew Wilson', N'800-555-0449'),
    (15, N'gfiori@sportsprosoftware.com', N'Gina Fiori', N'800-555-0459');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TechnicianID', N'Email', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Technicians]'))
        SET IDENTITY_INSERT [Technicians] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerID', N'Address', N'City', N'CountryID', N'Email', N'FirstName', N'LastName', N'Phone', N'PostalCode', N'State') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] ON;
    INSERT INTO [Customers] ([CustomerID], [Address], [City], [CountryID], [Email], [FirstName], [LastName], [Phone], [PostalCode], [State])
    VALUES (1002, N'PO Box 96621', N'Washington', N'US', N'ania@mma.nidc.com', N'Ania', N'Irvin', N'(301) 555-8950', N'20090', N'DC'),
    (1004, N'1990 Westwood Blvd Ste 260', N'Los Angeles', N'US', N'kenzie@mma.jobtrak.com', N'Kenzie', N'Quinn', N'(800) 555-8725', N'90025', N'CA'),
    (1006, N'3255 Ramos Cir', N'Sacramento', N'US', N'amauro@yahoo.org', N'Anton', N'Mauro', N'(916) 555-6670', N'95827', N'CA'),
    (1008, N'Box 52001', N'San Francisco', N'US', N'kanthoni@pge.com', N'Kaitlyn', N'Anthoni', N'(800) 555-6081', N'94152', N'CA'),
    (1010, N'PO Box 2069', N'Fresno', N'US', N'kmayte@fresno.ca.gov', N'Kendall', N'Mayte', N'(559) 555-9999', N'93718', N'CA'),
    (1012, N'4420 N. First Street, Suite 108', N'Fresno', N'US', N'marvin@expedata.com', N'Marvin', N'Quintin', N'(559) 555-9586', N'93726', N'CA'),
    (1015, N'27371 Valderas', N'Mission Viejo', N'US', N'', N'Gonzalo', N'Keeton', N'(214) 555-3647', N'92691', N'CA');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerID', N'Address', N'City', N'CountryID', N'Email', N'FirstName', N'LastName', N'Phone', N'PostalCode', N'State') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IncidentID', N'CustomerID', N'DateClosed', N'DateOpened', N'Description', N'ProductID', N'TechnicianID', N'Title') AND [object_id] = OBJECT_ID(N'[Incidents]'))
        SET IDENTITY_INSERT [Incidents] ON;
    INSERT INTO [Incidents] ([IncidentID], [CustomerID], [DateClosed], [DateOpened], [Description], [ProductID], [TechnicianID], [Title])
    VALUES (2, 1002, NULL, '2020-01-09T00:00:00.0000000', N'Received error message 415 while trying to import data from previous version.', 4, 14, N'Error importing data'),
    (1, 1010, '2020-01-10T00:00:00.0000000', '2020-01-08T00:00:00.0000000', N'Media appears to be bad.', 1, 11, N'Could not install'),
    (4, 1010, NULL, '2020-01-10T00:00:00.0000000', N'Program fails with error code 510, unable to open database.', 3, NULL, N'Error launching program'),
    (3, 1015, '2020-01-10T00:00:00.0000000', '2020-01-08T00:00:00.0000000', N'Setup failed with code 104.', 6, 15, N'Could not install');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IncidentID', N'CustomerID', N'DateClosed', N'DateOpened', N'Description', N'ProductID', N'TechnicianID', N'Title') AND [object_id] = OBJECT_ID(N'[Incidents]'))
        SET IDENTITY_INSERT [Incidents] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    CREATE INDEX [IX_Customers_CountryID] ON [Customers] ([CountryID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    CREATE INDEX [IX_Incidents_CustomerID] ON [Incidents] ([CustomerID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    CREATE INDEX [IX_Incidents_ProductID] ON [Incidents] ([ProductID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    CREATE INDEX [IX_Incidents_TechnicianID] ON [Incidents] ([TechnicianID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200130224714_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200130224714_Initial', N'3.1.0');
END;

GO

