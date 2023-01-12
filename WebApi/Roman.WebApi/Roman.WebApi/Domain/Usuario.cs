using System;
using System.Collections.Generic;

#nullable disable

namespace Roman.WebApi.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdUsuario { get; set; }
        public int? IdEquipe { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Equipe IdEquipeNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
