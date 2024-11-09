using System.Windows.Forms;

namespace BlocoDeNotas
{
    public partial class BlocoDeNotas : Form
    {
        public BlocoDeNotas()
        {
            InitializeComponent();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbTexto.Text != "")
            {
                DialogResult resultado = MessageBox.Show("Deseja salvar as altera��es?", "Bloco de notas", MessageBoxButtons.YesNoCancel);
                if (resultado == DialogResult.Yes)
                {
                    SalvarConteudoRichTextBox();
                }
                if (resultado == DialogResult.No)
                {
                    rtbTexto.Text = "";
                }
            }
        }

        // L�gica para salvar o arquivo de texto.
        private void SalvarConteudoRichTextBox()
        {
            // Cria o di�logo para salvar arquivos
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Configura��es do SaveFileDialog
                saveFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Title = "Salvar como";

                // Mostra o di�logo para o usu�rio
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Salva o conte�do do RichTextBox no arquivo selecionado
                        File.WriteAllText(saveFileDialog.FileName, rtbTexto.Text);
                        rtbTexto.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao salvar o arquivo:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvarConteudoRichTextBox();
        }

        // L�gica para abrir arquivos de texto e carregar no RichTextBox.
        private void AbrirArquivoTexto()
        {
            // Cria o di�logo para abrir arquivos
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configura��es do OpenFileDialog
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*";
                openFileDialog.Title = "Abrir";

                // Mostra o di�logo para o usu�rio
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // L� o conte�do do arquivo selecionado
                        string conteudo = File.ReadAllText(openFileDialog.FileName);

                        // Coloca o conte�do no RichTextBox
                        rtbTexto.Text = conteudo;

                        MessageBox.Show("Arquivo carregado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao abrir o arquivo:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArquivoTexto();
        }
    }
}
