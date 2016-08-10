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

/*
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
--AND C.Monto_Ultima_Tasacion_No_Terreno IS NULL
--AND E.Cod_Tipo_Bien = 1
--AND F.Cod_Tipo_Indicador_Inscripcion = 0
--AND B.Fecha_Presentacion IS NULL
AND A.Id_Fideicomiso_BCR = 'BCR03312016010'



SELECT *
FROM dbo.FIDEICOMISOS
WHERE Id_Fideicomiso_BCR = 'BCR13052016006'
AND Ind_Estado_Registro = 1



SELECT C.*
FROM dbo.GARANTIAS_VALORES C
LEFT JOIN dbo.GARANTIAS_FIDEICOMETIDAS D
ON D.Id_Garantia_Valor = C.Id_Garantia_Valor
AND D.Ind_Estado_Registro = 1
WHERE C.Ind_Estado_Registro = 1
AND C.Estado_Registro_Garantia = 1
AND D.Id_Garantia_Fideicomiso IS NULL
AND D.Id_Garantia_Valor IS NULL
AND D.Id_Garantia_Real IS NULL

*/

--DECLARE @VALOR DECIMAL(6,2)
--	SELECT 
--		top 1 @VALOR = Valor 
--	FROM 
--		dbo.TIPOS_CAMBIOS TC
--	ORDER BY 
--		Fecha desc

--SELECT 
	
