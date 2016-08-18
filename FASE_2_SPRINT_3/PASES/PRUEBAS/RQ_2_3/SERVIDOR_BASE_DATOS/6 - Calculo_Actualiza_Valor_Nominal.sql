USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Actualiza_Valor_Nominal', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Actualiza_Valor_Nominal;
GO


CREATE PROCEDURE [dbo].[Calculo_Actualiza_Valor_Nominal]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Actualiza_Valor_Nominal</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que se encarga de calcular y actualizar el valor nominal de las garantías de valor relacionadas a fideicomisos</Descripción>
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

    BEGIN TRANSACTION TRA_Actualizar
	BEGIN TRY

		/*ACTUALIZA EL VALOR NOMINAL DE GARANTIAS REALES*/
		UPDATE GFI
			SET Valor_Nominal = CONVERT(NUMERIC(24,2), (((ISNULL(GGR.Monto_Ultima_Tasacion_Terreno, 0) + ISNULL(GGR.Monto_Ultima_Tasacion_No_Terreno, 0)) * ISNULL(GFI.Porcentaje_Aceptacion_BCR, 0)) / 100))
		FROM 
			dbo.GARANTIAS_FIDEICOMETIDAS GFI
		INNER JOIN dbo.GARANTIAS_REALES GGR
			ON GGR.Id_Garantia_Real = GFI.Id_Garantia_Real
		WHERE GFI.Ind_Estado_Registro = 1
			AND GFI.Id_Garantia_Real IS NOT NULL
			AND GGR.Ind_Estado_Registro = 1

		/*ACTUALIZA EL VALOR NOMINAL DE GARANTIAS VALOR*/		
		UPDATE GFI
			SET Valor_Nominal = CONVERT(NUMERIC(24,2), ((ISNULL(GGV.Monto_Valor_Mercado_Colonizado, 0) * ISNULL(GFI.Porcentaje_Aceptacion_BCR, 0)) / 100))
		FROM 
			dbo.GARANTIAS_FIDEICOMETIDAS GFI
		INNER JOIN dbo.GARANTIAS_VALORES GGV
			ON GGV.Id_Garantia_Valor = GFI.Id_Garantia_Valor
		WHERE GFI.Ind_Estado_Registro = 1
			AND GFI.Id_Garantia_Valor IS NOT NULL
			AND GGV.Ind_Estado_Registro = 1


		/*ACTUALIZA VALOR NOMINAL DEL FIDEICOMISO*/
		UPDATE FID
			SET Valor_Nominal = GFI.Valor_Nominal_Total
		FROM 
			dbo.FIDEICOMISOS FID
		INNER JOIN (SELECT SUM(ISNULL(GF1.Valor_Nominal, 0)) AS Valor_Nominal_Total, GF1.Id_Fideicomiso
					FROM dbo.GARANTIAS_FIDEICOMETIDAS GF1
					WHERE GF1.Ind_Estado_Registro = 1
					GROUP BY GF1.Id_Fideicomiso) GFI
		ON GFI.Id_Fideicomiso = FID.Id_Fideicomiso
		WHERE FID.Ind_Estado_Registro = 1
				

		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Actualizar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Actualizar
	END CATCH

END


