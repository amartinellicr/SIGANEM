USE [USSIGANEM]
GO

/* GARANTIAS OPERACIONES */

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES] ADD Id_Fideicomiso INT NULL
GO

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES] ADD Id_Garantia_Aval INT NULL
GO

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES] ADD Id_Tipo_Indicador_Inscripcion INT NULL
GO

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES] ALTER COLUMN Monto_Mitigador NUMERIC(24, 2) NULL
GO

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES]  WITH CHECK ADD  CONSTRAINT [GARANTIAS_OPERACIONES_FK_FIDEICOMISOS_15] FOREIGN KEY([Id_Fideicomiso])
REFERENCES [dbo].[FIDEICOMISOS] ([Id_Fideicomiso])
GO

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES] CHECK CONSTRAINT [GARANTIAS_OPERACIONES_FK_FIDEICOMISOS_15]
GO

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES]  WITH CHECK ADD  CONSTRAINT [GARANTIAS_OPERACIONES_FK_GARANTIAS_AVALES_16] FOREIGN KEY([Id_Garantia_Aval])
REFERENCES [dbo].[GARANTIAS_AVALES] ([Id_Garantia_Aval])
GO

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES] CHECK CONSTRAINT [GARANTIAS_OPERACIONES_FK_GARANTIAS_AVALES_16]
GO

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES]  WITH CHECK ADD  CONSTRAINT [GARANTIAS_OPERACIONES_FK_TIPOS_INDICADORES_INSCRIPCIONES_17] FOREIGN KEY([Id_Tipo_Indicador_Inscripcion])
REFERENCES [dbo].[TIPOS_INDICADORES_INSCRIPCIONES] ([Id_Tipo_Indicador_Inscripcion])
GO

ALTER TABLE [dbo].[GARANTIAS_OPERACIONES] CHECK CONSTRAINT [GARANTIAS_OPERACIONES_FK_TIPOS_INDICADORES_INSCRIPCIONES_17]
GO

/* GARANTIAS VALOR */

ALTER TABLE [dbo].[GARANTIAS_VALORES] ADD Monto_Valor_Mercado_Colonizado NUMERIC(22, 2) NULL
GO


/* GRADOS_PRIORIDADES */

ALTER TABLE [dbo].[GRADOS_PRIORIDADES] ADD Saldo_Prioridad_Colonizado DECIMAL(22, 2) NULL
GO

/* MONTO_MITIGADOR */

ALTER TABLE [dbo].[GARANTIAS_FIDEICOMETIDAS] ALTER COLUMN Monto_Mitigador NUMERIC(24, 2) NULL
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[Actualizar_Garantias_Operaciones_Avales]
   ON  [dbo].[GARANTIAS_AVALES]
   AFTER INSERT
AS
/******************************************************************************************************************************************************
<Nombre>Actualizar_Garantias_Operaciones_Avales</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Trrigger que se encarga de actualizar el ID del Aval en la tabla de GARANTIAS_OPERACIONES</Descripción>
<Entradas>
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Marín</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>28/06/2016</Fecha>
<Versión>1.0</Versión>
<Historial>
    <Cambio>
        <Autor></Autor>
        <Requerimiento></Requerimiento>
        <Fecha></Fecha>
        <Descripción></Descripción>
    </Cambio>
</Historial>
******************************************************************************************************************************************************/
 
BEGIN

	SET NOCOUNT ON;

	UPDATE GOP
	 SET GOP.Id_Garantia_Aval = INS.Id_Garantia_Aval
	FROM 
		dbo.GARANTIAS_OPERACIONES GOP
	INNER JOIN dbo.GARANTIAS_AVALES GAV
		ON GAV.Id_Garantia_Aval = GOP.Id_Garantia_Aval
	INNER JOIN inserted INS 
		ON 	GAV.Id_Tipo_Aval = INS.Id_Tipo_Aval
		AND GAV.Numero_Aval = INS.Numero_Aval
	WHERE 
		GOP.Ind_Estado_Registro = 1

END

GO




CREATE TRIGGER [dbo].[Actualizar_Garantias_Operaciones_Fideicomiso]
   ON  [dbo].[FIDEICOMISOS]
   AFTER INSERT
AS
/******************************************************************************************************************************************************
<Nombre>Actualizar_Garantias_Operaciones_Fideicomiso</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Trrigger que se encarga de actualizar el ID del Fideicomiso en la tabla de GARANTIAS_OPERACIONES</Descripción>
<Entradas>
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Marín</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>28/06/2016</Fecha>
<Versión>1.0</Versión>
<Historial>
    <Cambio>
        <Autor></Autor>
        <Requerimiento></Requerimiento>
        <Fecha></Fecha>
        <Descripción></Descripción>
    </Cambio>
</Historial>
******************************************************************************************************************************************************/
 
