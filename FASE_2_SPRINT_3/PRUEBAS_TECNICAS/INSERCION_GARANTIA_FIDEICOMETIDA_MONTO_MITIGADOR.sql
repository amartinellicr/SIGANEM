--ESCENARIO CP02

UPDATE dbo.GARANTIAS_REALES
SET Monto_Tasacion_Actualizada_Terreno = 100000000.00
WHERE Id_Garantia_Real = 2026

UPDATE dbo.GRAVAMENES
SET Saldo_Grado_Gravamen = 6800000.00,
	Saldo_Grado_Gravamen_Colonizado = 6800000.00
WHERE Id_Garantia_Real = 2026



--ESCENARIO CP04

UPDATE dbo.GARANTIAS_REALES
SET Monto_Tasacion_Actualizada_Terreno = 90000000.00,
	Monto_Valor_Total_Cedula = 90000000.00
WHERE Id_Garantia_Real = 3180

UPDATE dbo.GRAVAMENES
SET Saldo_Grado_Gravamen = 984000.00,
	Saldo_Grado_Gravamen_Colonizado = 984000.00
WHERE Id_Garantia_Real = 3180



--ESCENARIO CP06 / BCR04012016010	252525

UPDATE dbo.GARANTIAS_REALES
SET Monto_Tasacion_Actualizada_Terreno = 150000000.00,
	Monto_Tasacion_Actualizada_No_Terreno = 25000000.00
WHERE Id_Garantia_Real = 3193

UPDATE dbo.GRAVAMENES
SET Saldo_Grado_Gravamen = 3000000.00,
	Saldo_Grado_Gravamen_Colonizado = 3000000.00
WHERE Id_Garantia_Real = 3193


--ESCENARIO CP08 / BCR04012016022	584752	

UPDATE dbo.GARANTIAS_REALES
SET Monto_Valor_Total_Cedula = 10000000.00
WHERE Id_Garantia_Real = 5884

UPDATE dbo.GRAVAMENES
SET Saldo_Grado_Gravamen = 100000.00,
	Saldo_Grado_Gravamen_Colonizado = 100000.00
WHERE Id_Garantia_Real = 5884


--ESCENARIO CP10 / BCR04042016037	888867	

UPDATE dbo.GARANTIAS_REALES
SET Monto_Tasacion_Actualizada_No_Terreno = 55000000.00
WHERE Id_Garantia_Real = 2080

UPDATE dbo.GRAVAMENES
SET Saldo_Grado_Gravamen = 284960.00,
	Saldo_Grado_Gravamen_Colonizado = 284960.00
WHERE Id_Garantia_Real = 2080

UPDATE dbo.GARANTIAS_FIDEICOMETIDAS
SET Porcentaje_Aceptacion_No_Terreno_SUGEF = 65,
	Porcentaje_Aceptacion_Terreno_SUGEF = NULL
WHERE Id_Fideicomiso = 129
AND Id_Garantia_Real = 2080


--ESCENARIO CP12 / BCR04062016006	000436		

UPDATE dbo.GARANTIAS_REALES
SET Monto_Tasacion_Actualizada_No_Terreno = 75000000.00
WHERE Id_Garantia_Real = 3235

UPDATE dbo.GRAVAMENES
SET Saldo_Grado_Gravamen = 500000.00,
	Saldo_Grado_Gravamen_Colonizado = 500000.00
WHERE Id_Garantia_Real = 3235

UPDATE dbo.GARANTIAS_FIDEICOMETIDAS
SET Porcentaje_Aceptacion_No_Terreno_SUGEF = 65,
	Porcentaje_Aceptacion_Terreno_SUGEF = NULL
WHERE Id_Fideicomiso = 175
AND Id_Garantia_Real = 3235
