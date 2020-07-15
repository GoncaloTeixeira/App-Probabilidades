using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Probabilidades.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rules : ContentPage
    {
        public Rules()
        { 
            InitializeComponent();
            but_retroceder.Clicked += But_retroceder_Clicked;
        }

        private async void But_retroceder_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}