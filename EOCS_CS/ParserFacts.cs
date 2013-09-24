using Xunit;
using Xunit.Extensions;

namespace EOCS_CS
{

    public class ParserFacts
    {

        [Fact]
        public void When_content_is_single_comment__HasMoreCommands_should_be_false()
        {
            var contents = new[] {"//"};

            var parser = new Parser(contents);
            parser.Advance();

            Assert.Equal(false, parser.HasMoreCommands());
        }

        [Fact]
        public void When_content_is_multiple_comments__HasMoreCommands_should_be_false()
        {
            var contents = new[] {"//  ", "//  ", "//  "};

            var parser = new Parser(contents);
            parser.Advance();

            Assert.Equal(false, parser.HasMoreCommands());
        }

        [Fact]
        public void When_content_is_only_spaces__HasMoreCommands_should_be_false()
        {
            var contents = new[] {"   ", "   ", "  "};

            var parser = new Parser(contents);
            parser.Advance();

            Assert.Equal(false, parser.HasMoreCommands());
        }

        [Theory]
        [InlineData("A=B", "A=B")]
        [InlineData(" A=B", "A=B")]
        [InlineData(" A=B ", "A=B")]
        [InlineData("A=B ", "A=B")]
        [InlineData(" A = B ", "A=B")]
        [InlineData("A = B", "A=B")]
        [InlineData("A= B", "A=B")]
        [InlineData("A =B", "A=B")]
        public void When_command_contains_spaces__should_be_removed(string line, string expected)
        {
            var contents = new[] {line};

            var parser = new Parser(contents);
            parser.Advance();
            var rawLine = parser.CurrentRawLine();

            Assert.Equal(expected, rawLine);
        }

        [Fact]
        public void When_there_are_two_commands__Should_be_returned_in_the_right_order()
        {
            const string FIRST_COMMAND = "A=B";
            const string SECOND_COMMAND = "C=D";
            var content = new[] {FIRST_COMMAND, SECOND_COMMAND};

            var parser = new Parser(content);

            parser.Advance();
            Assert.Equal(FIRST_COMMAND, parser.CurrentRawLine());
            parser.Advance();
            Assert.Equal(SECOND_COMMAND, parser.CurrentRawLine());
        }
    }
}
