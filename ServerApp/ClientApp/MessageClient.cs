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
        //private string _messageTypeString;

        public string GetMessage { get => _message; set => _message = value; }
        public string GetUsername { get => _username; set => _username = value; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType GetMessageType { get => _messageType; set => _messageType = value; }
        //public string MessageTypeString { get => _messageTypeString; set => _messageTypeString = value; }

        public Message(MessageType messageType, string username = "", string message = "")
        {
            _messageType = messageType;
            _message = message;
            _username = username;
        }

        /// <summary>
        /// Конвертировать в Json-строку
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            //_messageTypeString = _messageType.ToString();
            return JsonConvert.SerializeObject(this);
        }

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

                //switch (temp._messageTypeString)
                //{
                //    case "Message":
                //        _messageType = MessageType.Message;
                //        break;
                //    case "UserConnect":
                //        _messageType = MessageType.UserConnect;
                //        break;
                //    case "UserList":
                //        _messageType = MessageType.UserList;
                //        break;
                //    case "UserDisconnect":
                //        _messageType = MessageType.UserDisconnect;
                //        break;
                //    case "Error":
                //        _messageType = MessageType.Error;
                //        break;
                //    case "PrivateMessage":
                //        _messageType = MessageType.PrivateMessage;
                //        break;
                //    default:
                //        _messageType = MessageType.Message;
                //        break;
                //}
                return this;
            }
            catch (Exception) { return null; }
        }
    }
}
