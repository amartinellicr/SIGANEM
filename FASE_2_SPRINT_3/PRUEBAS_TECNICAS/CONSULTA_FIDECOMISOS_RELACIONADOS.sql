SELECT (CAST(C.Oficina AS VARCHAR) + '-' + CAST(C.Moneda AS VARCHAR) + '-' + CASE WHEN C.Id_Tipo_Operacion = 1 THEN CAST(C.Prod AS VARCHAR) + '-' ELSE '' END + CAST(C.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS',
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
AND B.Id_Fideicomiso_BCR = 'BCR04012016067'


SELECT (CAST(C.Oficina AS VARCHAR) + '-' + CAST(C.Moneda AS VARCHAR) + '-' + CASE WHEN C.Id_Tipo_Operacion = 1 THEN CAST(C.Prod AS VARCHAR) + '-' ELSE '' END + CAST(C.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS'
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
AND B.Id_Fideicomiso_BCR = 'BCR04012016068'