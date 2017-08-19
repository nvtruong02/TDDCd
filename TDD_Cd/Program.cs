using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Cd
{
    class Program
    {
        static void Main(string[] args)
        {
            Cmd cmd = new Cmd();
            var path = cmd.Cd(@"c:\a\b", @"c:\");
            
        }
    }
}
