using System.Text.Json;

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

    class Manipulator
    {
        public static Interval? interval;
        public void Save(Interval interval)
        {
            using (FileStream fs = new FileStream("save.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<Interval>(fs, interval);
                Console.WriteLine("Saved");
            }
        }

        public static async Task Read(Interval interval1)
        {
            using (FileStream fs = new FileStream("read.json", FileMode.OpenOrCreate))
            {
                interval = await JsonSerializer.DeserializeAsync<Interval>(fs);
            }
        }
    }
    class Interval
    {
        private double _leftBorder;
        private double _rightBorder;
        private readonly string _name;
        
        public double LeftBorder => _leftBorder;
        public double RightBorder => _rightBorder;

        public string Name => _name;


        public Interval(double leftBorder, double rightBorder, string name)
        {
            _leftBorder = leftBorder;
            _rightBorder = rightBorder;
            _name = name;
        }

        public void ShowInterval()
        {
            Console.WriteLine($"Interval {Name}: [{LeftBorder}, {RightBorder}]");
            Console.WriteLine($"Length: {CountIntervalLenght()}");
        }
        
        public double CountIntervalLenght()
        {
            return _rightBorder - _leftBorder;
        }
        
        public void ShiftToLeft(double coefficient)
        {
            Console.WriteLine(new string('=', 40));
            ShowInterval();
            _rightBorder -= coefficient;
            if (_leftBorder > _rightBorder)
            {
                _rightBorder += coefficient;
                Console.Write("\nIncorrect borders! \nLeft border > right border\n");
            }
            else if (_leftBorder == _rightBorder)
            {
                _rightBorder += coefficient;
                Console.WriteLine("it's a point! ");
            }
            else
            {
                Console.WriteLine($"Interval {Name} shifted to left: [{LeftBorder};{RightBorder}]");
            }
        }
        
        public void ShiftToRight(double coefficient)
        {
            Console.WriteLine(new string('=', 40));
            ShowInterval();
            _leftBorder += coefficient;
            if (_leftBorder > _rightBorder)
            {
                _leftBorder -= coefficient;
                Console.Write("\nIncorrect borders! \nLeft border > right border\n");
            }
            else if (_leftBorder == _rightBorder)
            {
                _leftBorder -= coefficient;
                Console.WriteLine("it's a point! ");
            }
            else
            {
                Console.WriteLine($"Interval {Name} shifted to right: [{LeftBorder};{RightBorder}]");
            }
        }
        
        public void CompressInterval(double coefficient)
        {
            Console.WriteLine(new string('=', 40));
            ShowInterval();
            double center = (_leftBorder + _rightBorder ) / 2;
            if (_leftBorder > _rightBorder)
            {
                Console.Write("\nIncorrect borders! \nLeft border > right border\n");
            }
            else if (_leftBorder == _rightBorder)
            {
                Console.WriteLine("it's a point! ");
            }
            else
            {
                _leftBorder += (center - _leftBorder) * coefficient;
                _rightBorder -= (_rightBorder - center) * coefficient;
                Console.WriteLine($"Interval {Name} compressed: [{LeftBorder};{RightBorder}]");
            }
        }
        
        public void ExpandInterval(double coefficient)
        {
            Console.WriteLine(new string('=', 40));
            ShowInterval();
            double center = (_leftBorder + _rightBorder ) / 2;
            if (_leftBorder > _rightBorder)
            {
                Console.Write("\nIncorrect borders! \nLeft border > right border\n");
            }
            else if (_leftBorder == _rightBorder)
            {
                Console.WriteLine("it's a point! ");
            }
            else
            {
                _leftBorder -= (center - _leftBorder) * coefficient;
                _rightBorder += (_rightBorder - center) * coefficient;
                Console.WriteLine($"Interval {Name} expanded: [{LeftBorder};{RightBorder}]");
            }
        }

        public void CompareIntervals(Interval interval)
        {
            Console.WriteLine(new string('=', 40));
            interval.ShowInterval();
            ShowInterval();
            if (interval.CountIntervalLenght() > CountIntervalLenght())
            {
                Console.WriteLine($"(interval {interval.Name}) > (interval {Name})");
            }
            else
            {
                Console.WriteLine($"(interval {interval.Name}) < (interval {Name})");
            }
        }

        public void AddIntervals(Interval interval)
        {
            Console.WriteLine(new string('=', 40));
            interval.ShowInterval();
            ShowInterval();
            Console.WriteLine($"Add intervals {interval.Name} and {Name}:" +
                              $" [{LeftBorder + interval.LeftBorder};{RightBorder + interval.RightBorder}]");
        }

        public void SubtractIntervals(Interval interval)
        {
            Console.WriteLine(new string('=', 40));
            interval.ShowInterval();
            ShowInterval();
            Console.WriteLine($"Subtract intervals {interval.Name} and {Name}:" +
                              $" [{LeftBorder - interval.LeftBorder};{RightBorder - interval.RightBorder}]");
        }
    }
}