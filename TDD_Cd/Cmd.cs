using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Cd
{
    class Cmd
    {
        private const string parent = "..";
        private const string root = @"\";
        public string Cd(string currentPath, string inputPath)
        {
            if (inputPath == root)
                return GoToRootFolder(currentPath);
            return CaculatePath(currentPath, inputPath);
        }

        private string CaculatePath(string currentPath, string inputPath)
        {
            string[] arr = inputPath.Replace("/d", "").Trim().Split('\\').ToArray();
            foreach (var subPath in arr)
                currentPath = subPath == parent ? GoToParentFolder(currentPath) : GoToChildrenFolder(currentPath, subPath);
            return currentPath;
        }

        private string GoToChildrenFolder(string currentPath, string inputPath)
        {
            if (IsRoot(inputPath))
                return RegexRootPath(inputPath);
            return IsRoot(currentPath) ? currentPath + inputPath : currentPath + @"\" + inputPath;
        }

        private string RegexRootPath(string inputPath)
        {
            return inputPath.LastIndexOf(@"\") == 2 ? inputPath : inputPath + @"\";
        }

        private string GoToParentFolder(string currentPath)
        {
            return IsRoot(currentPath) ? currentPath : currentPath.Substring(0, currentPath.LastIndexOf(@"\"));
        }

        private string GoToRootFolder(string currentPath)
        {
            return IsRoot(currentPath) ? currentPath : currentPath.Substring(0, currentPath.IndexOf(@"\") + 1);
        }

        private bool IsRoot(string currentPath)
        {
            return currentPath != null 
                && (
                    (currentPath.Length == 3 && currentPath.LastIndexOf(@"\") == 2 && currentPath.Contains(":"))
                    || (currentPath.Length == 2 && currentPath.Contains(":")));
        }

    }
}
