USE [USSIGANEM]
GO


IF(OBJECT_ID('dbo.Garantias_Operaciones_Porcentaje_Aceptacion_Sugef','P') IS NOT NULL)
	DROP PROCEDURE dbo.Garantias_Operaciones_Porcentaje_Aceptacion_Sugef
GO

CREATE PROCEDURE [dbo].[Garantias_Operaciones_Porcentaje_Aceptacion_Sugef]
( 
	@piId_Tipo_Garantia INT
	,@piId_Tipo_Mitigador_Riesgo INT
)
AS 
/******************************************************************************************************************************************************
<Nombre>Garantias_Operaciones_Porcentaje_Aceptacion_Sugef</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que consulta la información de la tabla CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS para el calculo de Porcentaje_Aceptacion_Sugef</Descripción>
<Entradas>	@piId_Tipo_Garantia = Tipo Garantia
			@piId_Tipo_Mitigador_Riesgo = Tipo Mitigador 
</Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado </Autor>
<Fecha>Febrero del 2014</Fecha>
<Requerimiento>1-24493227</Requerimiento>
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
 
	DECLARE @SqlHelper VARCHAR(MAX)
	SET @SqlHelper=('SELECT DISTINCT 
						Id_Categoria_Calificacion_Riesgo_Tipo_Mitigador		AS ''Valor'',
						Porc_Aceptacion_Calificacion_Riesgo					AS ''Texto''											
					FROM dbo.TIPOS_MITIGADORES_RIESGOS TM
					INNER JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CCTMR
					ON TM.Id_Tipo_Mitigador_Riesgo = CCTMR.Id_Tipo_Mitigador_Riesgo
					WHERE CCTMR.Id_Tipo_Garantia = ' + CAST(@piId_Tipo_Garantia AS VARCHAR(10)) + 
					'AND TM.Id_Tipo_Mitigador_Riesgo = '+CAST(@piId_Tipo_Mitigador_Riesgo AS VARCHAR(10))
					+' AND TM.Ind_Estado_Registro = 1  AND CCTMR.Ind_Estado_Registro = 1 ')
	EXEC (@SqlHelper)

END 

