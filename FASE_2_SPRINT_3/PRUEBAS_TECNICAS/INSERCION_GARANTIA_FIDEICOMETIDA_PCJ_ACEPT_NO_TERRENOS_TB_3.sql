--ESCENARIO CP02

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
129,              3,                  2080,               NULL,                N'109460987',       N'Tomás Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                         1,                               '20160303',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

--delete from dbo.GARANTIAS_FIDEICOMETIDAS
--where Id_Fideicomiso = 129


--ESCENARIO CP03

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160730'
WHERE Id_Fideicomiso = 130


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
130,              3,                  3282,               NULL,                N'109460988',       N'Luisa Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         3,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP04

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20150730'
WHERE Id_Fideicomiso = 131


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
131,              3,                  3533,               NULL,                N'109460989',       N'Lupita Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160606',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP05

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
132,              3,                  5756,               NULL,                N'109460990',       N'Rupert Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP06

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504'
WHERE Id_Garantia_Real = 5801


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
133,              3,                  5801,               NULL,                N'109460991',       N'Robert Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               '20160505',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP07
UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 524


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
134,              3,                  524,               NULL,                N'109460994',       N'Robert Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               '20160405',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP11

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 2080


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190730'
WHERE Id_Garantia_Real_Poliza = 690


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
135,              3,                  2080,               NULL,                N'109460992',       N'Rogelio Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP12

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160730'
WHERE Id_Fideicomiso = 136

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 2097

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 10979


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
136,              3,                  2097,               NULL,                N'109460993',       N'Roger Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         3,                               '20160701',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP13

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 2094


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
137,              3,                  2094,               NULL,                N'109470995',       N'Norman Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160706',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP14

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'
WHERE Id_Garantia_Real = 3096

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 1280


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
138,              3,                  3096,               NULL,                N'109470996',       N'Armando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP15
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404',
	Codigo_Bien = '089315'	
WHERE Id_Garantia_Real = 2515

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304',
	Codigo_Bien = '089534'	
WHERE Id_Garantia_Real = 2516

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 948

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 949



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
74,               3,                  2515,               NULL,                N'109470105',       N'Amanda Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
75,               3,                  2516,               NULL,                N'109470106',       N'Lesli Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP17

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2517

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2518

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 950

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 951



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
76,               3,                  2517,               NULL,                N'109470107',       N'German Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
77,               3,                  2518,               NULL,                N'109470108',       N'Lesli Segura Rojas',              1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
24,             11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  76,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
25,             11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  77,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
1161,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  77,               NULL,                NULL)



--ESCENARIO CP18


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2519

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2520

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 952

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 11050



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
78,               3,                  2519,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
79,               3,                  2520,               NULL,                N'109470110',       N'Marcos Segura Rojas',             1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
49,             11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  78,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
25,             11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  79,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
1161,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  79,               NULL,                NULL)


--ESCENARIO CP19

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2521

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2525

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 953

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 954



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
80,               3,                  2521,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
81,               3,                  2525,               NULL,                N'109470110',       N'Marcos Segura Rojas',             1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
28,             11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  80,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
388,             11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  80,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
13529,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  81,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44369,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  81,               NULL,                NULL)




--ESCENARIO CP20

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 82

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 83


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2526

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2527

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 955

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 956



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
82,               3,                  2526,               NULL,                N'109470103',       N'Armando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160720',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
83,               3,                  2527,               NULL,                N'109470104',       N'Laura Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160720',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44370,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  82,               NULL,                NULL)




--ESCENARIO CP21

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 84

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 85


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2528

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2529

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 957

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 958



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
84,               3,                  2528,               NULL,                N'109470105',       N'Amanda Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               '20160720',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
85,               3,                  2529,               NULL,                N'109470106',       N'Lesli Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               '20160720',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--UPDATE dbo.GARANTIAS_FIDEICOMETIDAS
--SET Id_Tipo_Indicador_Inscripcion = 4,
--	Fecha_Presentacion = '20160720'
--WHERE Id_Fideicomiso = 85 AND Id_Garantia_Real = 2529




--ESCENARIO CP22

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 86

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 88


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2533

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2537

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 959

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 960



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
86,               3,                  2533,               NULL,                N'109470107',       N'German Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
88,               3,                  2537,               NULL,                N'109470108',       N'Lesli Segura Rojas',              1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44346,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  86,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
8912,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  88,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
8914,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  88,               NULL,                NULL)



