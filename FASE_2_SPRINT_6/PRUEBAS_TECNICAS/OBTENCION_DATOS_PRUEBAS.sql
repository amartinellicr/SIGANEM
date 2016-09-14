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