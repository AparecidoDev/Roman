using Roman.WebApi.Contexts;
using Roman.WebApi.Domain;
using Roman.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        public void Create(TipoUsuario NovoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(NovoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.TipoUsuarios.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Read()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public TipoUsuario ReadById(int Id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == Id);
        }

        public void Update(int Id, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = ReadById(Id);

            if (TipoUsuarioAtualizado.NomeTipoUsuario != null)
            {
                TipoUsuarioBuscado.NomeTipoUsuario = TipoUsuarioAtualizado.NomeTipoUsuario;

                ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
