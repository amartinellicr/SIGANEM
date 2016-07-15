USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Garantias_Avales_Elimina', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Garantias_Avales_Elimina;
GO


CREATE PROCEDURE [dbo].[Garantias_Avales_Elimina]
( 
    @piId_Garantia_Aval	INT,
	@psCod_Usuario		VARCHAR(20)
)
AS 
/******************************************************************************************************************************************************
<Nombre>Garantias_Avales_Elimina</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que elimina la información en la tabla GARANTIAS_AVALES</Descripción>
<Entradas>
		@piId_Garantia_Aval = Llave de control interno</Entradas>
<Salidas></Salidas>
<Autor>Alexander Cruz</Autor>
<Fecha>Enero 2016</Fecha>
<Requerimiento></Requerimiento>
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

		DECLARE @viNumero_Error INT
		DECLARE @viEstado INT
		DECLARE @viBandera INT = 0
		SET @viBandera = (	SELECT	COUNT(GRI.Id_Garantia_Aval)
							FROM	dbo.GARANTIAS_AVALES GRI  
							WHERE	GRI.Id_Garantia_Aval = @piId_Garantia_Aval 		
									AND GRI.Ind_Estado_Registro =  0 )

		--Si la Garantia a Eliminar no se encuentra activa en Garantias Operaciones
		IF NOT EXISTS (	SELECT	Id_Garantia_Aval 
						FROM	GARANTIAS_OPERACIONES 
						WHERE	Id_Garantia_Aval = @piId_Garantia_Aval
								AND Ind_Estado_Registro = 1
						)
		BEGIN

			IF (@viBandera = 0)
			BEGIN
				DECLARE 
						@viId_Tipo_Aval								INT, 
						@vsNumero_Aval								VARCHAR(30), 
						@vdMonto_Avalado							DECIMAL(22,2), 
						@vsCod_Garantia_BCR							VARCHAR(30), 
						@vdtFecha_Emision							DATETIME, 
						@vdtFecha_Vencimiento						DATETIME, 
						@viId_Tipo_Persona_Deudor					INT, 
						@vsId_Deudor								VARCHAR(30), 
						@viId_Tipo_Asignacion_Calificacion			INT, 
						@viId_Plazo_Calificacion					INT, 
						@viId_Empresa_Calificadora					INT, 
						@viId_Categoria_Riesgo_Empresa_Calificadora	INT, 
						@viId_Calificacion_Empresa_Calificadora		INT,
						@vsInd_Metodo_Insercion						VARCHAR(30),
						@vdFecha_Ingreso							DATETIME,	
						@vdCod_Usuario_Ingreso						VARCHAR(20),					
						@vdFecha_Ultima_Modificacion				DATETIME 

				SELECT 
						@viId_Tipo_Aval								= Id_Tipo_Aval, 
						@vsNumero_Aval								= Numero_Aval, 
						@vdMonto_Avalado							= Monto_Avalado, 
						@vsCod_Garantia_BCR							= Cod_Garantia_BCR, 
						@vdtFecha_Emision							= Fecha_Emision, 
						@vdtFecha_Vencimiento						= Fecha_Vencimiento, 
						@viId_Tipo_Persona_Deudor					= Id_Tipo_Persona_Deudor, 
						@vsId_Deudor								= Id_Deudor, 
						@viId_Tipo_Asignacion_Calificacion			= Id_Tipo_Asignacion_Calificacion, 
						@viId_Plazo_Calificacion					= Id_Plazo_Calificacion, 
						@viId_Empresa_Calificadora					= Id_Empresa_Calificadora, 
						@viId_Categoria_Riesgo_Empresa_Calificadora	= Id_Categoria_Riesgo_Empresa_Calificadora, 
						@viId_Calificacion_Empresa_Calificadora		= Id_Calificacion_Empresa_Calificadora,
						@vdFecha_Ingreso							= Fecha_Ingreso,
						@vdCod_Usuario_Ingreso						= Cod_Usuario_Ingreso,
						@vsInd_Metodo_Insercion						= Ind_Metodo_Insercion,
						@vdFecha_Ultima_Modificacion				= GETDATE()
				FROM 	dbo.GARANTIAS_AVALES
				WHERE	Id_Garantia_Aval	=	@piId_Garantia_Aval

				--Actualiza el registro actual con Ind_Estado_Registro = 0
				UPDATE	dbo.GARANTIAS_AVALES
				   SET  Ind_Estado_Registro				=	0
				 WHERE	Id_Garantia_Aval	=	@piId_Garantia_Aval

				SELECT	@viEstado = 1, 
						@viNumero_Error = 0

				--Inserta el nuevo registro

				EXEC dbo.Garantias_Avales_Inserta
						@viId_Tipo_Aval, 
						@vsNumero_Aval, 
						@vdMonto_Avalado, 
						@vsCod_Garantia_BCR, 
						@vdtFecha_Emision, 
						@vdtFecha_Vencimiento, 
						@viId_Tipo_Persona_Deudor, 
						@vsId_Deudor, 
						@viId_Tipo_Asignacion_Calificacion, 
						@viId_Plazo_Calificacion, 
						@viId_Empresa_Calificadora, 
						@viId_Categoria_Riesgo_Empresa_Calificadora, 
						@viId_Calificacion_Empresa_Calificadora,
						@vsInd_Metodo_Insercion,
						@vdCod_Usuario_Ingreso,
						@vdFecha_Ingreso,					
						@vdFecha_Ultima_Modificacion,
						@psCod_Usuario,
						'E'
			END
			ELSE
			BEGIN
				SET @viEstado = 0
				SET @viNumero_Error = 18
			END

			--Si no hubo error, se aplica la transacción
			COMMIT TRANSACTION TRA_Eliminar

			SELECT	@viEstado		AS Estado, 
					@viNumero_Error AS NumeroError
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




