USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Porcentaje_Aceptacion_Terreno_SUGEF', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Porcentaje_Aceptacion_Terreno_SUGEF;
GO


CREATE PROCEDURE [dbo].[Calculo_Porcentaje_Aceptacion_Terreno_SUGEF]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Porcentaje_Aceptacion_Terreno_SUGEF</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo automático Porcentaje Aceptación Terreno SUGEF
	Esta formulación aplica únicamente para bienes tipo 1 y 2
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Alexander Cruz</Autor>
<Fecha>Octubre 2015</Fecha>
<Requerimiento>RQ_MANT_2015062310417367_00045 Porcentaje Aceptación Terreno SUGEF</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli M.</Autor>
		<Requerimiento>Modificación en el Mantenimiento de Garantías Reales (PBI 10800)</Requerimiento>
		<Fecha>Septiembre 2016</Fecha>
		<Descripción>Se ajusta el cálculo a los nuevos lineamientos emitidos por la SUGEF</Descripción>
	</Cambio>
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

	IF OBJECT_ID('[dbo].[AUX_GAR_PRC_ACP_TERRENO]') is not null
		DROP TABLE [dbo].[AUX_GAR_PRC_ACP_TERRENO]


	CREATE TABLE [dbo].AUX_GAR_PRC_ACP_TERRENO(
		[Id_Garantia_Operacion] [int] NOT NULL,
		[Cod_Tipo_Bien] [int] NOT NULL,
		[Cod_Clase_Tipo_Bien] [int] NOT NULL,
		[Validacion_1] [int] NOT NULL,
		[Validacion_2] [int] NOT NULL,
		[Validacion_3] [int] NOT NULL,
		[Validacion_4] [int] NOT NULL,
		[Validacion_5] [int] NOT NULL,
		[Validacion_6] [int] NOT NULL,
		[Porcentaje_Aceptacion_Terreno_SUGEF] [decimal](5, 2) NULL
	) ON [PRIMARY]
	

	INSERT INTO dbo.AUX_GAR_PRC_ACP_TERRENO
			   (Id_Garantia_Operacion,
			    Cod_Tipo_Bien,
				Cod_Clase_Tipo_Bien,
				Validacion_1,
				Validacion_2,
				Validacion_3,
				Validacion_4,
				Validacion_5,
				Validacion_6,
				Porcentaje_Aceptacion_Terreno_SUGEF
				)
		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN GRI.Fecha_Anotacion IS NOT NULL AND GRI.Fecha_Inscripcion IS NOT NULL 
									THEN 1
									ELSE 0
							END,
			Validacion_2 = CASE WHEN GRI.Fecha_Anotacion IS NULL AND GRI.Fecha_Inscripcion IS NULL AND (DATEADD(D,30,GAROPER.Fecha_Constitucion_Garantia)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_3 = CASE WHEN GRI.Fecha_Anotacion IS NULL AND GRI.Fecha_Inscripcion IS NOT NULL 
								THEN 1
								ELSE 0
							END,
			Validacion_4 = CASE WHEN GRI.Fecha_Anotacion IS NOT NULL AND GRI.Fecha_Inscripcion IS NULL AND (DATEADD(D,60,GAROPER.Fecha_Constitucion_Garantia)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_5 = CASE WHEN DATEADD(M,PAR.Meses_Vencimiento_Avaluo_SUGEF_Terreno,GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN DATEADD(M,PAR.Meses_Seguimiento_Terreno,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
			AND TM.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 1
			AND CTB.Cod_Clase_Tipo_Bien IN (1,3)

	UNION

		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN GRI.Fecha_Anotacion IS NOT NULL AND GRI.Fecha_Inscripcion IS NOT NULL 
								THEN 1
								ELSE 0
							END,
			Validacion_2 =	CASE WHEN GRI.Id_Garantia_Operacion IS NULL AND (DATEADD(D, 30, GAROPER.Fecha_Constitucion_Garantia)) > GETDATE()
									THEN 1
								 WHEN GRI.Id_Garantia_Operacion IS NOT NULL AND GRI.Fecha_Anotacion IS NULL AND GRI.Fecha_Inscripcion IS NULL AND (DATEADD(D,30,GAROPER.Fecha_Constitucion_Garantia)) > GETDATE()
									THEN 1
								 ELSE 0
							END,
			Validacion_3 = CASE WHEN GRI.Fecha_Anotacion IS NULL AND GRI.Fecha_Inscripcion IS NOT NULL 
								THEN 1
								ELSE 0
							END,
			Validacion_4 = CASE WHEN GRI.Fecha_Anotacion IS NOT NULL AND GRI.Fecha_Inscripcion IS NULL AND (DATEADD(D,60,GAROPER.Fecha_Constitucion_Garantia)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_5 = CASE WHEN DATEADD(M,PAR.Meses_Vencimiento_Avaluo_SUGEF_Edificacion,GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN DATEADD(M,PAR.Meses_Seguimiento_Edificacion,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
			AND TM.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2
			AND CTB.Cod_Clase_Tipo_Bien IN (1,3)

	UNION
		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN DATEADD(M,PAR.Meses_Vencimiento_Avaluo_SUGEF_Terreno,GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
					THEN 1
					ELSE 0							
				END,
			Validacion_2 = CASE WHEN DATEADD(M,PAR.Meses_Seguimiento_Terreno,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_3 = 0,
			Validacion_4 = 0,
			Validacion_5 = 0,
			Validacion_6 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
			AND TM.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 1
			AND CTB.Cod_Clase_Tipo_Bien = (2)

	UNION
		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN DATEADD(M,PAR.Meses_Vencimiento_Avaluo_SUGEF_Edificacion,GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
					THEN 1
					ELSE 0							
				END,
			Validacion_2 = CASE WHEN DATEADD(M,PAR.Meses_Seguimiento_Edificacion,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_3 = 0,
			Validacion_4 = 0,
			Validacion_5 = 0,
			Validacion_6 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
			AND TM.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2
			AND CTB.Cod_Clase_Tipo_Bien = (2)

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_TERRENO ON dbo.AUX_GAR_PRC_ACP_TERRENO
	(
		Id_Garantia_Operacion ASC
	)

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_TERRENO_1 ON dbo.AUX_GAR_PRC_ACP_TERRENO
	(
		Cod_Tipo_Bien ASC,
		Cod_Clase_Tipo_Bien ASC
	)

	IF OBJECT_ID('[dbo].[AUX_GAR_PRC_ACP_TERRENO_R]') is not null
		DROP TABLE [dbo].AUX_GAR_PRC_ACP_TERRENO_R

	CREATE TABLE [dbo].AUX_GAR_PRC_ACP_TERRENO_R(
		[Id_Garantia_Operacion] [int] NOT NULL,
		[Porcentaje_Aceptacion_Terreno_SUGEF] [decimal](5, 2) NULL
	) ON [PRIMARY]
	

	INSERT INTO dbo.AUX_GAR_PRC_ACP_TERRENO_R
		(
		Id_Garantia_Operacion,
		Porcentaje_Aceptacion_Terreno_SUGEF
		)
	SELECT 
		Id_Garantia_Operacion,
		MIN(Porcentaje_Aceptacion_Terreno_SUGEF)  Porcentaje_Aceptacion_Terreno_SUGEF
	FROM 
	(
	--Se valida el tipo de bien 1
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0 AND Validacion_4 = 0 THEN 0 END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien = 1
	AND Cod_Clase_Tipo_Bien IN (1,3)
	--UNION
	--SELECT 
	--	Id_Garantia_Operacion,
	--	CASE WHEN Validacion_2 = 0 THEN 0 END Porcentaje_Aceptacion_Terreno_SUGEF
	--FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	--UNION
	--SELECT 
	--	Id_Garantia_Operacion,
	--	CASE WHEN Validacion_3 = 0 THEN 0 END Porcentaje_Aceptacion_Terreno_SUGEF
	--FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	--UNION
	--SELECT 
	--	Id_Garantia_Operacion,
	--	CASE WHEN Validacion_4 = 0 THEN 0 END Porcentaje_Aceptacion_Terreno_SUGEF
	--FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien = 1
	AND Cod_Clase_Tipo_Bien IN (1,3)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_6 = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien = 1
	AND Cod_Clase_Tipo_Bien IN (1,3)

	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_1 = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien = 1
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_2 = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien = 1
	AND Cod_Clase_Tipo_Bien = 2

	UNION 

	--Se valida el tipo de bien 2
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0 AND Validacion_4 = 0 THEN 0 END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)
	UNION
	SELECT 
		ACT.Id_Garantia_Operacion,
		CASE WHEN Validacion_6 = 0 THEN 
			CASE	WHEN GAROPER.Ind_Deudor_Habita = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2)
					WHEN GAROPER.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('A1','A2','B1','B2','C1') THEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF
					WHEN GAROPER.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('C2','D','E') THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2)
			END 
		END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Garantia_Operacion = ACT.Id_Garantia_Operacion
	INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
	WHERE 
		Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)

	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_1 = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Operacion,
		CASE WHEN Validacion_2 = 0 THEN 
			CASE	WHEN GAROPER.Ind_Deudor_Habita = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2)
					WHEN GAROPER.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('A1','A2','B1','B2','C1') THEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF
					WHEN GAROPER.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('C2','D','E') THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2)
			END 
		END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Garantia_Operacion = ACT.Id_Garantia_Operacion
	INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
	WHERE 
		Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien = 2

	) T 
	GROUP BY T.Id_Garantia_Operacion

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_TERRENO_R ON dbo.AUX_GAR_PRC_ACP_TERRENO_R
	(
		Id_Garantia_Operacion ASC
	)

	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_Terreno_SUGEF =	CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1 OR Validacion_4 = 1) 
																AND (Validacion_5 = 1 AND Validacion_6 = 1)
													 THEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF
												END 
	FROM		dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien IN (1,2)
	AND Cod_Clase_Tipo_Bien IN (1,3)

	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_Terreno_SUGEF =	CASE WHEN (Validacion_1 = 1 AND Validacion_2 = 1 ) 
													 THEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF
												END 
	FROM		dbo.AUX_GAR_PRC_ACP_TERRENO ACT
	WHERE 
		Cod_Tipo_Bien IN (1,2)
	AND Cod_Clase_Tipo_Bien = 2
		
	UPDATE		GAR
	SET			GAR.Porcentaje_Aceptacion_Terreno_SUGEF =	CASE WHEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF IS NOT NULL
																THEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF
																ELSE ACT_1.Porcentaje_Aceptacion_Terreno_SUGEF
															END
	FROM		
		dbo.GARANTIAS_OPERACIONES GAR
	INNER JOIN	AUX_GAR_PRC_ACP_TERRENO ACT 
		ON GAR.Id_Garantia_Operacion = ACT.Id_Garantia_Operacion
	INNER JOIN AUX_GAR_PRC_ACP_TERRENO_R ACT_1
		ON GAR.Id_Garantia_Operacion = ACT_1.Id_Garantia_Operacion

		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END




