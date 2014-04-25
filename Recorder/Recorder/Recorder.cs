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
    using System.Runtime.Remoting.Messaging;
    using System.Text;

    /// <summary>
    /// Recorder class
    /// </summary>
    public class Recorder : IQueryable, IModifiable
    {

        private Dictionary<string, int> recordingsCollection = new Dictionary<string, int>();
        private Dictionary<string, int> checkpointCollection = new Dictionary<string, int>();

        public event EventHandler RecorderEvents;

        private int commandCounter;

        private readonly int n;

        public Recorder(int n)
        {
            this.n = n;
            this.commandCounter = 0;
        }

        public void RegisterInvalidCommand(string commandString)
        {
            SendNotifications("Invalid command entered: " + commandString);
        }

        private void SendNotifications(string message)
        {
            EventHandler handler = RecorderEvents;
            if (handler != null)
            {
                handler(this, new RecorderEventArgs(message));
            }
        }


        private void IncrementCounterAndFireNotifications()
        {
            this.commandCounter++;
            if (this.commandCounter == n)
            {
                string changes = this.BuildChangeReport();
                this.SendNotifications(changes);

                //Reset for next cycle
                commandCounter = 0;
                this.checkpointCollection.Clear();
                foreach (KeyValuePair<string, int> keyValuePair in recordingsCollection)
                {
                    this.checkpointCollection.Add(keyValuePair.Key,keyValuePair.Value);
                }
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

            this.IncrementCounterAndFireNotifications();
        }

        /// <summary>
        /// Deletes the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void DeleteByKey(string key)
        {
            recordingsCollection.Remove(key);


            this.IncrementCounterAndFireNotifications();
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            recordingsCollection.Clear();
        }

        public string BuildChangeReport()
        {
            StringBuilder builder = new StringBuilder();

            foreach (KeyValuePair<string, int> keyValuePair in recordingsCollection)
            {
                if(this.checkpointCollection.ContainsKey(keyValuePair.Key) && this.checkpointCollection[keyValuePair.Key]!=keyValuePair.Value)
                {
                   // We have found a modification
                    builder.AppendFormat(
                        "Key: {0} Modified by {1}\n",
                        keyValuePair.Key,
                        checkpointCollection[keyValuePair.Key] - keyValuePair.Value);
                }

                if (!this.checkpointCollection.ContainsKey(keyValuePair.Key))
                {
                    //Add 
                    builder.AppendFormat("Key: {0} Added", keyValuePair.Key);
                }
                
            }

            foreach (KeyValuePair<string, int> keyValuePair in this.checkpointCollection)
            {
                if (!recordingsCollection.ContainsKey(keyValuePair.Key))
                {
                    // Deleted
                    builder.AppendFormat("Key: {0} Deleted", keyValuePair.Key);
                }
            }

            return builder.ToString();
        }
    }
}
