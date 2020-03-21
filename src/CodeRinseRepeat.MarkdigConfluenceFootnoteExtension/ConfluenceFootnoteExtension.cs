using Markdig;
using Markdig.Extensions.Footnotes;
using Markdig.Renderers;

namespace CodeRinseRepeat.MarkdigConfluenceFootnoteExtension
{
    public class ConfluenceFootnoteExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.BlockParsers.Contains<FootnoteParser>()) {
                pipeline.BlockParsers.Insert(0, new FootnoteParser());
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            if (renderer is HtmlRenderer htmlRenderer) {
                htmlRenderer.ObjectRenderers.AddIfNotAlready<ConfluenceHtmlFootnoteGroupRenderer>();
                htmlRenderer.ObjectRenderers.AddIfNotAlready<ConfluenceHtmlFootnoteLinkRenderer>();
            }
        }
    }
}
