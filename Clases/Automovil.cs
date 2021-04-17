using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Automovil : Transporte, ITipoVehiculo
    {
        public Automovil(int pasajeros) : base(pasajeros)
        {

        }

        public override void Avanzar(int kms)
        {
            //1 * km (supongamos que vamos a 100km/h)
            base.KmsRecorridos += kms;
        }

        public override int Detenerse()
        {
            return KmsRecorridos;
        }

        public string tipoDeVehiculo()
        {
            return "terrestre";
        }
    }
}