using System;
using System.Collections.Generic;
using System.Text;
using static ITEA_Collections.Common.Extensions;

namespace IteaDelegates.IteaMessanger
{
    public class SpyNotificationsInGroup
    {
        public Account Observable { get; set; }

        public SpyNotificationsInGroup(Account observable)
        {
            Observable = observable;
            Observable.OnGroupSend += Detector;
        }
        public void Detector(object sender, OnGroupSendEventArgs e)
        {
            ToConsole($"Detected message sending...\n From: {e.From}\n Text: {e.Text}", ConsoleColor.Red);
        }
    }
}
