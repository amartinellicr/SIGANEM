USE [USSIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Garantias_Fideicometidas_Elimina', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Garantias_Fideicometidas_Elimina;
GO


CREATE PROCEDURE [dbo].[Garantias_Fideicometidas_Elimina]
( 
    @piId_Garantia_Fideicomiso_Act	INT,
	@psCod_Usuario					VARCHAR(20)
)
AS 
/******************************************************************************************************************************************************
<Nombre>Garantias_Fideicometidas_Elimina</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que elimina la información en la tabla GARANTIAS_FIDEICOMETIDAS</Descripción>
<Entradas>
		@piId_Garantia_Fideicomiso_Act = Llave de control interno.
		@psCod_Usuario = Código de usuario.
</Entradas>
<Salidas></Salidas>
<Autor>Arnoldo Martinelli M.</Autor>
<Fecha>Marzo del 2016</Fecha>
<Requerimiento>N.A.</Requerimiento>
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
	--Inicia la transacción
	BEGIN TRANSACTION TRA_Eliminar

	--Inicia control de errores
	BEGIN TRY


	DECLARE		@viId_Fideicomiso							INT,
				@viId_Tipo_Garantia							INT,
				@viId_Garantia_Real							INT = NULL,
				@viId_Garantia_Valor						INT = NULL,
				@vsId_Dueno									VARCHAR(17),
				@vsNombre_Dueno								VARCHAR(75),
				@viId_Tipo_Moneda_Valor_Nominal				INT,
				@vdValor_Nominal							NUMERIC(24, 2),
				@vdMonto_Mitigador							NUMERIC(24, 2),
				@vdPorcentaje_Aceptacion_No_Terreno_SUGEF	DECIMAL(5, 2) = NULL,
				@vdPorcentaje_Aceptacion_Terreno_SUGEF		DECIMAL(5, 2) = NULL,
				@vdPorcentaje_Aceptacion_SUGEF				NUMERIC(5, 2) = NULL,
				@vdPorcentaje_Aceptacion_BCR				NUMERIC(5, 2) = NULL,
				@viId_Tipo_Mitigador_Riesgo					INT,
				@viId_Tipo_Documento_Legal					INT,
				@viId_Tipo_Indicador_Inscripcion			INT,
				@vdtFecha_Presentacion						DATETIME,
				@viId_Formato_Identificacion_Vehiculo		INT = NULL,
				@vbInd_Deudor_Habita						BIT = NULL,	
				@vbEstado_Registro							BIT = NULL,
				@vsInd_Metodo_Insercion						VARCHAR(30) = NULL,
				@vdtFecha_Ingreso							DATETIME = NULL,
				@vsCod_Usuario_Ingreso						VARCHAR(20) = NULL,
				@vdtFecha_Ultima_Modificacion				DATETIME = NULL,
				@vsCod_Usuario_Ultima_Modificacion			VARCHAR(20) = NULL,
				@vsInd_Accion_Registro						VARCHAR(3)


		--Si la Garantia a Eliminar no se encuentra activa en Garantias Operaciones
		IF NOT EXISTS (	SELECT	Id_Fideicomiso 
						FROM	GARANTIAS_OPERACIONES 
						WHERE	Id_Garantia_Aval = @piId_Garantia_Fideicomiso_Act
								AND Ind_Estado_Registro = 1
						)
		BEGIN


			SELECT	@viId_Fideicomiso = Id_Fideicomiso,
					@viId_Tipo_Garantia	= Id_Tipo_Garantia,
					@viId_Garantia_Real = Id_Garantia_Real,
					@viId_Garantia_Valor = Id_Garantia_Valor,
					@vsId_Dueno	= Id_Dueno,
					@vsNombre_Dueno	= Nombre_Dueno,
					@viId_Tipo_Moneda_Valor_Nominal	= Id_Tipo_Moneda_Valor_Nominal,
					@vdValor_Nominal = Valor_Nominal,
					@vdMonto_Mitigador = Monto_Mitigador,
					@vdPorcentaje_Aceptacion_No_Terreno_SUGEF = Porcentaje_Aceptacion_No_Terreno_SUGEF,
					@vdPorcentaje_Aceptacion_Terreno_SUGEF = Porcentaje_Aceptacion_Terreno_SUGEF,
					@vdPorcentaje_Aceptacion_SUGEF = Porcentaje_Aceptacion_SUGEF,
					@vdPorcentaje_Aceptacion_BCR = Porcentaje_Aceptacion_BCR,
					@viId_Tipo_Mitigador_Riesgo	= Id_Tipo_Mitigador_Riesgo,
					@viId_Tipo_Documento_Legal = Id_Tipo_Documento_Legal,
					@viId_Tipo_Indicador_Inscripcion = Id_Tipo_Indicador_Inscripcion,
					@vdtFecha_Presentacion = Fecha_Presentacion,
					@viId_Formato_Identificacion_Vehiculo = Id_Formato_Identificacion_Vehiculo,
					@vbInd_Deudor_Habita = Ind_Deudor_Habita,	
					@vbEstado_Registro = Ind_Estado_Registro,
					@vsInd_Metodo_Insercion	= Ind_Metodo_Insercion,
					@vdtFecha_Ingreso = Fecha_Ingreso,
					@vsCod_Usuario_Ingreso = Cod_Usuario_Ingreso,
					@vdtFecha_Ultima_Modificacion = GETDATE(),
					@vsCod_Usuario_Ultima_Modificacion = Cod_Usuario_Ultima_Modificacion,
					@vsInd_Accion_Registro = Ind_Accion_Registro
			FROM	dbo.GARANTIAS_FIDEICOMETIDAS
			WHERE	Id_Garantia_Fideicomiso = @piId_Garantia_Fideicomiso_Act 


			--Actualiza el registro actual con Ind_Estado_Registro = 0
			UPDATE	dbo.GARANTIAS_FIDEICOMETIDAS 
			SET		Ind_Estado_Registro		=	0
			WHERE	Id_Garantia_Fideicomiso = @piId_Garantia_Fideicomiso_Act 
				AND Ind_Estado_Registro = 1

			--Actualiza la fecha de última modificación y el usuario

			UPDATE	dbo.FIDEICOMISOS
			SET		Fecha_Ultima_Modificacion =  GETDATE(),
					Cod_Usuario_Ultima_Modificacion = @psCod_Usuario
			WHERE	Id_Fideicomiso = @viId_Fideicomiso
				AND Ind_Estado_Registro = 1

			UPDATE	dbo.ARCHIVOS_FIDEICOMISOS
			SET		Fecha_Ultima_Modificacion =  GETDATE(),
					Cod_Usuario_Ultima_Modificacion = @psCod_Usuario
			WHERE	Id_Fideicomiso = @viId_Fideicomiso
				AND Ind_Estado_Registro = 1

			UPDATE	dbo.PRIORIDADES_FIDEICOMISOS
			SET		Fecha_Ultima_Modificacion =  GETDATE(),
					Cod_Usuario_Ultima_Modificacion = @psCod_Usuario
			WHERE	Id_Fideicomiso = @viId_Fideicomiso
				AND Ind_Estado_Registro = 1

			SELECT	1 AS Estado, 
					0 AS NumeroError

			--Inserta el nuevo registro
			DECLARE @vdFecha_Ultima_Modificacion DATETIME = GETDATE(),
					@piId_Garantia_Fideicomiso INT

			EXEC dbo.Garantias_Fideicometidas_Inserta_Total
					@viId_Fideicomiso,
					@viId_Tipo_Garantia,
					@viId_Garantia_Real,
					@viId_Garantia_Valor,
					@vsId_Dueno,
					@vsNombre_Dueno,
					@viId_Tipo_Moneda_Valor_Nominal,
					@vdValor_Nominal,
					@vdMonto_Mitigador,
					@vdPorcentaje_Aceptacion_No_Terreno_SUGEF,
					@vdPorcentaje_Aceptacion_Terreno_SUGEF,
					@vdPorcentaje_Aceptacion_SUGEF,
					@vdPorcentaje_Aceptacion_BCR,
					@viId_Tipo_Mitigador_Riesgo,
					@viId_Tipo_Documento_Legal,
					@viId_Tipo_Indicador_Inscripcion,
					@vdtFecha_Presentacion,
					@viId_Formato_Identificacion_Vehiculo,
					@vbInd_Deudor_Habita,
					@vbEstado_Registro,
					@vsInd_Metodo_Insercion,
					@vdtFecha_Ingreso,
					@vsCod_Usuario_Ingreso,
					@vdtFecha_Ultima_Modificacion,
					@psCod_Usuario,
					'E',
					@piId_Garantia_Fideicomiso = @piId_Garantia_Fideicomiso OUTPUT


			--Si no hubo error, se aplica la transacción
			COMMIT TRANSACTION TRA_Eliminar

			SELECT	1 AS Estado, 
					0 AS NumeroError

		END
		ELSE
		BEGIN
			--Si no hubo error, se aplica la transacción
			COMMIT TRANSACTION TRA_Eliminar

			SELECT	0 AS Estado, 
					547 AS NumeroError
		END

	END TRY

	--En caso de error, realiza lo siguiente
	BEGIN CATCH

		SELECT	0 AS Estado, 
				ERROR_NUMBER() AS NumeroError
		ROLLBACK TRANSACTION TRA_Eliminar

	END CATCH

END 



