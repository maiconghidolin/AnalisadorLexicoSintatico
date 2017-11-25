
using System;

namespace Models {
    class TabelaLALR {

        public Simbolo[] simbolos;
        public int[] estados;
        public AcaoTabelaLALR[,] acoes;

        public Simbolo getSimboloPorIndice(int indice) {
            return Array.FindLast(this.simbolos, x => x != null && x.indice.Equals(indice));
        }

    }
}
