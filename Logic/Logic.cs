using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace Logic
{
    public class Logic
    {

        /// <summary>
        /// Método que llama a una Exception por OverFlow
        /// </summary>
        public static Exception CallException()
        {
            Exception ex = Exceptions.Exceptions.ThrowException();
            return ex;
        }

        /// <summary>
        /// Método que llama a una Custom Exception
        /// </summary>
        /// <param name="mensaje"></param>
        public static void ThrowCustomException(string mensaje)
        {
            throw new CustomException(mensaje);
        }
    }
}
