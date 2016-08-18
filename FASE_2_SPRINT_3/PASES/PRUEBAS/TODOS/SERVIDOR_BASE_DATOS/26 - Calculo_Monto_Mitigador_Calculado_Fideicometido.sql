USE [USSIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Monto_Mitigador_Calculado_Fideicometido', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Monto_Mitigador_Calculado_Fideicometido;
GO


CREATE PROCEDURE [dbo].[Calculo_Monto_Mitigador_Calculado_Fideicometido]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Monto_Mitigador_Calculado_Fideicometido</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo automático del Monto Mitigador de las Garantías Fideicometidas
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Marín</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>06/07/2016</Fecha>
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

	IF OBJECT_ID('[dbo].[AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS]') is not null
		DROP TABLE [dbo].[AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS]


	CREATE TABLE [dbo].AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS(
		[Id_Garantia_Fideicomiso] [int] NOT NULL,
		[Monto_Mitigador_Calculado] [decimal](20, 2) NULL
	) ON [PRIMARY]
	

	DECLARE @VALOR DECIMAL(6,2)
	SELECT 
		top 1 @VALOR = Valor 
	FROM 
		dbo.TIPOS_CAMBIOS TC
	ORDER BY 
		Fecha desc

	INSERT INTO dbo.AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS
			   (Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado
				)
			--Garantias Reales
			--Tipo Bien 1 Clase Hipoteca Común 
			SELECT 
				GARFID.Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado = CASE 
											WHEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) 
											- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) IS NULL
											THEN NULL
											WHEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) 
											- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) < 0 
											THEN 0 
											ELSE 
												 (((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) 
												- SUM(GRA.Saldo_Grado_Gravamen_Colonizado))
											END
			FROM 
				dbo.GARANTIAS_FIDEICOMETIDAS GARFID
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GARFID.Id_Garantia_Real
				AND GAR.Ind_Estado_Registro = 1
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND TPB.Ind_Estado_Registro = 1
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
				AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND CTB.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			WHERE 
				GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 1
			AND CTB.Cod_Clase_Tipo_Bien = 1
			GROUP BY 
				GARFID.Id_Garantia_Fideicomiso,
				GAR.Monto_Tasacion_Actualizada_Terreno,
				GARFID.Porcentaje_Aceptacion_Terreno_SUGEF
			UNION
			--Tipo Bien 1 Clase Cédula Hipotecaria

			SELECT 
				GARFID.Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado = CASE 
											WHEN ((CASE WHEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) < GAR.Monto_Valor_Total_Cedula THEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) ELSE GAR.Monto_Valor_Total_Cedula END)
											- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) IS NULL
											THEN NULL
											WHEN ((CASE WHEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) < GAR.Monto_Valor_Total_Cedula THEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) ELSE GAR.Monto_Valor_Total_Cedula END)
											- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) < 0 
											THEN 0 
											ELSE 
												((CASE WHEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) < GAR.Monto_Valor_Total_Cedula THEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) ELSE GAR.Monto_Valor_Total_Cedula END)
												- SUM(GRA.Saldo_Grado_Gravamen_Colonizado))
											END
			FROM 
				dbo.GARANTIAS_FIDEICOMETIDAS GARFID
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GARFID.Id_Garantia_Real
				AND GAR.Ind_Estado_Registro = 1
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND TPB.Ind_Estado_Registro = 1
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
				AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND CTB.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			WHERE 
				GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 1
			AND CTB.Cod_Clase_Tipo_Bien = 2
			GROUP BY 
				GARFID.Id_Garantia_Fideicomiso,
				GAR.Monto_Tasacion_Actualizada_Terreno,
				GARFID.Porcentaje_Aceptacion_Terreno_SUGEF,
				GAR.Monto_Valor_Total_Cedula
			UNION
			--Tipo Bien 2 Clase Hipoteca Común 
			SELECT 
				GARFID.Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado = CASE 
											WHEN ((((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100))
											- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) IS NULL
											THEN NULL
											WHEN ((((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100))
											- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) < 0 
											THEN 0 
											ELSE 
												((((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100))
												- SUM(GRA.Saldo_Grado_Gravamen_Colonizado))
											END
			FROM 
				dbo.GARANTIAS_FIDEICOMETIDAS GARFID
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GARFID.Id_Garantia_Real
				AND GAR.Ind_Estado_Registro = 1
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND TPB.Ind_Estado_Registro = 1
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
				AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND CTB.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			WHERE 
				GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2
			AND CTB.Cod_Clase_Tipo_Bien = 1
			GROUP BY 
				GARFID.Id_Garantia_Fideicomiso,
				GAR.Monto_Tasacion_Actualizada_Terreno,
				GARFID.Porcentaje_Aceptacion_Terreno_SUGEF,
				GAR.Monto_Tasacion_Actualizada_No_Terreno,
				GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF
			UNION
			--Tipo Bien 2 Clase Cédula Hipotecaria
			SELECT 
				GARFID.Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado = CASE 
											WHEN ((CASE WHEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) < GAR.Monto_Valor_Total_Cedula THEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) ELSE GAR.Monto_Valor_Total_Cedula END)
												- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) IS NULL
											THEN NULL
											WHEN ((CASE WHEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) < GAR.Monto_Valor_Total_Cedula THEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) ELSE GAR.Monto_Valor_Total_Cedula END)
												- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) < 0 
											THEN 0 
											ELSE 
												((CASE WHEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) < GAR.Monto_Valor_Total_Cedula THEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GARFID.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) ELSE GAR.Monto_Valor_Total_Cedula END)
												- SUM(GRA.Saldo_Grado_Gravamen_Colonizado))
											END
			FROM 
				dbo.GARANTIAS_FIDEICOMETIDAS GARFID
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GARFID.Id_Garantia_Real
				AND GAR.Ind_Estado_Registro = 1
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND TPB.Ind_Estado_Registro = 1
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
				AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND CTB.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			WHERE 
				GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2
			AND CTB.Cod_Clase_Tipo_Bien = 2
			GROUP BY 
				GARFID.Id_Garantia_Fideicomiso,
				GAR.Monto_Tasacion_Actualizada_Terreno,
				GARFID.Porcentaje_Aceptacion_Terreno_SUGEF,
				GAR.Monto_Tasacion_Actualizada_No_Terreno,
				GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF,
				GAR.Monto_Valor_Total_Cedula
			UNION
			--Tipo Bien 3 Prenda Común
			SELECT 
				GARFID.Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado = CASE 
												WHEN (((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) IS NULL
												THEN NULL									
												WHEN (((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) < 0 
												THEN 0 
												ELSE 
													(((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(GRA.Saldo_Grado_Gravamen_Colonizado))
											END											
			FROM 
				dbo.GARANTIAS_FIDEICOMETIDAS GARFID
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GARFID.Id_Garantia_Real
				AND GAR.Ind_Estado_Registro = 1
			LEFT JOIN dbo.TIPOS_ALMACENES TPA
				ON TPA.Id_Tipo_Almacen = GAR.Id_Tipo_Almacen
				AND TPA.Ind_Estado_Registro = 1
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND TPB.Ind_Estado_Registro = 1
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
				AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND CTB.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			WHERE 
				GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 3
			AND CTB.Cod_Clase_Tipo_Bien = 2
			GROUP BY 
				GARFID.Id_Garantia_Fideicomiso,
				GAR.Monto_Tasacion_Actualizada_No_Terreno,
				GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF,
				TPA.Des_Tipo_Almacen
			UNION
			--Tipo Bien 4 al 14
			SELECT 
				GARFID.Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado = CASE 
												WHEN (((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) IS NULL
												THEN NULL									
												WHEN (((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(GRA.Saldo_Grado_Gravamen_Colonizado)) < 0 
												THEN 0 
												ELSE 
													(((GAR.Monto_Tasacion_Actualizada_No_Terreno * GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(GRA.Saldo_Grado_Gravamen_Colonizado))
											END											
			FROM 
				dbo.GARANTIAS_FIDEICOMETIDAS GARFID
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GARFID.Id_Garantia_Real
				AND GAR.Ind_Estado_Registro = 1
			LEFT JOIN dbo.TIPOS_ALMACENES TPA
				ON TPA.Id_Tipo_Almacen = GAR.Id_Tipo_Almacen
				AND TPA.Ind_Estado_Registro = 1
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND TPB.Ind_Estado_Registro = 1
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = ISNULL(GAR.Id_Clase_Tipo_Bien, CTB.Id_Clase_Tipo_Bien)
				AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
				AND CTB.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			WHERE 
				GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien IN (4,5,6,7,8,9,10,11,12,13,14)
			GROUP BY 
				GARFID.Id_Garantia_Fideicomiso,
				GAR.Monto_Tasacion_Actualizada_No_Terreno,
				GARFID.Porcentaje_Aceptacion_No_Terreno_SUGEF,
				TPA.Des_Tipo_Almacen
			UNION
			--Garantias Valor 
			--Tipo Mitigador 10
			SELECT 
				GARFID.Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado = CASE 
												 WHEN (((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)  IS NULL
												 THEN NULL
												 WHEN (((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)  < 0
												 THEN 0
												 ELSE (((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)
											END
			FROM	dbo.GARANTIAS_FIDEICOMETIDAS GARFID
			INNER JOIN dbo.GARANTIAS_VALORES GAV
				ON GAV.Id_Garantia_Valor = GARFID.Id_Garantia_Valor
				AND GAV.Ind_Estado_Registro = 1
			LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TMR
				ON TMR.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
				AND TMR.Ind_Estado_Registro = 1
			LEFT JOIN dbo.TIPOS_MONEDAS TM
				ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Mercado
			WHERE 
				GARFID.Ind_Estado_Registro = 1
			AND TMR.Cod_Tipo_Mitigador_Riesgo = 10
			UNION
			--Tipo Mitigador 12
			SELECT 
				GARFID.Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado = CASE 
												 WHEN ((CASE WHEN GAV.Monto_Valor_Mercado < GAV.Monto_Valor_Facial THEN (CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) ELSE (CASE TM1.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Facial) END * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)  IS NULL
												 THEN NULL
												 WHEN ((CASE WHEN GAV.Monto_Valor_Mercado < GAV.Monto_Valor_Facial THEN (CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) ELSE (CASE TM1.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Facial) END * GARFID.Porcentaje_Aceptacion_SUGEF) / 100) < 0
												 THEN 0
												 ELSE ((CASE WHEN GAV.Monto_Valor_Mercado < GAV.Monto_Valor_Facial THEN (CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) ELSE (CASE TM1.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Facial) END * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)
											END
			FROM	dbo.GARANTIAS_FIDEICOMETIDAS GARFID
			INNER JOIN dbo.GARANTIAS_VALORES GAV
				ON GAV.Id_Garantia_Valor = GARFID.Id_Garantia_Valor
				AND GAV.Ind_Estado_Registro = 1
			LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TMR
				ON TMR.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
				AND TMR.Ind_Estado_Registro = 1
			LEFT JOIN dbo.TIPOS_MONEDAS TM
				ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Mercado
				AND TM.Ind_Estado_Registro = 1
			LEFT JOIN dbo.TIPOS_MONEDAS TM1
				ON TM1.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Facial
				AND TM1.Ind_Estado_Registro = 1
			WHERE 
				GARFID.Ind_Estado_Registro = 1
			AND TMR.Cod_Tipo_Mitigador_Riesgo = 12
			UNION
			--Tipo Mitigador 0,11,13,14,15
			SELECT 
				GARFID.Id_Garantia_Fideicomiso,
				Monto_Mitigador_Calculado = CASE 
												 WHEN (((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)  IS NULL
												 THEN NULL
												 WHEN (((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)  < 0
												 THEN 0
												 ELSE (((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GARFID.Porcentaje_Aceptacion_SUGEF) / 100) 
											END
			FROM	dbo.GARANTIAS_FIDEICOMETIDAS GARFID
			INNER JOIN dbo.GARANTIAS_VALORES GAV
				ON GAV.Id_Garantia_Valor = GARFID.Id_Garantia_Valor
				AND GAV.Ind_Estado_Registro = 1
			LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TMR
				ON TMR.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
				AND TMR.Ind_Estado_Registro = 1
			LEFT JOIN dbo.TIPOS_MONEDAS TM
				ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Mercado
				AND TM.Ind_Estado_Registro = 1
			WHERE 
				GARFID.Ind_Estado_Registro = 1
			AND TMR.Cod_Tipo_Mitigador_Riesgo IN (0,11,13,14,15)


	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS ON dbo.AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS
	(
		Id_Garantia_Fideicomiso ASC
	)
		
	UPDATE		GAR
	SET			GAR.Monto_Mitigador =	ACT.Monto_Mitigador_Calculado
	FROM		
		dbo.GARANTIAS_FIDEICOMETIDAS GAR
	INNER JOIN	AUX_GAR_MONTO_MITIGADOR_FIDEICOMISOS ACT 
		ON GAR.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso

		SELECT 0 AS Error, '' AS Mensaje

		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END



