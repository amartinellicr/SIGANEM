/*COLONIZACIÓN DE PRIORIDADES*/

--DECLARE @VALOR DECIMAL(6,2) 
--SELECT TOP 1 @VALOR = Valor 
--FROM	dbo.TIPOS_CAMBIOS
--ORDER BY Fecha DESC

--SELECT @VALOR AS 'TIPO DE CAMBIO'

--SELECT COUNT(*) AS 'CANTIDAD DE REGISTROS'
--FROM dbo.FIDEICOMISOS A
--INNER JOIN dbo.PRIORIDADES_FIDEICOMISOS B
--ON B.Id_Fideicomiso = A.Id_Fideicomiso
--AND B.Ind_Estado_Registro = 1
--INNER JOIN dbo.GRADOS_PRIORIDADES C
--ON C.Id_Grado_Prioridad = B.Id_Grado_Prioridad
--AND C.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND C.Id_Tipo_Moneda = 2
--AND C.Saldo_Prioridad_Colonizado <> (C.Saldo_Prioridad * @VALOR)



/*COLONIZACIÓN DE VALOR MERCADO - GARANTÍAS VALORES*/


--DECLARE @VALOR DECIMAL(6,2) 
--SELECT TOP 1 @VALOR = Valor 
--FROM	dbo.TIPOS_CAMBIOS
--ORDER BY Fecha DESC

--SELECT @VALOR AS 'TIPO DE CAMBIO'

--SELECT COUNT(*) AS 'CANTIDAD_REGISTROS'
--FROM dbo.FIDEICOMISOS A
--INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS B
--ON B.Id_Fideicomiso = A.Id_Fideicomiso
--AND B.Ind_Estado_Registro = 1
--INNER JOIN dbo.GARANTIAS_VALORES C
--ON C.Id_Garantia_Valor = B.Id_Garantia_Valor
--AND C.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND B.Id_Garantia_Valor IS NOT NULL
--AND C.Id_Moneda_Valor_Mercado = 2
--AND C.Monto_Valor_Mercado_Colonizado <> (C.Monto_Valor_Mercado * @VALOR)


/*CALCULO VALOR NOMINAL - GARANTÍAS REALES FIDEICOMETIDAS*/


--SELECT A.Id_Fideicomiso_BCR, C.Id_Tipo_Bien, C.Id_Provincia, C.Codigo_Bien, B.Valor_Nominal
--FROM dbo.FIDEICOMISOS A
--INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS B
--ON B.Id_Fideicomiso = A.Id_Fideicomiso
--AND B.Ind_Estado_Registro = 1
--INNER JOIN dbo.GARANTIAS_REALES C
--ON C.Id_Garantia_Real = B.Id_Garantia_Real
--AND C.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND B.Id_Garantia_Real IS NOT NULL
--AND A.Id_Fideicomiso_BCR = 'BCR02052016004'
--AND C.Codigo_Bien = '000394'
--IN ('BCR04132016043', 'BCR04152016038', 'BCR02052016004')
--AND C.Codigo_Bien IN ('000400', '201516', '000394')



/*CALCULO VALOR NOMINAL - GARANTÍAS VALORES FIDEICOMETIDAS*/


--SELECT A.Id_Fideicomiso_BCR, C.Cod_Garantia_BCR, B.Valor_Nominal
--FROM dbo.FIDEICOMISOS A
--INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS B
--ON B.Id_Fideicomiso = A.Id_Fideicomiso
--AND B.Ind_Estado_Registro = 1
--INNER JOIN dbo.GARANTIAS_VALORES C
--ON C.Id_Garantia_Valor = B.Id_Garantia_Valor
--AND C.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND B.Id_Garantia_Valor IS NOT NULL
--AND A.Id_Fideicomiso_BCR = 'BCR04072016005'






/*CALCULO VALOR NOMINAL - FIDEICOMISOS*/


--SELECT A.Id_Fideicomiso_BCR, 
--CASE 
--WHEN B.Id_Garantia_Real IS NOT NULL THEN C.Codigo_Bien
--WHEN B.Id_Garantia_Valor IS NOT NULL THEN D.Cod_Garantia_BCR
--END AS 'ID GARANTIA', 
--A.Valor_Nominal
--FROM dbo.FIDEICOMISOS A
--INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS B
--ON B.Id_Fideicomiso = A.Id_Fideicomiso
--AND B.Ind_Estado_Registro = 1
--LEFT JOIN dbo.GARANTIAS_REALES C
--ON C.Id_Garantia_Real = B.Id_Garantia_Real
--AND C.Ind_Estado_Registro = 1
--LEFT JOIN dbo.GARANTIAS_VALORES D
--ON D.Id_Garantia_Valor = B.Id_Garantia_Valor
--AND D.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND A.Id_Fideicomiso_BCR = 'BCR04072016005'
--AND C.Codigo_Bien = '000400'
--IN ('BCR04132016043', 'BCR04152016038', 'BCR02052016004')
--AND C.Codigo_Bien IN ('000400', '201516', '000394')



/*CALCULO PORCENTAJE ACEPTACION TERRENO SUGEF - TIPO BIEN 1*/

SELECT B.Id_Garantia_Fideicomiso, A.Id_Fideicomiso_BCR, A.Id_Fideicomiso, C.Id_Garantia_Real, C.Codigo_Bien, B.Porcentaje_Aceptacion_Terreno_SUGEF
FROM dbo.FIDEICOMISOS A
INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS B
ON B.Id_Fideicomiso = A.Id_Fideicomiso
AND B.Ind_Estado_Registro = 1
INNER JOIN dbo.GARANTIAS_REALES C
ON C.Id_Garantia_Real = B.Id_Garantia_Real
AND C.Ind_Estado_Registro = 1
INNER JOIN dbo.TIPOS_BIENES E
ON E.Id_Tipo_Bien = C.Id_Tipo_Bien
AND E.Ind_Estado_Registro = 1
INNER JOIN dbo.TIPOS_INDICADORES_INSCRIPCIONES F
ON F.Id_Tipo_Indicador_Inscripcion = B.Id_Tipo_Indicador_Inscripcion
AND F.Ind_Estado_Registro = 1
WHERE A.Ind_Estado_Registro = 1
AND C.Monto_Ultima_Tasacion_No_Terreno IS NULL
AND E.Cod_Tipo_Bien = 1
AND F.Cod_Tipo_Indicador_Inscripcion = 3
--AND B.Fecha_Presentacion IS NULL
--AND A.Id_Fideicomiso_BCR = 'BCR04072016005'


SELECT *
FROM dbo.GARANTIAS_REALES C
INNER JOIN dbo.TIPOS_BIENES E
ON E.Id_Tipo_Bien = C.Id_Tipo_Bien
AND E.Ind_Estado_Registro = 1
WHERE C.Ind_Estado_Registro = 1
AND E.Cod_Tipo_Bien = 1

SELECT *
FROM dbo.FIDEICOMISOS A
LEFT JOIN dbo.GARANTIAS_FIDEICOMETIDAS B
ON B.Id_Fideicomiso = A.Id_Fideicomiso
AND B.Ind_Estado_Registro = 1
WHERE A.Ind_Estado_Registro = 1
AND B.Id_Fideicomiso IS NULL

/*

UPDATE dbo.GARANTIAS_FIDEICOMETIDAS
SET Id_Tipo_Indicador_Inscripcion = 3 
--Fecha_Presentacion = '20160701'
WHERE Id_Garantia_Fideicomiso IN (139, 391)

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20150720'
WHERE Id_Fideicomiso IN (619, 938)

*/