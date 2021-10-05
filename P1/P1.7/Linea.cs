using System;

namespace P1._7{
    class Linea{

        public Linea(Punto inicio, Punto final){
            this.Inicio = inicio;
            this.Final = final;
        }

        public Punto Inicio { get; }
        public Punto Final { get; }
        
        public override string ToString(){

            return string.Format("{0} - {1}", this.Inicio.ToString(), this.Final.ToString());

        }

    }
}