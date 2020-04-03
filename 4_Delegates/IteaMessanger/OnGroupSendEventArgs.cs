using System;
using System.Collections.Generic;
using System.Text;

namespace IteaDelegates.IteaMessanger
{
    public class OnGroupSendEventArgs : EventArgs
    {
        public string Text { get; set; }
        public string From { get; set; }

        public OnGroupSendEventArgs(string text, string from)
        {
            Text = text;
            From = from;
        }
    }
}
