using System;

namespace examsSystem
{
    public class ChooseOneQuestion : QuestionBase
    {
        public override string Header { get; } = "Choose One Question";

        public ChooseOneQuestion(string _body = "", double _marks = 0) : base(_body, _marks)
        {
            AnswerList = new Answers[3];
        }

        public override string ToString()
        {
            return $"{Header}   Marks :{Marks}\n  {Body}\n  " +
                $"1.{AnswerList[0].AnswerText} \t\t 2.{AnswerList[1].AnswerText} \t\t 3.{AnswerList[2].AnswerText}";
        }

        public static ChooseOneQuestion AddChooseOneQuestion()
        {
            ChooseOneQuestion question = new ChooseOneQuestion();
            Console.WriteLine(question.Header);
            Console.WriteLine("Enter the body of question");
            question.Body = Console.ReadLine();
            Console.WriteLine("Enter the marks of question ");
            question.Marks = double.Parse(Console.ReadLine());

            for (int i = 0; i < question.AnswerList?.Length; i++)
            {
                question.AnswerList[i] = new Answers();
                Console.WriteLine($"Enter the choice number {i + 1}");
                question.AnswerList[i].AnswerText = Console.ReadLine();
                question.AnswerList[i].AnswerId = i + 1;
            }

            question.RightAnswer = new Answers();
            int id;
            do
            {
                Console.WriteLine("Enter the right answer ... 1, 2, or 3 ");
            }
            while (!int.TryParse(Console.ReadLine(), out id) || id > 3 || id < 1);

            
            question.RightAnswer.AnswerText = question.AnswerList[id - 1].AnswerText;
            question.RightAnswer.AnswerId = id;

            return question;
        }

      
        public bool IsCorrectAnswer(string answer)
        {
            return string.Equals(answer.Trim(), RightAnswer.AnswerText.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