--ESCENARIO CP23


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 89

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 90

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2538

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2574

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 961

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Monto_Poliza = 20000000.00,
	Monto_Poliza_Colonizado = 20000000.00
WHERE Id_Garantia_Real_Poliza = 983



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
89,               3,                  2538,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
90,               3,                  2574,               NULL,                N'109470110',       N'Marcos Segura Rojas',             1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
395,            11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  89,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
405,            11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  89,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44389,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  90,               NULL,                NULL)



--ESCENARIO CP24


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 91

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 92


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2575

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2576

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza = 200000000.00,
	Monto_Poliza_Colonizado = 200000000.00
WHERE Id_Garantia_Real_Poliza = 984

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 985



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
91,               3,                  2575,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
92,               3,                  2576,               NULL,                N'109470110',       N'Marcos Segura Rojas',             1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160724',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44350,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  91,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
407,            11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  91,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44357,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  92,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
411,            11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  92,               NULL,                NULL)



--ESCENARIO CP25

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160115',
	Fecha_Vencimiento = '20180115'
WHERE Id_Fideicomiso = 93

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 94


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2577

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2578

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 986

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 987



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
93,               3,                  2577,               NULL,                N'109470103',       N'Armando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160720',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
94,               3,                  2578,               NULL,                N'109470104',       N'Laura Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160720',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
417,            11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  93,               NULL,                NULL)



--ESCENARIO CP26


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160215',
	Fecha_Vencimiento = '20180215'
WHERE Id_Fideicomiso = 95

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160221',
	Fecha_Vencimiento = '20180221'
WHERE Id_Fideicomiso = 96


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2579

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2580

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza = 6550279.00,
	Monto_Poliza_Colonizado = 6550279.00
WHERE Id_Garantia_Real_Poliza = 988

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 989



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
95,               3,                  2579,               NULL,                N'109470105',       N'Amanda Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               '20160720',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
96,               3,                  2580,               NULL,                N'109470106',       N'Lesli Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               '20160720',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP27


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160315',
	Fecha_Vencimiento = '20180315'
WHERE Id_Fideicomiso = 97

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160321',
	Fecha_Vencimiento = '20180321'
WHERE Id_Fideicomiso = 98


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2581

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2582

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza = 41000000.00,
	Monto_Poliza_Colonizado = 41000000.00
WHERE Id_Garantia_Real_Poliza = 990

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 11061



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
97,               3,                  2581,               NULL,                N'109470107',       N'German Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
98,               3,                  2582,               NULL,                N'109470108',       N'Lesli Segura Rojas',              1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
30,             11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  97,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
6417,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  98,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44375,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  98,               NULL,                NULL)


--ESCENARIO CP28



UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160415',
	Fecha_Vencimiento = '20180415'
WHERE Id_Fideicomiso = 99

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160421',
	Fecha_Vencimiento = '20180421'
WHERE Id_Fideicomiso = 100

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2583

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2585

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 991

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 992



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
99,               3,                  2583,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
100,              3,                  2585,               NULL,                N'109470110',       N'Marcos Segura Rojas',             1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
426,            11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  99,               NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
6936,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  100,              NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44550,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  100,              NULL,                NULL)


--ESCENARIO CP29

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 1, --200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160115',
	Fecha_Vencimiento = '20180115'
WHERE Id_Fideicomiso = 101

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 102


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2586

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2587

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 993

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 994



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
101,              3,                  2586,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
102,              3,                  2587,               NULL,                N'109470110',       N'Marcos Segura Rojas',             1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160724',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
9353,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  101,              NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
435,            11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  101,              NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44402,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  102,             NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
494,            11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  102,              NULL,                NULL)


--ESCENARIO CP30

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2588


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150630'
WHERE Id_Garantia_Real_Poliza = 995



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
103,              3,                  2588,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP31

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 104

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2590


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530'
WHERE Id_Garantia_Real_Poliza = 996


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
104,              3,                  2590,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP32

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 105

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2591


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530'
WHERE Id_Garantia_Real_Poliza = 997


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
105,              3,                  2591,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP33

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2592


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 998


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
106,              3,                  2592,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP34


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2593


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 6321473.00,
	Monto_Poliza_Colonizado = 6321473.00
