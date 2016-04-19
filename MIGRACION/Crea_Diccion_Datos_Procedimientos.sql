--USE [SIGANEM]
--GO
/****** Object:  StoredProcedure [dbo].[CREAINSERTAR]    Script Date: 17/10/2013 16:31:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[General_Crea_Dicc_Dat_Procedim]

AS
DECLARE @SQL VARCHAR(MAX),
	@TABLA VARCHAR(100),
	@TABLA1 VARCHAR(100),
	@COLUMNAS VARCHAR(300),
	@PARAM_ENTRADA VARCHAR(MAX),
	@PARAM_ENTRADA1 VARCHAR(MAX),
	@NOMBR_TABLA VARCHAR(MAX),
	@PARAM_COLUMNAS2 VARCHAR(300),
	@PARAM_DESCRIPCION VARCHAR(MAX),
	@PARAM_SALIDA VARCHAR(MAX),
	@CONT INT,
	@SEPARADOR VARCHAR(5),
	@TYPE VARCHAR(5)

DECLARE TABLAS CURSOR FOR
SELECT	SO.name 
FROM	sys.objects SO 
WHERE	SO.type in ('P', 'FN', 'TF', 'TR')
AND SO.name NOT LIKE 'sp%'
ORDER BY SO.name

OPEN TABLAS
FETCH NEXT FROM TABLAS INTO @TABLA 

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @NOMBR_TABLA = ''
	SET @PARAM_COLUMNAS2 = ''
	SET @PARAM_ENTRADA = ''
	SET @PARAM_ENTRADA1 = ''
	SET @PARAM_SALIDA = ''
	SET @CONT = 1
	SET @SEPARADOR =  ''


	DECLARE COLUMNAS CURSOR FOR
	SELECT SP.name FROM sys.objects SO
	INNER JOIN sys.parameters SP
	ON SO.object_id = SP.object_id
	WHERE SO.name = @TABLA

	SELECT @TYPE = type FROM sys.objects SO
	INNER JOIN sys.parameters SP
	ON SO.object_id = SP.object_id
	WHERE SO.name = @TABLA

	SET @PARAM_DESCRIPCION = CASE @TYPE WHEN 'P' THEN 'Procedimiento'
												  WHEN 'FN' THEN 'Funcion'
												  WHEN 'TF' THEN 'Funcion' 
												  WHEN 'TR' THEN 'Trigger' END + ' almacenado que '
	
	OPEN COLUMNAS
	FETCH NEXT FROM COLUMNAS
	INTO @PARAM_ENTRADA
	WHILE @@FETCH_STATUS = 0
	BEGIN

		IF @CONT <> 1
			BEGIN
				SET @SEPARADOR = ','
			END

		SET @PARAM_ENTRADA1 = @PARAM_ENTRADA1 +  @SEPARADOR  +  @PARAM_ENTRADA
		
		FETCH NEXT FROM COLUMNAS INTO @PARAM_ENTRADA

		SET @CONT = @CONT + 1
		--PRINT @CONT
	END

	--SELECT @TABLA1 = dbo.udf_TitleCase(@TABLA)
	SELECT @TABLA1 = @TABLA

	IF @TABLA LIKE '%Actualiza%'
		BEGIN
			SET @PARAM_DESCRIPCION  = @PARAM_DESCRIPCION + 'actualiza la información en la tabla '
			SET @PARAM_SALIDA = 'Estado,NumeroError' 
			--SET @NOMBR_TABLA = UPPER(SUBSTRING(@TABLA, 1, CHARINDEX('Actualiza',@TABLA)-2))
			--SET @NOMBR_TABLA = @TABLA--UPPER(SUBSTRING(@TABLA,1, CHARINDEX('_A',@TABLA)))
		END

	IF @TABLA LIKE '%Inserta%'
		BEGIN
			SET @PARAM_DESCRIPCION  = @PARAM_DESCRIPCION + 'inserta la información en la tabla '
			SET @PARAM_SALIDA = 'Estado,NumeroError' 
			--SET @NOMBR_TABLA = @TABLA--UPPER(SUBSTRING(@TABLA, 1, CHARINDEX('Inserta',@TABLA)-2))
		END

	IF @TABLA LIKE '%Elimina%'
		BEGIN
			SET @PARAM_DESCRIPCION  = @PARAM_DESCRIPCION + 'elimina la información en la tabla '
			SET @PARAM_SALIDA = 'Estado,NumeroError' 
			--SET @NOMBR_TABLA = @TABLA--UPPER(SUBSTRING(@TABLA, 1, CHARINDEX('Elimina',@TABLA)-2))
		END

	IF @TABLA LIKE '%Consulta%'
		BEGIN
			SET @PARAM_DESCRIPCION  = @PARAM_DESCRIPCION + 'consulta la información en la tabla '
			SET @PARAM_SALIDA = '' 
			--SET @NOMBR_TABLA = @TABLA--UPPER(SUBSTRING(@TABLA, 1, CHARINDEX('Consulta',@TABLA)-2))
		END

	IF @TABLA LIKE '%Consulta%' AND  @TABLA LIKE '%Detalle%'
		BEGIN
			SET @PARAM_DESCRIPCION  = @PARAM_DESCRIPCION + 'consulta el detalle de la información en la tabla '
			SET @PARAM_SALIDA = '' 
			--SET @NOMBR_TABLA = @TABLA--UPPER(SUBSTRING(@TABLA, 1, CHARINDEX('Consulta',@TABLA)-2))
		END

	IF @TABLA LIKE '%Total%'
		BEGIN
			SET @PARAM_DESCRIPCION  = @PARAM_DESCRIPCION + ' indica el total de filas para los filtros solicitados en la tabla '
			SET @PARAM_SALIDA = '' 
			--SET @NOMBR_TABLA = @TABLA--UPPER(SUBSTRING(@TABLA, 1, CHARINDEX('Total',@TABLA)-2))
		END

	IF @TABLA LIKE '%Lista%'
		BEGIN
			SET @PARAM_DESCRIPCION  = @PARAM_DESCRIPCION + ' consulta para crear una lista de la tabla '
			SET @PARAM_SALIDA = '' 
			--SET @NOMBR_TABLA =@TABLA --UPPER(SUBSTRING(@TABLA, 1, CHARINDEX('Lista',@TABLA)-2))
		END

	SELECT @NOMBR_TABLA = T.name
	FROM sys.tables T
	WHERE UPPER(@TABLA) LIKE '%'+ T.name +'%' 

	SET @PARAM_DESCRIPCION = @PARAM_DESCRIPCION + @NOMBR_TABLA

	SELECT @SQL  = 
	'SIGANEM' +'	' + @TABLA +'	' +CASE @TYPE WHEN 'P' THEN 'Procedimiento'
												  WHEN 'FN' THEN 'Funcion'
												  WHEN 'TF' THEN 'Funcion' 
												  WHEN 'TR' THEN 'Trigger' END+'	' + @PARAM_ENTRADA1 +'	' + @PARAM_SALIDA +'	' + @PARAM_DESCRIPCION 
	
		
	PRINT @SQL

	CLOSE COLUMNAS
	DEALLOCATE COLUMNAS

FETCH NEXT FROM TABLAS INTO @TABLA


END
CLOSE TABLAS
DEALLOCATE TABLAS

GO

exec [General_Crea_Dicc_Dat_Procedim]