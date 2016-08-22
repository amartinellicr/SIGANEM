using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.EN;
using BCR.SIGANEM.UT;


namespace BCR.SIGANEM.BL
{
    public interface IbitacoraNegocio
    {
        //CAMBIO FGUEVARA
        int BitacoraRegistrar(string conexion, BitacorasEntidad bitacora);

    }
}
