USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Garantias_Operaciones_Actualiza', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Garantias_Operaciones_Actualiza;
GO

CREATE PROCEDURE [dbo].[Garantias_Operaciones_Actualiza]
( 
    @piId_Garantia_Operacion					INT,    
    @piId_Tipo_Moneda_Monto_Gravamen			INT = NULL,
    @pnMonto_Grado_Gravamen						NUMERIC(22,2) = NULL,
    @piId_Grado_Gravamen						INT = NULL,
    @pdtFecha_Constitucion_Garantia				DATETIME = NULL,
    @piId_Clase_Garantia_PRT17					INT = NULL,
    @piId_Tenencia_PRT_15						INT = NULL,
    @piId_Tenencia_PRT_17						INT = NULL,
    @pbInd_Deudor_Habita						BIT = NULL,
    @pbInd_Recomendacion_Perito					BIT = NULL,
    @pbInd_Inspeccion_Garantia					BIT = NULL,
    @piId_Tipo_Mitigador_Riesgo					INT = NULL,
    @piId_Tipo_Documento_Legal					INT = NULL,
    @pnMonto_Mitigador							 NUMERIC(24,2) = NULL,
    @pnPorcentaje_Aceptacion_BCR				NUMERIC(5,2) = NULL,
    @pnPorcentaje_Responsabilidad_SUGEF			NUMERIC(5,2) = NULL,
    --@pbInd_Poliza								BIT = NULL,
	@piPartido									INT = NULL,
    @psInd_Metodo_Insercion						VARCHAR(30),
    @psCod_Usuario								VARCHAR(20),
	@piInd_Estado_Replicado						INT = NULL,
	@pdtFecha_Prescripcion_Garantia				DATETIME = NULL,
	@pnPorcentaje_Aceptacion_No_Terreno_SUGEF	NUMERIC(5,2) = NULL,
	@pnPorcentaje_Aceptacion_Terreno_SUGEF		NUMERIC(5,2) = NULL,
	@pnMonto_Mitigador_Calculado				NUMERIC(22,2) = NULL,
	@pnPorcentaje_Responsabilidad_Legal			NUMERIC(5,2) = NULL,
	@piId_Tipo_Indicador_Inscripcion			INT = NULL
)
AS 
/******************************************************************************************************************************************************
<Nombre>Garantias_Operaciones_Actualiza</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que actualiza la información de las Garantías Operaciones</Descripción>
<Entradas>@piId_Garantia_Operacion = Llave de control interna de la tabla GARANTIAS_OPERACIONES                   
             @piId_Tipo_Garantia = Llave de control interna de la tabla TIPOS_GARANTIAS                                                                   
             @piId_Tipo_Moneda_Monto_Gravamen = Llave de control interna de la tabla TIPOS_MONEDAS  
             @pnMonto_Grado_Gravamen    = Monto Grado Gravamen            
             @piId_Grado_Gravamen = Llave de control interna de la tabla GRADOS_GRAVAMENES
             @pdtFecha_Constitucion_Garantia   = Fecha de Constitucion de la Garantia  
             @piId_Clase_Garantia_PRT17 = Llave de control interna de la tabla CLASES_GARANTIAS_PRT_17                 
             @piId_Tenencia_PRT_15 = Llave de control interna de la tabla TENENCIAS_PRT_15                       
             @piId_Tenencia_PRT_17 = Llave de control interna de la tabla TENENCIAS_PRT_17                       
             @pbInd_Deudor_Habita = Indicador si el duedor habita                      
             @pbInd_Recomendacion_Perito       = Indicador de recomendación del perito        
             @pbInd_Inspeccion_Garantia = Indicador de Inspección Garantía             
             @piId_Tipo_Mitigador_Riesgo = Llave de control interna de la tabla TIPOS_MITIGADORES_RIESGOS               
             @piId_Tipo_Documento_Legal = Llave de control interna de la tabla TIPOS_DOCUMENTOS_LEGALES                
             @pnMonto_Mitigador = Monto Mitigador                               
             @pnPorcentaje_Aceptacion_BCR = Porcentaje de Aceptación BCR        
             @pnPorcentaje_Aceptacion_SUGEF = Porcentaje de Aceptación SUGEF           
             @pnPorcentaje_Responsabilidad_SUGEF = Porcentaje de Responsabilidad SUGEF  
             @pbInd_Poliza = Indicador póliza  
			 @piPartido = Partido
             @psInd_Metodo_Insercion = Indicador de método de ingreso del registro                               
             @psCod_Usuario = Código de usuario             
			 @pnPorcentaje_Aceptacion_No_Terreno_SUGEF = Porcentaje de Aceptación No Terreno SUGEF           
			 @pnPorcentaje_Aceptacion_Terreno_SUGEF = Porcentaje de Aceptación Terreno SUGEF           
			 @pnMonto_Mitigador_Calculado = Monto Mitigador Calculado
			 @pnPorcentaje_Responsabilidad_Legal = Responsabilidad Legal,
			 @piId_Tipo_Indicador_Inscripcion = Llave de control interna de la tabla TIPOS_INDICADORES_INSCRIPCIONES de los Fideicomisos
</Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado C.</Autor>
<Fecha>Febrero del 2014</Fecha>
<Requerimiento>1-24105230</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli Marín</Autor>
		<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
		<Fecha>21/06/2016</Fecha>
		<Descripción>Se agrega el parámetro de entrada "@piId_Tipo_Indicador_Inscripcion" y su correspondiente manipulación</Descripción>
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
       BEGIN TRANSACTION TRA_Actualizar

       --Inicia control de errores
       BEGIN TRY
             --Variables Usuario y fecha de ingreso
             DECLARE @vdFecha_Ingreso					DATETIME,    
                           @vdCod_Usuario_Ingreso       VARCHAR(20),
                           @viId_Operacion              INT = NULL,
                           @viId_Tipo_Garantia          INT = NULL,
                           @viId_Garantia_Fiduciaria	INT = NULL,
                           @viId_Garantia_Valor			INT = NULL,
                           @viId_Garantia_Real          INT = NULL,
						   @viId_Fideicomiso			INT = NULL,
						   @viId_Garantia_Aval			INT = NULL,
						   @vnMonto_Grado_Gravamen_Original	NUMERIC(22,2) = NULL

             SELECT
                    @viId_Operacion = Id_Operacion,
                    @viId_Tipo_Garantia = Id_Tipo_Garantia,
                    @viId_Garantia_Fiduciaria = Id_Garantia_Fiduciaria,
                    @viId_Garantia_Valor = Id_Garantia_Valor,
                    @viId_Garantia_Real = Id_Garantia_Real,
                    @vdFecha_Ingreso = Fecha_Ingreso,
                    @vdCod_Usuario_Ingreso = Cod_Usuario_Ingreso,
					@viId_Fideicomiso = Id_Fideicomiso,
					@viId_Garantia_Aval = Id_Garantia_Aval,
					@vnMonto_Grado_Gravamen_Original = ISNULL(Monto_Grado_Gravamen_Original, @pnMonto_Grado_Gravamen)
             FROM 
                    dbo.GARANTIAS_OPERACIONES
             WHERE  
                    Id_Garantia_Operacion = @piId_Garantia_Operacion 

				


             --Actualiza el registro actual con Ind_Estado_Registro = 0

             UPDATE dbo.GARANTIAS_OPERACIONES 
                    SET	Ind_Estado_Registro = 0
             WHERE  Id_Garantia_Operacion = @piId_Garantia_Operacion

			 
             --Inserta el nuevo registro

             DECLARE @vdFecha_Ultima_Modificacion DATETIME = GETDATE()

             EXEC dbo.Garantias_Operaciones_Inserta
                    @viId_Operacion,
                    @viId_Tipo_Garantia,
                    @viId_Garantia_Fiduciaria,
                    @viId_Garantia_Valor,
                    @viId_Garantia_Real,
                    @piId_Tipo_Moneda_Monto_Gravamen,
                    @pnMonto_Grado_Gravamen,
                    @piId_Grado_Gravamen,
                    @pdtFecha_Constitucion_Garantia,
                    @piId_Clase_Garantia_PRT17,
                    @piId_Tenencia_PRT_15,
                    @piId_Tenencia_PRT_17,
                    @pbInd_Deudor_Habita,
                    @pbInd_Recomendacion_Perito,
                    @pbInd_Inspeccion_Garantia,
                    @piId_Tipo_Mitigador_Riesgo,
                    @piId_Tipo_Documento_Legal,
                    @pnMonto_Mitigador,
                    @pnPorcentaje_Aceptacion_BCR,                    
                    @pnPorcentaje_Responsabilidad_SUGEF,
                    --@pbInd_Poliza,
					@piPartido,
                    @vdCod_Usuario_Ingreso,
                    @vdFecha_Ingreso,
                    @vdFecha_Ultima_Modificacion,
                    @psCod_Usuario,
                    'M',   -- Modificacion
                    @psInd_Metodo_Insercion,
					@piInd_Estado_Replicado,
					@pdtFecha_Prescripcion_Garantia,
					@pnPorcentaje_Aceptacion_No_Terreno_SUGEF,
					@pnPorcentaje_Aceptacion_Terreno_SUGEF,
					@pnMonto_Mitigador_Calculado,
					@pnPorcentaje_Responsabilidad_Legal,
					@viId_Fideicomiso,
					@viId_Garantia_Aval,
					@piId_Tipo_Indicador_Inscripcion,
					@vnMonto_Grado_Gravamen_Original,
					@pnMonto_Grado_Gravamen,
					1
			
			--Actualiza la fecha de ultima modificacion y el usuario

				UPDATE dbo.OPERACIONES
				SET 
						Fecha_Ultima_Modificacion =  GETDATE(),
						Cod_Usuario_Ultima_Modificacion = @psCod_Usuario
				WHERE Id_Operacion = @viId_Operacion

             --Si no hubo error, se aplica la transacción
             COMMIT TRANSACTION TRA_Actualizar

             SELECT 1 AS Estado, 
                    0 AS NumeroError

       END TRY

       --En caso de error, realiza lo siguiente
       BEGIN CATCH  
          
             SELECT 0 AS Estado, 
                    ERROR_NUMBER() AS NumeroError
             ROLLBACK TRANSACTION TRA_Actualizar

       END CATCH
END
GO


