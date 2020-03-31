using System;

namespace DnDDiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to do? \n1) Roll some specific dice\n2) Roll a series of 4d6 rolls where the lowest roll gets dropped");
            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                int times = 1;
                while (true)
                {
                    // say how many dice you want to roll and of what kind
                    if (times == 1)
                    {
                        Console.WriteLine("What do you want to roll?  (e.g. 2d10, 1d6)");
                    }
                    else
                    {
                        Console.WriteLine("What do you want to roll?");
                    }
                    string dice = Console.ReadLine();
                    if (dice == "q")
                    {
                        break;
                    }
                    string result = Roll(dice);
                    //Console.WriteLine($"\n\nYou rolled {result}!\n");
                    Console.WriteLine($"\n\n{result}\n");
                    times++;
                }
            }
            if (choice == "2")
            {
                Console.WriteLine("Great.  How many sets of 4d6 dropping the lowest do you need?");
                int repetitions = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                // call a method here
                for (int m = 0; m < repetitions; m++)
                {
                    RollFourDropLowest();
                }
            }
        }

        // parse type of die vs. number of dice, calculate
        static string Roll(string input)
        {
            int d = input.IndexOf("d");
            int result = 0;
            string allRolls = "";

            int dieNum;
            int dieType = Convert.ToInt32(input.Substring(d+1));
            Random rand = new Random();

            if (input.IndexOf("d") == 0)
            {
                return rand.Next(1, dieType).ToString();
            }
            else
            {
                dieNum = Convert.ToInt32(input.Substring(0, d));
            }

            if (dieNum == 1)
            {
                return rand.Next(2, dieType + 1).ToString();
            }

            for (int i = 1; i <= dieNum; i++)
            {
                int singleRoll = rand.Next(1, dieType + 1);
                result += singleRoll;
                if (i == 1)
                {
                    allRolls = singleRoll.ToString();
                }
                if (i > 1)
                {
                    allRolls = $"{allRolls}, {singleRoll}";
                }
            }
            allRolls = $"{result}  ({allRolls})";
            return allRolls;
        }

        // method for 4d6 drop the lowest goes here
        static void RollFourDropLowest()
        {
            Random rand = new Random();
            int[] allRolls = {rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7)};
            int i, j, temp;

            for (i = 0; i < 4; i++)
            {
                for (j = i + 1; j < 4; j++)
                {
                    if (allRolls[i] < allRolls[j])
                    {
                        temp = allRolls[i];
                        allRolls[i] = allRolls[j];
                        allRolls[j] = temp;
                    }
                }
            }

            Console.WriteLine($"{allRolls[0] + allRolls[1] + allRolls[2]}:  {allRolls[0]}, {allRolls[1]}, {allRolls[2]} ({allRolls[3]})");
        }
    }
}
