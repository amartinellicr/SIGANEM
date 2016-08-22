using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

using BCR.SIGANEM.EN;


namespace BCR.SIGANEM.BL
{
    public interface ImensajesNegocio
    {
        MensajesEntidad MensajesConsulta(string conexion, MensajesEntidad entidad);
    }
}
