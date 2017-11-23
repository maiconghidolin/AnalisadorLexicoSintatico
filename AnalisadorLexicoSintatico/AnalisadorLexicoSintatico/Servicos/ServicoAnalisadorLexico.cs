using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos {
    class ServicoAnalisadorLexico {

        private List<string> _listaEntrada = new List<string>();

        private void lerArquivo(string arquivoEntrada) {
            System.IO.StreamReader sr = new System.IO.StreamReader(arquivoEntrada);
            while (!sr.EndOfStream) {
                string linha = sr.ReadLine();
                if (!string.IsNullOrEmpty(linha)) {
                    _listaEntrada.Add(linha);
                }
            }
            sr.Close();
            sr.Dispose();
        }

        public void analisar(string arquivoEntrada, AutomatoFinito automatoFinito, ref List<TabelaSimbolos> tokensReconhecidos, ref List<string> erros) {
            lerArquivo(arquivoEntrada);
            string textoLinha;
            for (int numeroLinha = 0; numeroLinha < _listaEntrada.Count; numeroLinha++) {
                // passa cada linha
                textoLinha = _listaEntrada[numeroLinha];
                textoLinha = textoLinha.Replace(System.Environment.NewLine, " "); // remove quebra de linha e poe espaço
                List<string> matches = new List<string>();
                // insere espaço antes dos operadores para separar
                foreach (System.Text.RegularExpressions.Match m in Utilidades.expressaoOperadores.Matches(textoLinha)) {
                    if (matches.Contains(m.Value)) continue;
                    matches.Insert(0, m.Value);
                    textoLinha = textoLinha.Replace(matches[0], " " + matches[0] + " ");
                }
                _listaEntrada[numeroLinha] = Utilidades.expressaoEspacosDuplos.Replace(textoLinha, " ").Trim(); // remove espaços duplos
                string[] tokens = _listaEntrada[numeroLinha].Split(' '); // separa cada token pelo separador
                foreach (var token in tokens) {
                    // passa cada token da linha
                    Estado estadoAtual = automatoFinito.estados[0]; // estado inicial
                    for (int i = 0; i < token.Length; i++) {
                        // passa cada caractere do token
                        // verifica se tem uma transição para esse caractere/simbolo
                        // como ta determinizado, só tem uma ou nenhuma trasição por esse caractere/simbolo
                        Transicao transicaoSimbolo = (estadoAtual.transicoes.Where(x => x.simbolo.Equals(token[i]))).FirstOrDefault();
                        if (transicaoSimbolo == null) {
                            // não encontrou transição, leva o índice para a última posição
                            i = token.Length - 1;
                        } else {
                            estadoAtual = transicaoSimbolo.estadoDestino;
                        }

                        if (i == token.Length - 1) { // encontrou um separador
                            if (!estadoAtual.final || transicaoSimbolo == null) {
                                // erro
                                erros.Add("Linha " + (numeroLinha + 1) + ": a sequência de símbolos " + token + " não é reconhecida como sentença...");
                            } else {
                                // token reconhecido
                                tokensReconhecidos.Add(new TabelaSimbolos(tokensReconhecidos.Count(), token, estadoAtual, numeroLinha + 1));
                            }
                        }
                    }
                }
            }
        }

    }
}
