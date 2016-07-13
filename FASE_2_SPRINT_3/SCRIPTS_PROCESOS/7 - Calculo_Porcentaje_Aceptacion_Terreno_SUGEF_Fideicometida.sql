USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Porcentaje_Aceptacion_Terreno_SUGEF_Fideicometida', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Porcentaje_Aceptacion_Terreno_SUGEF_Fideicometida;
GO


CREATE PROCEDURE [dbo].[Calculo_Porcentaje_Aceptacion_Terreno_SUGEF_Fideicometida]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Porcentaje_Aceptacion_Terreno_SUGEF_Fideicometida</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que se encarga de calcular y actualizar el porcentaje de aceptación del terreno que se envía a SUGEF de las garantías de reales relacionadas a fideicomisos</Descripción>
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

	IF OBJECT_ID('[dbo].[AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA]') is not null
		DROP TABLE [dbo].[AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA]


	CREATE TABLE [dbo].AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA(
		[Id_Garantia_Fideicomiso] [int] NOT NULL,
		[Cod_Tipo_Bien] [int] NOT NULL,
		[Cod_Clase_Tipo_Bien] [int] NOT NULL,
		[Validacion_1] [int] NOT NULL,
		[Validacion_2] [int] NOT NULL,
		[Validacion_3] [int] NOT NULL,
		[Validacion_4] [int] NOT NULL,
		[Validacion_5] [int] NOT NULL,
		[Porcentaje_Aceptacion_Terreno_SUGEF] [decimal](5, 2) NULL
	) ON [PRIMARY]
	
	INSERT INTO dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA
			   (Id_Garantia_Fideicomiso,
			    Cod_Tipo_Bien,
				Cod_Clase_Tipo_Bien,
				Validacion_1,
				Validacion_2,
				Validacion_3,
				Validacion_4,
				Validacion_5,
				Porcentaje_Aceptacion_Terreno_SUGEF
				)
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
			Validacion_4 = CASE WHEN DATEADD(M, PAR.Meses_Vencimiento_Avaluo_SUGEF_Terreno, GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_5 = CASE WHEN DATEADD(M, PAR.Meses_Seguimiento_Terreno, GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
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
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien IN (1,2)
			


	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA ON dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA
	(
		Id_Garantia_Fideicomiso ASC
	)

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_TERRENO__FIDEICOMETIDA_1 ON dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA
	(
		Cod_Tipo_Bien ASC,
		Cod_Clase_Tipo_Bien ASC
	)

	IF OBJECT_ID('[dbo].[AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R]') is not null
		DROP TABLE [dbo].AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R

	CREATE TABLE [dbo].AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R(
		[Id_Garantia_Fideicomiso] [int] NOT NULL,
		[Porcentaje_Aceptacion_Terreno_SUGEF] [decimal](5, 2) NULL
	) ON [PRIMARY]
	

	INSERT INTO dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R
		(
		Id_Garantia_Fideicomiso,
		Porcentaje_Aceptacion_Terreno_SUGEF
		)
	SELECT 
		Id_Garantia_Fideicomiso,
		MIN(Porcentaje_Aceptacion_Terreno_SUGEF)  Porcentaje_Aceptacion_Terreno_SUGEF
	FROM 
	(SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0 AND Validacion_4 = 0 AND Validacion_5 = 0 THEN 0 END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien IN (1,2)
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0 THEN 0 END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien IN (1,2)
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_4 = 1 AND Validacion_5 = 1 THEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien IN (1,2)
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_4 = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien IN (1,2)
	UNION
	SELECT 
		Id_Garantia_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien IN (1,2)
	) T 
	GROUP BY T.Id_Garantia_Fideicomiso

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R ON dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R
	(
		Id_Garantia_Fideicomiso ASC
	)

	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_Terreno_SUGEF = CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) 
																AND (Validacion_4 = 1 AND Validacion_5 = 1)
														   THEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF
													  END 
	FROM	dbo.AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA ACT
	WHERE 
		Cod_Tipo_Bien IN (1,2)

			
	UPDATE		GAR
	SET			GAR.Porcentaje_Aceptacion_Terreno_SUGEF =	CASE WHEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF IS NOT NULL
																 THEN ACT.Porcentaje_Aceptacion_Terreno_SUGEF
																 ELSE ACT_1.Porcentaje_Aceptacion_Terreno_SUGEF
															END
	FROM		
		dbo.GARANTIAS_FIDEICOMETIDAS GAR
	INNER JOIN	AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA ACT 
		ON GAR.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
	INNER JOIN AUX_GAR_PRC_ACP_TERRENO_FIDEICOMETIDA_R ACT_1
		ON GAR.Id_Garantia_Fideicomiso = ACT_1.Id_Garantia_Fideicomiso

		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END



