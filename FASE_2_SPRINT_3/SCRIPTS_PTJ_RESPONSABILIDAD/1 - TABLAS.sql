USE [SIGANEM]
GO

/*SE ELIMINAN TABLAS TEMPORALES*/
/****** Object:  Table [dbo].[AUX_SALDOS]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_SALDOS]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_SALDOS]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D2_5]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D2_5]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D2_5]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D2_4]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D2_4]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D2_4]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D2_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D2_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D2_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D2_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D2_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D2_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D2_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D2_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D2_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D1_4]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D1_4]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D1_4]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D1_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D1_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D1_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D1_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D1_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D1_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D1_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D1_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D1_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_D]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_D]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_D]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C2_4]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C2_4]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C2_4]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C2_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C2_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C2_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C2_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C2_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C2_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C2_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C2_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C2_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C1_4]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C1_4]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C1_4]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C1_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C1_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C1_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C1_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C1_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C1_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C1_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C1_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C1_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C_4]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C_4]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C_4]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_C]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_C]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_C]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_B_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_B_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_B_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_B]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_B]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_B]
GO
/****** Object:  Table [dbo].[AUX_PCJ_OPERACIONES_A]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_OPERACIONES_A]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_OPERACIONES_A]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D2_6]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D2_6]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D2_6]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D2_5]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D2_5]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D2_5]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D2_4]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D2_4]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D2_4]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D2_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D2_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D2_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D2_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D2_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D2_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D2_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D2_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D2_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D1_6]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D1_6]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D1_6]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D1_5]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D1_5]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D1_5]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D1_4]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D1_4]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D1_4]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D1_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D1_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D1_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D1_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D1_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D1_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D1_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D1_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D1_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D_6]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D_6]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D_6]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D_5]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D_5]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D_5]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D_4]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D_4]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D_4]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_D]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_D]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_D]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_C2_3]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_C2_3]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_C2_3]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_C2_2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_C2_2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_C2_2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_C2_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_C2_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_C2_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_C2]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_C2]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_C2]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_C1_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_C1_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_C1_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_C1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_C1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_C1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_C_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_C_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_C_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_C]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_C]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_C]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_B_1]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_B_1]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_B_1]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_B]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_B]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_B]
GO
/****** Object:  Table [dbo].[AUX_PCJ_GARANTIAS_A]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_PCJ_GARANTIAS_A]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_PCJ_GARANTIAS_A]
GO
/****** Object:  Table [dbo].[AUX_GAR_PRC_ACP_TERRENO_R]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_PRC_ACP_TERRENO_R]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_PRC_ACP_TERRENO_R]
GO
/****** Object:  Table [dbo].[AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R]
GO
/****** Object:  Table [dbo].[AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA]
GO
/****** Object:  Table [dbo].[AUX_GAR_PRC_ACP_TERRENO]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_PRC_ACP_TERRENO]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_PRC_ACP_TERRENO]
GO
/****** Object:  Table [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_R]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_R]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_R]
GO
/****** Object:  Table [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION]
GO
/****** Object:  Table [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R]
GO
/****** Object:  Table [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA]
GO
/****** Object:  Table [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO]
GO
/****** Object:  Table [dbo].[AUX_GAR_MTO_ACT_TERRENO]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_MTO_ACT_TERRENO]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_MTO_ACT_TERRENO]
GO
/****** Object:  Table [dbo].[AUX_GAR_MTO_ACT_NO_TERRENO]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_MTO_ACT_NO_TERRENO]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_MTO_ACT_NO_TERRENO]
GO
/****** Object:  Table [dbo].[AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS]
GO
/****** Object:  Table [dbo].[AUX_GAR_MONTO_MITIGADOR]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_GAR_MONTO_MITIGADOR]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_GAR_MONTO_MITIGADOR]
GO
/****** Object:  Table [dbo].[AUX_CONSULTA_SALDOS]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_CONSULTA_SALDOS]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_CONSULTA_SALDOS]
GO
/****** Object:  Table [dbo].[AUX_CATEGORIA]    Script Date: 19/08/2016 08:40:42 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUX_CATEGORIA]') AND type in (N'U'))
DROP TABLE [dbo].[AUX_CATEGORIA]
GO
