USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Calculo_Monto_Grado_Gravamen', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Calculo_Monto_Grado_Gravamen;
GO


CREATE PROCEDURE [dbo].[Calculo_Monto_Grado_Gravamen]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Monto_Grado_Gravamen</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo automático Monto Grado Gravamen
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Alexander Cruz</Autor>
<Fecha>Mayo 2016</Fecha>
<Requerimiento></Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli M.</Autor>
		<Requerimiento>RQ_MANT_2016050410580724: BACKLOG 3943</Requerimiento>
		<Fecha>Agosto 2016</Fecha>
		<Descripción>Se redefine la lógica del cálculo</Descripción>
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

		/*SE APLICA EL CALCULO PARA LAS OPERACIONES*/
		UPDATE GAROPER
			SET Monto_Grado_Gravamen = CASE 
											WHEN Saldo_Colonizado IS NULL THEN ISNULL(Monto_Grado_Gravamen_Modificado, Monto_Grado_Gravamen_Original)
											WHEN ISNULL(Saldo_Original_Colonizado,0) = 0 THEN ISNULL(Monto_Grado_Gravamen_Modificado, Monto_Grado_Gravamen_Original)
											ELSE ((	CASE 
														WHEN Monto_Grado_Gravamen_Modificado IS NULL THEN Monto_Grado_Gravamen_Original
														ELSE Monto_Grado_Gravamen_Modificado
													END
												 ) * Saldo_Colonizado) / Saldo_Original_Colonizado 
									   END,
				Ind_Monto_Grado_Gravamen_Modificado = 0 
		FROM 
			dbo.OPERACIONES OPE
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON OPE.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TIP
			ON OPE.Id_Tipo_Operacion = TIP.Id_Tipo_Operacion
		WHERE 
			TIP.Cod_Tipo_Operacion = 1
		AND OPE.Ind_Estado_Registro = 1
		AND GAROPER.Ind_Estado_Registro = 1

		
		/*SE APLICA EL CALCULO PARA LOS CONTRATOS*/
		UPDATE GAROPER
			SET Monto_Grado_Gravamen =	CASE 
											WHEN Monto_Grado_Gravamen_Modificado IS NULL THEN Monto_Grado_Gravamen_Original
											ELSE Monto_Grado_Gravamen_Modificado
										END,												 
				Ind_Monto_Grado_Gravamen_Modificado = 0 
		FROM 
			dbo.OPERACIONES OPE
		INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
			ON OPE.Id_Operacion = GAROPER.Id_Operacion
		INNER JOIN dbo.TIPOS_OPERACIONES TIP
			ON OPE.Id_Tipo_Operacion = TIP.Id_Tipo_Operacion
		WHERE 
			TIP.Cod_Tipo_Operacion = 2
		AND OPE.Ind_Estado_Registro = 1
		AND GAROPER.Ind_Estado_Registro = 1


		SELECT 0 AS Error, '' AS Mensaje

		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END


