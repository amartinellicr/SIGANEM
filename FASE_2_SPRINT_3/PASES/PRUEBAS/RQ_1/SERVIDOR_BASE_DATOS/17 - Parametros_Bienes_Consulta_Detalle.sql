USE [USSIGANEM]
GO


ALTER PROCEDURE [dbo].[Parametros_Bienes_Consulta_Detalle]
( 
    @piId_Parametro_Bien	INT
)
AS 
/******************************************************************************************************************************************************
<Nombre>Parametros_Bienes_Consulta_Detalle</Nombre>
<Sistema>N.A.</Sistema>
<Descripción>Procedimiento almacenado que consulta la información del los parámetros</Descripción>
<Entradas>@piId_Parametro_Bien	= Llave de control interno </Entradas>
<Salidas></Salidas>
<Autor>Jéssica Alvarado C.</Autor>
<Fecha>Abril del 2014</Fecha>
<Requerimiento>1-24228291</Requerimiento>
<Versión>1.0</Versión>
<Historial>
	<Cambio>
		<Autor>Arnoldo Martinelli Marín</Autor>
		<Requerimiento>RQ_MANT_2016022310547690_Backlog_865</Requerimiento>
		<Fecha>07/07/2016</Fecha>
		<Descripción>Se agrega la obtención del valor del campo Meses_Prescripcion_Fideicomiso</Descripción>
	</Cambio>
    <Cambio>
		<Autor>Arnoldo Martinelli Marín</Autor>
		<Requerimiento></Requerimiento>
		<Fecha>07/04/2016</Fecha>
		<Descripción>
			Se comentan dos líneas que no son requeridas para le primer pase a producción, se debe valorar si para el segudo se requieren
		</Descripción>
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

	SELECT
		   PBS.[Id_Parametro_Bien]
		  ,PBS.[Meses_Prescripcion_Aeronave]
		  ,PBS.[Meses_Prescripcion_Alhaja]
		  ,PBS.[Meses_Prescripcion_Animal]
		  ,PBS.[Meses_Prescripcion_Bien]
		  ,PBS.[Meses_Prescripcion_Bono_Prenda]
		  ,PBS.[Meses_Prescripcion_Buque]
		  ,PBS.[Meses_Prescripcion_Cultivo_Fruto]
		  ,PBS.[Meses_Prescripcion_Edificacion]
		  ,PBS.[Meses_Prescripcion_Equipo_Computo]
		  ,PBS.[Meses_Prescripcion_Fianza]
		  ,PBS.[Meses_Prescripcion_Madera]
		  ,PBS.[Meses_Prescripcion_Maquinaria_Equipo]
		  ,PBS.[Meses_Prescripcion_Materia_Prima]
		  ,PBS.[Meses_Prescripcion_Mobiliario]
		  ,PBS.[Meses_Prescripcion_Otro_Tipo_Bien]
		  ,PBS.[Meses_Prescripcion_Terreno]
		  ,PBS.[Meses_Prescripcion_Valor]
		  ,PBS.[Meses_Prescripcion_Vehiculo]
		  ,PBS.[Meses_Vencimiento_Avaluo_Aeronave]
		  ,PBS.[Meses_Vencimiento_Avaluo_Alhaja]
		  ,PBS.[Meses_Vencimiento_Avaluo_Animal]
		  ,PBS.[Meses_Vencimiento_Avaluo_Buque]
		  ,PBS.[Meses_Vencimiento_Avaluo_Cultivo_Fruto]
		  ,PBS.[Meses_Vencimiento_Avaluo_Equipo_Computo]
		  ,PBS.[Meses_Vencimiento_Avaluo_Madera]
		  ,PBS.[Meses_Vencimiento_Avaluo_Maquinaria_Equipo]
		  ,PBS.[Meses_Vencimiento_Avaluo_Materia_Prima]
		  ,PBS.[Meses_Vencimiento_Avaluo_Mobiliario]
		  ,PBS.[Meses_Vencimiento_Avaluo_Otro_Tipo_Bien]
		  ,PBS.[Meses_Vencimiento_Avaluo_Vehiculo]
		  ,PBS.[Meses_Vencimiento_Avaluo_SUGEF_Edificacion]
		  ,PBS.[Meses_Vencimiento_Avaluo_SUGEF_Terreno]
		  ,PBS.Meses_Seguimiento_Terreno	
		  ,PBS.Meses_Seguimiento_Edificacion
		  ,PBS.Meses_Seguimiento_Vehiculo
		  ,PBS.Meses_Seguimiento_Maquinaria_Equipo
		  ,PBS.Meses_Seguimiento_Equipo_Computo
	      ,PBS.Meses_Seguimiento_Materia_Prima
		  ,PBS.Meses_Seguimiento_Mobiliario
		  ,PBS.Meses_Seguimiento_Maderas	
		  ,PBS.Meses_Seguimiento_Aeronave
		  ,PBS.Meses_Seguimiento_Buque
		  ,PBS.Meses_Seguimiento_Animal
		  ,PBS.Meses_Seguimiento_Cultivo_Fruto
		  ,PBS.Meses_Seguimiento_Alhaja
		  ,PBS.Meses_Seguimiento_Otros_Bienes
		  ,PBS.Meses_Prescripcion_Fideicomiso
		  /*SE COMENTAN ESTAS LINEAS PARA EL PRIMER PASE A PRODUCCIÓN, SE DEBE VERIFICAR SI PARA EL SEGUNDO DEBEN DE IR*/
		  --,PBS.Meses_Prescripcion_Factura_Cedida
		  ,PBS.Ind_Metodo_Insercion
		  ,PBS.Fecha_Ingreso
		  ,PBS.Cod_Usuario_Ingreso
		  ,PBS.Fecha_Ultima_Modificacion
		  ,PBS.Cod_Usuario_Ultima_Modificacion
		  ,USH.Nombre_Usuario Nombre_Usuario_Ingreso
		  ,US1.Nombre_Usuario Nombre_Usuario_Ultima_Modificacion
	FROM    dbo.PARAMETROS_BIENES	PBS
			INNER JOIN dbo.USUARIOS_HISTORICOS USH ON 
			USH.Cod_Usuario = PBS.Cod_Usuario_Ingreso
			LEFT JOIN dbo.USUARIOS_HISTORICOS US1 ON 
			US1.Cod_Usuario = PBS.Cod_Usuario_Ultima_Modificacion
	WHERE	Id_Parametro_Bien = @piId_Parametro_Bien

END 



