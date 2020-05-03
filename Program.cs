using System;
using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = StartCrawler();
            foreach (var item in x)
                Console.WriteLine(item + "\n");
            
            Console.ReadLine();


        }

        private  static List<Story> StartCrawler()
        {
            var html = @"https://www.straitstimes.com";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            var stories = new List<Story>();

            //select only div contains top-stories
            string sign_top_stories = @"Top Stories";
            var node_top_stories = htmlDoc.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("data-vr-zone", "").Contains(sign_top_stories));

            
            foreach (var item in node_top_stories)
            {
                var storieHeadline = item.Descendants("span").Where(node => node.GetAttributeValue("class", "").Equals("story-headline")).FirstOrDefault().Element("a");
                var story = new Story(html + storieHeadline.GetAttributeValue("href", "null"), storieHeadline.InnerText);
                stories.Add(story);
            }
            return stories;
        }
    }
}
