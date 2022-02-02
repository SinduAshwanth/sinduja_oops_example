using System;
using System.Threading.Tasks;

namespace oopsConcept
{
    class Program 
    {
        static void Main(string[] args)
        {
            //Comment this program is for oops concept

            Parallel.Invoke(
                () => LogTime(),
                () => LogMessage()
                );

            // created object for encapsulation
            encapsulationex encapobj = new encapsulationex();
            Console.WriteLine("Enter number to Add");
            encapobj.number1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter number to Add");
            encapobj.number2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter string to concatenate");
            encapobj.stringdata1 = Console.ReadLine();
            Console.WriteLine("Enter string to concatenate");
            encapobj.stringdata2 = Console.ReadLine();
            Addition obj1 = new add();
            AddString obj2 = new add();
            int sum = obj1.add(encapobj.number1, encapobj.number2);
            string concatval = obj2.add(encapobj.stringdata1, encapobj.stringdata2);
            BaseAdd objbase = new BaseAdd();
            objbase.printSum(sum);
            derivedadd objderived = new derivedadd();
            objderived.printSum(sum);
            objbase.printSum(concatval);            
            objderived.printSum(concatval);
            SealedClass objsealed = new SealedClass();
            Console.WriteLine(objsealed.Adddecimal(1.2, 1.4));

            Program objdel = new Program();
            delegateadd delobj = new delegateadd(objdel.addnumber);

        }

        public delegate int delegateadd(int a, int b);

        public int addnumber(int a , int b)
        {
            return a + b;
        }
        private static void LogTime()
        {
            Singleton logtimeobj = Singleton.GetInstance;
            logtimeobj.PrintDetails(DateTime.UtcNow.ToString());
        }
        private static void LogMessage()
        {
            Singleton logMessageObj = Singleton.GetInstance;
            logMessageObj.PrintDetails("Log has been added");
        }
    }
    public class encapsulationex
    {
        private int num1;
        private int num2;
        private string data1;
        private string data2;

        public int number1
        {
            get
            {
                return num1;
            }
            set
            {
                num1 = value;
            }
        }
        public int number2
        {
            get
            {
                return num2;
            }
            set
            {
                num2 = value;
            }
        }

        public string stringdata1
        {
            get
            {
                return data1;
            }
            set
            {
                data1 = value;
            }
        }
        public string stringdata2
        {
            get
            {
                return data2;
            }
            set
            {
                data2 = value;
            }
        }
    }
    public class add : Addition, AddString
    {
        int Addition.add(int num1, int num2)
        {
            int sum = num1 + num2;
            return sum;
        }

        string AddString.add(string num1, string num2)
        {
            string sum = num1 + num2;
            return sum;
        }
    }
    interface Addition
    {
        int add(int num1, int num2);
    }

    interface AddString
    {
        string add(string num1, string num2);
    }

    public class BaseAdd:printclass
    {
        public virtual void printSum(object val)
        {
            Console.WriteLine("Sum from base class is :" + val);
        }

        public override void printmessage()
        {
            Console.WriteLine("This is for printing for some message to implement the abstract class");
        }
    }
    public abstract class printclass
    {
        public abstract void printmessage();
    }
    sealed class SealedClass
    {

        // Calling Function
        public double Adddecimal(double a, double b)
        {
            return a + b;
        }
    }
    public class derivedadd : BaseAdd
    {
        public override void printSum(object val)
        {
            Console.WriteLine("Message from Derived class");
            base.printSum(val);
        }
    }

    public sealed class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
