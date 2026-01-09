using System;
using System.Collections.Generic;
using System.Text;

namespace project9
{
    public class Page : ITurnable
    {
        public string Turn()
        {
            return "Turning the page over to a new one";
        }
    }
}
