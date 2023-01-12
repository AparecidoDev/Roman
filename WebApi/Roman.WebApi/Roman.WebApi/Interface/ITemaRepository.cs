using Roman.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Interface
{
    interface ITemaRepository
    {
        void Create(Tema NovoTema);

        List<Tema> Read();

        Tema ReadById(int Id);

        void Update(int Id, Tema TemaAtualizado);

        void Delete(int Id);
    }
}
