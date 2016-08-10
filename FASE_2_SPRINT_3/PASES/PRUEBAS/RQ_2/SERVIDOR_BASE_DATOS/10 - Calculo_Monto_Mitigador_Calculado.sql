USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Monto_Mitigador_Calculado', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Monto_Mitigador_Calculado;
GO

CREATE PROCEDURE [dbo].[Calculo_Monto_Mitigador_Calculado]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Monto_Mitigador_Calculado</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo automático del Monto Mitigador
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Alexander Cruz</Autor>
<Fecha>Octubre 2015</Fecha>
<Requerimiento>RQ_MANT_2015062310417367_00025 Monto Mitigador y Porcentaje Responsabilidad Legal</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli Marín</Autor>
		<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
		<Fecha>06/07/2016</Fecha>
		<Descripción>Se agrega la lógica para incluir las garantías con código 7 (Fideicomiso de Garantía) y 99 ()</Descripción>
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

	IF OBJECT_ID('[dbo].[AUX_GAR_MONTO_MITIGADOR]') is not null
		DROP TABLE [dbo].[AUX_GAR_MONTO_MITIGADOR]


	CREATE TABLE [dbo].AUX_GAR_MONTO_MITIGADOR(
		[Id_Garantia_Operacion] [int] NOT NULL,
		[Monto_Mitigador_Calculado] [decimal](20, 2) NULL
	) ON [PRIMARY]
	WITH(DATA_COMPRESSION = PAGE)

	DECLARE @VALOR DECIMAL(6,2)
	SELECT 
		top 1 @VALOR = Valor 
	FROM 
		dbo.TIPOS_CAMBIOS TC
	ORDER BY 
		Fecha desc

	INSERT INTO dbo.AUX_GAR_MONTO_MITIGADOR
			   (Id_Garantia_Operacion,
				Monto_Mitigador_Calculado
				)
			--Garantias Fiduciaras
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = 0
			FROM 
				dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_FIDUCIARIAS GAF
				ON GAF.Id_Garantia_Fiduciaria = GAROPER.Id_Garantia_Fiduciaria
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			UNION
			--Garantias Reales
			--Tipo Bien 1 Clase Hipoteca Comun Hipoteca Abierta
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE 
											WHEN (((((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) 
											- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
											* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) IS NULL
											THEN NULL
											WHEN (((((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) 
											- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
											* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) < 0 
											THEN 0 
											ELSE 
												 (((((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) 
												- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
												* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100)
											END
			FROM 
				dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA1
				ON GRA1.Id_Grado_Gravamen = GRA.Id_Grado_Gravamen
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA2
				ON GRA2.Id_Grado_Gravamen = GAROPER.Id_Grado_Gravamen
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 1
			AND CTB.Cod_Clase_Tipo_Bien IN (1,3)
			GROUP BY 
				GAROPER.Id_Garantia_Operacion,
				GAR.Monto_Tasacion_Actualizada_Terreno,
				GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF,
				GAROPER.Porcentaje_Responsabilidad_SUGEF
			UNION
			--Tipo Bien 1 Clase Cedula Hipotecaria

			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE 
											WHEN ((((CASE WHEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) < GAR.Monto_Valor_Total_Cedula THEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) ELSE GAR.Monto_Valor_Total_Cedula END)
											- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
											* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) IS NULL
											THEN NULL
											WHEN ((((CASE WHEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) < GAR.Monto_Valor_Total_Cedula THEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) ELSE GAR.Monto_Valor_Total_Cedula END)
											- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
											* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) < 0 
											THEN 0 
											ELSE 
												((((CASE WHEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) < GAR.Monto_Valor_Total_Cedula THEN ((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) ELSE GAR.Monto_Valor_Total_Cedula END)
												- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
												* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100)
											END
			FROM 
				dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA1
				ON GRA1.Id_Grado_Gravamen = GRA.Id_Grado_Gravamen
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA2
				ON GRA2.Id_Grado_Gravamen = GAROPER.Id_Grado_Gravamen
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 1
			AND CTB.Cod_Clase_Tipo_Bien IN (2)
			GROUP BY 
				GAROPER.Id_Garantia_Operacion,
				GAR.Monto_Tasacion_Actualizada_Terreno,
				GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF,
				GAROPER.Porcentaje_Responsabilidad_SUGEF,
				GAR.Monto_Valor_Total_Cedula
			UNION
			--Tipo Bien 2 Clase Hipoteca Comun Hipoteca Abierta
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE 
											WHEN ((((((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100))
											- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
											* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) IS NULL
											THEN NULL
											WHEN ((((((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100))
											- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
											* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) < 0 
											THEN 0 
											ELSE 
												((((((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100))
												- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
												* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100)
											END
			FROM 
				dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA1
				ON GRA1.Id_Grado_Gravamen = GRA.Id_Grado_Gravamen
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA2
				ON GRA2.Id_Grado_Gravamen = GAROPER.Id_Grado_Gravamen
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2
			AND CTB.Cod_Clase_Tipo_Bien IN (1,3)
			GROUP BY 
				GAROPER.Id_Garantia_Operacion,
				GAR.Monto_Tasacion_Actualizada_Terreno,
				GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF,
				GAROPER.Porcentaje_Responsabilidad_SUGEF,
				GAR.Monto_Tasacion_Actualizada_No_Terreno,
				GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF
			UNION
			--Tipo Bien 2 Clase Cedula Hipotecaria
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE 
											WHEN ((((CASE WHEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) < GAR.Monto_Valor_Total_Cedula THEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) ELSE GAR.Monto_Valor_Total_Cedula END)
												- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
												* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) IS NULL
											THEN NULL
											WHEN ((((CASE WHEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) < GAR.Monto_Valor_Total_Cedula THEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) ELSE GAR.Monto_Valor_Total_Cedula END)
												- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
												* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) < 0 
											THEN 0 
											ELSE 
												((((CASE WHEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) < GAR.Monto_Valor_Total_Cedula THEN (((GAR.Monto_Tasacion_Actualizada_Terreno * GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF) / 100) + ((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)) ELSE GAR.Monto_Valor_Total_Cedula END)
												- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
												* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100)
											END
			FROM 
				dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA1
				ON GRA1.Id_Grado_Gravamen = GRA.Id_Grado_Gravamen
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA2
				ON GRA2.Id_Grado_Gravamen = GAROPER.Id_Grado_Gravamen
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2
			AND CTB.Cod_Clase_Tipo_Bien IN (2)
			GROUP BY 
				GAROPER.Id_Garantia_Operacion,
				GAR.Monto_Tasacion_Actualizada_Terreno,
				GAROPER.Porcentaje_Aceptacion_Terreno_SUGEF,
				GAROPER.Porcentaje_Responsabilidad_SUGEF,
				GAR.Monto_Tasacion_Actualizada_No_Terreno,
				GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF,
				GAR.Monto_Valor_Total_Cedula
			UNION
			--Tipo Bien 3 Bono Prenda
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE WHEN TPA.Des_Tipo_Almacen = 'Fiscal' THEN 0
												 ELSE
													CASE 
													WHEN (((((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
													* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) IS NULL
													THEN NULL
													WHEN (((((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
													* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) < 0 
													THEN 0 
													ELSE 
														(((((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
														- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
														* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100)
													END
											END
			FROM 
				dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
			LEFT JOIN dbo.TIPOS_ALMACENES TPA
				ON TPA.Id_Tipo_Almacen = GAR.Id_Tipo_Almacen
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA1
				ON GRA1.Id_Grado_Gravamen = GRA.Id_Grado_Gravamen
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA2
				ON GRA2.Id_Grado_Gravamen = GAROPER.Id_Grado_Gravamen
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 3
			AND CTB.Cod_Clase_Tipo_Bien IN (3)
			GROUP BY 
				GAROPER.Id_Garantia_Operacion,
				GAR.Monto_Tasacion_Actualizada_No_Terreno,
				GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF,
				GAROPER.Porcentaje_Responsabilidad_SUGEF,
				TPA.Des_Tipo_Almacen
			UNION
			--Tipo Bien 3 Prenda Comun
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE WHEN TPA.Des_Tipo_Almacen = 'Fiscal' THEN 0
												 ELSE
													CASE 
													WHEN (((((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
													* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) IS NULL
													THEN NULL									
													WHEN (((((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
													* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) < 0 
													THEN 0 
													ELSE 
														(((((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
														- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
														* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100)
													END
											END
			FROM 
				dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
			LEFT JOIN dbo.TIPOS_ALMACENES TPA
				ON TPA.Id_Tipo_Almacen = GAR.Id_Tipo_Almacen
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
				ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA1
				ON GRA1.Id_Grado_Gravamen = GRA.Id_Grado_Gravamen
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA2
				ON GRA2.Id_Grado_Gravamen = GAROPER.Id_Grado_Gravamen
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 3
			AND CTB.Cod_Clase_Tipo_Bien IN (2)
			GROUP BY 
				GAROPER.Id_Garantia_Operacion,
				GAR.Monto_Tasacion_Actualizada_No_Terreno,
				GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF,
				GAROPER.Porcentaje_Responsabilidad_SUGEF,
				TPA.Des_Tipo_Almacen
			UNION
			--Tipo Bien 4 al 14
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE WHEN TPA.Des_Tipo_Almacen = 'Fiscal' THEN 0
												 ELSE
													CASE 
													WHEN (((((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
													* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) IS NULL
													THEN NULL									
													WHEN (((((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
													- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
													* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100) < 0 
													THEN 0 
													ELSE 
														(((((GAR.Monto_Tasacion_Actualizada_No_Terreno * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100)
														- SUM(CASE WHEN CAST(GRA1.Cod_Grado_Gravamen AS INT) < CAST(GRA2.Cod_Grado_Gravamen AS INT) THEN GRA.Saldo_Grado_Gravamen_Colonizado ELSE 0 END))
														* GAROPER.Porcentaje_Responsabilidad_SUGEF)/100)
													END
											END
			FROM 
				dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_REALES GAR
				ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
			LEFT JOIN dbo.TIPOS_ALMACENES TPA
				ON TPA.Id_Tipo_Almacen = GAR.Id_Tipo_Almacen
			INNER JOIN dbo.TIPOS_BIENES TPB
				ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			LEFT JOIN dbo.GRAVAMENES GRA
				ON GRA.Id_Garantia_Real = GAR.Id_Garantia_Real
				AND GRA.Ind_Estado_Registro = 1
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA1
				ON GRA1.Id_Grado_Gravamen = GRA.Id_Grado_Gravamen
			LEFT JOIN dbo.GRADOS_GRAVAMENES GRA2
				ON GRA2.Id_Grado_Gravamen = GAROPER.Id_Grado_Gravamen
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien IN (4,5,6,7,8,9,10,11,12,13,14)
			GROUP BY 
				GAROPER.Id_Garantia_Operacion,
				GAR.Monto_Tasacion_Actualizada_No_Terreno,
				GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF,
				GAROPER.Porcentaje_Responsabilidad_SUGEF,
				TPA.Des_Tipo_Almacen
			UNION
			--Garantias Valor 
			--Tipo Mitigador 10
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE 
												 WHEN (((((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100) * GAROPER.Porcentaje_Responsabilidad_SUGEF) / 100) IS NULL
												 THEN NULL
												 WHEN (((((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100) * GAROPER.Porcentaje_Responsabilidad_SUGEF) / 100) < 0
												 THEN 0
												 ELSE (((((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100) * GAROPER.Porcentaje_Responsabilidad_SUGEF) / 100)
											END
			FROM	dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_VALORES GAV
				ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
			LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TMR
				ON TMR.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
			LEFT JOIN dbo.TIPOS_MONEDAS TM
				ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Mercado
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TMR.Cod_Tipo_Mitigador_Riesgo = 10
			UNION
			--Tipo Mitigador 12
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE 
												 WHEN ((((CASE WHEN GAV.Monto_Valor_Mercado < GAV.Monto_Valor_Facial THEN (CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) ELSE (CASE TM1.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Facial) END * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100) * GAROPER.Porcentaje_Responsabilidad_SUGEF) / 100) IS NULL
												 THEN NULL
												 WHEN ((((CASE WHEN GAV.Monto_Valor_Mercado < GAV.Monto_Valor_Facial THEN (CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) ELSE (CASE TM1.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Facial) END * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100) * GAROPER.Porcentaje_Responsabilidad_SUGEF) / 100) < 0
												 THEN 0
												 ELSE ((((CASE WHEN GAV.Monto_Valor_Mercado < GAV.Monto_Valor_Facial THEN (CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) ELSE (CASE TM1.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Facial) END * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100) * GAROPER.Porcentaje_Responsabilidad_SUGEF) / 100)
											END
			FROM	dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_VALORES GAV
				ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
			LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TMR
				ON TMR.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
			LEFT JOIN dbo.TIPOS_MONEDAS TM
				ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Mercado
			LEFT JOIN dbo.TIPOS_MONEDAS TM1
				ON TM1.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Facial
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TMR.Cod_Tipo_Mitigador_Riesgo = 12
			UNION
			--Tipo Mitigador 0,11,13,14,15
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE 
												 WHEN (((((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100) * GAROPER.Porcentaje_Responsabilidad_SUGEF) / 100) IS NULL
												 THEN NULL
												 WHEN (((((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100) * GAROPER.Porcentaje_Responsabilidad_SUGEF) / 100) < 0
												 THEN 0
												 ELSE (((((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GAROPER.Porcentaje_Aceptacion_No_Terreno_SUGEF) / 100) * GAROPER.Porcentaje_Responsabilidad_SUGEF) / 100)
											END
			FROM	dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.GARANTIAS_VALORES GAV
				ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
			LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TMR
				ON TMR.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
			LEFT JOIN dbo.TIPOS_MONEDAS TM
				ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Mercado
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
			AND TMR.Cod_Tipo_Mitigador_Riesgo IN (0,11,13,14,15)

			UNION
			--Garantias Fideicomiso 
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = SUM(GARFID.Monto_Mitigador)
			FROM	dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.FIDEICOMISOS FID
				ON FID.Id_Fideicomiso = GAROPER.Id_Fideicomiso
				AND FID.Ind_Estado_Registro = 1
			INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
				ON GARFID.Id_Fideicomiso = FID.Id_Fideicomiso
				AND GARFID.Ind_Estado_Registro = 1
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
				AND GAROPER.Id_Tipo_Garantia = 8
				AND GAROPER.Id_Fideicomiso IS NOT NULL
			GROUP BY 
				GAROPER.Id_Garantia_Operacion,
				GARFID.Id_Fideicomiso
			UNION
			--Garantias Avales 
			SELECT 
				GAROPER.Id_Garantia_Operacion,
				Monto_Mitigador_Calculado = CASE
												WHEN OPER.Id_Tipo_Operacion = 1 THEN ((ISNULL(OPER.Saldo_Colonizado, 0) * (ISNULL(GAROPER.Porcentaje_Aceptacion_BCR, 0))) / 100)
												WHEN OPER.Id_Tipo_Operacion = 2 THEN ((ISNULL(OPER.Saldo_Original_Colonizado, 0) * (ISNULL(GAROPER.Porcentaje_Aceptacion_BCR, 0))) / 100)
												ELSE 0
											END
			FROM	dbo.GARANTIAS_OPERACIONES GAROPER
			INNER JOIN dbo.OPERACIONES OPER
				ON OPER.Id_Operacion = GAROPER.Id_Operacion
				AND OPER.Ind_Estado_Registro = 1
			WHERE 
				GAROPER.Ind_Estado_Registro = 1
				AND GAROPER.Id_Tipo_Garantia = 12
				AND GAROPER.Id_Garantia_Aval IS NOT NULL
			
			 

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_MONTO_MITIGADOR ON dbo.AUX_GAR_MONTO_MITIGADOR
	(
		Id_Garantia_Operacion ASC
	)WITH(DATA_COMPRESSION = PAGE)
		
	UPDATE		GAR
	SET			GAR.Monto_Mitigador_Calculado =	ACT.Monto_Mitigador_Calculado,
				GAR.Monto_Mitigador = CASE 
											WHEN Id_Tipo_Garantia = 8 THEN (ACT.Monto_Mitigador_Calculado * GAR.Porcentaje_Responsabilidad_SUGEF)
											ELSE GAR.Monto_Mitigador
									  END
	FROM		
		dbo.GARANTIAS_OPERACIONES GAR
	INNER JOIN	AUX_GAR_MONTO_MITIGADOR ACT 
		ON GAR.Id_Garantia_Operacion = ACT.Id_Garantia_Operacion

		SELECT 0 AS Error, '' AS Mensaje

		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END


