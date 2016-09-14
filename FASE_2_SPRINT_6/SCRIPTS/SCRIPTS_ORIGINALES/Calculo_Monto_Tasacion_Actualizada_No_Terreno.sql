
CREATE PROCEDURE [dbo].[Calculo_Monto_Tasacion_Actualizada_No_Terreno]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Monto_Tasacion_Actualizada_No_Terreno</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo automático monto tasación actualizada no terreno
	Esta formulación no aplica para bienes tipo 1
</Descripción>
<Entradas></Entradas>
<Salidas></Salidas>
<Autor>Genoveva Salmeron</Autor>
<Fecha>Agosto 2015</Fecha>
<Requerimiento>RQ_MANT_2015042110384902_00040 – Monto tasación actualizada terreno y no terreno</Requerimiento>
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
--TIPO BIEN 2
BEGIN
	BEGIN TRANSACTION TRA_Insertar
	BEGIN TRY

	IF OBJECT_ID('[dbo].[AUX_GAR_MTO_ACT_NO_TERRENO]') is not null
		DROP TABLE [dbo].[AUX_GAR_MTO_ACT_NO_TERRENO]

	CREATE TABLE [dbo].[AUX_GAR_MTO_ACT_NO_TERRENO](
		[Id_Garantia_Real] [int] NOT NULL,
		[Cod_Tipo_Bien] [int] NOT NULL,
		[Id_Clase_Tipo_Bien] [int] NULL,
		[Fecha_Ultima_Tasacion_Garantia] [datetime] NULL,
		[Años_Construccion_Garantia] [int] NULL,
		[Ajuste_Fecha_Fabricacion_Garantia] [datetime] NOT NULL,
		[Dias_Transcurridos] [int] NOT NULL,
		[Periodos] [int] NOT NULL,
		[Monto_Ultima_Tasacion_No_Terreno] [numeric](22, 2) NOT NULL,
		[Monto_Tasacion_Actualizada_No_Terreno] [decimal](22, 2) NULL,
		[Monto_Depreciacion] [decimal](22, 2) NULL,
		[Ciclo] [int] NOT NULL,
		[Pcj_Dep] [decimal](6, 5) NULL,
		[Pcj_Dev] [decimal](6, 5) NULL,
		[Pcj_Inf] [decimal](6, 5) NULL,
		[Pcje] [decimal](6, 5) NULL,
		[Fecha_Calculo] [datetime] NULL,
		[Ind_Nueva] [varchar](3) NULL,
		[Monto_Actualizado] [decimal](22, 2) NULL
	) ON [PRIMARY]
	

	INSERT INTO dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SELECT DISTINCT
			Id_Garantia_Real,
			Cod_Tipo_Bien,
			GR.Id_Clase_Tipo_Bien,
			Fecha_Ultima_Tasacion_Garantia =	(CASE WHEN Fecha_Ultima_Tasacion_Garantia IS NOT NULL THEN dateadd(month,6,(Fecha_Ultima_Tasacion_Garantia))
												ELSE ISNULL(Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE())) END),
			Años_Construccion_Garantia	=		(CASE WHEN Fecha_Construccion_Garantia IS NOT NULL THEN datediff(year,(Fecha_Construccion_Garantia),CONVERT(DATE,GETDATE()))
												ELSE 0 END),
			Ajuste_Fecha_Fabricacion_Garantia = ISNULL(Fecha_Fabricacion_Garantia,'1900-01-01'),
			Dias_Transcurridos = 0,
			Periodos = 0,
			Monto_Ultima_Tasacion_No_Terreno =	ISNULL(Monto_Ultima_Tasacion_No_Terreno,0),
			Monto_Tasacion_Actualizada_No_Terreno = CAST((CASE	WHEN Monto_Tasacion_Actualizada_No_Terreno IS NULL THEN ISNULL(Monto_Ultima_Tasacion_No_Terreno,0)
																WHEN Fecha_Ultima_Tasacion_Garantia IS NULL THEN ISNULL(Monto_Tasacion_Actualizada_No_Terreno,0)
																ELSE ISNULL(Monto_Tasacion_Actualizada_No_Terreno,0)
													END) AS DECIMAL(22,2)),
			Monto_Depreciacion = CAST(	(CASE	WHEN Monto_Ultima_Tasacion_No_Terreno IS NULL THEN 0
																	WHEN Fecha_Ultima_Tasacion_Garantia IS NULL THEN ISNULL(Monto_Tasacion_Actualizada_No_Terreno,0)
															ELSE ISNULL(Monto_Ultima_Tasacion_No_Terreno,0)
														END) AS DECIMAL(22,2)),
			Ciclo	= 0,
			Pcj_Dep = CAST(0 AS DECIMAL(6,2)),
			Pcj_Dev = CAST(0 AS DECIMAL(6,2)),
			Pcj_Inf = CAST(0 AS DECIMAL(6,2)),
			Pcje	= CAST(0 AS DECIMAL(6,2)),
			Fecha_Calculo = DATEADD(MONTH,6,ISNULL(AUX.Fecha_Calculo,ISNULL(GR.Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE())))),
			Ind_Nueva = CASE WHEN AUX.Fecha_Calculo IS NULL THEN 'S' ELSE 'N' END,
			Monto_Actualizado = AUX.Monto_Actualizado
	FROM	dbo.GARANTIAS_REALES GR 
	INNER JOIN dbo.TIPOS_BIENES TB 
		ON GR.Id_Tipo_Bien = TB.Id_Tipo_Bien 
	LEFT JOIN dbo.AUX_ACTUALIZAGARANTIAS AUX
		ON ISNULL(AUX.Id_Clase_Aeronave,-1) = ISNULL(GR.Id_Clase_Aeronave,-1)
		AND ISNULL(AUX.Id_Clase_Buque,-1) = ISNULL(GR.Id_Clase_Buque,-1)
		AND ISNULL(AUX.Id_Clase_Tipo_Bien,-1) = ISNULL(GR.Id_Clase_Tipo_Bien,-1)
		AND ISNULL(AUX.Id_Clase_Vehiculo,-1) = ISNULL(GR.Id_Clase_Vehiculo,-1)
		AND ISNULL(AUX.Id_Provincia,-1) = ISNULL(GR.Id_Provincia,-1)
		AND ISNULL(AUX.Id_Tipo_Bien,-1) = ISNULL(GR.Id_Tipo_Bien,-1)
		AND AUX.Codigo_Bien = GR.Codigo_Bien
		AND ISNULL(AUX.Id_Codigo_Duplicado,-1) = ISNULL(GR.Id_Codigo_Duplicado,-1)
		AND ISNULL(AUX.Id_Codigo_Horizontalidad,-1) = ISNULL(GR.Id_Codigo_Horizontalidad,-1)
		--AND ISNULL(AUX.Id_Tipo_Liquidez,-1) = ISNULL(GR.Id_Tipo_Liquidez,-1)
		AND ISNULL(AUX.Formato_Identificacion_Vehiculo,-1) = ISNULL(GR.Formato_Identificacion_Vehiculo,-1)
		AND ISNULL(AUX.Fecha_Ultima_Tasacion,'1900-01-01') = ISNULL(GR.Fecha_Ultima_Tasacion_Garantia,'1900-01-01')
		AND AUX.Ind_Bien = 'N'
	WHERE	TB.Cod_Tipo_Bien = 2
	AND		GR.Ind_Estado_Registro = 1
	AND		GR.Estado_Registro_Garantia = 1	
	--------------------------------------------------------------------------

	--tipo bien 3 clase prenda comun y tipo bien 5
	INSERT INTO dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SELECT DISTINCT
			Id_Garantia_Real,
			Cod_Tipo_Bien,
			GR.Id_Clase_Tipo_Bien,
			Fecha_Ultima_Tasacion_Garantia		=	(CASE WHEN Fecha_Ultima_Tasacion_Garantia IS NOT NULL THEN dateadd(month,6,(Fecha_Ultima_Tasacion_Garantia))
													ELSE ISNULL(Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE())) END),
			Años_Construccion_Garantia	=		(CASE WHEN Fecha_Construccion_Garantia IS NOT NULL THEN datediff(year,(Fecha_Construccion_Garantia),CONVERT(DATE,GETDATE()))
												ELSE 0 END),
			Ajuste_Fecha_Fabricacion_Garantia	=	(CASE WHEN Fecha_Fabricacion_Garantia IS NOT NULL THEN dateadd(month,/*6*/0,(Fecha_Fabricacion_Garantia))
														ELSE ISNULL(Fecha_Fabricacion_Garantia,'1900-01-01') END),
			Dias_Transcurridos = 0,
			Periodos = 0,
			Monto_Ultima_Tasacion_No_Terreno	= ISNULL(Monto_Ultima_Tasacion_No_Terreno,0),
			Monto_Tasacion_Actualizada_No_Terreno	= CAST(	(CASE	WHEN Monto_Ultima_Tasacion_No_Terreno IS NULL THEN 0
																	WHEN Fecha_Fabricacion_Garantia IS NULL THEN ISNULL(Monto_Tasacion_Actualizada_No_Terreno,0)
															ELSE ISNULL(Monto_Ultima_Tasacion_No_Terreno,0)
														END) AS DECIMAL(22,2)),
			Monto_Depreciacion = CAST(	(CASE	WHEN Monto_Ultima_Tasacion_No_Terreno IS NULL THEN 0
																	WHEN Fecha_Ultima_Tasacion_Garantia IS NULL THEN ISNULL(Monto_Tasacion_Actualizada_No_Terreno,0)
															ELSE ISNULL(Monto_Ultima_Tasacion_No_Terreno,0)
														END) AS DECIMAL(22,2)),
			Ciclo	= 0,
			Pcj_Dep = CAST(0 AS DECIMAL(6,2)),
			Pcj_Dev = CAST(0 AS DECIMAL(6,2)),
			Pcj_Inf = CAST(0 AS DECIMAL(6,2)),
			Pcje	= CAST(0 AS DECIMAL(6,2)),
			Fecha_Calculo = DATEADD(MONTH,6,ISNULL(AUX.Fecha_Calculo,ISNULL(GR.Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE())))),
			Ind_Nueva = CASE WHEN AUX.Fecha_Calculo IS NULL THEN 'S' ELSE 'N' END,
			Monto_Actualizado = AUX.Monto_Actualizado
	FROM	dbo.GARANTIAS_REALES GR 
	INNER JOIN dbo.TIPOS_BIENES TB ON GR.Id_Tipo_Bien = TB.Id_Tipo_Bien 
	LEFT JOIN dbo.AUX_ACTUALIZAGARANTIAS AUX
		ON ISNULL(AUX.Id_Clase_Aeronave,-1) = ISNULL(GR.Id_Clase_Aeronave,-1)
		AND ISNULL(AUX.Id_Clase_Buque,-1) = ISNULL(GR.Id_Clase_Buque,-1)
		AND ISNULL(AUX.Id_Clase_Tipo_Bien,-1) = ISNULL(GR.Id_Clase_Tipo_Bien,-1)
		AND ISNULL(AUX.Id_Clase_Vehiculo,-1) = ISNULL(GR.Id_Clase_Vehiculo,-1)
		AND ISNULL(AUX.Id_Provincia,-1) = ISNULL(GR.Id_Provincia,-1)
		AND ISNULL(AUX.Id_Tipo_Bien,-1) = ISNULL(GR.Id_Tipo_Bien,-1)
		AND AUX.Codigo_Bien = GR.Codigo_Bien
		AND ISNULL(AUX.Id_Codigo_Duplicado,-1) = ISNULL(GR.Id_Codigo_Duplicado,-1)
		AND ISNULL(AUX.Id_Codigo_Horizontalidad,-1) = ISNULL(GR.Id_Codigo_Horizontalidad,-1)
		--AND ISNULL(AUX.Id_Tipo_Liquidez,-1) = ISNULL(GR.Id_Tipo_Liquidez,-1)
		AND ISNULL(AUX.Formato_Identificacion_Vehiculo,-1) = ISNULL(GR.Formato_Identificacion_Vehiculo,-1)
		AND ISNULL(AUX.Fecha_Ultima_Tasacion,'1900-01-01') = ISNULL(GR.Fecha_Ultima_Tasacion_Garantia,'1900-01-01')
		AND AUX.Ind_Bien = 'N'
	WHERE	(TB.Cod_Tipo_Bien = 3 AND GR.Id_Clase_Tipo_Bien in (7,8))
	OR		TB.Cod_Tipo_Bien = 5
	AND		GR.Ind_Estado_Registro = 1
	AND		GR.Estado_Registro_Garantia = 1

	--------------------------------------------------------------------------------------------------

	--tipo bien in (4,6,7,8,9,10,11,12,13,14)
	INSERT INTO	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SELECT DISTINCT
			Id_Garantia_Real,
			Cod_Tipo_Bien,
			GR.Id_Clase_Tipo_Bien,
			Fecha_Ultima_Tasacion_Garantia =	(CASE WHEN Fecha_Ultima_Tasacion_Garantia IS NOT NULL THEN dateadd(month,6,(Fecha_Ultima_Tasacion_Garantia))
												ELSE ISNULL(Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE())) END),
			Años_Construccion_Garantia	=		(CASE WHEN Fecha_Construccion_Garantia IS NOT NULL THEN datediff(year,(Fecha_Construccion_Garantia),CONVERT(DATE,GETDATE()))
												ELSE 0 END),
			Ajuste_Fecha_Fabricacion_Garantia = ISNULL(Fecha_Fabricacion_Garantia,'1900-01-01'),
			Dias_Transcurridos = 0,
			Periodos = 0,
			Monto_Ultima_Tasacion_No_Terreno =	ISNULL(Monto_Ultima_Tasacion_No_Terreno,0),
			Monto_Tasacion_Actualizada_No_Terreno = CAST((CASE	WHEN Monto_Ultima_Tasacion_No_Terreno IS NULL THEN 0
																WHEN Fecha_Ultima_Tasacion_Garantia IS NULL THEN ISNULL(Monto_Tasacion_Actualizada_No_Terreno,0)
																ELSE ISNULL(Monto_Ultima_Tasacion_No_Terreno,0)
													END) AS DECIMAL(22,2)),
			Monto_Depreciacion = CAST(	(CASE	WHEN Monto_Ultima_Tasacion_No_Terreno IS NULL THEN 0
																	WHEN Fecha_Ultima_Tasacion_Garantia IS NULL THEN ISNULL(Monto_Tasacion_Actualizada_No_Terreno,0)
															ELSE ISNULL(Monto_Ultima_Tasacion_No_Terreno,0)
														END) AS DECIMAL(22,2)),
			Ciclo	= 0,
			Pcj_Dep = CAST(0 AS DECIMAL(6,2)),
			Pcj_Dev = CAST(0 AS DECIMAL(6,2)),
			Pcj_Inf = CAST(0 AS DECIMAL(6,2)),
			Pcje	= CAST(0 AS DECIMAL(6,2)),
			Fecha_Calculo = DATEADD(MONTH,6,ISNULL(AUX.Fecha_Calculo,ISNULL(GR.Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE())))),
			Ind_Nueva = CASE WHEN AUX.Fecha_Calculo IS NULL THEN 'S' ELSE 'N' END,
			Monto_Actualizado = AUX.Monto_Actualizado
	FROM	dbo.GARANTIAS_REALES GR 
	INNER JOIN dbo.TIPOS_BIENES TB ON GR.Id_Tipo_Bien = TB.Id_Tipo_Bien 
	LEFT JOIN dbo.AUX_ACTUALIZAGARANTIAS AUX
		ON ISNULL(AUX.Id_Clase_Aeronave,-1) = ISNULL(GR.Id_Clase_Aeronave,-1)
		AND ISNULL(AUX.Id_Clase_Buque,-1) = ISNULL(GR.Id_Clase_Buque,-1)
		AND ISNULL(AUX.Id_Clase_Tipo_Bien,-1) = ISNULL(GR.Id_Clase_Tipo_Bien,-1)
		AND ISNULL(AUX.Id_Clase_Vehiculo,-1) = ISNULL(GR.Id_Clase_Vehiculo,-1)
		AND ISNULL(AUX.Id_Provincia,-1) = ISNULL(GR.Id_Provincia,-1)
		AND ISNULL(AUX.Id_Tipo_Bien,-1) = ISNULL(GR.Id_Tipo_Bien,-1)
		AND AUX.Codigo_Bien = GR.Codigo_Bien
		AND ISNULL(AUX.Id_Codigo_Duplicado,-1) = ISNULL(GR.Id_Codigo_Duplicado,-1)
		AND ISNULL(AUX.Id_Codigo_Horizontalidad,-1) = ISNULL(GR.Id_Codigo_Horizontalidad,-1)
		--AND ISNULL(AUX.Id_Tipo_Liquidez,-1) = ISNULL(GR.Id_Tipo_Liquidez,-1)
		AND ISNULL(AUX.Formato_Identificacion_Vehiculo,-1) = ISNULL(GR.Formato_Identificacion_Vehiculo,-1)
		AND ISNULL(AUX.Fecha_Ultima_Tasacion,'1900-01-01') = ISNULL(GR.Fecha_Ultima_Tasacion_Garantia,'1900-01-01')
		AND AUX.Ind_Bien = 'N'
	WHERE	TB.Cod_Tipo_Bien in (4,6,7,8,9,10,11,12,13,14)
	AND		GR.Ind_Estado_Registro = 1
	AND		GR.Estado_Registro_Garantia = 1

	--Creacion de indice
	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_MTO_ACT_NO_TERRENO ON dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	(
		Id_Garantia_Real ASC
	)

	-----------------------------------------------------------------------------
	---Calcula cantidad de dias transcurridos desde la fecha de fabricacion en semestres
	UPDATE dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		Dias_Transcurridos = ROUND((DATEDIFF(MONTH,Ajuste_Fecha_Fabricacion_Garantia,CONVERT(DATE,GETDATE()))/6.00)*180,0)
	WHERE	Ajuste_Fecha_Fabricacion_Garantia <> '1900-01-01'
	AND		(Cod_Tipo_Bien = 3 AND Id_Clase_Tipo_Bien = 7)
	OR		Cod_Tipo_Bien = 5

	--Calcula periodos a depreciar
	UPDATE	AUX
	SET		AUX.Periodos = ISNULL(RP.Periodos,0)
					--(CASE 
					--		WHEN Dias_Transcurridos BETWEEN 0 AND 179 THEN 0
					--		WHEN Dias_Transcurridos BETWEEN 180 AND 359	THEN 1
					--		WHEN Dias_Transcurridos BETWEEN 360 AND 539	THEN 2
					--		WHEN Dias_Transcurridos BETWEEN 540 AND 719	THEN 3
					--		WHEN Dias_Transcurridos BETWEEN 720 AND 899	THEN 4
					--		WHEN Dias_Transcurridos BETWEEN 900 AND 1079 THEN 5
					--		WHEN Dias_Transcurridos BETWEEN 1080 AND 1259 THEN 6
					--		WHEN Dias_Transcurridos BETWEEN 1260 AND 1439 THEN 7
					--		WHEN Dias_Transcurridos BETWEEN 1440 AND 1619 THEN 8
					--		WHEN Dias_Transcurridos BETWEEN 1620 AND 1799 THEN 9
					--		WHEN Dias_Transcurridos >= 1800 THEN 10
					--		ELSE 0
					--	END)
	FROM dbo.AUX_GAR_MTO_ACT_NO_TERRENO AUX
	INNER JOIN dbo.RANGOS_PERIODOS RP
		ON AUX.Dias_Transcurridos BETWEEN RP.Dias_Transcurridos_Inicio AND RP.Dias_Transcurridos_Final
	WHERE	Ajuste_Fecha_Fabricacion_Garantia <> '1900-01-01'
	AND		(Cod_Tipo_Bien = 3 AND Id_Clase_Tipo_Bien = 7)
	OR		Cod_Tipo_Bien = 5

	---Calcula límite de ciclo
	UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		--Ciclo = DATEDIFF(MONTH,Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE()))/6
			--Ciclo = DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))/6--DATEDIFF(MONTH,Fecha_Calculo,CONVERT(DATE,GETDATE()))/6
			Ciclo = CASE WHEN (DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))/6)>0 THEN
						CASE WHEN ((DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))%6 = 0 AND DAY(DATEADD(MONTH,-6,Fecha_Calculo)) <= DAY(CONVERT(DATE,GETDATE()))) 
							OR DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))%6 <> 0)
							THEN DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))/6
							ELSE DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))/6 -1
						END
					ELSE 0
					END

	WHERE	Cod_Tipo_Bien = 2

	UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		--Ciclo = DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Ultima_Tasacion_Garantia),CONVERT(DATE,GETDATE()))/6--DATEDIFF(MONTH,Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE()))/6
						Ciclo = CASE WHEN (DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Ultima_Tasacion_Garantia),CONVERT(DATE,GETDATE()))/6)>0 THEN
						CASE WHEN ((DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Ultima_Tasacion_Garantia),CONVERT(DATE,GETDATE()))%6 = 0 AND DAY(DATEADD(MONTH,-6,Fecha_Ultima_Tasacion_Garantia)) <= DAY(CONVERT(DATE,GETDATE()))) 
							OR DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Ultima_Tasacion_Garantia),CONVERT(DATE,GETDATE()))%6 <> 0)
							THEN DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Ultima_Tasacion_Garantia),CONVERT(DATE,GETDATE()))/6
							ELSE DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Ultima_Tasacion_Garantia),CONVERT(DATE,GETDATE()))/6 -1
						END
					ELSE 0
					END
	WHERE	Cod_Tipo_Bien in (4,6,7,8,9,10,11,12,13,14)

	---Calcula los pocentajes insumo
	UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		Pcj_Dep = (CASE	WHEN Años_Construccion_Garantia <= 10 THEN 0.9
							WHEN Años_Construccion_Garantia BETWEEN 11 AND 40 THEN 1.5
							WHEN Años_Construccion_Garantia > 40 THEN 3 
						END),
			Pcj_Dev = (	SELECT Porcentaje_Devaluacion 
						FROM dbo.TIPOS_CAMBIOS 
						WHERE Fecha = (	SELECT MAX(Fecha) 
										FROM TIPOS_CAMBIOS)),
			Pcj_Inf = (	SELECT Porcentaje_Inflacion 
						FROM dbo.INDICES_PRECIOS_CONSUMIDOR 
						WHERE Id_Indice_Precio_Consumidor = (	SELECT MAX(Id_Indice_Precio_Consumidor) 
																FROM dbo.INDICES_PRECIOS_CONSUMIDOR))

	--Calcula el porcentaje a utilizar 		
	UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		Pcje = (CASE	WHEN Pcj_Dev = NULL AND Pcj_Inf <> NULL THEN Pcj_Inf
							WHEN Pcj_Inf = NULL AND Pcj_Dev <> NULL THEN Pcj_Dev
							WHEN Pcj_Dev = NULL AND Pcj_Inf = NULL THEN 100
							WHEN ABS(Pcj_Dev) = ABS(Pcj_Inf) THEN 
								(CASE	WHEN Pcj_Dev < 0 AND Pcj_Inf >= 0 THEN Pcj_Inf
										WHEN Pcj_Inf < 0 AND Pcj_Dev >= 0 THEN Pcj_Dev 
								ELSE Pcj_Inf END)
							WHEN ABS(Pcj_Dev) > ABS(Pcj_Inf) THEN Pcj_Inf 
					ELSE Pcj_Dev END)

	---Conversion a puntos porcentuales
	UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		Pcje	= Pcje/100,
			Pcj_Dep = Pcj_Dep/100

	--Excepcion PCJ 
	UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		Pcje = 10/100.00
	WHERE	Cod_Tipo_Bien in (4,6,7,8,9,10,11,12,13,14)

	/*_________________________________________________________________________________________*/

	--										TIPO BIEN 2
	/*_________________________________________________________________________________________*/
	DECLARE	@viLimite_Ciclo INT
	SELECT	@viLimite_Ciclo = MAX(Ciclo)
	FROM	AUX_GAR_MTO_ACT_NO_TERRENO

	WHILE (@viLimite_Ciclo > 0 )
	BEGIN 	
		-------------------------------------------------------------------------------------------

		UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
		SET		Monto_Depreciacion = Monto_Depreciacion * Pcj_Dep
		WHERE	Ciclo > 0 AND
				Cod_Tipo_Bien = 2

		UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
		SET		
				--Monto_Tasacion_Actualizada_No_Terreno	= (Monto_Tasacion_Actualizada_No_Terreno - Monto_Depreciacion) 
				--										+ ((Monto_Tasacion_Actualizada_No_Terreno - Monto_Depreciacion) * Pcje),

				Monto_Ultima_Tasacion_No_Terreno = (Monto_Ultima_Tasacion_No_Terreno - Monto_Depreciacion) 
														+ ((Monto_Ultima_Tasacion_No_Terreno - Monto_Depreciacion) * Pcje),
				Monto_Actualizado = (Monto_Actualizado - Monto_Depreciacion) 
										+ ((Monto_Actualizado - Monto_Depreciacion) * Pcje),

				Ciclo = Ciclo - 1
		WHERE	Ciclo > 0 AND
				Cod_Tipo_Bien = 2

		UPDATE		dbo.AUX_GAR_MTO_ACT_NO_TERRENO
		SET			Monto_Depreciacion = CASE Ind_Nueva WHEN 'S' THEN Monto_Ultima_Tasacion_No_Terreno
														WHEN 'N' THEN  Monto_Actualizado
										END 
		WHERE 
			Ciclo > 0 
		AND Cod_Tipo_Bien = 2

		-------------------------------------------------------------------------------------------
		SELECT @viLimite_Ciclo =  @viLimite_Ciclo - 1    
	END

	/*_________________________________________________________________________________________*/

	--							TIPO BIEN 3 - Clase Codigo 8 “Bono de Prenda” 
	/*_________________________________________________________________________________________*/

	--Asignar a “Monto Tasación Actualizada No Terreno”, el mismo valor almacenado en “Monto Última Tasación No Terreno”.
	UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		Monto_Tasacion_Actualizada_No_Terreno = Monto_Ultima_Tasacion_No_Terreno
	WHERE	Cod_Tipo_Bien IN (3)
	AND		Id_Clase_Tipo_Bien = 8

	/*_________________________________________________________________________________________*/

	--							TIPO BIEN 3 - Clase Codigo 7 “Prenda Común” 
	/*_________________________________________________________________________________________*/

	UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		Monto_Tasacion_Actualizada_No_Terreno = Monto_Ultima_Tasacion_No_Terreno - ((Monto_Ultima_Tasacion_No_Terreno/10)* Periodos)
	WHERE	Ajuste_Fecha_Fabricacion_Garantia <> '1900-01-01'
	AND		Cod_Tipo_Bien IN (3)
	AND		Id_Clase_Tipo_Bien = 7 

	/*_________________________________________________________________________________________*/

	--							TIPO BIEN 4, 6, 7, 8, 9, 10, 11, 12, 13 o 14 
	/*_________________________________________________________________________________________*/

	SELECT	@viLimite_Ciclo = MAX(Ciclo)
	FROM	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	WHERE	Cod_Tipo_Bien in (4,6,7,8,9,10,11,12,13,14)

	WHILE (@viLimite_Ciclo > 0 )
	BEGIN 	
		-------------------------------------------------------------------------------------------

		UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
		SET		--Monto_Tasacion_Actualizada_No_Terreno = Monto_Ultima_Tasacion_No_Terreno - (Monto_Ultima_Tasacion_No_Terreno * Pcje),
				Monto_Tasacion_Actualizada_No_Terreno = Monto_Tasacion_Actualizada_No_Terreno - (Monto_Tasacion_Actualizada_No_Terreno * Pcje),
				Ciclo = Ciclo - 1
		WHERE	Ciclo > 0 AND
				Cod_Tipo_Bien in (4,6,7,8,9,10,11,12,13,14)

		-------------------------------------------------------------------------------------------
		SELECT @viLimite_Ciclo =  @viLimite_Ciclo - 1    
	END

	/*_________________________________________________________________________________________*/

	--										TIPO BIEN 5 
	/*_________________________________________________________________________________________*/

	UPDATE	dbo.AUX_GAR_MTO_ACT_NO_TERRENO
	SET		Monto_Tasacion_Actualizada_No_Terreno = Monto_Ultima_Tasacion_No_Terreno - ((Monto_Ultima_Tasacion_No_Terreno/8)* Periodos)
	WHERE	Ajuste_Fecha_Fabricacion_Garantia <> '1900-01-01'
	AND		Cod_Tipo_Bien IN (5)


	/*_________________________________________________________________________________________*/

	UPDATE AUX_GAR_MTO_ACT_NO_TERRENO
		SET
			Monto_Actualizado = 0
	WHERE (Monto_Actualizado < 0) 

	UPDATE AUX_GAR_MTO_ACT_NO_TERRENO
		SET
			Monto_Ultima_Tasacion_No_Terreno = 0
	WHERE (Monto_Ultima_Tasacion_No_Terreno < 0) 

	UPDATE AUX_GAR_MTO_ACT_NO_TERRENO
		SET
			Monto_Tasacion_Actualizada_No_Terreno = 0
	WHERE (Monto_Tasacion_Actualizada_No_Terreno < 0)
		
	UPDATE		GR
	SET			GR.Monto_Tasacion_Actualizada_No_Terreno = ACT.Monto_Tasacion_Actualizada_No_Terreno
	FROM		dbo.GARANTIAS_REALES GR
	INNER JOIN	dbo.AUX_GAR_MTO_ACT_NO_TERRENO ACT ON
				GR.Id_Garantia_Real = ACT.Id_Garantia_Real
	WHERE Cod_Tipo_Bien <> 2

	UPDATE		GR
	SET			GR.Monto_Tasacion_Actualizada_No_Terreno = CASE Ind_Nueva WHEN 'S' THEN ACT.Monto_Ultima_Tasacion_No_Terreno
																		  WHEN 'N' THEN  ACT.Monto_Actualizado
															END 
	FROM		dbo.GARANTIAS_REALES GR
	INNER JOIN	dbo.AUX_GAR_MTO_ACT_NO_TERRENO ACT ON
				GR.Id_Garantia_Real = ACT.Id_Garantia_Real
	WHERE Cod_Tipo_Bien = 2

	--Limpiar Tabla AUX_ACTUALIZAGARANTIAS

	DELETE FROM AUX FROM dbo.AUX_ACTUALIZAGARANTIAS AUX
		INNER JOIN dbo.GARANTIAS_REALES GR
		ON ISNULL(AUX.Id_Clase_Aeronave,-1) = ISNULL(GR.Id_Clase_Aeronave,-1)
		AND ISNULL(AUX.Id_Clase_Buque,-1) = ISNULL(GR.Id_Clase_Buque,-1)
		AND ISNULL(AUX.Id_Clase_Tipo_Bien,-1) = ISNULL(GR.Id_Clase_Tipo_Bien,-1)
		AND ISNULL(AUX.Id_Clase_Vehiculo,-1) = ISNULL(GR.Id_Clase_Vehiculo,-1)
		AND ISNULL(AUX.Id_Provincia,-1) = ISNULL(GR.Id_Provincia,-1)
		AND ISNULL(AUX.Id_Tipo_Bien,-1) = ISNULL(GR.Id_Tipo_Bien,-1)
		AND AUX.Codigo_Bien = GR.Codigo_Bien
		AND ISNULL(AUX.Id_Codigo_Duplicado,-1) = ISNULL(GR.Id_Codigo_Duplicado,-1)
		AND ISNULL(AUX.Id_Codigo_Horizontalidad,-1) = ISNULL(GR.Id_Codigo_Horizontalidad,-1)
		--AND ISNULL(AUX.Id_Tipo_Liquidez,-1) = ISNULL(GR.Id_Tipo_Liquidez,-1)
		AND ISNULL(AUX.Formato_Identificacion_Vehiculo,-1) = ISNULL(GR.Formato_Identificacion_Vehiculo,-1)
		AND ISNULL(AUX.Fecha_Ultima_Tasacion,'1900-01-01') = ISNULL(GR.Fecha_Ultima_Tasacion_Garantia,'1900-01-01')
		AND AUX.Ind_Bien = 'N'

	INSERT INTO dbo.AUX_ACTUALIZAGARANTIAS
	(
		--Campos LLave
		Id_Clase_Aeronave,
		Id_Clase_Buque,
		Id_Clase_Tipo_Bien,
		Id_Clase_Vehiculo,
		Id_Provincia,
		Id_Tipo_Bien,
		Codigo_Bien, 
		Id_Codigo_Duplicado, 
		Id_Codigo_Horizontalidad,
		--Id_Tipo_Liquidez,
		Formato_Identificacion_Vehiculo,
		--Fin Campos Llave
		Fecha_Ultima_Tasacion,
		Fecha_Calculo,
		Monto_Actualizado,
		Ind_Bien
	)
	SELECT 
		GR.Id_Clase_Aeronave,
		GR.Id_Clase_Buque,
		GR.Id_Clase_Tipo_Bien,
		GR.Id_Clase_Vehiculo,
		GR.Id_Provincia,
		GR.Id_Tipo_Bien,
		GR.Codigo_Bien, 
		GR.Id_Codigo_Duplicado, 
		GR.Id_Codigo_Horizontalidad,
		--GR.Id_Tipo_Liquidez,
		GR.Formato_Identificacion_Vehiculo,		
		GR.Fecha_Ultima_Tasacion_Garantia,
		Fecha_Calculo = CONVERT(DATE,GETDATE()),
		Monto_Actualizado = CASE Ind_Nueva WHEN 'S' THEN AUX.Monto_Ultima_Tasacion_No_Terreno
											WHEN 'N' THEN  AUX.Monto_Actualizado
							END,
		Ind_Bien = 'N'
	FROM GARANTIAS_REALES GR
	INNER JOIN AUX_GAR_MTO_ACT_NO_TERRENO AUX
		ON AUX.Id_Garantia_Real = GR.Id_Garantia_Real


		SELECT 0 AS Error, '' AS Mensaje
		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END

