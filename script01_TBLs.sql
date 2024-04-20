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

CREATE TABLE [TB_CATEGORIA] (
    [idCategoria] int NOT NULL IDENTITY,
    [nomeCategoria] nvarchar(100) NOT NULL,
    [descricao] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_TB_CATEGORIA] PRIMARY KEY ([idCategoria])
);
GO

CREATE TABLE [TB_EVENTOMUNICIPE] (
    [idEventoMunicipe] int NOT NULL IDENTITY,
    [idMunicipe] int NOT NULL,
    [idEvento] int NOT NULL,
    [horaInicio] datetime NOT NULL,
    [horaFim] datetime NOT NULL,
    CONSTRAINT [PK_TB_EVENTOMUNICIPE] PRIMARY KEY ([idEventoMunicipe])
);
GO

CREATE TABLE [TB_LOGINS] (
    [idPessoa] int NOT NULL IDENTITY,
    [nome] nvarchar(50) NOT NULL,
    [sobrenome] nvarchar(50) NOT NULL,
    [email] nvarchar(100) NOT NULL,
    [dataNasc] date NOT NULL,
    [PasswordHash] varbinary(255) NOT NULL,
    [PasswordSalt] varbinary(255) NOT NULL,
    [Foto] varbinary(max) NULL,
    [tipoConta] nvarchar(max) NOT NULL DEFAULT N'Municipe',
    CONSTRAINT [PK_TB_LOGINS] PRIMARY KEY ([idPessoa])
);
GO

