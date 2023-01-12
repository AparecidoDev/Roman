using Roman.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Interface
{
    interface IProjetoRepository
    {
        void Create(Projeto NovoProjeto);

        List<Projeto> Read();

        Projeto ReadById(int Id);

        void Update(int Id, Projeto ProjetoAtualizado);

        void Delete(int Id);
    }
}
