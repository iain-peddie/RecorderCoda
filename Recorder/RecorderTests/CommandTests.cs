using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecorderTests
{
    using NUnit.Framework;

    using Recorder;

    [TestFixture]
    public class CommandTests
    {
        private Recorder TestRecorder { set; get; }
        private Command TestCommand { set; get; }   
    
        [SetUp]
        public void SetUp()
        {
            TestRecorder = new Recorder();
            TestCommand = new Command(TestRecorder);
        }

        [Test]
        public void New_value_is_added_to_empty_repository()
        {
            

            TestCommand.Execute("value key 1");

            Assert.That(TestRecorder.GetValueByKey("key"),Is.EqualTo(1));
        }

        [Test]
        public void Extant_value_dropped_from_repository()
        {
            // Where
            TestRecorder.Add("something", 2);

            // When
            TestCommand.Execute("drop something");

            // Then
            Assert.Throws(
                typeof(KeyNotFoundException),
                delegate()
                { TestRecorder.GetValueByKey("something"); });
        }

        [Test]
        public void Extant_value_cleared_from_repository()
        {
            // Where
            TestRecorder.Add("something", 2);

            // When
            TestCommand.Execute("clear");

            // Then
            Assert.Throws(
                typeof(KeyNotFoundException),
                delegate()
                { TestRecorder.GetValueByKey("something"); });
        }


    }
}
