using System;
using BibReaderLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BibReaderTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void ScopusTest()
        {
            var scopusBibReader = new ScopusBibReader();

            var reader = new StreamReader(@"C:\Users\subbo\Desktop\курсач\Scopus\scopus.bib");
            string item = "";
            int j = 0;
            while(!reader.EndOfStream)
            {
                item = scopusBibReader.TestReader2(reader);
                Assert.AreEqual("source={Scopus},", item);
                j++;
            }
            //webOfScienceReder.Reader(reader);
            //scienceDirectBibReader.Reader(reader);

            reader.Close();
        }
    }
}
