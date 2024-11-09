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
                DialogResult resultado = MessageBox.Show("Deseja salvar as alterações?", "Bloco de notas", MessageBoxButtons.YesNoCancel);
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

        // Lógica para salvar o arquivo de texto.
        private void SalvarConteudoRichTextBox()
        {
            // Cria o diálogo para salvar arquivos
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Configurações do SaveFileDialog
                saveFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Title = "Salvar como";

                // Mostra o diálogo para o usuário
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Salva o conteúdo do RichTextBox no arquivo selecionado
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

        // Lógica para abrir arquivos de texto e carregar no RichTextBox.
        private void AbrirArquivoTexto()
        {
            // Cria o diálogo para abrir arquivos
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configurações do OpenFileDialog
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*";
                openFileDialog.Title = "Abrir";

                // Mostra o diálogo para o usuário
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lê o conteúdo do arquivo selecionado
                        string conteudo = File.ReadAllText(openFileDialog.FileName);

                        // Coloca o conteúdo no RichTextBox
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
