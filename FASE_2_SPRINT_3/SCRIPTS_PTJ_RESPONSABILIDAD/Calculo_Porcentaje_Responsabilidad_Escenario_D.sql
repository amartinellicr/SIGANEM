USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Porcentaje_Responsabilidad_Escenario_D', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Porcentaje_Responsabilidad_Escenario_D;
GO


CREATE PROCEDURE [dbo].[Calculo_Porcentaje_Responsabilidad_Escenario_D]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Porcentaje_Responsabilidad_Escenario_D</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo del porcentaje de responsabilidad para las garantias reales 
	y valores. Una operación tiene relación con más de una garantía, y esas garantías pueden tener relación con otra operación
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Alexander Cruz</Autor>
<Fecha>Octubre 2015</Fecha>
<Requerimiento>RQ_MANT_2015042110384902_00055 Pcj Responsabilidad, Pcj Aceptación BCR y Monto Gravamen 1_1</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli M.</Autor>
		<Requerimiento>RQ_MANT_2016022310547701_Backlog_870 SIGANEM- Porcentaje de Responsabilidad SUGEF con Fideicomisos y Avales</Requerimiento>
		<Fecha>Agosto 2016</Fecha>
		<Descripción>Se incluyen dentro del cálculo las garantías de tipo Fideicomiso y Avales</Descripción>
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
		--Escenario D: 1
		--Garantias Valores y Reales

		DECLARE @TIPOCAMBIO DECIMAL(7,2)
		SELECT TOP 1 
			@TIPOCAMBIO = Valor
		FROM 
			dbo.TIPOS_CAMBIOS TPC
		ORDER BY 
			Fecha DESC

		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D1


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D1
		(Id_Garantia INT,
		Id_Tipo_Garantia INT)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D1 (Id_Garantia, Id_Tipo_Garantia)
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


		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D1_01 ON dbo.AUX_PCJ_GARANTIAS_D1
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC) 
		

		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D1


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D1
		(Id_Operacion INT)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D1 (Id_Operacion)
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

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D1_01 ON dbo.AUX_PCJ_OPERACIONES_D1
		(Id_Operacion ASC) 
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D1 (Id_Garantia, Id_Tipo_Garantia)
		SELECT DISTINCT
			COALESCE(GAROPER.Id_Garantia_Real, GAROPER.Id_Garantia_Valor, GAROPER.Id_Fideicomiso) AS Id_Garantia,
			GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D1 AUX
			ON AUX.Id_Operacion = GAROPER.Id_Operacion
			AND GAROPER.Ind_Estado_Registro = 1
			AND GAROPER.Id_Garantia_Fiduciaria IS NULL
		LEFT JOIN dbo.AUX_PCJ_GARANTIAS_D1 AUX_2
			ON AUX_2.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Real, GAROPER.Id_Garantia_Valor, GAROPER.Id_Fideicomiso)
			AND AUX_2.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			AUX_2.Id_Tipo_Garantia IS NULL

		--2
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D1_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D1_1


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D1_1
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Monto DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D1_1 (Id_Operacion ,Id_Garantia, Id_Tipo_Garantia, Monto)
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
			END Monto
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D1  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_D1 AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		INNER JOIN dbo.TIPOS_GARANTIAS TP
			ON TP.Id_Tipo_Garantia = AUX_V.Id_Tipo_Garantia
		LEFT JOIN dbo.GARANTIAS_REALES GAR
			ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
		LEFT JOIN dbo.GARANTIAS_VALORES GAV
			ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
		LEFT JOIN dbo.TIPOS_MONEDAS TM
			ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Facial
		LEFT JOIN dbo.FIDEICOMISOS FID
			ON FID.Id_Fideicomiso = GAROPER.Id_Fideicomiso
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D1_1_01 ON dbo.AUX_PCJ_GARANTIAS_D1_1
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D1_1_02 ON dbo.AUX_PCJ_GARANTIAS_D1_1
		(Id_Operacion ASC)
		


		--3
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D1_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D1_1


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D1_1
		(Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Porcentaje DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D1_1 (Id_Garantia,Id_Tipo_Garantia, Porcentaje)
		SELECT 
			AUX.Id_Garantia,
			AUX.Id_Tipo_Garantia,
			MIN(Porcentaje_Aceptacion_BCR) Porcentaje
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D1 AUX
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAR
			ON ISNULL(GAR.Id_Garantia_Real,GAR.Id_Garantia_Valor) = AUX.Id_Garantia
			AND GAR.Id_Tipo_Garantia = AUX.Id_Tipo_Garantia
		WHERE 
			GAR.Ind_Estado_Registro = 1
		GROUP BY 
			AUX.Id_Garantia,
			AUX.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D1_1_01 ON dbo.AUX_PCJ_OPERACIONES_D1_1
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC
		)
		


		--4 5
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D1_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D1_2


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D1_2
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		VAG DECIMAL(22,2), --Valor Ajustado Garantia
		Monto_Grado_Gravamen DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D1_2 (
			Id_Operacion,
			Id_Garantia,
			Id_Tipo_Garantia,
			VAG,
			Monto_Grado_Gravamen)
		SELECT 
			GAROPER.Id_Operacion,
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			CASE 
				WHEN GAROPER.Id_Tipo_Garantia = 8 THEN 100
				ELSE ((AUX_G.Monto * (AUX_P.Porcentaje*1)) / 100)
			END AS VAG,
			CASE WHEN TM.Cod_Tipo_Moneda = 2 THEN @TIPOCAMBIO ELSE 1 END * ISNULL(GAROPER.Monto_Grado_Gravamen,0) Monto_Grado_Gravamen
		FROM 
			dbo.AUX_PCJ_OPERACIONES_D1_1 AUX_P
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_D1_1 AUX_G
			ON AUX_P.Id_Garantia = AUX_G.Id_Garantia
			AND AUX_P.Id_Tipo_Garantia = AUX_G.Id_Tipo_Garantia
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON AUX_G.Id_Operacion = GAROPER.Id_Operacion
			AND AUX_G.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso)
			AND AUX_G.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		LEFT JOIN dbo.TIPOS_MONEDAS TM
			ON TM.Id_Tipo_Moneda = GAROPER.Id_Tipo_Moneda_Monto_Gravamen
		WHERE 
			GAROPER.Ind_Estado_Registro = 1


		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D1_2_01 ON dbo.AUX_PCJ_GARANTIAS_D1_2
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		--5
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D1_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D1_3


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D1_3
		(Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Total_Gravamen DECIMAL(22,2)
		)
		
		--6
		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D1_3(
			Id_Garantia,
			Id_Tipo_Garantia,
			Total_Gravamen)
		SELECT 
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			SUM(AUX_G.Monto_Grado_Gravamen) Monto_Grado_Gravamen
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D1_2 AUX_G
		GROUP BY
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D1_3_01 ON dbo.AUX_PCJ_GARANTIAS_D1_3
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D1_4') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D1_4


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D1_4
		(Id_Garantia INT,
		Id_Operacion INT,
		Id_Tipo_Garantia INT,
		Total_Gravamenes DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D1_4(
			Id_Garantia,
			Id_Operacion,
			Id_Tipo_Garantia,
			Total_Gravamenes)
		SELECT DISTINCT
			AUX_G.Id_Garantia,
			AUX_G.Id_Operacion,
			AUX_G.Id_Tipo_Garantia,
			(AUX_G.VAG - (AUX_G_1.Total_Gravamen - AUX_G.Monto_Grado_Gravamen)) Total_Gravamenes
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D1_2 AUX_G
		INNER JOIN AUX_PCJ_GARANTIAS_D1_3 AUX_G_1
			ON AUX_G.Id_Garantia = AUX_G_1.Id_Garantia
			AND AUX_G.Id_Tipo_Garantia = AUX_G_1.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D1_4_01 ON dbo.AUX_PCJ_GARANTIAS_D1_4
		(Id_Garantia ASC,
		Id_Operacion ASC,
		Id_Tipo_Garantia ASC)
		

		--7
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D1_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D1_2


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D1_2
		(Id_Operacion INT,
		Total_Gravamenes DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D1_2(Id_Operacion, Total_Gravamenes)
		SELECT 
			AUX_G.Id_Operacion,
			SUM(AUX_G_1.Total_Gravamenes) Total_Gravamenes
		FROM 
			dbo.GARANTIAS_OPERACIONES AUX_G
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_D1_4 AUX_G_1
			ON ISNULL(AUX_G.Id_Garantia_Real,Id_Garantia_Valor) = AUX_G_1.Id_Garantia
			AND AUX_G.Id_Operacion = AUX_G_1.Id_Operacion
			AND AUX_G.Id_Tipo_Garantia = AUX_G_1.Id_Tipo_Garantia
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D1 AUX_O
			ON AUX_O.Id_Operacion  = AUX_G.Id_Operacion
		WHERE 
			AUX_G.Ind_Estado_Registro = 1
		GROUP BY 
			AUX_G.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D1_2_01 ON dbo.AUX_PCJ_OPERACIONES_D1_2
		(Id_Operacion ASC)
		

		--8
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D1_5') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D1_5


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D1_5
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Total DECIMAL(22,6)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D1_5(
			Id_Operacion,
			Id_Garantia,
			Id_Tipo_Garantia,
			Total)
		SELECT 
			AUX_G.Id_Operacion,
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			CASE WHEN AUX_O.Total_Gravamenes <> 0 
				THEN AUX_G_1.Total_Gravamenes / AUX_O.Total_Gravamenes
				ELSE 0 
			END Total
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D1_2 AUX_G
		INNER JOIN AUX_PCJ_GARANTIAS_D1_4 AUX_G_1
			ON AUX_G.Id_Garantia = AUX_G_1.Id_Garantia
			AND AUX_G.Id_Operacion = AUX_G_1.Id_Operacion
			AND AUX_G.Id_Tipo_Garantia = AUX_G_1.Id_Tipo_Garantia
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D1_2 AUX_O
			ON AUX_O.Id_Operacion = AUX_G.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D1_5_01 ON dbo.AUX_PCJ_GARANTIAS_D1_5
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		--9
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D1_6') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D1_6


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D1_6
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Saldo_Colonizado DECIMAL(22,2),
		Monto DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D1_6(
			Id_Operacion,
			Id_Garantia,
			Id_Tipo_Garantia,
			Saldo_Colonizado,
			Monto)
		SELECT 
			AUX_P.Id_Operacion,
			AUX_P.Id_Garantia,
			AUX_P.Id_Tipo_Garantia,
			CASE TP.Cod_Tipo_Operacion WHEN 1 THEN OPER.Saldo_Colonizado 
										   WHEN 2 THEN OPER.Saldo_Original_Colonizado
										   ELSE 0
				END Saldo_Colonizado,
			(AUX_P.Total) * (CASE TP.Cod_Tipo_Operacion WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
																							WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
																							ELSE 0
																END) Monto
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D1_5 AUX_P
		INNER JOIN dbo.OPERACIONES OPER
			ON OPER.Id_Operacion = AUX_P.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D1_6_01 ON dbo.AUX_PCJ_GARANTIAS_D1_6
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		--10
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D1_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D1_3


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D1_3
		(Id_Operacion INT,
		Monto DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D1_3(Id_Operacion, Monto)
		SELECT 
			Id_Operacion,
			SUM(Monto) Monto
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D1_6
		GROUP BY
			Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D1_3_01 ON dbo.AUX_PCJ_OPERACIONES_D1_3
		(Id_Operacion ASC)
		

		--11 12 13

		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF =	
			CASE WHEN AUX_O.Monto <> 0 THEN 
						CASE	WHEN ((AUX_G.Monto / AUX_O.Monto) * 100) > 100 THEN 100 
								WHEN ((AUX_G.Monto / AUX_O.Monto) * 100) < 0  THEN 0
							ELSE ((AUX_G.Monto / AUX_O.Monto) * 100)
							END
				 ELSE 0
			END
		FROM 
			dbo.AUX_PCJ_OPERACIONES_D1_3 AUX_O
		INNER JOIN AUX_PCJ_GARANTIAS_D1_6 AUX_G
			ON AUX_O.Id_Operacion = AUX_G.Id_Operacion
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON GAROPER.Id_Operacion = AUX_G.Id_Operacion
			AND COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso) = AUX_G.Id_Garantia
			AND GAROPER.Id_Tipo_Garantia = AUX_G.Id_Tipo_Garantia
		WHERE GAROPER.Ind_Estado_Registro = 1

--Fin Escenario D:1

/****************************************************************************************************************************************/

--Escenario D:2
		
		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D2


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D2
		(Id_Garantia INT,
		Id_Tipo_Garantia INT)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D2 (Id_Garantia, Id_Tipo_Garantia)
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

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D2_01 ON dbo.AUX_PCJ_GARANTIAS_D2
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC) 
		

		--2 
		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D2


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D2
		(Id_Operacion INT)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D2 (Id_Operacion)
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

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D2_01 ON dbo.AUX_PCJ_OPERACIONES_D2
		(Id_Operacion ASC) 
		
		--3 11
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D2_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D2_1


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D2_1
		(Id_Operacion INT,
		Saldo_Colonizado DECIMAL(22,2),
		Saldo_Distribuir DECIMAL(22,2),
		Monto_Aval DECIMAL(22,2),
		Porcentaje_Aceptacion_BCR NUMERIC(5,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D2_1 (Id_Operacion, Saldo_Colonizado, Saldo_Distribuir, Monto_Aval, Porcentaje_Aceptacion_BCR)
		SELECT 
			GAROPER.Id_Operacion,
			CASE TP.Cod_Tipo_Operacion WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
									   WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
									   ELSE 0
			END AS Saldo_Colonizado,

			(CASE GAROPER.Id_Tipo_Garantia 
			    WHEN 11 THEN (
			
					(CASE TP.Cod_Tipo_Operacion WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
												WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
												ELSE 0
					 END) 
					 -
					 (CASE GAROPER.Id_Tipo_Garantia WHEN 11 THEN (((CASE TP.Cod_Tipo_Operacion 
																		WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
																		WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
																		ELSE 0
																	END) * GAROPER.Porcentaje_Aceptacion_BCR) / 100)
												    ELSE 0
					  END))
			    ELSE 	CASE TP.Cod_Tipo_Operacion
							WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
							WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
							ELSE 0
						END 
			 END
			 ) AS Saldo_Distribuir,

			CASE GAROPER.Id_Tipo_Garantia WHEN 11 THEN (((CASE TP.Cod_Tipo_Operacion 
															WHEN 1 THEN ISNULL(OPER.Saldo_Colonizado,0)
															WHEN 2 THEN ISNULL(OPER.Saldo_Original_Colonizado,0)
															ELSE 0
														   END) * GAROPER.Porcentaje_Aceptacion_BCR) / 100)
										   ELSE 0
			END AS Monto_Aval,
			GAROPER.Porcentaje_Aceptacion_BCR AS Porcentaje_Aceptacion_BCR
		FROM 
			dbo.OPERACIONES OPER
		INNER JOIN AUX_PCJ_OPERACIONES_D2 AUX
			ON AUX.Id_Operacion = OPER.Id_Operacion
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON OPER.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion
			AND TP.Ind_Estado_Registro = 1		
		WHERE 
			OPER.Ind_Estado_Registro = 1 
		AND GAROPER.Ind_Estado_Registro = 1
		
		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D2_1_01 ON dbo.AUX_PCJ_OPERACIONES_D2_1
		(Id_Operacion ASC) 



		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D2 (Id_Garantia, Id_Tipo_Garantia)
		SELECT DISTINCT
			COALESCE(GAROPER.Id_Garantia_Real, GAROPER.Id_Garantia_Valor, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval) AS Id_Garantia,
			GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D2 AUX
			ON AUX.Id_Operacion = GAROPER.Id_Operacion
			AND GAROPER.Ind_Estado_Registro = 1
			AND GAROPER.Id_Garantia_Fiduciaria IS NULL
		LEFT JOIN dbo.AUX_PCJ_GARANTIAS_D2 AUX_2
			ON AUX_2.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Real, GAROPER.Id_Garantia_Valor, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND AUX_2.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			AUX_2.Id_Tipo_Garantia IS NULL

		--4
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D2_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D2_1


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D2_1
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Monto DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D2_1 (Id_Operacion ,Id_Garantia, Id_Tipo_Garantia, Monto)
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
			END Monto
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D2  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_D2 AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		INNER JOIN dbo.TIPOS_GARANTIAS TP
			ON TP.Id_Tipo_Garantia = AUX_V.Id_Tipo_Garantia
		LEFT JOIN dbo.GARANTIAS_REALES GAR
			ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
		LEFT JOIN dbo.GARANTIAS_VALORES GAV
			ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
		LEFT JOIN dbo.TIPOS_MONEDAS TM
			ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Facial
		LEFT JOIN dbo.FIDEICOMISOS FID
			ON FID.Id_Fideicomiso = GAROPER.Id_Fideicomiso
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D2_1_01 ON dbo.AUX_PCJ_GARANTIAS_D2_1
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D2_1_02 ON dbo.AUX_PCJ_GARANTIAS_D2_1
		(Id_Operacion ASC)
		


		--5
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D2_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D2_2


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D2_2
		(Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Porcentaje DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D2_2 (Id_Garantia,Id_Tipo_Garantia, Porcentaje)
		SELECT 
			AUX.Id_Garantia,
			AUX.Id_Tipo_Garantia,
			MIN(Porcentaje_Aceptacion_BCR) Porcentaje
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D2 AUX
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAR
			ON ISNULL(GAR.Id_Garantia_Real, GAR.Id_Garantia_Valor) = AUX.Id_Garantia
			AND GAR.Id_Tipo_Garantia = AUX.Id_Tipo_Garantia
		WHERE 
			GAR.Ind_Estado_Registro = 1
		GROUP BY 
			AUX.Id_Garantia,
			AUX.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D2_2_01 ON dbo.AUX_PCJ_OPERACIONES_D2_2
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC
		)
		


		--6 7
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D2_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D2_2


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D2_2
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		VAG DECIMAL(22,2), --Valor Ajustado Garantia
		Monto_Grado_Gravamen DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D2_2 (
			Id_Operacion,
			Id_Garantia,
			Id_Tipo_Garantia,
			VAG,
			Monto_Grado_Gravamen)
		SELECT 
			GAROPER.Id_Operacion,
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			CASE 
				WHEN GAROPER.Id_Tipo_Garantia = 8 THEN 100
				ELSE ((AUX_G.Monto * (AUX_P.Porcentaje*1)) / 100)
			END AS VAG,
			CASE WHEN TM.Cod_Tipo_Moneda = 2 THEN @TIPOCAMBIO ELSE 1 END * ISNULL(GAROPER.Monto_Grado_Gravamen,0) Monto_Grado_Gravamen
		FROM 
			dbo.AUX_PCJ_OPERACIONES_D2_2 AUX_P
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_D2_1 AUX_G
			ON AUX_P.Id_Garantia = AUX_G.Id_Garantia
			AND AUX_P.Id_Tipo_Garantia = AUX_G.Id_Tipo_Garantia
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON AUX_G.Id_Operacion = GAROPER.Id_Operacion
			AND AUX_G.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso)
			AND AUX_G.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		LEFT JOIN dbo.TIPOS_MONEDAS TM
			ON TM.Id_Tipo_Moneda = GAROPER.Id_Tipo_Moneda_Monto_Gravamen
		WHERE 
			GAROPER.Ind_Estado_Registro = 1


		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D2_2_01 ON dbo.AUX_PCJ_GARANTIAS_D2_2
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		--8
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D2_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D2_3


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D2_3
		(Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Total_Gravamen DECIMAL(22,2)
		)
				
		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D2_3(
			Id_Garantia,
			Id_Tipo_Garantia,
			Total_Gravamen)
		SELECT 
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			SUM(AUX_G.Monto_Grado_Gravamen) Monto_Grado_Gravamen
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D2_2 AUX_G
		GROUP BY
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D2_3_01 ON dbo.AUX_PCJ_GARANTIAS_D2_3
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		
				
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D2_4') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D2_4


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D2_4
		(Id_Garantia INT,
		Id_Operacion INT,
		Id_Tipo_Garantia INT,
		Total_Gravamenes DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D2_4(
			Id_Garantia,
			Id_Operacion,
			Id_Tipo_Garantia,
			Total_Gravamenes)
		SELECT DISTINCT
			AUX_G.Id_Garantia,
			AUX_G.Id_Operacion,
			AUX_G.Id_Tipo_Garantia,
			(AUX_G.VAG - (AUX_G_1.Total_Gravamen - AUX_G.Monto_Grado_Gravamen)) Total_Gravamenes
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D2_2 AUX_G
		INNER JOIN AUX_PCJ_GARANTIAS_D2_3 AUX_G_1
			ON AUX_G.Id_Garantia = AUX_G_1.Id_Garantia
			AND AUX_G.Id_Tipo_Garantia = AUX_G_1.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D2_4_01 ON dbo.AUX_PCJ_GARANTIAS_D2_4
		(Id_Garantia ASC,
		Id_Operacion ASC,
		Id_Tipo_Garantia ASC)
		

		--9
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D2_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D2_3


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D2_3
		(Id_Operacion INT,
		Total_Gravamenes DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D2_3(Id_Operacion, Total_Gravamenes)
		SELECT 
			AUX_G.Id_Operacion,
			SUM(AUX_G_1.Total_Gravamenes) Total_Gravamenes
		FROM 
			dbo.GARANTIAS_OPERACIONES AUX_G
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_D2_4 AUX_G_1
			ON ISNULL(AUX_G.Id_Garantia_Real,Id_Garantia_Valor) = AUX_G_1.Id_Garantia
			AND AUX_G.Id_Operacion = AUX_G_1.Id_Operacion
			AND AUX_G.Id_Tipo_Garantia = AUX_G_1.Id_Tipo_Garantia
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D2 AUX_O
			ON AUX_O.Id_Operacion  = AUX_G.Id_Operacion
		WHERE 
			AUX_G.Ind_Estado_Registro = 1
		GROUP BY 
			AUX_G.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D2_3_01 ON dbo.AUX_PCJ_OPERACIONES_D2_3
		(Id_Operacion ASC)
		

		--10
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D2_5') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D2_5


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D2_5
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Total DECIMAL(22,6)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D2_5(
			Id_Operacion,
			Id_Garantia,
			Id_Tipo_Garantia,
			Total)
		SELECT 
			AUX_G.Id_Operacion,
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			CASE WHEN AUX_O.Total_Gravamenes <> 0 
				THEN AUX_G_1.Total_Gravamenes / AUX_O.Total_Gravamenes
				ELSE 0 
			END Total
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D2_2 AUX_G
		INNER JOIN AUX_PCJ_GARANTIAS_D2_4 AUX_G_1
			ON AUX_G.Id_Garantia = AUX_G_1.Id_Garantia
			AND AUX_G.Id_Operacion = AUX_G_1.Id_Operacion
			AND AUX_G.Id_Tipo_Garantia = AUX_G_1.Id_Tipo_Garantia
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D2_3 AUX_O
			ON AUX_O.Id_Operacion = AUX_G.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D2_5_01 ON dbo.AUX_PCJ_GARANTIAS_D2_5
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		--12
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D2_6') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D2_6


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D2_6
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Saldo_Colonizado DECIMAL(22,2),
		Monto DECIMAL(22,2),
		Porcentaje_Aceptacion_BCR NUMERIC(5,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D2_6(
			Id_Operacion,
			Id_Garantia,
			Id_Tipo_Garantia,
			Saldo_Colonizado,
			Monto,
			Porcentaje_Aceptacion_BCR)
		SELECT 
			AUX_P.Id_Operacion,
			AUX_P.Id_Garantia,
			AUX_P.Id_Tipo_Garantia,
			AUX_O.Saldo_Colonizado AS Saldo_Colonizado,
			(AUX_P.Total) * (AUX_O.Saldo_Distribuir) Monto,
			AUX_O.Porcentaje_Aceptacion_BCR AS Porcentaje_Aceptacion_BCR
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D2_5 AUX_P
		INNER JOIN AUX_PCJ_OPERACIONES_D2_1 AUX_O
			ON AUX_O.Id_Operacion = AUX_P.Id_Operacion
		INNER JOIN dbo.OPERACIONES OPER
			ON OPER.Id_Operacion = AUX_O.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D2_6_01 ON dbo.AUX_PCJ_GARANTIAS_D2_6
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		

		--13
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D2_4') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D2_4


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D2_4
		(Id_Operacion INT,
		Monto DECIMAL(22,2)
		)
		

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D2_4(Id_Operacion, Monto)
		SELECT 
			Id_Operacion,
			SUM(Monto) Monto
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D2_6
		GROUP BY
			Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D2_4_01 ON dbo.AUX_PCJ_OPERACIONES_D2_4
		(Id_Operacion ASC)
		

		--14 15 16

		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF =	
			
			CASE AUX_G.Id_Tipo_Garantia 
				WHEN 11 THEN (
								CASE	WHEN AUX_G.Porcentaje_Aceptacion_BCR > 100 THEN 100 
										WHEN AUX_G.Porcentaje_Aceptacion_BCR < 0  THEN 0
										ELSE AUX_G.Porcentaje_Aceptacion_BCR
								END
							 )
				ELSE (	CASE WHEN AUX_O.Monto <> 0 THEN 
								CASE	WHEN ((AUX_G.Monto / AUX_O.Monto) * 100) > 100 THEN 100 
										WHEN ((AUX_G.Monto / AUX_O.Monto) * 100) < 0  THEN 0
										ELSE ((AUX_G.Monto / AUX_O.Monto) * 100)
								END
							 ELSE 0
						END
					)
			END
		FROM 
			dbo.AUX_PCJ_OPERACIONES_D2_4 AUX_O
		INNER JOIN AUX_PCJ_GARANTIAS_D2_6 AUX_G
			ON AUX_O.Id_Operacion = AUX_G.Id_Operacion
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON GAROPER.Id_Operacion = AUX_G.Id_Operacion
			AND COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval) = AUX_G.Id_Garantia
			AND GAROPER.Id_Tipo_Garantia = AUX_G.Id_Tipo_Garantia
		WHERE GAROPER.Ind_Estado_Registro = 1
		

		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END

