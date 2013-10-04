using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using CTF.Fidelidade.Premmia.ViewModel;
using SoftSize.Ieed.Model.FilterState;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ViewModels.ViewModels;

namespace SoftSize.Ieed.ModelMapping
{
    public static class ExtensionsMappers
    {
        public static IEnumerable<PermissaoViewModel> ToPermissoesViewModel(this IEnumerable<Permissao> permissoes)
        {
            return Mapper.Map<IEnumerable<Permissao>, IEnumerable<PermissaoViewModel>>(permissoes);
        }
        public static PermissaoViewModel ToPermissaoViewModel(this Permissao permissao)
        {
            return Mapper.Map<Permissao, PermissaoViewModel>(permissao);
        }

        public static IEnumerable<AssociadoModel> ToUsuariosViewModel(this IEnumerable<Associado> usuarios)
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<AssociadoModel>>(usuarios);
        }

        public static UsuarioViewModel ToUsuarioViewModel(this Usuario usuario)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(usuario);
        }


        public static IEnumerable<PerfilViewModel> ToPerfisViewModel(this IEnumerable<PerfilDeAcesso> perfilDeAcesso)
        {
            return Mapper.Map<IEnumerable<PerfilDeAcesso>, IEnumerable<PerfilViewModel>>(perfilDeAcesso);
        }


        public static Permissao ToPermissao(this PermissaoViewModel usuarioViewModel)
        {
            return Mapper.Map<PermissaoViewModel, Permissao>(usuarioViewModel);
        }


        public static IEnumerable<ListaAssociadoModel> ToListaAssociadoModel(this IEnumerable<Associado> associado)
        {
            return Mapper.Map<IEnumerable<Associado>, IEnumerable<ListaAssociadoModel>>(associado);
        }

        public static IEnumerable<PagamentoItemModel> ToPagamentoItemModel(this IEnumerable<LancamentoBase> lancamentosBase)
        {
            return Mapper.Map<IEnumerable<LancamentoBase>, IEnumerable<PagamentoItemModel>>(lancamentosBase);
        }

        public static Associado ToAssociado(this AssociadoModel registerModel, Associado associado)
        {
            return Mapper.Map(registerModel, associado);
        }
        public static Associado ToAssociado(this AssociadoModel associadoModel)
        {
            return Mapper.Map<AssociadoModel, Associado>(associadoModel);
        }
        public static AssociadoModel ToAssociadoViewModel(this Associado associado)
        {
            return Mapper.Map<Associado, AssociadoModel>(associado);
        }
        public static IOrderedEnumerable<AssociadoModel> ToAssociadosViewModel(this IOrderedEnumerable<Associado> associados)
        {
            return Mapper.Map<IOrderedEnumerable<Associado>, IOrderedEnumerable<AssociadoModel>>(associados);
        }
        public static IEnumerable<AssociadoModel> ToAssociadosViewModel(this IEnumerable<Associado> associados)
        {
            return Mapper.Map<IEnumerable<Associado>, IEnumerable<AssociadoModel>>(associados);
        }


        public static IEnumerable<LancamentoModel> ToListaLancamentoModel(this IEnumerable<LancamentoBase> mensalidades)
        {
            return Mapper.Map<IEnumerable<LancamentoBase>, IEnumerable<LancamentoModel>>(mensalidades);
        }


        public static IEnumerable<LancamentoModel> ToListaDespesaModel(this IEnumerable<LancamentoDespesa> despesas)
        {
            return Mapper.Map<IEnumerable<LancamentoDespesa>, IEnumerable<LancamentoModel>>(despesas);
        }
        
        public static LancamentoMensalidade ToMensalidade(this LancamentoModel lancamentoModel)
        {
            return Mapper.Map<LancamentoModel, LancamentoMensalidade>(lancamentoModel);
        }
        public static LancamentoDoacao ToDoacao(this LancamentoModel lancamentoModel)
        {
            return Mapper.Map<LancamentoModel, LancamentoDoacao>(lancamentoModel);
        }

        public static CentroDeCustoLancamento ToCentroDeCustoLancamento(this CentroDeCustoViewModel centroDeCustoViewModel)
        {
            return Mapper.Map<CentroDeCustoViewModel, CentroDeCustoLancamento>(centroDeCustoViewModel);
        }

        public static IEnumerable<CentroDeCustoViewModel> ToCentrosDeCustoViewModel(this IEnumerable<CentroDeCustoLancamento> centroDeCustoLancamento)
        {
            return Mapper.Map<IEnumerable<CentroDeCustoLancamento>, IEnumerable<CentroDeCustoViewModel>>(centroDeCustoLancamento);
        }
        

        public static IEnumerable<LancamentoCerimoniaModel> ToListaCerimoniasModel(this IEnumerable<LancamentoBase> cerimonias)
        {
            return Mapper.Map<IEnumerable<LancamentoBase>, IEnumerable<LancamentoCerimoniaModel>>(cerimonias);
        }
        
        public static LancamentoCerimonia ToLancamentoCerimonia(this LancamentoCerimoniaModel lancamentoCerimoniaModel)
        {
            return Mapper.Map<LancamentoCerimoniaModel, LancamentoCerimonia>(lancamentoCerimoniaModel);
        }

        public static LancamentoDespesa ToLancamentoDespesa(this LancamentoDespesaModel lancamentoDespesaModel)
        {
            return Mapper.Map<LancamentoDespesaModel, LancamentoDespesa>(lancamentoDespesaModel);
        }

        //public static LancamentoMensalidade ToMensalidade(this LancamentoModel LancamentoModel)
        //{
        //    return Mapper.Map<LancamentoModel, LancamentoMensalidade>(LancamentoModel);
        //}



        public static Usuario ToUsuario(this UsuarioViewModel usuarioViewModel)
        {
            return Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
        }

        
        public static Usuario ToUsuario(this RegisterModel registerModel)
        {
            return Mapper.Map<RegisterModel, Usuario>(registerModel);
        }

        public static RegisterModel ToRegisterModel(this Usuario registerModel)
        {
            return Mapper.Map<Usuario, RegisterModel>(registerModel);
        }

        //public static Entidad ToEntidadeModel(this Entidade entidade)
        //{
        //    return Mapper.Map<Entidade, EntidadeViewModel>(entidade);
        //}


        public static IEnumerable<UsuarioViewModel> TransformarPor(IEnumerable<Usuario> usuarios)
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(usuarios);
        }


        public static Guid[] ToGuids(this PagamentoModel pagamentoModel)
        {
            var guids = new List<Guid>();
            guids.AddRange(pagamentoModel.LancamentoModelPagar.ToGuidArray());
            return guids.ToArray();
        }

        public static Guid[] ToGuidArray(this string[] strings)
        {
            var guidsIds = new List<Guid>();
            foreach (var id in strings)
            {
                Guid parsedId;
                if (Guid.TryParse(id, out parsedId))
                {
                    guidsIds.Add(parsedId);
                }
            }
            return guidsIds.ToArray();
        }

        public static Filtro ToFiltroModel(this FiltroViewModel filtrosViewModel)
        {
            return Mapper.Map<FiltroViewModel, Filtro>(filtrosViewModel);
        }

        public static IEnumerable<FiltroViewModel> ToFiltrosViewModel(this IEnumerable<Filtro> filtros)
        {
            return Mapper.Map<IEnumerable<Filtro>, IEnumerable<FiltroViewModel>>(filtros);
        }

        public static IEnumerable<ItemFiltroViewModel> ToItensFiltroViewModel(this IEnumerable<ItemFiltro> filtros)
        {
            return Mapper.Map<IEnumerable<ItemFiltro>, IEnumerable<ItemFiltroViewModel>>(filtros);
        }

    }
}
