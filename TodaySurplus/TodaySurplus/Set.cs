#region 引用命名空间

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using 今日剩余;
using System.Runtime.InteropServices;
using System.Media;
using System.Text.RegularExpressions;

#endregion 引用命名空间

namespace 今日剩余
{
    public partial class Set : Form
    {
        #region 变量声明区

        private string hex1 = "#1CFF1C";
        private string hex2 = "#9AFF02";
        private string hex3 = "#FF5000";
        private string hex4 = "#EA0000";

        public static bool property = false;//在设置中改变属性

        public static bool createWindow = false;//创建一个变量，记录只打开一个窗口，防止同时打开多个设置窗口

        private string pathFile = Application.StartupPath + @"\TodaySurplus.ini";

        #endregion 变量声明区

        private 今日剩余 sy = new 今日剩余();

        public Set()
        {
            InitializeComponent();
        }

        #region 时间条颜色

        private void Color1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = Color.FromArgb(28, 255, 28);
                Color1.BackColor = colorDialog1.Color;
                color = colorDialog1.Color;
                hex1 = ColorTranslator.ToHtml(color);
            }
        }

        private void Color2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = Color.FromArgb(154, 255, 2);
                Color2.BackColor = colorDialog1.Color;
                color = colorDialog1.Color;
                hex2 = ColorTranslator.ToHtml(color);
            }
        }

        private void Color3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = Color.FromArgb(255, 80, 0);
                Color3.BackColor = colorDialog1.Color;
                color = colorDialog1.Color;
                hex3 = ColorTranslator.ToHtml(color);
            }
        }

        private void Color4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = Color.FromArgb(234, 0, 0);
                Color4.BackColor = colorDialog1.Color;
                color = colorDialog1.Color;
                hex4 = ColorTranslator.ToHtml(color);
            }
        }

        #endregion 时间条颜色

        #region 窗体重绘

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color FColor = Color.DimGray;
            Color TColor = Color.White;
            Brush b = new LinearGradientBrush(pictureBox1.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);
            g.FillRectangle(b, pictureBox1.ClientRectangle);
            //g.Dispose();
            //b.Dispose();
        }

        #endregion 窗体重绘

        #region 窗体加载事件

        private void Set_Load(object sender, EventArgs e)
        {
            sy.ReadFile();
            Color1.BackColor = ColorTranslator.FromHtml(sy.hex1);
            Color2.BackColor = ColorTranslator.FromHtml(sy.hex2);
            Color3.BackColor = ColorTranslator.FromHtml(sy.hex3);
            Color4.BackColor = ColorTranslator.FromHtml(sy.hex4);

            timeBarThicknessNL.Value = sy.timeBar;
            setHour.Text = Convert.ToString(sy.setHour);
            setMin.Text = Convert.ToString(sy.setMin);
        }

        #endregion 窗体加载事件

        #region 将数据写入文件

        private void btnApplicationChange_Click(object sender, EventArgs e)
        {
            createWindow = false;//防止多开，用creatWindow这个变量来记录是否已经打开了一个窗口，true表示已打开，false表示没有打开
            try
            {
                WriteFile();
                property = true;

                //写入成功才有声音，否则不会有声音
                SoundPlayer sp = new SoundPlayer();
                sp.Stream = Properties.Resources.water2;
                sp.Play();
                sp.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序文件类操作出错\n错误原因：" + ex.ToString());
            }
            this.Close();
        }

        //写入配置文件
        public void WriteFile()
        {
            StreamWriter sw = new StreamWriter(pathFile, false);
            if (!File.Exists(pathFile))
            {
                File.Create(pathFile);
            }

            #region 设置属性

            sw.WriteLine("今日剩余配置文件(请勿删除，否则原有数据将丢失)\n");
            sw.WriteLine("______________________________________________\r\n");
            sw.WriteLine(" ================颜色配置区域================");
            sw.WriteLine("‖     [Hex_1]" + hex1 + "[1_Hex]" + "\r\n" +
                         "‖     [Hex_2]" + hex2 + "[2_Hex]" + "\r\n" +
                         "‖     [Hex_3]" + hex3 + "[3_Hex]" + "\r\n" +
                         "‖     [Hex_4]" + hex4 + "[4_Hex]");
            sw.WriteLine(" ================颜色配置区域================\r\n");

            sw.WriteLine(" ================其他配置====================");
            sw.WriteLine("‖     timeBarThicknessNL_" + timeBarThicknessNL.Value + "_timeBarThicknessNL");
            sw.WriteLine("‖     setHour_" + setHour.Text + "_setHour");
            sw.WriteLine("‖     setMin_" + setMin.Text + "_setMin");
            sw.WriteLine(" ================其他配置====================\r\n");
            sw.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\nAuthor:MrWEI\r\nQQ:1627364392\r\n");

            #endregion 设置属性

            sw.Close();
        }

        #endregion 将数据写入文件

        #region 控制无边框窗体的移动

        //using System.Runtime.InteropServices;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //常量
            int WM_SYSCOMMAND = 0x0112;

            //窗体移动
            int SC_MOVE = 0xF010;
            int HTCAPTION = 0x0002;

            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion 控制无边框窗体的移动

        #region 取消事件

        private void btnCancel_Click(object sender, EventArgs e)
        {
            createWindow = false;//防止多开，用creatWindow这个变量来记录是否已经打开了一个窗口，true表示已打开，false表示没有打开
            this.Close();
        }

        #endregion 取消事件

        #region 帮助事件

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆本软件是一个时间提示助手◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆\n\n☞根据您今日剩余的时间,显示条会有不同的颜色和长度.\n☞在屏幕上左右拖动并释放时间条，可以让其停靠在屏幕左边或者右边.\n☞具有定时关机功能，在晚上23:45会提醒您即将关机，请你保存好您所做的工作.\n☞在23:50将会强制关机，且不会有任何提示!\n☞在23:50至03:00这段时间内将无法开机(此功能是为了保证您的睡眠).\n☞右键双击时间条即可取消开机自启，重新开启只需手动重启软件即可.\n☞右键单击时间条可再次显示帮助信息.\n\n☞Made By MrWEI...✍\n☞QQ:1627364392...✍\n\n------------------------------------→谢谢使用←------------------------------------", "「今日剩余」使用说明-------→Made By MWEI");
        }

        #endregion 帮助事件

        #region 时间设置

        private string patternH = @"^[1-3]*$";
        private string patternM = @"^[0-9]*$";

        private void setHour_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Match m = Regex.Match(setHour.Text, patternH);
                if (!m.Success)
                {
                    setHour.Text = Convert.ToString(sy.setHour);//TextBox的内容不变
                    setHour.SelectionStart = setHour.Text.Length;//光标定位到最后
                }
                else
                {
                    if (setHour.Text != null)
                        sy.setHour = Convert.ToInt32(0 + setHour.Text);
                }
            }
            catch
            {
                MessageBox.Show("支持输入21，22，23");
            }
        }

        private void setMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Match m = Regex.Match(this.setMin.Text, patternM);
                if (!m.Success)
                {
                    this.setMin.Text = Convert.ToString(sy.setMin);//TextBox的内容不变
                    this.setMin.SelectionStart = this.setMin.Text.Length;//光标定位到最后
                }
                else
                {
                    if (setMin.Text != null)
                        sy.setMin = Convert.ToInt32(0 + setMin.Text);
                }
            }
            catch
            {
                MessageBox.Show("分钟只能输入数字哦");
            }
        }

        #endregion 时间设置
    }
}

/*
 颜色知识：
    把十六进制颜色转化为color对象
    ColorTranslator.FromHtml("#FF0000")
    或 ColorTranslator.FromHtml("Red");

    把color对象转化为十六进制颜色
    ColorTranslator.ToHtml(Color.FromArgb(255,255,255))
    或 ColorTranslator.ToHtml(Color.Red);

 */