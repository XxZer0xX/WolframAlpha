#region Referencing

using System;
using System.Linq;

#endregion

namespace WolframAlpha.XmlSerializable
{
    [Serializable]
    public abstract class Serializable
    {

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
