using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shortener.Data
{
    public class ShortenerService
    {
        private SHSHConnector _connector = new SHSHConnector();
        private Random _random = new Random();
        public string GetRandomId()
        {
            string s = "";
            for (int i = 0; i < 6; i++)
            {
                int rand = _random.Next(0, 61);
                if (rand < 10)
                {
                    s += (char)('0' + rand);
                }
                else if (rand < 36)
                {
                    s += (char)('a' + rand - 10);
                }
                else
                {
                    s += (char)('A' + rand - 36);
                }
            }
            
            return Collision(s) ? GetRandomId() : s;
        }

        public bool Collision(string shortLink)
        {
            return _connector.Links.Any(x => x.Link == shortLink);
        }

        public void Create(string redirect, string shortLink)
        {
            _connector.Add(new ShortLink()
            {
                Redirect = redirect,
                Link = shortLink,
                CreatedDate = DateTime.UtcNow
            });
            _connector.SaveChanges();
        }
    }
}
