using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            string OptionSelected = "asd";
            int Option;
            int listIndex = 1;
            Dictionary<int, Animal> animalList = new Dictionary<int, Animal>();
            Action<string> Print = (text) => Console.WriteLine(text);
            Action<string> PrintInLine = (text) => Console.Write(text);
            Func<string> Read = () => {
                return Console.ReadLine();
            };
            Action ClearScreen = () => Console.Clear();
            Action CreateMenu = () =>
            {
                int count = 1;
                foreach (Animal animal in animalList.Values)
                {
                    Console.WriteLine($"{count}. {animal.Name}");
                    count++;
                }
                Console.WriteLine($"{count}. Add");
            };
            Func<int> SelectAnimalMenu = () =>
            {
                Print("1. Dog\n2. Cat");
                return Int32.Parse(Read());
            };
            Func<int, Animal> CreateAnimalMenu = (theAnimal) =>
            {
                ClearScreen();
                Print("---------Pet Meals Administrator------");
                Animal newAnimal;
                switch (theAnimal)
                {
                    case 1:
                        newAnimal = new Dog();
                        break;
                    case 2:
                        newAnimal = new Cat();
                        break;
                    default:
                        newAnimal = new Dog();
                        break;
                }
                PrintInLine("Insert the animal's name: ");
                newAnimal.Name = Read();
                PrintInLine($"Insert {newAnimal.Name}'s age: ");
                newAnimal.Age = Int32.Parse(Read());
                PrintInLine($"Insert {newAnimal.Name}'s race: ");
                newAnimal.Race = Read();
                PrintInLine($"Insert the times, {newAnimal.Name} eats: ");
                newAnimal.MealsADay = Int32.Parse(Read());
                return newAnimal;
            };
            Action<Animal> AnimalMenu = (theAnimal) =>
            {
                int option = 5;
                while (option!=10)
                {
                    ClearScreen();
                    Print("---------Pet Meals Administrator------");
                    Print($"1. Feed {theAnimal.Name}");
                    Print($"2. Ask {theAnimal.Name} if is hungry");
                    Print($"3. Tell {theAnimal.Name} to introduce itself");
                    Print($"4. Back");
                    Int32.TryParse(Read(), out option);
                    switch (option)
                    {
                        case 1:
                            if (theAnimal.Feed())
                            {
                                Print($"{theAnimal.Name}: Mmmm... yum yum");
                            }
                            else
                            {
                                Print($"{theAnimal.Name}: I'm full!");
                            }
                            break;
                        case 2:
                            if (theAnimal.IsHungry())
                            {
                                Print($"{theAnimal.Name}: Yes :(");
                            }
                            else
                            {
                                Print($"{theAnimal.Name}: No :D");
                            }
                            break;
                        case 3:
                            Print(theAnimal.Introduce());
                            break;
                        case 4:
                            option = 10;
                            break;
                        default:
                            Print("Select a valid option!");
                            option = 100;
                            break;
                    }
                    Print("Press enter to continue.");
                    Read();
                }
            };
            /*Action<Animal[], int> FillAnimalArray = (dogs, lengthOfArray) => {
                for (int i = 0; i < lengthOfArray; i++)
                {
                    dogs[i] = new Dog();
                }
            };*/
            /*Action<Animal[], int> FillAnimalsData = (TheAnimal, NumOfAnimals) => {
                string AnimalName = TheAnimal.GetType().Name;
                int Counter = 0;
                foreach (var animal in TheAnimal)
                {
                    Counter++;
                    Print($"Insert the information for {AnimalName} {Counter}:\nName: ");
                    animal.Name = Read();
                    Print("Age: ");
                    animal.Age = Int32.Parse(Read());
                    Print("Race: ");
                    animal.Race = Read();
                    Print("Meals a day: ");
                    animal.MealsADay = Int32.Parse(Read());
                    animal.ShowData();
                }
            };
            Func<Animal[], Animal> GetTheType = (theAnimal) => {
                Animal animal = null;
                for (int i = 0; i < 10; i++)
                {
                    if (theAnimal[i] != null)
                    {
                        animal = theAnimal[i];
                        theAnimal[i] = null;
                    }
                }
                return animal;
            };*/
            bool Stop = false;
            Print("---------Pet Meals Administrator------\nIn order to start, we need to know which animal you have. Please select one:");
            while (!Stop)
            {
                /*Print("1. Dog");
                Print("2. Cat");
                Console.Write("->");*/
                CreateMenu();
                OptionSelected = Read();
                ClearScreen();
                Print("---------Pet Meals Administrator------");
                //Animal theAnimal;
                if (int.TryParse(OptionSelected, out Option))
                {
                    if (animalList.ContainsKey(Option))
                    {
                        animalList[Option].ShowData();
                        AnimalMenu(animalList[Option]);
                    }
                    else
                    {
                        //ClearScreen();
                        Animal newAnimal = CreateAnimalMenu(SelectAnimalMenu());
                        animalList.Add(listIndex, newAnimal);
                        listIndex++;
                    }
                    ClearScreen();
                    Print("---------Pet Meals Administrator------");
                }
                else
                {
                    Print("---------Pet Meals Administrator------\nIn order to start, we need to know which animal you have. Please select one:");
                    Print("*You must select the number on the left of each option*");
                }
                /*switch (Option)
                {
                    case 1:
                        theAnimal = new Dog();
                        break;
                    case 2:
                        theAnimal = new Cat();
                        break;
                    default:
                        
                        break;
                }*/
                /*
                OptionSelected = "NotANumber";
                while (!int.TryParse(OptionSelected, out NumberOfAnimals))
                {
                    Print("Insert the number of Cats you have.");
                    OptionSelected = Read();
                }
                Program test = new Program();
                Console.WriteLine(test.GetType());
                
                //Type theType = theAnimal.GetType().BaseType;
                Animal[] NewAnimal = new theAnimal.GetType()[10];
                    //(theAnimal)[NumberOfAnimals];
                //FillAnimalArray(NewAnimal, NumberOfAnimals);
                FillAnimalsData(NewAnimal, NumberOfAnimals);
                */
                
            }
        }
    }
}