using MauiAppHotel.Models;

namespace MauiAppHotel.Models

{
    public class Hospedagem
{
    public Quarto QuartoEscolhido { get; set; }
    public int QntAdultos { get; set; }
    public int QntCriancas { get; set; }
    public DateTime DataCheckin { get; set; }
    public DateTime DataCheckout { get; set; }

    public int Estadia
    {
        get => DataCheckout.Subtract(DataCheckin).Days;
    }

    public double TotalHospedagem
    {
        get
        {
            double preco_adultos = QntAdultos * QuartoEscolhido.ValorAdultos;
            double preco_criancas = QntCriancas * QuartoEscolhido.ValorCriancas;

                double total_adultos = Math.Round(preco_adultos, 2);
                double total_criancas = Math.Round(preco_criancas, 2);

                return (total_adultos + total_criancas) * Estadia;
        }
    }
}
}