using ConsoleAppExamples.Model.Enums;

namespace ConsoleAppExamples.Model
{
    public class Venda : Pagamento
    {
        public Guid Guid { get; set; }
        public decimal ValorTotal { get; set; }
        public ETipoPagamento TipoPagamento { get; set; }
        public Venda() { }

        public void Pagamento(ETipoPagamento tipoPagamento)
        {
            TipoPagamento = tipoPagamento;
            throw new NotImplementedException();
        }
    }
}
