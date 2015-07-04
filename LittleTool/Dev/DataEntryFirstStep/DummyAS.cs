using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Atalasoft.Imaging.Drawing;
using Atalasoft.Imaging;
using Emgu.CV.Structure;
using Emgu.CV;
using System.IO;
using Utility;
using System.Collections;

namespace DataEntryFirstStep
{
    public partial class DummyAS : DockContent
    {
        public DummyAS()
        {
            InitializeComponent();
        }
        private string m_fileName = string.Empty;
        private AtalaImage imageBackup; //存储没有画之前的图像，以防画错
        private int nScrollXOffset = 0;
        private int nScrollYOffset = 0;

        /// <summary>
        /// 读图像
        /// </summary>
        public string FileName
        {
            get { return m_fileName; }
            set
            {
                double dRatio = 0.0;
                if (value != string.Empty)
                {
                    Atalasoft.Imaging.AtalaImage img = new Atalasoft.Imaging.AtalaImage(value);
                    if (img.PixelFormat != PixelFormat.Pixel24bppBgr)
                    {
                        img = img.GetChangedPixelFormat(PixelFormat.Pixel24bppBgr);
                    }

                    workspaceViewer1.Image = img;
                    imageBackup = (AtalaImage)this.workspaceViewer1.Image.Clone();
                    workspaceViewer1.Dock = DockStyle.Fill;
                    workspaceViewer1.MouseTool = Atalasoft.Imaging.WinControls.MouseToolType.None;
                    

                    if (File.Exists(".\\Zoom.txt"))
                    {
                        StreamReader sr = new StreamReader(".\\Zoom.txt");
                        string str = "";
                        str = sr.ReadLine();
                        Double.TryParse(str, out dRatio);
                        sr.Close();
                    }
                    else
                    {
                        dRatio = (double)workspaceViewer1.Width / img.Width;    
                    }
                    workspaceViewer1.Zoom = dRatio;

                    //workspaceViewer1.AutoZoom = Atalasoft.Imaging.WinControls.AutoZoomMode.FitToWidth;
                    workspaceViewer1.MouseWheelScrolling = true;
                }
                m_fileName = value;
                this.ToolTipText = value;
                oneStroke.clearAll();
                this.Refresh();
            }
        }

