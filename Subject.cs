using System;

namespace examsSystem
{
    public class Subject
    {
        private string name;
        private int id;
        private Exam subExam;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Exam SubExam
        {
            get { return subExam; }
            set { subExam = value; }
        }

        public Subject(string _name, int _id, Exam _subExam)
        {
            name = _name;
            id = _id;
            subExam = _subExam;
        }

        public Subject(int _id, string _name) : this(_name, _id, new PracticalExam(60, 3))
        {
        }

        public override string ToString()
        {
            return $"Subject Name: {Name}\nSubject Id: {Id}\nExam Type: {SubExam?.Type}";
        }

        public void CreateExam()
        {
            int time, type;

            do
            {
                Console.WriteLine("Please Choose The Type of The Exam [1 for Practical, 2 for Final]:");
            } while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 2);

            subExam.Type = (ExamType)type;

            do
            {
                Console.WriteLine("Please Choose The Time of The Exam in Minutes:");
            } while (!int.TryParse(Console.ReadLine(), out time) || time < 1 || time > 180);

            subExam.Time = time;

            int numberOfQuestions;
            do
            {
                Console.WriteLine("Please Enter Number of Questions:");
            } while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0);

            if (subExam.Type == ExamType.practicalExam)
            {
                subExam = new PracticalExam(time, numberOfQuestions);
                subExam.Questions = QuestionBase.CreateBaseQuestions(numberOfQuestions);
            }
            else
            {
                subExam = new FinalExam(time, numberOfQuestions);
                subExam.Questions = QuestionBase.CreateBaseQuestions(numberOfQuestions);
            }

            for (int i = 0; i < subExam.Questions.Length; i++)
            {
                subExam.ExamGrade += subExam.Questions[i].Marks;
            }
        }

        public void TakeExam()
        {
            for (int i = 0; i < subExam.Questions.Length; i++)
            {
                Console.WriteLine(subExam.Questions[i].ToString());

                int selectedAnswerId;
                bool isAnswerValid = false;

                do
                {
                    Console.WriteLine("Enter the correct answer (choose the number):");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out selectedAnswerId) &&
                        selectedAnswerId >= 1 && selectedAnswerId <= subExam.Questions[i].AnswerList.Length)
                    {
                        isAnswerValid = true;
                      
                        subExam.Answers[i] = subExam.Questions[i][selectedAnswerId];
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer. Please choose a valid answer number.");
                    }
                } while (!isAnswerValid);
            }
        }
    }
}
