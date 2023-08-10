namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random random= new Random();
            Console.Out.WriteLine("Let's play a guessing game");
            int ranDum = random.Next(1, 10);
            bool playOn = true;

            while (playOn)
            {
                Console.WriteLine("Guess a number");
                int userInput;

                try {
                    userInput = Convert.ToInt32(Console.ReadLine());

                    highLow(userInput, ranDum);

                    playOn = keepPlaying(userInput);
                    
                } catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }
        }
        static void highLow(int guess, int random)
        {
            string response;
            if (guess < random)
            {
                response = "Too low";
            } else if (guess > random)
            {
                response = "Too high";
            } else 
            {
                response = "Nice guess, you win!";
            }
            Console.Out.WriteLine(response);
        }

        static bool keepPlaying(int userInput)
        {
            Console.WriteLine("If you want to stop playing, input 0, you have selected: " + userInput);

            return userInput != 0;            
        }
    }
}