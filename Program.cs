/*
 * Course: CPRG-211-C
 * Lab: Using Serialization and Random Access Files (RAF)
 * Author: Jirch Tumbokon
 * When: Winter 2025
 * Purpose: This program demonstrates creating an object then
 *          serializing the object to a file called event.txt and then deserialize it back.
 *          Then calls a method ReadFromFile() to write the word "Hackathon"
 *          then read the first, middle and last characters using StreamWriter and Seek method.
 */

using System.Text.Json;

namespace Lab_Serialization_And_RAF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an Event object
            Event @event1 = new Event(1, "Calgary", "Tech Competition");

            // serialize the object to a file called event.txt
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(@event1, options);
            File.WriteAllText("event.txt", jsonString);

            // deserialize the object from the file
            Event @event2 = JsonSerializer.Deserialize<Event>(jsonString)!;
            Console.WriteLine(@event2); // display the object
            event2.ReadFromFile(); // read the characters from the file
        }
    }// class
}// namespace

