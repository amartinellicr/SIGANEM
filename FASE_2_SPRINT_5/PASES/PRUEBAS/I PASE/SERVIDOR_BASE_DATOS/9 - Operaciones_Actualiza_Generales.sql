USE [USSIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Operaciones_Actualiza_Generales', 'P') IS NOT NULL
	DROP PROCEDURE dbo.Operaciones_Actualiza_Generales;
GO

CREATE PROCEDURE [dbo].[Operaciones_Actualiza_Generales]
( 
    @piId_Operacion                        INT,
       @piId_Tipo_Operacion                INT = NULL,
       @psConta                            VARCHAR(2) = NULL,
       @psOficina                          VARCHAR(3) = NULL,
       @psMoneda                           VARCHAR(2) = NULL,
       @psProd                             VARCHAR(2) = NULL,
       @psNumero                           VARCHAR(7) = NULL,
       @piId_Tipo_Identificacion_RUC       INT = NULL,
       @psIdentificacion_RUC               VARCHAR (50) = NULL,
       @psCod_Tipo_Identificacion_SICC     VARCHAR (10) = NULL,
       @psIdentificacion_SICC              VARCHAR (50) = NULL,
       @pbDesembolso					   BIT,
	   @pbEstado_Registro_Operacion        BIT,
       @psInd_Metodo_Insercion             VARCHAR(30),
       @psCod_Usuario                      VARCHAR(20)
)
AS 
/******************************************************************************************************************************************************
<Nombre>Operaciones_Actualiza_Generales</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que inserta la información en la tabla OPERACIONES </Descripción>
<Entradas>
             @piId_Operacion = Llave de control autogenerada
             @piId_Tipo_Operacion = Llave de control interna de la tabla TIPOS_OPERACIONES
             @psConta =   Codigo Conta               
             @psOficina  = Codigo Oficina                   
             @psMoneda =  Codigo Moneda
             @psProd = Codigo Producto
             @psNumero =  Codigo Numero
             @piId_Tipo_Identificacion_RUC = Llave de control interna de la tabla TIPOS_IDENTIFICACIONES_RUC
             @psIdentificacion_RUC = Numero de identificacion RUC
             @psCod_Tipo_Identificacion_SICC = Codigo de tipo identificacion SICC
             @psIdentificacion_SICC = Identificacion SICC
             @pbDesembolso = Indicador de Desembolso
			 @pbEstado_Registro_Operacion = Indica si el registro esta completo o incompleto
             @psInd_Metodo_Insercion = Indicador Metodo de Inserción
             @psCod_Usuario = Código de usuario 
</Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado C.</Autor>
<Fecha>Abril del 2014</Fecha>
<Requerimiento>1-24105255</Requerimiento>
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
       BEGIN TRANSACTION TRA_Actualizar

       --Inicia control de errores
       BEGIN TRY

            UPDATE	dbo.OPERACIONES               
            SET		Ind_Estado_Registro = 0
            WHERE	Id_Operacion = @piId_Operacion

             --Variables
             DECLARE 
                    @viId_Tipo_Operacion                INT,
                    @vsConta                            VARCHAR(2),
                    @vsOficina                          VARCHAR(3),
                    @vsMoneda                           VARCHAR(2),
                    @vsProd                             VARCHAR(2),
                    @vsNumero                           VARCHAR(7),
                    @viId_Tipo_Identificacion_RUC       INT,
                    @vsIdentificacion_RUC               VARCHAR (50),
                    @vsCod_Tipo_Identificacion_SICC     VARCHAR (10),
                    @vsIdentificacion_SICC              VARCHAR (50),
                    @vbDesembolso						BIT,
					@vbEstado_Registro_Operacion        BIT,              
                    @vdtFecha_Ingreso                   DATETIME, 
                    @vdtFecha_Ultima_Modificacion       DATETIME, 
                    @vsCod_Usuario_Ultima_Modificacion  VARCHAR(20), 
                    @vsInd_Accion_Registro              VARCHAR(3)
                    
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
                           @vbDesembolso = Desembolso,
						   @vbEstado_Registro_Operacion = Estado_Registro_Operacion,
                           @psInd_Metodo_Insercion = Ind_Metodo_Insercion,
                           @vdtFecha_Ingreso = CASE WHEN @pbEstado_Registro_Operacion = 0 THEN NULL ELSE ISNULL(Fecha_Ingreso,GETDATE()) END,
                           @vdtFecha_Ultima_Modificacion = CASE WHEN Fecha_Ingreso IS NOT NULL THEN GETDATE() ELSE NULL END,
                           @vsCod_Usuario_Ultima_Modificacion = CASE WHEN Fecha_Ingreso IS NOT NULL THEN @psCod_Usuario ELSE NULL END,
                                            @psCod_Usuario = ISNULL(Cod_Usuario_Ingreso,@psCod_Usuario),
                           @vsInd_Accion_Registro  = CASE WHEN Estado_Registro_Operacion = 0 THEN 'I' ELSE 'M' END
                    FROM         
                           dbo.OPERACIONES
                    WHERE  
                           Id_Operacion = @piId_Operacion                              


             --Insertar
             DECLARE @poiId_Operacion INT

             EXEC dbo.Operaciones_Inserta_Generales 
                    @piId_Tipo_Operacion,
                    @psConta, 
                    @psOficina,
                    @psMoneda,
                    @psProd,
                    @psNumero,
                    @piId_Tipo_Identificacion_RUC,
                    @psIdentificacion_RUC,
                    @psCod_Tipo_Identificacion_SICC,
                    @psIdentificacion_SICC,
                    @pbDesembolso,
					@pbEstado_Registro_Operacion,
                    @psInd_Metodo_Insercion, 
                    @psCod_Usuario, 
                    @vdtFecha_Ingreso,
                    @vdtFecha_Ultima_Modificacion, 
                    @vsCod_Usuario_Ultima_Modificacion, 
                    @vsInd_Accion_Registro,
                    @poiId_Operacion = @poiId_Operacion OUTPUT

             --Inserta Relacionadas
             INSERT INTO dbo.GARANTIAS_OPERACIONES 
                    (Id_Operacion, 
                    Id_Tipo_Garantia, 
                    Id_Garantia_Fiduciaria, 
                    Id_Garantia_Valor, 
                    Id_Garantia_Real, 
                    Ind_Estado_Replicado, 
                    Id_Tipo_Moneda_Monto_Gravamen, 
                    Monto_Grado_Gravamen, 
                    Id_Grado_Gravamen, 
                    Fecha_Vencimiento_Garantia, 
                    Fecha_Prescripcion_Garantia, 
                    Fecha_Constitucion_Garantia, 
                    Id_Clase_Garantia_PRT17, 
                    Id_Tenencia_PRT_15, 
                    Id_Tenencia_PRT_17, 
                    Ind_Deudor_Habita, 
                    Ind_Recomendacion_Perito, 
                    Ind_Inspeccion_Garantia, 
                    Id_Tipo_Mitigador_Riesgo, 
                    Id_Tipo_Documento_Legal, 
                    Monto_Mitigador, 
                    Porcentaje_Aceptacion_BCR,                     
                    Porcentaje_Responsabilidad_SUGEF, 
                    --Ind_Poliza, 
					Partido,
                    Ind_Metodo_Insercion, 
                    Fecha_Ingreso, 
                    Cod_Usuario_Ingreso, 
                    Fecha_Ultima_Modificacion, 
                    Cod_Usuario_Ultima_Modificacion, 
                    Ind_Estado_Registro, 
                    Ind_Accion_Registro,
					Porcentaje_Aceptacion_No_Terreno_SUGEF, 
					Porcentaje_Aceptacion_Terreno_SUGEF,
					Monto_Mitigador_Calculado,
					Porcentaje_Responsabilidad_Legal,
					Id_Fideicomiso,
					Id_Garantia_Aval,
					Id_Tipo_Indicador_Inscripcion,
					Monto_Grado_Gravamen_Original,
					Monto_Grado_Gravamen_Modificado,
					Ind_Monto_Grado_Gravamen_Modificado)
                    SELECT
                           @poiId_Operacion, 
                           Id_Tipo_Garantia, 
                           Id_Garantia_Fiduciaria, 
                           Id_Garantia_Valor, 
                           Id_Garantia_Real, 
                           Ind_Estado_Replicado, 
                           Id_Tipo_Moneda_Monto_Gravamen, 
                           Monto_Grado_Gravamen, 
                           Id_Grado_Gravamen, 
                           Fecha_Vencimiento_Garantia, 
                           Fecha_Prescripcion_Garantia, 
                           Fecha_Constitucion_Garantia, 
                           Id_Clase_Garantia_PRT17, 
                           Id_Tenencia_PRT_15, 
                           Id_Tenencia_PRT_17, 
                           Ind_Deudor_Habita, 
                           Ind_Recomendacion_Perito, 
                           Ind_Inspeccion_Garantia, 
                           Id_Tipo_Mitigador_Riesgo, 
                           Id_Tipo_Documento_Legal, 
                           Monto_Mitigador, 
                           Porcentaje_Aceptacion_BCR,                             
                           Porcentaje_Responsabilidad_SUGEF, 
                           --Ind_Poliza, 
						   Partido,
                           Ind_Metodo_Insercion, 
                           Fecha_Ingreso, 
                           Cod_Usuario_Ingreso, 
                           @vdtFecha_Ultima_Modificacion, 
                           @vsCod_Usuario_Ultima_Modificacion, 
                           Ind_Estado_Registro, 
                           @vsInd_Accion_Registro,
						   Porcentaje_Aceptacion_No_Terreno_SUGEF,
						   Porcentaje_Aceptacion_Terreno_SUGEF,
						   Monto_Mitigador_Calculado,
						   Porcentaje_Responsabilidad_Legal,
						   Id_Fideicomiso,
						   Id_Garantia_Aval,
						   Id_Tipo_Indicador_Inscripcion,
						   Monto_Grado_Gravamen_Original,
						   Monto_Grado_Gravamen_Modificado,
						   Ind_Monto_Grado_Gravamen_Modificado
                    FROM 
                           dbo.GARANTIAS_OPERACIONES
                    WHERE  
                           Id_Operacion = @piId_Operacion

             --Actualizar Relacionadas
                    UPDATE dbo.GARANTIAS_OPERACIONES
                           SET 
                                  Ind_Estado_Registro =      0
                    WHERE  Id_Operacion = @piId_Operacion

             --Eliminar Registro Preliminar    
--           IF @pbEstado_Registro_Operacion = 1
       --     BEGIN                                   
                    DELETE FROM GOP FROM dbo.GARANTIAS_OPERACIONES GOP
                    INNER JOIN dbo.OPERACIONES OPR
                    ON OPR.Id_Operacion = GOP.Id_Operacion
                    WHERE GOP.Id_Operacion = @piId_Operacion       
                    AND OPR.Estado_Registro_Operacion = 0

                    DELETE FROM dbo.OPERACIONES             
                    WHERE Id_Operacion = @piId_Operacion           
                    AND Estado_Registro_Operacion = 0
             --END

                    --Si no hubo error, se aplica la transacción
             COMMIT TRANSACTION TRA_Actualizar

             SELECT @poiId_Operacion        AS Estado, 
                  --@piId_Garantia_Real     AS Estado, 
                   -1                       AS NumeroError

       END TRY

       ----En caso de error, realiza lo siguiente
       BEGIN CATCH

             SELECT 0 AS Estado, 
                           ERROR_NUMBER() AS NumeroError
             ROLLBACK TRANSACTION TRA_Insertar

       END CATCH

END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[Operaciones_Actualiza_Generales] TO [RAP_AccesoSIGANEM]
    AS [dbo];
GO

