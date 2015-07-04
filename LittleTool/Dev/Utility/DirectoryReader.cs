using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public class DirectoryReader
    {
        public static ArrayList GetFiles(string dir, bool checkSubfolder)
        {
            const string pattern = "*";
            return GetFiles(dir, pattern, checkSubfolder);
        }

        public static ArrayList GetFiles(string dir, string pattern, bool checkSubfolder)
        {
            var list = new ArrayList();

            string[] patterns = null;

            patterns = pattern.Split('|');

            foreach (string strPattern in patterns)
            {
                if (Directory.Exists(dir))
                {
                    if (checkSubfolder)
                    {
                        ArrayList temp = new ArrayList();
                        temp = GetFiles(dir, strPattern);
                        list.AddRange(temp);
                    }
                    else
                    {
                        try
                        {
                            string[] files = Directory.GetFiles
                                (dir, strPattern, SearchOption.TopDirectoryOnly);
                            foreach (string s in files)
                            {
                                list.Add(s);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return list;
        }

        private static ArrayList GetFiles(string root, string pattern)
        {
            var dirs = new Stack<string>(20);
            var list = new ArrayList();
            var subDirs = new string[0];
            string[] files = null;

            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();

                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    continue;
                }
                catch
                {
                }

                try
                {
                    files = Directory.GetFiles(currentDir, pattern);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    continue;
                }
                catch
                {
                }

                foreach (string file in files)
                {
                    list.Add(file);
                }

                foreach (string str in subDirs)
                {
                    dirs.Push(str);
                }
            }
            return list;
        }
    }
}
