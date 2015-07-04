using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility;
using System.Collections;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using NLog;

namespace DataEntryFirstStep
{
    public partial class DataEntryForm : Form
    {
        public static readonly Logger logger = LogManager.GetCurrentClassLogger();

        bool bFirstExit = true;

        ArrayList listImagePath = new ArrayList();//读取到所有的要处理的图片信息
        private BatchEngine _batchEngine; //控制batch
        public static String strImageConfig = "*.png|*.bmp|*.jpg|*.tif";//要读取的图片的名称中所包含的特征
        private string _strImagePath = "";
        private List<string> listDataEntryEnum = new List<string>{"first area", "A - B", "C - D", "E - F", "G - H", "I - L", "M - N" };
        private string strWorkingDir = "";

        public static int nFirstAreaPer = 1300;
        public static int nSecondAreaPer = 2484;
        public static int nThirdAreaPer = 3765;
        public static int nForthAreaPer = 4792;
        public static int nFifthAreaPer = 5741;
        public static int nSixthAreaPer = 6729;
        public static int nSeventhAreaPer = 7482;
        int _nCurrentImageIndex = 0;

        public static DummyAS DAPicture = new DummyAS();

        string _strCsvFilePath = "";

        public DataEntryForm()
        {
            InitializeComponent();
        }

        private void openDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _folderName = @"C:\";
            _folderName = (System.IO.Directory.Exists(_folderName)) ? _folderName : "";
            var dlg1 = new FolderBrowserDialogEx
            {
                Description = "Select a folder for the extracted files:",
                ShowNewFolderButton = true,
                ShowEditBox = true,
                //NewStyle = false,
                SelectedPath = _folderName,
                ShowFullPathInEditBox = false,
            };
            dlg1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            var result = dlg1.ShowDialog();
            
            string strBathStateFile = "";//记录当前目录下的BatchState.xml文件

            if (result == DialogResult.OK)
            {
                strWorkingDir = Path.GetFullPath(dlg1.SelectedPath);
                strBathStateFile = strWorkingDir + "\\BatchState.xml";
            }
            else
            {
                return;
            }

            //if (File.Exists(strBathStateFile))
            //{
            //    DataEntryForm.logger.Info("*****************************************************************");
            //    DataEntryForm.logger.Info("继续上次batch");
            //    DataEntryForm.logger.Info("*****************************************************************");
            //    DialogResult DiaResult = new DialogResult();
            //    DiaResult = MessageBox.Show("Do you want to continue the Batch? ", "Proofer", MessageBoxButtons.YesNo);
            //    BatchEngine engine = new BatchEngine(strWorkingDir, false);
                
            //    if (DiaResult == DialogResult.Yes)
            //    {
            //        int nTotal = engine.GetAllFile().Count;
            //        int nUndo = engine.GetAllFileUndo().Count;
            //        MessageBox.Show("You will do \t" + nUndo + "\nTotal number \t" + nTotal);
            //        listImagePath = engine.GetAllFileUndo();
            //        if (listImagePath.Count == 0)
            //        {
            //            MessageBox.Show("This batch is closed.");
            //            return;
            //        }
            //    }
                //else
            //    {
            //        DataEntryForm.logger.Info("*****************************************************************");
            //        DataEntryForm.logger.Info("打开一个新batch");
            //        DataEntryForm.logger.Info("*****************************************************************");
            //        listImagePath = DirectoryReader.GetFiles(strWorkingDir, strImageConfig, false);
            //        if (listImagePath.Count > 0)
            //        {
            //            _batchEngine = new BatchEngine(strWorkingDir, true);
            //        }
            //    }
            //}
            //else//该目录下没有BatchState.xml
            {
                DataEntryForm.logger.Info("*****************************************************************");
                DataEntryForm.logger.Info("打开一个新batch");
                DataEntryForm.logger.Info("*****************************************************************");
                listImagePath = DirectoryReader.GetFiles(strWorkingDir, strImageConfig, false);
                //if (listImagePath.Count > 0)
                //{
                //    _batchEngine = new BatchEngine(strWorkingDir, false);
                //}
            }
            LogInfo.nTotalPage = listImagePath.Count;
            DataEntryForm.logger.Info("总页数:\t" + LogInfo.nTotalPage);
            LogInfo.dtSoftWareStartTime = DateTime.Now;//加载完成后开始及时

            if (listImagePath.Count == 0)
            {
                MessageBox.Show("Image's path must contain:\t" + strImageConfig);
                return;
            }

            if (listImagePath.Count > 0)
            {
                if (_nCurrentImageIndex < listImagePath.Count && _nCurrentImageIndex >= 0)
                {
                    processOneImage(listImagePath[_nCurrentImageIndex].ToString());
                }
            }
            
        }

        private bool processOneImage(string strImagePath)
        {
            LogInfo.dtStartTime = DateTime.Now;

            //DataEntryForm.logger.Info(strImagePath + "开始时间:\t" + LogInfo.dtStartTime);

            if (!parseFileName(strImagePath))
            {
                return false;
            }
            _strImagePath = strImagePath;
            showImage(strImagePath);
            showImageState(strImagePath);
            return true;
        }

