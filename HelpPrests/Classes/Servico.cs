using System.Collections.Generic;


namespace HelpPrests.Classes
{
    public class Servico
    {
        private int Codigo { get; set; }
        private string Descricao { get; set; }
        private Categoria Categoria { get; set; }

        public Servico()
        {

        }

        public Servico(int codigo, string descricao, Categoria categoria)
        {
            Codigo = codigo;
            Descricao = descricao;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return "Descrição: " + this.Descricao + "\n" +
                   this.Categoria.ToString();
        }

        public Servico LocalizaServico(List<Servico> lista, int codigo, string descr)
        {
            if (codigo == 0 && descr == "")
                return null;
            
            if (codigo > 0)
                return lista.Find(c => c.Codigo == codigo);
            else
                return lista.Find(c => c.Descricao == descr);
        }
    }
}
