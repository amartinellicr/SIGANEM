USE [SIGANEM]
GO

/****** Object:  StoredProcedure [dbo].[Calculo_Porcentaje_Responsabilidad_Escenario_B]    Script Date: 10/08/2016 11:36:32 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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

		--Garantias Valores y Reales
		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_B') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_B

		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_B
			(Id_Garantia INT,
			Id_Tipo_Garantia INT)
		--WITH(DATA_COMPRESSION = PAGE)

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


		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_B_01 ON dbo.AUX_PCJ_GARANTIAS_B
			(Id_Garantia ASC,
			Id_Tipo_Garantia ASC) 
		--WITH(DATA_COMPRESSION = PAGE)

		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_B') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_B

		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_B
		(Id_Operacion INT)
		--WITH(DATA_COMPRESSION = PAGE)

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
		HAVING COUNT(1) = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_B_01 ON dbo.AUX_PCJ_OPERACIONES_B
		(Id_Operacion ASC) 
		--WITH(DATA_COMPRESSION = PAGE)

		--2
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_B_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_B_1

		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_B_1
		(Id_Garantia INT,
		Id_Tipo_Garantia INT,
		Saldo_Colonizado DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_B_1 (Id_Garantia, Id_Tipo_Garantia, Saldo_Colonizado)
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
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_B  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_B AUX_V
			ON AUX_V.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Real,GAROPER.Id_Garantia_Valor)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1
		GROUP BY AUX_V.Id_Garantia,
			GAROPER.Id_Tipo_Garantia

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_B_1_01 ON dbo.AUX_PCJ_GARANTIAS_B_1
		(Id_Garantia ASC,
		Id_Tipo_Garantia ASC)
		--WITH(DATA_COMPRESSION = PAGE)


		--3 4 5 6
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_B_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_B_1

		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_B_1
		(Id_Operacion INT,
		Saldo_Colonizado DECIMAL(22,2)
		)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_B_1 (Id_Operacion, Saldo_Colonizado)
		SELECT 
			GAROPER.Id_Operacion,
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
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_B  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_B AUX_V
			ON AUX_V.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Valor,GAROPER.Id_Garantia_Real)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1
		GROUP BY GAROPER.Id_Operacion

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_B_1_01 ON dbo.AUX_PCJ_OPERACIONES_B_1
		(Id_Operacion ASC)
		--WITH(DATA_COMPRESSION = PAGE)

		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF = CASE WHEN AUX_V.Saldo_Colonizado <> 0 THEN 
															CASE WHEN ROUND((AUX_O.Saldo_Colonizado / AUX_V.Saldo_Colonizado) * 100,2) > 100 
															THEN 100 
															WHEN ROUND((AUX_O.Saldo_Colonizado / AUX_V.Saldo_Colonizado) * 100,2) < 0
															THEN 0
															ELSE ROUND((AUX_O.Saldo_Colonizado / AUX_V.Saldo_Colonizado) * 100,2)
														END
													ELSE 0
													END
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_B_1 AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_B_1 AUX_V
			ON AUX_V.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Valor,GAROPER.Id_Garantia_Real)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
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


