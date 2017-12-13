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
        private DateTime _time;

        public string GetMessage { get => _message; set => _message = value; }
        public string GetUsername { get => _username; set => _username = value; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType GetMessageType { get => _messageType; set => _messageType = value; }
        public string GetRecipient { get => _recipient; set => _recipient = value; }
        public DateTime GetTime { get => _time; set => _time = value; }

        public Message(MessageType messageType, DateTime time, string username = "", string message = "", string recipient = "")
        {
            _messageType = messageType;
            _message = message;
            _username = username;
            _recipient = recipient;
            _time = time;
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

                _message = temp.GetMessage;             //костыль плохо!
                _username = temp._username;
                _messageType = temp.GetMessageType;
                _time = temp.GetTime;
                _recipient = temp.GetRecipient;
                return this;
            }
            catch (Exception) { return null; }
        }
    }
}
