using Roman.WebApi.Contexts;
using Roman.WebApi.Domain;
using Roman.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        public Usuario Login(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.Email == Email && c.Senha == Senha);
        }

        public void Create(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Usuarios.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Usuario> Read()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario ReadById(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == Id);
        }

        public void Update(int Id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ReadById(Id);

            if (UsuarioAtualizado.NomeUsuario != null)
            {
                UsuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if (UsuarioAtualizado.IdEquipe != null)
            {
                UsuarioBuscado.IdEquipe = UsuarioAtualizado.IdEquipe;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if (UsuarioAtualizado.IdTipoUsuario != null)
            {
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if (UsuarioAtualizado.Email != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if (UsuarioAtualizado.Senha != null)
            {
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
