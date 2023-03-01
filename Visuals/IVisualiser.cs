using System;

namespace ConsoleVisualiser
{
    public interface IVisualizer
    {

        void DrawAnswerStatus(bool correct, QuizAnswerQuestion correctAnswer);

        void DrawQuizQuestion(QuizQuestion question, Guid highlighedAnswerId);

        void DrawGameResult(int totalQuestionCount, int correctAnswersCount);

        void DrawGameStart(int totalQuestionCount);

        void DrawNoQuestion();

        void DrawPlayAgain();


    }
}