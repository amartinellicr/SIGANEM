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
130,              3,                  3271,               NULL,                N'109460988',       N'Luisa Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP04

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20150730'
WHERE Id_Fideicomiso = 131


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
131,              3,                  5758,               NULL,                N'109460989',       N'Lupita Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160606',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP05

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
132,              3,                  5807,               NULL,                N'109460990',       N'Rupert Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP06

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504'
WHERE Id_Garantia_Real = 5810


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
133,              3,                  5810,               NULL,                N'109460991',       N'Robert Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               '20160505',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP07
UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 6007


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
134,              3,                  6007,               NULL,                N'109460994',       N'Robert Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               '20160405',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


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
135,              3,                  2080,               NULL,                N'109460992',       N'Rogelio Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP12

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160730'
WHERE Id_Fideicomiso = 136

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 28513

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 15756


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
136,              3,                  28513,              NULL,                N'109460993',       N'Roger Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160701',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP13

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 2667

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Monto_Poliza = 9000000.00,
	Monto_Poliza_Colonizado = 9000000.00
WHERE Id_Garantia_Real_Poliza = 11083

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
137,              3,                  2667,               NULL,                N'109470995',       N'Norman Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160706',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP14

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'
WHERE Id_Garantia_Real = 2675

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 11089


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
138,              3,                  2675,               NULL,                N'109470996',       N'Armando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP15

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1



UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2678


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 11092



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
139,              3,                  2678,               NULL,                N'109470107',       N'German Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
6569,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  139,              NULL,                NULL)




--ESCENARIO CP16


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1



UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 2681


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 11095



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
140,              3,                  2681,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
45867,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  140,              NULL,                NULL)


--ESCENARIO CP17

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 2684


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 11097



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
141,              3,                  2684,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
6599,           11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  141,              NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
45467,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  141,              NULL,                NULL)




--ESCENARIO CP18

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 142


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404',
	Codigo_Bien = '001293'	
WHERE Id_Garantia_Real = 2810


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 11127



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
142,              3,                  2810,               NULL,                N'109470103',       N'Armando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160720',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')







--ESCENARIO CP19

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 143


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304',
	Codigo_Bien = '000131'	
WHERE Id_Garantia_Real = 2827


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Monto_Poliza = 8000000.00,
	Monto_Poliza_Colonizado = 8000000.00
WHERE Id_Garantia_Real_Poliza = 11131



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
143,              3,                  2827,               NULL,                N'109470105',       N'Amanda Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160720',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
30616,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  143,              NULL,                NULL)


--UPDATE dbo.GARANTIAS_FIDEICOMETIDAS
--SET Id_Tipo_Indicador_Inscripcion = 4,
--	Fecha_Presentacion = '20160720'
--WHERE Id_Fideicomiso = 85 AND Id_Garantia_Real = 2529




--ESCENARIO CP20

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 144

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304',
	Codigo_Bien = '000180'
WHERE Id_Garantia_Real = 2959

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza = 17000000.00,
	Monto_Poliza_Colonizado = 17000000.00
WHERE Id_Garantia_Real_Poliza = 11163


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
144,              3,                  2959,               NULL,                N'109470107',       N'German Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
45614,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  144,              NULL,                NULL)




--ESCENARIO CP21


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 145


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 4158


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 11324



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
145,              3,                  4158,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
27294,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  145,              NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44767,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  145,              NULL,                NULL)


--ESCENARIO CP22


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 146


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 5326


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 11491



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
146,              3,                  5326,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')





--ESCENARIO CP23

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160115',
	Fecha_Vencimiento = '20180115'
WHERE Id_Fideicomiso = 147


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 5463

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza = 8000000.00,
	Monto_Poliza_Colonizado = 8000000.00
WHERE Id_Garantia_Real_Poliza = 11518


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
147,              3,                  5463,               NULL,                N'109470104',       N'Laura Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160720',           NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
34636,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  147,              NULL,                NULL)


