USE [SIGANEM]
GO


SET IDENTITY_INSERT dbo.PROCESOS ON

INSERT INTO dbo.PROCESOS (Id_Proceso, Cod_Proceso, Des_Proceso, Ind_Metodo_Insercion, Fecha_Ingreso, Cod_Usuario_Ingreso)
SELECT
	 Id_Proceso, Cod_Proceso, Des_Proceso, Ind_Metodo_Insercion, Fecha_Ingreso, Cod_Usuario_Ingreso
FROM (
	VALUES 
		(11,11,'Coloniza Valor Mercado','MANTENIMIENTO', CAST('19000101' AS DateTime), N'999999999')
		,(12,12,'Actualiza Valor Nominal','MANTENIMIENTO',CAST('19000101' AS DateTime), N'999999999')
		,(13,13,'Actualiza Porcentajes de Aceptación Fideicometida','MANTENIMIENTO',CAST('19000101' AS DateTime), N'999999999')
		,(14,14,'Calcula Monto Mitigador Fideicometida','MANTENIMIENTO',CAST('19000101' AS DateTime), N'999999999')
		,(15,15,'Coloniza Montos Prioridades de Garantías','MANTENIMIENTO',CAST('19000101' AS DateTime), N'999999999')
		
		
) AS PROCESOS (Id_Proceso, Cod_Proceso, Des_Proceso, Ind_Metodo_Insercion, Fecha_Ingreso, Cod_Usuario_Ingreso)

EXCEPT 
	SELECT Id_Proceso, Cod_Proceso, Des_Proceso, Ind_Metodo_Insercion, Fecha_Ingreso, Cod_Usuario_Ingreso FROM PROCESOS

SET IDENTITY_INSERT dbo.PROCESOS OFF

GO


UPDATE dbo.PROCESOS
SET Des_Proceso = 'Actualiza Porcentajes de Aceptación de relaciones'
WHERE Id_Proceso = 8
GO


UPDATE dbo.PROCESOS
SET Des_Proceso = 'Calcula Monto Mitigador de relaciones'
WHERE Id_Proceso = 9
GO

UPDATE dbo.GARANTIAS_OPERACIONES
SET Id_Tipo_Garantia = 8
WHERE Id_Tipo_Garantia = 11
AND Id_Fideicomiso IS NOT NULL
GO

UPDATE dbo.GARANTIAS_OPERACIONES
SET Id_Tipo_Garantia = 11
WHERE Id_Tipo_Garantia = 12
AND Id_Garantia_Aval IS NOT NULL
GO

UPDATE dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS 
SET Id_Tipo_Garantia = 8
WHERE Id_Tipo_Garantia = 11
GO

UPDATE dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS 
SET Id_Tipo_Garantia = 11
WHERE Id_Tipo_Garantia = 12
GO

UPDATE dbo.TRAMAS
SET Id_Tipo_Garantia = 8
WHERE Id_Tipo_Garantia = 11
GO 

UPDATE dbo.TRAMAS
SET Id_Tipo_Garantia = 11
WHERE Id_Tipo_Garantia = 12
GO


DELETE FROM dbo.TIPOS_GARANTIAS
WHERE Id_Tipo_Garantia = 12
GO

UPDATE dbo.TIPOS_GARANTIAS
SET Cod_Tipo_Garantia = 99,
	Des_Tipo_Garantia = 'Garantía Aval'
WHERE Id_Tipo_Garantia = 11
GO










