// -----------------------------------------------------------------------
// <copyright file="Queryable.cs" company="Microsoft">
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
    /// 
    /// </summary>
    public interface IQueryable
    {
        int GetValueByKey(string key);      
    }
}