--ESCENARIO CP24


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160215',
	Fecha_Vencimiento = '20180215'
WHERE Id_Fideicomiso = 148


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 5478

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 11521


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
148,              3,                  5478,               NULL,                N'109470106',       N'Lesli Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160720',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
45542,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  148,              NULL,                NULL)



--ESCENARIO CP25


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160315',
	Fecha_Vencimiento = '20180315'
WHERE Id_Fideicomiso = 149


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 5993

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630'
WHERE Id_Garantia_Real_Poliza = 11590


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
149,              3,                  5993,               NULL,                N'109470108',       N'Lesli Segura Rojas',              1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
13298,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  149,              NULL,                NULL)


INSERT [dbo].[GARANTIAS_OPERACIONES] (
[Id_Operacion], [Id_Tipo_Garantia], [Id_Garantia_Fiduciaria], [Id_Garantia_Valor], [Id_Garantia_Real], [Ind_Estado_Replicado], [Id_Tipo_Moneda_Monto_Gravamen], [Monto_Grado_Gravamen],       [Id_Grado_Gravamen], [Fecha_Vencimiento_Garantia], [Fecha_Prescripcion_Garantia], [Fecha_Constitucion_Garantia], [Id_Clase_Garantia_PRT17], [Id_Tenencia_PRT_15], [Id_Tenencia_PRT_17], [Ind_Deudor_Habita], [Ind_Recomendacion_Perito], [Ind_Inspeccion_Garantia], [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Monto_Mitigador], [Porcentaje_Aceptacion_BCR],  [Porcentaje_Responsabilidad_SUGEF], [Partido], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Estado_Registro], [Ind_Accion_Registro], [Monto_Mitigador_Calculado], [Porcentaje_Responsabilidad_Legal], [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Id_Fideicomiso], [Id_Garantia_Aval], [Id_Tipo_Indicador_Inscripcion]) VALUES (
44719,          11,                 NULL,                     NULL,                 NULL,              0,                      NULL,                            CAST(0.00 AS Numeric(22, 2)), NULL,                NULL,                         NULL,                          NULL,                          21,                        NULL,                 NULL,                 0,                   0,                          0,                         NULL,                       NULL,                      NULL,              CAST(0.00 AS Numeric(5, 2)),  NULL,                               NULL,      N'MANTENIMIENTO',       CAST(N'2016-06-27 08:13:27.897' AS DateTime), N'114870238',          NULL,                        NULL,                              1,                     N'I',                  NULL,                        NULL,                               NULL,                                     NULL,                                  149,              NULL,                NULL)




--ESCENARIO CP26

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 46221


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
150,              3,                  46221,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP27

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 1 --300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 151

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404',
	Codigo_Bien = '003610'	
WHERE Id_Garantia_Real = 44655



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
151,              3,                  44655,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP28

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 152

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 46029



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
152,              3,                  46029,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160723',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP29

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 6288


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 10000000.00,
	Monto_Poliza_Colonizado = 10000000.00
WHERE Id_Garantia_Real_Poliza = 11638


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
153,              3,                  6288,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP30


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 154

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	,
	Codigo_Bien = '002767'
WHERE Id_Garantia_Real = 7819


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530'
WHERE Id_Garantia_Real_Poliza = 11870


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
154,              3,                  7819,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160727',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP31

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 155

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404',
	Codigo_Bien = '002238'	
WHERE Id_Garantia_Real = 9156


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 200000000.00,
	Monto_Poliza_Colonizado = 200000000.00
WHERE Id_Garantia_Real_Poliza = 12045


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
155,              3,                  9156,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP32


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 156

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 11042


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 28000000.00,
	Monto_Poliza_Colonizado = 28000000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12405


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
156,              3,                  11042,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP33

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 157

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 12817


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530'
WHERE Id_Garantia_Real_Poliza = 12670


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
157,              3,                  12817,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160722',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP34


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 158

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 12854


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12677


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
158,              3,                  12854,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160805',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP35


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 159

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13052


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 9930760.00,
	Monto_Poliza_Colonizado = 9930760.00
