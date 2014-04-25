// -----------------------------------------------------------------------
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
            Recorder.Recorder recorder = createStubRecorder();

            // When
            // Then

            Assert.Throws(typeof(KeyNotFoundException), delegate() { recorder.GetValueByKey("asdf"); });
        }

        [Test]
        public void Client_receives_notification_after_n_events()
        {
            // Where
            int notificationLimit = 10;
            Recorder.Recorder recorder = createStubRecorder();
            bool receievedNotification = false;
            recorder.RecorderEvents += (s,e) => { receievedNotification = true;};
            Recorder.Command command = new Recorder.Command(recorder);
            for (int i = 0; i <= notificationLimit; i++)
            {
                command.Execute("value something" + i + " " + i);
            }
            // When
            // Then
            Assert.IsTrue(receievedNotification);
        }

        private Recorder.Recorder createStubRecorder()
        {
            return new Recorder.Recorder(0);
        }
    }
}
