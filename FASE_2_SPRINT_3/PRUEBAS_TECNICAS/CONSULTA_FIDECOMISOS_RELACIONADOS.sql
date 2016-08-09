
SELECT DISTINCT (CAST(C.Oficina AS VARCHAR) + '-' + CAST(C.Moneda AS VARCHAR) + '-' + CASE WHEN C.Id_Tipo_Operacion = 1 THEN CAST(C.Prod AS VARCHAR) + '-' ELSE '' END + CAST(C.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS',
C.Categoria_Riesgo_Deudor AS 'CATEGORIA RIESGO DEUDOR'
FROM dbo.GARANTIAS_OPERACIONES A
INNER JOIN dbo.FIDEICOMISOS B
ON B.Id_Fideicomiso = A.Id_Fideicomiso
AND B.Ind_Estado_Registro = 1
INNER JOIN dbo.OPERACIONES C
ON C.Id_Operacion = A.Id_Operacion
AND C.Ind_Estado_Registro = 1
WHERE Id_Tipo_Garantia = 11
AND A.Ind_Estado_Registro = 1
AND B.Id_Fideicomiso_BCR = 'BCR04052016002'


SELECT COUNT(*) AS 'CANTIDAD_REGISTROS'
FROM dbo.GARANTIAS_FIDEICOMETIDAS A
INNER JOIN dbo.GARANTIAS_REALES B
ON B.Id_Garantia_Real = A.Id_Garantia_Real
AND B.Ind_Estado_Registro = 1
WHERE A.Ind_Estado_Registro = 1
AND B.Id_Tipo_Bien = 3
AND A.Porcentaje_Aceptacion_No_Terreno_SUGEF > 100


























/*
SELECT DISTINCT (CAST(C.Oficina AS VARCHAR) + '-' + CAST(C.Moneda AS VARCHAR) + '-' + CASE WHEN C.Id_Tipo_Operacion = 1 THEN CAST(C.Prod AS VARCHAR) + '-' ELSE '' END + CAST(C.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS'
,C.Categoria_Riesgo_Deudor AS 'CATEGORIA RIESGO DEUDOR'
FROM dbo.GARANTIAS_OPERACIONES A
INNER JOIN dbo.FIDEICOMISOS B
ON B.Id_Fideicomiso = A.Id_Fideicomiso
AND B.Ind_Estado_Registro = 1
INNER JOIN dbo.OPERACIONES C
ON C.Id_Operacion = A.Id_Operacion
AND C.Ind_Estado_Registro = 1
WHERE Id_Tipo_Garantia = 11
AND A.Ind_Estado_Registro = 1
AND B.Id_Fideicomiso_BCR = 'BCR04052016004'
*/