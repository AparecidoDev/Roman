using Roman.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Interface
{
    interface IEquipeRepository
    {
        void Create(Equipe NovaEquipe);

        List<Equipe> Read();

        Equipe ReadById(int Id);

        void Update(int Id, Equipe EquipeAtualizada);

        void Delete(int Id);
    }
}
