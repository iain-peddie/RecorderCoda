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
        /// <summary>
        /// Implemented method from IQueryable to get value by key
        /// </summary>
        /// <param name="key">Key to search for</param>
        /// <returns>String value or KeyNotFoundException</returns>
        public string GetKeyByValue(string key)
        {
            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void DeleteByKey(string key)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
