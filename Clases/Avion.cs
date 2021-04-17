using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Avion : Transporte, ITipoVehiculo
    {     
        public Avion(int pasajeros) : base(pasajeros)
        {

        }

        public override void Avanzar(int tiempo)
        {
            //Hace 3kms por segundo
            base.KmsRecorridos += tiempo * 3;
        }

        public override int Detenerse()
        {
            return KmsRecorridos;
        }

        public string tipoDeVehiculo()
        {
            return "aereo";
        }
    }
}
