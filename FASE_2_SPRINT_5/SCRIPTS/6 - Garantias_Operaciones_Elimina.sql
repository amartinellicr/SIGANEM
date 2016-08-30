USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Garantias_Operaciones_Elimina', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Garantias_Operaciones_Elimina;
GO

CREATE PROCEDURE [dbo].[Garantias_Operaciones_Elimina]
( 
    @piId_Garantia_Operacion	INT,
	@psCod_Usuario				VARCHAR(20)
)
AS 
/******************************************************************************************************************************************************
<Nombre>Garantias_Operaciones_Elimina</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que elimina la información en la tabla GARANTIAS_OPERACIONES</Descripción>
<Entradas>@piId_Garantia_Operacion = Llave de control interno</Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado C.</Autor>
<Fecha>Febrero del 2014</Fecha>
<Requerimiento>1-????????</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli Marín</Autor>
		<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
		<Fecha>21/06/2016</Fecha>
		<Descripción>Se agrega la manipulación de los campos en la consulta de salida "Id_Fideicomiso", "Id_Garantia_Aval" e "Id_Tipo_Indicador_Inscripcion"</Descripción>
	</Cambio>
	<Cambio>
		<Autor>Arnoldo Martinelli M.</Autor>
		<Requerimiento>RQ_MANT_2016050410580724: BACKLOG 3943</Requerimiento>
		<Fecha>Agosto 2016</Fecha>
		<Descripción>Se agregan los campos que permitien manipular el valor del monto del grado gravamen</Descripción>
	</Cambio>
	<Cambio>
		<Autor></Autor>
		<Requerimiento></Requerimiento>
		<Fecha></Fecha>
		<Descripción></Descripción>
	</Cambio>
</Historial>
******************************************************************************************************************************************************/
BEGIN 
	--Inicia la transacción
	BEGIN TRANSACTION TRA_Eliminar

	--Inicia control de errores
	BEGIN TRY


	DECLARE		@viId_Operacion						INT,
				@viId_Tipo_Garantia					INT,
				@viId_Garantia_Fiduciaria			INT = NULL,
				@viId_Garantia_Valor				INT = NULL,
				@viId_Garantia_Real					INT = NULL,
				@viId_Tipo_Moneda_Monto_Gravamen	INT = NULL,
				@vnMonto_Grado_Gravamen				NUMERIC(22,2) = NULL,
				@viId_Grado_Gravamen				INT = NULL,
				@vdFecha_Constitucion_Garantia		DATETIME = NULL,
				@viId_Clase_Garantia_PRT17			INT = NULL,
				@viId_Tenencia_PRT_15				INT = NULL,
				@viId_Tenencia_PRT_17				INT = NULL,
				@vbInd_Deudor_Habita				BIT = NULL,
				@vbInd_Recomendacion_Perito			BIT = NULL,
				@vbInd_Inspeccion_Garantia			BIT = NULL,
				@viId_Tipo_Mitigador_Riesgo			INT = NULL,
				@viId_Tipo_Documento_Legal			INT = NULL,
				@vnMonto_Mitigador					NUMERIC(24,2) = NULL,
				@vnPorcentaje_Aceptacion_BCR		NUMERIC(5,2) = NULL,				
				@vnPorcentaje_Responsabilidad_SUGEF NUMERIC(5,2) = NULL,
				--@vbInd_Poliza						BIT = NULL,
				@viId_Partido						INT,
				@vsCod_Usuario_Ingreso				VARCHAR(20),
				@vdFecha_Ingreso					DATETIME = NULL,	
				@vdFecha_Ultima_Modificacion		DATETIME = NULL,
				@vsCod_Usuario_Ultima_Modificacion	VARCHAR(20) = NULL,
				@vsInd_Metodo_Insercion				VARCHAR(30),
				@vdFecha_Prescripcion_Garantia		DATETIME = NULL,
				@viInd_Estado_Replicado				INT = NULL,
				@vnPorcentaje_Aceptacion_No_Terreno_SUGEF	NUMERIC(5,2) = NULL,
				@vnPorcentaje_Aceptacion_Terreno_SUGEF	NUMERIC(5,2) = NULL,
				@vnMonto_Mitigador_Calculado			NUMERIC(22,2) = NULL,
				@vnPorcentaje_Responsabilidad_Legal		NUMERIC(5,2) = NULL,
				@viId_Fideicomiso					INT,
			    @viId_Garantia_Aval					INT,
			    @viId_Tipo_Indicador_Inscripcion	INT,
				@vnMonto_Grado_Gravamen_Original	NUMERIC(22,2) = NULL,
				@vnMonto_Grado_Gravamen_Modificado	NUMERIC(22,2) = NULL,
				@vbInd_Monto_Grado_Gravamen_Modificado	BIT = NULL

		SELECT 
			@viId_Operacion = Id_Operacion
			,@viId_Tipo_Garantia = Id_Tipo_Garantia
			,@viId_Garantia_Fiduciaria = Id_Garantia_Fiduciaria
			,@viId_Garantia_Valor = Id_Garantia_Valor
			,@viId_Garantia_Real = Id_Garantia_Real
			,@viId_Tipo_Moneda_Monto_Gravamen = Id_Tipo_Moneda_Monto_Gravamen
			,@vnMonto_Grado_Gravamen = Monto_Grado_Gravamen
			,@viId_Grado_Gravamen = Id_Grado_Gravamen
			,@vdFecha_Constitucion_Garantia = Fecha_Constitucion_Garantia
			,@viId_Clase_Garantia_PRT17 = Id_Clase_Garantia_PRT17
			,@viId_Tenencia_PRT_15 = Id_Tenencia_PRT_15
			,@viId_Tenencia_PRT_17 = Id_Tenencia_PRT_17
			,@vbInd_Deudor_Habita = Ind_Deudor_Habita
			,@vbInd_Recomendacion_Perito = Ind_Recomendacion_Perito
			,@vbInd_Inspeccion_Garantia = Ind_Inspeccion_Garantia
			,@viId_Tipo_Mitigador_Riesgo = Id_Tipo_Mitigador_Riesgo
			,@viId_Tipo_Documento_Legal = Id_Tipo_Documento_Legal
			,@vnMonto_Mitigador = Monto_Mitigador
			,@vnMonto_Mitigador_Calculado = Monto_Mitigador_Calculado
			,@vnPorcentaje_Aceptacion_BCR = Porcentaje_Aceptacion_BCR
			,@vnPorcentaje_Aceptacion_No_Terreno_SUGEF = Porcentaje_Aceptacion_No_Terreno_SUGEF
			,@vnPorcentaje_Aceptacion_Terreno_SUGEF = Porcentaje_Aceptacion_Terreno_SUGEF
			,@vnPorcentaje_Responsabilidad_SUGEF = Porcentaje_Responsabilidad_SUGEF
			,@vnPorcentaje_Responsabilidad_Legal = Porcentaje_Responsabilidad_Legal
			--,@vbInd_Poliza = Ind_Poliza
			,@viId_Partido = Partido
			,@vsInd_Metodo_Insercion = Ind_Metodo_Insercion
			,@vdFecha_Ingreso = Fecha_Ingreso
			,@vsCod_Usuario_Ingreso = Cod_Usuario_Ingreso
			,@vdFecha_Ultima_Modificacion = GETDATE()
			,@vdFecha_Prescripcion_Garantia = Fecha_Prescripcion_Garantia
			,@viInd_Estado_Replicado = Ind_Estado_Replicado
			,@viId_Fideicomiso = Id_Fideicomiso
			,@viId_Garantia_Aval = Id_Garantia_Aval
			,@viId_Tipo_Indicador_Inscripcion = Id_Tipo_Indicador_Inscripcion
			,@vnMonto_Grado_Gravamen_Original = Monto_Grado_Gravamen_Original
			,@vnMonto_Grado_Gravamen_Modificado	= Monto_Grado_Gravamen_Modificado
			,@vbInd_Monto_Grado_Gravamen_Modificado	= Ind_Monto_Grado_Gravamen_Modificado
		FROM 
			dbo.GARANTIAS_OPERACIONES
		WHERE
			Id_Garantia_Operacion = @piId_Garantia_Operacion 


		--Actualiza el registro actual con Ind_Estado_Registro = 0
		UPDATE	dbo.GARANTIAS_OPERACIONES 
			SET 
				Ind_Estado_Registro				=	0
		WHERE	Id_Garantia_Operacion			=	@piId_Garantia_Operacion

		
		--Actualiza Inscripciones
		UPDATE	dbo.GARANTIAS_REALES_INSCRIPCIONES 
			SET 
				Ind_Estado_Registro				=	0
		WHERE	Id_Garantia_Operacion			=	@piId_Garantia_Operacion

		--Actualiza Mobiliarias
		UPDATE	dbo.GARANTIAS_REALES_MOBILIARIAS 
			SET 
				Ind_Estado_Registro				=	0
		WHERE	Id_Garantia_Operacion			=	@piId_Garantia_Operacion

		--Actualiza la fecha de ultima modificacion y el usuario

		UPDATE dbo.OPERACIONES
			SET 
				Fecha_Ultima_Modificacion =  GETDATE(),
				Cod_Usuario_Ultima_Modificacion = @psCod_Usuario
		WHERE Id_Operacion = @viId_Operacion

		SELECT	1 AS Estado, 
				0 AS NumeroError

		--Inserta el nuevo registro
		EXEC dbo.Garantias_Operaciones_Inserta 
			@viId_Operacion
			,@viId_Tipo_Garantia
			,@viId_Garantia_Fiduciaria
			,@viId_Garantia_Valor
			,@viId_Garantia_Real 
			,@viId_Tipo_Moneda_Monto_Gravamen 
			,@vnMonto_Grado_Gravamen 
			,@viId_Grado_Gravamen 
			,@vdFecha_Constitucion_Garantia
			,@viId_Clase_Garantia_PRT17 
			,@viId_Tenencia_PRT_15 
			,@viId_Tenencia_PRT_17
			,@vbInd_Deudor_Habita 
			,@vbInd_Recomendacion_Perito 
			,@vbInd_Inspeccion_Garantia 
			,@viId_Tipo_Mitigador_Riesgo
			,@viId_Tipo_Documento_Legal 
			,@vnMonto_Mitigador 
			,@vnPorcentaje_Aceptacion_BCR 			 
			,@vnPorcentaje_Responsabilidad_SUGEF 
			--,@vbInd_Poliza
			,@viId_Partido
			,@vsCod_Usuario_Ingreso 
			,@vdFecha_Ingreso 
			,@vdFecha_Ultima_Modificacion 
			,@psCod_Usuario
			,'E' 
			,@vsInd_Metodo_Insercion
			,@viInd_Estado_Replicado
			,@vdFecha_Prescripcion_Garantia
			,@vnPorcentaje_Aceptacion_No_Terreno_SUGEF
			,@vnPorcentaje_Aceptacion_Terreno_SUGEF
			,@vnMonto_Mitigador_Calculado 
			,@vnPorcentaje_Responsabilidad_Legal
			,@viId_Fideicomiso
			,@viId_Garantia_Aval
			,@viId_Tipo_Indicador_Inscripcion
			,@vnMonto_Grado_Gravamen_Original
			,@vnMonto_Grado_Gravamen_Modificado
			,@vbInd_Monto_Grado_Gravamen_Modificado

		--Si no hubo error, se aplica la transacción
		COMMIT TRANSACTION TRA_Eliminar

		SELECT	1 AS Estado, 
				0 AS NumeroError

	END TRY

	--En caso de error, realiza lo siguiente
	BEGIN CATCH

		SELECT	0 AS Estado, 
				ERROR_NUMBER() AS NumeroError
		ROLLBACK TRANSACTION TRA_Eliminar

	END CATCH

END
GO


