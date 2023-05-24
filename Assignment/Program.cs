namespace Assignment
{
    public static class ArrayReplicator
    {
        /// <summary>
        /// Replicates (deep copies) the incoming array
        /// </summary>
        /// <param name="original">The array to be replicated</param>
        /// <returns>A deep copy of the original array</returns>
        public static int[] ReplicateArray(int[] original)
        {
            int size = original.Length;
            int[] copyArray = new int[size];
            // LINQ -> map
            for (int i = 0; i < size; ++i)
            {
                copyArray[i] = original[i];
            }
            return copyArray;
        }

        /// <summary>
        /// Asks the user for a number. Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumber(string text)
        {
            Console.Write(text);
            string userInput = Console.ReadLine(); // Needs work -> try/catch + loop or Int.TryParse + loop
            int number = Convert.ToInt32(userInput);
            return number;
        }

        /// <summary>
        /// Asks the user for a number within a certain range [min, max]. If the number is not in the range, re-prompt the user for a new number.
        /// Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <param name="min">Smallest permissible value</param>
        /// <param name="max">Largest permissible value</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumber(string text, int min, int max)
        {
            int userInput = AskForNumber(text);
            // While the user input is outside the expected range
            while (userInput < min || userInput > max)
            {
                userInput = AskForNumber("Your previous input is not valid, try again.");
            }
            return userInput;
        }
    }

    static class Program
    {
        static void Main()
        {
            const int Min = 0;
            const int Max = 10;
            const int PrintOffset = 4;

            int size = ArrayReplicator.AskForNumber("Enter the array size: ", Min, Max);
            int[] original = new int[size];

            for (int item = 0; item < size; ++item)
            {
                original[item] = ArrayReplicator.AskForNumber("Enter a number: ");
            }

            int[] copy = ArrayReplicator.ReplicateArray(original);
            for (int index = 0; index < size; ++index)
                Console.WriteLine($"Original {original[index],-PrintOffset}  {copy[index],4} Copy");
        }
    }
}
