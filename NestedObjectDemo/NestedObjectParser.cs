using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NestedObjectDemo {
    public class NestedObjectParser {
        public NestedObjectParser() { }

        /// <summary>
        /// Parses the given object to retrieve the requested nested key.
        /// </summary>
        /// <param name="jsonObject">Any object in Json format, e.g. {“a”:{“b”:{“c”:”d”}}}</param>
        /// <param name="requestedKey">The key for which the value is required, e.g. a/c/c</param>
        /// <returns>The value matching the given key</returns>
        public string? Parse(string jsonObject, string requestedKey) {

            // Parse the Json to a JObject
            JObject parsedObject = JObject.Parse(jsonObject);

            // Convert the requested key to an array of characters by splitting it using forward slash
            string[] splitRequestedKey = requestedKey.Split('/');

            // String to store the found value
            string? foundValue = null;

            // Loop through each requested key in the array
            JToken? currentToken = null;
            foreach (string key in splitRequestedKey) {
                if (currentToken == null) currentToken = parsedObject[key]; else currentToken = currentToken[key]; 
            }
            if (currentToken != null) foundValue = currentToken.ToString(); 

            return foundValue;
        }

    }
}
