using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
