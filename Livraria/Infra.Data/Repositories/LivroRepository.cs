using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using Livraria.Domain.Query;
using Dapper;
using Livraria.Infra.Data.DataContexts;
using System;
using System.Linq;
using Livraria.Infra.Data.Repositories.Queries;

namespace Livraria.Infra.Data.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;
        public LivroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Livro livro)
        {
            try
            {
                _parameters.Add("Nome", livro.Nome, System.Data.DbType.String);
                _parameters.Add("Autor", livro.Autor, System.Data.DbType.String);
                _parameters.Add("Edicao", livro.Edicao, System.Data.DbType.Int32);
                _parameters.Add("Isbn", livro.Isbn, System.Data.DbType.String);
                _parameters.Add("Imagem", livro.Imagem, System.Data.DbType.String);

                //var sql = @"Insert Into Livro(Nome, Autor, Edicao, Isbn, Imagem) Values (@Nome, @Autor, @Edicao, @Isbn, @Imagem);
                //            select SCOPE_IDENTITY();";


                return _dataContext.SqlServerConexao.ExecuteScalar<long>(LivroQueries.Inserir, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Atualizar(Livro livro)
        {
            try
            {
                _parameters.Add("Id", livro.Id, System.Data.DbType.Int64);
                _parameters.Add("Nome", livro.Nome, System.Data.DbType.String);
                _parameters.Add("Autor", livro.Autor, System.Data.DbType.String);
                _parameters.Add("Edicao", livro.Edicao, System.Data.DbType.Int32);
                _parameters.Add("Isbn", livro.Isbn, System.Data.DbType.String);
                _parameters.Add("Imagem", livro.Imagem, System.Data.DbType.String);

                //var sql = @"Update Livro Set Nome=@Nome, Autor=@Autor, Edicao=@Edicao, Isbn=@Isbn, Imagem=@Imagem where Id=@Id";

                _dataContext.SqlServerConexao.Execute(LivroQueries.Atualizar, _parameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(long id)
        {
            try
            {
                _parameters.Add("Id", id, System.Data.DbType.Int64);

                //var sql = @"Delete From Livro where Id=@Id";

                _dataContext.SqlServerConexao.Execute(LivroQueries.Excluir, _parameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LivroQueryResult> Listar()
        {
            try
            {
                //var sql = @"Select 
                //            Nome as Nome, 
                //            Autor as Autor, 
                //            Edicao as Edicao, 
                //            Isbn as Isbn, 
                //            Imagem as Imagem
                //        From Livro
                //        Order by Nome";

                var livros = _dataContext.SqlServerConexao.Query<LivroQueryResult>(LivroQueries.Listar).ToList();
                return livros;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LivroQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, System.Data.DbType.Int64);

                //var sql = @"Select 
                //            Nome as Nome, 
                //            Autor as Autor, 
                //            Edicao as Edicao, 
                //            Isbn as Isbn, 
                //            Imagem as Imagem
                //        From Livro
                //        Where Id=@Id";

                var livro = _dataContext.SqlServerConexao.Query<LivroQueryResult>(LivroQueries.Obter, _parameters).FirstOrDefault();
                return livro;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("Id", id, System.Data.DbType.Int64);

                //var sql = @"Select Id From Livro Where Id=@Id";

                return _dataContext.SqlServerConexao.Query<bool>(LivroQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}