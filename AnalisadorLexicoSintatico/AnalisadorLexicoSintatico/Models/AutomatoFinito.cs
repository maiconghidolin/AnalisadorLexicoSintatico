using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Models {
    class AutomatoFinito {

        public List<Estado> estados;
        public List<char> alfabeto;

        public AutomatoFinito() {
            estados = new List<Estado>();
            alfabeto = new List<char>();
        }

        public void ordenaAlfabeto() {
            alfabeto.Sort(
              delegate (char x, char y) {
                  return x.CompareTo(y);
              }
            );
        }

        public string criaListaSaida() {
            StringBuilder saida = new StringBuilder();
            foreach (var estado in estados) {
                saida.AppendLine("Estado " + (estado.final ? "*" : "") + estado.label);
                List<Estado> estadosDistintos = estado.transicoes.Select(x => x.estadoDestino).Distinct().ToList(); ;
                foreach (var destino in estadosDistintos) {
                    saida.AppendLine("\t" + string.Join(",", estado.transicoes.Where(x => x.estadoDestino.label.Equals(destino.label)).Select(x => x.simbolo)) +
                        " vai para " + destino.label);
                }
                saida.Append("\n");
            }
            return saida.ToString();
        }

    }
}
