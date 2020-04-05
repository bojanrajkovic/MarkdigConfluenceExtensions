using Markdig.Syntax.Inlines;

namespace CodeRinseRepeat.MarkdigConfluenceExtensions
{
    class ConfluenceMacro : LeafInline
    {
        /// <summary>
        /// Gets or sets the delimiter character used by this code inline.
        /// </summary>
        public char Delimiter { get; set; }

        /// <summary>
        /// Gets or sets the content of the span.
        /// </summary>
        public string Content { get; set; }
    }
}