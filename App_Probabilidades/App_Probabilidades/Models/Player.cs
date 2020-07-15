using System;
using System.Collections.Generic;
using System.Text;

namespace App_Probabilidades.Models
{
    public class Player
    {
        public int Nome { get; set; }

        public int Pontuacao { get; set; }

        public int Multiplicador { get; set; }
       
        public int Respostas_Erradas { get; set; }// Maximo de 3 respostas erradas
        public int Respostas_Certas { get; set; }
        public int R_Certas_Seguidas { get; set; }
        public void Actualizar_Multiplicador()
        {
            if(R_Certas_Seguidas>=3 && R_Certas_Seguidas < 6)
            {
                Multiplicador = 2;
            }else if (R_Certas_Seguidas >= 6 && R_Certas_Seguidas < 9)
            {
                Multiplicador = 3;
            }else if (R_Certas_Seguidas == 9 )
            {
                Multiplicador = 5;
            }
            else
            {
                Multiplicador = 1;
            }
        }
        public int Get_Nivel()
        {
            if(Respostas_Certas >=3 && Respostas_Certas < 6)
            {
                return 2;
            }else if (Respostas_Certas >= 6 && Respostas_Certas < 9)
            {
                return 3;
            }else if (Respostas_Certas >= 9)
            {
                return 4;
            }else
            {
                return 1;
            }
        }
        public void Adicionar_Pontuaçao()
        {
            Actualizar_Multiplicador();
            int Nivel = Get_Nivel();
            Pontuacao += Nivel * Multiplicador;
            return;
        }
 
        public int VerificarAcabarJogo()
        {
            if (Respostas_Erradas == 3)
            {

            }


            return 1;
        } 
    }
    
}
