using examsSystem;

public class FinalExam : Exam
{
    public override ExamType Type { get; set; } = ExamType.FinalExam;

    public FinalExam(int _time, int _numberOfQuestions) : base(_time, _numberOfQuestions)
    {
        Answers = new Answers[NumberOfQuestions];
    }

    public override void ShowExam()
    {
        base.ShowExam();
        ShowExamResult();
    }

    public void ShowExamResult()
    {
        Console.WriteLine("The Right Answers :");
        double grade = 0;

        for (int i = 0; i < Questions.Length; i++)
        {
            if (Questions[i].GetType().Name == "MCQQuestions")
            {
                string answer = "";
                string[] arr = Questions[i].RightAnswer.AnswerText.Split(',');

                for (int j = 0; j < arr?.Length; j++)
                {
                    if (arr[j] == Questions[i].AnswerList[j].AnswerText)
                    {
                        answer += Questions[i].AnswerList[j].AnswerText + " ";
                    }
                }

                Console.WriteLine($"Question {i + 1} [{Questions[i].Body}] : {answer}");
            }
            else
            {
                Console.WriteLine($"Question {i + 1} [{Questions[i].Body}] : {Questions[i].RightAnswer.AnswerText}");
            }

            if (Answers[i].AnswerText == Questions[i].RightAnswer.AnswerText)
            {
                grade += Questions[i].Marks;
            }
        }

        Console.WriteLine($"Your Grade is {grade} From {ExamGrade}");
    }
}
