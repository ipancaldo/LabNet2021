using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class ExtensionMethod
    {
        public static string Message(this Exception ex, string message)
        {
            Console.WriteLine($"Extension Method personalizado: {message}");
            return message;
        }
    }
}
