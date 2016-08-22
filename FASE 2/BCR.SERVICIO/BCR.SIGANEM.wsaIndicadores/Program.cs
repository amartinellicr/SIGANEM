using System;
using System.Text;
using System.Linq;
using System.ServiceProcess;
using System.Collections.Generic;

namespace BCR.SIGANEM.wsaIndicadores
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new wsaIndicadoresServices() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
