using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AllContent_Client
{
    class Favorites
    {

        public List<string> current_favorites { get; private set; }
        public Favorites()
        {
            current_favorites = new List<string>();
        }
        
        public void Add(string favor)
        {
            current_favorites.Add(favor);
        }
        
        public void Delete (string favor)
        {
            current_favorites.Remove(favor);
        }
    }
}