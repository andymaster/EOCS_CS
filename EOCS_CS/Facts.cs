using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EOCS_CS
{
    public class Facts
    {

        public class ParserFacts
        {

            [Fact]
            public void When_only_comments__dont_execute()
            {
                var contents = new[]
                    {
                        "//"
                    };

                var parser = new Parser(contents);
                parser.Advance();

                Assert.Equal(false, parser.HasMoreCommands());
            }
        }


    }
}
