using System;
using System.Collections.Generic;


namespace HelpPrests.Classes
{
    public class Cliente
    {
        private int Codigo { get; set; }
        private string Nome { get; set; }
        private string CPF { get; set; }
        private DateTime DataNasc { get; set; }
        private string Endereco { get; set; }
        private int Numero { get; set; }
        private string CEP { get; set; }
        private string Bairro { get; set; }
        private string Cidade { get; set; }
        private string UF { get; set; }

        public Cliente()
        {

        }
        public Cliente(int codigo, string nome, DateTime dataNasc, string cpf, string endereco, 
                       int numero, string cep, string bairro, string cidade, string uf)
        {
            Codigo = codigo;
            Nome = nome;
            CPF = cpf;
            DataNasc = dataNasc;
            Endereco = endereco;
            Numero = numero;
            CEP = cep;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
        }

        public override string ToString()
        {
            string cpfFormato = FormatarCPF(this.CPF);

            return "Nome.....: " + this.Nome + "\n" +
                   "CPF......: " + cpfFormato+ "\n" +
                   "Data Nasc: " + this.DataNasc.ToString("dd/MM/yyyy") + "\n" +
                   "Endereco.: " + this.Endereco + "\n" +
                   "CEP......: " + this.CEP + "\n" +
                   "Bairro...: " + this.Bairro + "\n" +
                   "Cidade...: " + this.Cidade + "\n" +
                   "UF.......: " + this.UF;
        }

        //recebe 99999999999 devolve 999.999.999-99
        public string FormatarCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        public Cliente LocalizaCliente(List<Cliente> lista, string cpf)
        {
            return lista.Find(c => c.CPF == cpf);
        }
    }
}
