using System;
using CSharpTestProject.Domain.IServices;

namespace CSharpTestProject.Services.Services
{
    public class PrintService : IPrintService
    {
        public void PrintInitialMessage()
        {
            string banner = @" _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ 
|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|
|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|
                                                                               
                                                                               
             _       _     __                                _   _             
  /\  /\___ | |_ ___| |   /__\ ___  ___  ___ _ ____   ____ _| |_(_) ___  _ __  
 / /_/ / _ \| __/ _ \ |  / \/// _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \ 
/ __  / (_) | ||  __/ | / _  \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | |
\/ /_/ \___/ \__\___|_| \/ \_/\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|
                                                                               
     by ThoughtWorks                                                                          
 _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ 
|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|
|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|

    ";

            Console.WriteLine(banner);

            Console.WriteLine("Digite 'Enter' para continuar:");
            Console.ReadKey();
            Console.WriteLine("Digite os dados para reserva no seguinte formato: <tipo_do_cliente>: <data1>, <data2>, <data3>, …");
            Console.WriteLine();
            Console.WriteLine("Exemplo: Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)");
            Console.WriteLine();
        }
    }
}
