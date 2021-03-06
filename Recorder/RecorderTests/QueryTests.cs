﻿// -----------------------------------------------------------------------
// <copyright file="QueryTests.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RecorderTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class QueryTests
    {
        [Test]
        public void Getting_key_from_empty_recorder_throws_exception()
        {
            // Where
            Recorder.Recorder recorder = createStubRecorder(0);

            // When
            // Then

            Assert.Throws(typeof(KeyNotFoundException), delegate() { recorder.GetValueByKey("asdf"); });
        }

        private Recorder.Recorder createStubRecorder(int notificationNumber)
        {
            return new Recorder.Recorder(notificationNumber);
        }
    }
}
