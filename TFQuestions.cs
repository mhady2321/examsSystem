using System;

namespace examsSystem
{
    public class TFQuestions : QuestionBase
    {
        public override string Header { get; } = " True or False ";
        public TFQuestions(string _body = "", double _marks = 0) : base(_body, _marks)
        {
            AnswerList = new Answers[2];
            AnswerList[0] = new Answers("True", 1);
            AnswerList[1] = new Answers("False", 2);
        }

        public override string ToString()
        {
            return $"{Header}   Marks :{Marks}\n  {Body}\n  " +
                $"1.{AnswerList[0].AnswerText} \t\t 2.{AnswerList[1].AnswerText}";
        }

        public static TFQuestions AddTFQuestion()
        {
            TFQuestions question = new TFQuestions();
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

            question.RightAnswer = new Answers();
            int id;
            do
            {
                Console.WriteLine("Enter the correct answer ... 1 for True , 2 for False ");
            }
            while (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > 2);  
            question.RightAnswer.AnswerId = id;
            question.RightAnswer.AnswerText = question.AnswerList[id - 1].AnswerText;

            return question;
        }
    }
}
