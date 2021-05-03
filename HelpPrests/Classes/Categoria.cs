using System.Collections.Generic;


namespace HelpPrests.Classes
{
    public class Categoria
    {
        private int Codigo { get;  set; }
        private string Descricao { get;  set; }

        public Categoria()
        {

        }

        public Categoria(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return "Categoria: " + this.Descricao;
        }


        public Categoria LocalizaCategoria(List<Categoria> lista, int codigo)
        {
            return lista.Find(c => c.Codigo == codigo);
        }
    }
}
