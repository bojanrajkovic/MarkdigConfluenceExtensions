using Markdig;
using Markdig.Renderers;

namespace CodeRinseRepeat.MarkdigConfluenceExtensions
{
    class ConfluenceMacroExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.InlineParsers.Contains<ConfluenceMacroParser>()) {
                pipeline.InlineParsers.Insert(0, new ConfluenceMacroParser());
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer) {
            if (renderer is HtmlRenderer htmlRenderer) {
                htmlRenderer.ObjectRenderers.AddIfNotAlready<HtmlConfluenceMacroRenderer>();
            }
        }
    }
}