WHERE Id_Garantia_Real_Poliza = 999


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
107,              3,                  2593,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP35

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 108

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2594


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 1000


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
108,              3,                  2594,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP36


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 109

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2595


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 1000000.00,
	Monto_Poliza_Colonizado = 1000000.00
WHERE Id_Garantia_Real_Poliza = 1001


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
109,              3,                  2595,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP37

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 110

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2596


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Coberturas = 0,
	Monto_Poliza = 177396432.00,
	Monto_Poliza_Colonizado = 177396432.00 
WHERE Id_Garantia_Real_Poliza = 1002


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
110,              3,                  2596,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP38


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 111

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2598


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 1000000.00,
	Monto_Poliza_Colonizado = 1000000.00
WHERE Id_Garantia_Real_Poliza = 1003


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
111,              3,                  2598,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160405',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP39


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 112

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2599


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Coberturas = 0,
	Monto_Poliza = 9930760.00,
	Monto_Poliza_Colonizado = 9930760.00
WHERE Id_Garantia_Real_Poliza = 11063


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
112,              3,                  2599,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP40


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 113

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2600


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 5000000.00,
	Monto_Poliza_Colonizado = 5000000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 11064


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
113,              3,                  2600,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160405',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP41


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 114

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2601


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 8894278.00,
	Monto_Poliza_Colonizado = 8894278.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 1004


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
114,              3,                  2601,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160405',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP42


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 115

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 49965


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
115,              3,                  49965,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP43


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 116

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2531


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
116,              3,                  2531,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP44


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 117

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2534


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
117,              3,                  2534,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160125',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP45


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 118

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2604


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza = 2606926.00,
	Monto_Poliza_Colonizado = 2606926.00
WHERE Id_Garantia_Real_Poliza = 1005


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
118,              3,                  2604,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP46


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 119

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2904


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza = 1975250.00,
	Monto_Poliza_Colonizado = 1975250.00
WHERE Id_Garantia_Real_Poliza = 1158


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
119,              3,                  2904,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP47


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 120

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2905


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza = 5598834.00,
	Monto_Poliza_Colonizado = 5598834.00
WHERE Id_Garantia_Real_Poliza = 1159


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
120,              3,                  2905,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160125',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP48


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 121

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2906


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza = 4500000.00,
	Monto_Poliza_Colonizado = 4500000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 1160


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
121,              3,                  2906,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP49


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 122

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2908


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza = 10832992.00,
	Monto_Poliza_Colonizado = 10832992.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 11148


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
122,              3,                  2908,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP50


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160221',
	Fecha_Vencimiento = '20180221'
WHERE Id_Fideicomiso = 123

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2911


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza = 61285999.99,
	Monto_Poliza_Colonizado = 61285999.99,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 1161


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
123,              3,                  2911,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160225',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP51


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 124

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2912


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 1162


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
124,              3,                  2912,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP52


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 125

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2913


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 11149


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
125,              3,                  2913,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP53


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160321',
	Fecha_Vencimiento = '20180321'
WHERE Id_Fideicomiso = 126

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2914


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 11150


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
126,              3,                  2914,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160325',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP55
/*

UPDATE dbo.OPERACIONES
SET Categoria_Riesgo_Deudor = NULL
WHERE Id_Operacion IN (44350, 407, 44357, 411)

*/


--ESCENARIO CP56


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Edificacion = 200,
	Meses_Vencimiento_Avaluo_SUGEF_Edificacion = 13
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso IN (127, 128)

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real IN (2918, 2930)


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza_Colonizado = null
WHERE Id_Garantia_Real_Poliza IN (11151, 11154)


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
127,              3,                  2918,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
128,              3,                  2930,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 3,                          2,                         4,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



/*

SELECT * 
FROM dbo.GARANTIAS_FIDEICOMETIDAS
WHERE Id_Fideicomiso = 36
AND Id_Garantia_Real = 48058

DELETE FROM dbo.GARANTIAS_FIDEICOMETIDAS
WHERE Id_Fideicomiso = 37
AND Id_Garantia_Real = 3494

*/