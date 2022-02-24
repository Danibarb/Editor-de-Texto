using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Editor_de_Texto
{
    public partial class Form1 : Form
    {
        StreamReader leitura = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Salvar()
        {
            try
            {
                //Condição para salvamento do arquivo aberto
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //Criando um novo objeto do tipo FileStream com argumentos para receber os caracteres digitados no editor e texto
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName,FileMode.OpenOrCreate,FileAccess.Write);
                    
                    //Pegando os caracteres digitados e enviando para o objeto Arquivo
                    StreamWriter streamWriter = new StreamWriter(arquivo);

                    //Limpando buffer para receber os dados 
                    streamWriter.Flush();

                    //Informando a posição dos dados a serem gravados
                    streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);

                    //Escrevendo os dados do richTextBox no streamWriter
                    streamWriter.Write(this.richTextBox1.Text);

                    //Limpando e fechando
                    streamWriter.Flush();
                    streamWriter.Close();

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao Salvar o arquivo. " + "Erro ao gravar" + MessageBoxButtons.OK + MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void savarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Abrir()
        {
            //Definindo local e extensão do arquivo 
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"F:\CURSOS\Estudos_C#\CFBCursos\Editor de Texto";
            openFileDialog1.Filter = "(*.txt)|*.txt";

            if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Preparando oarquivo para a abertura-leitura
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(arquivo);
                    streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = streamReader.ReadLine();

                    while(linha != null)
                    {
                        this.richTextBox1.Text +=linha + "\n";
                        linha = streamReader.ReadLine();
                    }
                    streamReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de leitura. " + ex.Message, "Erro ao ler ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }
        private void Copiar()
        {
            if(richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }
        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void alinhaEsquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void alinharCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void copiarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void Negrito()
        {
            //Declarando variáveis para armazenar o que está no richTextBox
            string fonte = null;
            float tamanhoFonte = 0;
            bool negrito, italico, sublinhado = false;

            //Recebendo o que está escrito no richTextBox e armazenando nas variáveis
            fonte = richTextBox1.Font.Name;
            tamanhoFonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            //Deixando a fonte sem formatação
            richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Regular);

            //Apicando Negrito caso a fonte seja regular, ou deixando regular caso esteja em negrito
            if (negrito == false)
            {
                if (italico == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold | FontStyle.Underline | FontStyle.Italic);
                }
                else if (italico = true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (italico == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (italico == false & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold);
                }
                else
                {
                    if (italico == true & sublinhado == true)
                    {
                        richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Underline | FontStyle.Italic);
                    }
                    else if (italico = true & sublinhado == false)
                    {
                        richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Italic);
                    }
                    else if (italico == false & sublinhado == true)
                    {
                        richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Underline);
                    }
                }
            }    
        }

        private void Italico()
        {
            string fonte = null;
            float tamanhoFonte = 0;
            bool italico, negrito, sublinhado = false;

            fonte = richTextBox1.Font.Name;
            tamanhoFonte = richTextBox1.Font.Size;
            italico = richTextBox1.Font.Italic;
            negrito = richTextBox1.Font.Bold;
            sublinhado = richTextBox1.Font.Underline;

            richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Regular);

            if (italico == false)
            {
                if (negrito == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Italic | FontStyle.Bold |FontStyle.Underline);
                }
                else if (negrito = false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Underline | FontStyle.Italic);
                }
                else if (negrito == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (negrito == false & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Italic);
                }
                else
                {
                    if (negrito == true & sublinhado == true)
                    {
                        richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold |FontStyle.Underline);
                    }
                    else if (negrito = false & sublinhado == true)
                    {
                        richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Underline);
                    }
                    else if (negrito == true & sublinhado == false)
                    {
                        richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold);
                    }
                }
            }
        }

        private void Sublinhado()
        {
            string fonte = null;
            float tamanhoFonte = 0;
            bool sublinhado, negrito, italico = false;

            fonte = richTextBox1.Font.Name;
            tamanhoFonte = richTextBox1.Font.Size;
            sublinhado = richTextBox1.Font.Underline;
            negrito = richTextBox1.Font.Bold;
            italico = richTextBox1.Font.Italic;

            richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Regular);

            if (sublinhado == false)
            {
                if (negrito == true & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == false & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Underline | FontStyle.Italic);
                }
                else if (negrito == true & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (negrito == false & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Underline);
                }
                else
                {
                    if (negrito == true & italico == true)
                    {
                        richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold | FontStyle.Italic);
                    }
                    else if (negrito == false & italico == true)
                    {
                        richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Italic);
                    }
                    else if (negrito == true & italico == false)
                    {
                        richTextBox1.SelectionFont = new Font(fonte, tamanhoFonte, FontStyle.Bold);
                    }
                }
            }
        }
        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void btn_centralizar_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            alinhaEsquerda();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinhaEsquerda();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }
    }
}
