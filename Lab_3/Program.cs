namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Interval interval1 = new Interval(6, 10, "A");
            Interval interval2 = new Interval(5, 13, "B");
            Interval interval3 = new Interval(-10, 10, "C");
            interval1.ShiftToLeft(2);
            interval1.ShiftToRight(15);
            //interval1.CompressInterval(0.5);
            interval2.CompareIntervals(interval1);
            interval2.AddIntervals(interval1);
            interval2.SubtractIntervals(interval1);
            interval3.ExpandInterval(0.5);
            interval3.CompressInterval(0.5);
            
            Console.WriteLine(new string('=', 40));
            Console.ReadKey();
        }
    }

    class Interval
    {
        private double _leftBorder;
        private double _rightBorder;
        private readonly string _name;
        
        public double LeftBorder
        {
            get => _leftBorder;
        }
        public double RightBorder
        {
            get => _rightBorder;
        }

        public string Name
        {
            get => _name;
        }
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