USE [SIGANEM]
GO

/****** Object:  StoredProcedure [dbo].[Calculo_Porcentaje_Responsabilidad_Escenario_A]    Script Date: 10/08/2016 11:36:06 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Calculo_Porcentaje_Responsabilidad_Escenario_A]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Porcentaje_Responsabilidad_Escenario_A</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo del porcentaje de responsabilidad para las garantias fiduciarias, para las garantias reales 
	y valores que solo tienen una relacion
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

		--Garantia Fiduciaria

		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF = 100
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_FIDUCIARIAS GAF
			ON GAF.Id_Garantia_Fiduciaria = GAROPER.Id_Garantia_Fiduciaria
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		--Escenario A

		--Obtener Relacion Operacion Garantia 1 <-> 1

		--Garantias Valores y Reales

		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_A') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_A

		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_A
			(Id_Garantia INT,
			Id_Tipo_Garantia INT)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_A (Id_Garantia, Id_Tipo_Garantia)
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

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_A_01 ON dbo.AUX_PCJ_GARANTIAS_A
			(Id_Garantia ASC,
			Id_Tipo_Garantia ASC) 
		--WITH(DATA_COMPRESSION = PAGE)

		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_A') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_A

		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_A
		(Id_Operacion INT)
		--WITH(DATA_COMPRESSION = PAGE)

		INSERT INTO dbo.AUX_PCJ_OPERACIONES_A (Id_Operacion)
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

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_A_01 ON dbo.AUX_PCJ_OPERACIONES_A
		(Id_Operacion ASC) 
		--WITH(DATA_COMPRESSION = PAGE)

		--2
		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF = 100
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_A OPER
			ON OPER.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_A AUX_V
			ON AUX_V.Id_Garantia = ISNULL(GAROPER.Id_Garantia_Real,GAROPER.Id_Garantia_Valor)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		--Fin Escenario A
		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END


GO


