USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Porcentaje_Responsabilidad_Escenario_A', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Porcentaje_Responsabilidad_Escenario_A;
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
		<Autor>Mauricio Castro</Autor>
		<Requerimiento>RQ_MANT_2016022310547701_Backlog_870 SIGANEM- Porcentaje de Responsabilidad SUGEF con Fideicomisos y Avales</Requerimiento>
		<Fecha>Julio 2016</Fecha>
		<Descripción>Se incluyen dentro del cálculo las garantías de tipo Fideicomiso y Aval</Descripción>
	</Cambio>
	<Cambio>
		<Autor>Arnoldo Martinelli M.</Autor>
		<Requerimiento>Modificación en el Mantenimiento de Garantías Reales (PBI 10800)</Requerimiento>
		<Fecha>Septiembre 2016</Fecha>
		<Descripción>Se ajusta el proceso de cálculo establecido</Descripción>
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

		--Escenario A

		--Obtener Relación Operación Garantía 1 <-> 1

		--Garantías Fiduciarias, Garantías Valores, Reales, Avales y Fideicomisos

		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_A') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_A

		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_A
			(Id_Garantia INT,
			Id_Tipo_Garantia INT)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_A (Id_Garantia, Id_Tipo_Garantia)
		
		SELECT 
			GAROPER.Id_Garantia_Fiduciaria,
			GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.GARANTIAS_FIDUCIARIAS GAF
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON GAF.Id_Garantia_Fiduciaria = GAROPER.Id_Garantia_Fiduciaria
		WHERE 
			GAF.Ind_Estado_Registro = 1 
		AND GAROPER.Ind_Estado_Registro = 1
		GROUP BY 
			GAROPER.Id_Operacion,
			GAROPER.Id_Garantia_Fiduciaria,
			GAROPER.Id_Tipo_Garantia
		HAVING COUNT(1) = 1

		UNION 

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
			GAROPER.Id_Operacion,
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
			GAROPER.Id_Operacion,
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
			FID.Ind_Estado_Registro =  1
		AND GAROPER.Ind_Estado_Registro = 1
		GROUP BY 
			GAROPER.Id_Operacion,
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
			GARAV.Ind_Estado_Registro =  1
		AND GAROPER.Ind_Estado_Registro = 1
		GROUP BY 
			GAROPER.Id_Operacion,
			GARAV.Id_Garantia_Aval, 
			GAROPER.Id_Tipo_Garantia
		HAVING COUNT(1) = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_A_01 ON dbo.AUX_PCJ_GARANTIAS_A
			(Id_Garantia ASC,
			Id_Tipo_Garantia ASC) 

		--Operaciones
		IF(OBJECT_ID('dbo.AUX_PCJ_OPERACIONES_A') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_OPERACIONES_A

		CREATE TABLE dbo.AUX_PCJ_OPERACIONES_A
		(Id_Operacion INT)

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
		--HAVING COUNT(1) = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_A_01 ON dbo.AUX_PCJ_OPERACIONES_A
		(Id_Operacion ASC) 

		--2
		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF = 100
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_A OPER
			ON OPER.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_A AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Fiduciaria, GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
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

