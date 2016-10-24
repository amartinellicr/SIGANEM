SELECT *
FROM dbo.GARANTIAS_REALES
WHERE Ind_Estado_Registro = 1
AND Estado_Registro_Garantia = 1
AND Id_Tipo_Bien = 2
--AND datediff(year,(Fecha_Construccion_Garantia),CONVERT(DATE,GETDATE())) > 10
--AND datediff(year,(Fecha_Construccion_Garantia),CONVERT(DATE,GETDATE())) > 40
--AND GETDATE() > DATEADD(MONTH, -6, Fecha_Ultima_Tasacion_Garantia)
AND Fecha_Construccion_Garantia IS NULL


SELECT *
FROM dbo.TIPOS_BIENES


SELECT B.*
FROM dbo.GARANTIAS_OPERACIONES A
INNER JOIN dbo.OPERACIONES B
ON B.Id_Operacion = A.Id_Operacion
AND B.Ind_Estado_Registro = 1
LEFT OUTER JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES C
ON C.Id_Garantia_Operacion = A.Id_Garantia_Operacion
AND C.Ind_Estado_Registro = 1
WHERE A.Ind_Estado_Registro = 1
AND A.Id_Garantia_Real IS NOT NULL
AND C.Id_Garantia_Real_Inscripcion IS NULL