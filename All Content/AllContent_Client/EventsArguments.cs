using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllContent_Client
{
    class EventAuthorizationArgs : EventArgs
    {
        public bool Result { get; private set; }
        public string Name { get; private set; }
        public EventAuthorizationArgs(bool result, string name)
        {
            Result = result;
            Name = name;
        }
    }

    class EventFavoritesArgs : EventArgs
    {
        public Favorites favor { get; private set; }

        public EventFavoritesArgs(Favorites curr_fav)
        {
            favor = curr_fav;
        }
    }
}
