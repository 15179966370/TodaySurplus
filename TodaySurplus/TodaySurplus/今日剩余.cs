#region 引用命名空间

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

#endregion 引用命名空间

namespace 今日剩余
{
    public partial class 今日剩余 : Form
    {
        public 今日剩余()
        {
            InitializeComponent();
        }

        #region 变量声明

        //private int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        //private int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;

        private int WorkAreaWidth = Screen.PrimaryScreen.WorkingArea.Width;
        private int WorkAreaHeight = Screen.PrimaryScreen.WorkingArea.Height;

        private int PassMin = 0;//已经过去的时间
        private int RemainingTime = 0;//剩余时间
        private double k = 0;//比例系数

        private bool prompt = true;

        public string hex1 = "#1CFF1C";
        public string hex2 = "#9AFF02";
        public string hex3 = "#FF5000";
        public string hex4 = "#EA0000";
        public int timeBar = 2;
        public int setHour = 23;
        public int setMin  = 50;

        //应用配置文件路径
        private string pathFile   = Application.StartupPath + @"\TodaySurplus.ini";
        //待停止进程文件路径
        private string pathFilePs = Application.StartupPath + @"\KillProcess.txt";
        //新版本保存路径
        private string pathNewAPP = Application.StartupPath;
        //网络终端读取到的配置文件保存的路径
        private string pathWebConfig = Application.StartupPath + @"\WebConfig.ini";

        //网络终端 ---简书
        private static string contentUrl = @"https://www.jianshu.com/p/2b62eb43308a";

        //新版本下载地址
        private static string newVersionUrl = null;


        string[] PsArray = {null }; //将ReadFilePs()中读取到的需要停止的进程保存在这个数组里面

        int min30count = 0;

        #endregion 变量声明

        //实例化时间类
        private System.DateTime CurrentTime = new System.DateTime();

        //实例化一个网络下载类
        NetWork netWork = new NetWork();

        #region 窗体吸附

        /// <summary>
        /// 窗体吸附
        /// </summary>
        private void FormAdsorption()
        {
            //获取屏幕大小：Screen.PrimaryScreen.Bounds.Height
            if (this.Location.X < WorkAreaWidth / 2 && this.Location.X > -50)
            {
                this.Location = new Point(0, 0);
            }
            else if (this.Location.X > WorkAreaWidth / 2)
            {
                this.Location = new Point(WorkAreaWidth - this.Width, 0);
            }
        }

        #endregion 窗体吸附

