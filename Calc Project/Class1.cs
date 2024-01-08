using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_Project
{
    public class Class1
    {

        private int number1;
        private int number2;
        private string answer;
        private int rightAnswer;
        private string rightAnswerString;

        public Class1(int gameKind, char oper)
        {
            // check out switch
            Random random = new Random();
            number1 = random.Next(1, 11);
            number2 = random.Next(1, 11);
            if (oper == '+')
            {
                this.rightAnswer = this.number1 + this.number2;
                this.rightAnswerString = this.rightAnswer.ToString();
            }
            else if (oper == '-')
            {
                this.rightAnswer = number1 - number2;
                this.rightAnswerString = this.rightAnswer.ToString();
            }
            else if (oper == '*')
            {
                this.rightAnswer = number1 * number2;
                this.rightAnswerString = this.rightAnswer.ToString();
            }
            else if (oper == '/')
            {
                this.rightAnswer = number1 / number2;
                this.rightAnswerString = this.rightAnswer.ToString();
            }
        }

        public int GetNumber1()
        {
            return number1;
        }

        public void setNumber1(int value)
        {
            number1 = value;
        }

        public int GetNumber2()
        {
            return number2;
        }


        public void SetNumber2(int value)
        {
            number2 = value;
        }
        public string GetAnswer()
        {
            return answer;
        }
        public void SetAnswer(string value)
        {
            answer = value;
        }

        public int GetRightAnswer()
        {
            return rightAnswer;
        }
        public void setRightAnswer(int value)
        {
            rightAnswer = value;
        }

        public string GetRightAnswerString()
        {
            return rightAnswerString;
        }

        public bool CheckRightAnswer()
        {
            return rightAnswerString == answer;
        }
    }
}


