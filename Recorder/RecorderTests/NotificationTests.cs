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
            Assert.That(report, Is.EqualTo("Key: key Added"));
            
        }


        [Test]
        public void Client_receives_notification_after_invalid_event()
        {
            // Where
            Recorder.Recorder recorder = createStubRecorder(2);
            bool receievedNotification = false;
            string commandString = "wrong command";
            recorder.RecorderEvents += (s, e) =>
            {
                receievedNotification = true;
                Assert.IsTrue(((Recorder.RecorderEventArgs)e).Message.EndsWith(commandString));
            };
            Recorder.Command command = new Recorder.Command(recorder);

            command.Execute(commandString);

            // When
            // Then
            Assert.IsTrue(receievedNotification);
        }

        [Test]
        public void Client_receives_notification_after_n_events()
        {
            // Where
            int notificationLimit = 10;
            Recorder.Recorder recorder = createStubRecorder(notificationLimit);
            bool receievedNotification = false;
            recorder.RecorderEvents += (s, e) => { receievedNotification = true; };
            Recorder.Command command = new Recorder.Command(recorder);
            for (int i = 0; i <= notificationLimit; i++)
            {
                command.Execute("value something" + i + " " + i);
            }
            // When
            // Then
            Assert.IsTrue(receievedNotification);
        }


        [Test]
        public void Client_receives_no_notification_after_n_minus_one_events()
        {
            // Where
            int notificationLimit = 10;
            Recorder.Recorder recorder = createStubRecorder(notificationLimit);
            bool receievedNotification = false;
            recorder.RecorderEvents += (s, e) => { receievedNotification = true; };
            Recorder.Command command = new Recorder.Command(recorder);
            for (int i = 0; i < notificationLimit; i++)
            {
                command.Execute("value something" + i + " " + i);
            }
            // When
            // Then
            Assert.IsFalse(receievedNotification);
        }

        private Recorder.Recorder CreateRecorder()
        {
            return new Recorder.Recorder(0);
        }

        private Recorder.Recorder createStubRecorder(int notificationNumber)
        {
            return new Recorder.Recorder(notificationNumber);
        }

    }
}
