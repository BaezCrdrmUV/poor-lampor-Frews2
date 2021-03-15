using System;
using System.Collections.Generic;
using System.Text;

namespace relojLamport.Recursos
{
    public class Mensaje
    {
        private HiloProcesador origen;
        private HiloProcesador destino;
        private int unidadTiempo;
        public string texto;

        public Mensaje()
        {
            UnidadTiempo = 0;
        }

        public HiloProcesador Origen 
        {
            get => origen;
            set => origen = value;
        }

        public HiloProcesador Destino 
        {
            get => destino;
            set => destino = value;
        }

        public int UnidadTiempo 
        {
            get => unidadTiempo;
            set => unidadTiempo = value;
        }
        public string Texto 
        {
            get => texto;
            set => texto = value;
        }
    }
}
