USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Garantias_Operaciones_Consulta_Detalle', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Garantias_Operaciones_Consulta_Detalle;
GO

CREATE PROCEDURE [dbo].[Garantias_Operaciones_Consulta_Detalle]
( 
    @piId_Garantia_Operacion	INT
)
AS 
/******************************************************************************************************************************************************
<Nombre>Garantias_Operaciones_Consulta_Detalle</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que consulta la información detallada en la tabla GARANTIAS_OPERACIONES</Descripción>
<Entradas>@piId_Garantia_Operacion = Llave de control interno</Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado C.</Autor>
<Fecha>Febrero del 2014</Fecha>
<Requerimiento>1-????????</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli Marín</Autor>
		<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
		<Fecha>21/06/2016</Fecha>
		<Descripción>Se agregan los campos en la consulta de salida "Id_Fideicomiso", "Id_Garantia_Aval" e "Id_Tipo_Indicador_Inscripcion"</Descripción>
	</Cambio>
	<Cambio>
		<Autor>Arnoldo Martinelli M.</Autor>
		<Requerimiento>RQ_MANT_2016050410580724: BACKLOG 3943</Requerimiento>
		<Fecha>Agosto 2016</Fecha>
		<Descripción>Se agregan los campos que permitien manipular el valor del monto del grado gravamen</Descripción>
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

	DECLARE @dtFecha_Calculo_Monto_Grado_Gravamen DATE

	SELECT	@dtFecha_Calculo_Monto_Grado_Gravamen = CAST(Fecha_Fin_Ejecucion AS DATE)
	FROM	dbo.BITACORAS_PROCESOS
	WHERE   Fecha_Fin_Ejecucion = CAST(GETDATE() AS DATE)


	

	SELECT	GOP.Id_Operacion
			,GOP.Id_Tipo_Garantia
			,GOP.Id_Garantia_Fiduciaria
			,GOP.Id_Garantia_Valor
			,GOP.Id_Garantia_Real
			,GOP.Ind_Estado_Replicado
			,GOP.Id_Tipo_Moneda_Monto_Gravamen
			,CASE 
				WHEN GOP.Ind_Metodo_Insercion = 'I' AND @dtFecha_Calculo_Monto_Grado_Gravamen IS NULL THEN GOP.Monto_Grado_Gravamen_Original
				WHEN GOP.Ind_Metodo_Insercion = 'M' AND ISNULL(Ind_Monto_Grado_Gravamen_Modificado, 0) = 1 THEN GOP.Monto_Grado_Gravamen_Modificado
				ELSE COALESCE(GOP.Monto_Grado_Gravamen, GOP.Monto_Grado_Gravamen_Modificado, GOP.Monto_Grado_Gravamen_Original)
			 END AS Monto_Grado_Gravamen,			
			GOP.Monto_Grado_Gravamen
			,GOP.Id_Grado_Gravamen
			,GOP.Fecha_Constitucion_Garantia
			,GOP.Id_Clase_Garantia_PRT17
			,GOP.Id_Tenencia_PRT_15
			,GOP.Id_Tenencia_PRT_17
			,GOP.Ind_Deudor_Habita
			,GOP.Ind_Recomendacion_Perito
			,GOP.Ind_Inspeccion_Garantia
			,GOP.Id_Tipo_Mitigador_Riesgo
			,GOP.Id_Tipo_Documento_Legal
			,GOP.Monto_Mitigador
			,GOP.Monto_Mitigador_Calculado
			,GOP.Porcentaje_Aceptacion_BCR
			,GOP.Porcentaje_Aceptacion_No_Terreno_SUGEF
			,GOP.Porcentaje_Aceptacion_Terreno_SUGEF			
			,GOP.Porcentaje_Responsabilidad_SUGEF
			,GOP.Porcentaje_Responsabilidad_Legal
			--,GOP.Ind_Poliza
			,GOP.Partido
			,GOP.Ind_Metodo_Insercion
			,GOP.Fecha_Ingreso
			,GOP.Cod_Usuario_Ingreso
			,GOP.Fecha_Ultima_Modificacion
			,GOP.Cod_Usuario_Ultima_Modificacion
			,USH.Nombre_Usuario Nombre_Usuario_Ingreso
			,US1.Nombre_Usuario Nombre_Usuario_Ultima_Modificacion
			,GOP.Id_Fideicomiso
			,GOP.Id_Garantia_Aval
			,GOP.Id_Tipo_Indicador_Inscripcion
	FROM	dbo.GARANTIAS_OPERACIONES GOP
			LEFT JOIN dbo.USUARIOS_HISTORICOS USH ON 
			USH.Cod_Usuario = GOP.Cod_Usuario_Ingreso
			LEFT JOIN dbo.USUARIOS_HISTORICOS US1 ON 
			US1.Cod_Usuario = GOP.Cod_Usuario_Ultima_Modificacion
	WHERE	GOP.Id_Garantia_Operacion = @piId_Garantia_Operacion 

END
GO


