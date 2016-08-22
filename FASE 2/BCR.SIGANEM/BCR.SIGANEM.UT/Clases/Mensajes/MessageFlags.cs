using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.UT
{
    public static class MessageFlags
    {

        #region PROPIEDADES

        #region VARIABLES

        private static string _titleMessage;
        public static string TitleMessage
        {
            get { return _titleMessage; }
            set { _titleMessage = value; }
        }

        private static string _bodyMessage;
        public static string BodyMessage
        {
            get { return _bodyMessage; }
            set { _bodyMessage = value; }
        }

        #endregion

        #endregion

        #region METODOS PUBLICOS

        public static void ClearFlags()
        {
            TitleMessage = String.Empty;
            BodyMessage = String.Empty;
        }

        public static void SetFlags(string title, string body)
        {
            TitleMessage = title;
            BodyMessage = body;
        }

        #endregion

    }
}