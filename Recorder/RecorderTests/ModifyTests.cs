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
    public class ModifyTests
    {
        [Test]
        public void Add_unique_key_value_adds_to_dictionary()
        {
            Recorder.Recorder recorder = createStubRecorder();

            recorder.Add("test",1);

            Assert.AreEqual(1,recorder.GetValueByKey("test"));
            
        }


        private Recorder.Recorder createStubRecorder()
        {
            return new Recorder.Recorder();
        }
    }
}
