--ESCENARIO CP02
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Maquinaria_Equipo = 1, --400,
	Meses_Vencimiento_Avaluo_Maquinaria_Equipo = 11
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504',
	Codigo_Bien = '000436'
WHERE Id_Garantia_Real = 3235

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
175,              3,                  3235,               NULL,                N'109460987',       N'Tomás Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                         1,                              NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

--delete from dbo.GARANTIAS_FIDEICOMETIDAS
--where Id_Fideicomiso = 175


--ESCENARIO CP03
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Maquinaria_Equipo = 400,
	Meses_Vencimiento_Avaluo_Maquinaria_Equipo = 1--11
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504',
	Codigo_Bien = '000437'
WHERE Id_Garantia_Real = 3237


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
176,              3,                  3237,               NULL,                N'109460988',       N'Luisa Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP04
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Maquinaria_Equipo = 400,
	Meses_Vencimiento_Avaluo_Maquinaria_Equipo = 1--11
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504',
	Codigo_Bien = '000438'
WHERE Id_Garantia_Real = 3239

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
177,              3,                  3239,               NULL,                N'109460989',       N'Lupita Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP08

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Maquinaria_Equipo = 400,
	Meses_Vencimiento_Avaluo_Maquinaria_Equipo = 11
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604',
	Codigo_Bien = '001234'
WHERE Id_Garantia_Real = 3201


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190730'
WHERE Id_Garantia_Real_Poliza = 1352


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
178,              3,                  3201,               NULL,                N'109460992',       N'Rogelio Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP09

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Materia_Prima = 1, --600,
	Meses_Vencimiento_Avaluo_Materia_Prima = 9
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 5907

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930'
WHERE Id_Garantia_Real_Poliza = 4240


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
179,              3,                  5907,               NULL,                N'109460993',       N'Roger Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP10
UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Mobiliario = 1, --700,
	Meses_Vencimiento_Avaluo_Mobiliario = 8
WHERE Id_Parametro_Bien = 1

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160604',
	Fecha_Ultima_Tasacion_Garantia = '20160604'
WHERE Id_Garantia_Real = 3581

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 11241

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
181,              3,                  3581,               NULL,                N'109470995',       N'Norman Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP11

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Mobiliario = 1, --700,
	Meses_Vencimiento_Avaluo_Mobiliario = 8
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'
WHERE Id_Garantia_Real = 3207

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Monto_Poliza = 500000.00,
	Monto_Poliza_Colonizado = 500000.00
WHERE Id_Garantia_Real_Poliza = 1355


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
182,              3,                  3207,               NULL,                N'109470996',       N'Armando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP12

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Maderas = 1, --800,
	Meses_Vencimiento_Avaluo_Madera = 7
WHERE Id_Parametro_Bien = 1



UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 3307


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150630'
WHERE Id_Garantia_Real_Poliza = 1418



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
183,              3,                  3307,               NULL,                N'109470107',       N'German Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP13


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Maderas = 800,
	Meses_Vencimiento_Avaluo_Madera = 7
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 6037


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150930',
	Monto_Poliza = 1000.00,
	Monto_Poliza_Colonizado = 1000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 11598



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
184,              3,                  6037,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP14

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Aeronave = 1, --900,
	Meses_Vencimiento_Avaluo_Aeronave = 6
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 532


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Monto_Poliza = 5.00,
	Monto_Poliza_Colonizado = 5.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 36308



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
185,              3,                  532,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP15

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Aeronave = 1, --900,
	Meses_Vencimiento_Avaluo_Aeronave = 6
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'
WHERE Id_Garantia_Real = 3137


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190930',
	Monto_Poliza = 200000000.00,
	Monto_Poliza_Colonizado = 200000000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 1308



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
187,              3,                  3137,               NULL,                N'109470103',       N'Armando Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')







--ESCENARIO CP16

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Buque = 1, --150,
	Meses_Vencimiento_Avaluo_Buque = 5
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504'
WHERE Id_Garantia_Real = 3203


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150930',
	Monto_Poliza = 0.50,
	Monto_Poliza_Colonizado = 0.50
WHERE Id_Garantia_Real_Poliza = 1353



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
188,              3,                  3203,               NULL,                N'109470105',       N'Amanda Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP17

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Buque = 1, --150,
	Meses_Vencimiento_Avaluo_Buque = 5
WHERE Id_Parametro_Bien = 1


UPDATE dbo.FIDEICOMISOS
SET Fecha_Constitucion = '20160715',
	Fecha_Vencimiento = '20180715'
WHERE Id_Fideicomiso = 144

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160504',
	Fecha_Ultima_Tasacion_Garantia = '20160504'
WHERE Id_Garantia_Real = 5774

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150630',
	Monto_Poliza = 700000.00,
	Monto_Poliza_Colonizado = 700000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4163


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
189,              3,                  5774,               NULL,                N'109470107',       N'German Cascante Segura',          1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')




--ESCENARIO CP18


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Animal = 250,
	Meses_Vencimiento_Avaluo_Animal = 4
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'
WHERE Id_Garantia_Real = 3209


