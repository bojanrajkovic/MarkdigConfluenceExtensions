using System.Xml.Linq;
using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace CodeRinseRepeat.MarkdigConfluenceExtensions
{
    class HtmlConfluenceMacroRenderer : HtmlObjectRenderer<ConfluenceMacro>
    {
        protected override void Write(HtmlRenderer renderer, ConfluenceMacro obj)
        {
            XNamespace ac = "https://confluence.corp.firstrepublic.com";
            var macroName = obj.Content.Substring(0, obj.Content.IndexOf(':'));

            var macroInvocation = new XElement(ac + "structured-macro",
                new XAttribute(XNamespace.Xmlns + "ac", "https://confluence.corp.firstrepublic.com"),
                new XAttribute(ac + "name", macroName)
            );

            var macroParameterString = obj.Content.Substring(macroName.Length+1);
            var macroParameters = macroParameterString.Split('|');

            if (macroParameters.Length == 0) {
                var parameter = new XElement(ac + "parameter") { Value = macroParameterString };
                parameter.SetAttributeValue(ac + "name", string.Empty);
                macroInvocation.Add(parameter);
            } else {
                foreach (var parameterStr in macroParameters) {
                    var parameterName = parameterStr.Substring(0, parameterStr.IndexOf('='));
                    var parameterValue = parameterStr.Substring(parameterName.Length+1);
                    var parameter = new XElement(ac + "parameter") { Value = parameterValue };
                    parameter.SetAttributeValue(ac + "name", parameterName);
                    macroInvocation.Add(parameter);
                }
            }

            renderer.Write(macroInvocation.ToString());
        }
    }
}
