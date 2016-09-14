USE[SIGANEM]
GO


ALTER PROCEDURE [dbo].[Calculo_Monto_Tasacion_Actualizada_Terreno]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Monto_Tasacion_Actualizada_Terreno</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo automático monto tasación actualizada terreno
	Esta formulación aplica únicamente para bienes tipo 1 y 2
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Genoveva Salmeron</Autor>
<Fecha>Agosto 2015</Fecha>
<Requerimiento>RQ_MANT_2015042110384902_00040 – Monto tasación actualizada terreno y no terreno</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli M.</Autor>
		<Requerimiento>Modificación en el Mantenimiento de Garantías Reales (PBI 10800)</Requerimiento>
		<Fecha>Septiembre 2016</Fecha>
		<Descripción>Se elimina el proceso de cálculo establecido</Descripción>
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
	BEGIN TRANSACTION TRA_Insertar
	BEGIN TRY

		UPDATE		GR
		SET			GR.Monto_Tasacion_Actualizada_Terreno = GR.Monto_Ultima_Tasacion_Terreno
		FROM		dbo.GARANTIAS_REALES GR
		INNER JOIN dbo.TIPOS_BIENES TB 
			ON GR.Id_Tipo_Bien = TB.Id_Tipo_Bien 
		WHERE	TB.Cod_Tipo_Bien IN (1,2)
		AND		GR.Ind_Estado_Registro = 1
		AND		GR.Estado_Registro_Garantia = 1

		SELECT 0 AS Error, '' AS Mensaje

		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END
GO

