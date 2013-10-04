using System;

namespace SoftSize.Ieed.Model.UsuarioModel
{
    public class AssociadoDetalhe
    {
        public virtual DateTime? DataNascimento { get; set; }
        public virtual string Nascionalidade { get; set; }
        public virtual string NomeMae { get; set; }
        public virtual string NomePai { get; set; }
        public virtual string GrauDeInstrucao { get; set; }
        public virtual string Profissao { get; set; }
        public virtual EstadoCivilEnum EstadoCivil { get; set; }
        public virtual TipoDocumentoEnum DocumentoTipo { get; set; }
        public virtual string DocumentoNumero { get; set; }
        public virtual string DocumentoDataEmissao { get; set; }
        public virtual string CPF { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual DateTime? DataDoRequerimento { get; set; }
        public virtual DateTime? DataDeAprovacaoDiretoria { get; set; }
    }
}
