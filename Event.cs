using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Lab_Serialization_And_RAF
{
    class Event
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

        //Create an object from the class and assign a value of 1 to the event number property and a value of Calgary to the location property
        Event myEvent = new Event(1, "Calgary");

        // Method to serialize the object to a file called event.txt
        public void SerializeEvent()
        {
            string jsonString = JsonSerializer.Serialize(myEvent);
            File.WriteAllText("event.txt", jsonString);
        }
        //Use deserialization to deserialize the object from the file and display the values on the Console.
        public void DeserializeEvent()
        {
            string jsonString = File.ReadAllText("event.txt");
            Event? myEvent = JsonSerializer.Deserialize<Event>(jsonString);
            Console.WriteLine($"Event Number: {myEvent.eventNumber}");
            Console.WriteLine($"Location: {myEvent.location}");
        }
        //Create a method called ReadFromFile, where you write the word “Hackathon” to the file, and then read the first, middle and last characters using StreamWriter and the Seek method.
        public void ReadFromFile()
        {
            using (StreamWriter writer = new StreamWriter("hackathon.txt"))
            {
                writer.Write("Hackathon");
            }
            using (FileStream fileStream = new FileStream("hackathon.txt", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileStream.Seek(0, SeekOrigin.Begin);
                    Console.WriteLine($"First character: {reader.Read()}");
                    fileStream.Seek(3, SeekOrigin.Begin);
                    Console.WriteLine($"Middle character: {reader.Read()}");
                    fileStream.Seek(-1, SeekOrigin.End);
                    Console.WriteLine($"Last character: {reader.Read()}");
                }
            }
        }

    }
}
