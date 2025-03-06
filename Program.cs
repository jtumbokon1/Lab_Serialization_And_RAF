﻿using System.Text.Json;

namespace Lab_Serialization_And_RAF
{
    public class Event
    {
        // public properties
        public int eventNumber { get; set; }
        public string location { get; set; }

        // constructor
        public Event(int eventNumber, string location)
        {
            this.eventNumber = eventNumber;
            this.location = location;
        }

        // public methods
        // Create a method called ReadFromFile, where you write the word “Hackathon” to the file, and then read the first, middle and last characters using StreamWriter and the Seek method. 
        public void ReadFromFile()
        {
            using (StreamWriter writer = new StreamWriter("event.txt"))
            {
                writer.Write("Hackathon");
            }
            using (FileStream fs = new FileStream("event.txt", FileMode.Open, FileAccess.Read))
            {
                fs.Seek(0, SeekOrigin.Begin);
                Console.WriteLine((char)fs.ReadByte());

                fs.Seek(fs.Length / 2, SeekOrigin.Begin);
                Console.WriteLine((char)fs.ReadByte());

                fs.Seek(-1, SeekOrigin.End);
                Console.WriteLine((char)fs.ReadByte());
            }
        }

        public override string ToString() 
        {
            return $"{eventNumber}\n" +
                $"{location}\n" +
                $"Tech Competition\n" +
                $"In Word: Hackathon";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Event @event1 = new Event(1, "Calgary");

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(@event1, options);
            File.WriteAllText("event.txt", jsonString);

            Event @event2 = JsonSerializer.Deserialize<Event>(jsonString)!;
            Console.WriteLine(@event2);
            event2.ReadFromFile();
        }
    }
}