CREATE TABLE [TB_MUNICIPE] (
    [idMunicipe] int NOT NULL IDENTITY,
    [idPessoa] int NOT NULL,
    [estado] nvarchar(100) NOT NULL,
    [cidade] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_TB_MUNICIPE] PRIMARY KEY ([idMunicipe]),
    CONSTRAINT [FK_TB_MUNICIPE_TB_LOGINS_idPessoa] FOREIGN KEY ([idPessoa]) REFERENCES [TB_LOGINS] ([idPessoa]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_ORGEVENTOS] (
    [idOrganizador] int NOT NULL IDENTITY,
    [idPessoa] int NOT NULL,
    [profissao] nvarchar(100) NOT NULL,
    [empresa] nvarchar(100) NOT NULL,
    [telOrganizador] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_TB_ORGEVENTOS] PRIMARY KEY ([idOrganizador]),
    CONSTRAINT [FK_TB_ORGEVENTOS_TB_LOGINS_idPessoa] FOREIGN KEY ([idPessoa]) REFERENCES [TB_LOGINS] ([idPessoa]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_EVENTO] (
    [idEvento] int NOT NULL IDENTITY,
    [idOrganizador] int NOT NULL,
    [idCategoria] int NOT NULL,
    [titulo] nvarchar(max) NOT NULL,
    [dataInicio] datetime2 NOT NULL,
    [dataFim] datetime2 NOT NULL,
    [limiteParticipantes] int NOT NULL,
    [descricao] nvarchar(max) NOT NULL,
    [valorIngresso] int NOT NULL,
    [horaInicio] datetime2 NOT NULL,
    [horaFim] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_EVENTO] PRIMARY KEY ([idEvento]),
    CONSTRAINT [FK_TB_EVENTO_TB_CATEGORIA_idCategoria] FOREIGN KEY ([idCategoria]) REFERENCES [TB_CATEGORIA] ([idCategoria]) ON DELETE CASCADE,
    CONSTRAINT [FK_TB_EVENTO_TB_ORGEVENTOS_idOrganizador] FOREIGN KEY ([idOrganizador]) REFERENCES [TB_ORGEVENTOS] ([idOrganizador]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_EQUIPE] (
    [idEvento] int NOT NULL,
    [respoEquipe] nvarchar(100) NOT NULL,
    [tamanhoEquipe] int NOT NULL,
    [SelecaoEquipe] int NOT NULL,
    CONSTRAINT [FK_TB_EQUIPE_TB_EVENTO_idEvento] FOREIGN KEY ([idEvento]) REFERENCES [TB_EVENTO] ([idEvento]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_EVENTOCOMENTARIO] (
    [idEvento] int NOT NULL,
    [idMunicipe] int NOT NULL,
    [comentario] nvarchar(255) NOT NULL,
    [avaliacao] float NOT NULL,
    CONSTRAINT [FK_TB_EVENTOCOMENTARIO_TB_EVENTO_idEvento] FOREIGN KEY ([idEvento]) REFERENCES [TB_EVENTO] ([idEvento]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_EVENTOENDERECO] (
    [idEvento] int NOT NULL,
    [endereco] nvarchar(255) NOT NULL,
    [nroEndereco] nvarchar(20) NOT NULL,
    [Complemento] nvarchar(100) NULL,
    [bairroEndereco] nvarchar(100) NOT NULL,
    [cidadeEndereco] nvarchar(100) NOT NULL,
    [UFEndereco] nvarchar(2) NOT NULL,
    [CEPEndereco] nvarchar(8) NOT NULL,
    CONSTRAINT [FK_TB_EVENTOENDERECO_TB_EVENTO_idEvento] FOREIGN KEY ([idEvento]) REFERENCES [TB_EVENTO] ([idEvento]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_EVENTOPARTICIPANTE] (
    [idEvento] int NOT NULL,
    [horaParticipacao] datetime NOT NULL,
    [limiteParticipantesHora] int NOT NULL,
    CONSTRAINT [FK_TB_EVENTOPARTICIPANTE_TB_EVENTO_idEvento] FOREIGN KEY ([idEvento]) REFERENCES [TB_EVENTO] ([idEvento]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCategoria', N'descricao', N'nomeCategoria') AND [object_id] = OBJECT_ID(N'[TB_CATEGORIA]'))
    SET IDENTITY_INSERT [TB_CATEGORIA] ON;
INSERT INTO [TB_CATEGORIA] ([idCategoria], [descricao], [nomeCategoria])
VALUES (1, N'Atividades físicas e competições recreativas.', N'Esportivo'),
(2, N'Diversão e lazer para todos os gostos.', N'Entreterimento'),
(3, N'Exploração da arte, história e tradições.', N'Cultaral'),
(4, N'Eventos voltados para negócios.', N'Corporativo'),
(5, N'Práticas e celebrações voltadas para a religião.', N'Religioso'),
(7, N'Eventos voltados para educação', N'Educacional'),
(8, N'Eventos relacionados a organizações e instituições.', N'Institucional');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idCategoria', N'descricao', N'nomeCategoria') AND [object_id] = OBJECT_ID(N'[TB_CATEGORIA]'))
    SET IDENTITY_INSERT [TB_CATEGORIA] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idPessoa', N'Foto', N'PasswordHash', N'PasswordSalt', N'dataNasc', N'email', N'nome', N'sobrenome', N'tipoConta') AND [object_id] = OBJECT_ID(N'[TB_LOGINS]'))
    SET IDENTITY_INSERT [TB_LOGINS] ON;
INSERT INTO [TB_LOGINS] ([idPessoa], [Foto], [PasswordHash], [PasswordSalt], [dataNasc], [email], [nome], [sobrenome], [tipoConta])
VALUES (1, NULL, 0xD61A420A80AF0627A32581E624A088E6129B6D5A00D8EF281708A8D8CD9F95E6E2EBDC7200892C021BF2F48E729326B2675BC44C0E0F92D059D4039D73A8AD50, 0x9464A35B396BB33BDC128E883D033095169975A486CA4FDE9FF0F57B7F220857171BED4901C29868E38D7A25E8FBE37A5E8E0C3F7E4B84198CD074FFECBDE6EFF8B011E2E9E7235F1D5327F4D075E0D4670DAD17ED706A0C63BC9734B9D9F9F134C3B93C1B3516FDA3D77983678A4F225D19BB2058CBA5082BFEBE255B706B73, '2024-04-19', N'seuEmail@gmail.com', N'UsuarioAdmin', N'', N'Organizador');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idPessoa', N'Foto', N'PasswordHash', N'PasswordSalt', N'dataNasc', N'email', N'nome', N'sobrenome', N'tipoConta') AND [object_id] = OBJECT_ID(N'[TB_LOGINS]'))
    SET IDENTITY_INSERT [TB_LOGINS] OFF;
GO

CREATE UNIQUE INDEX [IX_TB_EQUIPE_idEvento] ON [TB_EQUIPE] ([idEvento]);
GO

CREATE UNIQUE INDEX [IX_TB_EVENTO_idCategoria] ON [TB_EVENTO] ([idCategoria]);
GO

CREATE UNIQUE INDEX [IX_TB_EVENTO_idOrganizador] ON [TB_EVENTO] ([idOrganizador]);
GO

CREATE UNIQUE INDEX [IX_TB_EVENTOCOMENTARIO_idEvento] ON [TB_EVENTOCOMENTARIO] ([idEvento]);
GO

CREATE UNIQUE INDEX [IX_TB_EVENTOENDERECO_idEvento] ON [TB_EVENTOENDERECO] ([idEvento]);
GO

CREATE UNIQUE INDEX [IX_TB_EVENTOPARTICIPANTE_idEvento] ON [TB_EVENTOPARTICIPANTE] ([idEvento]);
GO

CREATE UNIQUE INDEX [IX_TB_MUNICIPE_idPessoa] ON [TB_MUNICIPE] ([idPessoa]);
GO

CREATE UNIQUE INDEX [IX_TB_ORGEVENTOS_idPessoa] ON [TB_ORGEVENTOS] ([idPessoa]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240419231553_InitialCreate', N'8.0.4');
GO

COMMIT;
GO

