using System;
using HtmlAgilityPack;

class Program
{
    static void Main()
    {
        string url = "https://quizlet.com/803779911/wgu-d426-v2-flash-cards/?funnelUUID=ad9152ff-0d9d-4591-a28d-cf82b56fb0d3";

        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);

        var termNodes = doc.DocumentNode.SelectNodes("//span[@class='TermText']");

        if (termNodes != null)
        {
            string[] terms = termNodes.Select(node => node.InnerText).ToArray();
            string combinedTerms = string.Join(" ", terms);

            Console.WriteLine(combinedTerms);
        }
        else
        {
            Console.WriteLine("No terms found." + doc.DocumentNode.InnerHtml);
        }

    }
}



