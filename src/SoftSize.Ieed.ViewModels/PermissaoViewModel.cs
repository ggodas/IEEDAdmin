using System;
using System.Collections.Generic;

namespace CTF.Fidelidade.Premmia.ViewModel
{
    public class PermissaoViewModel
    {
        public Guid Id { get; set; }
        public string NomePermissao { get; set; }
        public string NomeDaFuncionalidade { get; set; }
        public virtual bool Privado { get; set; }
        public virtual PermissaoViewModel PermissaoPai { get; protected set; }
        public virtual IEnumerable<PermissaoViewModel> SubPermissoes { get; protected set; }

    }
}
