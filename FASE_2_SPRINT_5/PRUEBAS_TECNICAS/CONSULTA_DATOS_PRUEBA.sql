
SELECT (CAST(B.Oficina AS VARCHAR) + '-' + CAST(B.Moneda AS VARCHAR) + '-' + CASE WHEN B.Id_Tipo_Operacion = 1 THEN CAST(B.Prod AS VARCHAR) + '-' ELSE '' END + CAST(B.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS',
B.Saldo_Colonizado, B.Saldo_Original_Colonizado, B.Numero_Operacion 
--,D.Codigo_Bien--
--, E.Id_Fideicomiso_BCR
,F.Cod_Garantia_BCR
,A.Monto_Grado_Gravamen_Original, A.Monto_Grado_Gravamen_Modificado, A.Monto_Grado_Gravamen, A.Ind_Monto_Grado_Gravamen_Modificado
--, A.Id_Fideicomiso, A.Id_Garantia_Aval, A.Id_Garantia_Fiduciaria, A.Id_Garantia_Valor, A.Id_Garantia_Operacion
FROM dbo.GARANTIAS_OPERACIONES A
INNER JOIN dbo.OPERACIONES B
ON B.Id_Operacion = A.Id_Operacion
AND B.Ind_Estado_Registro = 1
INNER JOIN dbo.prmoc C
ON C.prmoc_pco_ofici = B.Oficina
AND C.prmoc_pco_moned = B.Moneda
AND C.prmoc_pco_produ = B.Prod
AND C.prmoc_pnu_oper = B.Numero
AND C.prmoc_estado = 'A'
LEFT JOIN dbo.GARANTIAS_REALES D
ON D.Id_Garantia_Real = A.Id_Garantia_Real
AND D.Ind_Estado_Registro = 1
AND D.Estado_Registro_Garantia = 1
LEFT JOIN dbo.FIDEICOMISOS E
ON E.Id_Fideicomiso = A.Id_Fideicomiso
AND E.Ind_Estado_Registro = 1
LEFT JOIN dbo.GARANTIAS_VALORES F
ON F.Id_Garantia_Valor = A.Id_Garantia_Valor
AND F.Ind_Estado_Registro = 1
WHERE A.Ind_Estado_Registro = 1
--AND A.Monto_Grado_Gravamen_Modificado IS NULL
AND B.Id_Tipo_Operacion = 1
AND C.prmoc_pnu_contr = 0
--AND A.Id_Garantia_Real IN (69,76)
--AND B.Saldo_Colonizado = 0
--AND B.Saldo_Original_Colonizado = 0
--AND C.prmoc_pmo_origi = 0
--AND A.Id_Fideicomiso = 77
AND A.Id_Operacion = 58439
/*


SELECT (CAST(B.Oficina AS VARCHAR) + '-' + CAST(B.Moneda AS VARCHAR) + '-' + CASE WHEN B.Id_Tipo_Operacion = 1 THEN CAST(B.Prod AS VARCHAR) + '-' ELSE '' END + CAST(B.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS',
B.Saldo_Colonizado, B.Saldo_Original_Colonizado, 
D.Cod_Garantia_BCR, E.Numero_Aval,
A.Monto_Grado_Gravamen_Original, A.Monto_Grado_Gravamen_Modificado, A.Monto_Grado_Gravamen
FROM dbo.GARANTIAS_OPERACIONES A
INNER JOIN dbo.OPERACIONES B
ON B.Id_Operacion = A.Id_Operacion
AND B.Ind_Estado_Registro = 1
INNER JOIN dbo.prmca C
ON C.prmca_pco_ofici = B.Oficina
AND C.prmca_pco_moned = B.Moneda
AND C.prmca_pco_produc = B.Prod
AND C.prmca_pnu_contr = B.Numero
AND C.prmca_estado = 'A'
LEFT JOIN dbo.GARANTIAS_AVALES E
ON E.Id_Garantia_Aval = A.Id_Garantia_Aval
AND E.Ind_Estado_Registro = 1
LEFT JOIN dbo.GARANTIAS_VALORES D
ON D.Id_Garantia_Valor = A.Id_Garantia_Valor
AND D.Ind_Estado_Registro = 1
WHERE A.Ind_Estado_Registro = 1
AND A.Monto_Grado_Gravamen_Original > 1
AND B.Id_Tipo_Operacion = 2
AND C.prmca_pfe_defin > 20160903









AND B.Id_Operacion IN (58433, 1303)
AND A.Id_Garantia_Operacion IN (60284, 60269)






SELECT *
FROM dbo.GARANTIAS_REALES A
LEFT JOIN dbo.GARANTIAS_OPERACIONES B
ON B.Id_Garantia_Real = A.Id_Garantia_Real
AND B.Ind_Estado_Registro = 1
WHERE A.Ind_Estado_Registro = 1
AND B.Id_Garantia_Real IS NULL
*/








/*
UPDATE dbo.GARANTIAS_OPERACIONES
SET Monto_Grado_Gravamen_Original = 10500000.00
WHERE Id_Garantia_Operacion = 60283
*/