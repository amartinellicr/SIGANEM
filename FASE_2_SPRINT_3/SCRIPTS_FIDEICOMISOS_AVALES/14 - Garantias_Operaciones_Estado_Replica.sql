USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[Garantias_Operaciones_Estado_Replica]
( 
       @piId_Garantia_Operacion             INT,
	   @piInd_Estado_Replicado				INT,    
	   @pdtFecha_Prescripcion_Garantia		DATETIME = NULL,
       @psCod_Usuario                       VARCHAR(20)
)
AS 
/******************************************************************************************************************************************************
<Nombre>Garantias_Operaciones_Estado_Replica</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que actualiza la información de las Garantías Operaciones</Descripción>
<Entradas>@piId_Garantia_Operacion = Llave de control interna de la tabla GARANTIAS_OPERACIONES                   
             @piId_Garantia_Operacion = Llave de control interna de la tabla GARANTIAS_OPERACIONES                                                                   
			 @piInd_Estado_Replicado = Indicador del estado de replica de la garantia relacionada. 
			 @pdtFecha_Prescripcion_Garantia = Fecha de prescripcion de la garantia relacionada. 
             @psCod_Usuario = Código de usuario             
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
		<Descripción>Se agrega la manipulación de los campos en la consulta de salida "Id_Fideicomiso", "Id_Garantia_Aval" e "Id_Tipo_Indicador_Inscripcion"</Descripción>
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
		DECLARE @viId_Tipo_Moneda_Monto_Gravamen			INT = NULL,
			   @vnMonto_Grado_Gravamen                      NUMERIC(22,2) = NULL,
			   @viId_Grado_Gravamen							INT = NULL,
			   @vdtFecha_Constitucion_Garantia				DATETIME = NULL,
			   @viId_Clase_Garantia_PRT17					INT = NULL,
			   @viId_Tenencia_PRT_15                        INT = NULL,
			   @viId_Tenencia_PRT_17                        INT = NULL,
			   @vbInd_Deudor_Habita							BIT = NULL,
			   @vbInd_Recomendacion_Perito                  BIT = NULL,
			   @vbInd_Inspeccion_Garantia					BIT = NULL,
			   @viId_Tipo_Mitigador_Riesgo                  INT = NULL,
			   @viId_Tipo_Documento_Legal					INT = NULL,
			   @vnMonto_Mitigador                           NUMERIC(22,2) = NULL,
			   @vnPorcentaje_Aceptacion_BCR					NUMERIC(5,2) = NULL,			   
			   @vnPorcentaje_Responsabilidad_SUGEF			NUMERIC(5,2) = NULL,
			   --@vbInd_Poliza                                BIT = NULL,
			   @viId_Partido								INT,
			   @vsInd_Metodo_Insercion                      VARCHAR(30),
			   @vdtFecha_Prescripcion_Garantia				DATETIME = NULL,
			   @vnPorcentaje_Aceptacion_No_Terreno_SUGEF	NUMERIC(5,2) = NULL,
			   @vnPorcentaje_Aceptacion_Terreno_SUGEF		NUMERIC(5,2) = NULL,
			   @vnMonto_Mitigador_Calculado                 NUMERIC(22,2) = NULL,
			   @vnPorcentaje_Responsabilidad_Legal			NUMERIC(5,2) = NULL,
			   @piId_Fideicomiso							INT = NULL,
			   @piId_Garantia_Aval							INT = NULL,
			   @piId_Tipo_Indicador_Inscripcion				INT = NULL

             SELECT
                    @viId_Tipo_Moneda_Monto_Gravamen = Id_Tipo_Moneda_Monto_Gravamen,
                    @vnMonto_Grado_Gravamen = Monto_Grado_Gravamen,
                    @viId_Grado_Gravamen = Id_Grado_Gravamen,
                    @vdtFecha_Constitucion_Garantia = Fecha_Constitucion_Garantia ,
                    @viId_Clase_Garantia_PRT17 = Id_Clase_Garantia_PRT17 ,
                    @viId_Tenencia_PRT_15 = Id_Tenencia_PRT_15 ,
                    @viId_Tenencia_PRT_17 = Id_Tenencia_PRT_17,
					@vbInd_Deudor_Habita = Ind_Deudor_Habita,
					@vbInd_Recomendacion_Perito = Ind_Recomendacion_Perito,
					@vbInd_Inspeccion_Garantia = Ind_Inspeccion_Garantia,
					@viId_Tipo_Mitigador_Riesgo = Id_Tipo_Mitigador_Riesgo,
					@viId_Tipo_Documento_Legal = Id_Tipo_Documento_Legal,
					@vnMonto_Mitigador = Monto_Mitigador,
					@vnMonto_Mitigador_Calculado = Monto_Mitigador_Calculado,
					@vnPorcentaje_Aceptacion_BCR = Porcentaje_Aceptacion_BCR,
					@vnPorcentaje_Aceptacion_No_Terreno_SUGEF = Porcentaje_Aceptacion_No_Terreno_SUGEF,
					@vnPorcentaje_Aceptacion_Terreno_SUGEF = Porcentaje_Aceptacion_Terreno_SUGEF,
					@vnPorcentaje_Responsabilidad_SUGEF = Porcentaje_Responsabilidad_SUGEF,
					@vnPorcentaje_Responsabilidad_Legal = Porcentaje_Responsabilidad_Legal,
					--@vbInd_Poliza = Ind_Poliza,
					@viId_Partido = Partido,
					@vsInd_Metodo_Insercion = Ind_Metodo_Insercion,
					@vdtFecha_Prescripcion_Garantia =  ISNULL(@pdtFecha_Prescripcion_Garantia,@vdtFecha_Prescripcion_Garantia),
					@piId_Fideicomiso = Id_Fideicomiso,
				    @piId_Garantia_Aval	= Id_Garantia_Aval,
				    @piId_Tipo_Indicador_Inscripcion = Id_Tipo_Indicador_Inscripcion
             FROM 
                    dbo.GARANTIAS_OPERACIONES
             WHERE  
                    Id_Garantia_Operacion = @piId_Garantia_Operacion 

			--SELECT @vdtFecha_Constitucion_Garantia 
             --Actualiza el registro actual con Ind_Estado_Registro = 0
             UPDATE dbo.GARANTIAS_OPERACIONES 
                    SET 
                           Ind_Estado_Registro                     = 0
             WHERE  Id_Garantia_Operacion = @piId_Garantia_Operacion

             --Inserta el nuevo registro
             EXEC dbo.Garantias_Operaciones_Actualiza 
					@piId_Garantia_Operacion,
					@viId_Tipo_Moneda_Monto_Gravamen,
                    @vnMonto_Grado_Gravamen,
                    @viId_Grado_Gravamen,
                    @vdtFecha_Constitucion_Garantia,
                    @viId_Clase_Garantia_PRT17,
                    @viId_Tenencia_PRT_15,
                    @viId_Tenencia_PRT_17,
					@vbInd_Deudor_Habita,
					@vbInd_Recomendacion_Perito,
					@vbInd_Inspeccion_Garantia,
					@viId_Tipo_Mitigador_Riesgo,
					@viId_Tipo_Documento_Legal,
					@vnMonto_Mitigador,
					@vnPorcentaje_Aceptacion_BCR,					
					@vnPorcentaje_Responsabilidad_SUGEF,
					--@vbInd_Poliza,
					@viId_Partido,
					@vsInd_Metodo_Insercion,
					@psCod_Usuario,
					@piInd_Estado_Replicado, --1 REPLICADO 0 PENDIENTE
					@vdtFecha_Prescripcion_Garantia,
					@vnPorcentaje_Aceptacion_No_Terreno_SUGEF,
					@vnPorcentaje_Aceptacion_Terreno_SUGEF,
					@vnMonto_Mitigador_Calculado,
					@vnPorcentaje_Responsabilidad_Legal,
					@piId_Tipo_Indicador_Inscripcion

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



