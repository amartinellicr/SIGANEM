USE [SIGANEM]
GO

/****** Object:  StoredProcedure [dbo].[Calculo_Porcentaje_Responsabilidad_Escenario_C]    Script Date: 10/08/2016 11:36:50 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Calculo_Porcentaje_Responsabilidad_Escenario_C]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Porcentaje_Responsabilidad_Escenario_C</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo del porcentaje de responsabilidad para las garantias reales 
	y valores. Una operación tiene relación con más de una garantía, y esa garantía solo tiene relación con dicha operación
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Alexander Cruz</Autor>
<Fecha>Octubre 2015</Fecha>
<Requerimiento>RQ_MANT_2015042110384902_00055 Pcj Responsabilidad, Pcj Aceptación BCR y Monto Gravamen 1_1</Requerimiento>
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

		--Escenario C

		--Garantias Valores y Reales

		DECLARE @TIPOCAMBIO DECIMAL(7,2)
		SELECT TOP 1 
			@TIPOCAMBIO = Valor
		FROM 
			dbo.TIPOS_CAMBIOS TPC
		ORDER BY 
			Fecha DESC

		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_C') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_C


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_C
		(Id_Garantia INT,
		Id_Tipo_Garantia INT)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_C (Id_Garantia, Id_Tipo_Garantia)
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
		HAVING COUNT(1) = 1

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
		HAVING COUNT(1) = 1


		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C_01 ON dbo.AUX_PCJ_GARANTIAS_C
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC) 
		--WITH(DATA_COMPRESSION = PAGE)

		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C
		(Id_Operacion INT)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C (Id_Operacion)
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
		HAVING COUNT(1) > 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C_01 ON dbo.AUX_PCJ_OPERACIONES_C
		(Id_Operacion ASC) 
		--WITH(DATA_COMPRESSION = PAGE)
		
		--INSERT INTO dbo.AUX_PCJ_GARANTIAS_C (Id_Garantia, Id_Tipo_Garantia)
		--SELECT DISTINCT
		--	ISNULL(GAROPER.Id_Garantia_Real,GAROPER.Id_Garantia_Valor) AS Id_Garantia,
		--	GAROPER.Id_Tipo_Garantia
		--FROM 
		--	dbo.GARANTIAS_OPERACIONES GAROPER
		--INNER JOIN dbo.AUX_PCJ_OPERACIONES_C AUX
		--	ON AUX.Id_Operacion = GAROPER.Id_Operacion
		--	AND GAROPER.Ind_Estado_Registro = 1
		--	AND GAROPER.Id_Garantia_Fiduciaria IS NULL
		--LEFT JOIN dbo.AUX_PCJ_GARANTIAS_C AUX_2
		--	ON AUX_2.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Real,GAROPER.Id_Garantia_Valor)
		--	AND AUX_2.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		--WHERE 
		--	AUX_2.Id_Tipo_Garantia IS NULL

		--2 3
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_C_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_C_1


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_C_1
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Monto DECIMAL(22,2),
		Porcentaje DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_C_1 (Id_Operacion,Id_Garantia, Id_Tipo_Garantia, Monto, Porcentaje)
		SELECT 
			GAROPER.Id_Operacion,
			AUX_V.Id_Garantia,
			GAROPER.Id_Tipo_Garantia, 
			CASE TP.Cod_Tipo_Garantia	WHEN 2 THEN ISNULL(GAR.Monto_Tasacion_Actualizada_Terreno,0) + ISNULL(GAR.Monto_Tasacion_Actualizada_No_Terreno,0)
										WHEN 3 THEN CASE WHEN TM.Cod_Tipo_Moneda = 2 THEN @TIPOCAMBIO ELSE 1 END * CASE WHEN ISNULL(GAV.Monto_Valor_Facial,0) > ISNULL(GAV.Monto_Valor_Mercado,0)
														 THEN ISNULL(GAV.Monto_Valor_Mercado,0)
														 ELSE ISNULL(GAV.Monto_Valor_Facial,0)
													END
										ELSE 0
			END Monto,
			(CASE TP.Cod_Tipo_Garantia	WHEN 2 THEN ISNULL(GAR.Monto_Tasacion_Actualizada_Terreno,0) + ISNULL(GAR.Monto_Tasacion_Actualizada_No_Terreno,0)
										WHEN 3 THEN CASE WHEN TM.Cod_Tipo_Moneda = 2 THEN @TIPOCAMBIO ELSE 1 END * CASE WHEN ISNULL(GAV.Monto_Valor_Facial,0) > ISNULL(GAV.Monto_Valor_Mercado,0)
														 THEN ISNULL(GAV.Monto_Valor_Mercado,0)
														 ELSE ISNULL(GAV.Monto_Valor_Facial,0)
													END
										ELSE 0
			END * GAROPER.Porcentaje_Aceptacion_BCR)/ 100 Porcentaje
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_C AUX_V
			ON AUX_V.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Real,GAROPER.Id_Garantia_Valor)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		INNER JOIN dbo.TIPOS_GARANTIAS TP
			ON TP.Id_Tipo_Garantia = AUX_V.Id_Tipo_Garantia
		LEFT JOIN dbo.GARANTIAS_REALES GAR
			ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
		LEFT JOIN dbo.GARANTIAS_VALORES GAV
			ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
		LEFT JOIN dbo.TIPOS_MONEDAS TM
			ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Facial
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C_1_01 ON dbo.AUX_PCJ_GARANTIAS_C_1
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C_1_02 ON dbo.AUX_PCJ_GARANTIAS_C_1
		(Id_Operacion ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--4
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C_1


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C_1
		(Id_Operacion INT,
		Porcentaje DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C_1 (Id_Operacion, Porcentaje)
		SELECT 
			Id_Operacion, 
			SUM(Porcentaje) Porcentaje
		FROM 
			dbo.AUX_PCJ_GARANTIAS_C_1
		GROUP BY 
			Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C_1_01 ON dbo.AUX_PCJ_OPERACIONES_C_1
		(Id_Operacion ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--5 6
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C_2


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C_2
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Porcentaje_Previo DECIMAL(22,2),
		Saldo_Colonizado DECIMAL(22,2),
		Porcentaje_Final DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C_2 (
			Id_Operacion,
			Id_Garantia,
			Id_Tipo_Garantia,
			Porcentaje_Previo,
			Saldo_Colonizado,
			Porcentaje_Final)
		SELECT 
			AUX_P.Id_Operacion,
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			CASE WHEN AUX_P.Porcentaje <> 0 
				THEN AUX_G.Porcentaje / AUX_P.Porcentaje 
				ELSE 0 
			END Porcentaje_Previo,
			CASE TP.Cod_Tipo_Operacion WHEN 1 THEN OPER.Saldo_Colonizado 
										   WHEN 2 THEN OPER.Saldo_Original_Colonizado
										   ELSE 0
				END Saldo_Colonizado,
			CASE WHEN AUX_P.Porcentaje <> 0 THEN(AUX_G.Porcentaje / AUX_P.Porcentaje) * (CASE TP.Cod_Tipo_Operacion WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
																							WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
																							ELSE 0
																END)
				ELSE 0 END Porcentaje_Final
		FROM 
			dbo.AUX_PCJ_OPERACIONES_C_1 AUX_P
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_C_1 AUX_G
			ON AUX_P.Id_Operacion = AUX_G.Id_Operacion
		INNER JOIN dbo.OPERACIONES OPER
			ON OPER.Id_Operacion = AUX_P.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion


		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C_2_01 ON dbo.AUX_PCJ_OPERACIONES_C_2
		(Id_Operacion ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--7
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C_3


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C_3
		(Id_Operacion INT,
		Porcentaje_Final DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C_3 (Id_Operacion,Porcentaje_Final)
		SELECT 
			Id_Operacion,
			SUM(Porcentaje_Final) Porcentaje_Final
		FROM 
			dbo.AUX_PCJ_OPERACIONES_C_2
		GROUP BY 
			Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C_3_01 ON dbo.AUX_PCJ_OPERACIONES_C_3
		(Id_Operacion ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--8
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C_4') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C_4

		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C_4
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Porcentaje DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C_4 (Id_Operacion,Id_Garantia, Id_Tipo_Garantia, Porcentaje)
		SELECT 
			AUX_3.Id_Operacion,
			AUX_2.Id_Garantia,
			AUX_2.Id_Tipo_Garantia,
			CASE WHEN AUX_3.Porcentaje_Final <> 0 THEN (AUX_2.Porcentaje_Final / AUX_3.Porcentaje_Final) * 100 
			ELSE 0 END Porcentaje
		FROM 
			dbo.AUX_PCJ_OPERACIONES_C_2 AUX_2
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C_3 AUX_3
			ON AUX_2.Id_Operacion = AUX_3.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C_4_01 ON dbo.AUX_PCJ_OPERACIONES_C_4
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--9 10
		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF = CASE WHEN AUX_V.Porcentaje > 100 
														THEN 100 
														WHEN AUX_V.Porcentaje < 0
														THEN 0
														ELSE AUX_V.Porcentaje
													END
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C_4 AUX_V
			ON AUX_V.Id_Operacion = GAROPER.Id_Operacion
			AND AUX_V.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Valor,GAROPER.Id_Garantia_Real)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

--Fin Escenario C
		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END


GO


