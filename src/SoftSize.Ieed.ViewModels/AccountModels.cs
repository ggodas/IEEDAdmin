using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SoftSize.Ieed.ViewModels
{

    public class ChangePasswordModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, digite sua senha atual")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Por favor digite uma nova senha")]
        [StringLength(100, ErrorMessage = "Sua senha deve possuir no mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da Nova Senha")]
        [Compare("NewPassword", ErrorMessage = "O campo Nova Senha e Confirmação de Nova Senha não coicidem.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessage = "Por favor digite seu nome de Usuário")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Por favor digite sua Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage="Nome requerido")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nome de Usuário requerido")]
        [Remote("CheckUserName", "Account", ErrorMessage = "Nome de usuário não permitido, por favor escolha outro.")]
        [RegularExpression("^[a-z0-9_-]{3,15}$", ErrorMessage = "O nome de usuário não pode conter espaços")]
        [Display(Name = "Nome de Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Requerido")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "O email deve estar no formato seunome@dominio.com.br")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha Requerida")]
        [StringLength(100, ErrorMessage = "Sua senha deve possuir no mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Compare("Password", ErrorMessage = "O campo senha e Confirmação de Senha não coicidem.")]
        public string ConfirmPassword { get; set; }

        [Display(Name="Ativo")]
        public bool Enabled { get; set; }


        public Guid Profile { get; set; }



        public IEnumerable<object> PerfisDeAcesso { get; set; }
    }
}
