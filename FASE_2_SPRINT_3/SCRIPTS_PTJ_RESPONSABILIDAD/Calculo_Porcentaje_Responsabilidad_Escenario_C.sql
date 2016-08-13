USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Porcentaje_Responsabilidad_Escenario_C', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Porcentaje_Responsabilidad_Escenario_C;
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
		<Autor>Mauricio Castro</Autor>
		<Requerimiento>RQ_MANT_2016022310547701_Backlog_870 SIGANEM- Porcentaje de Responsabilidad SUGEF con Fideicomisos y Avales</Requerimiento>
		<Fecha>Julio 2016</Fecha>
		<Descripción>Se incluyen dentro del cálculo las garantías de tipo Fideicomiso</Descripción>
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

--Escenario C:1

		--Garantias Valores, Reales y Fideicomiso

		DECLARE @TIPOCAMBIO DECIMAL(7,2)
		SELECT TOP 1 
			@TIPOCAMBIO = Valor
		FROM 
			dbo.TIPOS_CAMBIOS TPC
		ORDER BY 
			Fecha DESC

		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_C1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_C1


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_C1
		(Id_Garantia INT,
		Id_Tipo_Garantia INT)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_C1 (Id_Garantia, Id_Tipo_Garantia)
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
		HAVING COUNT(1) = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C1_01 ON dbo.AUX_PCJ_GARANTIAS_C1
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC) 

		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C1


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C1
		(Id_Operacion INT)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C1 (Id_Operacion)
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

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C1_01 ON dbo.AUX_PCJ_OPERACIONES_C1
		(Id_Operacion ASC) 
		
		--2 3
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_C1_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_C1_1


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_C1_1
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Monto DECIMAL(22,2),
		Porcentaje DECIMAL(22,2)
		)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_C1_1 (Id_Operacion,Id_Garantia, Id_Tipo_Garantia, Monto, Porcentaje)
		SELECT 
			GAROPER.Id_Operacion,
			AUX_V.Id_Garantia,
			GAROPER.Id_Tipo_Garantia, 
			CASE TP.Cod_Tipo_Garantia	WHEN 2 THEN ISNULL(GAR.Monto_Tasacion_Actualizada_Terreno,0) + ISNULL(GAR.Monto_Tasacion_Actualizada_No_Terreno,0)
										WHEN 3 THEN CASE WHEN TM.Cod_Tipo_Moneda = 2 THEN @TIPOCAMBIO ELSE 1 END * CASE WHEN ISNULL(GAV.Monto_Valor_Facial,0) > ISNULL(GAV.Monto_Valor_Mercado,0)
														 THEN ISNULL(GAV.Monto_Valor_Mercado,0)
														 ELSE ISNULL(GAV.Monto_Valor_Facial,0)
													END
										WHEN 8 THEN ISNULL(FID.Valor_Nominal,0)
										
										ELSE 0
			END Monto,
			CASE
				WHEN TP.Cod_Tipo_Garantia = 8 THEN 100
			ELSE
			(CASE TP.Cod_Tipo_Garantia	WHEN 2 THEN ISNULL(GAR.Monto_Tasacion_Actualizada_Terreno,0) + ISNULL(GAR.Monto_Tasacion_Actualizada_No_Terreno,0)
										WHEN 3 THEN CASE WHEN TM.Cod_Tipo_Moneda = 2 THEN @TIPOCAMBIO ELSE 1 END * CASE WHEN ISNULL(GAV.Monto_Valor_Facial,0) > ISNULL(GAV.Monto_Valor_Mercado,0)
														 THEN ISNULL(GAV.Monto_Valor_Mercado,0)
														 ELSE ISNULL(GAV.Monto_Valor_Facial,0)
													END
										ELSE 0
				END * GAROPER.Porcentaje_Aceptacion_BCR)/ 100 
			END Porcentaje
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C1  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_C1 AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		INNER JOIN dbo.TIPOS_GARANTIAS TP
			ON TP.Id_Tipo_Garantia = AUX_V.Id_Tipo_Garantia
		LEFT JOIN dbo.GARANTIAS_REALES GAR
			ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
		LEFT JOIN dbo.FIDEICOMISOS FID
			ON FID.Id_Fideicomiso = GAROPER.Id_Fideicomiso
		LEFT JOIN dbo.GARANTIAS_VALORES GAV
			ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
		LEFT JOIN dbo.TIPOS_MONEDAS TM
			ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Facial
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C1_1_01 ON dbo.AUX_PCJ_GARANTIAS_C1_1
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C1_1_02 ON dbo.AUX_PCJ_GARANTIAS_C1_1
		(Id_Operacion ASC)

		--4
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C1_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C1_1


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C1_1
		(Id_Operacion INT,
		Porcentaje DECIMAL(22,2)
		)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C1_1 (Id_Operacion, Porcentaje)
		SELECT 
			Id_Operacion, 
			SUM(Porcentaje) Porcentaje
		FROM 
			dbo.AUX_PCJ_GARANTIAS_C1_1
		GROUP BY 
			Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C1_1_01 ON dbo.AUX_PCJ_OPERACIONES_C1_1
		(Id_Operacion ASC)

		--5 6
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C1_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C1_2


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C1_2
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Porcentaje_Previo DECIMAL(22,2),
		Saldo_Colonizado DECIMAL(22,2),
		Porcentaje_Final DECIMAL(22,2)
		)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C1_2 (
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
			dbo.AUX_PCJ_OPERACIONES_C1_1 AUX_P
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_C1_1 AUX_G
			ON AUX_P.Id_Operacion = AUX_G.Id_Operacion
		INNER JOIN dbo.OPERACIONES OPER
			ON OPER.Id_Operacion = AUX_P.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion


		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C1_2_01 ON dbo.AUX_PCJ_OPERACIONES_C1_2
		(Id_Operacion ASC)

		--7
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C1_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C1_3


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C1_3
		(Id_Operacion INT,
		Porcentaje_Final DECIMAL(22,2)
		)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C1_3 (Id_Operacion,Porcentaje_Final)
		SELECT 
			Id_Operacion,
			SUM(Porcentaje_Final) Porcentaje_Final
		FROM 
			dbo.AUX_PCJ_OPERACIONES_C1_2
		GROUP BY 
			Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C1_3_01 ON dbo.AUX_PCJ_OPERACIONES_C1_3
		(Id_Operacion ASC)

		--8
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C1_4') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C1_4

		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C1_4
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Porcentaje DECIMAL(22,2)
		)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C1_4 (Id_Operacion,Id_Garantia, Id_Tipo_Garantia, Porcentaje)
		SELECT 
			AUX_3.Id_Operacion,
			AUX_2.Id_Garantia,
			AUX_2.Id_Tipo_Garantia,
			CASE WHEN AUX_3.Porcentaje_Final <> 0 THEN (AUX_2.Porcentaje_Final / AUX_3.Porcentaje_Final) * 100 
			ELSE 0 END Porcentaje
		FROM 
			dbo.AUX_PCJ_OPERACIONES_C1_2 AUX_2
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C1_3 AUX_3
			ON AUX_2.Id_Operacion = AUX_3.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C1_4_01 ON dbo.AUX_PCJ_OPERACIONES_C1_4
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)

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
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C1_4 AUX_V
			ON AUX_V.Id_Operacion = GAROPER.Id_Operacion
			AND AUX_V.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Valor,GAROPER.Id_Garantia_Real)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

