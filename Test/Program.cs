using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Test
{
    /*********Class*****************/
    public class Hero
    {
        protected int health;
        protected int mana;
        protected string name;
        protected int failed;
        
        public int getHealth() { return health; }
        public void setHealth(int health) { this.health = health; }

        public int getMana() { return mana; }
        public void setMana(int mana) { this.mana = mana; }

        public string getName() { return name; }
        public void setName(string name) { this.name = name; }

        public int getFailed() { return failed; }
        public void setFailed(int failed) { this.failed = failed; }


        public Hero (int h, int m, string n, int f)
        {
            health = h;
            mana = m;
            name = n;
            failed = f;
        }    


      

        public void Info()
        {
            Console.WriteLine("Name: " + name + " Health: " + health + " Mana: " + mana + " Failed: " + failed);
        }

        public virtual Tuple<int, int> Q (int health, int mana)
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

        public virtual Tuple<int, int, int> R(int health, int mana, int myHealth)
        {
            return new Tuple<int, int, int>(health, mana, myHealth);
        }

    }

    /*Hero thể lửa*/

    public class FireHero : Hero
    {
        public FireHero(int h, int m, string n, int f) : base (h,m,n,f)
        {
            
        }


        public override Tuple<int, int> Q(int rivalHealth, int mana)
        {
            if (mana >= 2)
            {
                rivalHealth -= 15;
            }
 
            return new Tuple<int, int>(rivalHealth, mana);
        }

        public override Tuple<int, int> W(int myHealth, int mana)
        {
            if (mana >= 3)
            {
                myHealth += 10;
                if (myHealth > 100)
                {

                    myHealth = 100;
                }

                mana += 2;

                if (mana > 20)
                {
                    mana = 20;
                }    

            }

            return new Tuple<int, int>(myHealth, mana);
        }

        public override Tuple<int, int> E(int rivalHealth, int mana)
        {
            if (mana >= 5)
            {
                rivalHealth -= 30;
            }     
            
            return new Tuple<int, int>(rivalHealth, mana);
        }

        public override Tuple<int, int, int> R(int rivalHealth, int mana, int myHealth)
        {
            if (mana >= 10)
            {
                rivalHealth -= 30;
            }
   
            return new Tuple<int, int, int>(rivalHealth, mana, myHealth);
        }

    }

    /*Hero thể nước*/

     public class WaterHero : Hero
    {
        public WaterHero(int h, int m, string n, int f) : base(h, m, n, f)
        {

        }

        public override Tuple<int, int> Q(int rivalHealth, int mana)
        {
            if (mana >= 3)
            {
                rivalHealth -= 20;
            }
            return new Tuple<int, int>(rivalHealth, mana);
        }

        public override Tuple<int, int> W(int rivalHealth, int mana)
        {
            if (mana >= 3)
            {
                rivalHealth -= 10;
            }

            return new Tuple<int, int>(rivalHealth, mana);
        }

        public override Tuple<int, int> E(int myHealth, int mana)
        {
            if (mana >= 5)
            {
                myHealth += 20;
                if (myHealth > 80)
                {
                    myHealth = 80;
                }    
                mana += 5;
                mana -= 5;
                
                if (mana > 20)
                {
                    mana = 20;
                }    

            }

            return new Tuple<int, int>(myHealth, mana);
        }

        public override Tuple<int, int, int> R(int rivalHealth, int mana, int myHealth)
        {
            if (mana >= 10)
            {
                mana -= 10;
                rivalHealth -= 50;
                mana = 20;
                myHealth += 1;
                if (myHealth > 80)
                {
                    myHealth = 80;
                }
            }  
            return new Tuple<int, int, int>(rivalHealth, mana, myHealth);
        }

    }


    


    internal class Program
    {

        /*********Cac function trong main*****************/
        // Nhập List
        public static void EnterHeroList(List<Hero> heroList, int n)
        {
            Hero hero;
            bool checkOption;
            int option;

            for (int i = 0; i < n; i++)
            {
                // 1. Nhập tên hero
                Console.WriteLine("Ten cua hero: ");
                string name = Console.ReadLine();

                // 2. Nhập thể của hero


                do
                {
                    Console.WriteLine("Hero cua ban thuoc the gi? ");
                    Console.WriteLine("1.Lua            2.Nuoc");
                    checkOption = int.TryParse(Console.ReadLine(), out option);

                    if (option < 1 || option > 2 || checkOption == false)
                    {
                        Console.WriteLine("Lua chon khong hop le. Vui long nhap lai!");
                    }

                    Console.Write("\n");

                } while (option < 1 || option > 2 || checkOption == false);
                

                switch (option)
                {
                    case 1:
                        hero = new FireHero(100, 20, name,0);
                        heroList.Add(hero);

                        break;
                    case 2:
                        hero = new WaterHero(80, 20, name, 0);
                        heroList.Add(hero);

                        break;
                    default:
                        
                        break;
                }

          

            }

        }

        // Xuất list
        public static void ShowHeroList(List<Hero> heroList)
        {
            foreach (var hero in heroList)
            {
                hero.Info();
            }
        }

        // Thi triển chiêu thức
        public static void TakeAction(string name, string action, List<Hero> heroList)
        {
            int index = heroList.FindIndex(x => x.getName() == name);
            Hero hero = heroList[index];
            Hero rivalHero;
            int first_hero;
            Tuple<int, int> result;
            Tuple<int, int, int> resultR;
            Random random = new Random();
            

            // Xuat chieu thuc theo the cua hero
            if (hero.GetType().Equals(typeof(FireHero)))
            {

                switch (action)
                {
                    case "Q": 
                        if (hero.getMana() >= 2)
                        {
                            for (int i = 0; i < heroList.Count(); i++)
                            {
                                if (i == index)
                                    continue;

                                // Lấy rival hero từ mảng hero list
                                rivalHero = heroList[i];

                                // Thực hiện chiêu thức và nhận về các giá trị 
                                result = hero.Q(rivalHero.getHealth(), hero.getMana());
                                rivalHero.setHealth(result.Item1);
                            }
                            hero.setMana(hero.getMana() - 2);
                        }
                        else
                        {
                            hero.setFailed(hero.getFailed() + 1);
                        }
                        break;

                    case "W":                   
                        if (hero.getMana() >= 3)
                        {
                            result = hero.W(hero.getHealth(), hero.getMana());

                            hero.setHealth(result.Item1);
                       
                            hero.setMana(result.Item2);
                        }
                        else
                        {
                            hero.setFailed(hero.getHealth() + 1);
                        }    

                        break;

                    case "E":

                        if (hero.getMana() >= 5)
                        {
                            // random ngẫu nhiên hero là hero đầu tiên
                            do
                            {                             
                                first_hero = random.Next(heroList.Count());
                            } while (first_hero == index);

                            // Lấy rival hero từ mảng hero list
                            rivalHero = heroList[first_hero];

                            // Thực hiện chiêu thức và nhận về các giá trị 
                            result = hero.E(rivalHero.getHealth(), hero.getMana());
                            rivalHero.setHealth(result.Item1);
                            hero.setMana(hero.getMana() - 5);
                            
                        }   
                        else
                        {
                            hero.setFailed(hero.getFailed() + 1);
                        }    
                        
                        break;

                    case "R":
                        if (hero.getMana() >= 10)
                        {
                            for (int i = 0; i < heroList.Count(); i++)
                            {
                                if (i == index)
                                    continue;

                                // Lấy rival hero từ mảng hero list
                                rivalHero = heroList[i];

                                // Thực hiện chiêu thức và nhận về các giá trị 
                                resultR = hero.R(rivalHero.getHealth(), hero.getMana(), hero.getHealth());
                                rivalHero.setHealth(resultR.Item1);
                                
                            }

                            hero.setMana(hero.getMana() - 10);
                        }
                        else
                        {
                            hero.setFailed(hero.getFailed() + 1);
                        }
                        break;

                    default:
                        // code block
                        break;
                }
            } 
            else
            {
               
                switch (action)
                {
                    case "Q":
                        if (hero.getMana() >= 3)
                        {
                            for (int i = 0; i < heroList.Count(); i++)
                            {
                                if (i == index)
                                    continue;

                                // Lấy rival hero từ mảng hero list
                                rivalHero = heroList[i];

                                // Thực hiện chiêu thức và nhận về các giá trị 
                                result = hero.Q(rivalHero.getHealth(), hero.getMana());
                                rivalHero.setHealth(result.Item1);
                               
                            }

                            hero.setMana(hero.getMana() - 3);
                        } 
                        else
                        {
                            hero.setFailed(hero.getFailed() + 1);
                        }    
                        
                        break;
                    case "W":  
                        if (hero.getMana() >= 3)
                        {
                            int loop;
                            if (heroList.Count() == 2)
                            {
                                loop = 1;
                            }
                            else
                            {
                                loop = 0;
                            }

                            while (loop < 2)
                            {
                                do
                                {
                                    first_hero = random.Next(heroList.Count());
                                } while (first_hero == index);

                                // Lấy rival hero từ mảng hero list
                                rivalHero = heroList[first_hero];

                                // Thực hiện chiêu thức và nhận về các giá trị 
                                result = hero.W(rivalHero.getHealth(), hero.getMana());
                                rivalHero.setHealth(result.Item1);
                                loop++;
                            };
                            hero.setMana(hero.getMana() - 3);
                        }    
                        else
                        {
                            hero.setFailed(hero.getFailed() + 1);
                        }    
                        

                        break;
                    case "E":
                        if (hero.getMana() >= 5)
                        {
                            result = hero.E(hero.getHealth(), hero.getMana());

                            hero.setHealth(result.Item1);
                            hero.setMana(result.Item2);
                        }
                        else
                        {
                            hero.setFailed(hero.getFailed() + 1);
                        }    
                        


                        break;
                    case "R":
                        if (hero.getMana() >= 10)
                        {
                            // random ngẫu nhiên hero là hero đầu tiên
                            do
                            {                                
                                first_hero = random.Next(heroList.Count());
                            } while (first_hero == index);

                            // Lấy rival hero từ mảng hero list
                            rivalHero = heroList[first_hero];

                            // Thực hiện chiêu thức và nhận về các giá trị 
                            resultR = hero.R(rivalHero.getHealth(), hero.getMana(), hero.getHealth());
                            rivalHero.setHealth(resultR.Item1);
                            hero.setHealth(resultR.Item3);

                            hero.setMana(resultR.Item2);
                        }    
                        
                         else
                        {
                            hero.setFailed(hero.getFailed() + 1);
                        }
                        break;


                    default:
                        // code block
                        break;
                }

            }

            //ShowHeroList(heroList);


        }


        /**********Main************/

        static void Main(string[] args)
        {
            // 1. Khai báo biến
            int n;
            string name,action;
            bool checkAction,CheckQuantity;
            Hero checkHero;

            // 2. Tạo list chứa các hero
            List<Hero> heroList = new List<Hero>();

            // 3. Nhập số lượng hero tham gia trận chiến
            do
            {
                Console.Write("So luong hero tham gia tran chien: ");
                CheckQuantity = int.TryParse(Console.ReadLine(), out n);

                if (CheckQuantity == false)
                {
                    Console.WriteLine("Vui long nhap so nguyen!!!");
                }
                Console.Write("\n");
            } while (CheckQuantity == false);                


            // 4. Nhập danh sách hero
            EnterHeroList(heroList, n);


            // 5. Bắt đầu trận chiến
            while (true)
            {
                // Kiểm tra tính hợp lệ của dữ liệu nhập vào. Ở đây là tên hero.
                do
                {
                    Console.WriteLine("Ban muon hero nao xuat chieu: ");
                    name = Console.ReadLine();

                    checkHero = heroList.Find((Hero hero) => { return (hero.getName() == name); });

                    Console.Write("\n");
                    if (checkHero == null)
                    {
                        Console.WriteLine("Hero khong co trong danh sach khong hop le. Vui long nhap lai!");
                        Console.Write("\n");
                    }


                } while (checkHero == null);


                // Chọn chiêu thức muốn thi triển và kiểu tra tính hợp lệ của chiêu thức
                do
                {
                    Console.WriteLine("Ban muon thuc hien chieu thuc nao (Q,W,E,R): ");


                    action = Console.ReadLine().ToUpper();


                    Console.Write("\n");

                    if (action.Equals("Q"))
                    {
                        break;
                    }
                    else if (action.Equals("W"))
                    {
                        break;
                    }
                    else if (action.Equals("E"))
                    {
                        break;
                    }
                    else if (action.Equals("R"))
                    {
                        break;
                    }
                    else { Console.WriteLine("Chieu thuc ban nhap khong hop le. Vui long nhap lai!"); }

                } while (true);

                // Thi triển chiêu thức
                TakeAction(name, action, heroList);


                Console.WriteLine("Tiep tuc --> Nhan Enter          Dung tran chien --> Escape: ");


                var keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }


            //TakeAction("a", "R", heroList);
            //TakeAction("b", "E", heroList);
            //TakeAction("a", "W", heroList);
            //TakeAction("a", "R", heroList);
            //TakeAction("a", "R", heroList);
            //TakeAction("b", "E", heroList);

            ShowHeroList(heroList);
            Console.ReadLine();


        }
    }
}




