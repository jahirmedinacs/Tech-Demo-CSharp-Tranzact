// Importing the System.IO namespace which contains types that allow reading and writing to files and data streams
using System.IO;

// Defining the namespace for the class. This groups related types into namespaces so that they can be organized and referenced easily
namespace TranzactDemo.Common
{
    // The Utilities class is a public class, meaning it can be accessed from any other class
    public class Utilities
    {
        // This is a public method that returns a string. It can be accessed from any class
        public string RandomAlphanumeric(int length)
        {
            // Path.GetRandomFileName() generates a random 11-character string that can be used as a file name
            // The Replace(".", "") removes any periods from the string
            // The Substring(0, length) returns the first 'length' characters of the string
            // So, this method returns a random alphanumeric string of the specified length
            return Path.GetRandomFileName().Replace(".", "").Substring(0, length);
        }
    }
}