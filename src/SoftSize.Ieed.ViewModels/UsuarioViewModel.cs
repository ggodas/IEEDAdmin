using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CTF.Fidelidade.Premmia.ViewModel;

namespace SoftSize.Ieed.ViewModels
{
    public class UsuarioViewModel
    {
        public virtual Guid Id { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [Display(Name = "Nome")]
        public virtual string Nome { get; set; }

        public string Login { get; set; }
        
        [Required(ErrorMessage = "Email Requerido")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "O email deve estar no formato seunome@dominio.com.br")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public virtual string Email { get; set; }
        
        public virtual bool Ativo { get; set; }

        public virtual bool PrimeiroLogin { get; set; }

        [Display(Name = "Perfil")]
        public dynamic PerfisDeAcessosAtribuidos { get; set; }
        
        public IEnumerable<PerfilViewModel> PerfisDeAcessosPermitidos { get; set; }

    }
}
