
DROP TABLE #TEMP_FORANEAS
GO 
DROP TABLE #FORANEAS
GO


SELECT
	ROW_NUMBER() OVER (ORDER BY o1.name,c1.name) ID,
	ROW_NUMBER() OVER (PARTITION BY o1.name,c1.name ORDER BY o1.name,c1.name) ID_1,
    o1.name AS FK_table,
    c1.name AS FK_column,
    o2.name AS PK_table,
    c2.name AS PK_column,
    fk.name AS FK_name--,
    --pk.name AS PK_name
	INTO #TEMP_FORANEAS
FROM sys.objects o1
    INNER JOIN sys.foreign_keys fk
        ON o1.object_id = fk.parent_object_id
    INNER JOIN sys.foreign_key_columns fkc
        ON fk.object_id = fkc.constraint_object_id
    INNER JOIN sys.columns c1
        ON fkc.parent_object_id = c1.object_id
        AND fkc.parent_column_id = c1.column_id
    INNER JOIN sys.columns c2
        ON fkc.referenced_object_id = c2.object_id
        AND fkc.referenced_column_id = c2.column_id
    INNER JOIN sys.objects o2
        ON fk.referenced_object_id = o2.object_id
    --INNER JOIN sys.key_constraints pk
    --    ON fk.parent_object_id = pk.parent_object_id
    --    AND fk.key_index_id = pk.unique_index_id
ORDER BY o1.name, o2.name, fkc.constraint_column_id

CREATE TABLE #FORANEAS
(
	TABLA VARCHAR(50) COLLATE Latin1_General_CS_AS,
	COLUMNA VARCHAR(50)COLLATE Latin1_General_CS_AS,
	TABLA_F VARCHAR(max) COLLATE SQL_Latin1_General_CP1_CI_AS,
	COLUMNA_F VARCHAR(max) COLLATE SQL_Latin1_General_CP1_CI_AS,
	LLAVE_F VARCHAR(max) COLLATE SQL_Latin1_General_CP1_CI_AS
)

--Latin1_General_CS_AS
--SQL_Latin1_General_CP1_CI_AS

DECLARE @MIN INT
DECLARE @MAX INT

SELECT @MIN = MIN(ID) , @MAX = MAX(ID) FROM #TEMP_FORANEAS

WHILE @MIN <= @MAX
BEGIN
	DECLARE @MIN_1 INT
	DECLARE @MAX_1 INT
	DECLARE @TABLA_F VARCHAR(max) = '',
			@COLUMNA_F VARCHAR(max) = '',
			@LLAVE_F VARCHAR(max) = '',	
			@TABLA VARCHAR(50),
			@COLUMNA VARCHAR(50)


	SELECT @MIN_1 = MIN(ID_1) , @MAX_1 = MAX(ID_1) FROM #TEMP_FORANEAS
	WHERE ID = @MIN

	WHILE @MIN_1 <= @MAX_1
	BEGIN

		SELECT 
			@TABLA_F = @TABLA_F + PK_table + ', ',
			@COLUMNA_F = @COLUMNA_F + PK_column + ', ',
			@LLAVE_F = @LLAVE_F + FK_name + ', ',
			@TABLA = FK_table,
			@COLUMNA = FK_column 
		FROM #TEMP_FORANEAS
		WHERE ID_1 = @MIN_1
		AND ID = @MIN

		SELECT @MIN_1 = MIN(ID_1) FROM #TEMP_FORANEAS
		WHERE ID_1 > @MIN_1
		AND ID = @MIN

	END

	SET @TABLA_F = LEFT(@TABLA_F,LEN(@TABLA_F)-1)
	SET @COLUMNA_F = LEFT(@COLUMNA_F,LEN(@COLUMNA_F)-1)
	SET @LLAVE_F = LEFT(@LLAVE_F,LEN(@LLAVE_F)-1)

	INSERT INTO #FORANEAS
	SELECT  
			@TABLA,
			@COLUMNA,
			@TABLA_F,
			@COLUMNA_F,
			@LLAVE_F

	SELECT @MIN = MIN(ID) FROM #TEMP_FORANEAS
	WHERE ID > @MIN

END

SELECT 
	d.name BaseDatos,
	s.name Esquema,
	t.name as Tabla, 
	c.name as Campo,
	'' descripcion, 
	'' reglasintaxis,
	t1.name as Tipo,
	case t1.name when 'datetime' then '' 
				 when 'decimal' then convert(varchar,c.precision) + ', '+ convert(varchar,c.scale)
				 when 'numeric' then convert(varchar,c.precision) + ', '+ convert(varchar,c.scale)
				 else convert(varchar,c.max_length)
	end 
	as Longitud,
	CASE 
		WHEN A.TEXT IS NULL THEN ''
		ELSE REPLACE((REPLACE(A.TEXT, '(', '')), ')', '')
	END as Valor_Defecto,
	CASE c.is_nullable WHEN 1 THEN 'SI' ELSE 'NO' END as Admite_Nulo,
	CASE WHEN ic.object_id IS NULL THEN 'NO' ELSE 'SI' END as PK,
	CASE WHEN Fk.TABLA_F IS NULL THEN 'NO' ELSE 'SI' END AS FK,
	CASE WHEN Fk.TABLA_F IS NULL THEN '' ELSE Fk.TABLA_F END AS 'Tabla Relacion FK',
	CASE WHEN Fk.COLUMNA_F IS NULL THEN '' ELSE Fk.COLUMNA_F END AS  'Atributo Foraneo',
	CASE WHEN Fk.LLAVE_F IS NULL THEN '' ELSE Fk.LLAVE_F END AS 'Constraint'
FROM 
	sys.tables t
inner join sys.schemas s
	on s.schema_id = t.schema_id
inner join sys.columns c
	on c.object_id = t.object_id
left join sys.index_columns ic
	on ic.column_id = c.column_id
    AND ic.object_id = c.object_id
inner join sys.types t1
	on t1.user_type_id = c.user_type_id
left join #FORANEAS Fk
	on Fk.TABLA COLLATE SQL_Latin1_General_CP1_CI_AS = t.name
	AND Fk.COLUMNA COLLATE SQL_Latin1_General_CP1_CI_AS = c.name
inner join sys.databases d
	on d.name = 'USSIGANEM'
	INNER JOIN (
SELECT SO.id AS ID_TABLA, SC.colid, SM.TEXT
FROM dbo.sysobjects SO INNER JOIN dbo.syscolumns SC ON SO.id = SC.id 
LEFT JOIN dbo.syscomments SM ON SC.cdefault = SM.id  
WHERE SO.xtype = 'U') A
ON t.object_id = ID_TABLA
AND A.colid = c.column_id
order by 
	t.name, 
	s.name