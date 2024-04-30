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

CREATE TABLE [Transactions] (
    [AuditTransactionId] bigint NOT NULL IDENTITY,
    [AuditId] bigint NOT NULL,
    [Refnumber] nvarchar(50) NOT NULL,
    [PartnerReference] nvarchar(50) NOT NULL,
    [ConfirmedDate] datetime2 NOT NULL,
    [TransactionDate] date NOT NULL,
    [Id] bigint NOT NULL,
    [OfferId] bigint NOT NULL,
    [Country] nvarchar(100) NOT NULL,
    [ToCurr] nvarchar(3) NOT NULL,
    [Bank] nvarchar(50) NOT NULL,
    [PartnerMTAI] nvarchar(50) NOT NULL,
    [Sarb] nvarchar(50) NULL,
    [PrincipleSpreadDCMZAR] decimal(20,10) NULL,
    [TotalAmount] decimal(20,10) NULL,
    [XEDCM] decimal(20,10) NULL,
    [HPAfterMarkUp] decimal(20,10) NULL,
    [ZARTotalSpread] decimal(20,10) NULL,
    [HPZARSpread] decimal(20,10) NULL,
    [DCMZARSpread] decimal(20,10) NULL,
    [DCMUSDSpread] decimal(20,10) NULL,
    [TotalTransFee] decimal(10,5) NULL,
    [HPTransFeeZAR] decimal(20,10) NULL,
    [DCMTransFeeZAR] decimal(20,10) NULL,
    [DCMTransFeeUSD] decimal(20,10) NULL,
    [OfferAmount] decimal(20,10) NULL,
    [Base] decimal(20,10) NULL,
    [MarkUp] decimal(20,10) NULL,
    [Randdiff] decimal(20,10) NULL,
    [Perc] decimal(20,10) NULL,
    [DCM] decimal(20,10) NULL,
    [USDMarkUp] decimal(20,10) NULL,
    [USDPerc] decimal(20,10) NULL,
    [DCMZAR] decimal(20,10) NULL,
    [DCMZARMarkUp] decimal(20,10) NULL,
    [DCMZARPerc] decimal(20,10) NULL,
    [DaytonaUSDBase] decimal(30,15) NULL,
    [DaytonaUSDMarkUp] decimal(30,15) NULL,
    [DaytonaPerc] decimal(18,15) NULL,
    [DaytonaZARBase] decimal(18,15) NULL,
    [DaytonaZARMarkUp] decimal(18,15) NULL,
    [DaytonaZARPerc] decimal(18,15) NULL,
    [InternalServiceFeeZAR] decimal(30,15) NULL,
    [InternalServiceFeeUSD] decimal(30,15) NULL,
    [MatchStatus] int NOT NULL,
    [PartnerStatus] int NOT NULL,
    [DTBaseLive] decimal(30,15) NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([AuditTransactionId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240430032832_audit-db-init', N'8.0.4');
GO

COMMIT;
GO

