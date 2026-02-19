using System;
using System.Linq;
using Game339.Shared.Diagnostics;

namespace Game339.Shared.Services.Implementation
{
    public class StringService : IStringService
    {
        private readonly IGameLog _log;

        public StringService(IGameLog log)
        {
            _log = log;
        }

        public string Reverse(string input)
        {
            var output = new string(input.Reverse().ToArray());
            _log.Info($"{nameof(StringService)}.{nameof(Reverse)} - {nameof(input)}: {input} - {nameof(output)}: {output}");
            return output;
        }

        public string ReverseWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;
// Split on spaces, remove empty entries
            string[] words = input.Split(' ',
                StringSplitOptions.RemoveEmptyEntries);
// Reverse the array
            Array.Reverse(words);
// Join back into a single string
            return string.Join(" ", words);
        }
    }
}