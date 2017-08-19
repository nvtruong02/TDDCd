using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDD_Cd
{
    [TestFixture]
    class CdUnitTest
    {
        Cmd cmd;
        [SetUp]
        public void CreateCmd()
        {
            cmd = new Cmd();
        }

        //[Test, TestCaseSource(typeof(ListTestCase), "TestCases")]
        //public string FormCurrent_GoToNewFolder(string currentPath, string inputPath)
        //{
        //    return cmd.Cd(currentPath, inputPath);
            
        //}

        private void UnitTestCdAndAssert(string currentPath, string inputPath, string resultPath)
        {
            var path = cmd.Cd(currentPath, inputPath);
            Assert.AreEqual(resultPath, path);
        }

        [TestCase(@"c:\a\b",@"c\d",@"c:\a\b\c\d")]
        [TestCase(@"c:\", @"c\d", @"c:\c\d")]
        public void FromCurrent_GoToChildrent(string currentPath, string inputPath, string resultPath)
        {
            UnitTestCdAndAssert(currentPath, inputPath, resultPath);
        }

        [TestCase(@"c:\a\b", "..", @"c:\a")]
        [TestCase(@"c:\", "..", @"c:\")]
        public void FromCurrent_GoToParent(string currentPath, string inputPath, string resultPath)
        {
            UnitTestCdAndAssert(currentPath, inputPath, resultPath);
        }

        [TestCase(@"c:\a\b", @"\", @"c:\")]
        [TestCase(@"c:\", @"\", @"c:\")]
        public void FromCurrent_GoToRoot(string currentPath, string inputPath, string resultPath)
        {
            UnitTestCdAndAssert(currentPath, inputPath, resultPath);
        }

        [TestCase(@"c:\a\b", @"..\e", @"c:\a\e")]
        [TestCase(@"c:\", @"..\..\e", @"c:\e")]
        [TestCase(@"c:\a\b\c\d", @"..\..\e\f", @"c:\a\b\e\f")]
        [TestCase(@"c:\a\b\c\d", @"..\e\..\f", @"c:\a\b\c\f")]
        [TestCase(@"c:\a\b\c\d", @"..\e\..\f", @"c:\a\b\c\f")]
        public void FromCurrent_MixToParentToChildren(string currentPath, string inputPath, string resultPath)
        {
            UnitTestCdAndAssert(currentPath, inputPath, resultPath);
        }

        [TestCase(@"c:\a\b", @"c:\", @"c:\")]
        [TestCase(@"c:\a\b", @"c:\c\d", @"c:\c\d")]
        [TestCase(@"c:\a\b", @"/dd:", @"d:\")]
        [TestCase(@"c:\a\b", @"/d d:\e\f", @"d:\e\f")]
        public void FromCurrent_GoToDirectPath(string currentPath, string inputPath, string resultPath)
        {
            UnitTestCdAndAssert(currentPath, inputPath, resultPath);
        }

    }
}
