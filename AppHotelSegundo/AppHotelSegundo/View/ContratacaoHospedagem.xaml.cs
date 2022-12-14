using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppHotelSegundo.Model;

namespace AppHotelSegundo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContratacaoHospedagem : ContentPage
    {

        App PropriedadesApp;


        public ContratacaoHospedagem()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;

            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

            dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
            dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);

            //dtpck_checkout.MinimumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker elemento = (DatePicker)sender;

            DateTime data_selecionada_checkin = elemento.Date;

            dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
            dtpck_checkout.MaximumDate = data_selecionada_checkin.Date.AddMonths(6);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Hospedagem h = new Hospedagem()
                {
                    QntAdultos = Convert.ToInt32(stp_adultos.Value),
                    QntCriancas = Convert.ToInt32(stp_criancas.Value),
                    Suite = (Quarto)pck_quarto.SelectedItem,
                    DataCheckIn = dtpck_checkin.Date,
                    DataCheckOut = dtpck_checkout.Date
                };

                Navigation.PushAsync(new HospedagemCalculada()
                {
                    BindingContext = h
                });

            } catch(Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }

        }
    }
}