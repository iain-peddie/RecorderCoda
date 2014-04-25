using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recorder;

namespace RecorderTests
{
    using NUnit.Framework;

    [TestFixture]
    public class NotificationTests
    {
        [Test]
        public void Default_Message_Is_Empty()
        {
            // Where
            var recorder = CreateRecorder();

            // When
            string report = recorder.BuildChangeReport();

            // Then
            Assert.That(report, Is.EqualTo(""));
        }

        [Test]
        public void Message_With_One_Addition_Contains_Addition()
        {
            // Where
            var recorder = CreateRecorder();
            recorder.Add("key", 1);

            // When
            string report = recorder.BuildChangeReport();

            // Then
            Assert.That(report, Is.EqualTo("{key: 1}"));
            
        }

        private Recorder.Recorder CreateRecorder()
        {
            return new Recorder.Recorder(0);
        }
    }
}
