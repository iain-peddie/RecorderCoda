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
            IModifiable modifiable=null;
            IQueryable queryable=null;
            ICommand command = new Command(modifiable);

            command.Execute("value key myValue");

            Assert.That(queryable.GetValueByKey("key"),Is.EqualTo("myValue"));
        }


    }
}
