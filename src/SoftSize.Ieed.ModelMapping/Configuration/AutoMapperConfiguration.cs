
using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using CTF.Fidelidade.Premmia.ViewModel;
using SoftSize.Ieed.Model.FilterState;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Ieed.ModelMapping.Resolvers;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ViewModels.ViewModels;

namespace SoftSize.Ieed.ModelMapping.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            x.AddProfile<DomainViewModelProfile>());
        }
    }

    public class DomainViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModel"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<RegisterModel, Usuario>()
                .ForMember(dest => dest.NomeDeUsuario, opt => opt.MapFrom(src => src.UserName));

            Mapper.CreateMap<Usuario, RegisterModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.NomeDeUsuario));


            Mapper.CreateMap<UsuarioViewModel, Usuario>()
                .ForMember(dest => dest.NomeDeUsuario, opt => opt.MapFrom(src => src.Login));

            Mapper.CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.NomeDeUsuario));

            Mapper.CreateMap<AssociadoModel, Associado>()
                .ForMember(dest => dest.Endereco, opt => opt.ResolveUsing<EnderecoResolver>())
                .ForMember(dest => dest.EnderecoCorrespondencia,
                           opt => opt.ResolveUsing<EnderecoCorrespondenciaResolver>())
                .ForMember(dest => dest.MensalidadeCategoria, opt => opt.Ignore())
                .ForMember(dest => dest.AssociadoDetalhe, opt => opt.ResolveUsing<AssociadoDetalheResolver>());

            Mapper.CreateMap<Associado, AssociadoModel>()
                .ForMember(dest => dest.Dependente,
                           opt => opt.MapFrom(src => (src.DependenteDe == null ? new Guid() : src.DependenteDe.Id)))
                .ForMember(dest => dest.MensalidadeCategoria,
                           opt =>
                           opt.MapFrom(
                               src => (src.MensalidadeCategoria == null ? new Guid() : src.MensalidadeCategoria.Id)))
                .ForMember(dest => dest.GrauEspiritualAtual,
                           opt => opt.MapFrom(src => (src.GrauEspiritual == null ? new Guid() : src.GrauEspiritual.Id)));

            Mapper.CreateMap<Associado, ListaAssociadoModel>()
                .ForMember(dest => dest.ListaAssociadoModels, opt => opt.MapFrom(src => src.Dependentes))
                .ForMember(dest => dest.Dependente, opt => opt.MapFrom(src => src.DependenteDe != null));


            Mapper.CreateMap<AssociadoDetalhe, ListaAssociadoModel>()
                .ForMember(dest => dest.AssociadoDetalheCPF, opt => opt.MapFrom(src => src.CPF));


            Mapper.CreateMap<AssociadoDetalhe, AssociadoModel>()
                .ForAllMembers(opt => opt.ResolveUsing<AssociadoDetalheResolver>());


            Mapper.CreateMap<LancamentoModel, LancamentoMensalidade>()
                                .ForMember(dest => dest.DataLancamento, opt => opt.UseValue(DateTime.Now))
                                .ForMember(dest => dest.Associado, opt => opt.MapFrom(src => src.Associado));

            Mapper.CreateMap<LancamentoModel, LancamentoBase>()
                    .ForMember(dest => dest.DataLancamento, opt => opt.UseValue(DateTime.Now));


            Mapper.CreateMap<LancamentoMensalidade, LancamentoModel>();

            Mapper.CreateMap<LancamentoModel, LancamentoDoacao>()
                .ForMember(dest => dest.DataLancamento, opt => opt.UseValue(DateTime.Now));
            Mapper.CreateMap<LancamentoDoacao, LancamentoModel>();

            Mapper.CreateMap<LancamentoBase, LancamentoModel>();
            Mapper.CreateMap<LancamentoModel, LancamentoBase>();

            Mapper.CreateMap<LancamentoDespesaModel, LancamentoDespesa>();
            Mapper.CreateMap<LancamentoDespesa, LancamentoDespesaModel>();

            Mapper.CreateMap<LancamentoModel, LancamentoDespesa>();
            Mapper.CreateMap<LancamentoDespesa, LancamentoModel>();


            Mapper.CreateMap<LancamentoCerimonia, LancamentoCerimoniaModel>()
                .ForMember(dest => dest.DataLancamento, opt => opt.UseValue(DateTime.Now));
            Mapper.CreateMap<LancamentoCerimoniaModel, LancamentoCerimonia>()
                                .ForMember(dest => dest.DataLancamento, opt => opt.UseValue(DateTime.Now));


            Mapper.CreateMap<PermissaoViewModel, Permissao>();
            Mapper.CreateMap<Permissao, PermissaoViewModel>();

            Mapper.CreateMap<PerfilViewModel, PerfilDeAcesso>();
            Mapper.CreateMap<PerfilDeAcesso, PerfilViewModel>();



            Mapper.CreateMap<LancamentoBase, PagamentoItemModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => src.DataLancamento))
                .ForMember(dest => dest.DataPagamento, opt => opt.MapFrom(src => src.DataPagamento))
                .ForMember(dest => dest.Tipo,
                           opt =>
                           opt.MapFrom(
                               src => (src is LancamentoMensalidade ? "Mensalidade" : (src is LancamentoCerimonia ? "Cerimônia" : ""))))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor));

            Mapper.CreateMap<PagamentoItemModel, LancamentoBase>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => src.DataLancamento))
                 .ForMember(dest => dest.DataPagamento, opt => opt.MapFrom(src => src.DataPagamento))
                 .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor));

            Mapper.CreateMap<CentroDeCustoViewModel, CentroDeCustoLancamento>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));


            Mapper.CreateMap<CentroDeCustoLancamento, CentroDeCustoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));

            Mapper.CreateMap<FiltroViewModel, Filtro>()
                    .ForMember(dest => dest.ItensFiltro, opt => opt.MapFrom(src => src.ItemsFiltro));

            Mapper.CreateMap<Filtro, FiltroViewModel>()
                  .ForMember(dest => dest.ItemsFiltro, opt => opt.MapFrom(src => src.ItensFiltro));


            Mapper.CreateMap<ItemFiltroViewModel, ItemFiltro>();
            Mapper.CreateMap<ItemFiltro, ItemFiltroViewModel>();

        }
    }
}
