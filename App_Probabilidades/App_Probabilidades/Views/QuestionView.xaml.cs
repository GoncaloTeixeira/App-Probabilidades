using App_Probabilidades.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_Probabilidades.Models;
namespace App_Probabilidades.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    
    public partial class Question : ContentPage
    {
        public List<Models.Question> Questions { get; set; }
        public Models.Question ActualQuestion { get; set; }
        public Player Player { get; set; }
        public Question()
        {
            Questions = new List<Models.Question>();
            ActualQuestion = new Models.Question();
            Player = new Player();
            NavigationPage.SetHasNavigationBar(this, false);// code to remove 
            InitializeComponent();
            Load_Question(1);
           

        }
        
        



        private async void Load_Question(int level)
        {
            Questions.Clear();



            string file = "Questions1.txt";
           
            if (level == 1)
            {
                file = "Questions1.txt";
               
            }else if(level == 2)
            {
                file = "Questions2.txt";
             
            }
            else if(level == 3)
            {
                file = "Questions3.txt";          
            }
            else
            {
                file = "Questions4.txt";  
            }


            using (var stream = await FileSystem.OpenAppPackageFileAsync(file))
            {
                using (var reader = new StreamReader(stream))
                {
                    
                    string auxIntro = reader.ReadLine();
                    string auxImg = reader.ReadLine();
                    
                    
                    while (reader.Peek() > -1)
                    {
                        Models.Question question = new Models.Question();
                        question.QuestionIntro = auxIntro;
                        question.QuestionImage = auxImg;
                        question.id = Int32.Parse(reader.ReadLine()); 
                        question.QuestionText = reader.ReadLine();
                        question.Right_Answer = reader.ReadLine();
                        question.Wrong_Answer1 = reader.ReadLine();
                        question.Wrong_Answer2 = reader.ReadLine();
                        question.Wrong_Answer3 = reader.ReadLine();
                        Questions.Add(question);
                       

                    }

                }

                var rand = new Random();
                int aux = rand.Next(0, Questions.Count());
                int auxRand = rand.Next(1, 5);
                //Write the question data on the view


                QuestionImage.Source = Questions[aux].QuestionImage;
                QuestionText.Text = Questions[aux].QuestionText;
                QuestionIntro.Text = Questions[aux].QuestionIntro;
                Answer1.Text = " ";
                Answer2.Text = " ";
                Answer3.Text = " ";
                Answer4.Text = " ";
                int Escrito1 = 0;
                int Escrito2 = 0;
                int Escrito3 = 0;
                int Escrito4 = 0;
                while (Answer1.Text == " " || Answer2.Text == " " || Answer3.Text == " "|| Answer4.Text == " " )
                {

                    auxRand = rand.Next(1, 5);
                    if (auxRand  == 1 &&  Escrito1 != 1)
                    {
                        if (Answer1.Text == " ")
                            Answer1.Text = Questions[aux].Wrong_Answer1;
                        else if (Answer2.Text == " ")
                            Answer2.Text = Questions[aux].Wrong_Answer1;
                        else if (Answer3.Text == " ")
                            Answer3.Text = Questions[aux].Wrong_Answer1;
                        else if (Answer4.Text == " ")
                            Answer4.Text = Questions[aux].Wrong_Answer1;
                        Escrito1 = 1;
                    }

                    if (auxRand == 2 && Escrito2 != 1)
                    {
                        if (Answer1.Text == " ")
                            Answer1.Text = Questions[aux].Wrong_Answer2;
                        else if(Answer2.Text == " ")
                            Answer2.Text = Questions[aux].Wrong_Answer2;
                        else if(Answer3.Text == " ")
                            Answer3.Text = Questions[aux].Wrong_Answer2;
                        else if(Answer4.Text == " ")
                            Answer4.Text = Questions[aux].Wrong_Answer2;
                        Escrito2 = 1;
                    }

                    if (auxRand == 3 && Escrito3 != 1)
                    {
                        if (Answer1.Text == " ")
                            Answer1.Text = Questions[aux].Wrong_Answer3;
                        else if (Answer2.Text == " ")
                            Answer2.Text = Questions[aux].Wrong_Answer3;
                        else if (Answer3.Text == " ")
                            Answer3.Text = Questions[aux].Wrong_Answer3;
                        else if (Answer4.Text == " ")
                            Answer4.Text = Questions[aux].Wrong_Answer3;
                        Escrito3 = 1;
                    }

                    if (auxRand == 4 && Escrito4 != 1 )
                    {
                        if (Answer1.Text == " ")
                            Answer1.Text = Questions[aux].Right_Answer;
                        else if (Answer2.Text == " ")
                            Answer2.Text = Questions[aux].Right_Answer;
                        else if (Answer3.Text == " ")
                            Answer3.Text = Questions[aux].Right_Answer;
                        else if (Answer4.Text == " ")
                            Answer4.Text = Questions[aux].Right_Answer;
                        Escrito4 = 1;
                    }


                }

                ActualQuestion = Questions[aux];
               
            }
           



            
        }
       
        




        private async void Play(object sender, EventArgs e)
        {
            Button Resposta = (Button)sender;
            // Ask for confirmation of choice 
            bool answer = await DisplayAlert("Atenção", "Pretendes selecionar a Opçao: " + Resposta.Text , "Sim", "Não");
            if (answer)//respondeu sim no pop up
            {
                if(Resposta.Text == ActualQuestion.Right_Answer)
                {
                    Player.Respostas_Certas++;
                    Player.R_Certas_Seguidas++;
                    Player.Adicionar_Pontuaçao();
                    if (Player.Respostas_Certas == 10)
                    {

                    }
                }
                else
                {
                    Player.Respostas_Erradas++;
                    Player.R_Certas_Seguidas=0;
                }
                Pontuacao.Text = Player.Pontuacao.ToString();
                Load_Question(Player.Get_Nivel());


                if (Player.Respostas_Erradas == 1)
                {
                    live3.IsVisible = false;
                }
                if (Player.Respostas_Erradas == 2)
                {
                    live2.IsVisible = false;
                    live3.IsVisible = false;
                }
                if (Player.Respostas_Erradas == 3)
                {
                    live1.IsVisible = false;
                    live2.IsVisible = false;
                    live3.IsVisible = false;
                }


                

            }
            else
            {

                return;
            }
        }




    
        

        
    }
}