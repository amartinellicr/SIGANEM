
--ESCENARIO 2
/*
0132101025768559 / CRG0000B91G6
01230012401209 / FS06
*/

UPDATE dbo.GARANTIAS_VALORES
SET Estado_Registro_Garantia = 1,
	Id_Estado_Garantia = 4,
	Id_Moneda_Valor_Facial = 1,
	Id_Moneda_Valor_Mercado = 1
WHERE Id_Garantia_Valor IN (1183, 1175)

INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],          [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia],                     [Fecha_Prescripcion_Garantia],                     [Fecha_Constitucion_Garantia],                [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador],              [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
46183,          4,                  NULL,                     1183,                NULL,               0,                      2,                               CAST(1000.00 AS Numeric(22, 2)), 1,                   CAST(N'2014-08-27 00:00:00.000' AS DateTime),     CAST(N'2014-08-27 00:00:00.000' AS DateTime),      CAST(N'2014-08-27 00:00:00.000' AS DateTime), 21,                        28,                   NULL,                 0,                   0,                          0,                         1,                          22,                        CAST(200.00 AS Numeric(24, 2)), CAST(80.00 AS Numeric(5, 2)), CAST(4.00 AS Numeric(5, 2)),        NULL,      N'MANTENIMIENTO',       CAST(N'2015-01-07 11:05:21.183' AS DateTime), N'113370655',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  NULL,             NULL,               NULL)

INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],          [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia],                     [Fecha_Prescripcion_Garantia],                     [Fecha_Constitucion_Garantia],                [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador],              [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
1301,           4,                  NULL,                     1175,                NULL,               0,                      2,                               CAST(1000.00 AS Numeric(22, 2)), 1,                   CAST(N'2014-08-27 00:00:00.000' AS DateTime),     CAST(N'2014-08-27 00:00:00.000' AS DateTime),      CAST(N'2014-08-27 00:00:00.000' AS DateTime), 21,                        28,                   NULL,                 0,                   0,                          0,                         1,                          22,                        CAST(200.00 AS Numeric(24, 2)), CAST(80.00 AS Numeric(5, 2)), CAST(4.00 AS Numeric(5, 2)),        NULL,      N'MANTENIMIENTO',       CAST(N'2015-01-07 11:05:21.183' AS DateTime), N'113370655',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  NULL,             NULL,               NULL)

/*
delete from dbo.GARANTIAS_REALES_INSCRIPCIONES where Id_Garantia_Operacion in (1356, 49107,59846,59847,6523)
delete from dbo.GARANTIAS_OPERACIONES where Id_Operacion in (46183, 1301)

select * from dbo.GARANTIAS_OPERACIONES where Id_Operacion in (46183, 1301)

select * from dbo.GARANTIAS_REALES_INSCRIPCIONES where Id_Garantia_Operacion in (1356, 49107,59846,59847)
*/


--ESCENARIO 3


--INSERT [dbo].[GARANTIAS_OPERACIONES] (
--[Id_Garantia_Operacion], [Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen], [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR], [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso], [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
--59712,                   56705,          3,                  NULL,                     NULL,                12546, 0, 1, CAST(31357816.01 AS Numeric(22, 2)), 1, CAST(N'2040-08-19 00:00:00.000' AS DateTime), CAST(N'2050-08-19 00:00:00.000' AS DateTime), CAST(N'2010-08-18 00:00:00.000' AS DateTime), 11, NULL, 1, 0, 1, 1, 3, 2, NULL, CAST(85.00 AS Numeric(5, 2)), CAST(98.77 AS Numeric(5, 2)), 2, N'MIGRACION', CAST(N'2016-06-24 21:35:40.757' AS DateTime), N'999999999', NULL, NULL, 1, N'I', CAST(15800043.55 AS Decimal(22, 2)), NULL, CAST(40.00 AS Decimal(5, 2)), CAST(40.00 AS Decimal(5, 2)), NULL, NULL, NULL)

--ESCENARIO 4

INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
46183,          8,                  NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  7,                NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
1301,          8,                  NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  8,                NULL,                NULL)


