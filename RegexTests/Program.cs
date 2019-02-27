using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace RegexTests
{
    class Program
    {
        static readonly string ParagraphMatcher = @"(?:\r?\n){2,}";
        static readonly string TermMatcher = @"(?sim)^terms:.*?(?=(?:\r?\n){2,}|\z)";

        static void Main(string[] args)
        {
            TermsTest();
        }

        static void TermsTest()
        {
           var text = @"Terms: 1 I've got the {name} and {term}
    So I would like to go
    But not return

Term: 2 I've got the {name} and {term}
    So I would like to go
    But not return

Terms: 3 I've got the {name} and {term}
    So I would like to go
    But not return
";

            var termResults = Regex.Matches(text, TermMatcher)
                .Cast<Match>()
                .Select(x => x.Value)
                .ToList();
            
            var count = termResults.Count; // 2

            var paraResults = Regex.Split(text, ParagraphMatcher);

            var paraCount = paraResults.Count(); // 3
         }
    }
}
