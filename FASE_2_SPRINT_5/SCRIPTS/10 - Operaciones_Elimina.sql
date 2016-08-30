USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Operaciones_Elimina', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Operaciones_Elimina;
GO

CREATE PROCEDURE [dbo].[Operaciones_Elimina]
( 
    @piId_Operacion		INT,
	@psCod_Usuario		VARCHAR(20)
)
AS 
/******************************************************************************************************************************************************
<Nombre>Operaciones_Elimina</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que elimina la información en la tabla OPERACIONES</Descripción>
<Entradas>@piId_Operacion	= Llave de control interno
		  @psCod_Usuario		= Código de usuario</Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado C.</Autor>
<Fecha>Marzo del 2014</Fecha>
<Requerimiento>1-24105255 </Requerimiento>
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
		
		DECLARE @vbEstado_Registro_Operacion BIT

		SELECT 
			@vbEstado_Registro_Operacion = Estado_Registro_Operacion 
		FROM 
			dbo.OPERACIONES 
		WHERE 
			Id_Operacion = @piId_Operacion
		

		IF @vbEstado_Registro_Operacion = 0
		BEGIN

			SELECT	1 AS Estado, 
					0 AS NumeroError

		--Eliminar Registro Preliminar							 
			DELETE FROM G FROM dbo.GARANTIAS_OPERACIONES G
			INNER JOIN dbo.OPERACIONES O
			ON G.Id_Operacion = O.Id_Operacion	
			WHERE O.Id_Operacion = @piId_Operacion		
			AND Estado_Registro_Operacion = 0

			DELETE FROM dbo.OPERACIONES		
			WHERE Id_Operacion = @piId_Operacion		
			AND Estado_Registro_Operacion = 0
		END
		ELSE
		BEGIN

			DECLARE @CONTROL INT

			--Busca de Garantias Relacionadas Replicadas
			SELECT 
				@CONTROL = COUNT(1)
			FROM GARANTIAS_OPERACIONES 
			WHERE Id_Operacion = @piId_Operacion 
			AND Ind_Estado_Registro = 1
			AND Ind_Estado_Replicado = 1

			IF(ISNULL(@CONTROL,0) <> 0)
			BEGIN
				
				SELECT	0 AS Estado, 
						13 AS NumeroError --Tiene Garantias Replicadas
			END
			ELSE
			BEGIN
			
				--Actualiza
				UPDATE dbo.OPERACIONES               
					SET 
						Ind_Estado_Registro = 0
				WHERE	Id_Operacion = @piId_Operacion

				SELECT	1 AS Estado, 
						0 AS NumeroError

				--Variables
				DECLARE 
					@viId_Tipo_Operacion                INT,
					@vsConta							VARCHAR(2),
					@vsOficina							VARCHAR(3),
					@vsMoneda							VARCHAR(2),
					@vsProd								VARCHAR(2),
					@vsNumero							VARCHAR(7),
					@viId_Tipo_Identificacion_RUC       INT,
					@vbDesembolso						BIT,
					@vsIdentificacion_RUC               VARCHAR (50),
					@vsCod_Tipo_Identificacion_SICC	    VARCHAR (10),
					@vsIdentificacion_SICC				VARCHAR (50),
					@vdtFecha_Ingreso					DATETIME, 
					@vdtFecha_Ultima_Modificacion		DATETIME, 
					@vsCod_Usuario_Ultima_Modificacion	VARCHAR(20), 
					@vsInd_Accion_Registro				VARCHAR(3),
					@vsInd_Metodo_Insercion				VARCHAR(30)
			
				SELECT
					@viId_Tipo_Operacion = Id_Tipo_Operacion,
					@vsConta = Conta, 
					@vsOficina = Oficina,
					@vsMoneda = Moneda,
					@vsProd = Prod,
					@vsNumero = Numero,
					@viId_Tipo_Identificacion_RUC = Id_Tipo_Identificacion_RUC,
					@vsIdentificacion_RUC = Identificacion_RUC,
					@vsCod_Tipo_Identificacion_SICC = Cod_Tipo_Identificacion_SICC,
					@vsIdentificacion_SICC = Identificacion_SICC,
					@vbEstado_Registro_Operacion = Estado_Registro_Operacion,
					@vbDesembolso = Desembolso,
					@vdtFecha_Ingreso = ISNULL(Fecha_Ingreso,GETDATE()),
					@psCod_Usuario = ISNULL(Cod_Usuario_Ingreso,@psCod_Usuario),
					@vdtFecha_Ultima_Modificacion = CASE WHEN Fecha_Ingreso IS NOT NULL THEN GETDATE() ELSE NULL END,
					@vsCod_Usuario_Ultima_Modificacion = CASE WHEN Fecha_Ingreso IS NOT NULL THEN @psCod_Usuario ELSE NULL END,
					@vsInd_Accion_Registro  = CASE WHEN Estado_Registro_Operacion = 0 THEN 'I' ELSE 'M' END,
					@vsInd_Metodo_Insercion = Ind_Metodo_Insercion 
				FROM 		
					dbo.OPERACIONES
				WHERE	
					Id_Operacion = @piId_Operacion		
				
				DECLARE @poiId_Operacion INT								 

				EXEC dbo.Operaciones_Inserta_Generales
					@viId_Tipo_Operacion,
					@vsConta,
					@vsOficina,
					@vsMoneda,
					@vsProd,
					@vsNumero,
					@viId_Tipo_Identificacion_RUC,
					@vsIdentificacion_RUC, 
					@vsCod_Tipo_Identificacion_SICC,
					@vsIdentificacion_SICC,
					@vbDesembolso,
					@vbEstado_Registro_Operacion,
					@vsInd_Metodo_Insercion,
					@psCod_Usuario,
					@vdtFecha_Ingreso,
					@vdtFecha_Ultima_Modificacion,
					@vsCod_Usuario_Ultima_Modificacion,
					'E',
					@poiId_Operacion = @poiId_Operacion OUTPUT

				INSERT INTO dbo.GARANTIAS_OPERACIONES
				   (Id_Operacion
				   ,Id_Tipo_Garantia
				   ,Id_Garantia_Fiduciaria
				   ,Id_Garantia_Valor
				   ,Id_Garantia_Real
				   ,Ind_Estado_Replicado
				   ,Id_Tipo_Moneda_Monto_Gravamen
				   ,Monto_Grado_Gravamen
				   ,Id_Grado_Gravamen
				   ,Fecha_Constitucion_Garantia
				   ,Id_Clase_Garantia_PRT17
				   ,Id_Tenencia_PRT_15
				   ,Id_Tenencia_PRT_17
				   ,Ind_Deudor_Habita
				   ,Ind_Recomendacion_Perito
				   ,Ind_Inspeccion_Garantia
				   ,Id_Tipo_Mitigador_Riesgo
				   ,Id_Tipo_Documento_Legal
				   ,Monto_Mitigador
				   ,Porcentaje_Aceptacion_BCR				   
				   ,Porcentaje_Responsabilidad_SUGEF
				   --,Ind_Poliza
				   ,Partido
				   ,Ind_Metodo_Insercion
				   ,Fecha_Ingreso
				   ,Cod_Usuario_Ingreso
				   ,Fecha_Ultima_Modificacion
				   ,Cod_Usuario_Ultima_Modificacion
				   ,Ind_Estado_Registro
				   ,Ind_Accion_Registro
				   ,Fecha_Prescripcion_Garantia
				   ,Porcentaje_Aceptacion_No_Terreno_SUGEF
				   ,Porcentaje_Aceptacion_Terreno_SUGEF
				   ,Monto_Mitigador_Calculado
				   ,Porcentaje_Responsabilidad_Legal
				   ,Id_Fideicomiso
				   ,Id_Garantia_Aval
				   ,Id_Tipo_Indicador_Inscripcion
				   ,Monto_Grado_Gravamen_Original
				   ,Monto_Grado_Gravamen_Modificado
				   ,Ind_Monto_Grado_Gravamen_Modificado)
				SELECT 
					@poiId_Operacion
					,Id_Tipo_Garantia 
					,Id_Garantia_Fiduciaria
					,Id_Garantia_Valor
					,Id_Garantia_Real
					,Ind_Estado_Replicado
					,Id_Tipo_Moneda_Monto_Gravamen
					,Monto_Grado_Gravamen
					,Id_Grado_Gravamen
					,Fecha_Constitucion_Garantia
					,Id_Clase_Garantia_PRT17
					,Id_Tenencia_PRT_15
					,Id_Tenencia_PRT_17
					,Ind_Deudor_Habita
					,Ind_Recomendacion_Perito
					,Ind_Inspeccion_Garantia
					,Id_Tipo_Mitigador_Riesgo
					,Id_Tipo_Documento_Legal
					,Monto_Mitigador
					,Porcentaje_Aceptacion_BCR					
					,Porcentaje_Responsabilidad_SUGEF
					--,Ind_Poliza
					,Partido
					,Ind_Metodo_Insercion
					,Fecha_Ingreso
					,Cod_Usuario_Ingreso
					,@vdtFecha_Ultima_Modificacion 
					,@vsCod_Usuario_Ultima_Modificacion
					,0--Ind_Estado_Registro 
					,'E'--Ind_Accion_Registro		
					,Fecha_Prescripcion_Garantia
					,Porcentaje_Aceptacion_No_Terreno_SUGEF
					,Porcentaje_Aceptacion_Terreno_SUGEF
					,Monto_Mitigador_Calculado
					,Porcentaje_Responsabilidad_Legal
				    ,Id_Fideicomiso
				    ,Id_Garantia_Aval
				    ,Id_Tipo_Indicador_Inscripcion
					,Monto_Grado_Gravamen_Original
				    ,Monto_Grado_Gravamen_Modificado
				    ,Ind_Monto_Grado_Gravamen_Modificado
				FROM dbo.GARANTIAS_OPERACIONES
				WHERE 
					Id_Operacion = @piId_Operacion 	
				AND Ind_Estado_Registro = 1		
			
				--Actualizar
				UPDATE dbo.GARANTIAS_OPERACIONES               
					SET 
						Ind_Estado_Registro = 0
				WHERE	Id_Operacion = @piId_Operacion

				--Actualiza Inscripciones
				UPDATE	GRI 
					SET 
						Ind_Estado_Registro = 0
				FROM dbo.GARANTIAS_REALES_INSCRIPCIONES GRI
				INNER JOIN dbo.GARANTIAS_OPERACIONES GOP
					ON GOP.Id_Garantia_Operacion = GRI.Id_Garantia_Operacion
				WHERE	Id_Operacion =	@piId_Operacion

				--Actualiza Mobiliarias
				UPDATE	dbo.GARANTIAS_REALES_MOBILIARIAS 
					SET 
						Ind_Estado_Registro	= 0
				FROM dbo.GARANTIAS_REALES_MOBILIARIAS GRI
				INNER JOIN dbo.GARANTIAS_OPERACIONES GOP
					ON GOP.Id_Garantia_Operacion = GRI.Id_Garantia_Operacion
				WHERE	Id_Operacion = @piId_Operacion

			END
		
		END
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