--delete from dbo.GARANTIAS_REALES_INSCRIPCIONES where Id_Garantia_Operacion in (49105, 59852)
--delete from dbo.GARANTIAS_OPERACIONES where Id_Operacion in (46183, 1301)

--select * from dbo.GARANTIAS_OPERACIONES where Id_Operacion in (46183, 46181)

--ESCENARIO 5

--select * from dbo.GARANTIAS_AVALES where Numero_Aval = 'BCR2016071900001'
--select * from dbo.GARANTIAS_OPERACIONES where Id_Garantia_Aval = 66

--delete from dbo.GARANTIAS_REALES_INSCRIPCIONES where Id_Garantia_Operacion in (6520, 6552)
--delete from dbo.GARANTIAS_OPERACIONES where Id_Garantia_Operacion in (6520, 6552)




--ESCENARIO 6

SELECT *
FROM dbo.GARANTIAS_VALORES
WHERE Id_Garantia_Valor = 1297


select *
from dbo.GARANTIAS_OPERACIONES 
where Id_Operacion = 1128
and Ind_Estado_Registro = 1

/*

delete from dbo.GARANTIAS_REALES_INSCRIPCIONES where Id_Garantia_Operacion in (3279, 3288, 3294, 3297, 3300, 3303, 3306, 3311, 3314, 3318,
3348, 3355, 5117, 5118, 5139,5151,5152,5163,5164,5169,5203,6116,6117,6118,6119,6120,60045,60046,60047,60048,60049,60050,60052,60053,
60054,60056,60057,60058,60060,60061,60062,
3283, 5119,5120,5121,6122,60044,60051,60055,60059,60063)

select * from dbo.GARANTIAS_OPERACIONES
where  Id_Operacion = 1128
and Id_Garantia_Operacion <> 6121
and Id_Tipo_Garantia = 3


delete from dbo.GARANTIAS_OPERACIONES
where  Id_Operacion = 1128
and Id_Garantia_Operacion <> 6121
and Id_Tipo_Garantia = 4
*/


--ESCENARIO 7
SELECT *
FROM dbo.GARANTIAS_REALES 
WHERE Id_Garantia_Real = 2598


--ESCENARIO 8

SELECT * FROM dbo.FIDEICOMISOS WHERE Id_Fideicomiso = 6


--ESCENARIO 9

SELECT *
FROM dbo.GARANTIAS_AVALES WHERE Id_Garantia_Aval = 62

UPDATE dbo.GARANTIAS_OPERACIONES
SET Id_Garantia_Aval = 62
WHERE Id_Garantia_Operacion IN (59789, 6528)


