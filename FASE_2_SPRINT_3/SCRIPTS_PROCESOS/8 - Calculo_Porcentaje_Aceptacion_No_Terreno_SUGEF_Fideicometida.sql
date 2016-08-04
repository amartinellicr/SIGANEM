USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Porcentaje_Aceptacion_No_Terreno_SUGEF_Fideicometida', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Porcentaje_Aceptacion_No_Terreno_SUGEF_Fideicometida;
GO


CREATE PROCEDURE [dbo].[Calculo_Porcentaje_Aceptacion_No_Terreno_SUGEF_Fideicometida]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Porcentaje_Aceptacion_No_Terreno_SUGEF_Fideicometida</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que se encarga de calcular y actualizar el porcentaje de aceptación del no terreno que se envía a SUGEF de las garantías de reales relacionadas a fideicomisos</Descripción>
<Entradas>
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Marín</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>29/06/2016</Fecha>
<Versión>1.0</Versión>
<Historial>
    <Cambio>
		<Autor></Autor>
		<Requerimiento></Requerimiento>
		<Fecha></Fecha>
		<Descripción></Descripción>
    </Cambio>
</Historial>
******************************************************************************************************************************************************/
BEGIN
	BEGIN TRANSACTION TRA_Insertar
	BEGIN TRY

	IF OBJECT_ID('[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA]') is not null
		DROP TABLE [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA]


	CREATE TABLE [dbo].AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA(
		[Id_Garantia_Fideicomiso] [int] NOT NULL,
		[Cod_Tipo_Bien] [int] NULL,
		[Cod_Clase_Tipo_Bien] [int] NULL,
		[Validacion_1] [int] NOT NULL,
		[Validacion_2] [int] NOT NULL,
		[Validacion_3] [int] NOT NULL,
		[Validacion_4] [int] NOT NULL,
		[Validacion_5] [int] NOT NULL,
		[Validacion_6] [int] NOT NULL,
		[Validacion_7] [int] NOT NULL,
		[Validacion_8] [int] NOT NULL,
		[Validacion_9] [int] NOT NULL,
		[Porcentaje_Aceptacion_No_Terreno_SUGEF] [decimal](5, 2) NULL
	) ON [PRIMARY]
	
	INSERT INTO dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA
			   (Id_Garantia_Fideicomiso,
			    Cod_Tipo_Bien,
				Cod_Clase_Tipo_Bien,
				Validacion_1,
				Validacion_2,
				Validacion_3,
				Validacion_4,
				Validacion_5,
				Validacion_6,
				Validacion_7,
				Validacion_8,
				Validacion_9,
				Porcentaje_Aceptacion_No_Terreno_SUGEF
				)
		SELECT --Reales
			GARFID.Id_Garantia_Fideicomiso,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN GARFID.Fecha_Presentacion IS NULL AND GARFID.Id_Tipo_Indicador_Inscripcion = 1 
									THEN 1
									ELSE 0
							END,
			Validacion_2 = CASE WHEN GARFID.Fecha_Presentacion IS NOT NULL AND GARFID.Id_Tipo_Indicador_Inscripcion = 4 AND (DATEADD(D,60, FID.Fecha_Constitucion)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_3 = CASE WHEN GARFID.Fecha_Presentacion IS NOT NULL AND GARFID.Id_Tipo_Indicador_Inscripcion = 4 
								THEN 1
								ELSE 0
							END,
			Validacion_4 = CASE WHEN DATEADD(M, PAR.Meses_Vencimiento_Avaluo_SUGEF_Edificacion, GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_5 = CASE WHEN DATEADD(M, PAR.Meses_Seguimiento_Edificacion, GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_7 = CASE WHEN  DATEADD(D, 30, GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_8 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_9 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		INNER JOIN dbo.FIDEICOMISOS FID
			ON FID.Id_Fideicomiso = GARFID.Id_Fideicomiso
			AND FID.Ind_Estado_Registro = 1
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GARFID.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
			AND TM.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GARFID.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2

	UNION
		
		SELECT 
			GARFID.Id_Garantia_Fideicomiso,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN GARFID.Fecha_Presentacion IS NULL AND GARFID.Id_Tipo_Indicador_Inscripcion = 1 
									THEN 1
									ELSE 0
							END,
			Validacion_2 = CASE WHEN GARFID.Fecha_Presentacion IS NOT NULL AND GARFID.Id_Tipo_Indicador_Inscripcion = 3 AND (DATEADD(D,60, FID.Fecha_Constitucion)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_3 = CASE WHEN GARFID.Fecha_Presentacion IS NOT NULL AND GARFID.Id_Tipo_Indicador_Inscripcion = 4 
								THEN 1
								ELSE 0
							END,
			Validacion_4 = CASE WHEN DATEADD(M, PAR.Meses_Seguimiento_Vehiculo, GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_5 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN  DATEADD(D, 30, GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_7 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_8 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			Validacion_9 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		INNER JOIN dbo.FIDEICOMISOS FID
			ON FID.Id_Fideicomiso = GARFID.Id_Fideicomiso
			AND FID.Ind_Estado_Registro = 1
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GARFID.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
			AND TM.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GARFID.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 3
			AND CTB.Cod_Clase_Tipo_Bien = 2

	
	UNION

		SELECT 
			GARFID.Id_Garantia_Fideicomiso,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN DATEADD(M,CASE WHEN TPB.Cod_Tipo_Bien = 4 --Maquinaria Equipo
													THEN  PAR.Meses_Vencimiento_Avaluo_Maquinaria_Equipo
													WHEN TPB.Cod_Tipo_Bien = 6 --Materia Prima
													THEN  PAR.Meses_Vencimiento_Avaluo_Materia_Prima
													WHEN TPB.Cod_Tipo_Bien = 7 --Mobiliario
													THEN  PAR.Meses_Vencimiento_Avaluo_Mobiliario
													WHEN TPB.Cod_Tipo_Bien = 8 --Maderas
													THEN  PAR.Meses_Vencimiento_Avaluo_Madera
													WHEN TPB.Cod_Tipo_Bien = 9 --Aeronave
													THEN  PAR.Meses_Vencimiento_Avaluo_Aeronave
													WHEN TPB.Cod_Tipo_Bien = 10 --Buques
													THEN  PAR.Meses_Vencimiento_Avaluo_Buque
													WHEN TPB.Cod_Tipo_Bien = 11 --Animales
													THEN  PAR.Meses_Vencimiento_Avaluo_Animal
													WHEN TPB.Cod_Tipo_Bien = 12 --Cultivos y Frutos
													THEN  PAR.Meses_Vencimiento_Avaluo_Cultivo_Fruto
													WHEN TPB.Cod_Tipo_Bien = 13 --Alhaja
													THEN  PAR.Meses_Vencimiento_Avaluo_Alhaja
													WHEN TPB.Cod_Tipo_Bien = 14 --Otros Bienes
													THEN  PAR.Meses_Vencimiento_Avaluo_Otro_Tipo_Bien
												END,GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_2 = CASE WHEN DATEADD(M,CASE WHEN TPB.Cod_Tipo_Bien = 4 --Maquinaria Equipo
													THEN  PAR.Meses_Seguimiento_Maquinaria_Equipo
													WHEN TPB.Cod_Tipo_Bien = 6 --Materia Prima
													THEN  PAR.Meses_Seguimiento_Materia_Prima
													WHEN TPB.Cod_Tipo_Bien = 7 --Mobiliario
													THEN  PAR.Meses_Seguimiento_Mobiliario
													WHEN TPB.Cod_Tipo_Bien = 8 --Maderas
													THEN  PAR.Meses_Seguimiento_Maderas
													WHEN TPB.Cod_Tipo_Bien = 9 --Aeronave
													THEN  PAR.Meses_Seguimiento_Aeronave
													WHEN TPB.Cod_Tipo_Bien = 10 --Buques
													THEN  PAR.Meses_Seguimiento_Buque
													WHEN TPB.Cod_Tipo_Bien = 11 --Animales
													THEN  PAR.Meses_Seguimiento_Animal
													WHEN TPB.Cod_Tipo_Bien = 12 --Cultivos y Frutos
													THEN  PAR.Meses_Seguimiento_Cultivo_Fruto
													WHEN TPB.Cod_Tipo_Bien = 13 --Alhaja
													THEN  PAR.Meses_Seguimiento_Alhaja
													WHEN TPB.Cod_Tipo_Bien = 14 --Otros Bienes
													THEN  PAR.Meses_Seguimiento_Otros_Bienes
												END,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_3 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_4 = CASE WHEN DATEADD(D,30,GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_5 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			Validacion_7 = 0,
			Validacion_8 = 0,
			Validacion_9 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		INNER JOIN dbo.FIDEICOMISOS FID
			ON FID.Id_Fideicomiso = GARFID.Id_Fideicomiso
			AND FID.Ind_Estado_Registro = 1
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GARFID.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = ISNULL(GAR.Id_Clase_Tipo_Bien, CTB.Id_Clase_Tipo_Bien)
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
			AND TM.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GARFID.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)	

	
	UNION

		SELECT 
			GARFID.Id_Garantia_Fideicomiso,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN DATEADD(M,PAR.Meses_Seguimiento_Equipo_Computo,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_2 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_3 = CASE WHEN DATEADD(D,30,GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_4 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_5 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = 0,
			Validacion_7 = 0,
			Validacion_8 = 0,
			Validacion_9 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		INNER JOIN dbo.FIDEICOMISOS FID
			ON FID.Id_Fideicomiso = GARFID.Id_Fideicomiso
			AND FID.Ind_Estado_Registro = 1
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GARFID.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = ISNULL(GAR.Id_Clase_Tipo_Bien, CTB.Id_Clase_Tipo_Bien)
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
			AND TM.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GARFID.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 5

	UNION
		--Valores
		SELECT 
			GARFID.Id_Garantia_Fideicomiso,
			Cod_Tipo_Bien = NULL,
			Cod_Clase_Tipo_Bien = NULL,
			Validacion_1 = 0,
			Validacion_2 = 0,
			Validacion_3 = 0,
			Validacion_4 = 0,
			Validacion_5 = 0,
			Validacion_6 = 0,
			Validacion_7 = 0,
			Validacion_8 = 0,
			Validacion_9 = 0,
			ISNULL((ISNULL(CAT.Porc_Aceptacion_Calificacion_Riesgo,CAT1.Porc_Aceptacion_Calificacion_Riesgo)), CAT2.Porc_Aceptacion_Calificacion_Riesgo) Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		INNER JOIN dbo.GARANTIAS_VALORES GAV
			ON GARFID.Id_Garantia_Valor = GAV.Id_Garantia_Valor
			AND GAV.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GARFID.Id_Tipo_Garantia
			AND CAT.Id_Categoria_Calificacion = GAV.Id_Categoria_Riesgo_Empresa_Calificadora 
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT1
			ON CAT1.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
			AND CAT1.Id_Tipo_Garantia = GARFID.Id_Tipo_Garantia
			AND CAT1.Id_Categoria_Calificacion = 2 --NO APLICA CALIFICACION
			AND CAT1.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT2
			ON CAT2.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
			AND CAT2.Id_Tipo_Garantia = GARFID.Id_Tipo_Garantia
			AND CAT2.Id_Categoria_Calificacion = 1 --SIN CALIFICACION
			AND CAT2.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GARFID.Ind_Estado_Registro = 1

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ON dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA
	(
		Id_Garantia_Fideicomiso ASC
	)

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_NO_TERRENO__FIDEICOMETIDA_1 ON dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA
	(
		Cod_Tipo_Bien ASC
	)

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_NO_TERRENO__FIDEICOMETIDA_2 ON dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA
	(
		Cod_Tipo_Bien ASC,
		Cod_Clase_Tipo_Bien ASC
	)

	IF OBJECT_ID('[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION]') is not null
		DROP TABLE [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION]


	CREATE TABLE [dbo].AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION(
		[Id_Fideicomiso] [int] NOT NULL,
		[Id_Garantia_Fideicomiso] [int] NOT NULL,
		[Id_Operacion] [int] NOT NULL,
		[Id_Fideicomiso_BCR] varchar(14) NOT NULL,
		[Categoria_Riesgo_Deudor] varchar(2) NULL
	) ON [PRIMARY]

	/*SE OBTIENEN LOS FIEDICOMISOS QUE ESTÁN RELACIONADOS A MAS DE UNA OPERACIÓN Y/O CONTRATO*/
	INSERT INTO dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION
		(
		Id_Fideicomiso,
		Id_Garantia_Fideicomiso,
		Id_Operacion,
		Id_Fideicomiso_BCR,
		Categoria_Riesgo_Deudor
		)
	SELECT FID.Id_Fideicomiso, GARFID.Id_Garantia_Fideicomiso, OPER.Id_Operacion, FID.Id_Fideicomiso_BCR, OPER.Categoria_Riesgo_Deudor
	FROM dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.FIDEICOMISOS FID
		ON FID.Id_Fideicomiso = GAROPER.Id_Fideicomiso
		AND FID.Ind_Estado_Registro = 1
		INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		ON GARFID.Id_Fideicomiso = FID.Id_Fideicomiso
		AND GARFID.Ind_Estado_Registro = 1
		INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
		AND OPER.Ind_Estado_Registro = 1
		INNER JOIN (SELECT	FI1.Id_Fideicomiso_BCR
					FROM	dbo.FIDEICOMISOS FI1
						INNER JOIN dbo.GARANTIAS_OPERACIONES GAROP
						ON FI1.Id_Fideicomiso = GAROP.Id_Fideicomiso
						AND GAROP.Ind_Estado_Registro = 1
					WHERE FI1.Ind_Estado_Registro = 1
					GROUP BY FI1.Id_Fideicomiso_BCR
					HAVING COUNT(*) > 1 
					) TEMP
		ON TEMP.Id_Fideicomiso_BCR = FID.Id_Fideicomiso_BCR
	WHERE	GAROPER.Ind_Estado_Registro = 1
	

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION ON dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION
	(
		Id_Fideicomiso_BCR ASC,
		Categoria_Riesgo_Deudor ASC,
		Id_Operacion ASC
	)

	/*Se eliminan los registros de duplicados*/
	;WITH FIDEICOMISOS_RELACIONADOS (Id_Operacion, Id_Fideicomiso, Id_Fideicomiso_BCR, cantidadRegistrosDuplicados)
	AS
	(
		SELECT	Id_Operacion, Id_Fideicomiso, Id_Fideicomiso_BCR, 
				ROW_NUMBER() OVER(PARTITION BY Id_Operacion, Id_Fideicomiso_BCR, Categoria_Riesgo_Deudor ORDER BY Id_Operacion) AS cantidadRegistrosDuplicados
		FROM	dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION
	)
	DELETE
	FROM FIDEICOMISOS_RELACIONADOS
	WHERE cantidadRegistrosDuplicados > 1;
	

	IF OBJECT_ID('[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R]') is not null
		DROP TABLE [dbo].AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R

	CREATE TABLE [dbo].AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R(
		[Id_Garantia_Fideicomiso] [int] NOT NULL,
		[Porcentaje_Aceptacion_No_Terreno_SUGEF] [decimal](5, 2) NULL
	) ON [PRIMARY]
	

	INSERT INTO dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R
		(
		Id_Garantia_Fideicomiso,
		Porcentaje_Aceptacion_No_Terreno_SUGEF
		)
	SELECT 
		Id_Garantia_Fideicomiso,
		MIN(Porcentaje_Aceptacion_No_Terreno_SUGEF)  Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM 
	(
	/*SE OBTIENE EL PORCENTAJE DE LOS REGISTROS CON TIPO DE BIEN IGUAL A 2*/
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0) THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0 AND Validacion_4 = 0 
		           AND Validacion_5 = 0 AND Validacion_6 = 0 AND Validacion_7 = 0 AND Validacion_8 = 0
				   AND Validacion_9 = 0 THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_4 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_5 = 0 AND GARFID.Ind_Deudor_Habita = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
		INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		ON GARFID.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_5 = 0 AND GARFID.Ind_Deudor_Habita = 1 AND GAROPER.Id_Fideicomiso IS NULL THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
		INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		ON GARFID.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
		AND GARFID.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Fideicomiso = GARFID.Id_Fideicomiso
		AND GAROPER.Ind_Estado_Registro = 1
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_5 = 0 AND GARFID.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('A1','A2','B1','B2','C1')  THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
			 WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_5 = 0 AND GARFID.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('C2','D','E') THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
		INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		ON GARFID.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Fideicomiso = GARFID.Id_Fideicomiso
		AND GAROPER.Ind_Estado_Registro = 1
		INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
		AND OPER.Ind_Estado_Registro = 1
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_5 = 0 AND GARFID.Ind_Deudor_Habita = 1 AND TMP.Categoria_Riesgo_Deudor IN ('A1','A2','B1','B2','C1', 'C2','D','E') AND ISNULL(TM1.CANTIDAD_REGISTROS, 0) > 1 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
		INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		ON GARFID.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Fideicomiso = GARFID.Id_Fideicomiso
		AND GAROPER.Ind_Estado_Registro = 1
		INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
		AND OPER.Ind_Estado_Registro = 1
		INNER JOIN dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION TMP
		ON TMP.Id_Operacion = OPER.Id_Operacion
		AND TMP.Id_Fideicomiso = GARFID.Id_Fideicomiso
		AND TMP.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
		INNER JOIN (SELECT Id_Fideicomiso_BCR, Categoria_Riesgo_Deudor, COUNT(*) AS CANTIDAD_REGISTROS
					FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION
					GROUP BY Id_Fideicomiso_BCR, Categoria_Riesgo_Deudor
					HAVING COUNT(*) > 1) TM1
		ON TM1.Id_Fideicomiso_BCR = TMP.Id_Fideicomiso_BCR
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_6 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_7 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_8 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_9 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 2
	
	--Tipo Bien 3 Prenda Comun
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0) THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 3
		AND Cod_Clase_Tipo_Bien = 3
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0 AND Validacion_4 = 0 
		           AND Validacion_5 = 0 AND Validacion_6 = 0 AND Validacion_7 = 0 AND Validacion_8 = 0
		     THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_4 = 0 AND GARFID.Id_Garantia_Fideicomiso IS NULL THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
		INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		ON GARFID.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
		LEFT JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Fideicomiso = GARFID.Id_Fideicomiso
		AND GAROPER.Ind_Estado_Registro = 1
	WHERE 
		Cod_Tipo_Bien = 3
		AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_4 = 0 AND OPER.Categoria_Riesgo_Deudor IN ('A1','A2','B1','B2','C1')  THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
			 WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_4 = 0 AND OPER.Categoria_Riesgo_Deudor IN ('C2','D','E') THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
		INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		ON GARFID.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Fideicomiso = GARFID.Id_Fideicomiso
		AND GAROPER.Ind_Estado_Registro = 1
		INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
		AND OPER.Ind_Estado_Registro = 1
	WHERE 
		Cod_Tipo_Bien = 3
		AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_4 = 0 AND TMP.Categoria_Riesgo_Deudor IN ('A1','A2','B1','B2','C1', 'C2','D','E') AND ISNULL(TM1.CANTIDAD_REGISTROS, 0) > 1 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
		INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		ON GARFID.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Fideicomiso = GARFID.Id_Fideicomiso
		AND GAROPER.Ind_Estado_Registro = 1
		INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
		AND OPER.Ind_Estado_Registro = 1
		INNER JOIN dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION TMP
		ON TMP.Id_Operacion = OPER.Id_Operacion
		AND TMP.Id_Fideicomiso = GARFID.Id_Fideicomiso
		AND TMP.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
		INNER JOIN (SELECT Id_Fideicomiso_BCR, Categoria_Riesgo_Deudor, COUNT(*) AS CANTIDAD_REGISTROS
					FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMISO_OPERACION
					GROUP BY Id_Fideicomiso_BCR, Categoria_Riesgo_Deudor
					HAVING COUNT(*) > 1) TM1
		ON TM1.Id_Fideicomiso_BCR = TMP.Id_Fideicomiso_BCR
	WHERE 
		Cod_Tipo_Bien = 3
		AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 3
		AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_6 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 3
		AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_7 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 3
		AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_8 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 3
		AND Cod_Clase_Tipo_Bien = 2

	-- Tipo Bien 4,6,7,8,9,10,11,12,13,14
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_1 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_2 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_3 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_4 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_6 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)

	--Tipo Bien 5
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_1 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien = 5
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_2 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien = 5
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_3 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien = 5
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_4 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien = 5
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien = 5
	
	UNION
	--Valores
	SELECT 
		Id_Garantia_Fideicomiso,
		Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien IS NULL
	AND Cod_Clase_Tipo_Bien IS NULL

	) T 
	GROUP BY T.Id_Garantia_Fideicomiso

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R ON dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R
	(
		Id_Garantia_Fideicomiso ASC
	)

	--Tipo Bien 2
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF = CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) 
																AND (Validacion_4 = 1 AND Validacion_5 = 1 AND Validacion_6 = 1
																AND Validacion_7 = 1 AND Validacion_8 = 1 AND Validacion_9 = 1)
														   THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
													  END 
	FROM	dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 2


	--Tipo Bien 3 Prenda Común
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF = CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) 
																AND (Validacion_4 = 1 AND Validacion_5 = 1 AND Validacion_6 = 1
																AND Validacion_7 = 1 AND Validacion_8 = 1)
														   THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
													  END 
	FROM	dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien = 3
		AND Cod_Clase_Tipo_Bien = 2


	--Tipo Bien 4,6,7,8,9,10,11,12,13,14
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF = CASE WHEN Validacion_1 = 1 AND Validacion_2 = 1 AND
																   Validacion_3 = 1 AND Validacion_4 = 1 AND
																  Validacion_5 = 1 AND Validacion_6 = 1
															 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
															END 
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)

	--Tipo Bien 5
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF =	CASE WHEN Validacion_1 = 1 AND Validacion_2 = 1 AND
																	Validacion_3 = 1 AND Validacion_4 = 1 AND
																	Validacion_5 = 1 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
															END 
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
	WHERE Cod_Tipo_Bien = 5
		
	
	--Valores
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF = ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IS NULL
	AND Cod_Clase_Tipo_Bien IS NULL



	UPDATE		GAR
	SET			GAR.Porcentaje_Aceptacion_No_Terreno_SUGEF =	CASE WHEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF IS NOT NULL
																	 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
																	 ELSE ACT_1.Porcentaje_Aceptacion_No_Terreno_SUGEF
																END
	FROM		
		dbo.GARANTIAS_FIDEICOMETIDAS GAR
	INNER JOIN	AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT 
		ON GAR.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
	INNER JOIN AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R ACT_1
		ON GAR.Id_Garantia_Fideicomiso = ACT_1.Id_Garantia_Fideicomiso
	WHERE Cod_Tipo_Bien IS NOT NULL
	AND Cod_Clase_Tipo_Bien IS NOT NULL

	/*SE ASIGNA EL PORCENTAJE CALCULADO PARA LAS GARANTIAS VALOR*/
	UPDATE		GAR
	SET			GAR.Porcentaje_Aceptacion_SUGEF =	CASE WHEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF IS NOT NULL
														 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
														 ELSE ACT_1.Porcentaje_Aceptacion_No_Terreno_SUGEF
													END
	FROM		
		dbo.GARANTIAS_FIDEICOMETIDAS GAR
	INNER JOIN	AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT 
		ON GAR.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
	INNER JOIN AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R ACT_1
		ON GAR.Id_Garantia_Fideicomiso = ACT_1.Id_Garantia_Fideicomiso
	WHERE Cod_Tipo_Bien IS NULL
	AND Cod_Clase_Tipo_Bien IS NULL


		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END



