using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projContato.Models;

namespace projContato.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        // metodo vai ser LISTAR O BANCO        
        List<ContatoModel> BuscarTodos();

        // metodo vai ser adicionar
        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);
         bool Apagar(int id);
    }
}