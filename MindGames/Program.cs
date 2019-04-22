using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MindGames
{
    class Program
    {
        static void Main(string[] args)
        {

            //Random number generation from 1 to 6 and add to the hashtable
            Random randn = new Random();
            int randNumb;
            Hashtable ht = new Hashtable();
            for (int i = 0; i < 4; i++)
            {
                randNumb = randn.Next(1, 7);
                ht.Add(i, randNumb);
            }
            //Display hashtable value.
            foreach (DictionaryEntry dr in ht)
            {
                Console.WriteLine(dr.Value);
            }
            //initialize the initial values.
            int wrongPosition = 0;
            int rightPosition = 0;
            int life = 10;
            int wrongNumberCount = 0;
            Boolean winFlag = false;
            while (!winFlag)
            {
                Console.WriteLine("Enter four digit number with each digit being between 1 and 6");

                string input = Console.ReadLine();
                //initialize array.
                int[] numberArr = new int[input.Length];

                for (int i = 0; i < numberArr.Length; i++)
                {
                    numberArr[i] = (int)Char.GetNumericValue(input[i]);

                    if (ht.ContainsValue(numberArr[i]))
                    {
                        if (Convert.ToInt32(ht[i]) == numberArr[i])
                        {
                            rightPosition++;
                        }
                        else
                        {
                            wrongPosition++;
                        }
                    }
                    else
                    {
                        wrongNumberCount++;
                    }

                }

                if (wrongPosition == 0 && wrongNumberCount == 0)
                {
                    winFlag = true;
                }

                Console.WriteLine("The number of correct numbers with correct Position");
                for (int i = 0; i < rightPosition; i++)
                {
                    Console.Write("  +  ");
                }

                Console.WriteLine();
                Console.WriteLine("The number of correct numbers with wrong Positions");

                for (int j = 0; j < wrongPosition; j++)
                {
                    Console.Write("   -   ");
                }

                life--;

                if (life < 0)
                {
                    break;
                }
                wrongPosition = 0;
                rightPosition = 0;
                wrongNumberCount = 0;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You have {0} chances left", life);
            }

            if (winFlag == true)
            {
                Console.WriteLine("You win");
            }
            else
            {
                Console.WriteLine("You Lose");
            }

            Console.ReadLine();



        }
    }
}
