namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            // Console.Out.WriteLine("Let's play a guessing game");
            int ranDum = random.Next(1, 10), num = 0;
            bool playOn = true;

            while (playOn)
            {
                // Console.WriteLine("Guess a number");
                // int userInput;
                for(int i = 0; i < num;i++)
                {
                Console.WriteLine("Hey!");
                }
                num++;

                if (num > 99)
                {
                    playOn = false;
                }

                try
                {
                    // userInput = Convert.ToInt32(Console.ReadLine());

                    // highLow(userInput, ranDum);

                    // playOn = keepPlaying(userInput);

                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }
        }
        static void highLow(int guess, int random)
        {
            int comparisonResult = guess.CompareTo(random);

            switch (comparisonResult)
            {
                case -1:
                    Console.WriteLine("Too low");
                    break;
                case 1:
                    Console.WriteLine("Too high");
                    break;
                default:
                    Console.WriteLine("Nice guess, you win!");
                    break;
            }
        }

        static bool keepPlaying(int userInput)
        {
            Console.WriteLine("If you want to stop playing, input 0, you have selected: " + userInput);

            return userInput != 0;
        }
    }
}