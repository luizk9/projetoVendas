using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projContato.Models;

namespace projContato.Data
{
    public class BancoContext : DbContext
    {
        //construtor
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        // fazer as tabelas do banco
        public DbSet<ContatoModel>Contatos{get; set;}
        
    }
}