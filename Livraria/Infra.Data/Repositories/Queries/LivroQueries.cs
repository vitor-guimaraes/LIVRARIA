using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.Data.Repositories.Queries
{
    public static class LivroQueries
    {
        public static String Inserir = @"Insert Into Livro(Nome, Autor, Edicao, Isbn, Imagem) Values (@Nome, @Autor, @Edicao, @Isbn, @Imagem);
                                        select SCOPE_IDENTITY();";

        public static String Atualizar = @"Update Livro Set Nome=@Nome, Autor=@Autor, Edicao=@Edicao, Isbn=@Isbn, Imagem=@Imagem where Id=@Id";
        
        public static String Excluir = @"Delete From Livro where Id=@Id";
        
        public static String Listar = @"Select 
                                        Nome as Nome, 
                                        Autor as Autor, 
                                        Edicao as Edicao, 
                                        Isbn as Isbn, 
                                        Imagem as Imagem
                                    From Livro
                                    Order by Nome";

        public static String Obter = @"Select 
                                        Nome as Nome, 
                                        Autor as Autor, 
                                        Edicao as Edicao, 
                                        Isbn as Isbn, 
                                        Imagem as Imagem
                                    From Livro
                                    Where Id=@Id";

        public static String CheckId = @"Select Id From Livro Where Id=@Id";

    }
}
