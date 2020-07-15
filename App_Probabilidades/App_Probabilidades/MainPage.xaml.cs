using App_Probabilidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Probabilidades
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static Player player { get; set; }
        
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
           
            InitializeComponent();
            player = new Player();
        }
       

         private async void Bt_scoreBoard_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ScoreBoard());
        }

        private async void Bt_rules_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Rules());
        }

        private async void Bt_play_Clicked(object sender, EventArgs e)
        {
            //var Pergunta = new Pergunta();
            await  Navigation.PushAsync(new Views.Question());
           
        }
    }
}