        private void workspaceViewer1_ScrollChanged(object sender, Atalasoft.Imaging.WinControls.ScrollEventArgs e)
        {
            nScrollXOffset = (int)(this.workspaceViewer1.ScrollPosition.X / this.workspaceViewer1.Zoom);
            nScrollYOffset = (int)(this.workspaceViewer1.ScrollPosition.Y / this.workspaceViewer1.Zoom);

            richTextBox1.Text = "Y:\t" + workspaceViewer1.ScrollPosition.Y + "\n";
            richTextBox1.Text += "Total:\t" + workspaceViewer1.Image.Height + "\n";
            richTextBox1.Text += "After zoom Total:\t" + workspaceViewer1.Image.Height * workspaceViewer1.Zoom + "\n";
            richTextBox1.Text += "Control Height: \t" + workspaceViewer1.Height + "\n";
            richTextBox1.Text += "Zoom Rate:\t" + workspaceViewer1.Zoom + "\n";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nPercentage">去四位小数，表示为整数即可</param>
        /// <returns></returns>
        public bool setYScrollPosition(int nPercentage)
        {
            int nScrollPositinY = 0;
            nScrollPositinY = (int)(workspaceViewer1.Image.Height * nPercentage / 10000 * workspaceViewer1.Zoom);
            workspaceViewer1.ScrollPosition = new Point(0, -nScrollPositinY);
            return true;
        }

        public int getYScrollPosition()
        {
            return workspaceViewer1.ScrollPosition.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nPixel">正数向上滚动，负数向下滚动</param>
        /// <returns></returns>
        public bool addYScrollPosition(int nPixel)
        {
            int nYScrollPosition = workspaceViewer1.ScrollPosition.Y;
            nYScrollPosition = nYScrollPosition + nPixel;

            workspaceViewer1.ScrollPosition = new Point(0, nYScrollPosition);
            return true;
        }

        public void DrawLineOnImage(Color color)
        {

            if (workspaceViewer1 != null && workspaceViewer1.Image != null)
            {
                Canvas canvas = new Canvas(workspaceViewer1.Image);
                canvas.SmoothingLevel = 0;
                AtalaPen pen = new AtalaPen(color, 5);

                if (oneStroke.listPoints.Count >= 2)
                {
                    List<Point> listTempPoint = new List<Point>();
                    foreach (Point p in oneStroke.listPoints)
                    {
                        Point temp = new Point(p.X - nScrollXOffset, p.Y - nScrollYOffset);
                        listTempPoint.Add(temp);
                    }
                    canvas.DrawLines(listTempPoint.ToArray(), pen);
                }
            }

            try
            {
                workspaceViewer1.Undos.Add("drawLines", true);
            }
            catch (System.Exception ex)
            {
                workspaceViewer1.Dispose();
                return;
            }

        }


        private word oneHanzi = new word();
        private strokes oneStroke = new strokes();
        private List<Point> listPoints = new List<Point>(); // 存储一笔的所有点

        bool nFirstLeftClick = false;
        bool nSecondRightClick = false;

        private void workspaceViewer1_MouseClick(object sender, MouseEventArgs e)
        {
            List<strokes> strokesForOneWord = new List<strokes>();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                oneStroke.listPoints.Add(new Point((int)(e.X / this.workspaceViewer1.Zoom), (int)(e.Y / this.workspaceViewer1.Zoom)));
                DrawLineOnImage(Color.Red);
                toolStripStatusLabel1.Text = "开始画笔画";
                nFirstLeftClick = true;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right && !IsControlDown()
                && !nFirstLeftClick)
            {
                MessageBox.Show("请选择笔画");
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right && !IsControlDown()
                && nFirstLeftClick)
            {
                //Point point = new Point(e.X, e.Y);
                // prepare to select the property
                SelectProperty property = new SelectProperty();
                property.FormClosed += property_FormClosed;
                Rectangle rec = new Rectangle(e.X, e.Y, 150, 300);
                property.Show(dockPanel1, rec);

                //contextMenuStrip1.Show(point);
                //oneStroke.strProperty = property
                toolStripStatusLabel1.Text = "正在画笔画中……";

            }
            else if (IsControlDown() && e.Button == System.Windows.Forms.MouseButtons.Right
            && !nSecondRightClick)
            {
                MessageBox.Show("请选择笔画属性");
            }
            else if (IsControlDown() && e.Button == System.Windows.Forms.MouseButtons.Right
                && nSecondRightClick)
            {
                Emgu.CV.Image<Bgr, Byte> img_lines = new Emgu.CV.Image<Bgr, byte>(this.workspaceViewer1.Image.ToBitmap());
                Emgu.CV.Image<Bgr, Byte> img = new Emgu.CV.Image<Bgr, byte>(m_fileName);
                oneHanzi.nXScrollOffset = nScrollXOffset;
                oneHanzi.nYScrollOffset = nScrollYOffset;
                //Rectangle rec = oneHanzi.getBoundingRectangle();
                Rectangle rec = new Rectangle(0, 0, img.Width, img.Height);
                img_lines.ROI = rec;
                img.ROI = rec;
                Emgu.CV.Image<Bgr, Byte> crop = new Emgu.CV.Image<Bgr, Byte>(rec.Width, rec.Height);
                Emgu.CV.Image<Bgr, Byte> crop2 = new Emgu.CV.Image<Bgr, Byte>(rec.Width, rec.Height);
                CvInvoke.cvCopy(img, crop, IntPtr.Zero);
                CvInvoke.cvCopy(img_lines, crop2, IntPtr.Zero);
                oneHanzi.wordimage = crop;
                oneHanzi.wordimageWithLines = crop2;
                oneHanzi.save(m_fileName);
                oneHanzi.clear();
                toolStripStatusLabel1.Text = "存储完毕";
                nFirstLeftClick = false;
                nSecondRightClick = false;
                if (File.Exists(".\\Temp.txt"))
                {
                    File.Delete(".\\Temp.txt");
                }
                imageBackup = (AtalaImage)this.workspaceViewer1.Image.Clone();
                //crop.Save("E:\\ww.jpg");
            }
            this.workspaceViewer1.Refresh();
        }

        void property_FormClosed(object sender, FormClosedEventArgs e)
        {
            SelectProperty temp = (SelectProperty)sender;
            oneStroke.strProperty = temp.getProperty();

            if (temp.getProperty() == "reset")
            {
                this.workspaceViewer1.Image = imageBackup;
                oneStroke.clearAll();
                nSecondRightClick = true;
                if (File.Exists(".\\Temp.txt"))
                {
                    File.Delete(".\\Temp.txt");
                }
            }
            else
            {
                oneHanzi.strWordContent = temp.getWordContent();
                StreamWriter sw = new StreamWriter(".\\Temp.txt");
                sw.Write(oneHanzi.strWordContent);
                strokes temp_s = new strokes();
                temp_s = oneStroke.copyto();
                oneHanzi.listStrokes.Add(temp_s);
                oneStroke.clearAll();
                nSecondRightClick = true;
                sw.Close();
            }

        }

        public bool IsControlDown()
        {
            return (Control.ModifierKeys & Keys.Control) == Keys.Control;
        }


        /// <summary>
        /// 选择笔画的属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;

            switch (item.Text)
            {
                case "横":
                    oneStroke.strProperty = "h";
                    break;
                case "竖":
                    oneStroke.strProperty = "s";
                    break;
                case "撇":
                    oneStroke.strProperty = "p";
                    break;
                case "捺":
                    oneStroke.strProperty = "n";
                    break;
                default:
                    break;
            }
            strokes temp = new strokes();
            temp = oneStroke.copyto();
            oneHanzi.listStrokes.Add(temp);
            oneStroke.clearAll();
            nSecondRightClick = true;
        }

