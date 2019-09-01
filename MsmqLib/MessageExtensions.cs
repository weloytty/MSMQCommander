using System.IO;
using System.Messaging;
using System.Text;

namespace MsmqLib
{
    public static class MessageExtensions
    {
        public static string GetMessageBodyAsString(this Message message)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(GetStreamAsByteArray(message.BodyStream), 0, (int)message.BodyStream.Length);
        }


        public static string GetMessageBodyAsUnicodeString(this Message message)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            return encoding.GetString(GetStreamAsByteArray(message.BodyStream), 0, (int)message.BodyStream.Length);
        }

        public static string GetMessageBodyWithEncoding(this Message message, Encoding encodingToUse)
        {
            if (encodingToUse == null) { encodingToUse = Encoding.Unicode; }
            return encodingToUse.GetString(GetStreamAsByteArray(message.BodyStream), 0, (int)message.BodyStream.Length);
        }


        public static byte[] GetStreamAsByteArray(Stream stream)
        {
            stream.Position = 0;
            byte[] streamAsByteArray = new byte[stream.Length];
            stream.Read(streamAsByteArray, 0, (int)stream.Length);
            return streamAsByteArray;
        }

        public static string GetExtensionDataAsString(this Message message)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(message.Extension, 0, message.Extension.Length);
        }


        public static string GetExtensionDataAsUnicodeString(this Message message)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            return encoding.GetString(message.Extension, 0, message.Extension.Length);
        }



        public static byte[] GetBodyAsByteArray(this Message message)
        {
            message.BodyStream.Position = 0;
            byte[] bodyAsByteArray = new byte[message.BodyStream.Length];
            message.BodyStream.Read(bodyAsByteArray, 0, (int)message.BodyStream.Length);
            return bodyAsByteArray;
        }
    }
}
