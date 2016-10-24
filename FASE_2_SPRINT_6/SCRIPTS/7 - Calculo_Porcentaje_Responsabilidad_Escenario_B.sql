USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Porcentaje_Responsabilidad_Escenario_B', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Porcentaje_Responsabilidad_Escenario_B;
GO


CREATE PROCEDURE [dbo].[Calculo_Porcentaje_Responsabilidad_Escenario_B]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Porcentaje_Responsabilidad_Escenario_B</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo del porcentaje de responsabilidad para las garantias reales 
	y valores. Una garantía tiene relación con N cantidad de operaciones, las cuales solo se asocian a dicha garantía.
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Alexander Cruz</Autor>
<Fecha>Octubre 2015</Fecha>
<Requerimiento>RQ_MANT_2015042110384902_00055 Pcj Responsabilidad, Pcj Aceptación BCR y Monto Gravamen 1_1</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Mauricio Castro</Autor>
		<Requerimiento>RQ_MANT_2016022310547701_Backlog_870 SIGANEM- Porcentaje de Responsabilidad SUGEF con Fideicomisos y Avales</Requerimiento>
		<Fecha>Julio 2016</Fecha>
		<Descripción>Se incluyen dentro del cálculo las garantías de tipo Fideicomiso y Aval</Descripción>
	</Cambio>
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

		--Escenario B

		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_B') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_B

		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_B
			(Id_Garantia INT,
			Id_Tipo_Garantia INT)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_B (Id_Garantia, Id_Tipo_Garantia)
		SELECT 
			GAROPER.Id_Garantia_Valor,
			GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.GARANTIAS_VALORES GAV
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
		WHERE 
			GAV.Ind_Estado_Registro = 1 
		AND GAROPER.Ind_Estado_Registro = 1
		GROUP BY 
			GAROPER.Id_Garantia_Valor,
			GAROPER.Id_Tipo_Garantia
		HAVING COUNT(1) > 1

		UNION

		SELECT 
			GAROPER.Id_Garantia_Real,
			GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.GARANTIAS_REALES GAR
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
		WHERE 
			GAR.Ind_Estado_Registro = 1 
		AND GAROPER.Ind_Estado_Registro = 1
		GROUP BY 
			GAROPER.Id_Garantia_Real,
			GAROPER.Id_Tipo_Garantia
		HAVING COUNT(1) > 1

		UNION

		SELECT 
			FID.Id_Fideicomiso,
			GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.FIDEICOMISOS FID
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON FID.Id_Fideicomiso = GAROPER.Id_Fideicomiso
		WHERE 
			FID.Ind_Estado_Registro = 1 
		AND GAROPER.Ind_Estado_Registro = 1
		GROUP BY 
			FID.Id_Fideicomiso,
			GAROPER.Id_Tipo_Garantia
		HAVING COUNT(1) > 1

		UNION

		SELECT 
			GARAV.Id_Garantia_Aval, 
			GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.GARANTIAS_AVALES GARAV
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON GARAV.Id_Garantia_Aval = GAROPER.Id_Garantia_Aval
		WHERE 
			GARAV.Ind_Estado_Registro = 1 
		AND GAROPER.Ind_Estado_Registro = 1
		GROUP BY 
			GARAV.Id_Garantia_Aval,
			GAROPER.Id_Tipo_Garantia
		HAVING COUNT(1) > 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_B_01 ON dbo.AUX_PCJ_GARANTIAS_B
			(Id_Garantia ASC,
			Id_Tipo_Garantia ASC) 

		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_B') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_B

		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_B
		(Id_Operacion INT)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_B (Id_Operacion)
		SELECT 
			GAROPER.Id_Operacion
		FROM 
			dbo.OPERACIONES OPER
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON OPER.Id_Operacion = GAROPER.Id_Operacion
		WHERE 
			OPER.Ind_Estado_Registro = 1 
		AND GAROPER.Ind_Estado_Registro = 1
		GROUP BY 
			GAROPER.Id_Operacion
		--HAVING COUNT(1) > 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_B_01 ON dbo.AUX_PCJ_OPERACIONES_B
		(Id_Operacion ASC) 

		--2
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_B_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_B_1

		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_B_1
		(Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Saldo_Total_Colonizado DECIMAL(30,10)
		)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_B_1 (Id_Garantia, Id_Tipo_Garantia, Saldo_Total_Colonizado)
		SELECT 
			AUX_V.Id_Garantia,
			GAROPER.Id_Tipo_Garantia,
			SUM(CASE TP.Cod_Tipo_Operacion	WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
											WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
											ELSE 0
				END) AS Saldo_Total_Colonizado
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.OPERACIONES OPER
			ON OPER.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_B  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_B AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1
		GROUP BY AUX_V.Id_Garantia,
			GAROPER.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_B_1_01 ON dbo.AUX_PCJ_GARANTIAS_B_1
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC)


		--3 4 5 6
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_B_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_B_1

		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_B_1
		(Id_Operacion INT,
		Saldo_Colonizado DECIMAL(30,10)
		)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_B_1 (Id_Operacion, Saldo_Colonizado)
		SELECT DISTINCT
			GAROPER.Id_Operacion,
			CASE TP.Cod_Tipo_Operacion WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
									   WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
									   ELSE 0
			END AS Saldo_Colonizado
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.OPERACIONES OPER
			ON OPER.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_B  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_B AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1
		--GROUP BY GAROPER.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_B_1_01 ON dbo.AUX_PCJ_OPERACIONES_B_1
		(Id_Operacion ASC)


		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_B_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_B_2


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_B_2
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Saldo_Colonizado DECIMAL(30,10),
		Porcentaje DECIMAL(30,10)		
		)


		INSERT INTO dbo.AUX_PCJ_OPERACIONES_B_2 (Id_Operacion,Id_Garantia, Id_Tipo_Garantia, Saldo_Colonizado, Porcentaje)
		SELECT 
			AUX_O.Id_Operacion,
			AUX_V.Id_Garantia,
			AUX_V.Id_Tipo_Garantia,
			AUX_O.Saldo_Colonizado,
			CASE WHEN AUX_V.Saldo_Total_Colonizado <> 0 THEN 
					CASE WHEN ((AUX_O.Saldo_Colonizado / AUX_V.Saldo_Total_Colonizado) * 100) > 100 
					THEN 100 
					WHEN ((AUX_O.Saldo_Colonizado / AUX_V.Saldo_Total_Colonizado) * 100) < 0
					THEN 0
					ELSE ((AUX_O.Saldo_Colonizado / AUX_V.Saldo_Total_Colonizado) * 100)
				END
			ELSE 0
			END AS Porcentaje
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_B_1 AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_B_1 AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia	
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_B_2_01 ON dbo.AUX_PCJ_OPERACIONES_B_2
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)

		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF = ROUND(AUX_O.Porcentaje, 2)
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_B_2 AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
			AND AUX_O.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND AUX_O.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		--Fin Escenario B
		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END
GO

