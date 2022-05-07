using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ko2capture
{
    class CaptureForm : Form
    {
        public Int32 MethodId { set; get; }

        public CaptureForm()
        {
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            DoubleBuffered = true;

            PreviewKeyDown += CaptureForm_PreviewKeyDown;
            Paint += CaptureForm_Paint;
            MouseMove += CaptureForm_MouseMove;
            MouseClick += CaptureForm_MouseClick;
            MouseWheel += CaptureForm_MouseWheel;

            DateTime now = DateTime.Now;
            m_base = now.Year.ToString() + now.Month.ToString("D2") + now.Day.ToString("D2") + "_" 
                + now.Hour.ToString("D2") + now.Minute.ToString("D2") + now.Second.ToString("D2");

            MethodId = 1;
        }

        public Form1 AppForm { set; get; } = null;

        private int m_hintCaptureWidth = 50;
        private int m_hintCaptureHeight = 50;
        private void CaptureForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0) {
                    m_hintCaptureWidth += 20;
                    if (m_hintCaptureWidth > 1024)
                    {
                        m_hintCaptureWidth = 1024;
                    }
                }
                else
                {
                    m_hintCaptureWidth -= 20;
                    if (m_hintCaptureWidth < 50)
                    {
                        m_hintCaptureWidth = 50;
                    }
                }
                Refresh();
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (e.Delta > 0)
                {
                    m_hintCaptureHeight += 20;
                    if (m_hintCaptureHeight > 1024)
                    {
                        m_hintCaptureHeight = 1024;
                    }
                }
                else
                {
                    m_hintCaptureHeight -= 20;
                    if (m_hintCaptureHeight < 50)
                    {
                        m_hintCaptureHeight = 50;
                    }
                }
                Refresh();
            }
        }

        private int m_x;
        private int m_y;

        private Rectangle m_crop;
        private string m_base;
        private int m_count;
        private Graphics m_captured_graphics;

        public string Folder { set; get; }

        private void CaptureForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_captured.Dispose();
                Hide();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                m_bounds = m_captured.GetPixel(e.X, e.Y);
                m_captured.Dispose();
                Hide();
                if (AppForm != null)
                {
                    AppForm.SetBoundaryColor(m_bounds);
                    AppForm.Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                m_count++;
                string filename = Folder + "\\" + m_base + "_" + m_count.ToString("D4") + ".png";

                if ((m_crop.Width == 0) || (m_crop.Height == 0))
                {
                    return;
                }

                Bitmap crop = m_captured.Clone(m_crop, m_captured.PixelFormat);
                crop.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                crop.Dispose();

                m_captured_graphics.FillRectangle(Brushes.Gray, m_crop);

            }
        }

        private void CaptureForm_MouseMove(object sender, MouseEventArgs e)
        {
            m_x = e.X;
            m_y = e.Y;
            Refresh();
        }

        private void CaptureForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //Application.Exit(
                m_captured.Dispose();
                Hide();
            }
        }

        private Bitmap m_captured;

        public void CaptureScreen()
        {
            m_captured = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            m_captured_graphics = Graphics.FromImage(m_captured);
            m_captured_graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), m_captured.Size);

            Refresh();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // ちらつき防止のため背景を描画しない
        }


        // 連続3点が同じ値(白)を持っているかどうか調べるアルゴリズム
        private Color m_bounds = Color.White;
        public Color Bounds
        {
            get { return m_bounds; }
        }

        private void Cropping1()
        {
            int x1 = m_x;
            int y1 = m_y;
            int x2 = m_x;
            int y2 = m_y;
            int limit = 600;
            int count = 0;
            Color p1;
            Color p2;
            Color p3;
            Func<Color, Color, bool> ColorMatcher = (c1, c2) =>
            {
                if ((c1.R == c2.R) && (c1.G == c2.G) && (c1.B == c2.B))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            // left
            count = 0;
            while (x1 > 2)
            {
                if (count >= limit)
                {
                    break;
                }
                count++;
                p1 = m_captured.GetPixel(x1, m_y);
                p2 = m_captured.GetPixel(x1 - 1, m_y);
                p3 = m_captured.GetPixel(x1 - 2, m_y);
                if (ColorMatcher(p1, p2) && ColorMatcher(p1, p3) && ColorMatcher(p1, m_bounds))
                {
                    break;
                }
                x1--;
            }

            // right
            count = 0;
            while (x2 < (m_captured.Width - 3))
            {
                if (count >= limit)
                {
                    break;
                }
                count++;
                p1 = m_captured.GetPixel(x2, m_y);
                p2 = m_captured.GetPixel(x2 + 1, m_y);
                p3 = m_captured.GetPixel(x2 + 2, m_y);
                if (ColorMatcher(p1, p2) && ColorMatcher(p1, p3) && ColorMatcher(p1, m_bounds))
                {
                    break;
                }
                x2++;
            }

            // top
            count = 0;
            while (y1 > 2)
            {
                if (count >= limit)
                {
                    break;
                }
                count++;
                p1 = m_captured.GetPixel(m_x, y1);
                p2 = m_captured.GetPixel(m_x, y1 - 1);
                p3 = m_captured.GetPixel(m_x, y1 - 2);
                if (ColorMatcher(p1, p2) && ColorMatcher(p1, p3) && ColorMatcher(p1, m_bounds))
                {
                    break;
                }
                y1--;
            }

            // bottom
            count = 0;
            while (y2 < (m_captured.Height - 3))
            {
                if (count >= limit)
                {
                    break;
                }
                count++;
                p1 = m_captured.GetPixel(m_x, y2);
                p2 = m_captured.GetPixel(m_x, y2 + 1);
                p3 = m_captured.GetPixel(m_x, y2 + 2);
                if (ColorMatcher(p1, p2) && ColorMatcher(p1, p3) && ColorMatcher(p1, m_bounds))
                {
                    break;
                }
                y2++;
            }
            m_crop = new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        private int FindFlattenRegion(List<List<double>> profiles)
        {
            double min_sigma = 0;
            int min_i = 0;
            double x;
            double sumx;
            double sumx2;
            double sigma;
            double mean;

            for (int i = 0; i < profiles.Count; i++)
            {
                List<double> profile = profiles[i];
                sumx = 0;
                sumx2 = 0;
                for (int j = 0; j < profile.Count; j++)
                {
                    x = profile[j];
                    sumx += x;
                    sumx2 += (x * x);

                }
                mean = sumx / (double)profile.Count;
                sigma = sumx2 / (double)profile.Count - (mean * mean);
                if (i == 0)
                {
                    min_sigma = sigma;
                }
                else if (sigma < min_sigma)
                {
                    min_sigma = sigma;
                    min_i = i;
                }

            }

            return min_i;
        }

        // ヒストグラムを作って領域を探索するアルゴリズム
        private void Cropping2()
        {
            int x1 = m_x;
            int y1 = m_y;
            int x2 = m_x;
            int y2 = m_y;
            int limit = 600;
            int count = 0;
            List<List<double>> profile = new List<List<double>>();
            Func<int, int, int, int, int, List<double>> PixelPicker = (bx, by, xinc, yinc, n) =>
            {
                List<double> points = new List<double>();
                int x = bx;
                int y = by;
                for(int i=0; i<n; i++)
                {
                    if ((x >= 0) && (y >= 0))
                    {
                        Color c = m_captured.GetPixel(x, y);
                        points.Add(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
                    }
                    x += xinc;
                    y += yinc;
                }
                return points;
            };
            int length = 80;
            int start = length / 2;
            int npoints = 40;
            int incr = length / npoints;


            // left
            profile.Clear();
            count = 0;
            while (x1 > 2)
            {
                if (count >= limit)
                {
                    break;
                }
                count++;
                profile.Add(PixelPicker(x1, m_y - start, 0, incr, npoints));
                x1--;
            }
            x1 = m_x - FindFlattenRegion(profile);

            // right
            profile.Clear();
            count = 0;
            while (x2 < (m_captured.Width - 3))
            {
                if (count >= limit)
                {
                    break;
                }
                count++;
                profile.Add(PixelPicker(x2, m_y - start, 0, incr, npoints));
                x2++;
            }
            x2 = m_x + FindFlattenRegion(profile);

            // top
            profile.Clear();
            count = 0;
            while (y1 > 2)
            {
                if (count >= limit)
                {
                    break;
                }
                count++;
                profile.Add(PixelPicker(m_x - start, y1, incr, 0, npoints));
                y1--;
            }
            y1 = m_y - FindFlattenRegion(profile);

            // bottom
            profile.Clear();
            count = 0;
            while (y2 < (m_captured.Height - 3))
            {
                if (count >= limit)
                {
                    break;
                }
                count++;
                profile.Add(PixelPicker(m_x - start, y2, incr, 0, npoints));
                y2++;
            }
            y2 = m_y + FindFlattenRegion(profile);

            m_crop = new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        // ヒストグラムを作って領域を探索するアルゴリズム
        private void Cropping3()
        {
            int cx = m_x - m_hintCaptureWidth / 2;
            int cy = m_y - m_hintCaptureHeight / 2;
            m_crop = new Rectangle(cx, cy, m_hintCaptureWidth, m_hintCaptureHeight);
        }

        private void CaptureForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(m_captured, 0, 0);

            switch(MethodId)
            {
                case 0:
                    m_crop = new Rectangle(m_x - 1, m_y - 1, 2, 2);
                    break;
                case 1: Cropping1(); break;
                case 2: Cropping2(); break;
                case 3: Cropping3(); break;
            }

            Pen pen = new Pen(Color.Blue);
            pen.Width = 3;

            e.Graphics.DrawRectangle(pen, m_crop);
        }

    }
}
