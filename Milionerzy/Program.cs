using System;
using System.Collections.Generic;

namespace Milionerzy
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                List<Question> questions = GenerateQuestions();
                int currentQuestionIndex = 0;
                int moneyWon = 0;

                Console.WriteLine("Witaj w grze Milionerzy!");

                while (currentQuestionIndex < questions.Count)
                {
                    Question currentQuestion = questions[currentQuestionIndex];
                    Console.WriteLine($"Pytanie {currentQuestionIndex + 1}: {currentQuestion.Text}");
                    currentQuestion.DisplayOptions();
                    Console.Write("Wybierz odpowiedź (wpisz literę): ");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == currentQuestion.CorrectAnswer)
                    {
                        Console.WriteLine("Poprawna odpowiedź!");
                        moneyWon += currentQuestion.Prize;
                        Console.WriteLine($"Wygrana: {moneyWon} zł");
                    }
                    else
                    {
                        Console.WriteLine("Niestety, zła odpowiedź!");
                        Console.WriteLine($"Zakończono grę. Wygrana: {moneyWon} zł");
                        break;
                    }

                    currentQuestionIndex++;
                }

                Console.WriteLine("Czy chcesz zagrać ponownie? (T/N)");
                string playAgainInput = Console.ReadLine().ToUpper();
                playAgain = (playAgainInput == "T");
            }

            Console.WriteLine("Koniec gry. Dziękujemy za udział!");
            Console.ReadLine();
        }

        static List<Question> GenerateQuestions()
        {
            List<Question> questions = new List<Question>();

            questions.Add(new Question("Jak nazywa się główny bohater serii gier Gothic?", new List<string> { "A. Bury Zenek", "B. Nie posiada imienia", "C. Diego", "D. Javier" }, "B", 1000));
            questions.Add(new Question("Kto jest ojcem Luke'a w słynnej serii 'Star Wars'?", new List<string> { "A. Vader", "B. Han Solo", "C. Boba Fett", "D. Obi Wan Kenobi" }, "A", 2000));
            questions.Add(new Question("Która z podanych gier wyszła tylko i wyłącznie na konsole firmy Sony?", new List<string> { "A. Dark Souls", "B. Diablo 3", "C. Fifa 23", "D. Bloodborne" }, "D", 3000));
            questions.Add(new Question("W którym roku zmarł papież Jan Paweł 2?", new List<string> { "A. 1999", "B. 2012", "C. 2005", "D. Nie wiem, choć się domyślam" }, "C", 5000));
            questions.Add(new Question("Która gra została grą roku 2022?", new List<string> { "A. God of War: Ragnarok", "B. Elden Ring", "C. The Callisto Protocol", "D. Lego Star Wars: Skywalker saga" }, "B", 10000));
            questions.Add(new Question("W którym roku zmarł wokalista zespołu Linkin Park - Chester Bennington?", new List<string> { "A. 2015", "B. 2018", "C. 2017", "D. 2009" }, "C", 20000));
            questions.Add(new Question("Z jakiego kraju pochodzi słynny zespół metalowy Rammstein?", new List<string> { "A. Niemcy", "B. Francja", "C. Stany Zjednoczone", "D. Polska" }, "A", 50000));
            questions.Add(new Question("Jak nazywa się wokalista Polskiego zespołu metalowego - Nocny Kochanek?", new List<string> { "A. Krzysztof Sokołowski", "B. Piotr Kupicha", "C. Michał Wiśniewski", "D. Krzysztof Krawczyk" }, "A", 100000));
            questions.Add(new Question("Który z wokalistów był w sporze z wokalistą zespołu 'Nirvana' Kurtem Cobainem?", new List<string> { "A. Axel Rose", "B. Brian Johnson", "C. Paul Stanley", "D. David Coverdale" }, "A", 500000));
            questions.Add(new Question("Który z podanych albumów wyszedł jako najwcześniej?", new List<string> { "A. Linkin Park - Hybrid Theory", "B. Three Days Grace - One-X", "C. Breaking Benjamin - Phobia", "D. Rammstein - Mutter" }, "A", 1000000));

            return questions;
        }
    }

    class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public int Prize { get; set; }

        public Question(string text, List<string> options, string correctAnswer, int prize)
        {
            Text = text;
            Options = options;
            CorrectAnswer = correctAnswer;
            Prize = prize;
        }

        public void DisplayOptions()
        {
            foreach (var option in Options)
            {
                Console.WriteLine(option);
            }
        }
    }
}