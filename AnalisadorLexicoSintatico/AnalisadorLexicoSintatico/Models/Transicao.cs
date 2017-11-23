
namespace Models {
    class Transicao {

        public char simbolo;
        public Estado estadoDestino;

        public Transicao(char simbolo, Estado estadoDestino) {
            this.simbolo = simbolo;
            this.estadoDestino = estadoDestino;
        }

    }
}
