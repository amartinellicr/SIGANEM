using System;
using System.Text;
using System.Collections.Generic;

namespace BCR.SIGANEM.UT
{
    public enum EnumTipoMensaje
    {
        DeleteOK = 1,
        InsertOK = 2,
        UpdateOK = 3,

        DeleteErr = 4,        
        InsertErr = 5,
        UpdateErr = 6,

        PrimaryKey = 7,
        ForeignKey = 8,
        Caducado = 9,
        Inesperado = 10,

        Filtrado = 11
    }
}