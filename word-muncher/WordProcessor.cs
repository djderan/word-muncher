using PorterStemmer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace word_muncher
{
    /// <summary>
    /// Contains all methods needed to be able to count the number of words in a selected string that have the Stemming algorithm applied.
    /// </summary>
    internal class WordProcessor
    {
        private char[] Delimitters => new[] { ' ', '\n' };
        private IDictionary<string, long> WordCount { get; } = new Dictionary<string, long>();
        private IEnumerable<string> StopWords { get; }
        private IEnumerable<string> ContentList { get; }

        public WordProcessor(string fileContents)
        {
            StopWords = Properties.Resources.stopwords
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim().ToLowerInvariant().StemWord());

            string contents = new string(fileContents.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            ContentList = contents
                .Split(Delimitters, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim().ToLowerInvariant().StemWord())
                .Where(s => !StopWords.Any(stopWord => stopWord.Equals(s, StringComparison.OrdinalIgnoreCase)));

            foreach (string word in ContentList)
            {
                if (!WordCount.TryAdd(word, 1))
                {
                    WordCount[word]++;
                    continue;
                }
            }
            WordCount = WordCount.OrderByDescending(i => i.Value).ThenBy(i => i.Key).ToDictionary(k => k.Key, v => v.Value);
        }

        /// <summary>
        /// Gets the top twenty occurences of words in a string.  In the case of a tie, alphanumerica sorting is the tie breaker.
        /// </summary>
        /// <returns>A Dictionary containing the word and number of occurances. </returns>
        public IDictionary<string, long> GetTopTwentyOccurances()
        {
            return WordCount.Take(20).ToDictionary(k => k.Key, v => v.Value);
        }
    }
}