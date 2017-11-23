using System;
using System.Collections.Generic;


namespace Models {
    public class Producao {

        public int indice;
        public int indiceNaoTerminal;
        public List<int> simbolosProducao;

        public override string ToString() {
            return String.Format("Produção: {0}, NT: {1}, Produções: {2}", indice.ToString(), indiceNaoTerminal, String.Join(" ", simbolosProducao));
        }

    }
}
