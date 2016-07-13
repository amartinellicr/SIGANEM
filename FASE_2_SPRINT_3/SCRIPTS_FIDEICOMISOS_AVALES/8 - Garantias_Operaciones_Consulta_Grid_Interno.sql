USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Garantias_Operaciones_Consulta_Grid_Interno]
(
	@piId_Garantia_Operacion INT
)
AS 
/******************************************************************************************************************************************************
<Nombre>Garantias_Operaciones_Consulta_Grid_Interno</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que consulta las Gantías de Operaciones para el grid de Garantías Relacionadas </Descripción>
<Entradas></Entradas>
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
		<Descripción>Se agregan los campos en la consulta de salida "Id_Fideicomiso" e "Id_Garantia_Aval"</Descripción>
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

	SELECT	
			GOP.Id_Garantia_Operacion, 
			TG.Des_Tipo_Garantia,
			CASE 
				WHEN GOP.Id_Garantia_Fiduciaria IS NOT NULL THEN GF.Cod_Garantia 
				WHEN GOP.Id_Garantia_Valor IS NOT NULL THEN GV.Cod_Garantia_BCR 
				WHEN GOP.Id_Garantia_Real IS NOT NULL THEN GR.Codigo_Bien 
				WHEN GOP.Id_Fideicomiso IS NOT NULL THEN FID.Id_Fideicomiso_BCR
				WHEN GOP.Id_Garantia_Aval IS NOT NULL THEN GAV.Numero_Aval
			END AS Id_Garantia,
			CASE GOP.Ind_Estado_Replicado	WHEN 1 THEN 'Replicado' 
											WHEN 0 THEN 'Pendiente'  
											WHEN 2 THEN 'Actualizado' END AS Estado_Replicado,
			TB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien 
	FROM	dbo.GARANTIAS_OPERACIONES GOP
			INNER JOIN dbo.TIPOS_GARANTIAS TG
			ON GOP.Id_Tipo_Garantia = TG.Id_Tipo_Garantia 
			LEFT JOIN dbo.GARANTIAS_REALES GR
			ON GOP.Id_Garantia_Real = GR.Id_Garantia_Real
			AND GOP.Ind_Estado_Registro = GR.Ind_Estado_Registro  
			LEFT JOIN dbo.GARANTIAS_FIDUCIARIAS GF
			ON GOP.Id_Garantia_Fiduciaria = GF.Id_Garantia_Fiduciaria 
			AND GOP.Ind_Estado_Registro = GF.Ind_Estado_Registro 
			LEFT JOIN dbo.GARANTIAS_VALORES GV
			ON GOP.Id_Garantia_Valor = GV.Id_Garantia_Valor 
			AND GOP.Ind_Estado_Registro = GV.Ind_Estado_Registro 
			LEFT JOIN dbo.FIDEICOMISOS FID
			ON GOP.Id_Fideicomiso = FID.Id_Fideicomiso
			AND GOP.Ind_Estado_Registro = FID.Ind_Estado_Registro
			LEFT JOIN dbo.GARANTIAS_AVALES GAV
			ON GOP.Id_Garantia_Aval = GAV.Id_Garantia_Aval
			AND GOP.Ind_Estado_Registro = GAV.Ind_Estado_Registro
			LEFT JOIN dbo.TIPOS_BIENES TB
			ON GR.Id_Tipo_Bien = TB.Id_Tipo_Bien 
			LEFT JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON GR.Id_Tipo_Bien = CTB.Id_Tipo_Bien 
			AND GR.Id_Clase_Tipo_Bien = CTB.Id_Clase_Tipo_Bien 
	WHERE	GOP.Id_Operacion = @piId_Garantia_Operacion 
			AND GOP.Ind_Estado_Registro = 1
	ORDER BY 2,3 ASC
			
END 

