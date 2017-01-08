using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Erudit.Core.BO;

namespace Erudit.Core
{
    public class Logic
    {
        private readonly List<Placeholder> _placeholders;
        private readonly List<Letter> _letters;
        private readonly string _lettersSet;
        private byte letterCount;

        public Logic(List<Placeholder> placeholders, List<Letter> letters)
        {
            _placeholders = placeholders;
            _letters = letters;
            _lettersSet = GetLettersSet();
        }

        public List<Letter> GetWord()
        {
            letterCount = (byte)_lettersSet.Length;
            string pattern ;
            if (_placeholders == null || !_placeholders.Any())
            {
                pattern = GetSimplePattern(letterCount);
            }
            else
            {
                pattern = GetComplexPattern();
            }

            pattern = $"^{pattern}\r\n";
            Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            var matches = regex.Matches(Constants.Words).Cast<Match>().Select(m => m.Value).ToList();

            foreach (var m in matches)
            {
                Console.WriteLine(m);
            }

            return null;
        }

        private string GetLettersSet()
        {
            return string.Join(string.Empty, _letters.Where(l => l.Value != '*').Select(l => l.Value));
        }

        private string GetSimplePattern(int count)
        {
            string pattern = string.Empty;
            for (int i = 1; i <= count; i++)
            {
                if (i < letterCount)
                {
                    var w = string.Join("|", Enumerable.Range(1, i).Select(ii => $"\\{ii.ToString()}"));
                    pattern += $"([{_lettersSet}])(?!{w})";
                }
                else
                {
                    pattern += $"([{_lettersSet}])";
                }
            }
            return pattern;
        }

        private string GetComplexPattern()
        {
            var pattern = string.Empty;
            foreach (Placeholder placeholder in _placeholders)
            {
                if (placeholder.Value == ' ')
                {
                    pattern = GetSimplePattern(placeholder.Max);
                }
                else
                {
                    pattern += placeholder.Value;
                }
            }            
            return pattern;            
        }
    }
}
