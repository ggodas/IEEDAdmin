using System;
using AutoMapper;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Ieed.ViewModels;
using EstadoCivilEnum = SoftSize.Ieed.Model.UsuarioModel.EstadoCivilEnum;

namespace SoftSize.Ieed.ModelMapping.Resolvers
{
    public class EnderecoCorrespondenciaResolver : ValueResolver<AssociadoModel, Endereco>
    {
        protected override Endereco ResolveCore(AssociadoModel source)
        {
            return new Endereco()
            {
                Cep = source.EnderecoCorrespondenciaCep,
                Logradouro = source.EnderecoCorrespondenciaLogradouro
            };
        }
    }


    public class AssociadoDetalheResolver : ValueResolver<AssociadoModel, AssociadoDetalhe>
    {
        protected override AssociadoDetalhe ResolveCore(AssociadoModel source)
        {
            return new AssociadoDetalhe()
                       {
                           DataNascimento = source.AssociadoDetalheDataNascimento,
                           Nascionalidade = source.AssociadoDetalheNascionalidade,
                           NomeMae = source.AssociadoDetalheNomeMae,
                           NomePai = source.AssociadoDetalheNomePai,
                           GrauDeInstrucao = source.AssociadoDetalheGrauDeInstrucao,
                           Profissao = source.AssociadoDetalheProfissao,
                           EstadoCivil = (EstadoCivilEnum)source.AssociadoDetalheEstadoCivil,
                           DocumentoTipo = (TipoDocumentoEnum)source.AssociadoDetalheDocumentoTipo,
                           DocumentoNumero = source.AssociadoDetalheDocumentoNumero,
                           DocumentoDataEmissao = source.AssociadoDetalheDocumentoDataEmissao,
                           CPF = source.AssociadoDetalheCPF,
                           Observacoes = source.AssociadoDetalheObservacoes,
                           DataDoRequerimento = source.AssociadoDetalheDataDoRequerimento,
                           DataDeAprovacaoDiretoria = source.AssociadoDetalheDataDeAprovacaoDiretoria
                       };
        }
    }



    public class AssociadoModelResolver : ValueResolver<Associado, AssociadoModel>
    {
        protected override AssociadoModel ResolveCore(Associado source)
        {
            return new AssociadoModel()
                       {
                           EnderecoCep = source.Endereco.Cep,
                           EnderecoLogradouro = source.Endereco.Logradouro,
                           EnderecoCorrespondenciaCep = source.EnderecoCorrespondencia.Cep,
                           EnderecoCorrespondenciaLogradouro = source.EnderecoCorrespondencia.Logradouro,
                           AssociadoDetalheDataNascimento = source.AssociadoDetalhe.DataNascimento,
                           AssociadoDetalheNascionalidade = source.AssociadoDetalhe.Nascionalidade,
                           AssociadoDetalheNomeMae = source.AssociadoDetalhe.NomeMae,
                           AssociadoDetalheNomePai = source.AssociadoDetalhe.NomePai,
                           AssociadoDetalheGrauDeInstrucao = source.AssociadoDetalhe.GrauDeInstrucao,
                           AssociadoDetalheProfissao = source.AssociadoDetalhe.Profissao,
                           AssociadoDetalheEstadoCivil = (SoftSize.Ieed.ViewModels.EstadoCivilEnum)source.AssociadoDetalhe.EstadoCivil,
                           AssociadoDetalheDocumentoTipo = (SoftSize.Ieed.ViewModels.TipoDocumento)source.AssociadoDetalhe.DocumentoTipo,
                           AssociadoDetalheDocumentoNumero = source.AssociadoDetalhe.DocumentoNumero,
                           AssociadoDetalheDocumentoDataEmissao = source.AssociadoDetalhe.DocumentoDataEmissao,
                           AssociadoDetalheCPF = source.AssociadoDetalhe.CPF,
                           AssociadoDetalheObservacoes = source.AssociadoDetalhe.Observacoes,
                           AssociadoDetalheDataDoRequerimento = source.AssociadoDetalhe.DataDoRequerimento,
                           AssociadoDetalheDataDeAprovacaoDiretoria = source.AssociadoDetalhe.DataDeAprovacaoDiretoria
                       };
        }
    }
}