--	GARFID.Id_Garantia_Fideicomiso,
--	A.Id_Fideicomiso_BCR,
--	@VALOR,
--	TM.Cod_Tipo_Moneda,
--	GAV.Monto_Valor_Mercado,
--	GARFID.Porcentaje_Aceptacion_SUGEF,
--	Monto_Mitigador_Calculado = CASE 
--										WHEN (((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)  IS NULL
--										THEN NULL
--										WHEN (((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)  < 0
--										THEN 0
--										ELSE (((CASE TM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END * GAV.Monto_Valor_Mercado) * GARFID.Porcentaje_Aceptacion_SUGEF) / 100)
--								END
--FROM	dbo.GARANTIAS_FIDEICOMETIDAS GARFID
--INNER JOIN dbo.GARANTIAS_VALORES GAV
--	ON GAV.Id_Garantia_Valor = GARFID.Id_Garantia_Valor
--	AND GAV.Ind_Estado_Registro = 1
--INNER JOIN dbo.FIDEICOMISOS A
--ON A.Id_Fideicomiso = GARFID.Id_Fideicomiso
--AND A.Ind_Estado_Registro = 1
--LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TMR
--	ON TMR.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
--	AND TMR.Ind_Estado_Registro = 1
--LEFT JOIN dbo.TIPOS_MONEDAS TM
--	ON TM.Id_Tipo_Moneda = GAV.Id_Moneda_Valor_Mercado
--WHERE 
--	GARFID.Ind_Estado_Registro = 1
--AND TMR.Cod_Tipo_Mitigador_Riesgo = 0 --in (0, 11, 13,14,15)


/*
SELECT H.Id_Fideicomiso, H.Id_Fideicomiso_BCR, C.Codigo_Bien, C.Id_Garantia_Real, C.Codigo_Bien, 
G.Id_Tipo_Moneda_Monto_Gravamen, G.Saldo_Grado_Gravamen, G.Saldo_Grado_Gravamen_Colonizado,
C.Monto_Tasacion_Actualizada_Terreno, D.Porcentaje_Aceptacion_Terreno_SUGEF, 
C.Monto_Tasacion_Actualizada_No_Terreno, D.Porcentaje_Aceptacion_No_Terreno_SUGEF,
D.Monto_Mitigador, D.Valor_Nominal, C.Monto_Valor_Total_Cedula
FROM dbo.GARANTIAS_REALES C
INNER JOIN dbo.TIPOS_BIENES E
ON E.Id_Tipo_Bien = C.Id_Tipo_Bien
AND E.Ind_Estado_Registro = 1
INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS D
ON D.Id_Garantia_Real = C.Id_Garantia_Real
AND D.Ind_Estado_Registro = 1
INNER JOIN dbo.GARANTIAS_REALES_POLIZAS F
ON F.Id_Garantia_Real = C.Id_Garantia_Real
AND F.Ind_Estado_Registro = 1
INNER JOIN dbo.GRAVAMENES G
ON G.Id_Garantia_Real = C.Id_Garantia_Real
AND G.Ind_Estado_Registro = 1
INNER JOIN dbo.FIDEICOMISOS H
ON H.Id_Fideicomiso = D.Id_Fideicomiso
and H.Ind_Estado_Registro = 1
WHERE C.Ind_Estado_Registro = 1
AND C.Estado_Registro_Garantia = 1
AND E.Cod_Tipo_Bien = 1
AND C.Id_Clase_Tipo_Bien = 1
AND D.Id_Garantia_Fideicomiso IS not NULL
AND D.Id_Garantia_Valor IS NULL
AND D.Id_Garantia_Real IS not NULL
AND C.Fecha_Ultima_Tasacion_Garantia IS NOT NULL
AND F.Id_Garantia_Real_Poliza IS NOT NULL
--AND D.Porcentaje_Aceptacion_Terreno_SUGEF > 0
--AND D.Valor_Nominal > 0
--AND D.Monto_Mitigador = 0
ORDER BY H.Id_Fideicomiso_BCR
*/


/*
SELECT *
FROM dbo.CLASES_TIPOS_BIENES

*/
--UPDATE dbo.GRAVAMENES
--SET Saldo_Grado_Gravamen = 150000.00,
--	Saldo_Grado_Gravamen_Colonizado = 150000.00
--WHERE Id_Garantia_Real = 3088



--SELECT *
--FROM dbo.FIDEICOMISOS A
--LEFT JOIN dbo.GARANTIAS_FIDEICOMETIDAS B
--ON B.Id_Fideicomiso = A.Id_Fideicomiso
--AND B.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND B.Id_Fideicomiso IS NULL
--AND CONVERT(BIGINT, (dbo.Tramas_Obtener_Numericos(A.Id_Fideicomiso_BCR))) > 3312016023 
--AND A.Id_Fideicomiso_BCR NOT IN ('BCR04192016012', 'BCR22042016039', 'BCR25042016045', 'BCR04222016001', 'BCR22042016076',
--'BCR04152016020', 'BCR22042016057', 'BCR04012016035', 'BCR04012016037', 'BCR03312016013', 'BCR04012016023', 'BCR03312016022',
--'BCR04012016001', 'BCR03312016004' ,'BCR03312016005', 'BCR03312016006', 'BCR03312016007', 'BCR03312016008', 'BCR03312016009',
--'BCR03312016010', 'BCR03312016011', 'BCR03312016012', 'BCR03312016014', 'BCR03312016015', 'BCR03312016016', 'BCR03312016017',
--'BCR03312016018', 'BCR03312016019', 'BCR03312016020', 'BCR03312016021', 'BCR03312016023')

/*
SELECT *
FROM dbo.OPERACIONES A
INNER JOIN dbo.GARANTIAS_OPERACIONES B
ON B.Id_Operacion = A.Id_Operacion
AND B.Ind_Estado_Registro = 1
INNER JOIN dbo.prmoc C
ON C.prmoc_pco_conta = A.Conta
AND C.prmoc_pco_ofici = A.Oficina
AND C.prmoc_pco_moned = A.Moneda
AND C.prmoc_pco_produ = A.Prod
AND C.prmoc_pnu_oper = A.Numero
WHERE A.Ind_Estado_Registro = 1
AND A.Id_Tipo_Operacion = 1
--AND A.Categoria_Riesgo_Deudor IN ('A1', 'A2', 'B1', 'B2', 'C1')
AND A.Categoria_Riesgo_Deudor IN ('C2', 'D', 'E')
AND C.prmoc_estado = 'A'
AND C.prmoc_pnu_contr = 0
AND NOT EXISTS  (SELECT 1 
				 FROM dbo.GARANTIAS_OPERACIONES C 
				 WHERE C.Id_Operacion = A.Id_Operacion 
				 AND C.Id_Fideicomiso IS NOT NULL)



SELECT *
FROM dbo.OPERACIONES A
INNER JOIN dbo.GARANTIAS_OPERACIONES B
ON B.Id_Operacion = A.Id_Operacion
AND B.Ind_Estado_Registro = 1
INNER JOIN dbo.prmca C
ON C.prmca_pco_conta = A.Conta
AND C.prmca_pco_ofici = A.Oficina
AND C.prmca_pco_moned = A.Moneda
AND C.prmca_pco_produc = A.Prod
AND C.prmca_pnu_contr = A.Numero
WHERE A.Ind_Estado_Registro = 1
AND A.Id_Tipo_Operacion = 2
AND A.Categoria_Riesgo_Deudor IN ('A1', 'A2', 'B1', 'B2', 'C1')
--AND A.Categoria_Riesgo_Deudor IN ('C2', 'D', 'E')
AND C.prmca_estado = 'A'
AND NOT EXISTS  (SELECT 1 
				 FROM dbo.GARANTIAS_OPERACIONES C 
				 WHERE C.Id_Operacion = A.Id_Operacion 
				 AND C.Id_Fideicomiso IS NOT NULL)

*/

/*

UPDATE dbo.GARANTIAS_FIDEICOMETIDAS
SET Id_Tipo_Indicador_Inscripcion = 4 
--Fecha_Presentacion = '20160701'
WHERE Id_Garantia_Fideicomiso IN (869, 871)

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20150720'
WHERE Id_Fideicomiso IN (619, 938)



UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultima_Tasacion_Garantia = '20160728'
WHERE Id_Garantia_Real IN (20108, 25843)



--SELECT A.Id_Garantia_Fideicomiso, F.Id_Fideicomiso, F.Id_Fideicomiso_BCR, 
--CASE WHEN A.Id_Garantia_Real IS NOT NULL THEN D.Codigo_Bien
--	 WHEN A.Id_Garantia_Valor IS NOT NULL THEN E.Cod_Garantia_BCR
--END AS CODIGO_BIEN, 
--A.Id_Garantia_Real, A.Id_Garantia_Valor
--FROM dbo.GARANTIAS_FIDEICOMETIDAS A
--INNER JOIN dbo.PRIORIDADES_FIDEICOMISOS B
--ON B.Id_Fideicomiso = A.Id_Fideicomiso
--AND B.Ind_Estado_Registro = 1
--INNER JOIN GRADOS_PRIORIDADES C
--ON C.Id_Grado_Prioridad = B.Id_Grado_Prioridad
--AND C.Ind_Estado_Registro = 1
--AND C.Id_Tipo_Moneda = 2
--LEFT JOIN dbo.GARANTIAS_REALES D
--ON D.Id_Garantia_Real = A.Id_Garantia_Real
--AND D.Ind_Estado_Registro = 1
--LEFT JOIN dbo.GARANTIAS_VALORES E
--ON E.Id_Garantia_Valor = A.Id_Garantia_Valor
--AND E.Ind_Estado_Registro = 1
--INNER JOIN dbo.FIDEICOMISOS F
--ON F.Id_Fideicomiso = A.Id_Fideicomiso
--AND F.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1


--SELECT F.Id_Fideicomiso_BCR,  
--E.Cod_Garantia_BCR AS CODIGO_BIEN,
--E.Id_Moneda_Valor_Mercado, E.Monto_Valor_Mercado, E.Monto_Valor_Mercado_Colonizado

--SELECT COUNT(*) AS 'CANTIDAD_REGISTROS'
--FROM dbo.GARANTIAS_FIDEICOMETIDAS A
--INNER JOIN dbo.GARANTIAS_VALORES E
--ON E.Id_Garantia_Valor = A.Id_Garantia_Valor
--AND E.Ind_Estado_Registro = 1
--AND E.Id_Moneda_Valor_Mercado = 2
--INNER JOIN dbo.FIDEICOMISOS F
--ON F.Id_Fideicomiso = A.Id_Fideicomiso
--AND F.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1


--DECLARE @VALOR DECIMAL(6,2) 
--SELECT TOP 1 @VALOR = Valor 
--FROM	dbo.TIPOS_CAMBIOS
--ORDER BY Fecha DESC

--SELECT COUNT(*) AS 'CANTIDAD_REGISTROS', @VALOR AS 'TIPO DE CAMBIO'
--FROM dbo.GARANTIAS_VALORES
--WHERE Ind_Estado_Registro = 1
--AND Id_Moneda_Valor_Mercado = 2
--AND (Monto_Valor_Mercado * @VALOR) <> Monto_Valor_Mercado_Colonizado

















--SELECT COUNT(*) AS 'CANTIDAD_REGISTROS'
--FROM dbo.GARANTIAS_FIDEICOMETIDAS A
--INNER JOIN dbo.PRIORIDADES_FIDEICOMISOS B
--ON B.Id_Fideicomiso = A.Id_Fideicomiso
--AND B.Ind_Estado_Registro = 1
--INNER JOIN GRADOS_PRIORIDADES C
--ON C.Id_Grado_Prioridad = B.Id_Grado_Prioridad
--AND C.Ind_Estado_Registro = 1
--AND C.Id_Tipo_Moneda = 2
--LEFT JOIN dbo.GARANTIAS_REALES D
--ON D.Id_Garantia_Real = A.Id_Garantia_Real
--AND D.Ind_Estado_Registro = 1
--LEFT JOIN dbo.GARANTIAS_VALORES E
--ON E.Id_Garantia_Valor = A.Id_Garantia_Valor
--AND E.Ind_Estado_Registro = 1
--INNER JOIN dbo.FIDEICOMISOS F
--ON F.Id_Fideicomiso = A.Id_Fideicomiso
--AND F.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND (C.Saldo_Prioridad * @VALOR) <> C.Saldo_Prioridad_Colonizado
----AND Id_Garantia_Fideicomiso IN (445, 623)
----AND Id_Garantia_Fideicomiso IN (664, 863)




--SELECT A.Id_Garantia_Fideicomiso, F.Id_Fideicomiso, F.Id_Fideicomiso_BCR, 
--D.Codigo_Bien
---- E.Cod_Garantia_BCR
--  AS CODIGO_BIEN, 
--A.Id_Garantia_Real, A.Id_Garantia_Valor
--FROM dbo.GARANTIAS_FIDEICOMETIDAS A
--LEFT JOIN dbo.GARANTIAS_REALES D
--ON D.Id_Garantia_Real = A.Id_Garantia_Real
--AND D.Ind_Estado_Registro = 1
----LEFT JOIN dbo.GARANTIAS_VALORES E
----ON E.Id_Garantia_Valor = A.Id_Garantia_Valor
----AND E.Ind_Estado_Registro = 1
--INNER JOIN dbo.FIDEICOMISOS F
--ON F.Id_Fideicomiso = A.Id_Fideicomiso
--AND F.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND A.Valor_Nominal > 0
--AND D.Monto_Ultima_Tasacion_Terreno > 0
--AND D.Monto_Ultima_Tasacion_No_Terreno > 0
--AND A.Porcentaje_Aceptacion_BCR > 0
--AND A.Id_Garantia_Fideicomiso IN (912, 919)





--SELECT F.Id_Fideicomiso_BCR, 
--D.Codigo_Bien AS CODIGO_BIEN, 
--(D.Monto_Ultima_Tasacion_Terreno + D.Monto_Ultima_Tasacion_No_Terreno) AS 'MONTO TOTAL AVALUO',
--A.Porcentaje_Aceptacion_BCR,
--A.Valor_Nominal,
--F.Id_Fideicomiso
--FROM dbo.GARANTIAS_FIDEICOMETIDAS A
--LEFT JOIN dbo.GARANTIAS_REALES D
--ON D.Id_Garantia_Real = A.Id_Garantia_Real
--AND D.Ind_Estado_Registro = 1
--INNER JOIN dbo.FIDEICOMISOS F
--ON F.Id_Fideicomiso = A.Id_Fideicomiso
--AND F.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND A.Valor_Nominal > 0
--AND D.Monto_Ultima_Tasacion_Terreno > 0
--AND D.Monto_Ultima_Tasacion_No_Terreno > 0
--AND A.Porcentaje_Aceptacion_BCR > 0
--AND A.Id_Garantia_Fideicomiso IN (912, 919)


--select *
--from dbo.GARANTIAS_FIDEICOMETIDAS
--where Id_Fideicomiso = 46


--delete from dbo.GARANTIAS_FIDEICOMETIDAS
--where Id_Garantia_Fideicomiso = 966 

--SELECT A.Id_Garantia_Fideicomiso, F.Id_Fideicomiso, F.Id_Fideicomiso_BCR, 
--E.Cod_Garantia_BCR
--  AS CODIGO_BIEN, 
--A.Id_Garantia_Real, A.Id_Garantia_Valor
--FROM dbo.GARANTIAS_FIDEICOMETIDAS A
--LEFT JOIN dbo.GARANTIAS_VALORES E
--ON E.Id_Garantia_Valor = A.Id_Garantia_Valor
--AND E.Ind_Estado_Registro = 1
--INNER JOIN dbo.FIDEICOMISOS F
--ON F.Id_Fideicomiso = A.Id_Fideicomiso
--AND F.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND A.Valor_Nominal > 0
--AND E.Monto_Valor_Mercado_Colonizado > 0
--AND A.Porcentaje_Aceptacion_BCR > 0
--AND A.Id_Garantia_Fideicomiso IN (863, 976)







--SELECT F.Id_Fideicomiso_BCR, 
--E.Cod_Garantia_BCR AS CODIGO_BIEN, 
--E.Monto_Valor_Mercado_Colonizado, A.Porcentaje_Aceptacion_BCR, A.Valor_Nominal, F.Id_Fideicomiso
--FROM dbo.GARANTIAS_FIDEICOMETIDAS A
--LEFT JOIN dbo.GARANTIAS_VALORES E
--ON E.Id_Garantia_Valor = A.Id_Garantia_Valor
--AND E.Ind_Estado_Registro = 1
--INNER JOIN dbo.FIDEICOMISOS F
--ON F.Id_Fideicomiso = A.Id_Fideicomiso
--AND F.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND A.Valor_Nominal > 0
--AND E.Monto_Valor_Mercado_Colonizado > 0
--AND A.Porcentaje_Aceptacion_BCR > 0
--AND A.Id_Garantia_Fideicomiso IN (863, 976)

--select *
--from dbo.GARANTIAS_FIDEICOMETIDAS
--where Id_Fideicomiso = 1380


--delete from dbo.GARANTIAS_FIDEICOMETIDAS
--where Id_Garantia_Fideicomiso = 974 



--SELECT F.Id_Fideicomiso_BCR,  
-- A.Valor_Nominal
--FROM dbo.GARANTIAS_FIDEICOMETIDAS A
--INNER JOIN dbo.FIDEICOMISOS F
--ON F.Id_Fideicomiso = A.Id_Fideicomiso
--AND F.Ind_Estado_Registro = 1
--WHERE A.Ind_Estado_Registro = 1
--AND A.Valor_Nominal > 0
--AND A.Porcentaje_Aceptacion_BCR > 0
--AND A.Id_Garantia_Fideicomiso IN (919, 863)

*/


/*

USE [SIGANEM]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Garantias_Fideicometidas_Consulta_Grid_Interno]
		@piId_Fideicomiso = 135

EXEC	@return_value = [dbo].[Garantias_Fideicometidas_Consulta_Detalle]
		@piId_Garantia_Fideicomiso = 1046


EXEC	@return_value = [dbo].[Garantias_Reales_Consulta]
		@piIndice_Inicio_Fila = 0,
		@piMaximo_Filas = 10,
		@psValores_Filtro = N'666999',
		@psColumnas_Filtros = N'Codigo_Bien',
		@psColumna_Ordenar = N'Codigo_Bien'

--SELECT	'Return Value' = @return_value



EXEC	@return_value = [dbo].[Garantias_Reales_Consulta_Detalle]
		@piId_Garantia_Real = 3501

--SELECT	'Return Value' = @return_value

EXEC	@return_value = [dbo].[Garantias_Reales_Polizas_Consulta_Grid_Interno]
		@piId_Garantia_Real = 5980

--SELECT	'Return Value' = @return_value

EXEC	@return_value = [dbo].[Garantias_Reales_Polizas_Consulta_Detalle]
		@piId_Garantia_Real_Poliza = 1609

--SELECT	'Return Value' = @return_value


EXEC	@return_value = [dbo].[Fideicomisos_Consulta_Detalle]
		@piId_Fideicomiso = 39

--SELECT	'Return Value' = @return_value



SELECT *
FROM dbo.TIPOS_INDICADORES_INSCRIPCIONES




USE [SIGANEM]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Garantias_Valores_Consulta]
		@piIndice_Inicio_Fila = 0,
		@piMaximo_Filas = 10,
		@psValores_Filtro = N'325610',
		@psColumnas_Filtros = N'Cod_Garantia_BCR',
		@psColumna_Ordenar = N'Cod_Garantia_BCR'

--SELECT	'Return Value' = @return_value


EXEC	@return_value = [dbo].[Garantias_Valores_Consulta_Detalle]
		@piId_Garantia_Valor = 1277

--SELECT	'Return Value' = @return_value



*/

/*

SELECT 
	    GARFID.Id_Fideicomiso,	ACT.*,GARFID.Ind_Deudor_Habita,GAROPER.Id_Fideicomiso,
		CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1) AND Validacion_5 = 0 AND GARFID.Ind_Deudor_Habita = 1 AND GAROPER.Id_Fideicomiso IS NULL THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT
		INNER JOIN dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		ON GARFID.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
		AND GARFID.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Fideicomiso = GARFID.Id_Fideicomiso
		AND GAROPER.Ind_Estado_Registro = 1
	WHERE 
		Cod_Tipo_Bien = 2
		AND GARFID.Id_Fideicomiso IN (74, 75)


SELECT --Reales
			GARFID.Id_Fideicomiso,
			GARFID.Id_Garantia_Fideicomiso,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN GARFID.Fecha_Presentacion IS NULL AND GARFID.Id_Tipo_Indicador_Inscripcion = 1 
									THEN 1
									ELSE 0
							END,
			Validacion_2 = CASE WHEN GARFID.Fecha_Presentacion IS NOT NULL AND GARFID.Id_Tipo_Indicador_Inscripcion = 4 AND (DATEADD(D,60, FID.Fecha_Constitucion)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_3 = CASE WHEN GARFID.Fecha_Presentacion IS NOT NULL AND GARFID.Id_Tipo_Indicador_Inscripcion = 4 
								THEN 1
								ELSE 0
							END,
			Validacion_4 = CASE WHEN DATEADD(M, PAR.Meses_Vencimiento_Avaluo_SUGEF_Edificacion, GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_5 = CASE WHEN DATEADD(M, PAR.Meses_Seguimiento_Edificacion, GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_7 = CASE WHEN  DATEADD(D, 30, GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_8 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_9 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_FIDEICOMETIDAS GARFID
		INNER JOIN dbo.FIDEICOMISOS FID
			ON FID.Id_Fideicomiso = GARFID.Id_Fideicomiso
			AND FID.Ind_Estado_Registro = 1
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GARFID.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GARFID.Id_Tipo_Mitigador_Riesgo
			AND TM.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GARFID.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GARFID.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2
			ORDER BY  GARFID.Id_Fideicomiso 

SELECT *
FROM
dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R
WHERE Id_Garantia_Fideicomiso IN (944, 945)


SELECT *
FROM
dbo.AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA
WHERE Id_Garantia_Fideicomiso IN (944, 945)


SELECT 
CASE WHEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF IS NOT NULL
																	 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
																	 ELSE ACT_1.Porcentaje_Aceptacion_No_Terreno_SUGEF
																END
	FROM		
		dbo.GARANTIAS_FIDEICOMETIDAS GAR
	INNER JOIN	AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA ACT 
		ON GAR.Id_Garantia_Fideicomiso = ACT.Id_Garantia_Fideicomiso
	INNER JOIN AUX_GAR_PRC_ACP_NO_TERRENO_FIDEICOMETIDA_R ACT_1
		ON GAR.Id_Garantia_Fideicomiso = ACT_1.Id_Garantia_Fideicomiso
	WHERE Cod_Tipo_Bien IS NOT NULL
	AND Cod_Clase_Tipo_Bien IS NOT NULL
	AND GAR.Id_Garantia_Fideicomiso IN (944, 945)

	SELECT *
	FROM dbo.GARANTIAS_FIDEICOMETIDAS
	WHERE Id_Garantia_Fideicomiso IN (944, 945)


	SELECT D.Id_Garantia_Aval, D.Numero_Aval,
(CAST(O.Oficina AS VARCHAR) + '-' + CAST(O.Moneda AS VARCHAR) + '-' + CASE WHEN O.Id_Tipo_Operacion = 1 THEN CAST(O.Prod AS VARCHAR) + '-' ELSE '' END + CAST(O.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS'
, E.Id_Garantia_Operacion, E.Monto_Mitigador_Calculado
FROM dbo.GARANTIAS_AVALES D
INNER JOIN dbo.GARANTIAS_OPERACIONES E
ON E.Id_Garantia_Aval = D.Id_Garantia_Aval
AND E.Ind_Estado_Registro = 1
INNER JOIN dbo.OPERACIONES O
ON O.Id_Operacion = E.Id_Operacion
AND O.Ind_Estado_Registro = 1
--INNER JOIN dbo.prmoc K
--ON K.prmoc_pco_ofici = O.Oficina
--AND K.prmoc_pco_moned = O.Moneda
--AND K.prmoc_pco_produ = O.Prod
--AND K.prmoc_pnu_oper = O.Numero
--AND K.prmoc_estado = 'A'
--AND K.prmoc_pcoctamay <> 815
--AND K.prmoc_pse_proces = 1
--AND K.prmoc_pnu_contr = 0
INNER JOIN dbo.prmca K
ON K.prmca_pco_ofici = O.Oficina
AND K.prmca_pco_moned = O.Moneda
AND K.prmca_pnu_contr = O.Numero
AND K.prmca_estado = 'A'
AND K.prmca_pfe_defin > 20160809
WHERE D.Ind_Estado_Registro = 1
AND E.Monto_Mitigador_Calculado > 0
AND E.Porcentaje_Aceptacion_BCR > 0
ORDER BY D.Numero_Aval

/*
UPDATE dbo.GARANTIAS_OPERACIONES
SET Porcentaje_Responsabilidad_SUGEF = 75
WHERE Id_Garantia_Operacion = 59746 --59752
*/


	*/