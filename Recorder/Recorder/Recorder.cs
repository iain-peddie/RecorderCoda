// -----------------------------------------------------------------------
// <copyright file="Recorder.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Recorder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Recorder class
    /// </summary>
    public class Recorder : IQueryable, IModifiable
    {

        private Dictionary<string, int> recordingsCollection = new Dictionary<string, int>();

        public event EventHandler RecorderEvents;

        private void SendNotifications()
        {
            EventHandler handler = RecorderEvents;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Implemented method from IQueryable to get value by key
        /// </summary>
        /// <param name="key">Key to search for</param>
        /// <returns>String value or KeyNotFoundException</returns>
        public int GetValueByKey(string key)
        {

            int value = recordingsCollection[key];

            return value;
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, int value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException();

            if (recordingsCollection.ContainsKey(key))
            {
                recordingsCollection[key] = value;
            }
            else
            {
                recordingsCollection.Add(key, value);
            }
        }

        /// <summary>
        /// Deletes the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void DeleteByKey(string key)
        {
            recordingsCollection.Remove(key);
        }

        public void Clear()
        {
            recordingsCollection.Clear();
        }
    }
}
