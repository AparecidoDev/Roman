using Roman.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Interface
{
    interface IUsuarioRepository
    {
        Usuario Login(string Email, string Senha);

        void Create(Usuario NovoUsuario); 
        List<Usuario> Read(); 
        Usuario ReadById(int Id);

        void Update(int Id, Usuario UsuarioAtualizado);

        void Delete(int Id);


    }
}
