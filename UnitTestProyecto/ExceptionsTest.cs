using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Exceptions;
using Logic;

namespace UnitTestProyecto
{
    [TestClass]
    public class ExceptionsTest
    {
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionPorCero_PassAnyDividend_GetDivideByZeroException()
        {
            //Da igual cual sea el dividendo, el divisor es 0
            int numeroDividendo = 4;
            int result = Exceptions.Exceptions.DivisionPorCero(numeroDividendo);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Dividir_PassDividend2Divisor2_GetResult()
        {
            int dividendo = 2;
            int divisor = 2;
            int division = Exceptions.Exceptions.Dividir(dividendo, divisor);

            Assert.AreEqual(1, division);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Dividir_PassDividend2Divisor0_GetExceptionByZero()
        {
            int dividendo = 2;
            int divisor = 0;
            int division = Exceptions.Exceptions.Dividir(dividendo, divisor);

            Assert.AreEqual(1, division);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Dividir_PassALargeNumber_GetExceptionByOverflow()
        {
            int division = 0;
            checked
            {
                int dividendo = int.MaxValue;
                dividendo += 100;
                int divisor = 20;
                division = Exceptions.Exceptions.Dividir(dividendo, divisor);
            }
            Assert.AreEqual(1, division);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void ThrowException_RunMethod_GetExceptionByOverflow()
        {
            Exception ex = Exceptions.Exceptions.ThrowException();

            //Assert.IsNotNull(ex);
            Assert.AreEqual(ex, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void CallException_RunMethod_GetExceptionByOverflow()
        {
            Exception ex = Logic.Logic.CallException();

            Assert.AreEqual(ex, 1);
        }
    }
}
