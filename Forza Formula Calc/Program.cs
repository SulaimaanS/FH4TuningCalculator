using Forza_Formula_Calc;
using System;
using System.Transactions;

namespace Forza_Formula_Calc
{
    public abstract class ForzaCalc
    {
        public double Max;
        public double Min;
        public double WeightPercentage;

        public ForzaCalc(double Max, double Min, double WeightPercentage)
        {
            this.Max = Max;
            this.Min = Min;
            this.WeightPercentage = WeightPercentage;
        }
    }

    public interface IDamper
    {
        void FrontFormula();
        void RearFormula();
        void FrontReboundStiffness();
        void RearReboundStiffness();
        void FrontBumpStiffness();
        void RearBumpStiffness();
        void FrontSpringStiffness();
        void RearSpringStiffness();
        void FrontRollBars();
        void RearRollBars();

    }

    public class Damper : ForzaCalc
    {
        public Damper(double Max, double Min, double Weight) : base(Max, Min, Weight)
        {
            this.Max = Max;
            this.Min = Min;
            this.WeightPercentage = Weight;
        }

        private double frontFormula()
        {
            return (Max - Min) * WeightPercentage + Min;
        }
        private double rearFormula()
        {
            return (Max - Min) * (1 - WeightPercentage) + Min;
        }

        public void FrontReboundStiffness()
        {
            Console.WriteLine("\nFront Rebound Stiffness is: {0}", frontFormula());
        }
        public void RearReboundStiffness()
        {
            Console.WriteLine("Rear Rebound Stiffness is: {0}", rearFormula());
        }
        public void FrontBumpStiffness()
        {
            Console.WriteLine("Front Bump Stiffness is: {0}", frontFormula() * 0.6);
        }
        public void RearBumpStiffness()
        {
            Console.WriteLine("Rear Bump Stiffness is: {0}", rearFormula() * 0.6);
        }


        public void FrontSpringStiffness()
        {
            Console.WriteLine("\nFront Spring Stiffness is: {0}", frontFormula());
        }
        public void RearSpringStiffness()
        {
            Console.WriteLine("Rear Spring Stiffness is: {0}", rearFormula());
        }


        public void FrontRollBars()
        {
            Console.WriteLine("\nFront Spring Stiffness is: {0}", frontFormula());
        }
        public void RearRollBars()
        {
            Console.WriteLine("Rear Spring Stiffness is: {0}", rearFormula());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var canExit = false;
        while (!canExit)
        {
            Console.WriteLine("\nEnter the part group you'd like to calculate for");
            Console.WriteLine("\n1: Rebound and Bump Stiffness");
            Console.WriteLine("2: Spring Stiffness");
            Console.WriteLine("3: Rollbar Stiffness");
            Console.WriteLine("4: Exit");
            var userInput = Console.ReadLine();
            var isNumeric = int.TryParse(userInput, out int option);

            if (!isNumeric)
            {
                Console.WriteLine("Invalid option. Try again.");
                continue;
            }
            switch (option)
            {
                case 1:
                    Console.WriteLine("Please enter max, min and weight percentage values for rebound and bump stiffness: ");
                    var value1 = new double[3];

                    for (var i = 0; i < value1.Length; i++)
                    {
                        var input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            value1[i] = Convert.ToDouble(input);
                        }
                    }
                    Damper D1 = new Damper(value1[0], value1[1], value1[2]);
                    D1.FrontReboundStiffness();
                    D1.RearReboundStiffness();
                    D1.FrontBumpStiffness();
                    D1.RearBumpStiffness();
                    Console.WriteLine("\nPress any key to return to the menu");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Please enter max, min and weight percentage values for spring stiffness: ");
                    var value2 = new double[3];

                    for (var i = 0; i < value2.Length; i++)
                    {
                        var input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            value2[i] = Convert.ToDouble(input);
                        }
                    }
                    Damper D2 = new Damper(value2[0], value2[1], value2[2]);
                    D2.FrontSpringStiffness();
                    D2.RearSpringStiffness();
                    Console.WriteLine("\nPress any key to return to the menu");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Please enter max, min and weight percentage values for rollbar stiffness: ");
                    var value3 = new double[3];

                    for (var i = 0; i < value3.Length; i++)
                    {
                        var input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            value3[i] = Convert.ToDouble(input);
                        }
                    }
                    Damper D3 = new Damper(value3[0], value3[1], value3[2]);
                    D3.FrontRollBars();
                    D3.RearRollBars();
                    Console.WriteLine("\nPress any key to return to the menu");
                    Console.ReadKey();
                    break;
                case 4:
                    canExit = true;
                    break;
                default:
                    Console.WriteLine("\nPlease select an option from the menu");
                    break;
            }

        }
    }
}
