using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void ReadFromFile()
        {
            using (StreamWriter writer = new StreamWriter("event.txt"))
            {
                // write the word "Hackathon" to the file
                writer.Write("Hackathon");
            }
            using (FileStream fs = new FileStream("event.txt", FileMode.Open, FileAccess.Read))
            {
                // read the first character
                fs.Seek(0, SeekOrigin.Begin);
                Console.WriteLine((char)fs.ReadByte());

                // read the middle character
                fs.Seek(fs.Length / 2, SeekOrigin.Begin);
                Console.WriteLine((char)fs.ReadByte());

                // read the last character
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
    }// class
}// namespace
