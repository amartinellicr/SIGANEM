
CREATE PROCEDURE [dbo].[Calculo_Monto_Tasacion_Actualizada_Terreno]
AS 
/******************************************************************************************************************************************************
<Nombre>Calculo_Monto_Tasacion_Actualizada_Terreno</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>
	Procedimiento almacenado que realiza el cálculo automático monto tasación actualizada terreno
	Esta formulación aplica únicamente para bienes tipo 1 y 2
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
BEGIN
	BEGIN TRANSACTION TRA_Insertar
	BEGIN TRY

	IF OBJECT_ID('[dbo].[AUX_GAR_MTO_ACT_TERRENO]') is not null
		DROP TABLE [dbo].[AUX_GAR_MTO_ACT_TERRENO]


	CREATE TABLE [dbo].[AUX_GAR_MTO_ACT_TERRENO](
		[Id_Garantia_Real] [int] NOT NULL,
		[Fecha_Ultima_Tasacion_Garantia] [datetime] NULL,
		[Monto_Ultima_Tasacion_Terreno] [decimal](22, 2) NOT NULL,
		[Monto_Tasacion_Actualizada_Terreno] [decimal](22, 2) NULL,
		[Ciclo] [int] NOT NULL,
		[Pcj_Dev] [decimal](6, 5) NULL,
		[Pcj_Inf] [decimal](6, 5) NULL,
		[Pcje] [decimal](6, 5) NULL,
		[Fecha_Calculo] [datetime] NULL,
		[Ind_Nueva] [varchar](3) NULL,
		[Monto_Actualizado] [decimal](22, 2) NULL
	) ON [PRIMARY]
	

	INSERT INTO dbo.[AUX_GAR_MTO_ACT_TERRENO]
			   (Id_Garantia_Real
			   ,Fecha_Ultima_Tasacion_Garantia
			   ,Monto_Ultima_Tasacion_Terreno
			   ,Monto_Tasacion_Actualizada_Terreno
			   ,Ciclo
			   ,Pcj_Dev
			   ,Pcj_Inf
			   ,Pcje
			   ,Fecha_Calculo
			   ,Ind_Nueva
			   ,Monto_Actualizado)
	SELECT DISTINCT
			Id_Garantia_Real,
			Fecha_Ultima_Tasacion_Garantia =	(CASE WHEN Fecha_Ultima_Tasacion_Garantia IS NOT NULL THEN dateadd(month,6,(Fecha_Ultima_Tasacion_Garantia))
												ELSE ISNULL(Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE())) END),
			Monto_Ultima_Tasacion_Terreno =	ISNULL(Monto_Ultima_Tasacion_Terreno,0),
			--Monto_Tasacion_Actualizada_Terreno = CAST(	(CASE	WHEN Monto_Ultima_Tasacion_Terreno IS NULL THEN 0
			--													WHEN Fecha_Ultima_Tasacion_Garantia IS NULL THEN ISNULL(Monto_Ultima_Tasacion_Terreno,0)
			--													ELSE ISNULL(Monto_Ultima_Tasacion_Terreno,0)
			--											END) AS DECIMAL(22,2)),
			Monto_Tasacion_Actualizada_Terreno = CAST(	(CASE	WHEN Monto_Tasacion_Actualizada_Terreno IS NULL THEN ISNULL(Monto_Ultima_Tasacion_Terreno,0)
																WHEN Fecha_Ultima_Tasacion_Garantia IS NULL THEN ISNULL(Monto_Ultima_Tasacion_Terreno,0)
																ELSE Monto_Tasacion_Actualizada_Terreno
														END) AS DECIMAL(22,2)),
			Ciclo	= 0,
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
		AND AUX.Ind_Bien = 'T'
	WHERE	TB.Cod_Tipo_Bien IN (1,2)
	AND		GR.Ind_Estado_Registro = 1
	AND		GR.Estado_Registro_Garantia = 1

	CREATE NONCLUSTERED INDEX IDX_AUX_GAR_MTO_ACT_TERRENO ON dbo.AUX_GAR_MTO_ACT_TERRENO
	(
		Id_Garantia_Real ASC
	)

	UPDATE	dbo.AUX_GAR_MTO_ACT_TERRENO
	SET		--Ciclo = DATEDIFF(MONTH,Fecha_Ultima_Tasacion_Garantia,CONVERT(DATE,GETDATE()))/6
			--Ciclo = DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))/6
			Ciclo = CASE WHEN (DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))/6)>0 THEN
						CASE WHEN ((DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))%6 = 0 AND DAY(DATEADD(MONTH,-6,Fecha_Calculo)) <= DAY(CONVERT(DATE,GETDATE()))) 
							OR DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))%6 <> 0)
							THEN DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))/6
							ELSE DATEDIFF(MONTH,DATEADD(MONTH,-6,Fecha_Calculo),CONVERT(DATE,GETDATE()))/6 -1
						END
					ELSE 0
					END
			
	UPDATE	dbo.AUX_GAR_MTO_ACT_TERRENO
	SET		Pcj_Dev = (	SELECT Porcentaje_Devaluacion 
						FROM dbo.TIPOS_CAMBIOS 
						WHERE Fecha = (	SELECT MAX(Fecha) 
										FROM TIPOS_CAMBIOS)),
			Pcj_Inf = (	SELECT Porcentaje_Inflacion 
						FROM dbo.INDICES_PRECIOS_CONSUMIDOR 
						WHERE Id_Indice_Precio_Consumidor = (	SELECT MAX(Id_Indice_Precio_Consumidor) 
																FROM dbo.INDICES_PRECIOS_CONSUMIDOR))
		
	UPDATE	dbo.AUX_GAR_MTO_ACT_TERRENO
	SET		Pcje = (CASE	WHEN Pcj_Dev IS NULL AND Pcj_Inf IS NOT NULL THEN Pcj_Inf
							WHEN Pcj_Inf IS NULL AND Pcj_Dev IS NOT NULL THEN Pcj_Dev
							WHEN Pcj_Dev IS NULL AND Pcj_Inf IS NULL THEN 100
							WHEN ABS(Pcj_Dev) = ABS(Pcj_Inf) THEN 
								(CASE	WHEN Pcj_Dev < 0 AND Pcj_Inf >= 0 THEN Pcj_Inf
										WHEN Pcj_Inf < 0 AND Pcj_Dev >= 0 THEN Pcj_Dev 
								ELSE Pcj_Inf END)
							WHEN ABS(Pcj_Dev) > ABS(Pcj_Inf) THEN Pcj_Inf 
					ELSE Pcj_Dev END)

	UPDATE	dbo.AUX_GAR_MTO_ACT_TERRENO
	SET		Pcje = Pcje/100

	DECLARE	@viLimite_Ciclo INT 
	SELECT	@viLimite_Ciclo = MAX(Ciclo)
	FROM	dbo.AUX_GAR_MTO_ACT_TERRENO

	WHILE (@viLimite_Ciclo > 0 )
	BEGIN 	
	-------------------------------------------------------------------------------------------
		--UPDATE	dbo.AUX_GAR_MTO_ACT_TERRENO
		--SET		Monto_Tasacion_Actualizada_Terreno = Monto_Tasacion_Actualizada_Terreno + (Monto_Tasacion_Actualizada_Terreno * Pcje),
		--		Ciclo = Ciclo - 1
		--WHERE	Ciclo > 0

		UPDATE	dbo.AUX_GAR_MTO_ACT_TERRENO
		SET		Monto_Ultima_Tasacion_Terreno = Monto_Ultima_Tasacion_Terreno + (Monto_Ultima_Tasacion_Terreno * Pcje),
				Monto_Actualizado = Monto_Actualizado + (Monto_Actualizado * Pcje),
				Ciclo = Ciclo - 1
		WHERE	Ciclo > 0

	-------------------------------------------------------------------------------------------
		SELECT @viLimite_Ciclo =  @viLimite_Ciclo - 1    
	END

	UPDATE AUX_GAR_MTO_ACT_TERRENO
		SET
			Monto_Ultima_Tasacion_Terreno = 0
	WHERE (Monto_Ultima_Tasacion_Terreno < 0) 

	UPDATE AUX_GAR_MTO_ACT_TERRENO
		SET
			Monto_Actualizado = 0
	WHERE (Monto_Actualizado < 0)
		
	UPDATE		GR
	SET			GR.Monto_Tasacion_Actualizada_Terreno = CASE Ind_Nueva WHEN 'S' THEN ACT.Monto_Ultima_Tasacion_Terreno
																	   WHEN 'N' THEN  ACT.Monto_Actualizado
														END 
	FROM		dbo.GARANTIAS_REALES GR
	INNER JOIN	AUX_GAR_MTO_ACT_TERRENO ACT ON
				GR.Id_Garantia_Real = ACT.Id_Garantia_Real

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
		AND AUX.Ind_Bien = 'T'

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
		Monto_Actualizado = CASE Ind_Nueva WHEN 'S' THEN AUX.Monto_Ultima_Tasacion_Terreno
											WHEN 'N' THEN  AUX.Monto_Actualizado
							END,
		Ind_Bien = 'T'
	FROM GARANTIAS_REALES GR
	INNER JOIN AUX_GAR_MTO_ACT_TERRENO AUX
		ON AUX.Id_Garantia_Real = GR.Id_Garantia_Real

		SELECT 0 AS Error, '' AS Mensaje

		COMMIT TRANSACTION TRA_Insertar
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS Error, ERROR_MESSAGE() AS Mensaje
		ROLLBACK TRANSACTION TRA_Insertar
	END CATCH

END


