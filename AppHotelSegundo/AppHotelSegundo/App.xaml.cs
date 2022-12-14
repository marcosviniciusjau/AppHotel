using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.Generic;
using System.Globalization;
using System.Threading;

using AppHotelSegundo.Model;
using AppHotelSegundo.View;

namespace AppHotelSegundo
{
    public partial class App : Application
    {
        public List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto()
            {
                Descricao = "Suíte Super Luxo",
                ValorDiariaAdulto = 110.0,
                ValorDiariaCrianca = 55.0
            },
            new Quarto()
            {
                Descricao = "Suíte Luxo",
                ValorDiariaAdulto = 80,
                ValorDiariaCrianca = 40
            },
            new Quarto()
            {
                Descricao = "Suíte Single",
                ValorDiariaAdulto = 50,
                ValorDiariaCrianca = 25
            },
            new Quarto()
            {
                Descricao = "Suite Crise",
                ValorDiariaAdulto = 25,
                ValorDiariaCrianca = 12.5
            }
        };


        public App()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            MainPage = new NavigationPage(new ContratacaoHospedagem());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
