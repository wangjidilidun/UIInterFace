 #region highlight
        static Rectangle oldRec = new Rectangle();
        bool bNewField = false;
        public void HighLightImageWithRec(string strXMLResultPath, string strFieldName, Color color)
        {
            LoadOCRResult result = LoadOCRResult.GetInstance(strXMLResultPath);
            Rectangle rec1 = result.FindResultRectangleByTemplateName(strFieldName);
            //if (rec1.Width == 0 && rec1.Height == 0)
            //{
            //    rec1.Location = new Point(0, 0);
            //    rec1.Width = workspaceViewer1.Image.Width;
            //    rec1.Height = workspaceViewer1.Image.Height;
            //}
            //if the new rectangle is different from the last one, de-highlight the last one
            //if (!rec1.IntersectsWith(oldRec) && !oldRec.IsEmpty)
            if (bNewField)
            {
                workspaceViewer1.Undos.Undo();
                bNewField = false;

            }
            bNewField = true;
            //////////////////////////////////////////////////////////////////////////
            //DisplayRectangle is the Image Show Area BEFORE zoom
            //rec2 means show area of the Image after zoom
            Rectangle rec2 = ConvertRectangle(workspaceViewer1.DisplayRectangle, workspaceViewer1.Zoom);
            //////////////////////////////////////////////////////////////////////////
            //if (!rec1.IntersectsWith(rec2) && rec1.Width !=0 && rec1.Height != Height)
            if (rec1.Width != 0 && rec1.Height != Height && JudgeTwoRecCross(rec1, rec2))
            {
                AdjustImage(workspaceViewer1, rec1, 100, workspaceViewer1.Zoom);
            }
            //if (workspaceViewer1.Undos != null)
            {
                try
                {
                    workspaceViewer1.Undos.Add("highlight", true);
                }
                catch (System.Exception ex)
                {
                    workspaceViewer1.Dispose();
                    return;
                }
                
            }
            
            DrawRectangleOnImage(workspaceViewer1, rec1, color);
            workspaceViewer1.Refresh();
        }

        private bool JudgeTwoRecCross(Rectangle rec1, Rectangle rec2)
        {
            if ((rec1.Left - rec2.Left) > 10 && (rec1.Top - rec2.Top) > 10 && (rec2.Bottom - rec1.Bottom) > 10 && (rec2.Right - rec1.Right) > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Rectangle ConvertRectangle(Rectangle rec, double zoom)
        {
            Rectangle recNew = new Rectangle((int)((rec.Left - workspaceViewer1.ScrollPosition.X) / zoom), (int)((rec.Top - workspaceViewer1.ScrollPosition.Y) / zoom), (int)(rec.Width / zoom), (int)(rec.Height / zoom));
            return recNew;
        }

        /// <summary>
        /// Auto image skip, make the rec at the top of the image
        /// </summary>
        /// <param name="workspaceViewer1"></param>
        /// <param name="rec"></param>
        /// <param name="nExpend"></param>
        /// <param name="zoom"></param>
        private void AdjustImage(Atalasoft.Imaging.WinControls.WorkspaceViewer workspaceViewer1, Rectangle rec, int nExpend, double zoom)
        {
            int nSx = rec.Left;
            int nSy = rec.Top;
            int nWidth = rec.Width;
            int nHeight = rec.Height;
            workspaceViewer1.ScrollPosition = new System.Drawing.Point((int)(-(nSx * zoom - nExpend)), (int)(-(nSy * zoom - nExpend)));
        }

        private void DrawRectangleOnImage(Atalasoft.Imaging.WinControls.WorkspaceViewer workspaceViewer1, Rectangle rec, Color color)
        {
            if (workspaceViewer1 != null && workspaceViewer1.Image != null)
            {
                Canvas canvas = new Canvas(workspaceViewer1.Image);
                canvas.SmoothingLevel = 0;
                Fill fill = new SolidFill(color);
                canvas.DrawRectangle(rec, new AtalaPen(color, 1), fill);
            }
            
        }
        #endregion