        #region 窗体加载事件

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 读取配置文件是否存在
            try
            {
                if (!File.Exists(pathFile))
                {
                    //File.Create(pathFile);
                    FileInfo file = new FileInfo(pathFile);//没有则创建，有则覆盖
                    StreamWriter sw = file.CreateText();

                    #region 初始化应用文件配置

                    sw.WriteLine("\"今日剩余\"配置文件(请勿删除，否则原有数据将丢失)\n");
                    sw.WriteLine("______________________________________________\r\n");
                    sw.WriteLine(" ================颜色配置区域================");
                    sw.WriteLine("‖     [Hex_1]" + "#1CFF1C" + "[1_Hex]" + "\r\n" +
                                 "‖     [Hex_2]" + "#9AFF02" + "[2_Hex]" + "\r\n" +
                                 "‖     [Hex_3]" + "#FF5000" + "[3_Hex]" + "\r\n" +
                                 "‖     [Hex_4]" + "#EA0000" + "[4_Hex]");
                    sw.WriteLine(" ================颜色配置区域================\r\n");

                    sw.WriteLine(" ================其他配置====================");
                    sw.WriteLine("‖     timeBarThicknessNL_" + 2 + "_timeBarThicknessNL");
                    sw.WriteLine("‖     setHour_" + 23 + "_setHour");
                    sw.WriteLine("‖     setMin_" + 50 + "_setMin");
                    sw.WriteLine(" ================其他配置====================\r\n");
                    sw.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\nAuthor:MrWEI\r\nQQ:1627364392\r\n");

                    #endregion 初始化应用文件配置

                    sw.Close();
                    MessageBox.Show("◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆本软件是一个时间提示助手◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆\n\n☞根据您今日剩余的时间,显示条会有不同的颜色和长度.\n☞在屏幕上左右拖动并释放时间条，可以让其停靠在屏幕左边或者右边.\n☞具有定时关机功能，在晚上23:45会提醒您即将关机，请你保存好您所做的工作.\n☞在23:50将会强制关机，且不会有任何提示!\n☞在23:50至03:00这段时间内将无法开机(此功能是为了保证您的睡眠).\n☞右键双击时间条即可取消开机自启，重新开启只需手动重启软件即可.\n☞右键单击时间条可再次显示帮助信息.\n\n☞Made By MrWEI...✍\n☞QQ:1627364392...✍\n\n------------------------------------→谢谢使用←------------------------------------", "欢迎使用「今日剩余」-------→Made By MWEI");
                }
                else
                {
                    ReadFile();//读取应用配置文件
                }

                if (!File.Exists(pathFilePs))
                {
                    FileInfo filePs = new FileInfo(pathFilePs);
                    StreamWriter swPs = filePs.CreateText();

                    #region 初始化Ps配置文件

                    swPs.WriteLine("请在此文件内添加你需要结束掉的弹窗广告或者应用程序\r\n");
                    swPs.WriteLine("(-------------请注意按下列格式进行添加-------------)\r\n");
                    swPs.WriteLine("请勿随意改动本文件的其他部分，否则将无法清除预期应用程序\r\n\r\n");
                    swPs.WriteLine("本次修改将在下次程序启动时生效\r\n\r\n");
                    swPs.WriteLine("Example:\r\n");
                    swPs.WriteLine("[psStart]ApplicationName1|ApplicationName2|ApplicationName3[psEnd]");
                    swPs.WriteLine("(不用加.exe后缀名)\r\n\r\n\r\n");

                    swPs.WriteLine("[Add From Here]\r\n\r\n");
                    swPs.WriteLine("[psStart][psEnd]\r\n");
                    swPs.WriteLine("\r\n[Add End of Here]\r\n");
                    swPs.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\nAuthor:MrWEI\r\nQQ:1627364392\r\n");

                    #endregion

                    swPs.Close();
                }
                else
                {
                    ReadFilePs(pathFilePs);//读取所有要停止的进程
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form_Load出错！\n出错原因：\n" + ex.Message);
            } 
            #endregion

            #region 时间条位置及形状设置

            this.Location = new Point(WorkAreaWidth - timeBar, 0);
            this.Width = timeBar;
            this.Height = WorkAreaHeight;
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;

            #endregion 时间条位置及形状设置

            BootFromStart(true);//开机自启
            timer1.Enabled = true;
        }

        #endregion 窗体加载事件

        #region 自动关机部分

        private delegate uint ZwShutdownSystem(int ShutdownAction);//编译

