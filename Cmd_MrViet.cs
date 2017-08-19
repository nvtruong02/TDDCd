using System.Linq;

namespace Cd
{
    class Cmd
    {
        private const string Root = @"\";
        private const string Parent = "..";
        public string Cd(string currentPath, string path)
        {
            if (path == Root)
                return GotoRoot(currentPath);
            return IsRoot(path) ? path : path.Split('\\').Aggregate(currentPath, CalculatePath);
        }

        private static string GotoRoot(string currentPath)
        {
            return currentPath.Substring(0, currentPath.IndexOf(@"\") + 1);
        }
        
        private static string CalculatePath(string currentPath, string path)
        {
            if (path == Parent)
                return GotoParrentFolder(currentPath);
            if (IsRoot(currentPath))
                return currentPath + path;
            return currentPath + @"\" + path;
        }

        private static string GotoParrentFolder(string currentPath)
        {
            return IsRoot(currentPath) ? currentPath : currentPath.Substring(0, currentPath.LastIndexOf(@"\"));
        }
        

        private static bool IsRoot(string currentPath)
        {
            return currentPath != null && (currentPath.LastIndexOf(@"\") == 2 && currentPath.Contains(":"));
        }
    }
}
