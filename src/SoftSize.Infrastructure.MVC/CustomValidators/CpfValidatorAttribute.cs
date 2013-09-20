using System.ComponentModel.DataAnnotations;
using SoftSize.Infrastructure.Extensions;

namespace SoftSize.Infrastructure.MVC.CustomValidators
{
    public class CpfValidatorAttribute : ValidationAttribute//, IClientValidatable
    {


        public override bool IsValid(object value)
        {
            if(value == null || value.ToString() == string.Empty)
                return true;

            switch (TipoDeDocumento)
            {
                case TipoDeDocumento.Cpf:
                    if (value.ToString().Length == 11)
                        return ValidacaoDocumentos.Validar(value.ToString());
                    break;
            }

            return false;
        }

        public TipoDeDocumento TipoDeDocumento { get; set; }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    var rule = new ModelClientValidationRule();
        //    rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
        //}
    }

    public enum TipoDeDocumento
    {
        Cpf,
        Cnpj
    }
}