--Fin Escenario C:1

/****************************************************************************************************************************************/

--Escenario C:2

		--Garantias Valores, Reales, Avales y Fideicomiso
		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_C2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_C2


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_C2
		(Id_Garantia INT,
		Id_Tipo_Garantia INT)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_C2 (Id_Garantia, Id_Tipo_Garantia)
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
		HAVING COUNT(1) = 1

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
		HAVING COUNT(1) = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C2_01 ON dbo.AUX_PCJ_GARANTIAS_C2
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC) 

		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C2


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C2
		(Id_Operacion INT)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C2 (Id_Operacion)
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

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C2_01 ON dbo.AUX_PCJ_OPERACIONES_C2
		(Id_Operacion ASC) 

		--2
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_C2_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_C2_1

		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_C2_1
		(Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Saldo_Colonizado DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_C2_1 (Id_Garantia, Id_Tipo_Garantia, Saldo_Colonizado)
		SELECT 
			AUX_V.Id_Garantia,
			GAROPER.Id_Tipo_Garantia,
			SUM(CASE TP.Cod_Tipo_Operacion WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
										   WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
										   ELSE 0
				END) Saldo_Colonizado
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.OPERACIONES OPER
			ON OPER.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C2  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_C2 AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1
		GROUP BY AUX_V.Id_Garantia,
			GAROPER.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C2_1_01 ON dbo.AUX_PCJ_GARANTIAS_C2_1
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		--3 4 (calcular el monto a utilizar solo aval) 
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_C2_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_C2_2

		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_C2_2
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Saldo_Distribuir DECIMAL(22,2),
		Monto_Aval DECIMAL(22,2), 
		Porcentaje_Aceptacion_BCR NUMERIC(5,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_C2_2 (Id_Operacion, Id_Garantia, Id_Tipo_Garantia, Saldo_Distribuir, Monto_Aval, Porcentaje_Aceptacion_BCR)
		SELECT	GAROPER.Id_Operacion,
				AUX_1.Id_Garantia,
				AUX_1.Id_Tipo_Garantia,
				CASE 
					WHEN AUX_1.Id_Tipo_Garantia = 11 THEN AUX_1.Saldo_Colonizado - ((AUX_1.Saldo_Colonizado * GAROPER.Porcentaje_Aceptacion_BCR)/100) 
					ELSE AUX_1.Saldo_Colonizado
				END AS Saldo_Distribuir,
				((AUX_1.Saldo_Colonizado * GAROPER.Porcentaje_Aceptacion_BCR)/100) AS Monto_Aval,
				GAROPER.Porcentaje_Aceptacion_BCR AS Porcentaje_Aceptacion_BCR
		FROM dbo.AUX_PCJ_GARANTIAS_C2_1 AUX_1
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON AUX_1.Id_Garantia = GAROPER.Id_Garantia_Aval
			AND GAROPER.Ind_Estado_Registro = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C2_2_01 ON dbo.AUX_PCJ_GARANTIAS_C2_2
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC)

		--5 6
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_C2_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_C2_3


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_C2_3
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Monto DECIMAL(22,2),
		Porcentaje DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_C2_3 (Id_Operacion,Id_Garantia, Id_Tipo_Garantia, Monto, Porcentaje)
		SELECT 
			GAROPER.Id_Operacion,
			AUX_V.Id_Garantia,
			GAROPER.Id_Tipo_Garantia, 
			CASE TP.Cod_Tipo_Garantia	WHEN 2 THEN ISNULL(GAR.Monto_Tasacion_Actualizada_Terreno,0) + ISNULL(GAR.Monto_Tasacion_Actualizada_No_Terreno,0)
										WHEN 3 THEN CASE WHEN TM.Cod_Tipo_Moneda = 2 THEN @TIPOCAMBIO ELSE 1 END * CASE WHEN ISNULL(GAV.Monto_Valor_Facial,0) > ISNULL(GAV.Monto_Valor_Mercado,0)
														 THEN ISNULL(GAV.Monto_Valor_Mercado,0)
														 ELSE ISNULL(GAV.Monto_Valor_Facial,0)
													END
										WHEN 8 THEN ISNULL(F.Valor_Nominal,0)
										
										ELSE 0
			END Monto,
			CASE
				WHEN TP.Cod_Tipo_Garantia = 8 THEN 100
			ELSE
				(CASE TP.Cod_Tipo_Garantia	WHEN 2 THEN ISNULL(GAR.Monto_Tasacion_Actualizada_Terreno,0) + ISNULL(GAR.Monto_Tasacion_Actualizada_No_Terreno,0)
											WHEN 3 THEN CASE WHEN TM.Cod_Tipo_Moneda = 2 THEN @TIPOCAMBIO ELSE 1 END * CASE WHEN ISNULL(GAV.Monto_Valor_Facial,0) > ISNULL(GAV.Monto_Valor_Mercado,0)
															 THEN ISNULL(GAV.Monto_Valor_Mercado,0)
															 ELSE ISNULL(GAV.Monto_Valor_Facial,0)
														END
											ELSE 0
				END * GAROPER.Porcentaje_Aceptacion_BCR)/ 100 
			END Porcentaje
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C2  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_C2 AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		INNER JOIN dbo.TIPOS_GARANTIAS TP
			ON TP.Id_Tipo_Garantia = AUX_V.Id_Tipo_Garantia
		LEFT JOIN dbo.GARANTIAS_REALES GAR
			ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
		LEFT JOIN dbo.FIDEICOMISOS F
			ON F.Id_Fideicomiso = GAROPER.Id_Fideicomiso
		LEFT JOIN dbo.GARANTIAS_VALORES GAV
			ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
		LEFT JOIN dbo.TIPOS_MONEDAS TM
			ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Facial
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C2_3_01 ON dbo.AUX_PCJ_GARANTIAS_C2_3
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_C2_3_02 ON dbo.AUX_PCJ_GARANTIAS_C2_3
		(Id_Operacion ASC)
		

		--7
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C2_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C2_1


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C2_1
		(Id_Operacion INT,
		Porcentaje DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C2_1 (Id_Operacion, Porcentaje)
		SELECT 
			Id_Operacion, 
			SUM(Porcentaje) Porcentaje
		FROM 
			dbo.AUX_PCJ_GARANTIAS_C2_3
		GROUP BY 
			Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C2_1_01 ON dbo.AUX_PCJ_OPERACIONES_C2_1
		(Id_Operacion ASC)
		

		--8 9
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C2_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C2_2


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C2_2
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Porcentaje_Previo DECIMAL(22,2),
		Monto_Responsabilidad DECIMAL(22,2),
		Porcentaje_Final DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C2_2 (
			Id_Operacion,
			Id_Garantia,
			Id_Tipo_Garantia,
			Porcentaje_Previo,
			Monto_Responsabilidad,
			Porcentaje_Final)
		SELECT 
			AUX_P.Id_Operacion,
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			CASE WHEN AUX_P.Porcentaje <> 0 
				THEN AUX_G.Porcentaje / AUX_P.Porcentaje 
				ELSE 0 
			END Porcentaje_Previo,
			((CASE WHEN AUX_P.Porcentaje <> 0 
				THEN AUX_G.Porcentaje / AUX_P.Porcentaje 
				ELSE 0 
			  END) 
			  * AUX_G2.Saldo_Distribuir) AS Monto_Responsabilidad,
			NULL AS Porcentaje_Final
		FROM 
			dbo.AUX_PCJ_OPERACIONES_C2_1 AUX_P
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_C2_3 AUX_G
			ON AUX_P.Id_Operacion = AUX_G.Id_Operacion
		INNER JOIN dbo.OPERACIONES OPER
			ON OPER.Id_Operacion = AUX_P.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion
		INNER JOIN 
			(SELECT AUX_G3.Id_Operacion, AUX_G3.Saldo_Distribuir 
			 FROM 
				dbo.AUX_PCJ_OPERACIONES_C2_2  AUX_P
			 INNER JOIN 
				(SELECT AUX_1.Id_Operacion, MIN(AUX_1.Saldo_Distribuir) AS Saldo_Distribuir
				 FROM dbo.AUX_PCJ_GARANTIAS_C2_2 AUX_1
				 GROUP BY AUX_1.Id_Operacion) AUX_G3
				ON AUX_G3.Id_Operacion = AUX_P.Id_Operacion
			 WHERE AUX_P.Id_Tipo_Garantia <> 11) AUX_G2
			 ON AUX_G2.Id_Operacion = OPER.Id_Operacion

		UNION 

		SELECT 
			AUX_G.Id_Operacion,
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			0 Porcentaje_Previo,
			AUX_G.Monto_Aval AS Monto_Responsabilidad,
			AUX_G.Porcentaje_Aceptacion_BCR AS Porcentaje_Final
		FROM 
			dbo.AUX_PCJ_GARANTIAS_C2_2 AUX_G

				
		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C2_2_01 ON dbo.AUX_PCJ_OPERACIONES_C2_2
		(Id_Operacion ASC)
		

		--10
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C2_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C2_3


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C2_3
		(Id_Operacion INT,
		Monto_Responsabilidad_Total DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C2_3 (Id_Operacion, Monto_Responsabilidad_Total)
		SELECT 
			Id_Operacion,
			SUM(Monto_Responsabilidad) Monto_Responsabilidad_Total
		FROM 
			dbo.AUX_PCJ_OPERACIONES_C2_2
		GROUP BY 
			Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C2_3_01 ON dbo.AUX_PCJ_OPERACIONES_C2_3
		(Id_Operacion ASC)
		

		--11 12
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_C2_4') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_C2_4

		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_C2_4
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Porcentaje DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_C2_4 (Id_Operacion,Id_Garantia, Id_Tipo_Garantia, Porcentaje)
		SELECT 
			AUX_3.Id_Operacion,
			AUX_2.Id_Garantia,
			AUX_2.Id_Tipo_Garantia,
			CASE WHEN AUX_3.Monto_Responsabilidad_Total <> 0 THEN (AUX_2.Monto_Responsabilidad / AUX_3.Monto_Responsabilidad_Total) * 100 
			ELSE 0 END Porcentaje
		FROM 
			dbo.AUX_PCJ_OPERACIONES_C2_2 AUX_2
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C2_3 AUX_3
			ON AUX_2.Id_Operacion = AUX_3.Id_Operacion
		WHERE AUX_2.Id_Tipo_Garantia <> 11

		UNION
		
		SELECT 
			AUX_3.Id_Operacion,
			AUX_2.Id_Garantia,
			AUX_2.Id_Tipo_Garantia,
			AUX_2.Porcentaje_Final AS Porcentaje
		FROM 
			dbo.AUX_PCJ_OPERACIONES_C2_2 AUX_2
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C2_3 AUX_3
			ON AUX_2.Id_Operacion = AUX_3.Id_Operacion
		WHERE AUX_2.Id_Tipo_Garantia = 11


		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_C2_4_01 ON dbo.AUX_PCJ_OPERACIONES_C2_4
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		--13
		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF = CASE WHEN ISNULL(AUX_V.Porcentaje, 0) > 100 
														THEN 100 
														WHEN ISNULL(AUX_V.Porcentaje, 0) < 0
														THEN 0
														ELSE AUX_V.Porcentaje
													END
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_C2_4 AUX_V
			ON AUX_V.Id_Operacion = GAROPER.Id_Operacion
			AND AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

--Fin Escenario C:2

		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END