        public void Zoom(double ratio)
        {
            if (this.workspaceViewer1.Zoom + ratio > 0)
            {
                this.workspaceViewer1.Zoom += ratio;
            }
            else
            {
                this.workspaceViewer1.Zoom = 0.0;
            }
            this.workspaceViewer1.Refresh();
        }

        #region Nothing
        private void workspaceViewer1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void workspaceViewer1_MouseEnter(object sender, EventArgs e)
        {

        }


        private void DummyAS_Load(object sender, EventArgs e)
        {
        }

        private void workspaceViewer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }
        #endregion

        private void workspaceViewer1_ZoomChanged(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(".\\Zoom.txt");
            sw.Write(this.workspaceViewer1.Zoom.ToString());
            sw.Close();
        }


    }

    public class strokes
    {
        public List<Point> listPoints = new List<Point>();
        public string strProperty = "";
        public void clearAll()
        {
            listPoints.Clear();
            strProperty = "";
        }
        public strokes copyto()
        {
            strokes temp = new strokes();
            foreach (Point point in this.listPoints)
            {
                temp.listPoints.Add(point);
            }
            temp.strProperty = this.strProperty;
            return temp;
        }
    }

    /// <summary>
    /// 一个汉字，包括该汉字的图片，以及对应的笔画
    /// 还有存储等方法
    /// </summary>
    public class word
    {
        public Emgu.CV.Image<Bgr, Byte> wordimage;
        public Emgu.CV.Image<Bgr, Byte> wordimageWithLines;
        public string strWordContent = "";
        public List<strokes> listStrokes = new List<strokes>();
        /// <summary>
        /// listStrokesCropedImage contains the coordinates which have been converted to
        /// to meet the cropped image.
        /// </summary>
        public List<strokes> listStrokesCropedImage
        {
            get
            {
                List<strokes> temp = new List<strokes>();
                foreach (strokes s in listStrokes)
                {
                    strokes temp_s = new strokes();
                    temp_s.strProperty = s.strProperty;
                    foreach (Point temp_p in s.listPoints)
                    {
                        temp_s.listPoints.Add(new Point(temp_p.X - nXOffset - nXScrollOffset, temp_p.Y - nYOffset - nYScrollOffset));
                    }
                    temp.Add(temp_s);
                }
                return temp;
            }
            
        }

        public int nXOffset = 0;
        public int nYOffset = 0;

        public int nXScrollOffset = 0;
        public int nYScrollOffset = 0;

        /// <summary>
        /// 找出所有笔画的的外接矩形，为了下一步从图像中把字截取出来使用
        /// </summary>
        /// <returns>笔画的外接矩形</returns>
        public Rectangle getBoundingRectangle()
        {
            Rectangle rec;
            int nLeft = 65535;
            int nTop = 65535; 
            int nBottom = 0;
            int nRight = 0;
            foreach (strokes oneStroke in listStrokes)
            {
                foreach(Point onePoint in oneStroke.listPoints)
                {
                    if ((onePoint.X - nXScrollOffset) < nLeft)
                    {
                        nLeft = (onePoint.X - nXScrollOffset);
                    }
                    if ((onePoint.X - nXScrollOffset) > nRight)
                    {
                        nRight = (onePoint.X - nXScrollOffset);
                    }
                    if ((onePoint.Y - nYScrollOffset) < nTop)
                    {
                        nTop = (onePoint.Y - nYScrollOffset);
                    }
                    if ((onePoint.Y - nYScrollOffset) > nBottom)
                    {
                        nBottom = (onePoint.Y - nYScrollOffset);
                    }
                }
            }
            rec = new Rectangle(nLeft, nTop, nRight - nLeft, nBottom - nTop);
            nXOffset = nLeft;
            nYOffset = nTop;
            return rec;
        }
        /// <summary>
        /// 存储一个字的信息，存出的文件一个jpg格式的字的图像，一个txt文件，包含笔画的点的信息
        /// </summary>
        /// <param name="strSrcImageFile"></param>
        public void save(string strSrcImageFile)
        {
            string strSrcFolder = Path.GetDirectoryName(strSrcImageFile);
            string strImageFileName = Path.GetFileNameWithoutExtension(strSrcImageFile);
            string strPareFolder = Directory.GetParent(strSrcImageFile).Parent.FullName.ToString();
            //string strDstFolder = strPareFolder + "\\result\\" + strImageFileName + "\\";
            string strDstFolder = strPareFolder + "\\result\\";
            string strDstFolderWithLine = strDstFolder + "lines\\";

            ArrayList imagesForOneHanzi = new ArrayList();
            int nIndex = 0;
            if (!Directory.Exists(strDstFolder))
            {
                Directory.CreateDirectory(strDstFolder);
            }
            if (!Directory.Exists(strDstFolderWithLine))
            {
                Directory.CreateDirectory(strDstFolderWithLine);
            }
            imagesForOneHanzi = DirectoryReader.GetFiles(strDstFolder, "*.jpg", false);
            nIndex = imagesForOneHanzi.Count + 1;


            string strOutPutTXTFile = strDstFolder + strImageFileName + ".txt";
            string strOutPutImageFile = strDstFolder + strImageFileName + ".jpg";
            string strOutputImageLinesFile = strDstFolderWithLine + strImageFileName + ".jpg";

            wordimageWithLines.Save(strOutputImageLinesFile);
            wordimage.Save(strOutPutImageFile);
            saveStrokes(strOutPutTXTFile);
        }

        /// <summary>
        /// 将一个汉字的所有笔画都写入到一个文件中
        /// </summary>
        /// <param name="strTXTFile"></param>
        private void saveStrokes(string strTXTFile)
        {
            StreamWriter sw = new StreamWriter(strTXTFile);
            //foreach (strokes s in this.listStrokes)
            //{
            //    foreach (Point p in s.listPoints)
            //    {
            //        sw.Write(p.ToString());
            //    }
            //    sw.Write(";");
            //    sw.Write(s.strProperty + "\n");
            //}
            sw.Write(this.strWordContent + "\n");
            //foreach (strokes s in this.listStrokesCropedImage) 
            //this.listStrokesCropedImage中存储的是剪切后的坐标
            foreach (strokes s in this.listStrokes) 
            {
                foreach (Point p in s.listPoints)
                {
                    sw.Write(p.ToString());
                }
                sw.Write(";");
                sw.Write(s.strProperty + "\n");
            }
            sw.Close();
        }

        
        public void clear()
        {
            this.wordimage = null;
            this.listStrokes.Clear();
            this.nXOffset = 0;
            this.nYOffset = 0;
        }
    }
}
