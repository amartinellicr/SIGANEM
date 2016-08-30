USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Garantias_Operaciones_Inserta', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Garantias_Operaciones_Inserta;
GO

CREATE PROCEDURE [dbo].[Garantias_Operaciones_Inserta]
( 
    @piId_Operacion						INT,
    @piId_Tipo_Garantia					INT,
	@piId_Garantia_Fiduciaria			INT = NULL,
	@piId_Garantia_Valor				INT = NULL,
	@piId_Garantia_Real					INT = NULL,
	@piId_Tipo_Moneda_Monto_Gravamen	INT = NULL,
	@pnMonto_Grado_Gravamen				NUMERIC(22,2) = NULL,
	@piId_Grado_Gravamen				INT = NULL,
	@pdtFecha_Constitucion_Garantia		DATETIME = NULL,
	@piId_Clase_Garantia_PRT17			INT = NULL,
	@piId_Tenencia_PRT_15				INT = NULL,
	@piId_Tenencia_PRT_17				INT = NULL,
	@pbInd_Deudor_Habita				BIT = NULL,
	@pbInd_Recomendacion_Perito			BIT = NULL,
	@pbInd_Inspeccion_Garantia			BIT = NULL,
	@piId_Tipo_Mitigador_Riesgo			INT = NULL,
	@piId_Tipo_Documento_Legal			INT = NULL,
	@pnMonto_Mitigador					NUMERIC(24,2) = NULL,
	@pnPorcentaje_Aceptacion_BCR		NUMERIC(5,2) = NULL,	
	@pnPorcentaje_Responsabilidad_SUGEF NUMERIC(5,2) = NULL,
	--@pbInd_Poliza						BIT = NULL,
	@piPartido							INT = NULL,
	@psCod_Usuario						VARCHAR(20),
	@pdFecha_Ingreso					DATETIME = NULL,	
	@pdFecha_Ultima_Modificacion		DATETIME = NULL,
	@psCod_Usuario_Ultima_Modificacion	VARCHAR(20) = NULL,
	@psInd_Accion_Registro				VARCHAR(3) = NULL,
	@psInd_Metodo_Insercion				VARCHAR(30),
	@piInd_Estado_Replicado				INT = NULL,
	@pdtFecha_Prescripcion_Garantia		DATETIME = NULL,
	@pnPorcentaje_Aceptacion_No_Terreno_SUGEF	NUMERIC(5,2) = NULL,
	@pnPorcentaje_Aceptacion_Terreno_SUGEF		NUMERIC(5,2) = NULL,
	@pnMonto_Mitigador_Calculado		NUMERIC(22,2) = NULL,
	@pnPorcentaje_Responsabilidad_Legal	NUMERIC(5,2) = NULL,
	@piId_Fideicomiso					INT = NULL,
	@piId_Garantia_Aval					INT = NULL,
	@piId_Tipo_Indicador_Inscripcion	INT = NULL,
	@pnMonto_Grado_Gravamen_Original	NUMERIC(22,2) = NULL,
	@pnMonto_Grado_Gravamen_Modificado	NUMERIC(22,2) = NULL,
	@pbInd_Monto_Grado_Gravamen_Modificado	BIT = NULL
)
AS 
/******************************************************************************************************************************************************
<Nombre>Garantias_Operaciones_Inserta</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que inserta la información en la tabla GARANTIAS_REALES_CEDULAS </Descripción>
<Entradas>@piId_Operacion = Llave de control interna de la tabla OPERACIONES			
		@piId_Tipo_Garantia = Llave de control interna de la tabla TIPOS_GARANTIAS					
		@piId_Garantia_Fiduciaria = Llave de control interna de la tabla GARANTIAS_FIDUCIARIAS			
		@piId_Garantia_Valor = Llave de control interna de la tabla GARANTIAS_VALORES				
		@piId_Garantia_Real	= Llave de control interna de la tabla GARANTIAS_REALES				
		@piId_Tipo_Moneda_Monto_Gravamen = Llave de control interna de la tabla TIPOS_MONEDAS	
		@pnMonto_Grado_Gravamen	= Monto Grado Gravamen		
		@piId_Grado_Gravamen = Llave de control interna de la tabla GRADOS_GRAVAMENES
		@pdtFecha_Constitucion_Garantia	= Fecha de Constitucion de la Garantia	
		@piId_Clase_Garantia_PRT17 = Llave de control interna de la tabla CLASES_GARANTIAS_PRT_17			
		@piId_Tenencia_PRT_15 = Llave de control interna de la tabla TENENCIAS_PRT_15				
		@piId_Tenencia_PRT_17 = Llave de control interna de la tabla TENENCIAS_PRT_17				
		@pbInd_Deudor_Habita = Indicador si el duedor habita				
		@pbInd_Recomendacion_Perito	= Indicador de recomendación del perito		
		@pbInd_Inspeccion_Garantia = Indicador de Inspección Garantía		
		@piId_Tipo_Mitigador_Riesgo = Llave de control interna de la tabla TIPOS_MITIGADORES_RIESGOS			
		@piId_Tipo_Documento_Legal = Llave de control interna de la tabla TIPOS_DOCUMENTOS_LEGALES			
		@pnMonto_Mitigador = Monto Mitigador					
		@pnPorcentaje_Aceptacion_BCR = Porcentaje de Aceptación BCR				
		@pnPorcentaje_Responsabilidad_SUGEF = Porcentaje de Responsabilidad SUGEF  
		@pbInd_Poliza = Indicador póliza						
		@piPartido = Partido
		@psCod_Usuario = Código de usuario
		@pdFecha_Ingreso = Fecha de creacion del registro
		@pdFecha_Ultima_Modificacion = Fecha de la ultima Modificacion del Registro
		@psCod_Usuario_Ultima_Modificacion = Usuario de la modificacion del registro
		@psInd_Accion_Registro = Indicador de acción del registro
		@psInd_Metodo_Insercion = Indicador de método de ingreso del registro
		@pnPorcentaje_Aceptacion_No_Terreno_SUGEF = Porcentaje de Aceptación No Terreno SUGEF		
		@pnPorcentaje_Aceptacion_Terreno_SUGEF = Porcentaje de Aceptación Terreno SUGEF		
		@pnMonto_Mitigador_Calculado = Monto Mitigador Calculado
		@pnPorcentaje_Responsabilidad_Legal = Responsabilidad Legal	
		@piId_Fideicomiso = Llave de control interna de la tabla FIDEICOMISOS
		@piId_Garantia_Aval = Llave de control interna de la tabla GARANTIAS_AVALES
		@piId_Tipo_Indicador_Inscripcion = Llave de control interna de la tabla TIPOS_INDICADORES_INSCRIPCIONES de los Fideicomisos
		@pnMonto_Grado_Gravamen_Original = Monto del grado gravamen original
		@pnMonto_Grado_Gravamen_Modificado = Monto del grado gravamen modificado por el usuario
		@pbInd_Monto_Grado_Gravamen_Modificado = Indicador de que el monto del grado gravamen ha sido modificado por el usuario
</Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado C.</Autor>
<Fecha>Marzo del 2014</Fecha>
<Requerimiento>1-24105255</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli Marín</Autor>
		<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
		<Fecha>21/06/2016</Fecha>
		<Descripción>Se agregan los parámetros de entrada "@piId_Fideicomiso", "@piId_Garantia_Aval" y "@piId_Tipo_Indicador_Inscripcion" y su correspondiente manipulación</Descripción>
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
	BEGIN TRANSACTION TRA_Insertar

	--Inicia control de errores
	BEGIN TRY

		--Validaciones de codigos unicos
		DECLARE @CONTROL INT,
				@ERRORNUMBER INT = NULL

		SELECT 
			@CONTROL = COUNT(1)
		FROM 
			dbo.GARANTIAS_OPERACIONES 
		WHERE
			Ind_Estado_Registro = 1
			AND Id_Operacion = @piId_Operacion
			AND Id_Tipo_Garantia = @piId_Tipo_Garantia
			AND (Id_Garantia_Fiduciaria = @piId_Garantia_Fiduciaria OR Id_Garantia_Fiduciaria IS NULL)
			AND (Id_Garantia_Valor = @piId_Garantia_Valor OR Id_Garantia_Valor IS NULL)
			AND (Id_Garantia_Real = @piId_Garantia_Real OR Id_Garantia_Real IS NULL)
			AND (Id_Fideicomiso = @piId_Fideicomiso OR Id_Fideicomiso IS NULL)
			AND (Id_Garantia_Aval = @piId_Garantia_Aval OR Id_Garantia_Aval IS NULL)
			--AND (Id_Tipo_Moneda_Monto_Gravamen = @piId_Tipo_Moneda_Monto_Gravamen OR Id_Tipo_Moneda_Monto_Gravamen IS NULL)
			--AND (Monto_Grado_Gravamen = @pnMonto_Grado_Gravamen OR Monto_Grado_Gravamen IS NULL)
			--AND (Id_Grado_Gravamen = @piId_Grado_Gravamen OR Id_Grado_Gravamen IS NULL)
			--AND (Fecha_Constitucion_Garantia = @pdtFecha_Constitucion_Garantia OR Fecha_Constitucion_Garantia IS NULL)
			--AND (Id_Clase_Garantia_PRT17 = @piId_Clase_Garantia_PRT17 OR Id_Clase_Garantia_PRT17 IS NULL)
			--AND (Id_Tenencia_PRT_15 = @piId_Tenencia_PRT_15 OR Id_Tenencia_PRT_15 IS NULL)
			--AND (Id_Tenencia_PRT_17 = @piId_Tenencia_PRT_17 OR Id_Tenencia_PRT_17 IS NULL)
			--AND (Ind_Deudor_Habita = @pbInd_Deudor_Habita OR Ind_Deudor_Habita IS NULL)
			--AND (Ind_Recomendacion_Perito = @pbInd_Recomendacion_Perito OR Ind_Recomendacion_Perito IS NULL)
			--AND (Ind_Inspeccion_Garantia = @pbInd_Inspeccion_Garantia OR Ind_Inspeccion_Garantia IS NULL)
			--AND (Id_Tipo_Mitigador_Riesgo = @piId_Tipo_Mitigador_Riesgo OR Id_Tipo_Mitigador_Riesgo IS NULL)
			--AND (Id_Tipo_Documento_Legal = @piId_Tipo_Documento_Legal OR Id_Tipo_Documento_Legal IS NULL)
			--AND (Monto_Mitigador = @pnMonto_Mitigador OR Monto_Mitigador IS NULL)
			--AND (Porcentaje_Aceptacion_BCR = @pnPorcentaje_Aceptacion_BCR AND @pnPorcentaje_Aceptacion_BCR IS NULL)
			--AND (Porcentaje_Aceptacion_SUGEF = @pnPorcentaje_Aceptacion_SUGEF AND Porcentaje_Aceptacion_SUGEF IS NULL)
			--AND (Porcentaje_Responsabilidad_SUGEF = @pnPorcentaje_Responsabilidad_SUGEF AND Porcentaje_Responsabilidad_SUGEF IS NULL)
			--AND (Ind_Poliza = @pbInd_Poliza OR Ind_Poliza IS NULL)

		IF(ISNULL(@CONTROL,0) <> 0)
		BEGIN
			SET @ERRORNUMBER = 2601
			SET @CONTROL = 'ERROR'
		END

		--Actualiza la fecha de ultima modificacion y el usuario

			UPDATE dbo.OPERACIONES
				SET 
					Fecha_Ultima_Modificacion =  GETDATE(),
					Cod_Usuario_Ultima_Modificacion = @psCod_Usuario
			WHERE Id_Operacion = @piId_Operacion


		INSERT INTO GARANTIAS_OPERACIONES
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
     VALUES
           (@piId_Operacion
           ,@piId_Tipo_Garantia
           ,@piId_Garantia_Fiduciaria
           ,@piId_Garantia_Valor
           ,@piId_Garantia_Real
           ,ISNULL(@piInd_Estado_Replicado,0) --ESTADO PENDIENTE
           ,@piId_Tipo_Moneda_Monto_Gravamen
           ,@pnMonto_Grado_Gravamen
           ,@piId_Grado_Gravamen
           ,@pdtFecha_Constitucion_Garantia
           ,@piId_Clase_Garantia_PRT17
           ,@piId_Tenencia_PRT_15
           ,@piId_Tenencia_PRT_17
           ,@pbInd_Deudor_Habita
           ,@pbInd_Recomendacion_Perito
           ,@pbInd_Inspeccion_Garantia
           ,@piId_Tipo_Mitigador_Riesgo
           ,@piId_Tipo_Documento_Legal
           ,@pnMonto_Mitigador
           ,@pnPorcentaje_Aceptacion_BCR           
           ,@pnPorcentaje_Responsabilidad_SUGEF
           --,@pbInd_Poliza
		   --,NULL
		   ,@piPartido
           ,@psInd_Metodo_Insercion 
           ,ISNULL(@pdFecha_Ingreso,GETDATE())
           ,@psCod_Usuario
           ,@pdFecha_Ultima_Modificacion
           ,@psCod_Usuario_Ultima_Modificacion
           ,CASE WHEN ISNULL(@psInd_Accion_Registro,'I') = 'E' THEN 0 ELSE 1 END
           ,ISNULL(@psInd_Accion_Registro,'I')
		   ,@pdtFecha_Prescripcion_Garantia
		   ,@pnPorcentaje_Aceptacion_No_Terreno_SUGEF
		   ,@pnPorcentaje_Aceptacion_Terreno_SUGEF
		   ,@pnMonto_Mitigador_Calculado
		   ,@pnPorcentaje_Responsabilidad_Legal
		   ,@piId_Fideicomiso
		   ,@piId_Garantia_Aval
		   ,@piId_Tipo_Indicador_Inscripcion
		   ,CASE WHEN ISNULL(@psInd_Accion_Registro,'I') = 'I' THEN @pnMonto_Grado_Gravamen ELSE @pnMonto_Grado_Gravamen_Original END
		   ,CASE WHEN ISNULL(@psInd_Accion_Registro,'I') = 'M' THEN @pnMonto_Grado_Gravamen ELSE @pnMonto_Grado_Gravamen_Modificado END
		   ,CASE WHEN ISNULL(@psInd_Accion_Registro,'I') = 'M' THEN 1 ELSE @pbInd_Monto_Grado_Gravamen_Modificado END)


		--Si no hubo error, se aplica la transacción
		COMMIT TRANSACTION TRA_Insertar

		SELECT	1 AS Estado, 
				0 AS NumeroError

	END TRY

	--En caso de error, realiza lo siguiente
	BEGIN CATCH

		SELECT	0 AS Estado, 
				ISNULL(@ERRORNUMBER,ERROR_NUMBER()) AS NumeroError
		ROLLBACK TRANSACTION TRA_Insertar

	END CATCH

END
GO


