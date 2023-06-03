using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Test
{
    /*********Class*****************/
    public class Hero
    {
        protected int health;
        protected int mana;

        public int getHealth() { return health; }
        public void setHealth(int health) { this.health = health; }

        public int getMana() {  return mana; }
        public void setMana(int mana) { this.mana = mana; }

      

        public void Info()
        {
            Console.WriteLine("Health: " + health + " Mana: " + mana);
        }

        public virtual Tuple<int,int> Q (int health, int mana)
        {
            return new Tuple<int, int>(health, mana);
        }

        public virtual Tuple<int, int> W(int health, int mana)
        {
            return new Tuple<int, int>(health, mana);
        }

        public virtual Tuple<int, int> E(int health, int mana)
        {
            return new Tuple<int, int>(health, mana);
        }

        public virtual Tuple<int, int> R(int health, int mana)
        {
            return new Tuple<int, int>(health, mana);
        }

    }

    /*Hero thể nước*/

    public class WaterHero : Hero
    {
        public WaterHero()
        {
            health = 100;
            mana = 20;
        }

        public override Tuple<int, int> Q(int rivalHealth, int mana)
        {
            rivalHealth -= 15;
            mana -= 2;
            return new Tuple<int, int>(rivalHealth, mana);
        }

        public override Tuple<int, int> W(int myHealth, int mana)
        {
            myHealth -= 15;
            mana += 2;
            return new Tuple<int, int>(myHealth, mana);
        }

        public override Tuple<int, int> E(int rivalHealth, int mana)
        {
            rivalHealth -= 30;
            mana -= 5;
            return new Tuple<int, int>(health, mana);
        }

        public override Tuple<int, int> R(int rivalHealth, int mana)
        {
            rivalHealth -= 30;
            mana -= 10;
            return new Tuple<int, int>(rivalHealth, mana);
        }

    }

    /*Hero thể lửa*/

     public class FireHero : Hero
    {
        public FireHero()
        {
            health = 80;
            mana = 20;
        }

        public override Tuple<int, int> Q(int rivalHealth, int mana)
        {
            rivalHealth -= 20;
            mana -= 3;
            return new Tuple<int, int>(rivalHealth, mana);
        }

        public override Tuple<int, int> W(int rivalHealth, int mana)
        {
            rivalHealth -= 10;
            mana -= 3;
            return new Tuple<int, int>(rivalHealth, mana);
        }

        public override Tuple<int, int> E(int myHealth, int mana)
        {
            myHealth -= 30;
            mana -= 0;
            return new Tuple<int, int>(myHealth, mana);
        }

        public new Tuple<int, int, int> R(int rivalHealth, int myHealth, int mana)
        {
            rivalHealth -= 50;
            myHealth += 1;
            mana = 10;
            return new Tuple<int, int, int>(rivalHealth, myHealth, mana);
        }

    }


    


    internal class Program
    {

        /*********Cac function trong main*****************/
        // Nhập List
        public static void EnterHeroList(List<Hero> heroList, int n, string the)
        {
            Hero hero;
            if (the == "nuoc")
            {
                hero = new WaterHero();
            }
            else
            {
                hero = new FireHero();
            }

            for (int i = 0; i < n; i++)
            {
                heroList.Add(hero);
            }
        }

        // Xuất list
        public static void ShowHeroList(List<Hero> heroList)
        {
            foreach (var hero in heroList)
            {
                Console.WriteLine(hero);
            }
        }


        /**********Main************/

        static void Main(string[] args)
        {
            //1. Nhập số lượng hero tham gia trận chiến
            Console.Write("So luong hero tham gia tran chien: ");
            int n = int.Parse(Console.ReadLine());

            //2. Nhập thể hero
            Console.Write("The cua hero: ");
            string he = Console.ReadLine();

            //3. Tạo list chứa các hero
            List<Hero> heroList = new List<Hero>();

            EnterHeroList(heroList, n, he);
            ShowHeroList(heroList);
            

            

            


            //Hero waterhero = new WaterHero();
            //Hero firehero = new FireHero();
            //int health = firehero.getHealth();
            //int mana = waterhero.getMana();
            //var q = waterhero.Q(health, mana);
            //firehero.setHealth(q.Item1);
            //waterhero.setMana(q.Item2);
            //Console.Write(firehero.getHealth() + "\n");
            //Console.Write(waterhero.getMana());
            //Console.WriteLine(q);

            Console.ReadKey();
        }
    }
}