WHERE Id_Garantia_Real_Poliza = 12706


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
159,              3,                  13052,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160727',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP36


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160421',
	Fecha_Vencimiento = '20180421'
WHERE Id_Fideicomiso = 160

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 12113


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 10000000.00,
	Monto_Poliza_Colonizado = 10000000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12577


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
160,              3,                  12113,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160425',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP37


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 161

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 12144


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 8894278.00,
	Monto_Poliza_Colonizado = 8894278.00
WHERE Id_Garantia_Real_Poliza = 12582


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
161,              3,                  12144,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160405',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP38


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160421',
	Fecha_Vencimiento = '20180421'
WHERE Id_Fideicomiso = 162

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13049


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12582


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
162,              3,                  13049,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP39


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 163

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13095

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Monto_Poliza = 8894278.00,
	Monto_Poliza_Colonizado = 8894278.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12720


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
163,              3,                  13095,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP40


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 164

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13060

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12714

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
164,              3,                  13060,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160125',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP41


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 165

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13229


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530'
WHERE Id_Garantia_Real_Poliza = 12744


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
165,              3,                  13229,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP42


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 166

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13209


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530'
WHERE Id_Garantia_Real_Poliza = 12739


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
166,              3,                  13209,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP43


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 167

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	,
	Codigo_Bien = '000133'
WHERE Id_Garantia_Real = 13467


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza = 5598834.00,
	Monto_Poliza_Colonizado = 5598834.00
WHERE Id_Garantia_Real_Poliza = 12790


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
167,              3,                  13467,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160125',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP44


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160121',
	Fecha_Vencimiento = '20180121'
WHERE Id_Fideicomiso = 168

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13249


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12745


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
168,              3,                  13249,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP45


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 169

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13358


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12766


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
169,              3,                  13358,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP46


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160221',
	Fecha_Vencimiento = '20180221'
WHERE Id_Fideicomiso = 170

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13490


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza = 1285999.99,
	Monto_Poliza_Colonizado = 1285999.99,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12793


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
170,              3,                  13490,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160225',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--ESCENARIO CP47


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 171

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13501


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12797


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
171,              3,                  13501,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP48


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 172

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13621


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 12817


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
172,              3,                  13621,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        3,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP49


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160321',
	Fecha_Vencimiento = '20180321'
WHERE Id_Fideicomiso = 173

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13636


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Coberturas = 0,
	Monto_Poliza = 10258000.00,
	Monto_Poliza_Colonizado = 10258000.00
WHERE Id_Garantia_Real_Poliza = 12821


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
173,              3,                  13636,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160325',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP51
/*

UPDATE dbo.OPERACIONES
SET Categoria_Riesgo_Deudor = NULL
WHERE Id_Operacion = 30616

*/


--ESCENARIO CP52


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Vehiculo = 300
WHERE Id_Parametro_Bien = 1

UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160721',
	Fecha_Vencimiento = '20180721'
WHERE Id_Fideicomiso = 174

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 13704


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190530',
	Monto_Poliza_Colonizado = null
WHERE Id_Garantia_Real_Poliza = 12837


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
174,              3,                  13704,              NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        4,                               '20160725',           NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--delete from dbo.GARANTIAS_FIDEICOMETIDAS where Id_Fideicomiso = 174

/*

SELECT * 
FROM dbo.GARANTIAS_FIDEICOMETIDAS
WHERE Id_Fideicomiso = 36
AND Id_Garantia_Real = 48058

DELETE FROM dbo.GARANTIAS_FIDEICOMETIDAS
WHERE Id_Fideicomiso = 37
AND Id_Garantia_Real = 3494

*/