using JetBrains.Annotations;
using Markdig;

namespace CodeRinseRepeat.MarkdigConfluenceExtensions
{
    [PublicAPI]
    public static class MarkdigPipelineExtensions
    {
        public static MarkdownPipelineBuilder UseConfluenceFootnotes(this MarkdownPipelineBuilder pipeline) =>
            pipeline.Use<ConfluenceFootnoteExtension>();

        public static MarkdownPipeline UseConfluenceFootnotes(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<ConfluenceFootnoteExtension>();
            return pipeline;
        }

        public static MarkdownPipelineBuilder UseConfluenceMacros(this MarkdownPipelineBuilder pipeline) =>
            pipeline.Use<ConfluenceMacroExtension>();

        public static MarkdownPipeline UseConfluenceMacros(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<ConfluenceMacroExtension>();
            return pipeline;
        }
    }
}
