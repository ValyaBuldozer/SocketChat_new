﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServerApp
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    { UserDisconnect, UserConnect, UserList, Message, Error }

    public class Message
    {
        private string _message;
        private string _username;
        private MessageType _messageType;

        public string GetMessage { get => _message; set => _message = value; }
        public string Username { get => _username; }
        internal MessageType MessageType { get => _messageType; }

        public Message(MessageType messageType, string username = "", string message = "")
        {
            _messageType = MessageType;
            _message = message;
            _username = username;
        }

        /// <summary>
        /// Конвертировать в Json-строку
        /// </summary>
        /// <returns></returns>
        public string Serialize() => JsonConvert.SerializeObject(this);

        /// <summary>
        /// Конвертировать из JSon-строки
        /// </summary>
        /// <param name="jsonObject"></param>
        public Message Deserialize(string jsonObject)
        {
            try
            {
                Message temp = JsonConvert.DeserializeObject<Message>(jsonObject);

                _message = temp.GetMessage;
                _messageType = temp._messageType;
                _username = temp._username;
                return this;
            }
            catch (Exception) { return null; }
        }
    }
}