DELETE FROM dbo.GARANTIAS_REALES_POLIZAS
WHERE Id_Garantia_Real_Poliza = 1357



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
190,              3,                  3209,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP19


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Animal = 250,
	Meses_Vencimiento_Avaluo_Animal = 4
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'
WHERE Id_Garantia_Real = 5824


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150930'
WHERE Id_Garantia_Real_Poliza = 4190



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
191,              3,                  5824,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')





--ESCENARIO CP20

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Animal = 250,
	Meses_Vencimiento_Avaluo_Animal = 4
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'
WHERE Id_Garantia_Real = 5914

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150630',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4244


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
192,              3,                  5914,               NULL,                N'109470104',       N'Laura Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 0,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP21


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Cultivo_Fruto = 350,
	Meses_Vencimiento_Avaluo_Cultivo_Fruto = 3
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'
WHERE Id_Garantia_Real = 3210

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20150630',
	Monto_Poliza = 20000.00,
	Monto_Poliza_Colonizado = 20000.00
WHERE Id_Garantia_Real_Poliza = 1358


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
193,              3,                  3210,               NULL,                N'109470106',       N'Lesli Cascante Segura',           1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP22


UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Cultivo_Fruto = 350,
	Meses_Vencimiento_Avaluo_Cultivo_Fruto = 3
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160304',
	Fecha_Ultima_Tasacion_Garantia = '20160304'
WHERE Id_Garantia_Real = 3326

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza = 0.50,
	Monto_Poliza_Colonizado = 0.50
WHERE Id_Garantia_Real_Poliza = 1428


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
194,              3,                  3326,               NULL,                N'109470108',       N'Lesli Segura Rojas',              1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP23

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Alhaja = 450,
	Meses_Vencimiento_Avaluo_Alhaja = 2
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'	
WHERE Id_Garantia_Real = 5780

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza = 10000.00,
	Monto_Poliza_Colonizado = 10000.00,
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4164

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
195,              3,                  5780,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP24

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Otros_Bienes = 550,
	Meses_Vencimiento_Avaluo_Otro_Tipo_Bien = 10
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'
WHERE Id_Garantia_Real = 5782

UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Coberturas = 0
WHERE Id_Garantia_Real_Poliza = 4166


INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
196,              3,                  5782,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')



--ESCENARIO CP26

UPDATE dbo.PARAMETROS_BIENES
SET Meses_Seguimiento_Maquinaria_Equipo = 400,
	Meses_Vencimiento_Avaluo_Maquinaria_Equipo = 11,
	Meses_Seguimiento_Alhaja = 450,
	Meses_Vencimiento_Avaluo_Alhaja = 2
WHERE Id_Parametro_Bien = 1


UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160404',
	Fecha_Ultima_Tasacion_Garantia = '20160404'	
WHERE Id_Garantia_Real = 5905

UPDATE dbo.GARANTIAS_REALES
SET Fecha_Ultimo_Seguimiento_Garantia = '20160704',
	Fecha_Ultima_Tasacion_Garantia = '20160704'	
WHERE Id_Garantia_Real = 5916


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza_Colonizado = NULL
WHERE Id_Garantia_Real_Poliza = 4238


UPDATE dbo.GARANTIAS_REALES_POLIZAS
SET Fecha_Vencimiento = '20190630',
	Monto_Poliza_Colonizado = NULL
WHERE Id_Garantia_Real_Poliza = 4246



INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
197,              3,                  5905,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')

INSERT [dbo].[GARANTIAS_FIDEICOMETIDAS] (
[Id_Fideicomiso], [Id_Tipo_Garantia], [Id_Garantia_Real], [Id_Garantia_Valor], [Id_Dueno],         [Nombre_Dueno],                     [Id_Tipo_Moneda_Valor_Nominal], [Valor_Nominal],              [Monto_Mitigador],            [Porcentaje_Aceptacion_No_Terreno_SUGEF], [Porcentaje_Aceptacion_Terreno_SUGEF], [Porcentaje_Aceptacion_SUGEF], [Porcentaje_Aceptacion_BCR],  [Id_Tipo_Mitigador_Riesgo], [Id_Tipo_Documento_Legal], [Id_Tipo_Indicador_Inscripcion], [Fecha_Presentacion], [Id_Formato_Identificacion_Vehiculo], [Ind_Deudor_Habita], [Ind_Estado_Registro], [Ind_Metodo_Insercion], [Fecha_Ingreso],                              [Cod_Usuario_Ingreso], [Fecha_Ultima_Modificacion], [Cod_Usuario_Ultima_Modificacion], [Ind_Accion_Registro]) VALUES (
198,              3,                  5916,               NULL,                N'109470109',       N'Joaquin Cascante Segura',         1,                              CAST(0.00 AS Numeric(24, 2)), CAST(0.00 AS Numeric(24, 2)), CAST(40.00 AS Decimal(5, 2)),             CAST(40.00 AS Decimal(5, 2)),          CAST(00.00 AS Numeric(5, 2)),  CAST(60.00 AS Numeric(5, 2)), 8,                          10,                        1,                               NULL,                 NULL,                                 1,                   1,                     N'MANTENIMIENTO',       CAST(N'2016-04-13 16:21:37.960' AS DateTime), N'113370655',          NULL,                        NULL,                              N'I')


