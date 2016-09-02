USE [SIGANEM]
GO


/*PERMISOS TABLAS*/

GRANT SELECT, INSERT, DELETE, UPDATE ON dbo.GARANTIAS_OPERACIONES TO RAP_AccesoSIGANEM
GO


/*PERMISOS SPs */

GRANT EXECUTE ON Calculo_Monto_Grado_Gravamen TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Garantias_Operaciones_Inserta TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Garantias_Operaciones_Actualiza TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Garantias_Operaciones_Elimina TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Garantias_Operaciones_Consulta_Detalle TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Operaciones_Actualiza TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Operaciones_Actualiza_Generales TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Operaciones_Elimina TO RAP_AccesoSIGANEM
GO

GRANT EXECUTE ON Calculo_Monto_Grado_Gravamen TO RAP_AccesoIntegracion
GO

