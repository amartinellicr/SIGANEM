USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Operaciones_Garantias_Avales_Busqueda', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Operaciones_Garantias_Avales_Busqueda;
GO


CREATE PROCEDURE [dbo].[Operaciones_Garantias_Avales_Busqueda]
( 
    @piId_Tipo_Aval								INT, 
	@psNumero_Aval								VARCHAR(30)
		
)
AS 
/******************************************************************************************************************************************************
<Nombre>Operaciones_Garantias_Avales_Busqueda</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que consulta la información de Garantías Aváles para relacionarla a las Operaciones</Descripción>
<Entradas>
		@piId_Tipo_Aval	= Tipo Aval
		@psNumero_Aval	= Número de Aval
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Marín</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>21/06/2016</Fecha>
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
       
	SELECT	GAV.Id_Garantia_Aval,
			GAV.Id_Tipo_Aval,
			GAV.Numero_Aval,
			CONVERT(VARCHAR, TPE.Id_Tipo_Persona)+' - '+ TPE.Des_Tipo_Persona AS 'Tipo_Persona_Deudor',
			TIA.Id_Avalista,
			GAV.Monto_Avalado 
	FROM	dbo.GARANTIAS_AVALES GAV
		INNER JOIN dbo.TIPOS_AVALES TIA
		ON TIA.Id_Tipo_Aval = GAV.Id_Tipo_Aval
		LEFT JOIN dbo.TIPOS_PERSONAS TPE
		ON TPE.Id_Tipo_Persona = TIA.Id_Tipo_Persona
		AND TPE.Ind_Estado_Registro = 1
	WHERE	GAV.Id_Tipo_Aval = @piId_Tipo_Aval
			AND GAV.Numero_Aval = @psNumero_Aval 
			AND GAV.Ind_Estado_Registro = 1

END 

