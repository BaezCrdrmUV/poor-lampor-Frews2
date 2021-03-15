using System;
using System.Collections.Generic;
using System.Text;

namespace relojLamport.Recursos
{
    public class HiloProcesador
    {
        private int identificador;
        private int relojLogico;

        public HiloProcesador(int id)
        {
            this.identificador = id;
            RelojLogico = 0;

        }
        public int Identificador 
        {
            get => identificador;
            set => identificador = value;
        }

        public int RelojLogico 
        {
            get => relojLogico;
            set => relojLogico = value;
        }
    }
}
