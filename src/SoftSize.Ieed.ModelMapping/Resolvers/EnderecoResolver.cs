using AutoMapper;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Ieed.ViewModels;

namespace SoftSize.Ieed.ModelMapping.Resolvers
{
    public class EnderecoResolver : ValueResolver<AssociadoModel, Endereco>
    {
        protected override Endereco ResolveCore(AssociadoModel source)
        {
            return new Endereco()
            {
                Cep = source.EnderecoCep,
                Logradouro = source.EnderecoLogradouro
            };
        }
    }
}