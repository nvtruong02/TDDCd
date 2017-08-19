using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Cd
{
    class ListTestCase
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(@"c:\a\b", @"c\d").Returns(@"c:\a\b\c\d");
                yield return new TestCaseData(@"c:\a\b", @"..\c\d").Returns(@"c:\a\c\d");
               
            }
        }  
    }
}
