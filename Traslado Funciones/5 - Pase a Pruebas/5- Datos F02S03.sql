USE [SIGANEM]
GO

/*GATANT�AS AVALES RELACIONADAS*/
INSERT INTO ADMINISTRACIONES_CONTENIDOS(Cod_Pantalla, Nombre_Propiedad, Des_Columna, Tab, Ind_Requerido, Ind_Modificar, Ind_Visible, Valor_Defecto,Tipo_Contenido,Valor_Maximo,
Css_Tipo,Metodo_Servicio_Web,Grupo_Validacion,Ind_Metodo_Insercion, Fecha_Ingreso, Cod_Usuario_Ingreso)

/*INSERCION NUEVOS CAMPOS ADMINISTRACI�N_CONTENIDOS SECCION GENERAL GARANTIAS AVALES*/
SELECT 24,'IdTipoAval','Tipo Aval', 'Avales', 1, 0, 1,NULL,'DROPDOWNLIST', NULL,
	   'mainTableBoxesCss','TipoAvalLista',NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'NAval','N� Aval', 'Avales', 1, 0, 1,NULL,'TEXTBOX', NULL,
	   'mainTableBoxesCss',NULL,'ValidacionAvalesGeneral', 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'IdTipoIdentificacionAvalista','Tipo Identificaci�n Avalista', 'Avales', 0, 0, 1,NULL,'DROPDOWNLIST', NULL,
	   'mainTableBoxesCss','GarantiasOperacionesTipoIdentificacionLista',NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
	   UNION ALL
SELECT 24,'Identificaci�nAvalista','Identificaci�n Avalista', 'Avales', 0, 0, 1,NULL,'TEXTBOX', NULL,
	   'mainTableBoxesCss',NULL,NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
	   UNION ALL
SELECT 24,'MontoAvalado','Monto Avalado', 'Avales', 0, 0, 1,NULL,'TEXTBOX', NULL,
	   'mainTableBoxesCss',NULL, NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
	   UNION ALL
SELECT 24,'IdClaseGarantiaPrt17','Clase Garant�a', 'Avales', 0, 0, 1,'20 - Seguridades','DROPDOWNLIST', NULL,
		'mainTableBoxesCss','ClasesGarantiasPRT17Lista', NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'IdTenenciaPrt15','C�digo Tenencia', 'Avales', 0, 0, 1,'37 - Aval Garant�a FINADE','DROPDOWNLIST', NULL,
		'mainTableBoxesCss','TenenciasPRT15Lista', NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'IdGradoGravamen','Grado Gravamen', 'Avales', 0, 0, 1,'01 - Primer Grado','DROPDOWNLIST', NULL,
		'mainTableBoxesCss','GradosGravamenesLista', NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'IdTipoMonedaGradoGravamen','Tipo Moneda Monto Gravamen', 'Avales', 0, 0, 1,NULL,'DROPDOWNLIST', NULL,
		'mainTableBoxesCss','MonedasLista', NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'FechaConstitucionGarantia','Fecha Constituci�n Garant�a', 'Avales', 0, 0, 1,NULL,'TEXTBOX', NULL,
	'mainTableBoxesCss',NULL, NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'FechaVencimientoGarantia','Fecha Vencimiento Garant�a', 'Avales', 0, 0, 1,NULL,'TEXTBOX', NULL,
	'mainTableBoxesCss',NULL, NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'IdTipoMitigadorRiesgo','Tipo Mitigador Riesgo', 'Avales', 0, 0, 1,'0 � No Mitigador','DROPDOWNLIST', NULL,
	'mainTableBoxesCss','TiposMitigadoresRiesgosLista', NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'IdTipoDocumentoLegal','Tipo Documento Legal', 'Avales', 0, 0, 1,'29 - Fianzas y avales','DROPDOWNLIST', NULL,
	'mainTableBoxesCss','TiposDocumentosLegalesLista', NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
GO
/*GATANT�AS AVALES RELACIONADAS*/
INSERT INTO ADMINISTRACIONES_CONTENIDOS(Cod_Pantalla, Nombre_Propiedad, Des_Columna, Tab, Ind_Requerido, Ind_Modificar, Ind_Visible, Valor_Defecto,Mascara,Valor_Mascara,Tipo_Contenido,Valor_Maximo,
Css_Tipo,Metodo_Servicio_Web,Grupo_Validacion,Ind_Metodo_Insercion, Fecha_Ingreso, Cod_Usuario_Ingreso)

SELECT 24,'MontoGradoGravamen','Monto Grado Gravamen', 'Avales', 1, 1, 1,NULL,1,'99,999,999,999,999,999,999.99', 'TEXTBOX', NULL,
'mainTableBoxesCss',NULL, 'ValidacionAvalesAdicional', 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'MontoMitigador','Monto Mitigador', 'Avales', 0, 1, 1,NULL,1,'99,999,999,999,999,999,999.99','TEXTBOX', NULL,
	'mainTableBoxesCss',NULL, NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'MontoMitigadorCalculado','Monto Mitigador Calculado', 'Avales', 0, 0, 1,NULL,1,'9,999,999,999,999,999,999,999.99','TEXTBOX', NULL,
	'mainTableBoxesCss',NULL, NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'PorcentajeAceptBCR','Porcentaje Aceptaci�n BCR', 'Avales', 1, 1, 1,0,1,'999.99%','TEXTBOX', NULL,
	'mainTableBoxesCss',NULL, 'ValidacionAvalesAdicional', 'MANTENIMIENTO',GETDATE(),'999999999'
UNION ALL
SELECT 24,'PorcentajeAceptSugef','Porcentaje Aceptaci�n SUGEF', 'Avales', 0, 0, 1,0,1,'999.99%','TEXTBOX', NULL,
	'mainTableBoxesCss',NULL, NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
	UNION ALL
SELECT 24,'PorcentajeResponSugef','Porcentaje Responsabilidad SUGEF', 'Avales', 0, 0, 1,NULL,1,'999.99%','TEXTBOX', NULL,
	'mainTableBoxesCss',NULL, NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
	UNION ALL
SELECT 24,'PorcentajeResponLegal','Porcentaje Responsabilidad Legal', 'Avales', 0, 0, 1,NULL,1,'999.99%','TEXTBOX', NULL,
	'mainTableBoxesCss',NULL, NULL, 'MANTENIMIENTO',GETDATE(),'999999999'

/*GATANT�AS AVALES FECHA PREESCRIPCION*/
INSERT INTO ADMINISTRACIONES_CONTENIDOS(Cod_Pantalla, Nombre_Propiedad, Des_Columna, Tab, Ind_Requerido, Ind_Modificar, Ind_Visible, Valor_Defecto, Mascara, Tipo_Contenido,Valor_Minimo,Valor_Maximo,
Css_Tipo,Metodo_Servicio_Web,Grupo_Validacion,Ind_Metodo_Insercion, Fecha_Ingreso, Cod_Usuario_Ingreso)
SELECT 24,'FechaPrescripcionGarantia','Fecha Prescripci�n Garant�a', 'Avales', 0, 0, 1,NULL,2,'CALENDAREXTENDER','DATETIME', NULL,
	'mainTableBoxesCss',NULL, NULL, 'MANTENIMIENTO',GETDATE(),'999999999'
