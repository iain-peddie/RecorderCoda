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
        [Test]
        public void New_value_is_added_to_empty_repository()
        {
            Recorder recorder = new Recorder();

            ICommand command = new Command(recorder);

            command.Execute("value key 1");

            Assert.That(recorder.GetValueByKey("key"),Is.EqualTo(1));
        }


    }
}
