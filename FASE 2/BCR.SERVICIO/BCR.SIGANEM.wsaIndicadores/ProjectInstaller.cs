using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Configuration.Install;


namespace BCR.SIGANEM.wsaIndicadores
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            this.serviceInstaller1.DisplayName = wsaIndicadores.Properties.Settings.Default.NombreServicio;
            this.serviceInstaller1.ServiceName = wsaIndicadores.Properties.Settings.Default.NombreServicio;
        }
    }
}
