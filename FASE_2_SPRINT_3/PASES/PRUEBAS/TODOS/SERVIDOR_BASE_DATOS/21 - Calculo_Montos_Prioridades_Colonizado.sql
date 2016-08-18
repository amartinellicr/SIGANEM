USE [USSIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Montos_Prioridades_Colonizado', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Montos_Prioridades_Colonizado;
GO


CREATE PROCEDURE [dbo].[Calculo_Montos_Prioridades_Colonizado]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Montos_Prioridades_Colonizado</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que se encarga de colonizar el monto de la prioridad</Descripción>
<Entradas>
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Marín</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>29/06/2016</Fecha>
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
	BEGIN TRANSACTION TRA_Insertar
	BEGIN TRY

		DECLARE @VALOR DECIMAL(6,2) 

		SELECT TOP 1 
			@VALOR = Valor 
		FROM 
			dbo.TIPOS_CAMBIOS
		ORDER BY 
			Fecha DESC

		UPDATE G
			SET Saldo_Prioridad_Colonizado = Saldo_Prioridad * CASE TPM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END
		FROM 
			dbo.GRADOS_PRIORIDADES G
		INNER JOIN dbo.TIPOS_MONEDAS TPM
			ON G.Id_Tipo_Moneda = TPM.Id_Tipo_Moneda
		WHERE 
			G.Ind_Estado_Registro = 1

		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END


