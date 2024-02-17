using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace sorveteriaVanilla
{
    public partial class Form1 : Form
    {
        // Define a criação de uma lista de produtos vazia
        List<Picole> picoles;
        public Form1()
        {
            InitializeComponent();

            // Carrega os dados do Json para a lista de produtos
            picoles = ProcessaJson.CarregaLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;
            string ingredientes = txtIngredientes.Text;
            decimal valor = decimal.Parse(txtValor.Text);

            Picole novo_picole = new Picole(nome, descricao, ingredientes, valor);

            picoles.Add(novo_picole);

            // Armazena a lista no arquivo JSON
            ProcessaJson.ArmazenaLista("./meuarquivojson.json", picoles);

            MessageBox.Show("Produto cadastrado com sucesso");
            limparCampos();
        }
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            Picole picole = picoles[(int)numNumeroPicole.Value];
            txtVisor.Text = picole.ToString();
        }
        private void limparCampos()
        {
            // Limpa o campo de descricao
            txtDescricao.Clear();
            txtIngredientes.Clear();
            txtNome.Clear();
            txtValor.Clear();
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Adiciona a coluna no ListView
            // lsvProdutos.View = View.Details;
            // lsvProdutos.Columns.Add("Nome");
            // lsvProdutos.Columns.Add("Valor");

            lsvPicole.Items.Clear();

            // Executa uma vez para cada produto na lista
            foreach (Picole produto in picoles)
            {
                // Cria um item de list view vazio
                ListViewItem item = new ListViewItem(produto.nome);

                item.SubItems.Add(produto.valor.ToString("c"));

                // Adiciona o item ao listView
                lsvPicole.Items.Add(item);
            }

            lsvPicole.Visible = true;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            {
                // Adiciona a coluna no ListView
                // lsvProdutos.View = View.Details;
                // lsvProdutos.Columns.Add("Nome");
                // lsvProdutos.Columns.Add("Valor");

                lsvPicole.Items.Clear();

                // Executa uma vez para cada produto na lista
                foreach (Picole produto in picoles)
                {
                    // Cria um item de list view vazio
                    ListViewItem item = new ListViewItem(produto.descricao);

                    item.SubItems.Add(produto.valor.ToString("c"));

                    // Adiciona o item ao listView
                    lsvPicole.Items.Add(item);
                }

                lsvPicole.Visible = true;
            }
        }
    }

}