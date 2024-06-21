
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppExamples.Model.Enums
{
    public enum ETipoPagamento
    {
        [Display(Name = "Cartão de Crédito", ShortName = "CCR")]
        CartaoCredito = 1,

        [Display(Name = "Cartão de Débito", ShortName = "CDE")]
        CartaoDebito = 2,

        [Display(Name = "Dinheiro", ShortName = "DIN")]
        Dinheiro = 3,

        [Display(Name = "Cheque", ShortName = "CHQ")]
        Cheque = 4,

        [Display(Name = "Boleto", ShortName = "BOL")]
        Boleto = 5,
    }
}
