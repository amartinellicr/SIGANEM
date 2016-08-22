using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

using BCR.SIGANEM.EN;


namespace BCR.SIGANEM.BL
{
    public interface IreportesNegocio
    {
        ReportesEntidad ReportesConsultarDetalle(String conexion, String conexionBitacora, ReportesEntidad entidad, BitacorasEntidad _bitacora);
    }
}
