using System;
using System.Collections.Generic;
using System.Linq;

namespace Milionerzy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool playAgain = true;

                while (playAgain)
                {
                    Dictionary<int, Question> questions = GenerateQuestionsWithIds();
                    Dictionary<int, int> questionPrizes = GenerateQuestionPrizes(); // Przechowuje nagrody dla pytań
                    ShuffleQuestions(questions); // Losowanie pytań
                    int currentQuestionIndex = 0;
                    int moneyWon = 0;

                    Console.WriteLine("Witaj w grze Milionerzy!");

                    while (currentQuestionIndex < questions.Count)
                    {
                        Question currentQuestion = questions[currentQuestionIndex];
                        Console.WriteLine($"Pytanie {currentQuestion.Id}: {currentQuestion.Text}");
                        currentQuestion.DisplayOptions();
                        Console.Write("Wybierz odpowiedź (wpisz literę): ");
                        string answer = Console.ReadLine().ToUpper();

                        if (answer == currentQuestion.CorrectAnswer)
                        {
                            Console.WriteLine("Poprawna odpowiedź!");
                            moneyWon += questionPrizes[currentQuestion.Id]; // Używa ID pytania do pobrania nagrody z słownika
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }

            Console.ReadLine();
        }

        static Dictionary<int, Question> GenerateQuestionsWithIds()
        {
            Dictionary<int, Question> questions = new Dictionary<int, Question>();

            questions.Add(0, new Question(0, "Jak nazywa się główny bohater serii gier Gothic?", new List<string> { "A. Bury Zenek", "B. Nie posiada imienia", "C. Diego", "D. Javier" }, "B"));
            questions.Add(1, new Question(1, "Kto jest ojcem Luke'a w słynnej serii 'Star Wars'?", new List<string> { "A. Vader", "B. Han Solo", "C. Boba Fett", "D. Obi Wan Kenobi" }, "A"));
            questions.Add(2, new Question(2, "Która z podanych gier wyszła tylko i wyłącznie na konsole firmy Sony?", new List<string> { "A. Dark Souls", "B. Diablo 3", "C. Fifa 23", "D. Bloodborne" }, "D"));
            questions.Add(3, new Question(3, "W którym roku zmarł papież Jan Paweł 2?", new List<string> { "A. 1999", "B. 2012", "C. 2005", "D. Nie wiem, choć się domyślam" }, "C"));
            questions.Add(4, new Question(4, "Która gra została grą roku 2022?", new List<string> { "A. God of War: Ragnarok", "B. Elden Ring", "C. The Callisto Protocol", "D. Lego Star Wars: Skywalker saga" }, "B"));
            questions.Add(5, new Question(5, "W którym roku zmarł wokalista zespołu Linkin Park - Chester Bennington?", new List<string> { "A. 2015", "B. 2018", "C. 2017", "D. 2009" }, "C"));
            questions.Add(6, new Question(6, "Z jakiego kraju pochodzi słynny zespół metalowy Rammstein?", new List<string> { "A. Niemcy", "B. Francja", "C. Stany Zjednoczone", "D. Polska" }, "A"));
            questions.Add(7, new Question(7, "Jak nazywa się wokalista Polskiego zespołu metalowego - Nocny Kochanek?", new List<string> { "A. Krzysztof Sokołowski", "B. Piotr Kupicha", "C. Michał Wiśniewski", "D. Krzysztof Krawczyk" }, "A"));
            questions.Add(8, new Question(8, "Który z wokalistów był w sporze z wokalistą zespołu 'Nirvana' Kurtem Cobainem?", new List<string> { "A. Axel Rose", "B. Brian Johnson", "C. Paul Stanley", "D. David Coverdale" }, "A"));
            questions.Add(9, new Question(9, "Który z podanych albumów wyszedł jako najwcześniej?", new List<string> { "A. Linkin Park - Hybrid Theory", "B. Three Days Grace - One-X", "C. Breaking Benjamin - Phobia", "D. Rammstein - Mutter" }, "A"));
            questions.Add(10, new Question(10, "W którym roku wyszła gra Diablo 3?", new List<string> { "A. 2012", "B. 2015", "C. 2013", "D. 2020" }, "A"));
            questions.Add(11, new Question(11, "Jaką ocenę na metacritic ma Diablo 4?", new List<string> { "A. 5.4", "B. 1.5", "C. 2.2", "D. 7.4" }, "C"));
            questions.Add(12, new Question(12, "Która z podanych gier pochodzi od studia fromsoftware?", new List<string> { "A. The Surge", "B. Lords of the Fallen", "C. King's field", "D. Ratchet & Clank" }, "C"));
            questions.Add(13, new Question(13, "Które studio było kiedyś uważane za synonim jakości?", new List<string> { "A. Bethesda", "B. Blizzard", "C. CI Games", "D. Santa Monica Studio" }, "B"));
            questions.Add(14, new Question(14, "W którym roku wyszła pierwsza część Dark Souls?", new List<string> { "A. 2007", "B. 2010", "C. 2011", "D. 2009" }, "C"));
            questions.Add(15, new Question(15, "Jak nazywa się słynny mędrzec pojawiający się w serii diablo w częściach 1-3?", new List<string> { "A. Griswold", "B. Decard Cain", "C. Horazon", "D. Akara" }, "B"));
            questions.Add(16, new Question(16, "Kto w grze 'Elden Ring' zniszczył tytułowy eldeński krąg?", new List<string> { "A. Marika", "B. Radagon", "C. Godfrey", "D. Godwyn" }, "A"));
            questions.Add(17, new Question(17, "Jak nazywa się mroczny Bóg przedstawiony w grach z serii Gothic?", new List<string> { "A. Zuben", "B. Vatras", "C. Śniący", "D. Beliar" }, "D"));
            questions.Add(18, new Question(18, "Z którym z magów Pyrokar z serii Gothic miał konflikt?", new List<string> { "A. Vatras", "B. Saturas", "C. Cavalorn", "D. Xardas" }, "D"));
            questions.Add(19, new Question(19, "W którym roku wyszła gra 'Baldur's Gate 2'?", new List<string> { "A. 1999", "B. 2000", "C. 1998", "D. 2001" }, "B"));
            questions.Add(20, new Question(20, "Do nazywa się 4 część serii The Elder Scrolls?", new List<string> { "A. Arena", "B. Daggerfall", "C. Morrowind", "D. Oblivion" }, "D"));
            questions.Add(21, new Question(21, "W którym roku wyszła gra League of Legends?", new List<string> { "A. 2015", "B. 2006", "C. 2009", "D. 2005" }, "C"));
            questions.Add(22, new Question(22, "Która z wymienionych serii miała swoje początki za czasów konsoli Playstation 2?", new List<string> { "A. Crash Bandicoot", "B. Ratchet & Clank", "C. The last of us", "D. Dark Souls" }, "B"));
            questions.Add(23, new Question(23, "W którym roku wyszedł remaster najpopularniejszej częśći serii Diablo - Diablo 2?", new List<string> { "A. 2021", "B. 2020", "C. 2022", "D. 2023" }, "A"));

            return questions;
        }

        static Dictionary<int, int> GenerateQuestionPrizes()
        {
            // Nagrody dla pytań, gdzie klucz to ID pytania, a wartość to wygrana
            Dictionary<int, int> questionPrizes = new Dictionary<int, int>();
            questionPrizes.Add(0, 1000);
            questionPrizes.Add(1, 2000);
            questionPrizes.Add(2, 3000);
            questionPrizes.Add(3, 5000);
            questionPrizes.Add(4, 10000);
            questionPrizes.Add(5, 20000);
            questionPrizes.Add(6, 50000);
            questionPrizes.Add(7, 100000);
            questionPrizes.Add(8, 500000);
            questionPrizes.Add(9, 1000000);
            questionPrizes.Add(10, 1000);
            questionPrizes.Add(11, 2000);
            questionPrizes.Add(12, 3000);
            questionPrizes.Add(13, 5000);
            questionPrizes.Add(14, 10000);
            questionPrizes.Add(15, 20000);
            questionPrizes.Add(16, 50000);
            questionPrizes.Add(17, 100000);
            questionPrizes.Add(18, 500000);
            questionPrizes.Add(19, 1000000);
            questionPrizes.Add(20, 1000);
            questionPrizes.Add(21, 2000);
            questionPrizes.Add(22, 3000);
            questionPrizes.Add(23, 5000);
            return questionPrizes;
        }

        static void ShuffleQuestions(Dictionary<int, Question> questions)
        {
            Random rng = new Random();
            int n = questions.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Question value = questions.ElementAt(k).Value;
                questions[questions.ElementAt(k).Key] = questions.ElementAt(n).Value;
                questions[questions.ElementAt(n).Key] = value;
            }
        }
    }

    class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }

        public Question(int id, string text, List<string> options, string correctAnswer)
        {
            Id = id;
            Text = text;
            Options = options;
            CorrectAnswer = correctAnswer;
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