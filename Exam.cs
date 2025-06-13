namespace examsSystem
{
    public enum ExamType { practicalExam = 1, FinalExam = 2 }

    public abstract class Exam
    {
        private int time;
        private int numberOfQuestions;
        private double examGrade;
        private QuestionBase[] questions;
        private Answers[] answers;

        public abstract ExamType Type { get; set; }

        public int Time
        {
            get => time;
            set => time = value;
        }

        public int NumberOfQuestions
        {
            get => numberOfQuestions;
            set => numberOfQuestions = value;
        }

        public double ExamGrade
        {
            get => examGrade;
            set => examGrade = value;
        }

        public QuestionBase[] Questions
        {
            get => questions;
            set => questions = value;
        }

        public Answers[] Answers
        {
            get => answers;
            set => answers = value;
        }

        public Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            ExamGrade = 0;
            Questions = new QuestionBase[NumberOfQuestions];
            Answers = new Answers[NumberOfQuestions];
        }

        public virtual void ShowExam()
        {
            for (int i = 0; i < Questions?.Length; i++)
            {
                Answers[i] = new Answers();

                Console.WriteLine(Questions[i]);
                Console.WriteLine("=======================");

                if (Questions[i] is MCQQuestion)
                {
                    string input;
                    do
                    {
                        Console.Write("Enter your answer(s) (e.g., 1,3): ");
                        input = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(input));

                    Answers[i].AnswerText = input.Trim();
                }
                else
                {
                    int id;
                    do
                    {
                        Console.Write("Enter your answer ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out id));

                    Answers[i].AnswerId = id;

                    var selectedAnswer = Questions[i][id];
                    Answers[i].AnswerText = selectedAnswer.AnswerText;
                }

                Console.WriteLine("========================\n");
            }
        }
    }
}
