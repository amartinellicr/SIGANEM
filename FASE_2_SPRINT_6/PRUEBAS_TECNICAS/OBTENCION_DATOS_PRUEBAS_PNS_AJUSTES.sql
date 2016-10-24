SELECT A.Id_Garantia_Operacion, D.Id_Garantia_Real,  B.Numero_Operacion, D.Codigo_Bien, D.Id_Provincia, D.Id_Clase_Tipo_Bien, D.Id_Tipo_Bien
FROM dbo.GARANTIAS_OPERACIONES A
INNER JOIN dbo.OPERACIONES B
ON B.Id_Operacion = A.Id_Operacion
AND B.Ind_Estado_Registro = 1
--LEFT OUTER JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES C
--ON C.Id_Garantia_Operacion = A.Id_Garantia_Operacion
--AND C.Ind_Estado_Registro = 1
INNER JOIN dbo.GARANTIAS_REALES D
ON D.Id_Garantia_Real = A.Id_Garantia_Real
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
AND E.prmca_pnu_contr = B.Numero
AND E.prmca_estado = 'A'
*/
WHERE A.Ind_Estado_Registro = 1
AND A.Id_Garantia_Real IS NOT NULL
--AND C.Id_Garantia_Real_Inscripcion IS NULL
--AND B.Numero_Operacion = '0121501025757962'
AND A.Fecha_Vencimiento_Garantia > GETDATE()
--AND B.Categoria_Riesgo_Deudor IN ('A1', 'A2', 'B1', 'B2', 'C1')
AND B.Categoria_Riesgo_Deudor IN ('C2', 'D', 'E')
ORDER BY B.Numero_Operacion




/*
SELECT *
FROM dbo.CLASES_TIPOS_BIENES
*/

SELECT B.Numero_Operacion, B.*, C.Id_Garantia_Operacion, C.Id_Garantia_Real
FROM dbo.OPERACIONES B
INNER JOIN dbo.prmca_SICC E
ON E.prmca_pco_conta = B.Conta
AND E.prmca_pco_ofici = B.Oficina
AND E.prmca_pco_moned = B.Moneda
AND E.prmca_pnu_contr = B.Numero
AND E.prmca_estado = 'A'
LEFT JOIN dbo.GARANTIAS_OPERACIONES C
ON C.Id_Operacion = B.Id_Operacion
AND C.Ind_Estado_Registro = 1
WHERE B.Ind_Estado_Registro = 1
--AND B.Categoria_Riesgo_Deudor IN ('A1', 'A2', 'B1', 'B2', 'C1')
AND B.Categoria_Riesgo_Deudor IN ('C2', 'D', 'E')
--AND C.Id_Garantia_Operacion IS NULL
--AND B.Numero_Operacion = '01406022400678'



SELECT *
FROM dbo.GARANTIAS_REALES A
LEFT JOIN dbo.GARANTIAS_OPERACIONES B
ON B.Id_Garantia_Real = A.Id_Garantia_Real
AND B.Ind_Estado_Registro = 1
WHERE A.Ind_Estado_Registro = 1
AND B.Id_Garantia_Operacion IS NULL
AND A.Id_Clase_Tipo_Bien IN (4,6)
AND A.Id_Tipo_Bien = 2
ORDER BY A.Id_Garantia_Real