using System;
using System.Collections.Generic;
using System.Text;

namespace project9
{
    public class Pancake: ITurnable
    {
        public string Turn()
        {
            return "Turning over the pancake to the uncooked side";
        }
    }
}
