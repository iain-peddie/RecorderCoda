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

        [Test]
        public void Add_existing_key_modifies_value_in_dictionary()
        {
            Recorder.Recorder recorder = createStubRecorder();

            recorder.Add("test", 1);
            recorder.Add("test", 2);

            Assert.AreEqual(2, recorder.GetValueByKey("test"));

        }

        [Test]
        public void Add_null_key_throws()
        {
            Recorder.Recorder recorder = createStubRecorder();

            Assert.Throws(typeof(ArgumentNullException), delegate() { recorder.Add(null, 1); });

        }

        [Test]
        public void Drop_non_existant_key_for_dictionary_results_does_not_throw()
        {
            Recorder.Recorder recorder = createStubRecorder();

            recorder.Add("test", 1);
            recorder.DeleteByKey("Bob");

            // correct behaviour is no exception thrown
        }

        [Test]
        public void Drop_existant_key_for_dictionary_results_in_removal_from_dictionary()
        {
            Recorder.Recorder recorder = createStubRecorder();

            recorder.Add("test", 1);

            Assert.AreEqual(1, recorder.GetValueByKey("test"));

            recorder.DeleteByKey("test");

            Assert.Throws(typeof(KeyNotFoundException), delegate() { recorder.GetValueByKey("test"); });
        }

        [Test]
        public void Clear_removes_all_values()
        {
            Recorder.Recorder recorder = createStubRecorder();

            recorder.Add("test", 1);
            recorder.Add("test2", 2);

            recorder.Clear();

            Assert.Throws(typeof(KeyNotFoundException), delegate() { recorder.GetValueByKey("test"); });
            Assert.Throws(typeof(KeyNotFoundException), delegate() { recorder.GetValueByKey("test2"); });
        }

        private Recorder.Recorder createStubRecorder()
        {
            return new Recorder.Recorder();
        }
    }
}
