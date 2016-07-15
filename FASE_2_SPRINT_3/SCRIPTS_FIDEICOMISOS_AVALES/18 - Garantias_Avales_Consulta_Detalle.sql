USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Garantias_Avales_Consulta_Detalle', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Garantias_Avales_Consulta_Detalle;
GO


CREATE PROCEDURE [dbo].[Garantias_Avales_Consulta_Detalle]
( 
    @piId_Garantia_Aval	INT
)
AS 
/******************************************************************************************************************************************************
<Nombre> Garantias_Avales_Consulta_Detalle</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que consulta la información en la tabla GARANTIAS_AVALES </Descripción>
<Entradas>@piId_Garantia_Aval = Llave de control interna</Entradas>
<Salidas></Salidas>
<Autor>Alexander Cruz</Autor>
<Fecha>Enero 2016</Fecha>
<Requerimiento></Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli Marín</Autor>
		<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
		<Fecha>21/06/2016</Fecha>
		<Descripción>Se agrega la información referente al tip ode persona del avalista</Descripción>
	</Cambio>
    <Cambio>
        <Autor></Autor>
        <Requerimiento></Requerimiento>
        <Fecha></Fecha>
        <Descripción></Descripción>
    </Cambio>
</Historial>
******************************************************************************************************************************************************/
BEGIN 

		SELECT	GRI.Id_Garantia_Aval, 
				GRI.Id_Tipo_Aval, 
				GRI.Numero_Aval, 
				GRI.Monto_Avalado, 
				GRI.Cod_Garantia_BCR, 
				GRI.Fecha_Emision, 
				GRI.Fecha_Vencimiento, 
				GRI.Id_Tipo_Persona_Deudor, 
				GRI.Id_Deudor, 
				GRI.Id_Tipo_Asignacion_Calificacion, 
				GRI.Id_Plazo_Calificacion, 
				GRI.Id_Empresa_Calificadora, 
				GRI.Id_Categoria_Riesgo_Empresa_Calificadora, 
				GRI.Id_Calificacion_Empresa_Calificadora,
				GRI.Ind_Metodo_Insercion,	
				GRI.Fecha_Ingreso,	
				GRI.Cod_Usuario_Ingreso,	
				GRI.Fecha_Ultima_Modificacion,	
				GRI.Cod_Usuario_Ultima_Modificacion,
				USH.Nombre_Usuario Nombre_Usuario_Ingreso,
				US1.Nombre_Usuario Nombre_Usuario_Ultima_Modificacion,
				CONVERT(VARCHAR, TPE.Id_Tipo_Persona)+' - '+ TPE.Des_Tipo_Persona AS 'Tipo_Persona_Deudor'
		FROM	dbo.GARANTIAS_AVALES GRI 	
				LEFT JOIN dbo.USUARIOS_HISTORICOS USH ON 
				USH.Cod_Usuario = GRI.Cod_Usuario_Ingreso
				LEFT JOIN dbo.USUARIOS_HISTORICOS US1 ON 
				US1.Cod_Usuario = GRI.Cod_Usuario_Ultima_Modificacion
				LEFT JOIN dbo.TIPOS_PERSONAS TPE
				ON TPE.Id_Tipo_Persona = GRI.Id_Tipo_Persona_Deudor
				AND TPE.Ind_Estado_Registro = 1
		 WHERE	Id_Garantia_Aval = @piId_Garantia_Aval

END 

