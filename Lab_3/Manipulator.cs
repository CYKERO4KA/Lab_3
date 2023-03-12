using System.Text.Json;
namespace Lab_3;

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