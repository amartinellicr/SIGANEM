USE [SIGANEM]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Calculo_Saldo_Grado_Gravamen_Colonizado]

SELECT	'Return Value' = @return_value


EXEC	@return_value = [dbo].[Calculo_Monto_Tasacion_Actualizada_Terreno]

SELECT	'Return Value' = @return_value

EXEC	@return_value = [dbo].[Calculo_Monto_Tasacion_Actualizada_No_Terreno]

SELECT	'Return Value' = @return_value

EXEC	@return_value = [dbo].[Calculo_Porcentaje_Aceptacion_No_Terreno_SUGEF_Fideicometida]

SELECT	'Return Value' = @return_value

EXEC	@return_value = [dbo].[Calculo_Porcentaje_Aceptacion_Terreno_SUGEF_Fideicometida]

SELECT	'Return Value' = @return_value


EXEC	@return_value = [dbo].[Calculo_Actualiza_Valor_Nominal]

SELECT	'Return Value' = @return_value



EXEC	@return_value = [dbo].[Calculo_Monto_Mitigador_Calculado_Fideicometido]

SELECT	'Return Value' = @return_value


