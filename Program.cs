/* Disclaimer: The examples and comments from this program are from
   C#7 in a Nutshell and are written for learning purposes only. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    public class Panda
    {
        /* Constructors run initialization code on a class or struct. A constructor
          is defined slike a method, except that the method name and return type are 
          reduced to the name of the enclosing type: */
        string name;            // Define field
        public Panda (string n) // Define constructor
        {
            name = n;           // Initialization code (set up field)
        }
        /* Instance constructors allow the following modifiers: 
         Access modifiers               public, internal, private, protected
         Unmanaged code modifiers       unsafe, extern                      */
        /* From C#7, single-statment constructors can also be written as expression-
         bodied members:  public Panda(string n) => name = n; */
       
        static void Main(string[] args)
        {
            Panda p = new Panda("Petey");   // Call constructor
        }

    }
    // OVERLOADING CONSTRUCTORS:
    /* A class of struct may overload constructors. To avoid code duplication, one 
     constructor may call another, using the this keyword: */
    public class Wine
    {
        public decimal Price;
        public int Year;
        public Wine (decimal price) { Price = price; }
        public Wine (decimal price, int year) : this (price) { Year = year; }
        /* When one constructor calls another, the called constructor executes first. 
         You can pass an expression into another constructor as follows: */
        public Wine(decimal price, DateTime year) : this(price, year.Year) { }
        /* The expression itself cannot make use of the this reference, for example,
         to call an instance method. (This is enforced because the object has not been 
         initialized by the constructor at this stage, so any methods that you call on it
         are likely to fail.) It can, however, call static methods. */
        // IMPLICIT PARAMATERLESS CONTRUCTORS
        /* For classes, the C# compiler automatically generates a parameterless public
          constructor if and only if you do not define any constructors. However, as soon
          as you define at least one constructor, the parameterless constructor is no 
          longer automatically generated. */
    }
    // CONSTRUCTOR AND FIELD INITIALIZATION ORDER:
    /* We saw previously that fields can be initialized with default values in their
     declaration: */
     class Player
    {
        int shields = 50;       // Initialized first
        int health = 100;       // Initialized second
        /* FIeld initializations occur before the constructor is executed, and in the 
         declaration order of the fields. */
    }
    // NONPUBLIC CONSTRUCTORS
    /* Constructors do not need to be public. A common reason to have a nonpublic
     constructor is to control instane creation via a static method call. The static
     method could be used to return an object from a pool rather than necessarily
     creating a new object, or return various subclasses based on input arguments: */
    public class Class1
    {
        Class1() { }        // Private Constructor
        /* public static Class1 Create ()
          Create custom logic here to return an instance of Class1. */ 
    }
}
