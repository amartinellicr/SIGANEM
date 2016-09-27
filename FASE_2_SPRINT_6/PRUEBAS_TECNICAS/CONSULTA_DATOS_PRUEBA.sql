USE [SIGANEM]
GO

SELECT DISTINCT 
A.Id_Garantia_Operacion
,(CAST(B.Oficina AS VARCHAR) + '-' + CAST(B.Moneda AS VARCHAR) + '-' + CASE WHEN B.Id_Tipo_Operacion = 1 THEN CAST(B.Prod AS VARCHAR) + '-' ELSE '' END + CAST(B.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS'
, B.Numero_Operacion
, C.Codigo_Bien
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
LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES D
ON D.Id_Garantia_Operacion = A.Id_Garantia_Operacion
AND D.Ind_Estado_Registro = 1
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
AND B.Numero_Operacion IN ('0134101020005708', '0134501020001405')
AND D.Id_Garantia_Operacion IS NOT NULL
--AND D.Fecha_Anotacion IS NOT NULL
--AND D.Fecha_Inscripcion IS NULL
--AND DATEADD(MM, 1, C.Fecha_Ultimo_Seguimiento_Garantia) < GETDATE()
AND DATEADD(MM, 13, C.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
--AND DATEADD(DD, 30, A.Fecha_Constitucion_Garantia) > GETDATE()
AND C.Id_Tipo_Bien = 2
--AND D.Cod_Usuario_Ultima_Modificacion IS NULL


/*
SELECT * FROM dbo.PARAMETROS_BIENES WHERE Id_Parametro_Bien = 1

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200, --200
    Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 1 --13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_OPERACIONES
SET Fecha_Constitucion_Garantia = '20160920'
WHERE Id_Garantia_Operacion IN (46508, 60305)

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



*/