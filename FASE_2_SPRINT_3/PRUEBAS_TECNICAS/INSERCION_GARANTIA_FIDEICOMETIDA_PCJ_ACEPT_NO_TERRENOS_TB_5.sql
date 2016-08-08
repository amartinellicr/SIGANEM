--ESCENARIO CP02
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504'
WHERE Id_Garantia_Real = 5836

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
199,              3,                  5836,               NULL,                N'109460987',       N'Tomás Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                         1,                              NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

--delete from dbo.GARANTIAS_FIDEICOMETIDAS where Id_Fideicomiso between 199 and 217

--ESCENARIO CP03
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 1, --444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504'
WHERE Id_Garantia_Real = 5834


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
200,              3,                  5834,               NULL,                N'109460988',       N'Luisa Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--delete from dbo.GARANTIAS_FIDEICOMETIDAS
--where Id_Fideicomiso = 200

--ESCENARIO CP07

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 5852


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150730',
	Monto_Poliza = 10000.00,
	Monto_Poliza_Colonizado = 10000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4205


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
201,              3,                  5852,               NULL,                N'109460992',       N'Rogelio Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP08

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 1,--444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'
WHERE Id_Garantia_Real = 5838


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190730',
	Monto_Poliza = 10000.00,
	Monto_Poliza_Colonizado = 10000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4198


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
202,              3,                  5838,               NULL,                N'109460992',       N'Rogelio Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP09

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 1,--444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 6031

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150930',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4321


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
203,              3,                  6031,               NULL,                N'109460993',       N'Roger Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP10
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 1,--444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 5906

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150930',
	Monto_Poliza = 10000.00,
	Monto_Poliza_Colonizado = 10000.00
WHERE Id_Garantia_Real_Poliza = 4239

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
204,              3,                  5906,               NULL,                N'109470995',       N'Norman Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP11

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'
WHERE Id_Garantia_Real = 6059

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Monto_Poliza = 500000.00,
	Monto_Poliza_Colonizado = 500000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4334


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
205,              3,                  6059,               NULL,                N'109470996',       N'Armando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP12


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 6057


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150630',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4332


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
206,              3,                  6057,               NULL,                N'109470107',       N'German Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP13


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 6047


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150930',
	Monto_Poliza = 1000.00,
	Monto_Poliza_Colonizado = 1000.00
WHERE Id_Garantia_Real_Poliza = 4326


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
207,              3,                  6047,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP14

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 1, --444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 6040


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4323


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
208,              3,                  6040,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP15

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 1, --444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'
WHERE Id_Garantia_Real = 6038


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Monto_Poliza = 20000.00,
	Monto_Poliza_Colonizado = 20000.00
WHERE Id_Garantia_Real_Poliza = 11599


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
209,              3,                  6038,               NULL,                N'109470103',       N'Armando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


--DELETE FROM dbo.GARANTIAS_FIDEICOMETIDAS WHERE Id_Fideicomiso BETWEEN 199 AND 209

--ESCENARIO CP16

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 1, --444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504'
WHERE Id_Garantia_Real = 6031


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150930'
WHERE Id_Garantia_Real_Poliza = 4321


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
210,              3,                  6031,               NULL,                N'109470105',       N'Amanda Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP17

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504'
WHERE Id_Garantia_Real = 5834

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150630',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 11567


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
211,              3,                  5834,               NULL,                N'109470107',       N'German Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP18


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'
WHERE Id_Garantia_Real = 5838


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Coberturas = 1
WHERE Id_Garantia_Real_Poliza = 4198



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
212,              3,                  5838,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP19


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'
WHERE Id_Garantia_Real = 5852


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150930',
	Monto_Poliza = 2000000.00,
	Monto_Poliza_Colonizado = 2000000.00,
	Coberturas = 1
WHERE Id_Garantia_Real_Poliza = 4205


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
213,              3,                  5852,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')





--ESCENARIO CP20

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 1, --444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 5906

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza = 20000000.00,
	Monto_Poliza_Colonizado = 20000000.00,
	Coberturas = 1
WHERE Id_Garantia_Real_Poliza = 4239


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
214,              3,                  5906,               NULL,                N'109470104',       N'Laura Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP21


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'
WHERE Id_Garantia_Real = 6059

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza = 20000000.00,
	Monto_Poliza_Colonizado = 20000000.00,
	Coberturas = 1
WHERE Id_Garantia_Real_Poliza = 4334


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
215,              3,                  6059,               NULL,                N'109470106',       N'Lesli Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP24
/*
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Equipo_Computo = 444,
	Meses_Vencimiento_Avaluo_Equipo_Computo = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 6057

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'	
WHERE Id_Garantia_Real = 6047


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza_Colonizado = NULL,
	Coberturas = 1
WHERE Id_Garantia_Real_Poliza = 4332


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza_Colonizado = NULL
WHERE Id_Garantia_Real_Poliza = 4326



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
216,              3,                  6057,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
217,              3,                  6047,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


*/