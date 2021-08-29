using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Animals
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public int MealsADay { get; set; }
        public int CurrentMeals { get; set; }
        public Animal()
        {
            Name = "";
            Age = 0;
            Race = "";
            MealsADay = 0;
            CurrentMeals = 0;
        }
        public virtual string Introduce()
        {
            return $"Hi, my name is {Name} and I am {Age}";
        }
        /*public void FillData()
        {
      
            Name = Console.ReadLine();
            Console.WriteLine("Age: ");
            Age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Race: ");
            Race = Console.ReadLine();
            Console.WriteLine("Meals a day: ");
            MealsADay = Int32.Parse(Console.ReadLine());
        }*/
        public bool IsHungry()
        {
            int RecientHour = DateTime.Now.Hour;
            return (16/ MealsADay) * (1 + CurrentMeals) + 3 < RecientHour && CurrentMeals != MealsADay;
        }
        public bool Feed()
        {
            bool successfullFeeded = false;
            if (IsHungry())
            {
                successfullFeeded = true;
                CurrentMeals++;
            }
            return successfullFeeded;
        }
        public void ShowData()
        {
            Console.WriteLine($"Name: {Name}\nAge: {Age}\nRace: {Race}\nMeals a day: {MealsADay}\nCurrent meals: {CurrentMeals}");
        }
    }

}
