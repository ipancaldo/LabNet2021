using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public interface ITipoVehiculo
    {
        //Para sabe si es volador o terrestre
        string tipoDeVehiculo();
    }

    public abstract class Transporte //Clase abstracta que no será instanciable
    {
        private int pasajeros;
        private int kmsRecorridos = 0;

        public Transporte(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }

        public int Pasajeros
        {
            get { return this.pasajeros; }
            set { this.pasajeros = value; }
        }

        public int KmsRecorridos
        {
            get { return this.kmsRecorridos; }
            set { this.kmsRecorridos = value; }
        }

        public abstract void Avanzar(int avanzar);
        public abstract int Detenerse();

        private void Privado()
        {
            Console.WriteLine("Soy una clase privada!!");
        }
    }
}
