using AspProjekat2024.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void Log(Exception exception)
        {
            Console.WriteLine("An error occurred: "+ DateTime.UtcNow);
            Console.WriteLine(exception.Message);
        }
    }
}
