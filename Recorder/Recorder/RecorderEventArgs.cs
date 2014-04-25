// -----------------------------------------------------------------------
// <copyright file="RecorderEventArgs.cs" company="Microsoft">
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
    /// Recorder Event Arguments class.
    /// </summary>
    public class RecorderEventArgs : EventArgs
    {
        private readonly string message;

        public RecorderEventArgs(string message)
        {
            this.message = message;
        }

        public string Message
        {
            get { return this.message; }
        }
    }
}
