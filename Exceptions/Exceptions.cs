using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class Exceptions
    {
        /// <summary>
        /// Método que dispara una excepción al dividir por cero
        /// </summary>
        public static int DivisionPorCero(int numeroDividendo)
        {
            //Se deja esta variable para que sea más facil realizar las pruebas
            int numeroDivisor = 0;
            int resultado = 0;
            try
            {
                resultado = numeroDividendo / numeroDivisor;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Cero no puede ser un divisor. Error: '{ex.Message}'");
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se puede realizar el proceso");
                throw ex;
            }

            Console.WriteLine($"División exitosa. Resultado: {numeroDividendo / numeroDivisor}");
            return resultado;
        }

        /// <summary>
        /// Método que permite la división entre dos números
        /// </summary>
        /// <param name="dividendo"></param>
        /// <param name="divisor"></param>
        public static int Dividir(int dividendo, int divisor)
        {
            int resultado = 0;
            try
            {
                resultado = dividendo / divisor;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Sólo Chuck Norris divide por cero! Y por la débil presión que ejerces sobre las teclas, no lo eres.");
                Console.WriteLine($"Para vos esta división terminó en ERROR '{ex.Message}'");
                throw ex;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Aflojale a la cantidad de números!");
                Console.WriteLine($"ERROR: '{ex.Message}'");
                throw ex;
            }

            Console.WriteLine($"División exitosa. Resultado: {resultado}");
            return resultado;
        }

        /// <summary>
        /// Arroja una Exception por OverFlow
        /// </summary>
        public static Exception ThrowException()
        {
            Exception e = null;
            try
            {
                //No deja que C# permita el OverFlow asignando un valor random
                checked
                {
                    int numero = int.MaxValue;
                    numero += 20;
                }
            }
            catch (OverflowException ex)
            {
                //Console.WriteLine("Integer desbordado");
                //Console.WriteLine($"ERROR: '{ex.Message}'");
                //Para el unit test
                e = ex;
                throw ex;
            }

            return e;
        }
    }
}
