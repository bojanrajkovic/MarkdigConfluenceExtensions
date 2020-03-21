using Markdig;

namespace CodeRinseRepeat.MarkdigConfluenceFootnoteExtension
{
    public static class MarkdigPipelineExtensions
    {
        public static MarkdownPipelineBuilder UseConfluenceFootnotes(this MarkdownPipelineBuilder pipeline) =>
            pipeline.Use<ConfluenceFootnoteExtension>();

        public static MarkdownPipeline UseConfluenceFootnotes(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<ConfluenceFootnoteExtension>();
            return pipeline;
        }
    }
}