        /// <summary>
        /// 显示两个东西
        /// 1. 该图片的index
        /// 2. 该图片是否已经被录入
        /// </summary>
        /// <param name="i">BatchState中的状态,0代表没有完成，1代表完成</param>
        private void showImageState(string strImagePath)
        {
            int nIndex = 0;
            int i = 0;
            string strWorkingDir = Path.GetDirectoryName(strImagePath);

            if (_batchEngine == null)
            {
                _batchEngine = new BatchEngine(strWorkingDir, false);
            }
            nIndex = listImagePath.IndexOf(strImagePath) + 1;
            i = _batchEngine.GetFileState(strImagePath);

            lblIndexTotal.Text = nIndex.ToString() + "  of  " + listImagePath.Count.ToString();

            if (i == 0)
            {
                lblFileState.Text = "Unprocessed";
            }
            else if (i == 1)
            {
                lblFileState.Text = "Done";
            }
            else
            {
                lblFileState.Text = "Error";
            }
        }

        private bool showImage(string strImagePath)
        {
            DAPicture.Text = strImagePath;
            DAPicture.FileName = strImagePath;
            DAPicture.Show(dockPanel1);
            return true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        

        /// <summary>
        /// parse file path according the image file path
        /// </summary>
        /// <param name="strImagePath"></param>
        private bool parseFileName(string strImagePath)
        {
            strImagePath = Path.GetFullPath(strImagePath);

            if (!File.Exists(strImagePath))
            {
                MessageBox.Show("Image is missing.");
                return false;
            }
            else
            {
                _strCsvFilePath = Path.ChangeExtension(strImagePath, ".csv");
            }
            return true;
        }

        private void bttNext_Click(object sender, EventArgs e)
        {
            int nNextImageIndex = _nCurrentImageIndex + 1;
            if (nNextImageIndex < listImagePath.Count && nNextImageIndex >= 0)
            {
                processOneImage(listImagePath[nNextImageIndex].ToString());
                _nCurrentImageIndex++;
            }
            if (nNextImageIndex == listImagePath.Count)
            {
                MessageBox.Show("Last One");
            }
        }

        private void bttPrevious_Click(object sender, EventArgs e)
        {
            int nPreviousIndex = _nCurrentImageIndex - 1;
            if (nPreviousIndex < listImagePath.Count && nPreviousIndex >= 0)
            {
                processOneImage(listImagePath[nPreviousIndex].ToString());
                _nCurrentImageIndex--;
            }
            if (nPreviousIndex == -1)
            {
                MessageBox.Show("First One");
            }
        }

        private void bttBatchClosed_Click(object sender, EventArgs e)
        {
            if (listImagePath.Count <= 0)
            {
                return;
            }

            LogInfo.nAlreadyDonePages = _batchEngine.GetAllFile().Count - _batchEngine.GetAllFileUndo().Count;
            LogInfo.dtBatchCloseTime = DateTime.Now;
            if (LogInfo.nAlreadyDonePages != 0)
            {
                //算平均一页所花时间
                TimeSpan ts = LogInfo.dtBatchCloseTime - LogInfo.dtSoftWareStartTime;
                double secPerPage = (double)ts.TotalSeconds / LogInfo.nAlreadyDonePages;
                double charCountPerPage = (double)LogInfo.CharacterTotalCount / LogInfo.nAlreadyDonePages;

                DataEntryForm.logger.Info("平均每页字符数：\t" + charCountPerPage);
                DataEntryForm.logger.Info("平均每页的速度：\t" + secPerPage);
            }
            DataEntryForm.logger.Info("*****************************************************************");
            DataEntryForm.logger.Info("Batch结束");
            DataEntryForm.logger.Info("*****************************************************************");

            string strBathCsvFileName = Directory.GetParent(_strImagePath).Name;
            strBathCsvFileName += ".csv";
            MergerCsv mc = new MergerCsv(Path.GetDirectoryName(_strImagePath), strBathCsvFileName);

            mc.MergerToOneCsv();
            MessageBox.Show("Batch Closed");
        }


        private void jumpDAPicture(int nPercent)
        {

        }

        private string getActivedDataEntryTab()
        {   
            for (int index = dockPanel1.Contents.Count - 1; index >= 0; index--)
            {
                if (dockPanel1.Contents[index] is IDockContent)
                {
                    IDockContent content = (IDockContent)dockPanel1.Contents[index];
                    if (listDataEntryEnum.Contains(content.DockHandler.TabText) && content.DockHandler.IsActivated)
                    {
                        return content.DockHandler.TabText;
                    }
                }
            }
            return "";
        }

        private bool setActivedDataEntryTab(string strTabText)
        {
            for (int index = dockPanel1.Contents.Count - 1; index >= 0; index--)
            {
                if (dockPanel1.Contents[index] is IDockContent)
                {
                    IDockContent content = (IDockContent)dockPanel1.Contents[index];
                    if (listDataEntryEnum.Contains(content.DockHandler.TabText) && content.DockHandler.TabText == strTabText)
                    {
                        content.DockHandler.Show();
                        if (strTabText == "first area")
                        {
                            DAPicture.setYScrollPosition(nFirstAreaPer);
                        }
                        if (strTabText == "A - B")
                        {
                            DAPicture.setYScrollPosition(nSecondAreaPer);
                        }
                        else if (strTabText == "C - D")
                        {
                            DAPicture.setYScrollPosition(nThirdAreaPer);
                        }
                        else if (strTabText == "E - F")
                        {
                            DAPicture.setYScrollPosition(nForthAreaPer);
                        }
                        else if (strTabText == "G - H")
                        {
                            DAPicture.setYScrollPosition(nFifthAreaPer);
                        }
                        else if (strTabText == "I - L")
                        {
                            DAPicture.setYScrollPosition(nSixthAreaPer);
                        }
                        else if (strTabText == "M - N")
                        {
                            DAPicture.setYScrollPosition(nSeventhAreaPer); 
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAPicture.Zoom(0.05);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAPicture.Zoom(-0.05);
        }

    }
}
