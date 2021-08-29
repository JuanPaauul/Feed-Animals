using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed_Animals
{
    public class Dog:Animal
    {
        public override string Introduce()
        {
            return $"Whoof whoof, my name is {Name} and I am {Age} years old";
        }
    }
}
