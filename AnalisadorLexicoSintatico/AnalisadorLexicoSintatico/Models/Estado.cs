
using System.Collections.Generic;

namespace Models {
    class Estado {

        public string label;
        public bool final;
        public List<Transicao> transicoes;

        public Estado(string label, bool final) {
            this.label = label;
            this.final = final;
            this.transicoes = new List<Transicao>();
        }

    }
}
