using System;
using System.Collections.Generic;

namespace EOCS_CS
{
    internal class Parser : IParser
    {
        private readonly string[] originalContent;
        private int currentIndex;
        List<string> content = new List<string>();

        public Parser(string[] contents)
        {
            originalContent = contents;
            currentIndex = 0;
            RemoveCommentsAndWhitespaces();
        }

        public bool HasMoreCommands()
        {
            return currentIndex < content.Count - 1;
        }

        public void Advance()
        {
            if (HasMoreCommands())
            {
                currentIndex++;
            }
        }

        public Commands CommandType()
        {
            throw new NotImplementedException();
        }

        public string Symbol()
        {
            throw new NotImplementedException();
        }

        public string Dest()
        {
            throw new NotImplementedException();
        }

        public string Comp()
        {
            throw new NotImplementedException();
        }

        public string Jump()
        {
            throw new NotImplementedException();
        }

        private void ParseLine(string line)
        {
            line = line.Replace(" ", "");
        }

        private void RemoveCommentsAndWhitespaces()
        {
            string cleanLine;

            foreach (var line in originalContent)
            {
                cleanLine = RemoveComments(line);
                if (cleanLine != "")
                    content.Add(cleanLine);
            }

        }

        private string RemoveComments(string line)
        {
            var index = line.IndexOf("//", System.StringComparison.OrdinalIgnoreCase);
            if (index > -1)
            {
                line = line.Remove(index);
            }

            return line;
        }
    }
}