BEGIN

	SET NOCOUNT ON;

	UPDATE GOP
	 SET GOP.Id_Garantia_Aval = INS.Id_Fideicomiso
	FROM 
		dbo.GARANTIAS_OPERACIONES GOP
	INNER JOIN dbo.FIDEICOMISOS FID
		ON FID.Id_Fideicomiso = GOP.Id_Fideicomiso
	INNER JOIN inserted INS 
		ON 	FID.Id_Fideicomiso_BCR = INS.Id_Fideicomiso_BCR
		AND ISNULL(FID.Cod_Fideicomiso, '') = ISNULL(INS.Cod_Fideicomiso, '')
	WHERE 
		GOP.Ind_Estado_Registro = 1

END

GO


CREATE TRIGGER [dbo].[Actualizar_Garantias_Fideicometidas_Reales]
   ON  [dbo].[GARANTIAS_REALES]
   AFTER INSERT
AS
/******************************************************************************************************************************************************
<Nombre>Actualizar_Garantias_Fideicometidas_Reales</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Trrigger que se encarga de actualizar el ID de la garantía real en la tabla de GARANTIAS_FIDEICOMETIDAS</Descripción>
<Entradas>
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Marín</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>28/06/2016</Fecha>
<Versión>1.0</Versión>
<Historial>
    <Cambio>
        <Autor></Autor>
        <Requerimiento></Requerimiento>
        <Fecha></Fecha>
        <Descripción></Descripción>
    </Cambio>
</Historial>
******************************************************************************************************************************************************/
 
BEGIN

	SET NOCOUNT ON;

	UPDATE GFI
	 SET GFI.Id_Garantia_Real = INS.Id_Garantia_Real
	FROM 
		dbo.GARANTIAS_FIDEICOMETIDAS GFI
	INNER JOIN dbo.GARANTIAS_REALES GAR
		ON GAR.Id_Garantia_Real = GFI.Id_Garantia_Real
	INNER JOIN inserted INS 
	ON 	ISNULL(GAR.Id_Clase_Aeronave,-1) = ISNULL(INS.Id_Clase_Aeronave,-1)
		AND ISNULL(GAR.Id_Clase_Buque,-1) = ISNULL(INS.Id_Clase_Buque,-1)
		AND ISNULL(GAR.Id_Clase_Tipo_Bien,-1) = ISNULL(INS.Id_Clase_Tipo_Bien,-1)
		AND ISNULL(GAR.Id_Clase_Vehiculo,-1) = ISNULL(INS.Id_Clase_Vehiculo,-1)
		AND ISNULL(GAR.Id_Provincia,-1) = ISNULL(INS.Id_Provincia,-1)
		AND ISNULL(GAR.Id_Tipo_Bien,-1) = ISNULL(INS.Id_Tipo_Bien,-1)
		AND GAR.Codigo_Bien = INS.Codigo_Bien
		AND ISNULL(GAR.Id_Codigo_Duplicado,-1) = ISNULL(INS.Id_Codigo_Duplicado,-1)
		AND ISNULL(GAR.Id_Codigo_Horizontalidad,-1) = ISNULL(INS.Id_Codigo_Horizontalidad,-1)
		AND ISNULL(GAR.Formato_Identificacion_Vehiculo,-1) = ISNULL(INS.Formato_Identificacion_Vehiculo,-1)
	WHERE 
		GFI.Ind_Estado_Registro = 1

END

GO



CREATE TRIGGER [dbo].[Actualizar_Garantias_Fideicometidas_Valores]
   ON  [dbo].[GARANTIAS_VALORES]
   AFTER INSERT
AS
/******************************************************************************************************************************************************
<Nombre>Actualizar_Garantias_Fideicometidas_Valores</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Trrigger que se encarga de actualizar el ID de la garantía valor en la tabla de GARANTIAS_FIDEICOMETIDAS</Descripción>
<Entradas>
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Marín</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>28/06/2016</Fecha>
<Versión>1.0</Versión>
<Historial>
    <Cambio>
        <Autor></Autor>
        <Requerimiento></Requerimiento>
        <Fecha></Fecha>
        <Descripción></Descripción>
    </Cambio>
</Historial>
******************************************************************************************************************************************************/
 
BEGIN

	SET NOCOUNT ON;

	UPDATE GFI
	 SET GFI.Id_Garantia_Valor = INS.Id_Garantia_Valor
	FROM 
		dbo.GARANTIAS_FIDEICOMETIDAS GFI
	INNER JOIN dbo.GARANTIAS_VALORES GAV
		ON GAV.Id_Garantia_Valor = GFI.Id_Garantia_Valor
	INNER JOIN inserted INS 
		ON 	ISNULL(GAV.Id_Instrumento,-1) = ISNULL(INS.Id_Instrumento,-1)
		AND ISNULL(GAV.Id_Emisor,-1) = ISNULL(INS.Id_Emisor,-1)
		AND ISNULL(GAV.ISIN,-1) = ISNULL(INS.ISIN,-1)
		AND ISNULL(GAV.Serie,-1) = ISNULL(INS.Serie,-1)
		AND ISNULL(GAV.Cod_Garantia_BCR,-1) = ISNULL(INS.Cod_Garantia_BCR,-1)
	WHERE 
		GFI.Ind_Estado_Registro = 1

END

GO



