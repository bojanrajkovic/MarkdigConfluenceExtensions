using Markdig.Extensions.Footnotes;
using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace CodeRinseRepeat.MarkdigConfluenceFootnoteExtension
{
    public class ConfluenceHtmlFootnoteGroupRenderer : HtmlObjectRenderer<FootnoteGroup>
    {
        const string GroupClass = "footnotes";
        const string AnchorMacro = @"<ac:structured-macro ac:name=""anchor""><ac:parameter ac:name="""">{0}</ac:parameter></ac:structured-macro>";

        protected override void Write(HtmlRenderer renderer, FootnoteGroup footnotes)
        {
            renderer.EnsureLine();
            renderer.WriteLine($"<div class=\"{GroupClass}\">");
            renderer.WriteLine("<hr />");
            renderer.WriteLine("<ol>");

            foreach (Footnote footnote in footnotes)
            {
                var anchorMacro = string.Format(AnchorMacro, $"fnref{footnote.Order}");
                renderer.WriteLine($"<li>");
                renderer.Write(anchorMacro);
                renderer.WriteChildren(footnote);
                renderer.WriteLine("</li>");
            }
            renderer.WriteLine("</ol>");
            renderer.WriteLine("</div>");
        }
    }
}
