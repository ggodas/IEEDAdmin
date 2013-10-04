using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftSize.Ieed.ViewModels
{
    public class AssociadoModel
    {
        public virtual Guid Id { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo associado é requerido.")]
        [StringLength(100, ErrorMessage="O campo nome deve conter entre 10 e 100 caracteres", MinimumLength=10)]
        public virtual string Nome { get; set; }

        [RegularExpression("^[a-z0-9_-]{3,15}$")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Nome de Usuario é requerido.")]
        public virtual string NomeDeUsuario { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage="Campo email incorreto")]
        public virtual string Email { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo Data de Nascimento esta em um formato incorreto.")]
        [Display(Name = "Data de Nascimento")]
        public virtual DateTime? AssociadoDetalheDataNascimento { get; set; }

        [Display(Name = "Nacionalidade")]
        public virtual string AssociadoDetalheNascionalidade { get; set; }

        [Display(Name = "Nome da Mãe")]
        public virtual string AssociadoDetalheNomeMae { get; set; }

        [Display(Name = "Nome do Pai")]
        public virtual string AssociadoDetalheNomePai { get; set; }

        [Display(Name = "Grau de Instrução")]
        public virtual string AssociadoDetalheGrauDeInstrucao { get; set; }

        [Display(Name = "Profissão")]
        public virtual string AssociadoDetalheProfissao { get; set; }

        [Display(Name = "Estado Civil")]
        public virtual EstadoCivilEnum AssociadoDetalheEstadoCivil { get; set; }

        [Display(Name = "Tipo de Documento")]
        public virtual TipoDocumento AssociadoDetalheDocumentoTipo { get; set; }
        
        [Display(Name = "Documento nº")]
        public virtual string AssociadoDetalheDocumentoNumero { get; set; }

        [Display(Name = "Data de Emissão do Documento")]
        public virtual string AssociadoDetalheDocumentoDataEmissao { get; set; }
        [Display(Name = "CPF")]
        public virtual string AssociadoDetalheCPF { get; set; }

        public bool PossuiDependentes { get; set; }

        [Display(Name = "Observações")]
        public virtual string AssociadoDetalheObservacoes { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo Data do Requerimento esta em um formato incorreto.")]
        [Display(Name="Data do Requerimento")]
        public virtual DateTime? AssociadoDetalheDataDoRequerimento { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo Data de Aprovação esta em um formato incorreto.")]
        [Display(Name = "Data de Aprovação pela diretoria")]
        public virtual DateTime? AssociadoDetalheDataDeAprovacaoDiretoria { get; set; }
        
        [Display(Name = "Endereço")]
        public virtual string EnderecoLogradouro { get; set; }
        
        [Display(Name = "CEP")]
        public virtual string EnderecoCep { get; set; }

        [Display(Name = "Endereço de Correspondência")]
        public virtual string EnderecoCorrespondenciaLogradouro { get; set; }

        [Display(Name = "CEP de Correspondência")]
        public virtual string EnderecoCorrespondenciaCep { get; set; }

        public virtual IEnumerable<object> Associados { get; set; }

        public virtual IEnumerable<object> GrausEspirituais { get; set; }

        public virtual IEnumerable<object> CategoriasDeMensalidade { get; set; }

        [Display(Name = "Grau Espíritual")]
        public virtual Guid GrauEspiritualAtual { get; set; }


        [Display(Name = "Dependente de:(selecionar este campo apenas se for um associado dependente.)")]
        public Guid? Dependente { get; set; }

        [Display(Name = "Categoria de Mensalidade")]
        public Guid? MensalidadeCategoria { get; set; }

    }

    public enum EstadoCivilEnum
    {
        Solteiro,
        Casado,
        Desquitado,
        Viuvo,
    }

    public enum TipoDocumento
    {
        RG,
        CREA,
        CRM,
        OAB,
        Passaporte
    }
}