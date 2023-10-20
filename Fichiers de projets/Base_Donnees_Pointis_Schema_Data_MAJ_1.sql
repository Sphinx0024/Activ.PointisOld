USE [Pointis]
GO
/****** Object:  Table [dbo].[Societe]    Script Date: 14/04/2023 11:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Societe](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RaisonSociale] [varchar](255) NOT NULL,
	[RCCM] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Telephone] [varchar](50) NULL,
 CONSTRAINT [PK_Societe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pointage]    Script Date: 14/04/2023 11:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pointage](
	[PointageID] [bigint] IDENTITY(1,1) NOT NULL,
	[Jour] [date] NOT NULL,
	[HeureEntree] [datetime] NOT NULL,
	[HeureSortie] [datetime] NULL,
	[EmployesID] [bigint] NULL,
	[Imei_employe_entree] [varchar](50) NOT NULL,
	[Imei_employe_sortie] [varchar](50) NULL,
	[Imei_verificateur_entree] [varchar](50) NOT NULL,
	[Imei_verificateur_sortie] [varchar](50) NULL,
	[Application_id_entree] [varchar](50) NOT NULL,
	[Application_id_sortie] [varchar](50) NULL,
 CONSTRAINT [PK_Pointage] PRIMARY KEY CLUSTERED 
(
	[PointageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employes]    Script Date: 14/04/2023 11:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employes](
	[EmployeID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
	[Prenom] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Telephone] [varchar](50) NOT NULL,
	[Sexe] [varchar](50) NOT NULL,
	[SocieteID] [bigint] NOT NULL,
	[Titre] [varchar](255) NOT NULL,
	[Matricule] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employes] PRIMARY KEY CLUSTERED 
(
	[EmployeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Pointage]    Script Date: 14/04/2023 11:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Pointage]
AS
SELECT        dbo.Employes.EmployeID, dbo.Employes.Nom AS EmployeNom, dbo.Employes.Prenom AS EmployePrenom, dbo.Employes.Email AS EmployeEmail, dbo.Employes.Telephone AS EmployeTelephone, 
                         dbo.Employes.Sexe AS EmployeSexe, dbo.Employes.SocieteID, dbo.Societe.RaisonSociale AS SocieteRaisonSociale, dbo.Societe.RCCM AS SocieteRCCM, dbo.Societe.Email AS SocieteEmail, 
                         dbo.Societe.Telephone AS SocieteTelephone, dbo.Pointage.PointageID, dbo.Pointage.Jour AS PointageJour, dbo.Pointage.HeureEntree AS PointageHeureEntree, dbo.Pointage.HeureSortie AS PointageHeureSortie, 
                         DATEDIFF(Second, dbo.Pointage.HeureSortie, dbo.Pointage.HeureEntree) AS PointageDureeSeconde, DATEDIFF(Hour, dbo.Pointage.HeureSortie, dbo.Pointage.HeureEntree) AS PointageDureeHeure, DATEDIFF(Minute, 
                         dbo.Pointage.HeureSortie, dbo.Pointage.HeureEntree) AS PointageDureeMinute, dbo.Employes.Titre AS EmployeTitre, dbo.Employes.Matricule AS EmployeMatricule
FROM            dbo.Employes INNER JOIN
                         dbo.Societe ON dbo.Employes.SocieteID = dbo.Societe.ID INNER JOIN
                         dbo.Pointage ON dbo.Employes.EmployeID = dbo.Pointage.EmployesID
GO
/****** Object:  Table [dbo].[Connexion]    Script Date: 14/04/2023 11:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connexion](
	[ConnexionID] [bigint] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[EmployeID] [bigint] NULL,
	[Role] [varchar](50) NULL,
 CONSTRAINT [PK_Connexion] PRIMARY KEY CLUSTERED 
(
	[ConnexionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailsConnexion]    Script Date: 14/04/2023 11:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailsConnexion](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[telephone_imei] [varchar](50) NOT NULL,
	[date_connexion] [datetime] NOT NULL,
	[numero_telephone] [varchar](50) NOT NULL,
	[Longitude] [varchar](50) NOT NULL,
	[Latitude] [varchar](50) NOT NULL,
	[ApplicationID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DetailsConnexion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 14/04/2023 11:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[NotifcationBody] [varchar](max) NOT NULL,
	[SMSNumber] [varchar](50) NULL,
	[SMSSender] [varchar](50) NULL,
	[MAILFrom] [varchar](50) NULL,
	[MAILTo] [varchar](50) NULL,
	[MAILSubject] [varchar](255) NULL,
	[NotifcationNature] [varchar](10) NOT NULL,
	[NotificationStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Connexion]  WITH CHECK ADD  CONSTRAINT [FK_Connexion_Employes] FOREIGN KEY([EmployeID])
REFERENCES [dbo].[Employes] ([EmployeID])
GO
ALTER TABLE [dbo].[Connexion] CHECK CONSTRAINT [FK_Connexion_Employes]
GO
ALTER TABLE [dbo].[Employes]  WITH CHECK ADD  CONSTRAINT [FK_Employes_Societe] FOREIGN KEY([SocieteID])
REFERENCES [dbo].[Societe] ([ID])
GO
ALTER TABLE [dbo].[Employes] CHECK CONSTRAINT [FK_Employes_Societe]
GO
ALTER TABLE [dbo].[Pointage]  WITH CHECK ADD  CONSTRAINT [FK_Pointage_Employes] FOREIGN KEY([EmployesID])
REFERENCES [dbo].[Employes] ([EmployeID])
GO
ALTER TABLE [dbo].[Pointage] CHECK CONSTRAINT [FK_Pointage_Employes]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Employes"
            Begin Extent = 
               Top = 20
               Left = 216
               Bottom = 217
               Right = 386
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Societe"
            Begin Extent = 
               Top = 12
               Left = 10
               Bottom = 220
               Right = 180
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Pointage"
            Begin Extent = 
               Top = 24
               Left = 441
               Bottom = 213
               Right = 611
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Pointage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Pointage'
GO
