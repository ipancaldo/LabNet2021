using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using TP3_EM_Ex;
using Exceptions;

namespace TP3_EM_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroDividendo;
            Console.WriteLine("Ingrese el dividendo");

            // Se intenta hacer una división por 0
            try
            {
                numeroDividendo = int.Parse(Console.ReadLine());
                Exceptions.Exceptions.DivisionPorCero(numeroDividendo);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Debe ingresar un número");
                Console.WriteLine($"Error: '{ex.Message}'");
                Console.WriteLine("No se ha podido procesar la división.");
            }
            catch
            {
                Console.WriteLine("No se ha podido procesar la división.");
            }
            finally
            {
                Console.WriteLine("Operación finalizada.");
            }


            Console.WriteLine(Environment.NewLine);

            int dividendo, divisor;

            //División entre dos numeros
            try
            {
                Console.WriteLine("Ingrese dividendo");
                dividendo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese divisor");
                divisor = int.Parse(Console.ReadLine());

                Exceptions.Exceptions.Dividir(dividendo, divisor);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Seguro ingreso una letra o no ingreso nada!");
                Console.WriteLine($"Error: '{ex.Message}'");
                Console.WriteLine("No se ha podido procesar la división.");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Aflojale a la cantidad de números!");
                Console.WriteLine($"Valor superior al que admite integer. Error: '{ex.Message}'");
                Console.WriteLine("No se ha podido procesar la división.");
            }
            catch
            {
                Console.WriteLine("No se ha podido procesar la división.");
            }


            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("Ejecutando desde Logic");
            //Desde Logic
            try
            {
                Logic.Logic.CallException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Tipo de excepción: {ex.GetType()}");
            }


            Console.WriteLine(Environment.NewLine);


            //CustomException
            Console.WriteLine("Mensaje para el custom exception: ");
            string mensaje = Console.ReadLine();
            try
            {
                Logic.Logic.ThrowCustomException(mensaje);
            }
            catch (CustomException ex)
            {
                ex.Message(mensaje);
                Console.WriteLine($"Mensaje del Custom Exception: '{ex.Message}'");
                Console.WriteLine($"Tipo de excepción: {ex.GetType()}");
            }

            Console.ReadKey();
        }
    }
}
