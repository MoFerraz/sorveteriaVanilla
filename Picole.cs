using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorveteriaVanilla
{
    internal class Picole
    {
        public string nome;
        public string descricao;
        public string ingredientes;
        public decimal valor;

        public Picole(string nome, string descricao, string ingredientes, decimal valor)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.ingredientes = ingredientes;
            this.valor = valor;
        }
        public override string ToString()
        {
            return $"Nome: {this.nome} "  +  $"Descrição: {this.descricao} "  +  $"Ingredientes: {this.ingredientes} " +  $"Valor: {this.valor} ";
        }


    }
}
