

namespace Lab_3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Interval interval1 = new Interval(6, 10, "A");
            //Interval interval2 = new Interval(2, 14, "B");

            interval1.ShowInterval();
            Console.WriteLine(new string('=', 40));
            await Manipulator.Read(interval1);
            int index;
            double coefficient;

            Manipulator manipulator = new Manipulator();
            
            
            while (true)
            {
                Console.WriteLine("\nChoose action: \n1.Show intervals\n2.Count interval lenght\n3.Shift to left" +
                                  "\n4.Shift to right\n5.Compress interval\n6.Expand interval\n7.Compare intervals" +
                                  "\n8.Add intervals\n9.Subtract intervals\n10.Save\n");
                index = Convert.ToInt32(Console.ReadLine());
                switch (index)
                {
                    case 1:
                        Manipulator.interval?.ShowInterval();
                        break;
                    case 2:
                        Console.WriteLine("The lenght is: "+Manipulator.interval?.CountIntervalLenght());
                        break;
                    case 3:
                        Console.Write("Write a coefficient: ");
                        coefficient = Convert.ToDouble(Console.ReadLine());
                        Manipulator.interval?.ShiftToLeft(coefficient);
                        break;
                    case 4:
                        Console.Write("Write a coefficient: ");
                        coefficient = Convert.ToDouble(Console.ReadLine());
                        Manipulator.interval?.ShiftToRight(coefficient);
                        break;
                    case 5:
                        Console.Write("Write a coefficient: ");
                        coefficient = Convert.ToDouble(Console.ReadLine());
                        if (coefficient <= 1 && coefficient >= 0)
                            Manipulator.interval?.CompressInterval(coefficient);
                        else
                            Console.WriteLine("You can't compress with this coefficient!");
                        break;
                    case 6:
                        Console.Write("Write a coefficient: ");
                        coefficient = Convert.ToDouble(Console.ReadLine());
                        Manipulator.interval?.ExpandInterval(coefficient);
                        break;
                    case 7:
                        Manipulator.interval?.CompareIntervals(interval1);
                        break;
                    case 8:
                        Manipulator.interval?.AddIntervals(interval1);
                        break;
                    case 9:
                        Manipulator.interval?.SubtractIntervals(interval1);
                        break;
                    case 10:
                        manipulator.Save(Manipulator.interval);
                        break;
                    default:
                        Console.WriteLine("Incorrect index!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            }
        }
        
    }

}