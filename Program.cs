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
            
        }
    }
}

