using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using Livraria.Domain.Query;

namespace Livraria.Infra.Data.Repositories
{
    public class LivroRepository : ILivroRepository
    {

        public LivroRepository()
        {

        }

        public long Inserir(Livro livro)
        {
            throw new System.NotImplementedException();
        }
        public void Atualizar(Livro livro)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(long id)
        {
            throw new System.NotImplementedException();
        }
        public List<LivroQueryResult> Listar()
        {
            throw new System.NotImplementedException();
        }

        public LivroQueryResult Obter(long id)
        {
            throw new System.NotImplementedException();
        }
        public bool CheckId(long id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// /////////////
        /// </summary>
        /// <returns></returns>

        List<LivroQueryResult> ILivroRepository.Listar()
        {
            throw new System.NotImplementedException();
        }

        bool ILivroRepository.CheckId(long id)
        {
            throw new System.NotImplementedException();
        }
    }

}