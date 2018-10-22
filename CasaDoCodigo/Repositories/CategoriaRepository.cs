using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria AddCategoria(string nome);
        Categoria GetCategoria(string nome);
    }

    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Categoria AddCategoria(string nome)
        {
            var categoria = GetCategoria(nome);
            if (categoria == null)
            {
                categoria = new Categoria(nome);
                contexto.Set<Categoria>()
                    .Add(categoria);

                contexto.SaveChanges();
            }
            return categoria;
        }

        public Categoria GetCategoria(string nome)
        {
            return contexto.Set<Categoria>()
                            .Where(c => c.Nome == nome)
                            .SingleOrDefault();
        }
    }
}
