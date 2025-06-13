namespace examsSystem
{
    public class Answers
    {
        public string AnswerText { get; set; }
        public int AnswerId { get; set; }

        public Answers(string answerText, int answerId)
        {
            AnswerText = answerText;
            AnswerId = answerId;
        }

        public Answers() { }
    }
}