--INSERT [dbo].[GARANTIAS_OPERACIONES] (
--[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
--1104,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  73,               NULL,                NULL)

--INSERT [dbo].[GARANTIAS_OPERACIONES] (
--[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
--1305,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  73,               NULL,                NULL)


--ESCENARIO 10
SELECT *
FROM dbo.GARANTIAS_REALES
WHERE Id_Garantia_Real IN (19374, 5985) --= 38758


SELECT *
FROM dbo.GARANTIAS_VALORES
WHERE Id_Garantia_Valor = 1335--1275

UPDATE dbo.GARANTIAS_VALORES
SET Cod_Garantia_BCR = '45340015',
	Estado_Registro_Garantia = 1,
	Ind_Estado_Registro = 1,
	Fecha_Vencimiento = '20210405',
	Id_Estado_Garantia = 1
WHERE Id_Garantia_Valor = 1335

SELECT *
FROM dbo.FIDEICOMISOS WHERE Id_Fideicomiso = 76

SELECT *
FROM dbo.GARANTIAS_OPERACIONES
WHERE Id_Garantia_Real = 38758--IN (19374, 5985) --= 38758
AND Ind_Estado_Registro = 1


SELECT *
FROM dbo.GARANTIAS_OPERACIONES
WHERE Id_Garantia_Valor = 34
AND Ind_Estado_Registro = 1

SELECT *
FROM dbo.GARANTIAS_OPERACIONES
WHERE Id_Operacion =  44061--1198
AND Ind_Estado_Registro = 1


delete from dbo.GARANTIAS_REALES_INSCRIPCIONES where Id_Garantia_Operacion =  58874
delete from dbo.GARANTIAS_OPERACIONES
where Id_Garantia_Operacion = 58874


/*

--SELECT *
--FROM dbo.GARANTIAS_VALORES A
--WHERE A.Ind_Estado_Registro = 1
--AND NOT EXISTS (SELECT 1 
--				 FROM dbo.GARANTIAS_OPERACIONES C 
--				 WHERE C.Id_Garantia_Valor = A.Id_Garantia_Valor)


SELECT *
FROM dbo.OPERACIONES A
INNER JOIN dbo.GARANTIAS_OPERACIONES B
ON B.Id_Operacion = A.Id_Operacion
AND B.Ind_Estado_Registro = 1
AND B.Id_Tipo_Garantia in (3,4,11)
INNER JOIN dbo.prmoc C
ON C.prmoc_pco_conta = A.Conta
AND C.prmoc_pco_ofici = A.Oficina
AND C.prmoc_pco_moned = A.Moneda
AND C.prmoc_pco_produ = A.Prod
AND C.prmoc_pnu_oper = A.Numero
WHERE A.Ind_Estado_Registro = 1
AND A.Id_Tipo_Operacion = 1
--AND A.Categoria_Riesgo_Deudor IN ('A1', 'A2', 'B1', 'B2', 'C1')
--AND A.Categoria_Riesgo_Deudor IN ('C2', 'D', 'E')
AND C.prmoc_estado = 'A'
AND C.prmoc_pnu_contr = 0
AND EXISTS  (SELECT 1 
				 FROM dbo.GARANTIAS_OPERACIONES C 
				 WHERE C.Id_Operacion = A.Id_Operacion 
				 AND C.Id_Garantia_Aval IS NULL
				 AND C.Id_Garantia_Real IS NOT NULL
				 OR C.Id_Garantia_Valor IS NOT NULL
				 OR C.Id_Fideicomiso IS NOT NULL)
ORDER BY B.Id_Operacion



SELECT *
FROM dbo.OPERACIONES A
INNER JOIN dbo.GARANTIAS_OPERACIONES B
ON B.Id_Operacion = A.Id_Operacion
AND B.Ind_Estado_Registro = 1
AND B.Id_Tipo_Garantia in (3,4,11)
INNER JOIN dbo.prmca C
ON C.prmca_pco_conta = A.Conta
AND C.prmca_pco_ofici = A.Oficina
AND C.prmca_pco_moned = A.Moneda
AND C.prmca_pco_produc = A.Prod
AND C.prmca_pnu_contr = A.Numero
WHERE A.Ind_Estado_Registro = 1
AND A.Id_Tipo_Operacion = 2
--AND A.Categoria_Riesgo_Deudor IN ('A1', 'A2', 'B1', 'B2', 'C1')
--AND A.Categoria_Riesgo_Deudor IN ('C2', 'D', 'E')
AND C.prmca_estado = 'A'
AND  EXISTS  (SELECT 1 
				 FROM dbo.GARANTIAS_OPERACIONES C 
				 WHERE C.Id_Operacion = A.Id_Operacion 
				 AND C.Id_Garantia_Aval IS NULL
				 AND C.Id_Garantia_Real IS NOT NULL
				 OR C.Id_Garantia_Valor IS NOT NULL
				 OR C.Id_Fideicomiso IS NOT NULL)
ORDER BY B.Id_Operacion


SELECT 
 (CAST(OP.Oficina AS VARCHAR) + '-' + CAST(OP.Moneda AS VARCHAR) + '-' + CASE WHEN OP.Id_Tipo_Operacion = 1 THEN CAST(OP.Prod AS VARCHAR) + '-' ELSE '' END + CAST(OP.Numero AS VARCHAR)) AS 'OPERACIONES_RELACIONADAS',
GV.Cod_Garantia_BCR
--GR.Codigo_Bien
--FID.Id_Fideicomiso_BCR

FROM
dbo.GARANTIAS_OPERACIONES GP
INNER JOIN 
(
SELECT 
	GAROPER.Id_Garantia_Valor,
	GAROPER.Id_Tipo_Garantia
FROM 
	dbo.GARANTIAS_VALORES GAV
INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
	ON GAV.Id_Garantia_Valor = GAROPER.Id_Garantia_Valor
WHERE 
	GAV.Ind_Estado_Registro = 1 
AND GAROPER.Ind_Estado_Registro = 1
GROUP BY 
	GAROPER.Id_Garantia_Valor,
	GAROPER.Id_Tipo_Garantia
HAVING COUNT(1) > 1
) A

ON A.Id_Garantia_Valor = GP.Id_Garantia_Valor
AND A.Id_Tipo_Garantia = GP.Id_Tipo_Garantia

--(
--SELECT 
--	GAROPER.Id_Garantia_Real,
--	GAROPER.Id_Tipo_Garantia
--FROM 
--	dbo.GARANTIAS_REALES GAR
--INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
--	ON GAR.Id_Garantia_Real = GAROPER.Id_Garantia_Real
--WHERE 
--	GAR.Ind_Estado_Registro = 1 
--AND GAROPER.Ind_Estado_Registro = 1
--GROUP BY 
--	GAROPER.Id_Garantia_Real,
--	GAROPER.Id_Tipo_Garantia
--HAVING COUNT(1) = 1
--) A
--ON A.Id_Garantia_Real = GP.Id_Garantia_Real
--AND A.Id_Tipo_Garantia = GP.Id_Tipo_Garantia

--(
--SELECT FID.Id_Fideicomiso, GAROPER.Id_Tipo_Garantia 
--FROM dbo.FIDEICOMISOS FID
--INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
--	ON FID.Id_Fideicomiso = GAROPER.Id_Fideicomiso
--WHERE FID.Ind_Estado_Registro =  1
--	AND GAROPER.Ind_Estado_Registro = 1
--GROUP BY FID.Id_Fideicomiso, GAROPER.Id_Tipo_Garantia
--HAVING COUNT(1) = 1
--) A
--ON A.Id_Fideicomiso = GP.Id_Fideicomiso
--AND A.Id_Tipo_Garantia = GP.Id_Tipo_Garantia

INNER JOIN 
(
SELECT 
	GAROPER.Id_Operacion
FROM 
	dbo.OPERACIONES OPER
INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
	ON OPER.Id_Operacion = GAROPER.Id_Operacion
WHERE 
	OPER.Ind_Estado_Registro = 1 
AND GAROPER.Ind_Estado_Registro = 1
GROUP BY 
	GAROPER.Id_Operacion
HAVING COUNT(1) = 1
) B
ON B.Id_Operacion = GP.Id_Operacion
INNER JOIN dbo.OPERACIONES OP
ON OP.Id_Operacion = GP.Id_Operacion
INNER JOIN dbo.GARANTIAS_VALORES GV
ON GV.Id_Garantia_Valor = A.Id_Garantia_Valor
--INNER JOIN dbo.GARANTIAS_REALES GR
--ON GR.Id_Garantia_Real = A.Id_Garantia_Real
--INNER JOIN dbo.FIDEICOMISOS FID
--ON FID.Id_Fideicomiso = A.Id_Fideicomiso
INNER JOIN dbo.prmoc C
ON C.prmoc_pco_conta = OP.Conta
	AND C.prmoc_pco_ofici = OP.Oficina
	AND C.prmoc_pco_moned = OP.Moneda
	AND C.prmoc_pco_produ = OP.Prod
	AND C.prmoc_pnu_oper = OP.Numero
	AND C.prmoc_estado = 'A'
	AND C.prmoc_pnu_contr = 0
	AND C.prmoc_pcoctamay <> 815
	AND C.prmoc_pse_proces = 1

--INNER JOIN dbo.prmca C					
--ON C.prmca_pco_conta = OP.Conta
--	AND C.prmca_pco_ofici = OP.Oficina
--	AND C.prmca_pco_moned = OP.Moneda
--	AND C.prmca_pco_produc = OP.Prod
--	AND C.prmca_pnu_contr = OP.Numero
--	AND C.prmca_estado = 'A'
--	AND C.prmca_pfe_defin > 20160811
WHERE 
	GP.Ind_Estado_Registro = 1
	AND OP.Id_Tipo_Operacion = 1


*/