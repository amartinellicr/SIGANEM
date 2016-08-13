USE [SIGANEM]
GO

/****** Object:  StoredProcedure [dbo].[Calculo_Porcentaje_Responsabilidad_Escenario_D]    Script Date: 10/08/2016 11:37:04 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--EXEC [dbo].[Calculo_Porcentaje_Responsabilidad_Escenario_D]

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
		--Escenario D
		--Garantias Valores y Reales

		DECLARE @TIPOCAMBIO DECIMAL(7,2)
		SELECT TOP 1 
			@TIPOCAMBIO = Valor
		FROM 
			dbo.TIPOS_CAMBIOS TPC
		ORDER BY 
			Fecha DESC

		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D
		(Id_Garantia INT,
		Id_Tipo_Garantia INT)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D (Id_Garantia, Id_Tipo_Garantia)
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


		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D_01 ON dbo.AUX_PCJ_GARANTIAS_D
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC) 
		--WITH(DATA_COMPRESSION = PAGE)

		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D
		(Id_Operacion INT)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D (Id_Operacion)
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

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D_01 ON dbo.AUX_PCJ_OPERACIONES_D
		(Id_Operacion ASC) 
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D (Id_Garantia, Id_Tipo_Garantia)
		SELECT DISTINCT
			ISNULL(GAROPER.Id_Garantia_Real,GAROPER.Id_Garantia_Valor) AS Id_Garantia,
			GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D AUX
			ON AUX.Id_Operacion = GAROPER.Id_Operacion
			AND GAROPER.Ind_Estado_Registro = 1
			AND GAROPER.Id_Garantia_Fiduciaria IS NULL
		LEFT JOIN dbo.AUX_PCJ_GARANTIAS_D AUX_2
			ON AUX_2.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Real,GAROPER.Id_Garantia_Valor)
			AND AUX_2.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			AUX_2.Id_Tipo_Garantia IS NULL

		--2
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D_1


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D_1
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Monto DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D_1 (Id_Operacion ,Id_Garantia, Id_Tipo_Garantia, Monto)
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
			END Monto
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_D AUX_V
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

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D_1_01 ON dbo.AUX_PCJ_GARANTIAS_D_1
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D_1_02 ON dbo.AUX_PCJ_GARANTIAS_D_1
		(Id_Operacion ASC)
		--WITH(DATA_COMPRESSION = PAGE)


		--3
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D_1


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D_1
		(--Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Porcentaje DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D_1 (Id_Garantia/*Id_Operacion*/,Id_Tipo_Garantia, Porcentaje)
		SELECT 
			--AUX.Id_Operacion, 
			AUX.Id_Garantia,
			AUX.Id_Tipo_Garantia,
			MIN(Porcentaje_Aceptacion_BCR) Porcentaje
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D/*AUX_PCJ_OPERACIONES_D*/ AUX
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAR
			ON ISNULL(GAR.Id_Garantia_Real,GAR.Id_Garantia_Valor) = AUX.Id_Garantia--GAR.Id_Operacion = AUX.Id_Operacion
			AND GAR.Id_Tipo_Garantia = AUX.Id_Tipo_Garantia
		WHERE 
			GAR.Ind_Estado_Registro = 1
		GROUP BY 
			--AUX.Id_Operacion
			AUX.Id_Garantia,
			AUX.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D_1_01 ON dbo.AUX_PCJ_OPERACIONES_D_1
		(--Id_Operacion ASC
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC
		)
		--WITH(DATA_COMPRESSION = PAGE)


		--4 5
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D_2


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D_2
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		VAG DECIMAL(22,2), --Valor Ajustado Garantia
		Monto_Grado_Gravamen DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D_2 (
			Id_Operacion,
			Id_Garantia,
			Id_Tipo_Garantia,
			VAG,
			Monto_Grado_Gravamen)
		SELECT 
			GAROPER.Id_Operacion,
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			(AUX_G.Monto * (AUX_P.Porcentaje*1)) / 100 VAG,
			CASE WHEN TM.Cod_Tipo_Moneda = 2 THEN @TIPOCAMBIO ELSE 1 END * ISNULL(GAROPER.Monto_Grado_Gravamen,0) Monto_Grado_Gravamen
		FROM 
			dbo.AUX_PCJ_OPERACIONES_D_1 AUX_P
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_D_1 AUX_G
			ON AUX_P.Id_Garantia = AUX_G.Id_Garantia
			AND AUX_P.Id_Tipo_Garantia = AUX_G.Id_Tipo_Garantia
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON AUX_G.Id_Operacion = GAROPER.Id_Operacion
			AND AUX_G.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Valor,GAROPER.Id_Garantia_Real)
			AND AUX_G.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		LEFT JOIN dbo.TIPOS_MONEDAS TM
			ON TM.Id_Tipo_Moneda = GAROPER.Id_Tipo_Moneda_Monto_Gravamen
		WHERE 
			GAROPER.Ind_Estado_Registro = 1


		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D_2_01 ON dbo.AUX_PCJ_GARANTIAS_D_2
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--5
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D_3


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D_3
		(Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Total_Gravamen DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D_3(
			Id_Garantia,
			Id_Tipo_Garantia,
			Total_Gravamen)
		SELECT 
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia,
			SUM(AUX_G.Monto_Grado_Gravamen) Monto_Grado_Gravamen
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D_2 AUX_G
		GROUP BY
			AUX_G.Id_Garantia,
			AUX_G.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D_3_01 ON dbo.AUX_PCJ_GARANTIAS_D_3
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--6

		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D_4') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D_4


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D_4
		(Id_Garantia INT,
		Id_Operacion INT,
		Id_Tipo_Garantia INT,
		Total_Gravamenes DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D_4(
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
			dbo.AUX_PCJ_GARANTIAS_D_2 AUX_G
		INNER JOIN AUX_PCJ_GARANTIAS_D_3 AUX_G_1
			ON AUX_G.Id_Garantia = AUX_G_1.Id_Garantia
			AND AUX_G.Id_Tipo_Garantia = AUX_G_1.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D_4_01 ON dbo.AUX_PCJ_GARANTIAS_D_4
		(Id_Garantia ASC,
		Id_Operacion ASC,
		Id_Tipo_Garantia ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--7
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D_2') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D_2


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D_2
		(Id_Operacion INT,
		Total_Gravamenes DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D_2(Id_Operacion, Total_Gravamenes)
		SELECT 
			AUX_G.Id_Operacion,
			SUM(AUX_G_1.Total_Gravamenes) Total_Gravamenes
		FROM 
			dbo.GARANTIAS_OPERACIONES AUX_G
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_D_4 AUX_G_1
			ON ISNULL(AUX_G.Id_Garantia_Real,Id_Garantia_Valor) = AUX_G_1.Id_Garantia
			AND AUX_G.Id_Operacion = AUX_G_1.Id_Operacion
			AND AUX_G.Id_Tipo_Garantia = AUX_G_1.Id_Tipo_Garantia
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D AUX_O
			ON AUX_O.Id_Operacion  = AUX_G.Id_Operacion
		WHERE 
			AUX_G.Ind_Estado_Registro = 1
		GROUP BY 
			AUX_G.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D_2_01 ON dbo.AUX_PCJ_OPERACIONES_D_2
		(Id_Operacion ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--8
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D_5') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D_5


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D_5
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Total DECIMAL(22,6)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D_5(
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
			dbo.AUX_PCJ_GARANTIAS_D_2 AUX_G
		INNER JOIN AUX_PCJ_GARANTIAS_D_4 AUX_G_1
			ON AUX_G.Id_Garantia = AUX_G_1.Id_Garantia
			AND AUX_G.Id_Operacion = AUX_G_1.Id_Operacion
			AND AUX_G.Id_Tipo_Garantia = AUX_G_1.Id_Tipo_Garantia
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_D_2 AUX_O
			ON AUX_O.Id_Operacion = AUX_G.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D_5_01 ON dbo.AUX_PCJ_GARANTIAS_D_5
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--9
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_D_6') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_D_6


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_D_6
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Saldo_Colonizado DECIMAL(22,2),
		Monto DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_D_6(
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
			dbo.AUX_PCJ_GARANTIAS_D_5 AUX_P
		INNER JOIN dbo.OPERACIONES OPER
			ON OPER.Id_Operacion = AUX_P.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TP
			ON TP.Id_Tipo_Operacion = OPER.Id_Tipo_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_D_6_01 ON dbo.AUX_PCJ_GARANTIAS_D_6
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--10
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_D_3') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_D_3


		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_D_3
		(Id_Operacion INT,
		Monto DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_D_3(Id_Operacion, Monto)
		SELECT 
			Id_Operacion,
			SUM(Monto) Monto
		FROM 
			dbo.AUX_PCJ_GARANTIAS_D_6
		GROUP BY
			Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_D_3_01 ON dbo.AUX_PCJ_OPERACIONES_D_3
		(Id_Operacion ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		--11 12 13

		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF =	
			CASE WHEN AUX_O.Monto <> 0 THEN 
						CASE WHEN ((AUX_G.Monto / AUX_O.Monto) * 100) > 100 
														THEN 100 
														WHEN ((AUX_G.Monto / AUX_O.Monto) * 100) < 0
														THEN 0
													ELSE ((AUX_G.Monto / AUX_O.Monto) * 100)
													END
				ELSE 0
			END
		FROM 
			dbo.AUX_PCJ_OPERACIONES_D_3 AUX_O
		INNER JOIN AUX_PCJ_GARANTIAS_D_6 AUX_G
			ON AUX_O.Id_Operacion = AUX_G.Id_Operacion
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON GAROPER.Id_Operacion = AUX_G.Id_Operacion
			AND ISNULL(GAROPER.Id_Garantia_Real,GAROPER.Id_Garantia_Valor) = AUX_G.Id_Garantia
			AND GAROPER.Id_Tipo_Garantia = AUX_G.Id_Tipo_Garantia
		WHERE GAROPER.Ind_Estado_Registro = 1

--Fin Escenario D
		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END


GO


