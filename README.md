# Markdig Footnote Extension w/ Confluence Support

This project is the result of me getting very angry.

[PHP Markdown Extra][phpmde] introduced a very nice [footnote
syntax][phpmde-footnotes] as part of their Markdown extensions. Footnotes are
occasionally quite useful, especially when one is writing long design documents,
white papers, etc.

I wanted to use this extension, generate the plain HTML that it emits, and
upload that to Confluence as a page's content. What I found though was that
Confluence would strip the anchors/IDs that the extension was emitting, even
though they are perfectly valid internal anchors. Near as I can tell, this is
because Confluence wants you to use their anchor macro, which emits slightly
different IDs that include the page name.

First, I got angry, because this is a ridiculous thing for Confluence to do. I
could understand, to a degree, validating the anchors. I cannot understand
finding them valid and stripping them anyway.

Then I got even: Markdig is open source, and the footnote *rendering* code is
wonderfully simple. I looked at it, wrote some format strings to emit the markup
for Confluence's "structured macro" expansions, and reimplemented the two
renderer classes.

Thus, CodeRinseRepeat.MarkdigConfluenceFootnoteExtension was born out of
incandescent rage. I can only hope that someone besides me will find it useful.

[phpmde]: https://michelf.ca/projects/php-markdown/extra
[phpmde-footnotes]: https://michelf.ca/projects/php-markdown/extra/#footnotes

## Installing

The package is available [on NuGet][nuget].

[nuget]: https://nuget.org/packages/CodeRinseRepeat.MarkdigConfluenceFootnoteExtension
