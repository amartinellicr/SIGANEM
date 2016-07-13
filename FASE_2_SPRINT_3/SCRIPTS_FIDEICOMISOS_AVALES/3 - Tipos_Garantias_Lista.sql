USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Tipos_Garantias_Lista]
( 
    @psFiltro VARCHAR(11)
)
AS 
/******************************************************************************************************************************************************
<Nombre> Tipos_Garantias_Lista</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que consulta la información detallada en la tabla TIPOS_GARANTIAS </Descripción>
<Entradas>@psFiltro = Valor a filtrar</Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado</Autor>
<Fecha>Noviembre del 2013</Fecha>
<Requerimiento>1-23903815</Requerimiento>
<Versión>1.0</Versión>
<Historial>
    <Cambio>
        <Autor>Arnoldo Martinelli Marín</Autor>
        <Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
        <Fecha>21/06/2016</Fecha>
		<Descripción>Se ajusta el tamaño de la variable de entrada para que acepte los códigos completos enviados en el filtro</Descripción>
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
	DECLARE @SqlHelper VARCHAR(MAX)

	SET @SqlHelper=('SELECT	Id_Tipo_Garantia AS ''Valor'',
							CONVERT(VARCHAR,Cod_Tipo_Garantia)+'' - ''+Des_Tipo_Garantia AS ''Texto''
					FROM dbo.TIPOS_GARANTIAS 
					WHERE Ind_Estado_Registro = 1')
              
	IF @psFiltro <> '' AND @psFiltro IS NOT NULL
		--SET @SqlHelper=(@SqlHelper + 'WHERE Id_Tipo_Garantia = '+ @psFiltro)
		SET @SqlHelper=(@SqlHelper + ' AND Id_Tipo_Garantia IN ('+ @psFiltro+')')

	EXEC (@SqlHelper)

END 


