using Servicos;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Views {
    public partial class ViewMain : Form {

        public ViewMain() {
            InitializeComponent();
        }

        private void ViewMain_FormClosing(object sender, FormClosingEventArgs e) {
            Environment.Exit(0);
        }

        private void txtArquivoGramatica_Click(object sender, EventArgs e) {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtArquivoGramatica.Text = openFileDialog.FileName;
        }

        private void txtArquivoSaida_Click(object sender, EventArgs e) {
            saveFileDialogSaida.Filter = "Arquivo de texto|*.txt";
            if (saveFileDialogSaida.ShowDialog() == DialogResult.OK)
                txtArquivoSaida.Text = saveFileDialogSaida.FileName;
        }

        private void txtArquivoCodigoFonte_Click(object sender, EventArgs e) {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtArquivoCodigoFonte.Text = openFileDialog.FileName;
        }

        private void txtArquivoGoldParser_Click(object sender, EventArgs e) {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtArquivoGoldParser.Text = openFileDialog.FileName;
        }

        private void btnExecutar_Click(object sender, EventArgs e) {
            if (txtArquivoGramatica.Text.Trim() == "" || txtArquivoSaida.Text.Trim() == "" || txtArquivoCodigoFonte.Text.Trim() == "" || txtArquivoGoldParser.Text.Trim() == "") {
                MessageBox.Show("Selecione o arquivo de entrada, código fonte, saída e resultado do gold parser.");
                return;
            }
            CheckForIllegalCrossThreadCalls = false;
            System.Threading.Thread processo = new System.Threading.Thread(threadProcessos);
            processo.Start();
        }

        private void threadProcessos() {
            System.IO.StreamWriter streamWriterSaida = new System.IO.StreamWriter(txtArquivoSaida.Text, false, Encoding.UTF8);

            ServicoGeracaoAutomatoFinito servicoGeracaoAF = new ServicoGeracaoAutomatoFinito();
            AutomatoFinito automatoFinito = servicoGeracaoAF.gerarAutomatoFinitoInicial(txtArquivoGramatica.Text);
            automatoFinito = servicoGeracaoAF.determinizarAutomato(automatoFinito);
            servicoGeracaoAF.removerMortos(automatoFinito);

            streamWriterSaida.WriteLine("Autômato finito gerado.");
            streamWriterSaida.WriteLine(automatoFinito.criaListaSaida());

            ServicoAnalisadorLexico servicoAnalisadorLexico = new ServicoAnalisadorLexico();
            List<TabelaSimbolos> tokensLidos = new List<TabelaSimbolos>();
            List<string> erros = new List<string>();
            servicoAnalisadorLexico.analisar(txtArquivoCodigoFonte.Text, automatoFinito, ref tokensLidos, ref erros);

            streamWriterSaida.WriteLine("Tokens Lidos:\r\n" + String.Join(Environment.NewLine, tokensLidos.Select(token => String.Format("id: {0}, estado: {1}, rotulo: {2}, linha {3}", token.identificador, token.estadoReconhecedor.label, token.rotulo, token.linha))));

            streamWriterSaida.WriteLine("Erros:\r\n" + (erros == null || erros.Count == 0 ? "Nenhum." : String.Join(Environment.NewLine, erros)));

            streamWriterSaida.WriteLine("Análise léxica concluída...\n");

            if(erros != null && erros.Count > 0) {
                MessageBox.Show("Foram encontrados erros na análise léxica. Verifique o log!");
                streamWriterSaida.Close();
                streamWriterSaida.Dispose();
                return;
            }

            ServicoAnalisadorSintatico servicoAnalisadorSintatico = new ServicoAnalisadorSintatico(txtArquivoGoldParser.Text);
            servicoAnalisadorSintatico.lerSimbolos();
            servicoAnalisadorSintatico.lerProducoes();
            servicoAnalisadorSintatico.lerTabelaLALR();

            List<string> resultadoAnaliseSintatica = servicoAnalisadorSintatico.analisar(tokensLidos);

            streamWriterSaida.WriteLine(String.Join(Environment.NewLine, resultadoAnaliseSintatica));

            streamWriterSaida.Close();
            streamWriterSaida.Dispose();

            if (resultadoAnaliseSintatica != null && resultadoAnaliseSintatica.Count > 0) {
                MessageBox.Show("Foram encontrados erros na análise sintática. Verifique o log!");
            } else {
                MessageBox.Show("Análise sintática concluída!");
            }

        }

    }
}
