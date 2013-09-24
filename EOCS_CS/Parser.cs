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
            currentIndex = -1;
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

        public string CurrentRawLine()
        {
            return currentIndex >= content.Count
                       ? ""
                       : content[currentIndex];
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
            foreach (var line in originalContent)
            {
                var cleanLine = RemoveComments(line);
                cleanLine = RemoveWhitespaces(cleanLine);

                if (cleanLine != "")
                    content.Add(cleanLine);
            }
        }

        private string RemoveComments(string line)
        {
            var index = line.IndexOf("//", StringComparison.OrdinalIgnoreCase);
            if (index > -1)
            {
                line = line.Remove(index);
            }

            return line;
        }

        private string RemoveWhitespaces(string line)
        {
            return line == null ? "" : line.Replace(" ", "");
        }
    }
}