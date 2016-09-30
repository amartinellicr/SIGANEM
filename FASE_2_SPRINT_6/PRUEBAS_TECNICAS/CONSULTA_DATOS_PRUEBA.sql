USE [SIGANEM]
GO

SELECT DISTINCT 
A.Id_Garantia_Operacion
,(CAST(B.Oficina AS VARCHAR) + '-' + CAST(B.Moneda AS VARCHAR) + '-' + CASE WHEN B.Id_Tipo_Operacion = 1 THEN CAST(B.Prod AS VARCHAR) + '-' ELSE '' END + CAST(B.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS'
, C.Codigo_Bien
, B.Numero_Operacion
, A.Fecha_Constitucion_Garantia
, C.Id_Tipo_Bien, C.Id_Clase_Tipo_Bien, C.Id_Provincia, C.Id_Codigo_Horizontalidad, C.Id_Codigo_Duplicado, C.Id_Clase_Aeronave, C.Id_Clase_Buque, C.Id_Clase_Vehiculo
--, B.*
FROM dbo.GARANTIAS_OPERACIONES A
INNER JOIN dbo.OPERACIONES B
ON B.Id_Operacion = A.Id_Operacion
AND B.Ind_Estado_Registro = 1
INNER JOIN dbo.GARANTIAS_REALES C
ON C.Id_Garantia_Real = A.Id_Garantia_Real
AND C.Ind_Estado_Registro = 1
AND C.Estado_Registro_Garantia = 1
--LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES D
--ON D.Id_Garantia_Operacion = A.Id_Garantia_Operacion
--AND D.Ind_Estado_Registro = 1

INNER JOIN dbo.prmoc_SICC E
ON E.prmoc_pco_conta = B.Conta
AND E.prmoc_pco_ofici = B.Oficina
AND E.prmoc_pco_moned = B.Moneda
AND E.prmoc_pco_produ = B.Prod
AND E.prmoc_pnu_oper = B.Numero
AND E.prmoc_estado = 'A'
AND E.prmoc_pnu_contr = 0
/*
INNER JOIN dbo.prmca_SICC E
ON E.prmca_pco_conta = B.Conta
AND E.prmca_pco_ofici = B.Oficina
AND E.prmca_pco_moned = B.Moneda
AND E.prmca_pco_produc = B.Prod
AND E.prmca_pnu_contr = B.Numero
AND E.prmca_estado = 'A'
*/
WHERE A.Ind_Estado_Registro = 1
--AND B.Numero_Operacion IN ('0134101020005708', '0134501020001405')
--AND D.Id_Garantia_Operacion IS NOT NULL
--AND D.Fecha_Anotacion IS NOT NULL
--AND D.Fecha_Inscripcion IS NULL
--AND DATEADD(MM, 1, C.Fecha_Ultimo_Seguimiento_Garantia) < GETDATE()
--AND DATEADD(MM, 13, C.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
--AND DATEADD(DD, 30, A.Fecha_Constitucion_Garantia) > GETDATE()
AND C.Id_Tipo_Bien = 2
AND C.Id_Clase_Tipo_Bien = 5
AND B.Categoria_Riesgo_Deudor IN ('C2', 'D', 'E')
--AND B.Categoria_Riesgo_Deudor IN ('A1', 'A2', 'B1', 'B2', 'C1')
--AND D.Cod_Usuario_Ultima_Modificacion IS NULL


/*
SELECT * FROM dbo.PARAMETROS_BIENES WHERE Id_Parametro_Bien = 1

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200, --200
    Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 1 --13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_OPERACIONES
SET Fecha_Constitucion_Garantia = '20160921'
WHERE Id_Garantia_Operacion IN (46508, 60305)

SELECT *
FROM dbo.GARANTIAS_OPERACIONES
WHERE Id_Garantia_Operacion = 1396


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultima_Tasacion_Garantia = '20160615',
Fecha_Ultimo_Seguimiento_Garantia = '20160615'
WHERE Id_Garantia_Real = 16420


SELECT *
--UPDATE A
--SET Ind_Estado_Registro = 0
FROM dbo.GARANTIAS_REALES_INSCRIPCIONES A
INNER JOIN dbo.GARANTIAS_OPERACIONES B
ON B.Id_Garantia_Operacion = A.Id_Garantia_Operacion
--AND B.Ind_Estado_Registro = 1
INNER JOIN dbo.OPERACIONES C
ON C.Id_Operacion = B.Id_Operacion
--AND C.Ind_Estado_Registro = 1
WHERE /*C.Numero_Operacion = '0100102029001726' 
AND */A.Id_Garantia_Operacion = 1352--<> 5524-- IN (1352, 5524)
*/

/*SELECT Codigo_Bien, Id_Clase_Tipo_Bien, Id_Provincia, Id_Codigo_Horizontalidad, Id_Codigo_Duplicado, Monto_Ultima_Tasacion_No_Terreno, Monto_Tasacion_Actualizada_No_Terreno
FROM dbo.GARANTIAS_REALES
WHERE Codigo_Bien = '456321'
AND Ind_Estado_Registro = 1

SELECT *
FROM dbo.AUX_ACTUALIZAGARANTIAS
WHERE Codigo_Bien = '112289'

SELECT *
FROM dbo.GARANTIAS_REALES
WHERE Codigo_Bien = '112289'
AND Ind_Estado_Registro = 1
AND Estado_Registro_Garantia = 1

SELECT *
FROM dbo.AUX_GAR_MTO_ACT_NO_TERRENO
WHERE Id_Garantia_Real = 50026


--DELETE FROM dbo.AUX_ACTUALIZAGARANTIAS
--WHERE Codigo_Bien = '112289'



SELECT DATEDIFF(YEAR,('19760101'),CONVERT(DATE,GETDATE()))
SELECT cast(DATEDIFF(MONTH,('19760101'),CONVERT(DATE,GETDATE()))/12 as decimal(12,2))
SELECT DATEDIFF(DAY,('19760101'),CONVERT(DATE,GETDATE()))

Select Cast((DATEDIFF(day,'19760101' , GetDate())/365.25) as decimal(12,2))

declare 
       @fechaconstruccion datetime = '19760101',
       @fechacalculo datetime = '20160919'

select 
       CASE WHEN (DATEDIFF(MONTH,@fechaconstruccion,CONVERT(DATE,@fechacalculo)))<>480 
                     THEN DATEDIFF(MONTH,@fechaconstruccion,CONVERT(DATE,@fechacalculo))/12.00
              WHEN (DATEDIFF(MONTH,@fechaconstruccion,CONVERT(DATE,@fechacalculo)))=480 AND DAY(@fechaconstruccion) < DAY(CONVERT(DATE,@fechacalculo))
                     THEN DATEDIFF(DAY,@fechaconstruccion,CONVERT(DATE,@fechacalculo))/30.00/12.00
              WHEN (DATEDIFF(MONTH,@fechaconstruccion,CONVERT(DATE,@fechacalculo)))=480
                     THEN DATEDIFF(MONTH,@fechaconstruccion,CONVERT(DATE,@fechacalculo))/12.00
       END




SELECT *
FROM dbo.GARANTIAS_REALES_POLIZAS
WHERE Ind_Estado_Registro = 1


USE [SIGANEM]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Calculo_Monto_Tasacion_Actualizada_Terreno]

SELECT	'Return Value' = @return_value


EXEC	@return_value = [dbo].[Calculo_Monto_Tasacion_Actualizada_No_Terreno]

SELECT	'Return Value' = @return_value



UPDATE dbo.GARANTIAS_REALES_INSCRIPCIONES
SET Fecha_Anotacion = NULL,
	Fecha_Inscripcion = NULL,
	Folio = NULL,
	Tomo = NULL,
	Asiento = NULL,
	Secuencia = NULL,
	Subsecuencia = NULL,
	Consecutivo = NULL,
	Id_Tipo_Indicador_Inscripcion = 4
WHERE Id_Garantia_Operacion IN (1299, 46508)


SELECT *
FROM dbo.TIPOS_INDICADORES_INSCRIPCIONES

SELECT *
FROM dbo.GARANTIAS_REALES_INSCRIPCIONES
WHERE Id_Garantia_Operacion IN (1299, 46508)

UPDATE dbo.OPERACIONES
SET Estado_Registro_Operacion = 1
WHERE Id_Operacion IN (1247, 41378)


SELECT *
FROM dbo.GARANTIAS_OPERACIONES
WHERE Id_Garantia_Operacion IN (1299, 44553)


DELETE FROM dbo.GARANTIAS_REALES_INSCRIPCIONES
WHERE Id_Garantia_Operacion = 1281

DELETE FROM dbo.GARANTIAS_OPERACIONES
WHERE Id_Garantia_Operacion = 1281

DELETE FROM dbo.OPERACIONES
WHERE Id_Operacion = 1228

--DBCC OPENTRAN
*/

/*

SELECT * FROM dbo.TIPOS_GARANTIAS

SELECT A.*
FROM dbo.GARANTIAS_REALES_INSCRIPCIONES A
INNER JOIN dbo.GARANTIAS_OPERACIONES B
ON B.Id_Garantia_Operacion = A.Id_Garantia_Operacion
INNER JOIN dbo.OPERACIONES C
ON C.Id_Operacion = B.Id_Operacion
WHERE --A.Id_Garantia_Operacion IN (5524, 44553)
B.Id_Operacion = 41378 -- IN (1243, 41378)
--AND B.Id_Tipo_Garantia = 3

SELECT *
FROM dbo.OPERACIONES
WHERE Numero_Operacion = '0194302025952931'

SELECT *
FROM dbo.GARANTIAS_OPERACIONES
WHERE Id_Operacion = 41378






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
			--GAROPER.Id_Operacion,
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
			--GAROPER.Id_Operacion,
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
			--GAROPER.Id_Operacion,
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
			--GAROPER.Id_Operacion,
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
			--GAROPER.Id_Operacion,
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
		SELECT B.Numero_Operacion,
				(CAST(B.Oficina AS VARCHAR) + '-' + CAST(B.Moneda AS VARCHAR) + '-' + CASE WHEN B.Id_Tipo_Operacion = 1 THEN CAST(B.Prod AS VARCHAR) + '-' ELSE '' END + CAST(B.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS'
				,CASE 
					WHEN GAROPER.Id_Garantia_Aval IS NOT NULL THEN C.Cod_Garantia_BCR
					WHEN GAROPER.Id_Garantia_Fiduciaria IS NOT NULL THEN D.Cod_Garantia
					WHEN GAROPER.Id_Garantia_Real IS NOT NULL THEN H.Codigo_Bien
					WHEN GAROPER.Id_Garantia_Valor IS NOT NULL THEN F.Cod_Garantia_BCR
					WHEN GAROPER.Id_Fideicomiso IS NOT NULL THEN G.Id_Fideicomiso_BCR
					ELSE '-'
				END AS COD_GARANTIA,
			  GAROPER.Id_Tipo_Garantia
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.AUX_PCJ_OPERACIONES_A OPER
			ON OPER.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.AUX_PCJ_GARANTIAS_A AUX_V
			ON AUX_V.Id_Garantia = COALESCE(GAROPER.Id_Garantia_Fiduciaria, GAROPER.Id_Garantia_Valor, GAROPER.Id_Garantia_Real, GAROPER.Id_Fideicomiso, GAROPER.Id_Garantia_Aval)
			AND AUX_V.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
		INNER JOIN dbo.OPERACIONES B
			ON B.Id_Operacion = GAROPER.Id_Operacion
			AND B.Ind_Estado_Registro = 1
		INNER JOIN dbo.prmoc_SICC E
			ON E.prmoc_pco_conta = B.Conta
			AND E.prmoc_pco_ofici = B.Oficina
			AND E.prmoc_pco_moned = B.Moneda
			AND E.prmoc_pco_produ = B.Prod
			AND E.prmoc_pnu_oper = B.Numero
			AND E.prmoc_estado = 'A'
			AND E.prmoc_pnu_contr = 0
			/*
			INNER JOIN dbo.prmca_SICC E
			ON E.prmca_pco_conta = B.Conta
			AND E.prmca_pco_ofici = B.Oficina
			AND E.prmca_pco_moned = B.Moneda
			AND E.prmca_pco_produc = B.Prod
			AND E.prmca_pnu_contr = B.Numero
			AND E.prmca_estado = 'A'
			*/
		LEFT JOIN dbo.GARANTIAS_AVALES C
			ON C.Id_Garantia_Aval = GAROPER.Id_Garantia_Aval
			AND C.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_FIDUCIARIAS D
			ON D.Id_Garantia_Fiduciaria = GAROPER.Id_Garantia_Fiduciaria
			AND D.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES H
			ON H.Id_Garantia_Real = GAROPER.Id_Garantia_Real
			AND H.Ind_Estado_Registro = 1
			AND H.Estado_Registro_Garantia = 1
		LEFT JOIN dbo.GARANTIAS_VALORES F
			ON F.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
			AND F.Ind_Estado_Registro = 1
		LEFT JOIN dbo.FIDEICOMISOS G
			ON G.Id_Fideicomiso = GAROPER.Id_Fideicomiso
			AND G.Ind_Estado_Registro = 1
		WHERE 
			GAROPER.Ind_Estado_Registro = 1
		ORDER BY GAROPER.Id_Operacion
	

*/

/*
SELECT *
FROM dbo.GARANTIAS_FIDEICOMETIDAS A
INNER JOIN dbo.FIDEICOMISOS B
ON B.Id_Fideicomiso = A.Id_Fideicomiso
AND B.Ind_Estado_Registro = 1
WHERE B.Id_Fideicomiso_BCR IN('BCR04042016021')

/*

UPDATE dbo.GARANTIAS_FIDEICOMETIDAS
SET Id_Tipo_Indicador_Inscripcion = 3
WHERE Id_Fideicomiso = 113

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160925',
	Fecha_Vencimiento = '20171025'
WHERE Id_Fideicomiso = 113

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160920',
	Fecha_Vencimiento = '20171020'
WHERE Id_Fideicomiso = 91




SELECT * FROM dbo.PARAMETROS_BIENES WHERE Id_Parametro_Bien = 1

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200, --200
    Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13 --13
WHERE Id_Parametro_Bien = 1
*/

*/