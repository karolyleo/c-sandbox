namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // finds the previous-game.txt
            string filePath = txtToLog(); 

            // Returns the results of the guessing game in a string array so that it can be saved        
            string[] gameResult = guesingGame();

            // Saves everything to the txt ------------------->
            File.AppendAllLines(filePath, gameResult);
        }

        // Creates or verifys the Game-logs
        static string txtToLog()
        {
            // Hardcoded path
            string folderPath = "/home/karolleo000/IdeaProjects/c-sandbox/c-sandbox/hello-world/Game-logs/";

            // File to be located
            string filePath = Path.Combine(folderPath, "Previous-Game.txt");

            // Creation/Verification of file
            try
            {
                Directory.CreateDirectory(folderPath);

                // Ensure our stuff runs!
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "This is a new file.");
                    Console.WriteLine("First time playing, welcome!");
                } 
                else 
                {
                    Console.WriteLine("Resetting Saved Game");
                }
            }
            catch (Exception ex)
            {
                // Note the $ before our " " and variables can be place inside of { }
                Console.WriteLine($"An error occured: {ex.Message}");
            }

            // return path
            return filePath;
        }
        
        // Returns the results of the guessing game in a string array so that it can be saved
        static string[] guesingGame()
        {
            Random random = new Random();

            Console.Out.WriteLine("Let's play a guessing game");
            int ranDum = random.Next(1, 10), tries = 0;
            bool playOn = true;
            List<string> gameLog = new List<string>();
            gameLog.Add("----------New Game----------");
            gameLog.Add($"The random number generated is {ranDum}");

            while (playOn)
            {
                Console.WriteLine("Guess a number");
                int userInput;
            
                tries++;

                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());

                    // Custom msg for the file
                    gameLog.Add($"On try {tries}, the user guessed {userInput}");

                    if ( !highLow(userInput, ranDum)) 
                    {
                        gameLog.Add("Congrats on Winning!");
                        playOn = false;
                        break;
                    }

                    if (tries > 3)
                {
                    playOn = false;
                    string loss = "All tries used up... You lost!";
                    Console.WriteLine(loss);

                    // Add to our log
                    gameLog.Add(loss);
                }

                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }
            return gameLog.ToArray();
        }

        
        // Evaluates the user input vs the random number
        static bool highLow(int guess, int random)
        {
            int comparisonResult = guess.CompareTo(random);

            switch (comparisonResult)
            {
                case -1:
                    Console.WriteLine("Too low");
                    return true;
                case 1:
                    Console.WriteLine("Too high");
                    return true;
                default:
                    Console.WriteLine("Nice guess, you win!");
                    return false;
            }
        }

    }
}