using Roman.WebApi.Contexts;
using Roman.WebApi.Domain;
using Roman.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Repository
{
    public class TemaRepository : ITemaRepository
    {
        RomanContext ctx = new RomanContext();

        public void Create(Tema NovoTema)
        {
            ctx.Temas.Add(NovoTema);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Temas.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Tema> Read()
        {
            return ctx.Temas.ToList();
        }

        public Tema ReadById(int Id)
        {
            return ctx.Temas.FirstOrDefault(t => t.IdTema == Id);
        }

        public void Update(int Id, Tema TemaAtualizado)
        {
            Tema TemaBuscado = ReadById(Id);

            if (TemaAtualizado.NomeTema != null)
            {
                TemaBuscado.NomeTema = TemaAtualizado.NomeTema;

                ctx.Temas.Update(TemaBuscado);

                ctx.SaveChanges();
            }

            if (TemaAtualizado.Ativo != null)
            {
                TemaBuscado.Ativo = TemaAtualizado.Ativo;

                ctx.Temas.Update(TemaBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
