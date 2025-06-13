using System;

namespace examsSystem
{
    internal class MCQQuestion : QuestionBase
    {
        public override string Header => " MCQ question ";

        public MCQQuestion(string _body = "", double _marks = 0) : base(_body, _marks)
        {
            AnswerList = new Answers[3];
        }

        public override string ToString()
        {
            return $"{Header}   Marks :{Marks}\n  {Body}\n  " +
                $"1.{AnswerList[0].AnswerText} \t\t 2.{AnswerList[1].AnswerText} \t\t 3.{AnswerList[2].AnswerText}";
        }

        public static MCQQuestion AddMCQQuestion()
        {
            MCQQuestion question = new MCQQuestion();
            Console.WriteLine(question.Header);
            Console.WriteLine("Enter the body of question");
            question.Body = Console.ReadLine();

            double marks;
            do
            {
                Console.WriteLine("Enter the marks of question (numeric value):");
            }
            while (!double.TryParse(Console.ReadLine(), out marks));  
            question.Marks = marks;

            for (int i = 0; i < question.AnswerList?.Length; i++)
            {
                question.AnswerList[i] = new Answers();
                Console.WriteLine($"Enter the choice number {i + 1}");
                question.AnswerList[i].AnswerText = Console.ReadLine();
                question.AnswerList[i].AnswerId = i + 1;
            }

            question.RightAnswer = new Answers();
            string answer = "";
            do
            {
                Console.WriteLine("Enter the correct answer (you can input the answer text directly):");
                answer = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(answer));  
            question.RightAnswer.AnswerText = answer;

            return question;
        }
    }
}
