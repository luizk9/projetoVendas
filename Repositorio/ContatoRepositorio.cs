using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projContato.Data;
using projContato.Models;

namespace projContato.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        
        //construtor que vai ser injetado o contexto
        public ContatoRepositorio(BancoContext bancoContext )
        { // que vai ser acessado atraves da variavel acima, pois ela só
        // dentro do metodo
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x=>x.Id == id);
        }


         public List<ContatoModel> BuscarTodos()
         {
            return _bancoContext.Contatos.ToList();
                // agora vai na index
         }   

        public ContatoModel Adicionar(ContatoModel contato)
        {          
            // gravar no banco de dados que vem do contexto
            // vindo do contexto injetado no construtor 

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;

        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);
            if(contatoDB == null) throw new System.Exception("houver um erro na atulaização");
            
            contatoDB.Nome = contato.Nome;
            contatoDB.Local = contato.Local;
            contatoDB.ValorTotal = contato.ValorTotal;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);
            if(contatoDB ==null) throw new System.Exception("Houver um erro no item..");
            
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;

        }
    }
}