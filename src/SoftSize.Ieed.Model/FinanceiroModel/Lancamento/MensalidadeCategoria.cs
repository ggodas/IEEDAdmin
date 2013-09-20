using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Model.FinanceiroModel.Lancamento
{
    public class MensalidadeCategoria : Entity, IAggregateRoot
    {
        public virtual string Descricao { get; set; }
        public virtual decimal Valor { get; set; }
    }
}
