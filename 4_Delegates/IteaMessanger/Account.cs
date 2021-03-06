﻿using System;
using System.Collections.Generic;
using System.Linq;

using IteaDelegates.IteaMessanger;
using static ITEA_Collections.Common.Extensions;

namespace IteaDelegates.IteaMessanger
{
    public delegate void OnMessage(Message message);
    public delegate void OnMessageInGroup(GroupMessage message);
    public delegate void OnSend(object sender, OnSendEventArgs e);
    public delegate void OnGroupSend(object sender, OnGroupSendEventArgs e);

    public class Account
    {
        
        public string Username { get; private set; }
        public List<Message> Messages { get; set; } = new List<Message>();

        public event OnSend OnSend;
        public event OnGroupSend OnGroupSend;

        public OnMessage NewMessage { get; set; }

        public Account(string username)
        {
            Username = username;
            NewMessage += OnNewMessage;
        }

        public Message CreateMessage(string text, Account to)
        {
            var message = new Message(this, to, text);
            Messages.Add(message);
            return message;
        }

        public GroupMessage CreateGroupMessage(string text, Group groupname)
        {
            var message = new GroupMessage(this, groupname, text);
            groupname.MessagesInGroup.Add(message);
            return message;
        }

        public void Send(Message message)
        {
            message.Send = true;
            message.To.Messages.Add(message);
            message.To.NewMessage(message);
            OnSend?.Invoke(this, new OnSendEventArgs(message.ReadMessage(this), message.From.Username, message.To.Username));
        }

        public void OnNewMessage(Message message)
        {
            if (message.Send)
                ToConsole($"OnNewMessage: {message.From.Username}: {message.Preview}", ConsoleColor.DarkYellow);
        }
        public void OnNewMessageInGroup(GroupMessage message)
        {
            if (message.Send)
                ToConsole($"OnNewMessageInGroup: {message.From.Username}: {message.Preview}", ConsoleColor.DarkYellow);
        }

        public void Subsribe(Group groupname, Account username)
        {
            groupname.AccountsInGroup?.Add(username);
            groupname.NewMessageInGroup += OnNewMessageInGroup;
        }

        public void SendToGroup(GroupMessage messageToSend, Group groupname)
        {
            messageToSend.Send = true;
            groupname.MessagesInGroup.Add(messageToSend);
            messageToSend.To.NewMessageInGroup(messageToSend);
            OnGroupSend?.Invoke(this, new OnGroupSendEventArgs(messageToSend.ReadMessage(this), messageToSend.From.Username));
        }

        public void ShowDialog(string username)
        {
            List<Message> messageDialog = Messages
                .Where(x => x.To.Username.Equals(username) || x.From.Username.Equals(username))
                .Where(x => x.Send)
                .OrderBy(x => x.Created)
                .ToList();
            string str = $"Dialog with {username}";
            ToConsole($"---{str}---");
            foreach (Message message in messageDialog)
            {
                ToConsole($"{(message.From.Username.Equals(username) ? username : Username)}: {message.ReadMessage(this)}",
                    message.From.Username.Equals(username) ? ConsoleColor.Cyan : ConsoleColor.DarkYellow);
            }
            ToConsole($"---{string.Concat(str.Select(x => "-"))}---");
        }
    }
}
