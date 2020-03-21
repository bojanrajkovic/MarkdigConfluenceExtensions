using Markdig.Extensions.Footnotes;
using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace CodeRinseRepeat.MarkdigConfluenceFootnoteExtension
{
    public class ConfluenceHtmlFootnoteLinkRenderer : HtmlObjectRenderer<FootnoteLink>
    {
        const string BackLinkString = "&#8617;";
        const string AnchorMacro = @"<ac:structured-macro ac:name=""anchor""><ac:parameter ac:name="""">{0}</ac:parameter></ac:structured-macro>";
        const string AnchorLinkMacro = @"<ac:link ac:anchor=""{0}""><ac:link-body>{1}</ac:link-body></ac:link>";

        protected override void Write(HtmlRenderer renderer, FootnoteLink link)
        {
            string content;

            if (link.IsBackLink) {
                content = string.Format(
                    AnchorLinkMacro,
                    $"fnbref{link.Index}",
                    BackLinkString
                );
            } else {
                // Insert a backreference anchor and the anchor link to the forward reference
                content = string.Format(
                    AnchorLinkMacro,
                    $"fnref{link.Index}",
                    $"<sup>{link.Footnote.Order}</sup>"
                ) + string.Format(AnchorMacro, $"fnbref{link.Index}");
            }

            renderer.Write(content);
        }
    }
}
