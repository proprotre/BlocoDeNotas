
# Bloco de Notas em C# com Interface Gráfica

- C# .NET Core
- Windows Forms
- Manipulação de arquivos de texto (`.txt`)

## Funcionalidades

- **Criar um Novo Documento**: Permite criar um novo documento. Caso haja texto não salvo no editor, solicita ao usuário para salvar antes de limpar o conteúdo.
- **Abrir Arquivo de Texto**: Carrega um arquivo de texto existente e exibe o conteúdo no editor.
- **Salvar Arquivo**: Salva o conteúdo do editor em um arquivo existente ou permite salvar como um novo arquivo.
- **Salvar Como**: Abre uma janela para que o usuário escolha o local e o nome do arquivo onde o conteúdo será salvo.
  
## Interface do Usuário
![Interface Bloco de Notas](/Imagens/BlocoDeNotas.png "Interface Bloco de Notas")

## Funcionalidades Detalhadas

### Criar Novo Documento
- Verifica se o editor contém texto não salvo.
- Oferece opções para salvar, descartar alterações ou cancelar a operação.

### Abrir Arquivo de Texto
- Abre um arquivo de texto selecionado pelo usuário e carrega o conteúdo no editor.
- Exibe mensagens de erro em caso de problemas ao abrir o arquivo.

### Salvar Como
- Sempre solicita que o usuário escolha o local e o nome do arquivo antes de salvar.

---

## Código Principal

```csharp
// Exemplos principais: Novo, Abrir e Salvar
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

private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
{
    SalvarConteudoRichTextBox();
}

private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
{
    AbrirArquivoTexto();
}
```

---

## Caminho do Executável
"BlocoDeNotas/bin/Debug/net8.0-windows/BlocoDeNotas.exe"

## Autor
Gabriel Badaró
