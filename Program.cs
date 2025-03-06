using System.Text.Json;

namespace Lab_Serialization_And_RAF
{
    public class Event
    {
        // public properties
        public int eventNumber { get; set; }
        public string location { get; set; }

        public Event(int eventNumber, string location)
        {
            this.eventNumber = eventNumber;
            this.location = location;
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
        }
    }
}

