USE [SIGANEM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Garantias_Operaciones_Trama]
( 
    @piId_Garantia_Operacion INT, 
	@psCod_Accion VARCHAR(30),
	@psFecha_Prescripcion VARCHAR(10) = NULL
)
AS 
/******************************************************************************************************************************************************
<Nombre>Activos_Inserta</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento que retorna la trama para ser enviada a MQ</Descripción>
<Entradas>@piId_Garantia_Operacion = Id Garantia Operacion a replicar
          @psCod_Accion = Codigo del tipo de accion a realizar.
		  @psFecha_Prescripcion = Fecha Prescripcion
</Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado C.</Autor>
<Fecha>Octubre del 2013</Fecha>
<Requerimiento>1-23903815</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli Marín</Autor>
		<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
		<Fecha>21/06/2016</Fecha>
		<Descripción>Se agrega la lógica para la replica de garantías avales y garantías fideicomisos</Descripción>
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

	DECLARE @psCod_Trama VARCHAR(30)

	IF EXISTS (	SELECT	GOP.Id_Garantia_Operacion 
			FROM	GARANTIAS_OPERACIONES GOP
			WHERE	GOP.Id_Garantia_Operacion = @piId_Garantia_Operacion 
					AND GOP.Id_Garantia_Fiduciaria IS NOT NULL )
	BEGIN
		SET @psCod_Trama = 'PRT14'
	END
	ELSE IF EXISTS (	SELECT	GOP.Id_Garantia_Operacion 
					FROM	GARANTIAS_OPERACIONES GOP
					WHERE	GOP.Id_Garantia_Operacion = @piId_Garantia_Operacion 
							AND GOP.Id_Garantia_Valor IS NOT NULL )
	BEGIN
		SET @psCod_Trama = 'PRT15'
	END
	ELSE IF EXISTS (SELECT	GOP.Id_Garantia_Operacion 
					FROM	GARANTIAS_OPERACIONES GOP
							INNER JOIN GARANTIAS_REALES GR
							ON GOP.Id_Garantia_Real = GR.Id_Garantia_Real 
							INNER JOIN TIPOS_BIENES TB
							ON GR.Id_Tipo_Bien = TB.Id_Tipo_Bien 
							INNER JOIN CLASES_TIPOS_BIENES CTB
							ON GR.Id_Clase_Tipo_Bien = CTB.Id_Clase_Tipo_Bien
							AND TB.Id_Tipo_Bien = CTB.Id_Tipo_Bien  
					WHERE	GOP.Id_Garantia_Operacion = @piId_Garantia_Operacion 
							AND TB.Cod_Tipo_Bien = 3
							AND CTB.Cod_Clase_Tipo_Bien = 3 )
	BEGIN
		SET @psCod_Trama = 'PRT15'
	END
	ELSE IF EXISTS (SELECT	GOP.Id_Garantia_Operacion 
					FROM	GARANTIAS_OPERACIONES GOP
					WHERE	GOP.Id_Garantia_Operacion = @piId_Garantia_Operacion 
							AND GOP.Id_Fideicomiso IS NOT NULL )
	BEGIN
		SET @psCod_Trama = 'PRT15'
	END
	ELSE IF EXISTS (	SELECT	GOP.Id_Garantia_Operacion 
					FROM	GARANTIAS_OPERACIONES GOP
					WHERE	GOP.Id_Garantia_Operacion = @piId_Garantia_Operacion 
							AND GOP.Id_Garantia_Aval IS NOT NULL )
	BEGIN
		SET @psCod_Trama = 'PRT15'
	END
	ELSE
	BEGIN
		SET @psCod_Trama = 'PRT17'
	END

	SELECT	
		CASE TIPOP.Cod_Tipo_Operacion
			WHEN 1 THEN  /*OPERACION DE CREDITO*/
					CASE WHEN GAR_REL.Id_Fideicomiso IS NOT NULL
					THEN /*GARANTIAS FIDEICOMISOS*/
						CASE TRAMA.Cod_Trama 
							/*SOLUCION PALEATIVA PARA SOLVENTAR EL TEMA DE LA IDENTIFICACION DE LA GARANTIA*/
							WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-PROD@',OPERA.Prod),'@PNU-OPERA@',OPERA.Numero),'@PCO-CONT@',OPERA.Conta),'@PCO-OFIC@',OPERA.Oficina),'@PCO-MONE@',OPERA.Moneda),'@PNU-IDENT@', (dbo.Tramas_Obtener_Numericos(FIDEICOMISOS.Id_Fideicomiso_BCR) + '0') ),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
							/*SOLUCION NORMAL*/
							--WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-PROD@',OPERA.Prod),'@PNU-OPERA@',OPERA.Numero),'@PCO-CONT@',OPERA.Conta),'@PCO-OFIC@',OPERA.Oficina),'@PCO-MONE@',OPERA.Moneda),'@PNU-IDENT@', dbo.Tramas_Obtener_Numericos(FIDEICOMISOS.Id_Fideicomiso_BCR) ),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
						END
					WHEN GAR_REL.Id_Garantia_Aval IS NOT NULL
					THEN /*GARANTIAS AVALES*/
						CASE TRAMA.Cod_Trama 
							WHEN 'PRT15' THEN
							/*SOLUCION PALEATIVA PARA SOLVENTAR EL TEMA DE LA IDENTIFICACION DE LA GARANTIA*/
							CASE 
								WHEN LEN(dbo.Tramas_Obtener_Numericos(AVALES.Numero_Aval)) = 11 THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-PROD@',OPERA.Prod),'@PNU-OPERA@',OPERA.Numero),'@PCO-CONT@',OPERA.Conta),'@PCO-OFIC@',OPERA.Oficina),'@PCO-MONE@',OPERA.Moneda),'@PNU-IDENT@', dbo.Tramas_Obtener_Numericos(AVALES.Numero_Aval) + '0'),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
								ELSE REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-PROD@',OPERA.Prod),'@PNU-OPERA@',OPERA.Numero),'@PCO-CONT@',OPERA.Conta),'@PCO-OFIC@',OPERA.Oficina),'@PCO-MONE@',OPERA.Moneda),'@PNU-IDENT@', dbo.Tramas_Obtener_Numericos(AVALES.Numero_Aval) ),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
							END
							/*SOLUCION NORMAL*/
							--WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-PROD@',OPERA.Prod),'@PNU-OPERA@',OPERA.Numero),'@PCO-CONT@',OPERA.Conta),'@PCO-OFIC@',OPERA.Oficina),'@PCO-MONE@',OPERA.Moneda),'@PNU-IDENT@', dbo.Tramas_Obtener_Numericos(AVALES.Numero_Aval) ),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
						END
					WHEN GAR_REL.Id_Garantia_Real IS NULL AND ((GAR_REL.Id_Garantia_Fiduciaria IS NOT NULL) OR (GAR_REL.Id_Garantia_Valor IS NOT NULL))
					THEN /*GARANTIAS VALORES Y FIDUCIARIAS*/
						CASE TRAMA.Cod_Trama 
							WHEN 'PRT14' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-PROD@',OPERA.Prod),'@PNU-OPERA@',OPERA.Numero),'@PCO-CONT@',OPERA.Conta),'@PCO-OFIC@',OPERA.Oficina),'@PCO-MONE@',OPERA.Moneda),'@PNU-IDENT@',FIDUCIARIAS.Identificacion_SICC)
							WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-PROD@',OPERA.Prod),'@PNU-OPERA@',OPERA.Numero),'@PCO-CONT@',OPERA.Conta),'@PCO-OFIC@',OPERA.Oficina),'@PCO-MONE@',OPERA.Moneda),'@PNU-IDENT@', dbo.Tramas_Obtener_Numericos(VALORES.Cod_Garantia_BCR) ),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
						END
					ELSE /*GARANTIAS REALES*/
						CASE TRAMA.Cod_Trama
							WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-PROD@',OPERA.Prod),'@PNU-OPERA@',OPERA.Numero),'@PCO-CONT@',OPERA.Conta),'@PCO-OFIC@',OPERA.Oficina),'@PCO-MONE@',OPERA.Moneda),'@PNU-IDENT@', dbo.Tramas_Obtener_Numericos(REALES.Codigo_Bien) ),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
							WHEN 'PRT17' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-CONT@',OPERA.Conta),'@PCO-OFIC@',OPERA.Oficina),'@PCO-MONE@',OPERA.Moneda),'@PNU-OPERA@',OPERA.Numero),'@PNU-IDENT@', CASE PRT17.Cod_Clase_Garantia_Prt_17 WHEN '41' THEN REALES.Codigo_Bien ELSE dbo.Tramas_Obtener_Numericos(REALES.Codigo_Bien) END  ),'@PCO-PROD@',OPERA.Prod),'@PMOAVAING@', REPLACE(REPLACE(CONVERT(VARCHAR,ISNULL(REALES.Monto_Ultima_Tasacion_No_Terreno,0) + ISNULL(REALES.Monto_Ultima_Tasacion_Terreno,0)),'.',''),',','') ),'@PFEAVAING@',ISNULL(REPLACE(CONVERT(VARCHAR,REALES.Fecha_Ultima_Tasacion_Garantia,103),'/',''),'')),'@PCOLIQGAR@',LIQUIDEZ.Cod_Tipo_Liquidez),'@PCOTIPGAR@',ISNULL(PRT17.Cod_Clase_Garantia_Prt_17,'')),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',','')),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PCO-TENEN@',T_PRT17.Cod_Tenencia_PRT_17),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PSE-PERITO@',CASE GAR_REL.Ind_Recomendacion_Perito WHEN 0 THEN '2' ELSE '1' END),'@PSE-INSPEC@', CASE GAR_REL.Ind_Inspeccion_Garantia WHEN 0 THEN '2' ELSE '1' END),'@PNU-PARTI@',ISNULL(CONVERT(VARCHAR,P.Cod_Provincia),ISNULL(CONVERT(VARCHAR,PART.Cod_Provincia),'') ))
						END
					END
			WHEN 2 THEN /*CONTRATO DE CREDITO*/
					CASE WHEN GAR_REL.Id_Fideicomiso IS NOT NULL
					THEN /*GARANTIAS FIDEICOMISOS*/
						CASE TRAMA.Cod_Trama 
							/*SOLUCION PALEATIVA PARA SOLVENTAR EL TEMA DE LA IDENTIFICACION DE LA GARANTIA*/
							WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-CON@',OPERA.Conta),'@PCO-OFI@',OPERA.Oficina),'@PCO-MON@',OPERA.Moneda),'@PNU-IDENT@', (dbo.Tramas_Obtener_Numericos(FIDEICOMISOS.Id_Fideicomiso_BCR) + '0')),'@PNU-CONT@',OPERA.Numero),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
							/*SOLUCION NORMAL*/
							--WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-CON@',OPERA.Conta),'@PCO-OFI@',OPERA.Oficina),'@PCO-MON@',OPERA.Moneda),'@PNU-IDENT@',dbo.Tramas_Obtener_Numericos(FIDEICOMISOS.Id_Fideicomiso_BCR)),'@PNU-CONT@',OPERA.Numero),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
						END
					WHEN GAR_REL.Id_Garantia_Aval IS NOT NULL
					THEN /*GARANTIAS AVALES*/
						CASE TRAMA.Cod_Trama 
							WHEN 'PRT15' THEN
								/*SOLUCION PALEATIVA PARA SOLVENTAR EL TEMA DE LA IDENTIFICACION DE LA GARANTIA*/
								CASE 
									WHEN LEN(dbo.Tramas_Obtener_Numericos(AVALES.Numero_Aval)) = 11 THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-CON@',OPERA.Conta),'@PCO-OFI@',OPERA.Oficina),'@PCO-MON@',OPERA.Moneda),'@PNU-IDENT@',dbo.Tramas_Obtener_Numericos(AVALES.Numero_Aval) + '0'),'@PNU-CONT@',OPERA.Numero),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
									ELSE REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-CON@',OPERA.Conta),'@PCO-OFI@',OPERA.Oficina),'@PCO-MON@',OPERA.Moneda),'@PNU-IDENT@',dbo.Tramas_Obtener_Numericos(AVALES.Numero_Aval)),'@PNU-CONT@',OPERA.Numero),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
								END
								/*SOLUCION NORMAL*/
								--WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-CON@',OPERA.Conta),'@PCO-OFI@',OPERA.Oficina),'@PCO-MON@',OPERA.Moneda),'@PNU-IDENT@',dbo.Tramas_Obtener_Numericos(AVALES.Numero_Aval)),'@PNU-CONT@',OPERA.Numero),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
							END							
					WHEN GAR_REL.Id_Garantia_Real IS NULL AND ((GAR_REL.Id_Garantia_Fiduciaria IS NOT NULL) OR (GAR_REL.Id_Garantia_Valor IS NOT NULL))
					THEN /*GARANTIAS VALORES Y FIDUCIARIAS*/
						CASE TRAMA.Cod_Trama 
							WHEN 'PRT14' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-CON@',OPERA.Conta),'@PCO-OFI@',OPERA.Oficina),'@PCO-MON@',OPERA.Moneda),'@PNU-IDENT@',FIDUCIARIAS.Identificacion_SICC),'@PNU-CONT@',OPERA.Numero)
							WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-CON@',OPERA.Conta),'@PCO-OFI@',OPERA.Oficina),'@PCO-MON@',OPERA.Moneda),'@PNU-IDENT@',dbo.Tramas_Obtener_Numericos(VALORES.Cod_Garantia_BCR)),'@PNU-CONT@',OPERA.Numero),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
						END
					ELSE /*GARANTIAS REALES*/
						CASE TRAMA.Cod_Trama
							WHEN 'PRT15' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PNU-CONT@',OPERA.Numero),'@PCO-CON@',OPERA.Conta),'@PCO-OFI@',OPERA.Oficina),'@PCO-MON@',OPERA.Moneda),'@PNU-IDENT@', dbo.Tramas_Obtener_Numericos(REALES.Codigo_Bien) ),'@PCOTIPGAR@',PRT17.Cod_Clase_Garantia_Prt_17),'@PCO-TENEN@',PRT15.Cod_Tenencia_PRT_15),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',',''))
							WHEN 'PRT17' THEN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(TRAMA.Trama,'@PCO-CON@',OPERA.Conta),'@PCO-OFI@',OPERA.Oficina) ,'@PCO-MON@',OPERA.Moneda),'@PNU-CONT@',OPERA.Numero),'@PNU-IDENT@', CASE PRT17.Cod_Clase_Garantia_Prt_17 WHEN '41' THEN REALES.Codigo_Bien ELSE dbo.Tramas_Obtener_Numericos(REALES.Codigo_Bien) END ),'@PMOAVAING@', REPLACE(REPLACE(CONVERT(VARCHAR,ISNULL(REALES.Monto_Ultima_Tasacion_No_Terreno,0) + ISNULL(REALES.Monto_Ultima_Tasacion_Terreno,0)),'.',''),',','') ),'@PFEAVAING@',ISNULL(REPLACE(CONVERT(VARCHAR,REALES.Fecha_Ultima_Tasacion_Garantia,103),'/',''),'')),'@PCOLIQGAR@',LIQUIDEZ.Cod_Tipo_Liquidez),'@PCOTIPGAR@',ISNULL(PRT17.Cod_Clase_Garantia_Prt_17,'')),'@PMO-RESPON@',REPLACE(REPLACE(CONVERT(VARCHAR,GAR_REL.Monto_Grado_Gravamen),'.',''),',','')),'@PCO-MONGAR@',CONVERT(VARCHAR,MON.Cod_Moneda)),'@PCO-TENEN@',T_PRT17.Cod_Tenencia_PRT_17),'@PCO-GRAVA@',CONVERT(INT,GRADOS.Cod_Grado_Gravamen)),'@PFEPREGAR@',ISNULL(@psFecha_Prescripcion,'') ),'@PSE-PERITO@',CASE GAR_REL.Ind_Recomendacion_Perito WHEN 0 THEN '2' ELSE '1' END),'@PSE-INSPEC@', CASE GAR_REL.Ind_Inspeccion_Garantia WHEN 0 THEN '2' ELSE '1' END),'@PNU-PARTI@', ISNULL(CONVERT(VARCHAR,P.Cod_Provincia),ISNULL(CONVERT(VARCHAR,PART.Cod_Provincia),'') ))
						END
					END
			END AS Valor
	FROM	TRAMAS TRAMA
			LEFT JOIN GARANTIAS_OPERACIONES GAR_REL
			ON 1 = 1
			INNER JOIN TIPOS_GARANTIAS TIPO_GAR
			ON GAR_REL.Id_Tipo_Garantia = TIPO_GAR.Id_Tipo_Garantia 
			INNER JOIN OPERACIONES OPERA
			ON GAR_REL.Id_Operacion = OPERA.Id_Operacion 
			INNER JOIN TIPOS_OPERACIONES TIPOP
			ON OPERA.Id_Tipo_Operacion = TIPOP.Id_Tipo_Operacion
			LEFT JOIN GARANTIAS_VALORES VALORES
			ON GAR_REL.Id_Garantia_Valor = VALORES.Id_Garantia_Valor 
			LEFT JOIN GARANTIAS_REALES REALES
			ON GAR_REL.Id_Garantia_Real = REALES.Id_Garantia_Real 
			LEFT JOIN GARANTIAS_FIDUCIARIAS FIDUCIARIAS
			ON GAR_REL.Id_Garantia_Fiduciaria = FIDUCIARIAS.Id_Garantia_Fiduciaria 
			LEFT JOIN GARANTIAS_AVALES AVALES
			ON GAR_REL.Id_Garantia_Aval = AVALES.Id_Garantia_Aval 
			LEFT JOIN FIDEICOMISOS FIDEICOMISOS
			ON GAR_REL.Id_Fideicomiso = FIDEICOMISOS.Id_Fideicomiso 
			LEFT JOIN CLASES_GARANTIAS_PRT_17 PRT17
			ON GAR_REL.Id_Clase_Garantia_PRT17 = PRT17.Id_Clase_Garantia_Prt_17  
			LEFT JOIN TENENCIAS_PRT_15 PRT15
			ON GAR_REL.Id_Tenencia_PRT_15 = PRT15.Id_Tenencia_PRT_15 
			LEFT JOIN TENENCIAS_PRT_17 T_PRT17
			ON GAR_REL.Id_Tenencia_PRT_17 = T_PRT17.Id_Tenencia_PRT_17
			LEFT JOIN GRADOS_GRAVAMENES GRADOS
			ON GAR_REL.Id_Grado_Gravamen = GRADOS.Id_Grado_Gravamen
			LEFT JOIN MONEDAS MON
			ON GAR_REL.Id_Tipo_Moneda_Monto_Gravamen = MON.Id_Moneda
			LEFT JOIN TIPOS_LIQUIDEZ LIQUIDEZ
			ON REALES.Id_Tipo_Liquidez = LIQUIDEZ.Id_Tipo_Liquidez 
			LEFT JOIN PROVINCIAS P
			ON REALES.Id_Provincia = P.Id_Provincia 
			LEFT JOIN PROVINCIAS PART
			ON GAR_REL.Partido = PART.Id_Provincia 
	WHERE	GAR_REL.Id_Garantia_Operacion = @piId_Garantia_Operacion
			AND TRAMA.Cod_Accion = @psCod_Accion 
			AND TRAMA.Cod_Trama = @psCod_Trama 		
			AND OPERA.Id_Tipo_Operacion = TRAMA.Id_Tipo_Operacion 
			AND TIPO_GAR.Id_Tipo_Garantia = TRAMA.Id_Tipo_Garantia

END


