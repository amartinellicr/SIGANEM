using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Collections.Generic;


namespace BCR.SIGANEM.UT
{
    public class InfoClienteParser
    {

        #region METODOS PUBLICOS

        public string InformacionClienteXML(String xmlString)
        {
            StringBuilder output = new StringBuilder();

            #region CREAR XMLREADER
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                reader.ReadToFollowing("CLIENTE");
                while (reader.MoveToNextAttribute())
                {
                    switch (reader.Name)
                    {
                        case "tipo_identificacion":
                            output.AppendLine("Tipo Identificacion RUC: " + reader.Value);
                            break;
                        case "identificacion":
                            output.AppendLine("Identificacion RUC: " + reader.Value);
                            break;
                        case "nombre":
                            output.Append("Nombre del cliente RUC: " + reader.Value);
                            break;
                        case "apellido1":
                            output.Append(" " + reader.Value);
                            break;
                        case "apellido2":
                            output.AppendLine(" " + reader.Value);
                            break;
                        case "fecha_nacimiento":
                            output.AppendLine("Fecha Nacimiento RUC: " + DateTime.Parse(reader.Value).ToShortDateString());
                            break;
                        case "nacionalidad":
                            output.AppendLine("Nacionalidad: " + reader.Value);
                            break;
                    }
                }
                reader.ReadToFollowing("HOMOLOGACION");
                while (reader.MoveToNextAttribute())
                {
                    switch (reader.Name)
                    {
                        case "IDENTIFICACION_SICC":
                            output.AppendLine("Identificacion SICC: " + reader.Value);
                            break;
                    }
                }
            }
            #endregion

            //DEVUELVE EL RESULTADO DE LA CONSULTA
            return output.ToString();
        }

        #endregion

    }
}