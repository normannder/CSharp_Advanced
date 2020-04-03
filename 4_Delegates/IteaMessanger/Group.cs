using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using static ITEA_Collections.Common.Extensions;
using IteaDelegates.IteaMessanger;
namespace IteaDelegates.IteaMessanger
{

    public class Group
    {
        public OnMessageInGroup NewMessageInGroup { get; set; }

        
        public List<Account> AccountsInGroup { get; set; }
        public List<GroupMessage> MessagesInGroup { get; set; }

        public Group(string groupname, Account chiefAccount)
        {
            AccountsInGroup = new List<Account>();
            MessagesInGroup = new List<GroupMessage>();

            ToConsole($"{groupname} group created!");
            ToConsole($"The creator of the group is {chiefAccount.ToString()}");
                AccountsInGroup.Add(chiefAccount);
        }
        public void ShowGroupDialog(Group groupname)
        {
            List<Message> messageDialog = MessagesInGroup
                .Where(x => x.From.Username.Equals(username))
                .Where(x => x.Send)
                .OrderBy(x => x.Created)
                .ToList();

            foreach (Message message in messageDialog)
            {
                ToConsole($"{(message.From.Username.Equals(username) ? username : Username)}: {message.ReadMessage(this)}",
                    message.From.Username.Equals(username) ? ConsoleColor.Cyan : ConsoleColor.DarkYellow);
            }
            ToConsole($"---{string.Concat(str.Select(x => "-"))}---");
        }

    }
}
