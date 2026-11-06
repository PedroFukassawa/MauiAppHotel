using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    List<Quarto> lista_quartos = new()
    {
        new Quarto { Nome = "Suíte Master", ValorAdultos = 200, ValorCriancas = 180 },
        new Quarto { Nome = "Suíte Premium", ValorAdultos = 150.5, ValorCriancas = 110 },
        new Quarto { Nome = "Suíte Viajante", ValorAdultos = 110.5, ValorCriancas = 90 },
        new Quarto { Nome = "Suíte Crise", ValorAdultos = 95, ValorCriancas = 55 }
    };
    public ContratacaoHospedagem()
	{
		InitializeComponent();

        pck_quarto.ItemsSource = lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(3);

        dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
        dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(4);
    }
		
    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new()
            {
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                QuartoEscolhido = (Quarto)pck_quarto.SelectedItem,
                DataCheckin = dtpck_checkin.Date.Value,
                DataCheckout = dtpck_checkout.Date.Value,
            };

            Navigation.PushAsync(new HospedagemContratada
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Ops!", ex.Message, "OK");
        }
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        {
            try
            {
                Navigation.PushAsync(new Sobre());
            }

            catch (Exception ex)
            {
                DisplayAlertAsync("Erro", ex.Message, "OK");
            }
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_checkout.MinimumDate = e.NewDate?.AddDays(1);
    }
}