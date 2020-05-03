using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler
{
    class Story
    {
        public string link { get; private set; }
        public string title { get; private set; }

        public Story(string link, string title)
        {
            this.link = link;
            this.title = title;
        }

        
        public override string ToString()
        {
            return $"link = {link}, title = {title}";
        }
    }
}
