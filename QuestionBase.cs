using examsSystem;

public abstract class QuestionBase
{
    protected string _body;
    protected double _marks;
    private Answers[] _answerList;
    private Answers _rightAnswer;

    public abstract string Header { get; }

    public string Body { get => _body; set => _body = value; }

    public double Marks { get => _marks; set => _marks = value; }

    public Answers RightAnswer { get => _rightAnswer; set => _rightAnswer = value; }

    public Answers[] AnswerList { get => _answerList; set => _answerList = value; }

    private Answers FindAnswer(Predicate<Answers> predicate)
    {
        if (_answerList == null) return new Answers();
        return _answerList.FirstOrDefault(a => predicate(a)) ?? new Answers();
    }

    public Answers this[int id] => FindAnswer(a => a.AnswerId == id);

    public Answers this[string text] => FindAnswer(a => a.AnswerText == text);

    public QuestionBase(string body, double marks)
    {
        Body = body;
        Marks = marks;
    }

    public static QuestionBase[] CreateBaseQuestions(int size)
    {
        var questions = new QuestionBase[size];

        for (int i = 0; i < size; i++)
        {
            int questionType;
            do
            {
                Console.WriteLine($"Enter type for question {i + 1} [1: T/F, 2: Choose One, 3: MCQ]");
            } while (!int.TryParse(Console.ReadLine(), out questionType) || questionType < 1 || questionType > 3);

            switch (questionType)
            {
                case 1:
                    Console.WriteLine($"Enter data for True/False Question {i + 1}");
                    questions[i] = TFQuestions.AddTFQuestion();
                    break;
                case 2:
                    Console.WriteLine($"Enter data for Choose One Question {i + 1}");
                    questions[i] = ChooseOneQuestion.AddChooseOneQuestion();
                    break;
                case 3:
                    Console.WriteLine($"Enter data for MCQ Question {i + 1}");
                    questions[i] = MCQQuestion.AddMCQQuestion();
                    break;
            }
        }

        return questions;
    }
}
