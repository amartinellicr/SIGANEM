USE [SIGANEM]
GO


/*SE AJUSTAN LOS VALORES EN LOS CAMPOS NUEVOS*/
UPDATE	AUX
SET		AUX.Monto_Ultima_Tasacion_No_Terreno = GR.Monto_Ultima_Tasacion_No_Terreno
FROM	dbo.AUX_ACTUALIZAGARANTIAS AUX
	INNER JOIN dbo.GARANTIAS_REALES GR
		ON ISNULL(AUX.Id_Clase_Aeronave,-1) = ISNULL(GR.Id_Clase_Aeronave,-1)
		AND ISNULL(AUX.Id_Clase_Buque,-1) = ISNULL(GR.Id_Clase_Buque,-1)
		AND ISNULL(AUX.Id_Clase_Tipo_Bien,-1) = ISNULL(GR.Id_Clase_Tipo_Bien,-1)
		AND ISNULL(AUX.Id_Clase_Vehiculo,-1) = ISNULL(GR.Id_Clase_Vehiculo,-1)
		AND ISNULL(AUX.Id_Provincia,-1) = ISNULL(GR.Id_Provincia,-1)
		AND ISNULL(AUX.Id_Tipo_Bien,-1) = ISNULL(GR.Id_Tipo_Bien,-1)
		AND AUX.Codigo_Bien = GR.Codigo_Bien
		AND ISNULL(AUX.Id_Codigo_Duplicado,-1) = ISNULL(GR.Id_Codigo_Duplicado,-1)
		AND ISNULL(AUX.Id_Codigo_Horizontalidad,-1) = ISNULL(GR.Id_Codigo_Horizontalidad,-1)
		AND ISNULL(AUX.Formato_Identificacion_Vehiculo,-1) = ISNULL(GR.Formato_Identificacion_Vehiculo,-1)
		AND ISNULL(AUX.Fecha_Ultima_Tasacion,'1900-01-01') = ISNULL(GR.Fecha_Ultima_Tasacion_Garantia,'1900-01-01')
		AND AUX.Ind_Bien = 'N'
	INNER JOIN dbo.TIPOS_BIENES TB 
		ON GR.Id_Tipo_Bien = TB.Id_Tipo_Bien 
	WHERE	TB.Cod_Tipo_Bien = 2
	AND		GR.Ind_Estado_Registro = 1
	AND		GR.Estado_Registro_Garantia = 1	

GO







