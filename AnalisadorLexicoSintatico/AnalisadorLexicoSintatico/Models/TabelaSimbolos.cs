
namespace Models {
    class TabelaSimbolos {

        public int identificador;
        public string rotulo;
        public Estado estadoReconhecedor;
        public int linha;

        public TabelaSimbolos(int identificador, string rotulo, Estado estadoReconhecedor, int linha) {
            this.identificador = identificador;
            this.rotulo = rotulo;
            this.estadoReconhecedor = estadoReconhecedor;
            this.linha = linha;
        }

        public int getIndiceSimboloGoldParser {
            get {
                switch (estadoReconhecedor.label) {
                    case "1": // identificador
                        return 20;
                    case "2": // numero
                        return 21;
                    case "3": // +
                        return 9;
                    case "4": // -
                        return 3;
                    case "5": // *
                        return 6;
                    case "6": // /
                        return 7;
                    case "7": // =
                        return 11;
                    case "8": // &
                        return 5;
                    case "9": // ¬
                        return 13;
                    case "10": // %
                        return 4;
                    case "11": // <
                        return 10;
                    case "12": // >
                        return 12;
                    case "13": // :
                        return 8;
                    case "14": // V
                        return 25;
                    case "15": // F
                        return 17;
                    case "17,24": // se
                        return 23;
                    case "22": // entao
                        return 16;
                    case "27": // senao
                        return 24;
                    case "30": // fim
                        return 19;
                    case "32": // de
                        return 14;
                    case "36": // para
                        return 22;
                    case "41": // fazer
                        return 18;
                    case "49": // enquanto
                        return 15;
                    default:
                        return -1;
                }
            
            }
        }

    }
}
