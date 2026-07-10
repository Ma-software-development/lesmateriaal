using System;

namespace LoopDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] leeftijden = new int[]{1,5,6,78,9,10 };


            for (int i = 0; i < leeftijden.Length; i++)
            {
                int huidigeLeeftijd = leeftijden[i];
                Console.WriteLine(huidigeLeeftijd);
            }

            foreach (int leeftijd in leeftijden) 
            { 
                Console.WriteLine(leeftijd); 
            }


            Enemy[] enemies = new Enemy[] {
                new Enemy() {dead = false }, 
                new Enemy() { dead=true} };

            for (int i = 0;i < enemies.Length;i++)
            { 
                Enemy enemy = enemies[i];
                if(enemy.dead)
                {
                    break;
                }
                enemy.Ai();
            }

        }
    }


    class Enemy
    {
        internal bool dead;

        public void Ai()
        {

        }
    }
}
