
--exec [Calculo_Porcentaje_Aceptacion_No_Terreno_SUGEF]

CREATE PROCEDURE [dbo].[Calculo_Porcentaje_Aceptacion_No_Terreno_SUGEF]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Porcentaje_Aceptacion_No_Terreno_SUGEF</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo automático Porcentaje Aceptación No Terreno SUGEF
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Alexander Cruz</Autor>
<Fecha>Octubre 2015</Fecha>
<Requerimiento>RQ_MANT_2015062310417367_00040 Porcentaje Aceptación No Terreno SUGEF</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor></Autor>
		<Requerimiento></Requerimiento>
		<Fecha></Fecha>
		<Descripción></Descripción>
	</Cambio>
</Historial>
******************************************************************************************************************************************************/
BEGIN
	BEGIN TRANSACTION TRA_Insertar
	BEGIN TRY

	IF OBJECT_ID('[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO]') is not null
		DROP TABLE [dbo].[AUX_GAR_PRC_ACP_NO_TERRENO]


	CREATE TABLE [dbo].AUX_GAR_PRC_ACP_NO_TERRENO(
		[Id_Garantia_Operacion] [int] NOT NULL,
		[Cod_Tipo_Bien] [int] NULL,
		[Cod_Clase_Tipo_Bien] [int] NULL,
		[Validacion_1] [int] NOT NULL,
		[Validacion_2] [int] NOT NULL,
		[Validacion_3] [int] NOT NULL,
		[Validacion_4] [int] NOT NULL,
		[Validacion_5] [int] NOT NULL,
		[Validacion_6] [int] NOT NULL,
		[Validacion_7] [int] NOT NULL,
		[Validacion_8] [int] NOT NULL,
		[Validacion_9] [int] NOT NULL,
		[Validacion_10] [int] NOT NULL,
		[Porcentaje_Aceptacion_No_Terreno_SUGEF] [decimal](5, 2) NULL
	) ON [PRIMARY]
	

	INSERT INTO dbo.AUX_GAR_PRC_ACP_NO_TERRENO
			   (Id_Garantia_Operacion,
				Cod_Tipo_Bien,
				Cod_Clase_Tipo_Bien,
				Validacion_1,
				Validacion_2,
				Validacion_3,
				Validacion_4,
				Validacion_5,
				Validacion_6,
				Validacion_7,
				Validacion_8,
				Validacion_9,
				Validacion_10,
				Porcentaje_Aceptacion_No_Terreno_SUGEF
				)
		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN GRI.Fecha_Anotacion IS NOT NULL AND GRI.Fecha_Inscripcion IS NOT NULL 
									THEN 1
									ELSE 0
							END,
			Validacion_2 = CASE WHEN GRI.Fecha_Anotacion IS NULL AND GRI.Fecha_Inscripcion IS NULL AND (DATEADD(D,30,GAROPER.Fecha_Constitucion_Garantia)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_3 = CASE WHEN GRI.Fecha_Anotacion IS NULL AND GRI.Fecha_Inscripcion IS NOT NULL 
								THEN 1
								ELSE 0
							END,
			Validacion_4 = CASE WHEN GRI.Fecha_Anotacion IS NOT NULL AND GRI.Fecha_Inscripcion IS NULL AND (DATEADD(D,60,GAROPER.Fecha_Constitucion_Garantia)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_5 = CASE WHEN DATEADD(M,PAR.Meses_Vencimiento_Avaluo_SUGEF_Edificacion,GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN DATEADD(M,PAR.Meses_Seguimiento_Edificacion,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_7 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_8 = CASE WHEN DATEADD(D,30,GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_9 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_10 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2
			AND CTB.Cod_Clase_Tipo_Bien IN (1,3)
	
	UNION
		--Cedula Hipotecaria
		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN DATEADD(M,PAR.Meses_Vencimiento_Avaluo_SUGEF_Edificacion,GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_2 = CASE WHEN DATEADD(M,PAR.Meses_Seguimiento_Edificacion,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_3 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_4 = CASE WHEN DATEADD(D,30,GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_5 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			Validacion_7 = 0,
			Validacion_8 = 0,
			Validacion_9 = 0,
			Validacion_10 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 2
			AND CTB.Cod_Clase_Tipo_Bien = 2
	
	UNION
		--Bono Prenda
		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = 0,
			Validacion_2 = 0,
			Validacion_3 = 0,
			Validacion_4 = 0,
			Validacion_5 = 0,
			Validacion_6 = 0,
			Validacion_7 = 0,
			Validacion_8 = 0,
			Validacion_9 = 0,
			Validacion_10 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 3
			AND CTB.Cod_Clase_Tipo_Bien = 3

	UNION 
	--Prenda Comun
		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN GRI.Fecha_Anotacion IS NOT NULL AND GRI.Fecha_Inscripcion IS NOT NULL 
						THEN 1
						ELSE 0
				END,
			Validacion_2 = CASE WHEN GRI.Fecha_Anotacion IS NULL AND GRI.Fecha_Inscripcion IS NULL AND (DATEADD(D,30,GAROPER.Fecha_Constitucion_Garantia)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_3 = CASE WHEN GRI.Fecha_Anotacion IS NULL AND GRI.Fecha_Inscripcion IS NOT NULL 
								THEN 1
								ELSE 0
							END,
			Validacion_4 = CASE WHEN GRI.Fecha_Anotacion IS NOT NULL AND GRI.Fecha_Inscripcion IS NULL AND (DATEADD(D,60,GAROPER.Fecha_Constitucion_Garantia)) > GETDATE()
								THEN 1
								ELSE 0
							END,
			Validacion_5 = CASE WHEN DATEADD(M,PAR.Meses_Seguimiento_Vehiculo,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_7 = CASE WHEN DATEADD(D,30,GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_8 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_9 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			Validacion_10 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		INNER JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 3
			AND CTB.Cod_Clase_Tipo_Bien = 2

	UNION

		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN DATEADD(M,CASE WHEN TPB.Cod_Tipo_Bien = 4 --Maquinaria Equipo
													THEN  PAR.Meses_Vencimiento_Avaluo_Maquinaria_Equipo
													WHEN TPB.Cod_Tipo_Bien = 6 --Materia Prima
													THEN  PAR.Meses_Vencimiento_Avaluo_Materia_Prima
													WHEN TPB.Cod_Tipo_Bien = 7 --Mobiliario
													THEN  PAR.Meses_Vencimiento_Avaluo_Mobiliario
													WHEN TPB.Cod_Tipo_Bien = 8 --Maderas
													THEN  PAR.Meses_Vencimiento_Avaluo_Madera
													WHEN TPB.Cod_Tipo_Bien = 9 --Aeronave
													THEN  PAR.Meses_Vencimiento_Avaluo_Aeronave
													WHEN TPB.Cod_Tipo_Bien = 10 --Buques
													THEN  PAR.Meses_Vencimiento_Avaluo_Buque
													WHEN TPB.Cod_Tipo_Bien = 11 --Animales
													THEN  PAR.Meses_Vencimiento_Avaluo_Animal
													WHEN TPB.Cod_Tipo_Bien = 12 --Cultivos y Frutos
													THEN  PAR.Meses_Vencimiento_Avaluo_Cultivo_Fruto
													WHEN TPB.Cod_Tipo_Bien = 13 --Alhaja
													THEN  PAR.Meses_Vencimiento_Avaluo_Alhaja
													WHEN TPB.Cod_Tipo_Bien = 14 --Otros Bienes
													THEN  PAR.Meses_Vencimiento_Avaluo_Otro_Tipo_Bien
												END,GAR.Fecha_Ultima_Tasacion_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_2 = CASE WHEN DATEADD(M,CASE WHEN TPB.Cod_Tipo_Bien = 4 --Maquinaria Equipo
													THEN  PAR.Meses_Seguimiento_Maquinaria_Equipo
													WHEN TPB.Cod_Tipo_Bien = 6 --Materia Prima
													THEN  PAR.Meses_Seguimiento_Materia_Prima
													WHEN TPB.Cod_Tipo_Bien = 7 --Mobiliario
													THEN  PAR.Meses_Seguimiento_Mobiliario
													WHEN TPB.Cod_Tipo_Bien = 8 --Maderas
													THEN  PAR.Meses_Seguimiento_Maderas
													WHEN TPB.Cod_Tipo_Bien = 9 --Aeronave
													THEN  PAR.Meses_Seguimiento_Aeronave
													WHEN TPB.Cod_Tipo_Bien = 10 --Buques
													THEN  PAR.Meses_Seguimiento_Buque
													WHEN TPB.Cod_Tipo_Bien = 11 --Animales
													THEN  PAR.Meses_Seguimiento_Animal
													WHEN TPB.Cod_Tipo_Bien = 12 --Cultivos y Frutos
													THEN  PAR.Meses_Seguimiento_Cultivo_Fruto
													WHEN TPB.Cod_Tipo_Bien = 13 --Alhaja
													THEN  PAR.Meses_Seguimiento_Alhaja
													WHEN TPB.Cod_Tipo_Bien = 14 --Otros Bienes
													THEN  PAR.Meses_Seguimiento_Otros_Bienes
												END,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_3 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_4 = CASE WHEN DATEADD(D,30,GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_5 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			Validacion_7 = 0,
			Validacion_8 = 0,
			Validacion_9 = 0,
			Validacion_10 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)

	UNION

		SELECT 
			GAROPER.Id_Garantia_Operacion,
			TPB.Cod_Tipo_Bien,
			CTB.Cod_Clase_Tipo_Bien,
			Validacion_1 = CASE WHEN DATEADD(M,PAR.Meses_Seguimiento_Equipo_Computo,GAR.Fecha_Ultimo_Seguimiento_Garantia) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_2 = CASE WHEN GARPOL.Id_Garantia_Real_Poliza IS NOT NULL
								THEN 1
								ELSE 0							
							END,
			Validacion_3 = CASE WHEN DATEADD(D,30,GARPOL.Fecha_Vencimiento) > GETDATE()
								THEN 1
								ELSE 0							
							END,
			Validacion_4 = CASE WHEN GARPOL.Monto_Poliza_Colonizado >= GAR.Monto_Ultima_Tasacion_No_Terreno
								THEN 1
								ELSE 0							
							END,
			Validacion_5 = CASE WHEN GARPOL.Coberturas = 1
								THEN 1
								ELSE 0							
							END,
			Validacion_6 = 0,
			Validacion_7 = 0,
			Validacion_8 = 0,
			Validacion_9 = 0,
			Validacion_10 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_REALES GAR
			ON GAROPER.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GAR.Ind_Estado_Registro = 1
		INNER JOIN dbo.TIPOS_BIENES TPB
			ON TPB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND TPB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CLASES_TIPOS_BIENES CTB
			ON CTB.Id_Clase_Tipo_Bien = GAR.Id_Clase_Tipo_Bien
			AND CTB.Id_Tipo_Bien = GAR.Id_Tipo_Bien
			AND CTB.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
			ON GRI.Id_Garantia_Operacion = GAROPER.Id_Garantia_Operacion
			AND GRI.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.GARANTIAS_REALES_POLIZAS GARPOL
			ON GARPOL.Id_Garantia_Real = GAR.Id_Garantia_Real
			AND GARPOL.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1
			AND TPB.Cod_Tipo_Bien = 5

	UNION
		--Fiduciarias
		SELECT 
			GAROPER.Id_Garantia_Operacion,
			Cod_Tipo_Bien = NULL,
			Cod_Clase_Tipo_Bien = NULL,
			Validacion_1 = 0,
			Validacion_2 = 0,
			Validacion_3 = 0,
			Validacion_4 = 0,
			Validacion_5 = 0,
			Validacion_6 = 0,
			Validacion_7 = 0,
			Validacion_8 = 0,
			Validacion_9 = 0,
			Validacion_10 = 0,
			CAT.Porc_Aceptacion_Calificacion_Riesgo Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_FIDUCIARIAS GAF
			ON GAROPER.Id_Garantia_Fiduciaria = GAF.Id_Garantia_Fiduciaria
			AND GAF.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = TM.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1

	UNION
		--Valores
		SELECT 
			GAROPER.Id_Garantia_Operacion,
			Cod_Tipo_Bien = NULL,
			Cod_Clase_Tipo_Bien = NULL,
			Validacion_1 = 0,
			Validacion_2 = 0,
			Validacion_3 = 0,
			Validacion_4 = 0,
			Validacion_5 = 0,
			Validacion_6 = 0,
			Validacion_7 = 0,
			Validacion_8 = 0,
			Validacion_9 = 0,
			Validacion_10 = 0,
			ISNULL(CAT.Porc_Aceptacion_Calificacion_Riesgo,CAT1.Porc_Aceptacion_Calificacion_Riesgo) Porcentaje_Aceptacion
		FROM 
			dbo.GARANTIAS_OPERACIONES GAROPER
		INNER JOIN dbo.GARANTIAS_VALORES GAV
			ON GAROPER.Id_Garantia_Valor = GAV.Id_Garantia_Valor
			AND GAV.Ind_Estado_Registro = 1
		LEFT JOIN dbo.TIPOS_MITIGADORES_RIESGOS TM
			ON TM.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT
			ON CAT.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
			AND CAT.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT.Id_Categoria_Calificacion = GAV.Id_Categoria_Riesgo_Empresa_Calificadora 
			AND CAT.Ind_Estado_Registro = 1
		LEFT JOIN dbo.CATEGORIAS_CALIFICACIONES_TIPOS_MITIGADORES_RIESGOS CAT1
			ON CAT1.Id_Tipo_Mitigador_Riesgo = GAROPER.Id_Tipo_Mitigador_Riesgo
			AND CAT1.Id_Tipo_Garantia = GAROPER.Id_Tipo_Garantia
			AND CAT1.Id_Categoria_Calificacion = 2 --NO APLICA CALIFICACION
			AND CAT1.Ind_Estado_Registro = 1
		INNER JOIN dbo.PARAMETROS_BIENES PAR
			ON 1 = 1
		WHERE
			GAROPER.Ind_Estado_Registro = 1

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_NO_TERRENO ON dbo.AUX_GAR_PRC_ACP_NO_TERRENO
	(
		Id_Garantia_Operacion ASC
	)

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_NO_TERRENO_1 ON dbo.AUX_GAR_PRC_ACP_NO_TERRENO
	(
		Cod_Tipo_Bien ASC
	)

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_NO_TERRENO_2 ON dbo.AUX_GAR_PRC_ACP_NO_TERRENO
	(
		Cod_Tipo_Bien ASC,
		Cod_Clase_Tipo_Bien ASC
	)

	IF OBJECT_ID('[dbo].[AUX_GAR_PRC_ACP_NO_TERRENO_R]') is not null
		DROP TABLE [dbo].AUX_GAR_PRC_ACP_NO_TERRENO_R

	CREATE TABLE [dbo].AUX_GAR_PRC_ACP_NO_TERRENO_R(
		[Id_Garantia_Operacion] [int] NOT NULL,
		[Porcentaje_Aceptacion_No_Terreno_SUGEF] [decimal](5, 2) NULL
	) ON [PRIMARY]
	

	INSERT INTO dbo.AUX_GAR_PRC_ACP_NO_TERRENO_R
		(
		Id_Garantia_Operacion,
		Porcentaje_Aceptacion_No_Terreno_SUGEF
		)
	SELECT 
		Id_Garantia_Operacion,
		MIN(Porcentaje_Aceptacion_No_Terreno_SUGEF)  Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM 
	(SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0 AND Validacion_4 = 0 THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)
	--UNION
	--SELECT 
	--	Id_Garantia_Operacion,
	--	CASE WHEN Validacion_2 = 0 THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	--FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	--WHERE Cod_Tipo_Bien = 2
	--UNION
	--SELECT 
	--	Id_Garantia_Operacion,
	--	CASE WHEN Validacion_3 = 0 THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	--FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	--WHERE Cod_Tipo_Bien = 2
	--UNION
	--SELECT 
	--	Id_Garantia_Operacion,
	--	CASE WHEN Validacion_4 = 0 THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	--FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	--WHERE Cod_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)
	UNION
	SELECT 
		ACT.Id_Garantia_Operacion,
		CASE WHEN Validacion_6 = 0 THEN 
			CASE	WHEN GAROPER.Ind_Deudor_Habita = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
					WHEN GAROPER.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('A1','A2','B1','B2','C1') THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
					WHEN GAROPER.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('C2','D','E') THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
			END 
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Garantia_Operacion = ACT.Id_Garantia_Operacion
	INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_7 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_8 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_9 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2 
	AND Cod_Clase_Tipo_Bien IN (1,3)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_10 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)
	UNION
	--Tipo Bien 2 Cedula Hipotecaria
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_1 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		ACT.Id_Garantia_Operacion,
		CASE WHEN Validacion_2 = 0 THEN 
			CASE	WHEN GAROPER.Ind_Deudor_Habita = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
					WHEN GAROPER.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('A1','A2','B1','B2','C1') THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
					WHEN GAROPER.Ind_Deudor_Habita = 1 AND OPER.Categoria_Riesgo_Deudor IN ('C2','D','E') THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
			END 
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Garantia_Operacion = ACT.Id_Garantia_Operacion
	INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_3 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_4 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_6 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	--Tipo Bien 3 Prenda Comun
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_1 = 0 AND Validacion_2 = 0 AND Validacion_3 = 0 AND Validacion_4 = 0 THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 3
	AND Cod_Clase_Tipo_Bien = 2
	--UNION
	--SELECT 
	--	Id_Garantia_Operacion,
	--	CASE WHEN Validacion_2 = 0 THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	--FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	--WHERE Cod_Tipo_Bien = 3
	--AND Id_Clase_Tipo_Bien = 7
	--UNION
	--SELECT 
	--	Id_Garantia_Operacion,
	--	CASE WHEN Validacion_3 = 0 THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	--FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	--WHERE Cod_Tipo_Bien = 3
	--AND Id_Clase_Tipo_Bien = 7
	--UNION
	--SELECT 
	--	Id_Garantia_Operacion,
	--	CASE WHEN Validacion_4 = 0 THEN 0 END Porcentaje_Aceptacion_No_Terreno_SUGEF
	--FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	--WHERE Cod_Tipo_Bien = 3
	--AND Id_Clase_Tipo_Bien = 7
	UNION
	SELECT 
		ACT.Id_Garantia_Operacion,
		CASE WHEN Validacion_5 = 0 THEN 
			CASE	WHEN OPER.Categoria_Riesgo_Deudor IN ('A1','A2','B1','B2','C1') THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
					WHEN OPER.Categoria_Riesgo_Deudor IN ('C2','D','E') THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2)
			END 
		END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	INNER JOIN dbo.GARANTIAS_OPERACIONES GAROPER
		ON GAROPER.Id_Garantia_Operacion = ACT.Id_Garantia_Operacion
	INNER JOIN dbo.OPERACIONES OPER
		ON OPER.Id_Operacion = GAROPER.Id_Operacion
	WHERE Cod_Tipo_Bien = 3
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_6 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 3
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_7 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 3
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_8 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 3
	AND Cod_Clase_Tipo_Bien = 2
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_9 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 3
	AND Cod_Clase_Tipo_Bien = 2
	--Tipo Bien 3 Bono Prenda
	UNION
	SELECT 
		Id_Garantia_Operacion,
		ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 3
	AND Cod_Clase_Tipo_Bien = 3
	-- Tipo Bien 4,6,7,8,9,10,11,12,13,14
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_1 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)	
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_2 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_3 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_4 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_6 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)
	--Tipo Bien 5
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_1 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 5
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_2 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 5
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_3 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 5
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_4 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 5
	UNION
	SELECT 
		Id_Garantia_Operacion,
		CASE WHEN Validacion_5 = 0 THEN (ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF / 2) END Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 5
	UNION
	--Fiduciarias y Valores
	SELECT 
		Id_Garantia_Operacion,
		Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IS NULL
	AND Cod_Clase_Tipo_Bien IS NULL
) T
	GROUP BY T.Id_Garantia_Operacion

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_PRC_ACP_NO_TERRENO_R ON dbo.AUX_GAR_PRC_ACP_NO_TERRENO_R
	(
		Id_Garantia_Operacion ASC
	)

	--Tipo Bien 2 Hipoteca Comun - Hipoetca Abierta
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF =	CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1 OR Validacion_4 = 1) 
																	AND (Validacion_5 = 1 AND Validacion_6 = 1 AND Validacion_7 = 1 AND Validacion_8 = 1 AND Validacion_9 = 1 
																	     AND Validacion_10 = 1)
													 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
												END 
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien IN (1,3)

	--Tipo Bien 2 Cedula Hipotecaria
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF =	CASE WHEN (Validacion_1 = 1 AND Validacion_2 = 1 AND Validacion_3 = 1 AND Validacion_4 = 1
																	AND Validacion_5 = 1 AND Validacion_6 = 1)
													 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
												END 
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 2
	AND Cod_Clase_Tipo_Bien = 2

	--Tipo Bien 3 Prenda Comun
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF =	CASE WHEN (Validacion_1 = 1 OR Validacion_2 = 1 OR Validacion_3 = 1 OR Validacion_4 = 1) 
																	AND (Validacion_5 = 1 AND Validacion_6 = 1 AND Validacion_7 = 1 AND Validacion_8 = 1 AND Validacion_9 = 1)
													 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
												END 
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 3
	AND Cod_Clase_Tipo_Bien = 2

	--Tipo Bien 3 Bono Prenda
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF = ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 3
	AND Cod_Clase_Tipo_Bien = 3

	--Tipo Bien 4,6,7,8,9,10,11,12,13,14
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF =	CASE WHEN Validacion_1 = 1 AND
													 	  Validacion_2 = 1 AND
														  Validacion_3 = 1 AND
														  Validacion_4 = 1 AND
													      Validacion_5 = 1 AND
														  Validacion_6 = 1
													 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
												END 
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IN (4,6,7,8,9,10,11,12,13,14)

	--Tipo Bien 5
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF =	CASE WHEN Validacion_1 = 1 AND 
													 	  Validacion_2 = 1 AND
														  Validacion_3 = 1 AND
														  Validacion_4 = 1 AND
													      Validacion_5 = 1
													 THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
												END 
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien = 5

	--Fiduciarias y Valores
	UPDATE	ACT
		SET ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF = ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
	FROM		dbo.AUX_GAR_PRC_ACP_NO_TERRENO ACT
	WHERE Cod_Tipo_Bien IS NULL
	AND Cod_Clase_Tipo_Bien IS NULL
		
	UPDATE		GAR
	SET			GAR.Porcentaje_Aceptacion_No_Terreno_SUGEF =	CASE WHEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF IS NOT NULL
																THEN ACT.Porcentaje_Aceptacion_No_Terreno_SUGEF
																ELSE ACT_1.Porcentaje_Aceptacion_No_Terreno_SUGEF
															END
	FROM		
		dbo.GARANTIAS_OPERACIONES GAR
	INNER JOIN	AUX_GAR_PRC_ACP_NO_TERRENO ACT 
		ON GAR.Id_Garantia_Operacion = ACT.Id_Garantia_Operacion
	INNER JOIN AUX_GAR_PRC_ACP_NO_TERRENO_R ACT_1
		ON GAR.Id_Garantia_Operacion = ACT_1.Id_Garantia_Operacion

		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END




