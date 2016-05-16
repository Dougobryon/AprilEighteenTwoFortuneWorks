using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprilEighteenTwoFortuneWORKS
{
    class Program
    {
        static void Main(string[] args)
        {
            //our game will start here
            //let's create a fortune teller
            FortuneTeller fortuneTeller = new FortuneTeller();
            CrystalBall crystalBall = new CrystalBall();
            fortuneTeller.Greet(); //say hi
            fortuneTeller.StartService((Service)crystalBall);

            string clientfavoriteColor = favoriteColor();
            string clientCherishedObject = cherishedObject();
            string myPhrase = "you will lose a " + clientCherishedObject + " in a haze of " + clientfavoriteColor + " surrounding you.";
            crystalBall.CreatePhrases(myPhrase);

            crystalBall.Work();
            crystalBall.Show();
            crystalBall.StateEffectiveness();
            fortuneTeller.Farewell();
        }

        static public string favoriteColor()
        {
            Console.WriteLine("What is your favorite color?");
            string favoriteColor = Console.ReadLine();
            //this.FavoriteColor = favoriteColor;
            return favoriteColor;
        }

        static public string cherishedObject()
        {
            Console.WriteLine("What is your most cherished object?");
            string cherishedObject = Console.ReadLine();
            // this.CherishedObject = cherishedObject;
            return cherishedObject;

        }
    }

    abstract class Service
    {

        //Properties
        //services have costs
        //I want this to be overrideable.
        public abstract decimal Price { get; set; }

        //public virtual string FavoriteColor { get; set; }
        //public virtual string CherishedObject { get; set; }

        //all services have a name.
        public virtual string Name { get; set; }

        //Let's make a property to store some result. Let's just say it's a single result and it's a string.
        public abstract string Result { get; set; }

        //We might want to track other things too, but we can add on later if we'd like


    }


    class FortuneTeller : Employee
    {
        //I'm just setting this up as a regular old class. 
        //Later, I might choose to make it in a game where I inherit from a Human class
        //(and have a customer also inherit from Human), but for our first round, this is great.

        //Properties
        public string Name { get; set; } = "Esmerelda";

        public string ExperienceLevel { get; set; }

        //public virtual string FavoriteColor { get; set; }
        //public virtual string CherishedObject { get; set; }

        //Methods

        public void Greet()
        {
            Console.WriteLine("Hello! Welcome to my humble shop.");
            Console.WriteLine("Let me see what I have to offer you today.");

        }

        public void StartService(Service service)
        {
            Console.WriteLine("For you, my {0}! Yes, perfect. It only costs {1} and that's fine by everyone.", service.Name, service.Price);
        }

        //public void favoriteColor()
        //{
        //    Console.WriteLine("What is your favorite color?");
        //    string favoriteColor = Console.ReadLine();
        //    this.FavoriteColor = favoriteColor;
        //}

        //public void cherishedObject()
        //{
        //    Console.WriteLine("What is your most cherished object?");
        //    string cherishedObject = Console.ReadLine();
        //    this.CherishedObject = cherishedObject;
        //}

        public void Farewell()
        {
            Console.WriteLine("Thank you for your patronage.");
        }



        /// <summary>
        /// Create a new fortune teller, giving it a name and experience level.
        /// </summary>
        /// <param name="name">The fortune teller's name.</param>
        /// <param name="experienceLevel">A string value (beginner, intermediate, advanced) for this fortune teller.</param>
        //Constructors
        public FortuneTeller(string name, string experienceLevel)
        {
            this.Name = name;
            this.ExperienceLevel = experienceLevel;
        }

        public FortuneTeller()
        {
        }
    }


    class Magic : Service
    {
        //what is at the base of a magical item?
        //in our base class, let's say that they all have good or bad magic. In this case, let's just say it's black magic, or just magic.
        //now, we have to decide what kind of datatype we want to use to store it. 
        //Since there are only 2 values, it would be very efficient to use a bool
        //property
        public virtual bool BlackMagic { get; set; }

        //how about another property that gives us the effectiveness of this magical item?
        public virtual int PercentEffective { get; set; }

        public override decimal Price { get; set; }
        public override string Result { get; set; }

        //let's make sure all of them have a name!
        public override string Name { get; set; }

        //let's throw in the level of expertise the fortune teller needs to use this item
        protected virtual string Expertise { get; set; }

        //How about a  work -- "make it go now" method?
        public virtual void Work()
        {
            Console.WriteLine("Let me pull out my {0}", this.Name);
        }
        //What about a Show method for sharing the results -- showing the magical object to the user?
        public virtual void Show()
        {
            Console.WriteLine("Oh, my. The {0} told me, yes, your future.", this.Name);
            Console.WriteLine(this.Result);
        }
        public virtual void StateEffectiveness()
        {
            Console.WriteLine("In case you're wondering, this method is {2} percent effective.", this.Name, this.Result, this.PercentEffective);
        }
    }


    class CrystalBall : Magic
    {
        //straight up field. I really don't need a property. Just using globally so random behaves well.
        private Random random = new Random();

        //properties
        protected List<string> Phrases { get; set; } = new List<string>();

        public override string Name { get; set; } = "Crystal Ball";

        public string CherishedObject { get; set; }
        public string FavoriteColor { get; set; }


        public override void Work()
        {
            base.Work();
            //now let's call a method that will get a result for the crystal ball
            this.Result = GetPhrase();

        }

        internal void CreatePhrases()
        {
            /* Phrases.Add("Night time is a dark place for you.");
             Phrases.Add("I see shiny objects in your near future");
             Phrases.Add("The decorating around you needs some help.");
     */
            //Phrases.Add("You will lose " + this.CherishedObject + " in a " + this.FavoriteColor + " haze.");
        }

        //let's create an overloaded method now
        internal void CreatePhrases(string phrase)
        {
            Phrases.Add(phrase);
        }

        private string GetPhrase()
        {
            //local variable
            int randomNumber = random.Next(Phrases.Count);
            return Phrases.ElementAt(randomNumber);

        }

        //constructor
        //let's override some of the properties of what we inherited from magic and service here.
        public CrystalBall()
        {
            this.Price = 45.00M;
            this.PercentEffective = 65;
            this.BlackMagic = false;
            this.Expertise = "beginner";
            //I want to call my initializer for phrases.
            CreatePhrases();
        }


    }


    class Customer
    {
        public virtual int CustomerAge { get; set; } = 33;
        public virtual int CustomerHeight { get; set; } = 72;
        public virtual int CustomerWeight { get; set; } = 135;

        //a simple method to prove class Customer is up and running.

        public void PrintCustomerDetails()
        {
            Console.WriteLine("Customer is " + CustomerAge + " years old, " + CustomerHeight + " inches tall, and " + CustomerWeight + " pounds in weight.");
        }
    }



    class Employee
    {
        public virtual int EmployeeAge { get; set; } = 21;
        public virtual int EmployeeHeight { get; set; } = 60;
        public virtual int EmployeeWeight { get; set; } = 200;


        public void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee is " + EmployeeAge + " years old, " + EmployeeHeight + " inches tall, and " + EmployeeWeight + " pounds in weight.");
        }



        class NotMagic : Service
        {
            public virtual string Hair { get; set; } = "hair salon";
            public virtual string Nails { get; set; } = "nail salon";

            public override string Name { get; set; } = "NotMagic Services";
            public override decimal Price { get; set; } = 100.00m;
            public override string Result { get; set; } = "Result";



            public void CutHair()
            {
                Console.WriteLine("the initial cost of your salon visit is : " + this.Price);
                this.Price = 50.00m;
                Console.WriteLine("but now, the cost of your salon visit is : " + this.Price);
                Console.WriteLine("the Name of NotMagic is : " + this.Name);
            }

            public void PaintNails()
            {
                Console.WriteLine("the initial cost of your nail treatment is : " + this.Price);
                this.Price = 200.00m;
                Console.WriteLine("but now, the cost of your nail treatment is : " + this.Price);
                Console.WriteLine("the Result of NotMagic is : " + this.Result);
            }


        }

    }
}



