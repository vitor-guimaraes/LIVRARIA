using Livraria.Domain.Commands.Input;
using Livraria.Domain.Commands.Outputs;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Infra.Interfaces.Commands;
using System;

namespace Livraria.Domain.Handlers
{
    public class LivroHandler : ICommandHandler<AdicionarLivroCommand> //INSERIR ATUALIZAR - AQUI DESAFIO 1
    {
        private readonly ILivroRepository _repository;
        public LivroHandler(ILivroRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(AdicionarLivroCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new LivroCommandResult(false, "Corrija as inconsistências", command.Notifications);

                long id = 0;
                string nome = command.Nome;
                string autor = command.Autor;
                int edicao = command.Edicao;
                string isbn = command.Isbn;
                string imagem = command.Imagem;

                Livro livro = new Livro(id, nome, autor, edicao, isbn, imagem);

                id = _repository.Inserir(livro);

                var retorno = new LivroCommandResult(true, "Livro adicionado com sucesso",
                    new
                    {
                        Id = id,
                        Nome = livro.Nome,
                        Autor = livro.Autor,
                        Edicao = livro.Edicao,
                        Isbn = livro.Isbn,
                        Imagem = livro.Imagem
                    });

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
