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
<Nombre>Operaciones_Garantias_Reales_Busqueda</Nombre>
<Sistema>N.A.</Sistema>
<Descripci�n>Procedimiento almacenado que consulta la informaci�n de Garant�as Av�les para relacionarla a las Operaciones</Descripci�n>
<Entradas>
		@piId_Tipo_Aval	= Tipo Aval
		@psNumero_Aval	= N�mero de Aval
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Mar�n</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>21/06/2016</Fecha>
<Versi�n>1.0</Versi�n>
<Historial>
    <Cambio>
            <Autor></Autor>
            <Requerimiento></Requerimiento>
            <Fecha></Fecha>
            <Descripci�n></Descripci�n>
    </Cambio>
</Historial>
******************************************************************************************************************************************************/
BEGIN 
       
	SELECT	Id_Garantia_Aval,
			Id_Tipo_Aval,
			Numero_Aval,
			Id_Tipo_Persona_Deudor,
			Id_Deudor,
			Monto_Avalado 
	FROM	dbo.GARANTIAS_AVALES 
	WHERE	Id_Tipo_Aval = @piId_Tipo_Aval
			AND Numero_Aval = @psNumero_Aval 
			AND Ind_Estado_Registro = 1

END 

