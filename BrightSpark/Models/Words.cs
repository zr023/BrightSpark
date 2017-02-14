using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrightSpark.Models
{
    public class Words
    {
        public static Dictionary<int, string> dicp = new Dictionary<int, string>();

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

            dictionary = dicp;

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

                // Remove duplicate values
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

            dicp = result;
            return result;
        }

        /// <summary>
        ///  Add array of words to existing dictionary and return the new dictionary
        /// </summary>
        /// <param name="sa"></param>
        /// <returns></returns>
        public Dictionary<int, string> AddWords(string[] sa)
        {
            try
            {
                int dc = dicp.Count();
                if (dc != 0)
                {

                    int countsa = 0;
                    int countdicp = 0;

                    Dictionary<string, int> counts = sa.GroupBy(x => x)
                                      .ToDictionary(g => g.Key,
                                                    g => g.Count());

                    foreach (string word in sa)
                    {

                        // Count the number of occurences in dicp
                        countdicp = dicp.Count(kvp => kvp.Value.Contains(word));

                        // Count the number of occurence in each word in sa
                        countsa = counts.FirstOrDefault(x => x.Key == word).Value;


                        if (countdicp != countsa)
                        {
                            for (int id = 0; id <= dc; id++)
                            {
                                if (!dicp.ContainsKey(id))
                                {
                                    dicp.Add(id, word);
                                }
                            }
                        }
                    }
                }
                else //in case dictionary is empty
                {
                    int idn = 0;
                    foreach (string wordn in sa)
                    {
                        dicp.Add(idn, wordn);
                        idn++;
                    }

                }
            }
            catch (Exception)
            {
                return null;
            }

            return dicp;
        }
        /// <summary>
        /// Delete all words in dictionary
        /// </summary>
        public string DeleteAllWords()
        {
            try
            {
                dicp.Clear();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "ok";
        }
    }
    
    /// <summary>
    /// Structure containing the value of n that we are requesting, and the nth number in the Fibonacci sequence
    /// </summary>
    public struct WordsStruct
    {
        public uint wordId;
        public string word;
    }
}