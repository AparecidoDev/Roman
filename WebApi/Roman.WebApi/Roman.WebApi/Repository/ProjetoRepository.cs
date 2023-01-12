using Microsoft.EntityFrameworkCore;
using Roman.WebApi.Contexts;
using Roman.WebApi.Domain;
using Roman.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Repository
{

    public class ProjetoRepository : IProjetoRepository
    {
        RomanContext ctx = new RomanContext();

        public void Create(Projeto NovoProjeto)
        {
            ctx.Projetos.Add(NovoProjeto);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Projetos.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Projeto> Read()
        {
            return ctx.Projetos
                
            .Include(x => x.IdTemaNavigation)             
                 
            .ToList();
        }

        public Projeto ReadById(int Id)
        {
            return ctx.Projetos.FirstOrDefault(p => p.IdProjeto == Id);
        }

        public void Update(int Id, Projeto ProjetoAtualizado)
        {
            Projeto ProjetoBuscado = ReadById(Id);

            if (ProjetoAtualizado.NomeProjeto != null)
            {
                ProjetoBuscado.NomeProjeto = ProjetoAtualizado.NomeProjeto;

                ctx.Projetos.Update(ProjetoBuscado);

                ctx.SaveChanges();
            }

            if (ProjetoAtualizado.IdTema != null)
            {
                ProjetoBuscado.IdTema = ProjetoAtualizado.IdTema;

                ctx.Projetos.Update(ProjetoBuscado);

                ctx.SaveChanges();
            }

            if (ProjetoAtualizado.IdUsuario != null)
            {
                ProjetoBuscado.IdUsuario = ProjetoAtualizado.IdUsuario;

                ctx.Projetos.Update(ProjetoBuscado);

                ctx.SaveChanges();
            }

            if (ProjetoAtualizado.Descricao != null)
            {
                ProjetoBuscado.Descricao = ProjetoAtualizado.Descricao;

                ctx.Projetos.Update(ProjetoBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
