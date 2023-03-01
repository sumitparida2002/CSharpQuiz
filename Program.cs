using System;

namespace QuizGame
{
    public class Program
    {
        public static IVisualizer Visualizer { get; } = new ConsoleVisualizer();
        public static void Main()
        {
            bool run;
            do
            {
                IEnumerable<QuizQuestion> questions = Program.GetQuestions();

                if (questions.Any())
                {
                    Program.RunGameLoop(questions);
                }
                else
                {
                    Program.GameVisualizer.DrawNoQuestions();
                }
            } while (run);
        }

        private static void RunGameLoop(IEnumberable<QuizQuestion> questions)
        {
            RunGameLoop gameLoop = new RunGameLoop(Program.Visualizer, questions);

            while (!gameLoop.isFinished)
            {
                gameLoop.DoTick();
            }
            Program.Visualizer.DrawPlayAgain();
        }

        private static IEnumerable<QuizQuestion> GetQuestions()
        {
            string filePath = ".\\game_questions.json";
            IQuizQuestionSerializer serializer = new FileQuizQuestionSerializer(filePath);
            return serializer.DeserializeQuestions();
        }
    }
}