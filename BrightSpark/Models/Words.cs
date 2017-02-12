using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrightSpark.Models
{
    public class Words
    {

        /// <summary>
        /// Value    | Behaviour
        /// "id"     | by the numeric id value in ascending order
        /// "-id"    | by the numeric id value in descending order
        /// "value"  | by the textual value in ascending order
        /// "-value" | by the textual value in descending order
        /// Default is "id".
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="unique"></param>
        public Dictionary<int, string> GetWords(string sort, bool unique)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "dog");
            dictionary.Add(2, "cat");
            dictionary.Add(3, "cat");
            dictionary.Add(4, "horse");


            // Set the default sort value to "id"
            var items = from pair in dictionary orderby pair.Key ascending select pair;

                switch (sort)
                {
                    case "-id":
                        items = from pair in dictionary orderby pair.Key descending select pair;
                        break;

                    case "value":
                        items = from pair in dictionary orderby pair.Value ascending select pair;
                        break;

                    case "-value":
                        items = from pair in dictionary orderby pair.Value descending select pair;
                        break;
                }

                 
                Dictionary<int, string> uniqueValues = new Dictionary<int, string>();
                if (unique)
                {
                    result = items.GroupBy(pair => pair.Value)
                                             .Select(group => group.First())
                                             .ToDictionary(pair => pair.Key, pair => pair.Value);
                }
                else
                {
                    result = items.ToDictionary(pair => pair.Key, pair => pair.Value); ;
                }


            return result;
        }
   }
}