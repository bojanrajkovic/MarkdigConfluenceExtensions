using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Syntax;

namespace CodeRinseRepeat.MarkdigConfluenceExtensions
{
    class ConfluenceMacroParser : InlineParser
    {
        public ConfluenceMacroParser()
        {
            OpeningCharacters = new [] { '{' };
        }

        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            var match = slice.CurrentChar;

            if (slice.PeekCharExtra(-1) == match) {
                return false;
            }

            var startPosition = slice.Start;
            int openSticks = 0, closeSticks = 0;
            var c = slice.CurrentChar;

            while (c == match) {
                openSticks++;
                c = slice.NextChar();
            }

            var builder = processor.StringBuilders.Get();
            while (c != '\0') {
                // If we find a close brace, that's the end of our
                // macro. Otherwise, append to the builder.
                if (c == '}') {
                    do {
                        closeSticks++;
                        c = slice.NextChar();
                    } while (c == match);

                    if (openSticks == closeSticks) {
                        break;
                    }

                    builder.Append(match, closeSticks);
                    closeSticks = 0;
                } else {
                    builder.Append(c);
                    c = slice.NextChar();
                }
            }

            bool isMatching = false;

            if (closeSticks == openSticks) {
                processor.Inline = new ConfluenceMacro {
                    Delimiter = match,
                    Content = builder.ToString(),
                    Span = new SourceSpan(
                        processor.GetSourcePosition(startPosition, out int line, out int column),
                        processor.GetSourcePosition(slice.Start - 1)
                    ),
                    Line = line,
                    Column = column
                };
                isMatching = true;
            }
            processor.StringBuilders.Release(builder);

            return isMatching;
        }
    }
}
