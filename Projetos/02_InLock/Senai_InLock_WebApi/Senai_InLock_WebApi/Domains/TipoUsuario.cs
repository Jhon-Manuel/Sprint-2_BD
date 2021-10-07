﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_InLock_WebApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoUsuario { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}