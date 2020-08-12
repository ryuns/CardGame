using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool lPlayAgain = true;
            do
            {
                IGame lGame = new LuckOfTheDraw();

                lGame.PlayGame();

                Console.WriteLine("The winners are:");
                for(int i = 0; i < lGame.Winners.Count; i++)
                {
                    Console.WriteLine(lGame.Winners[i].ToString());
                    Console.WriteLine(String.Join(", ", lGame.Winners[i].Cards));
                }

                Console.WriteLine("Would you like to play again Y/N");
                string lAgainString = Console.ReadLine();
                if (lAgainString.ToLower() != "y")
                {
                    lPlayAgain = false;
                }
                Console.Clear();
            }
            while (lPlayAgain);            
        }
    }
}
