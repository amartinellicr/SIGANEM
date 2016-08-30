USE [SIGANEM]
GO


/*SE AJUSTAN LOS VALORES EN LOS CAMPOS NUEVOS*/
UPDATE dbo.GARANTIAS_OPERACIONES
SET Monto_Grado_Gravamen_Original = Monto_Grado_Gravamen,
	Ind_Monto_Grado_Gravamen_Modificado = 0

GO








