using System;
using System.Collections.Generic;
using System.Text;

namespace IteaDelegates.IteaMessanger
{
    public class GroupMessage
    {
        readonly string text;

        public Account From { get; set; }
        public Group To { get; set; }
        public bool Read { get; set; }
        public bool Send { get; set; }
        public DateTime Created { get; private set; }

        public string Preview
        {
            get
            {
                return $"{text.Substring(0, 10)}...";
            }
        }

        public GroupMessage(Account from, Group to, string text)
        {
            From = from;
            To = to;
            this.text = text;
            Read = false; //?
            Created = DateTime.Now;
        }

        public string ReadMessage(Account username)
        {
            Read = true;
            return From == username ? text : string.Empty;
        }


    }
}
