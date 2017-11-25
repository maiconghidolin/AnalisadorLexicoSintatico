using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos {
    class ServicoAnalisadorSintatico {

        private TabelaLALR tabelaLALR;
        private List<Producao> producoes;
        private System.Xml.XmlDocument xmlTabela = new System.Xml.XmlDocument();

        public ServicoAnalisadorSintatico(string arquivoEntrada) {
            xmlTabela = new System.Xml.XmlDocument();
            xmlTabela.Load(arquivoEntrada);
            tabelaLALR = new TabelaLALR();
        }

        public void lerSimbolos() {
            // le os simbolos que o gold parser enumera
            System.Xml.XmlNodeList xmlNodeList = xmlTabela.GetElementsByTagName("Symbol");
            tabelaLALR.simbolos = new Simbolo[xmlNodeList.Count + 1];
            for (int i = 0; i < xmlNodeList.Count; i++) {
                Simbolo simbolo = new Simbolo();
                simbolo.indice = int.Parse(xmlNodeList[i].Attributes["Index"].Value);
                simbolo.nome = xmlNodeList[i].Attributes["Name"].Value;
                tabelaLALR.simbolos[i] = simbolo;
            }
        }

        public void lerProducoes() {
            // le as produções que o gold parser enumera
            // guarda tambem os símbolos de cada produção
            // usa na redução para saber o tamanho da produção e o simbolo que da nome a regra          
            producoes = new List<Producao>();
            System.Xml.XmlNodeList xmlNodeList = xmlTabela.GetElementsByTagName("Production");
            foreach (System.Xml.XmlNode n in xmlNodeList) {
                Producao producao = new Producao();
                producao.indice = Int32.Parse(n.Attributes["Index"].InnerText);
                producao.indiceNaoTerminal = int.Parse(n.Attributes["NonTerminalIndex"].InnerText);
                producao.simbolosProducao = new List<int>();
                foreach (System.Xml.XmlNode s in n.ChildNodes) {
                    producao.simbolosProducao.Add(int.Parse(s.Attributes["SymbolIndex"].InnerText));
                }
                producoes.Add(producao);
            }

        }

        public void lerTabelaLALR() {
            // le a tabela que o gold parser gera
            System.Xml.XmlNodeList xmlNodeList = xmlTabela.GetElementsByTagName("LALRState");

            tabelaLALR.estados = new int[xmlNodeList.Count];
            tabelaLALR.acoes = new AcaoTabelaLALR[tabelaLALR.estados.Count(), tabelaLALR.simbolos.Count() + 1];

            foreach (System.Xml.XmlNode nodoEstado in xmlNodeList) {
                int indiceEstado = int.Parse(nodoEstado.Attributes["Index"].InnerText);
                tabelaLALR.estados[indiceEstado] = indiceEstado;

                foreach (System.Xml.XmlNode nodoAcao in nodoEstado.ChildNodes) {
                    int indiceAcao = int.Parse(nodoAcao.Attributes["SymbolIndex"].InnerText);
                    AcaoTabelaLALR acao = new AcaoTabelaLALR();
                    Enum.TryParse(nodoAcao.Attributes["Action"].InnerText, out acao.acao);
                    acao.valor = int.Parse(nodoAcao.Attributes["Value"].InnerText);
                    tabelaLALR.acoes[indiceEstado, indiceAcao] = acao;
                }

            }
        }

        public List<string> analisar(List<TabelaSimbolos> tokens) {
            List<string> listaRetorno = new List<string>();

            List<int> fita = mapearFitaSaidaAnaliseSintatica(tokens);
            List<int> pilha = new List<int>();
            int indiceLeituraFita = 0;

            pilha.Add(tabelaLALR.estados[0]);

            while (true) {
                int estadoTopoPilha = pilha.Last();
                int tokenAtualFita = fita[indiceLeituraFita];

                AcaoTabelaLALR acaoTabela = tabelaLALR.acoes[estadoTopoPilha, tokenAtualFita];

                if (acaoTabela == null) {
                    if (indiceLeituraFita == tokens.Count) {
                        TabelaSimbolos token = tokens[indiceLeituraFita - 1];
                        listaRetorno.Add("Fim de arquivo inesperado. O token " + token.rotulo + ", na linha " + token.linha + " não um conclui uma expressão.");
                    } else {
                        TabelaSimbolos token = tokens[indiceLeituraFita];
                        listaRetorno.Add("Token " + token.rotulo + " inesperado na linha " + token.linha + ".");
                    }
                    break;
                } else if (acaoTabela.acao == Enumeradores.Acao.Aceitar) {
                    break;
                } else if (acaoTabela.acao == Enumeradores.Acao.Shift) {
                    pilha.Add(acaoTabela.valor);
                    indiceLeituraFita += 1;
                } else if (acaoTabela.acao == Enumeradores.Acao.Reduce) {
                    Producao producaoReducao = producoes[acaoTabela.valor];
                    if (producaoReducao != null) {
                        int tamanhoProducao = producaoReducao.simbolosProducao.Count();
                        pilha.RemoveRange(pilha.Count() - tamanhoProducao, tamanhoProducao);
                        pilha.Add(tabelaLALR.acoes[pilha.Last(), producaoReducao.indiceNaoTerminal].valor);
                    } else {
                        listaRetorno.Add("Produção de redução não encontrada.");
                        break;
                    }
                }

                if (indiceLeituraFita == fita.Count()) {
                    listaRetorno.Add("Fim da fita de análise... O código não foi reconhecido.");
                    break;
                }

            }

            return listaRetorno;
        }

        private List<int> mapearFitaSaidaAnaliseSintatica(List<TabelaSimbolos> tokens) {
            // a partir da fita de saida do analisador lexico
            // gera uma nova fita mapeada com os indices gerados pelo gold parser
            Simbolo simbolo;
            List<int> fita = new List<int>();
            foreach (TabelaSimbolos token in tokens) {
                simbolo = tabelaLALR.getSimboloPorIndice(token.getIndiceSimboloGoldParser);
                if (simbolo != null) {
                    fita.Add(simbolo.indice);
                }
            }
            simbolo = tabelaLALR.getSimboloPorIndice(0); // EOF
            fita.Add(simbolo.indice);
            return fita;
        }

    }
}
