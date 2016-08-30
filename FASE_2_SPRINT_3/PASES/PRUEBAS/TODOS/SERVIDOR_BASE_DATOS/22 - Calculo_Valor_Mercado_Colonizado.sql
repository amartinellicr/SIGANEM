USE [USSIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Valor_Mercado_Colonizado', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Valor_Mercado_Colonizado;
GO


CREATE PROCEDURE [dbo].[Calculo_Valor_Mercado_Colonizado]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Valor_Mercado_Colonizado</Nombre>
<Sistema>N.A.</Sistema>
<Descripci�n>Procedimiento almacenado que se encarga de colonizar el monto del valor mercado de las garant�as de valor</Descripci�n>
<Entradas>
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli Mar�n</Autor>
<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
<Fecha>29/06/2016</Fecha>
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
			SET Monto_Valor_Mercado_Colonizado = Monto_Valor_Mercado * CASE TPM.Cod_Tipo_Moneda WHEN 2 THEN @VALOR ELSE 1 END
		FROM 
			dbo.GARANTIAS_VALORES G
		INNER JOIN dbo.TIPOS_MONEDAS TPM
			ON G.Id_Moneda_Valor_Mercado = TPM.Id_Tipo_Moneda
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

