using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Entidades
{
    public class Livro 
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Autor { get; private set; }
        public int Edicao { get; private set; }
        public string Isbn { get; private set; }
        public string Imagem { get; private set; }

        public Livro(long id, string nome, string autor, int edicao, string isbn, string imagem)
        {
            Id = id;
            Nome = nome;
            Autor = autor;
            Edicao = edicao;
            Isbn = isbn;
            Imagem = imagem;
        }

        //public void TrocarNomeLivro(string NovoNome)
        //{
        //    this.Nome = NovoNome;
        //}

        public void SetarId( long id)
        {
            this.Id = id;
        }
    }
}
