#region Referencing

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WolframAlpha.XmlSerializable.Warnings;

#endregion

namespace WolframAlpha.Collections
{
    public class WarningsList : IEnumerable<Warning>
    {
        public int Count { get { return this.warningsList.Count; } }

        public WarningsList()
        {
            this.warningsList = new List<Warning>();
        }

        private IList<Warning> warningsList { get; set; }

        public void Clear()
        {
            this.warningsList.Clear();
        }

        public bool Contains(Warning item)
        {
            return this.warningsList.Contains( item );
        }

        public bool IsReadOnly
        {
            get { return this.warningsList.IsReadOnly; }
        }

        public int IndexOf(Warning item)
        {
            return this.warningsList.IndexOf( item );
        }

        public void Insert(int index, Warning item)
        {
            this.warningsList.Insert( index , item );
        }

        public void RemoveAt(int index)
        {
            this.warningsList.RemoveAt( index );
        }

        public Warning this[int index]
        {
            get { return this.warningsList[index]; }
            set { this.warningsList[index] = value; }
        }

        public IEnumerator<Warning> GetEnumerator()
        {
            return this.warningsList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
