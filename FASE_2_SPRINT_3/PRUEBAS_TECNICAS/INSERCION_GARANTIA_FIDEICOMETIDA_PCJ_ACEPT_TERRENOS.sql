--ESCENARIO CP07
UPDATE dbo.GARANTIAS_FIDEICOMETIDAS
SET Id_Tipo_Indicador_Inscripcion = 1,
	Fecha_Presentacion = '20160304'
WHERE Id_Garantia_Real = 2023
AND Id_Fideicomiso = 23

UPDATE dbo.GARANTIAS_FIDEICOMETIDAS
SET Id_Tipo_Indicador_Inscripcion = 1,
	Fecha_Presentacion = '20160504'
WHERE Id_Garantia_Real = 2029
AND Id_Fideicomiso = 25

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultima_Tasacion_Garantia = '2016',
	Fecha_Ultimo_Seguimiento_Garantia = ''
WHERE Id_Garantia_Real = 2023


--ESCENARIO CP08
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 1 --100
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20010504'
WHERE Id_Garantia_Real = 2026

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20010404'
WHERE Id_Garantia_Real = 2032



--ESCENARIO CP09

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 1--650
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504'
WHERE Id_Garantia_Real = 2021

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404'
WHERE Id_Garantia_Real = 2067


--ESCENARIO CP10
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1


--ESCENARIO CP11

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 1,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20190421'
WHERE Id_Fideicomiso = 11

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160802',
	Fecha_Vencimiento = '20190821'
WHERE Id_Fideicomiso = 12


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20020504'
WHERE Id_Garantia_Real = 2176

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20020404'
WHERE Id_Garantia_Real = 3088


--ESCENARIO CP12

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 1--650
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160722',
	Fecha_Vencimiento = '20190421'
WHERE Id_Fideicomiso = 13

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160801',
	Fecha_Vencimiento = '20190821'
WHERE Id_Fideicomiso = 15


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504'
WHERE Id_Garantia_Real = 2103

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404'
WHERE Id_Garantia_Real = 3183



--ESCENARIO CP13
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160719',
	Fecha_Vencimiento = '20190421'
WHERE Id_Fideicomiso = 16

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160725',
	Fecha_Vencimiento = '20190821'
WHERE Id_Fideicomiso = 17

--ESCENARIO CP14
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 1,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1


--ESCENARIO CP15
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 1--650
WHERE Id_Parametro_Bien = 1


--ESCENARIO CP16
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1





--ESCENARIO CP17

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
26,               3,                  1755,               NULL,                N'109460957',       N'Rosario Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               '20160303',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
27,               3,                  2117,               NULL,                N'109460958',       N'Rosario Segura Rojas',            1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(70.00 AS Numeric(5, 2)), 3,                          2,                         1,                               '20160403',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP18

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
28,               3,                  2182,               NULL,                N'109460959',       N'Rosa Cascante Segura',            1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(65.00 AS Numeric(5, 2)), 3,                          2,                         3,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
29,               3,                  2120,               NULL,                N'109460960',       N'Romario Segura Rojas',            1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(75.00 AS Numeric(5, 2)), 3,                          2,                         3,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715'
WHERE Id_Fideicomiso = 28

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721'
WHERE Id_Fideicomiso = 29



--ESCENARIO CP19

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
30,               3,                  2172,               NULL,                N'109460961',       N'Mario Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(65.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160130',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
31,               3,                  2170,               NULL,                N'109460962',       N'jesús Segura Rojas',              1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(75.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160415',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160115'
WHERE Id_Fideicomiso = 30

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160221'
WHERE Id_Fideicomiso = 31



--ESCENARIO CP20

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
32,               3,                  2173,               NULL,                N'109460963',       N'Miriam Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(65.00 AS Numeric(5, 2)), 3,                          2,                         4,                               NULL,           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
33,               3,                  2175,               NULL,                N'109460964',       N'Roberto Segura Rojas',            1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(75.00 AS Numeric(5, 2)), 3,                          2,                         4,                               NULL,           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP21

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 1,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
34,               3,                  3193,               NULL,                N'109460965',       N'Rolando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(65.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
35,               3,                  3182,               NULL,                N'109460966',       N'José Segura Rojas',               1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(75.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP22

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 1 --650
WHERE Id_Parametro_Bien = 1

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
36,               3,                  48058,               NULL,               N'109460967',       N'Ronald Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(65.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
37,               3,                  3494,               NULL,                N'109460968',       N'Joaquin Segura Rojas',            1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(75.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP23

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
38,               3,                  3303,               NULL,               N'109460969',       N'María Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(66.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
39,               3,                  3501,               NULL,                N'109460970',       N'Lizbeth Segura Rojas',            1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(76.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP24

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 1,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160719',
	Fecha_Vencimiento = '20190421'
WHERE Id_Fideicomiso = 40

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160725',
	Fecha_Vencimiento = '20190821'
WHERE Id_Fideicomiso = 41


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
40,               3,                  3274,               NULL,               N'109460971',       N'Moisés Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(66.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160405',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
41,               3,                  3573,               NULL,                N'109460972',       N'Elizabeth Segura Rojas',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(76.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160517',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP25

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 1 --650
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160718',
	Fecha_Vencimiento = '20190421'
WHERE Id_Fideicomiso = 42

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160726',
	Fecha_Vencimiento = '20190821'
WHERE Id_Fideicomiso = 43

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
42,               3,                  3618,               NULL,               N'109460973',       N'Andrés Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(66.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160405',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
43,               3,                  3650,               NULL,                N'109460974',       N'Tobías Segura Rojas',             1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(76.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160517',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP26

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160720',
	Fecha_Vencimiento = '20190421'
WHERE Id_Fideicomiso = 44

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160728',
	Fecha_Vencimiento = '20190821'
WHERE Id_Fideicomiso = 45


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
44,               3,                  4686,               NULL,               N'109460975',       N'Alex Cascante Segura',             1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(66.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160405',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
45,               3,                  5879,               NULL,                N'109460976',       N'Alejandra Segura Rojas',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(76.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160517',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP27

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 1,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
46,               3,                  5884,               NULL,               N'109460977',       N'Alexander Cascante Segura',        1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(66.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160505',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
48,               3,                  4702,               NULL,                N'109460978',       N'Alejandro Segura Rojas',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(76.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160527',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP28

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 1 --650
WHERE Id_Parametro_Bien = 1

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
49,               3,                  5726,               NULL,               N'109460979',       N'Dennis Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(66.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160507',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
50,               3,                  5936,               NULL,                N'109460980',       N'Karla Segura Rojas',              1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(76.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160528',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP29

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Terreno = 100,
	Meses_Vencimiento_Avaluo_SUGEF_Terreno = 650
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504'
WHERE Id_Garantia_Real = 5952

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'
WHERE Id_Garantia_Real = 5955


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
51,               3,                  5952,               NULL,               N'109460981',       N'Denia Cascante Segura',            1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(66.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160507',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
52,               3,                  5955,               NULL,                N'109460982',       N'Carol Segura Rojas',              1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(76.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160528',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


/*

SELECT * 
FROM dbo.GARANTIAS_FIDEICOMETIDAS
WHERE Id_Fideicomiso = 36
AND Id_Garantia_Real = 48058

DELETE FROM dbo.GARANTIAS_FIDEICOMETIDAS
WHERE Id_Fideicomiso = 37
AND Id_Garantia_Real = 3494

*/