using Roman.WebApi.Contexts;
using Roman.WebApi.Domain;
using Roman.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Repository
{
    public class EquipeRepository : IEquipeRepository
    {
        RomanContext ctx = new RomanContext();

        public void Create(Equipe NovaEquipe)
        {
            ctx.Equipes.Add(NovaEquipe);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Equipes.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Equipe> Read()
        {
            return ctx.Equipes.ToList();
        }

        public Equipe ReadById(int Id)
        {
            return ctx.Equipes.FirstOrDefault(e => e.IdEquipe == Id);
        }

        public void Update(int Id, Equipe EquipeAtualizada)
        {
            Equipe EquipeBuscada = ReadById(Id);

            if (EquipeAtualizada.NomeEquipe != null)
            {
                EquipeBuscada.NomeEquipe = EquipeAtualizada.NomeEquipe;

                ctx.Equipes.Update(EquipeBuscada);

                ctx.SaveChanges();
            }
        }
    }
}
