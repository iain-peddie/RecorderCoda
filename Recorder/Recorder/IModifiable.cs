// -----------------------------------------------------------------------
// <copyright file="IModifiable.cs" company="Microsoft">
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
    /// TODO: Update summary.
    /// </summary>
    public interface IModifiable
    {
        void Add(string key, string value);
        void DeleteByKey(string key);

        void Clear();
    }
}
