using System;
using NestedObjectDemo;
using Newtonsoft.Json.Linq;

Console.WriteLine("Nested Object Demo. This will allow you to retrieve the value of a nested key in an object.");
Console.WriteLine("Example object: " + "{“a”:{“b”:{“c”:”d”}}}");
Console.WriteLine("Example request: " + "\"a/b/c\" will return \"d\"");
Console.WriteLine("");

// Create the NestedObjectParser object
NestedObjectParser nestedObjectParser = new NestedObjectParser();

// Loop indefinitely to get inputs from the user
while(true) {
    Console.Write("Input an object: ");
    string? inputObject = Console.ReadLine();
    Console.Write("Input a request: ");
    string? inputRequest = Console.ReadLine();

    // Simple input validation
    if (inputObject == null || inputRequest == null ) { Console.WriteLine("Please enter the object and the requested key"); continue; }

    // Store an empty string ready for the output
    string? outputValue = null;
    try {
        // Use the NestedObjectParser to get the value
        outputValue = nestedObjectParser.Parse(inputObject, inputRequest);

    } catch(Exception ex) {
        // Check to see whether this was a Json exception - if so print a friendly message to the user
        if (ex is Newtonsoft.Json.JsonReaderException) Console.WriteLine("The input Json object was of an invalid format"); else Console.WriteLine("Unexpected error: " + ex.Message);
        continue;
    }

    // Print the result
    if(outputValue != null) {
        Console.WriteLine("Value found: " + outputValue);
    } else {
        Console.WriteLine("Value was not found in the object");
    }
    
}

