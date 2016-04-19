SELECT d.name BaseDatos ,s.name Esquema,t.name as Tabla FROM sys.tables t
inner join sys.schemas s
on s.schema_id = t.schema_id
inner join sys.databases d
on d.name = 'SIGANEM'
order by t.name, s.name