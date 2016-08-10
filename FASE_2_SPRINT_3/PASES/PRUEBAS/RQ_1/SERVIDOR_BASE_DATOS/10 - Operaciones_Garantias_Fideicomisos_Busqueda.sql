USE [USSIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Operaciones_Garantias_Fideicomisos_Busqueda', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Operaciones_Garantias_Fideicomisos_Busqueda;
GO


CREATE PROCEDURE [dbo].[Operaciones_Garantias_Fideicomisos_Busqueda]
( 
    @psId_Fideicomiso_BCR							VARCHAR(14)	
)
AS 
/******************************************************************************************************************************************************
<Nombre>Operaciones_Garantias_Reales_Busqueda</Nombre>
<Sistema>N.A.</Sistema>
<Descripci�n>Procedimiento almacenado que consulta la informaci�n de Garant�as Fideicomisos para relacionarla a las Operaciones</Descripci�n>
<Entradas>
		@psId_Fideicomiso_BCR	= Identificaci�n del Fideicomiso para el BCR 
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
       
	SELECT	FID.Id_Fideicomiso,
			FID.Id_Fideicomiso_BCR,
			CONVERT(VARCHAR, TIM.Cod_Tipo_Moneda) + ' - ' + TIM.Des_Tipo_Moneda AS 'Tipo_Moneda_Valor_Nominal',
			FID.Valor_Nominal
	FROM	dbo.FIDEICOMISOS FID
		LEFT JOIN dbo.TIPOS_MONEDAS TIM
		ON TIM.Id_Tipo_Moneda = FID.Id_Tipo_Moneda_Valor_Nominal
	WHERE	FID.Id_Fideicomiso_BCR = @psId_Fideicomiso_BCR
			AND FID.Ind_Estado_Registro = 1

END 

