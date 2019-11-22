﻿using System.Collections.Generic;
using System.Linq;
using Markdown.Core.Rules;

namespace Markdown.Core.Parsers
{
    class MainParser : IParser
    {
        private readonly IEnumerable<IRule> rules;

        public MainParser(IEnumerable<IRule> rules)
        {
            this.rules = rules;
        }


        public List<TagToken> ParseLine(string line)
        {
            var singleTagTokens = new SingleTagParser(rules).ParseLine(line);
            var doubleTagTokens = new DoubleTagParser(rules).ParseLine(line);
            return singleTagTokens.Concat(doubleTagTokens).ToList();
        }
    }
}