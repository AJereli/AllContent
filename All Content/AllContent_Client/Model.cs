using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AllContent_Client
{
    class EventAuthorization : EventArgs
    {
        public bool Result { get; private set; }
        public string Name { get; private set; }
        public EventAuthorization(bool result, string name)
        {
            Result = result;
            Name = name;
        }
    }

    class Model
    {
        public event EventHandler AuthorizationEvent = delegate { };

        User user;

        ObservableCollection<ContentUnit> cont_collect;

        BackgroundWorker loadContent;
        public Model()
        {
            user = new User();
            loadContent = new BackgroundWorker();
            loadContent.DoWork += LoadContent_DoWork;
            cont_collect = new ObservableCollection<ContentUnit>();

        }

        private void Authorization(string login, string passw)
        {
            bool result = user.Authorization(login, passw);

            AuthorizationEvent(this, new EventAuthorization(result, login));
            
        }

        private void LoadContent_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
