using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ClientApp
{
    public enum MessageType
    { Message, UserConnect, UserList, UserDisconnect, Error, PrivateMessage }

    public class Message
    {
        private string _message;
        private string _username;
        private MessageType _messageType;
        private string _recipient;

        public string GetMessage { get => _message; set => _message = value; }
        public string GetUsername { get => _username; set => _username = value; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType GetMessageType { get => _messageType; }
        public string GetRecipient { get => _recipient; set => _recipient = value; }

        public Message(MessageType messageType, string username = "", string message = "", string recipient = "")
        {
            _messageType = messageType;
            _message = message;
            _username = username;
            _recipient = recipient;
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
                _username = temp._username;
                _messageType = temp.GetMessageType;
                return this;
            }
            catch (Exception) { return null; }
        }
    }
}
