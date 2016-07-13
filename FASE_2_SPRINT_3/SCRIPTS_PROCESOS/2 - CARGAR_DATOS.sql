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




