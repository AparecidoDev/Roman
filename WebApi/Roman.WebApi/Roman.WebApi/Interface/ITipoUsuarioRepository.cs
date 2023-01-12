using Roman.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Interface
{
    interface ITipoUsuarioRepository
    {
        void Create(TipoUsuario NovoTipoUsuario);
        List<TipoUsuario> Read();
        TipoUsuario ReadById(int Id);

        void Update(int Id, TipoUsuario TipoUsuarioAtualizado);

        void Delete(int Id);
    }
}