        private delegate uint RtlAdjustPrivilege(int Privilege, bool Enable, bool CurrentThread, ref int Enabled);

        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(String path);

        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, String funcName);

        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);

        //将要执行的函数转换为委托
        private static Delegate Invoke(String APIName, Type t, IntPtr hLib)
        {
            IntPtr api = GetProcAddress(hLib, APIName);
            return (Delegate)Marshal.GetDelegateForFunctionPointer(api, t);
        }

        #endregion 自动关机部分

        #region 开机自动运行

        public static void BootFromStart(bool selfStart)
        {
            try
            {
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                if (selfStart)
                    rk2.SetValue("今日剩余", path);
                else
                    rk2.DeleteValue("今日剩余", false);

                rk2.Close();
                rk.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("开机自启设置失败，请以管理员身份运行此程序！\n出错原因:" + ex.Message);
            }
        }

        #endregion 开机自动运行

        #region 在alt+tab组合键情况下不出现在桌面列表中

        //来源：http://www.cnblogs.com/pcy0/archive/2010/07/11/1775108.html
        //重载了CreateParams这个方法
        public static int WS_EX_TOOLWINDOW = 0x00000080;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= (int)WS_EX_TOOLWINDOW;
                return createParams;
            }
        }

        #endregion 在alt+tab组合键情况下不出现在桌面列表中

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

            FormAdsorption();//窗体吸附
        }

        #endregion 控制无边框窗体的移动

        #region 500ms定时程序

        //每500ms处理一次

        public void timer1_Tick(object sender, EventArgs e)
        {
            if (Set.property == true)//2s钟读一次，减少内存开销
            {
                Set.property = false;
                ReadFile();
            }

            #region 时间条位置及形状设置

            this.Location = new Point(WorkAreaWidth - timeBar, 0);
            this.Width = timeBar;
            this.Height = WorkAreaHeight;
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;

            #endregion 时间条位置及形状设置

            CurrentTime = DateTime.Now;//获取系统当前时间
            PassMin = CurrentTime.Hour * 60 + CurrentTime.Minute;//已经过去的时间
            RemainingTime = (24 * 60 - 1 - PassMin);//剩余时间
            k = (WorkAreaHeight / (24 * 60.0));//比例系数

            pictureBox1.Height = (int)(k * RemainingTime);
            pictureBox1.Location = new Point(pictureBox1.Location.X, WorkAreaHeight - pictureBox1.Height);

            //秒测试部分
            //pictureBox1.Height = (59 - CurrentTime.Second) * (WorkAreaHeight / 60);
            //pictureBox1.Location = new Point(pictureBox1.Location.X, WorkAreaHeight - pictureBox1.Height);

            #region 时间条颜色改变

            if (RemainingTime >= 12 * 60)
                pictureBox1.BackColor = ColorTranslator.FromHtml(hex1);
            else if (RemainingTime >= 6 * 60 && RemainingTime < 12 * 60)
                pictureBox1.BackColor = ColorTranslator.FromHtml(hex2);
            else if (RemainingTime >= 2 * 60 && RemainingTime < 6 * 60)
                pictureBox1.BackColor = ColorTranslator.FromHtml(hex3);
            else if (RemainingTime < 2 * 60)
                pictureBox1.BackColor = ColorTranslator.FromHtml(hex4);

            #endregion 时间条颜色改变

            #region 提示和强制关机部分

            if (CurrentTime.Hour == setHour && CurrentTime.Minute == setMin - 5 && prompt == true)
            {
                prompt = false;
                MessageBox.Show("☞还有5min将强制关机☜\n☞请保存当前所做的工作☜\n☞否则数据可能会丢失哦！☜", "☞☾温馨提示☽☜");
            }
            else if (CurrentTime.Hour == setHour && CurrentTime.Minute >= setMin || CurrentTime.Hour <= 3)//---------------------------------
            {
                IntPtr hLib = LoadLibrary("ntdll.dll");
                RtlAdjustPrivilege rtla = (RtlAdjustPrivilege)Invoke("RtlAdjustPrivilege", typeof(RtlAdjustPrivilege), hLib);
                ZwShutdownSystem shutdown = (ZwShutdownSystem)Invoke("ZwShutdownSystem", typeof(ZwShutdownSystem), hLib);

                int en = 0;
                uint ret = rtla(0x13, true, false, ref en);//SE_SHUTDOWN_PRIVILEGE = 0x13;     //关机权限
                ret = shutdown(2); // POWEROFF = 0x2 // 关机 // REBOOT = 0x1 // 重启
            }

            #endregion 提示和强制关机部分

            KillProcess(PsArray);//进程清理，主要是为了处理掉某些流氓哥哥的弹窗

            ClearMemory();//内存优化 10M占用优化到了500k
        }

        #endregion 500ms定时程序

        #region 1min定时程序
        private void timer2_Tick(object sender, EventArgs e)
        {
            bool timeOut = false;

            if (min30count >= 30 && !timeOut)
            {
                min30count = 0;
                timeOut = true;

                //将网络终端的配置记录到本地
                netWork.RecordWebConfig(contentUrl, pathWebConfig);
            }
            else
                min30count += 1;

            //下载新版 今日剩余
            if (timeOut)
            {
                netWork.HttpDownload(newVersionUrl, pathNewAPP, "今日剩余V2.0");
            }
                
        } 
        #endregion

        #region 属性设置弹窗

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //防止多开，用creatWindow这个变量来记录是否已经打开了一个窗口，true表示已打开，false表示没有打开
            if (Set.createWindow == false)
            {
                Set.createWindow = true;
                Set FormSet = new Set();
                FormSet.Show();
            }
        }

        #endregion 属性设置弹窗

        #region 读取应用配置文件

        public void ReadFile()
        {
            FileStream fs = new FileStream(pathFile, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            try
            {
                string[] sArrayHex_1 = line.Split(new string[] { "[Hex_1]", "[1_Hex]" }, StringSplitOptions.RemoveEmptyEntries);
                string[] sArrayHex_2 = line.Split(new string[] { "[Hex_2]", "[2_Hex]" }, StringSplitOptions.RemoveEmptyEntries);
                string[] sArrayHex_3 = line.Split(new string[] { "[Hex_3]", "[3_Hex]" }, StringSplitOptions.RemoveEmptyEntries);
                string[] sArrayHex_4 = line.Split(new string[] { "[Hex_4]", "[4_Hex]" }, StringSplitOptions.RemoveEmptyEntries);

                string[] sArrayTimeBar = line.Split(new string[] { "timeBarThicknessNL_", "_timeBarThicknessNL" }, StringSplitOptions.RemoveEmptyEntries);
                string[] sArraySetHour = line.Split(new string[] { "setHour_", "_setHour" }, StringSplitOptions.RemoveEmptyEntries);
                string[] sArraySetMin = line.Split(new string[] { "setMin_", "_setMin" }, StringSplitOptions.RemoveEmptyEntries);

                hex1 = sArrayHex_1[1];
                hex2 = sArrayHex_2[1];
                hex3 = sArrayHex_3[1];
                hex4 = sArrayHex_4[1];
                timeBar = Convert.ToInt32(sArrayTimeBar[1]);
                setHour = Convert.ToInt32(sArraySetHour[1]);
                setMin = Convert.ToInt32(sArraySetMin[1]);
                //MessageBox.Show(hex1 + hex2 + hex3 + hex4 + timeBar + setHour + setMin + selfStart);
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置文件读取失败，错误原因:" + ex.ToString(), "文件错误");
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }

        #endregion 读取应用配置文件

        #region 读取要停止的进程
        /// <summary>
        /// 读取要停止的进程
        /// </summary>
        /// <param name="path"></param>
        public void ReadFilePs(string path)
        {
            FileStream fsPs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader srPs = new StreamReader(fsPs);
            try
            {
                string line = srPs.ReadToEnd();

                //校验文件是否丢失数据
                CheckFileLoss(path, "KillProcess.txt", new string[] { "[Add From Here]", "[Add End of Here]", "[psStart]", "[psEnd]" });
                //获取相应内容
                string[] allProcess = line.Split(new string[] { "[Add From Here]", "[Add End of Here]" }, StringSplitOptions.RemoveEmptyEntries);
                string[] process = allProcess[1].Split(new string[] { "[psStart]", "[psEnd]" }, StringSplitOptions.RemoveEmptyEntries);
                if(allProcess[1].Contains(".exe"))
                    MessageBox.Show("检查到你在KillProcess.txt文件中添加了想要结束的进程，但进程名不能包含.exe，请找到文件后去除.exe后缀名，否则此部分功能将无法生效","KillProcess.txt Error");
                else
                    PsArray = process[1].Split('|');
            }
            catch (Exception ex)
            {
                MessageBox.Show("KillProcess文件读取失败，错误原因:" + ex.ToString(), "文件错误");
            }
            finally
            {
                srPs.Close();
                fsPs.Close();
            }
        }
        #endregion

        #region 校验配置文件是否丢失数据
        /// <summary>
        /// 校验配置文件是否丢失数据
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="filename">文件名称</param>
        /// <param name="contentArray">需要校验的字符串数组</param>
        private void CheckFileLoss(string path, string filename, string[] contentArray)
        {
            FileStream fsCF = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader srCF = new StreamReader(fsCF);
            try
            {
                string line = srCF.ReadToEnd();
                foreach (string item in contentArray)
                {
                    if (!(line.Contains(item)))
                    {
                        MessageBox.Show(filename + "文件已被破坏," + item + " 标识丢失，请重新添加或将其删除后重新启动 “今日剩余.exe”，" + filename + "将会重新生成", filename + "Error");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("错误详情："+"\r\n" + ex.Message,"校验文件时出错");
            }
            finally
            {
                fsCF.Close();
                srCF.Close();
            }
        } 
        #endregion

        #region 进程截杀，去掉讨厌的弹窗

        public void KillProcess(string[] array)
        {
            Process[] p = Process.GetProcesses();
            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (p[i].ProcessName == array[j])
                    {
                        p[i].Kill();
                    }
                }
            }
        }

        #endregion 进程截杀，去掉讨厌的弹窗

        #region 内存回收

        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                今日剩余.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        #endregion 内存回收


    }
}