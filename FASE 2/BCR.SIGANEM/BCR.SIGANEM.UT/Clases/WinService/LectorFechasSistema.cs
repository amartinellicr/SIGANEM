﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;


namespace BCR.SIGANEM.UT
{
    /// <summary>
    /// LectorFechasSistema
    /// </summary>
    /// <Description>CLASE PARA LA OBTENCION DE FECHAS</Description>
    /// <Author>Francisco Guevara</Author>
    public class LectorFechasSistema
    {

        #region PROPIEDADES

        private DateTime fecha;
        private string culture = "es-ES";

        #endregion

        #region METODOS PUBLICOS

        /// <summary>
        /// ObtenerDiaAnterior
        /// </summary>
        /// <Description>OBTIENE EL DÍA ANTERIOR A LA FECHA ACTUAL</Description>
        /// <Author>Francisco Guevara</Author>
        public DateTime ObtenerDiaAnterior()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            return DateTime.Now.AddDays(-1);
        }

        /// <summary>
        /// ObtenerDiaActual
        /// </summary>
        /// <Description>OBTIENE EL DÍA ACTUAL</Description>
        /// <Author>Francisco Guevara</Author>
        public DateTime ObtenerDiaActual()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            return DateTime.Now;
        }

        /// <summary>
        /// ObtenerDiaposterior
        /// </summary>
        /// <Description>OBTIENE EL DÍA POSTERIOR A LA FECHA ACTUAL</Description>
        /// <Author>Francisco Guevara</Author>
        public DateTime ObtenerDiaposterior()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            return DateTime.Now.AddDays(1);
        }

        #region FECHA MES ACTUAL

        /// <summary>
        /// ObtenerPrimerDiaMesActual
        /// </summary>
        /// <Description>OBTIENE EL PRIMER DIA DEL MES ACTUAL</Description>
        /// <Author>Francisco Guevara</Author>
        public DateTime ObtenerPrimerDiaMesActual()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            return fecha;
        }

        /// <summary>
        /// ObtenerUltimoDiaMesActual
        /// </summary>
        /// <Description>OBTIENE EL ULTIMO DIA DEL MES ACTUAL</Description>
        /// <Author>Francisco Guevara</Author>
        public DateTime ObtenerUltimoDiaMesActual()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            return fecha;
        }

        #endregion

        #region FECHA MES ANTERIOR

        /// <summary>
        /// ObtenerPrimerDiaMesAnterior
        /// </summary>
        /// <Description>OBTIENE EL PRIMER DIA DEL MES ANTERIOR</Description>
        /// <Author>Francisco Guevara</Author>
        public DateTime ObtenerPrimerDiaMesAnterior()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);

            return fecha;
        }

        /// <summary>
        /// ObtenerUltimoDiaMesAnterior
        /// </summary>
        /// <Description>OBTIENE EL ULTIMO DIA DEL MES ANTERIOR</Description>
        /// <Author>Francisco Guevara</Author>
        public DateTime ObtenerUltimoDiaMesAnterior()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month -1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1));

            return fecha;
        }

        #endregion

        #endregion

    }
}
