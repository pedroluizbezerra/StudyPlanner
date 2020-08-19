IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Conhecimentos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [NivelConhecimentoAtual] int NOT NULL,
    [NivelConhecimentoDesejado] int NOT NULL,
    [Prioridade] int NOT NULL,
    [TipoConhecimento] int NOT NULL,
    [PlanoAcao] varchar(1000) NOT NULL,
    CONSTRAINT [PK_Conhecimentos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Metas] (
    [Id] uniqueidentifier NOT NULL,
    [Titulo] varchar(200) NOT NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataFimPrevista] datetime2 NOT NULL,
    [DataFimRealizada] datetime2 NOT NULL,
    [Ativa] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Metas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MetasConhecimentos] (
    [Id] uniqueidentifier NOT NULL,
    [ConhecimentoId] uniqueidentifier NOT NULL,
    [MetaId] uniqueidentifier NOT NULL,
    [MetaNivelConhecimentoDesejado] int NOT NULL,
    CONSTRAINT [PK_MetasConhecimentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MetasConhecimentos_Conhecimentos_ConhecimentoId] FOREIGN KEY ([ConhecimentoId]) REFERENCES [Conhecimentos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MetasConhecimentos_Metas_MetaId] FOREIGN KEY ([MetaId]) REFERENCES [Metas] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_MetasConhecimentos_ConhecimentoId] ON [MetasConhecimentos] ([ConhecimentoId]);

GO

CREATE INDEX [IX_MetasConhecimentos_MetaId] ON [MetasConhecimentos] ([MetaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200811002647_Inicial com Mapeamento', N'3.1.6');

GO

