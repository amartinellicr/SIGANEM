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

		--Garantia Fiduciaria

		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF = 100
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_FIDUCIARIAS GAF
			ON GAF.Id_Garantia_Fiduciaria = GAROPER.Id_Garantia_Fiduciaria
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		
		--Obtener Relación Operación Garantía 1 <-> 1

		--Garantías Valores, Reales, Avales y Fideicomisos

		--1
		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_A') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_A

		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_A
			(Id_Garantia INT,
			Id_Tipo_Garantia INT)

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
		

		CREATE NONCLUSTERED INDEX AUX_PCJ_OPERACIONES_A_01 ON dbo.AUX_PCJ_OPERACIONES_A
		(Id_Operacion ASC) 


		IF(OBJECT_ID('dbo.AUX_PCJ_GARANTIAS_A_1') IS NOT NULL)
			DROP TABLE dbo.AUX_PCJ_GARANTIAS_A_1


		CREATE TABLE dbo.AUX_PCJ_GARANTIAS_A_1
		(Id_Operacion INT,
		Id_Garantia INT,
		Id_Tipo_Garantia INT
		)

		INSERT INTO dbo.AUX_PCJ_GARANTIAS_A_1 (Id_Operacion,Id_Garantia, Id_Tipo_Garantia)
		SELECT 
			GAROPER.Id_Operacion,
			AUX_V.Id_Garantia,
			GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_A  AUX_O
			ON AUX_O.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_A AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		INNER JOIN dbo.TIPOS_GARANTIAS TP
			ON TP.Id_Tipo_Garantia = AUX_V.Id_Tipo_Garantia
		LEFT JOIN dbo.GARANTIAS_FIDUCIARIAS GFI
			ON GFI.Id_Garantia_Fiduciaria = GAROPER.Id_Garantia_Fiduciaria
		LEFT JOIN dbo.GARANTIAS_REALES GAR
			ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
		LEFT JOIN dbo.FIDEICOMISOS FID
			ON FID.Id_Fideicomiso = GAROPER.Id_Fideicomiso
		LEFT JOIN dbo.GARANTIAS_VALORES GAV
			ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
		LEFT JOIN dbo.GARANTIAS_AVALES GAVA
			ON GAVA.Id_Garantia_Aval = GAROPER.Id_Garantia_Aval
		
		WHERE 
			GAROPER.Ind_Estado_Registro = 1

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_A_1_01 ON dbo.AUX_PCJ_GARANTIAS_A_1
		(Id_Operacion ASC,
		Id_Garantia ASC,
		Id_Tipo_Garantia ASC)

		CREATE NONCLUSTERED INDEX AUX_PCJ_GARANTIAS_A_1_02 ON dbo.AUX_PCJ_GARANTIAS_A_1
		(Id_Operacion ASC)

		DELETE FROM dbo.AUX_PCJ_GARANTIAS_A_1
		FROM dbo.AUX_PCJ_GARANTIAS_A_1 PGA
		INNER JOIN (SELECT	Id_Garantia, Id_Tipo_Garantia
					FROM	dbo.AUX_PCJ_GARANTIAS_A_1
					GROUP BY Id_Garantia, Id_Tipo_Garantia
					HAVING COUNT(*) > 1) TMP
		ON TMP.Id_Garantia = PGA.Id_Garantia
		AND TMP.Id_Tipo_Garantia = PGA.Id_Tipo_Garantia

		--2
		UPDATE GAROPER
			SET Porcentaje_Responsabilidad_SUGEF = 100
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_A_1 PGA
			ON PGA.Id_Operacion = GAROPER.Id_Operacion
			AND PGA.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND PGA.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
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

