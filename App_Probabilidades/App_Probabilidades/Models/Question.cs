using System;
using System.Collections.Generic;
using System.Text;

namespace App_Probabilidades.Models
{
    public class Question
    {
        public int id { get; set; }
        public string QuestionText { get; set; }
        public string QuestionIntro { get; set; }
        public string QuestionImage { get; set; }

        public string Right_Answer { get; set; }
        public string Wrong_Answer1 { get; set; }
        public string Wrong_Answer2 { get; set; }

        public string Wrong_Answer3 { get; set; }


 
    }
}
