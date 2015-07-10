if not exists(select * from sys.databases where name = 'agad')
    create database agad;
else
	use agad;

if object_id(N'dbo.USER', N'U') is null
begin
	create table [dbo].[USER] (
    [TC]    NCHAR (11)     NOT NULL,
    [AD]    NVARCHAR (50)  NOT NULL,
    [SOYAD] NVARCHAR (50)  NOT NULL,
    [EMAIL] NVARCHAR (50)  NULL,
    [PASS]  NVARCHAR (MAX) NOT NULL,
    [ADRES] NVARCHAR (MAX) NULL,
    [PHONE] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([TC] ASC)
	);
	print 'USER TABLOSU KURULDU'
end else
	print 'USER TABLOSU KURULMUÞ'


if object_id(N'dbo.CONFIRMSTATE',N'U') is null
begin
	create table [dbo].[CONFIRMSTATE] (
    [Id]          INT           NOT NULL,
    [NAME]        NVARCHAR (50) NOT NULL,
    [NAMEUNICODE] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
	);
		print 'CONFIRMSTATE TABLOSU KURULDU'
end else
	print 'CONFIRMSTATE TABLOSU KURULMUÞ'

if object_id(N'dbo.AGADTYPE', N'U') is  null
begin
	create table [dbo].[AGADTYPE] (
    [Id]          INT           NOT NULL,
    [NAME]        NVARCHAR (50) NOT NULL,
    [NAMEUNICODE] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
	);
	print 'AGADTYPE TABLOSU KURULDU'
end else
	print 'AGADTYPE TABLOSU KURULMUÞ'

if object_id(N'dbo.AGAD', N'U') is  null
begin
	create table [dbo].[AGAD] (
    [Id]             INT            NOT NULL,
    [AGADTYPE]       INT            NOT NULL,
    [STARTDATE]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [ENDDATE]        DATETIME       DEFAULT (getdate()) NOT NULL,
    [TIME]           INT            DEFAULT ((0)) NOT NULL,
    [IL]             NVARCHAR (50)  NOT NULL,
    [ILCESEMT]       NVARCHAR (50)  NOT NULL,
    [KOY]            NVARCHAR (50)  NULL,
    [MAHALLE]        NVARCHAR (50)  NULL,
    [BELDEMEVKI]     NVARCHAR (50)  NULL,
    [LATITUDE]       NVARCHAR (50)  NULL,
    [LONGITUDE]      NVARCHAR (50)  NULL,
    [COMMENT]        NVARCHAR (50)  NULL,
    [EFFECTTEDAREA]  NVARCHAR (50)  NULL,
    [IMAGEPATH]      NVARCHAR (MAX) NULL,
    [CONFIRMSTATEID] INT            NOT NULL,
    [CONFIRMCOMMENT] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AGAD_ToTable] FOREIGN KEY ([AGADTYPE]) REFERENCES [dbo].[AGADTYPE] ([Id]),
    CONSTRAINT [FK_AGAD_ToTable_1] FOREIGN KEY ([CONFIRMSTATEID]) REFERENCES [dbo].[CONFIRMSTATE] ([Id])
	);
	print 'AGAD TABLOSU KURULDU'
end else
	print 'AGAD TABLOSU KURULMUÞ'
