USE [SIGANEM]
GO


/*PERMISOS TABLAS*/

GRANT SELECT, INSERT, DELETE, UPDATE ON dbo.AUX_ACTUALIZAGARANTIAS TO RAP_AccesoSIGANEM
GO


/*PERMISOS SPs */

GRANT EXECUTE ON Calculo_Monto_Tasacion_Actualizada_Terreno TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Calculo_Monto_Tasacion_Actualizada_No_Terreno TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Calculo_Porcentaje_Aceptacion_Terreno_SUGEF TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Calculo_Porcentaje_Responsabilidad_Escenario_A TO RAP_AccesoSIGANEM
GO
GRANT EXECUTE ON Calculo_Porcentaje_Responsabilidad_Escenario_B TO RAP_AccesoSIGANEM
GO
