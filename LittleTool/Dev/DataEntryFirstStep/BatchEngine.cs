using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using Utility;
using System.Xml;
using System.IO;

namespace DataEntryFirstStep
{
    class BatchEngine
    {
        private BatchState _batchState;
        private string _strStateFilePath = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDir"></param>
        /// <param name="nReBatch">重新加载一遍当前文件夹中的图像文件文件，原来记录清空</param>
        public BatchEngine(string strDir, bool nReBatch)
        {
            ArrayList fileList = new ArrayList();
            _strStateFilePath = strDir + "\\BatchState.xml";
            fileList = DirectoryReader.GetFiles(strDir, DataEntryForm.strImageConfig, false);

            if (nReBatch)
            {
                if (File.Exists(_strStateFilePath))
                {
                    try
                    {
                        File.Delete(_strStateFilePath);
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(_strStateFilePath + ": is opened by another program.");
                    }

                    _batchState = new BatchState();
                    foreach (string s in fileList)
                    {
                        FileState fs = new FileState();
                        fs.FilePath = s;
                        fs.State = FileState.Undone;
                        _batchState.FilesState.Add(fs);
                    }

                    _batchState.Save(_strStateFilePath);
                }
            }
            else
            {
                if (fileList.Count <= 0)
                {
                    return;
                }
                else if (File.Exists(_strStateFilePath))
                {
                    _batchState = BatchState.Load(_strStateFilePath);
                }
                else
                {
                    _batchState = new BatchState();
                    foreach (string s in fileList)
                    {
                        FileState fs = new FileState();
                        fs.FilePath = s;
                        fs.State = FileState.Undone;
                        _batchState.FilesState.Add(fs);
                    }

                    _batchState.Save(_strStateFilePath);
                }
            }


        }

        public BatchEngine()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFilePath">得是图像文件的全路径</param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool SetFileState(string strFilePath, int state)
        {
            if (_batchState.FilesState.Count <= 0)
            {
                return false;
            }
            foreach (FileState fs in _batchState.FilesState)
            {
                if (fs.FilePath.Equals(strFilePath))
                {
                    fs.State = state;
                    _batchState.Save(_strStateFilePath);
                    return true;
                }
            }
            return false;
        }

        public int GetFileState(string strFilePath)
        {
            strFilePath = Path.GetFullPath(strFilePath);
            strFilePath = strFilePath.Replace(".ocr.", ".");
            _batchState = BatchState.Load(_strStateFilePath);
            if (_batchState.FilesState.Count <= 0)
            {
                return -1;
            }
            foreach (FileState fs in _batchState.FilesState)
            {
                if (fs.FilePath.ToUpper().Equals(strFilePath.ToUpper()))
                {
                    return fs.State;
                }
            }
            return -1;
        }

        public bool isBatchEnd()
        {
            int i = 0;//控制一下，不去判断最后一个状态
            if (string.IsNullOrEmpty(_strStateFilePath))
            {
                return false;
            }
            if (_batchState == null)
            {
                _batchState = BatchState.Load(_strStateFilePath);
            }
            foreach (FileState fs in _batchState.FilesState)
            {
                i++;
                if (fs.State == FileState.Undone && i < _batchState.FilesState.Count)
                {
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// 如果手动的把一张图片移到proofer失败的情况，需要把其在BatchState.xml中的记录清楚
        /// 好像用不上，先留着，以后考虑
        /// </summary>
        /// <param name="strFileName">要删除的文件名，.csv的，或者没有扩展名</param>
        /// <returns></returns>
        public bool deleteOneFile(string strFileName)
        {
            if (string.IsNullOrEmpty(_strStateFilePath))
            {
                return false;
            }
            if (_batchState == null)
            {
                _batchState = BatchState.Load(_strStateFilePath);
            }
            foreach (FileState fs in _batchState.FilesState)
            {
                if (fs.FilePath.Contains(strFileName))
                {
                    _batchState.FilesState.Remove(fs);
                    _batchState.Save(_strStateFilePath);
                    return true;
                }
            }
            return false;

        }

        public ArrayList GetAllFileUndo()
        {
            ArrayList temp = new ArrayList();
            foreach (FileState fs in _batchState.FilesState)
            {
                if (fs.State == 0)
                {

                    temp.Add(fs.FilePath);
                }
            }
            return temp;
        }

        public ArrayList GetAllFile()
        {
            ArrayList temp = new ArrayList();
            foreach (FileState fs in _batchState.FilesState)
            {
                //if (fs.State == 0)
                {

                    temp.Add(fs.FilePath);
                }
            }
            return temp;
        }
    }

    public class BatchState
    {
        private List<FileState> _lFilesState;
        public BatchState()
        {
            _lFilesState = new List<FileState>();
        }
        [XmlArrayItem(typeof(FileState))]
        public List<FileState> FilesState
        {
            get { return _lFilesState; }
            set { _lFilesState = value; }
        }

        public bool Save(string filePath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(fs, Encoding.UTF8);

                XmlSerializer xs = new XmlSerializer(typeof(BatchState));
                xs.Serialize(xmlTextWriter, this);
                return true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
            finally
            {
                if (fs != null) fs.Dispose();
            }
        }

        public static BatchState Load(string filePath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(BatchState));
                BatchState batchState = (BatchState)xs.Deserialize(fs);
                return batchState;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
            finally
            {
                if (fs != null) fs.Dispose();
            }
        }


    }

    public class FileState
    {
        private string _strFilePath = "";
        private int _nState = 0;

        public static int Done = 1;
        public static int Undone = 0;

        public string FilePath
        {
            get { return _strFilePath; }
            set { _strFilePath = value; }
        }

        public int State
        {
            get { return _nState; }
            set { _nState = value; }
        }
    }
}
