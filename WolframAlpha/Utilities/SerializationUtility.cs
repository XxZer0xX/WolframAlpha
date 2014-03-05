#region Referencing

using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.Utilities
{
    public static class SerializationUtility
    {
        public static T Deserialize<T>(XDocument doc)
        {
            doc.Declaration = new XDeclaration("1.0","UTF-8","yes");
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var reader = doc.Root.CreateReader())
            {
                return (T) xmlSerializer.Deserialize(reader);
            }
        }

        public static XDocument Serialize<T>(T value)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                xmlSerializer.Serialize(writer, value);
            }

            return doc;
        }
    }
}
