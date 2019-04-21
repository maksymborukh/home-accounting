using System;

namespace UI.Date
{
    public class Date
    {
        public string date { get { return DateTime.Now.ToUniversalTime().ToString(); } }
    }
}
