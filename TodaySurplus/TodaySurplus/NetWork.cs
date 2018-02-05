#region 引用命名空间
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text; 
#endregion

namespace 今日剩余
{
    class NetWork
    {
        #region 下载文件功能函数
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">下载链接</param>
        /// <param name="path">保存路径</param>
        /// <param name="appName">应用名称</param>
        /// <returns></returns>
        public bool HttpDownload(string url, string path, string appName)
        {
            string tempFile = path + @"\NewApplications";
            string pathApp = tempFile + "\\" + appName + ".exe";
            Directory.CreateDirectory(tempFile);

            if (File.Exists(pathApp))
            {
                File.Delete(pathApp);
            }
            try
            {
                //设置参数
                FileStream fs = new FileStream(pathApp, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //发送请求并获取相应回应数据
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //直到request.GetResponse()程序才开始像目标网页发送Post请求
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //创建本地文件写入流
                Stream responseStream = response.GetResponseStream();

                byte[] bArray = new byte[1024];
                int size = responseStream.Read(bArray, 0, (int)bArray.Length);
                while (size > 0)
                {
                    fs.Write(bArray, 0, size);
                    size = responseStream.Read(bArray, 0, (int)bArray.Length);
                }
                fs.Close();
                responseStream.Close();
                //File.Move(tempFile, path);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("下载失败：" + ex.Message, "今日剩余");
                return false;
            }
        }
        #endregion

        #region 获取网页源码
        private string GetWebSourceCode(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, System.Text.Encoding.UTF8);
            string SourceCode = sr.ReadToEnd();
            //saveSourceCode(SourceCode);
            resStream.Close();
            sr.Close();
            return SourceCode;
        }
        #endregion

        #region 记录网络终端的配置到本地
        /// <summary>
        /// 将网络终端的信息记录在本地文件中
        /// </summary>
        /// <param name="url"></param>
        public void RecordWebConfig(string url, string path)
        {
            string[] mainContent = null;
            string[] newVersion = null;
            string[] downloadUrl = null;
            string[] newFeature = null;
            string allSource = null;

            FileInfo file = new FileInfo(path);
            StreamWriter sw = file.CreateText();

            try
            {
                allSource = GetWebSourceCode(url);

                mainContent = allSource.Split(new string[] { "[mainContent_]", "[_mainContent]" }, StringSplitOptions.RemoveEmptyEntries);
                newVersion = mainContent[1].Split(new string[] { "[newVersion_]", "[_newVersion]" }, StringSplitOptions.RemoveEmptyEntries);
                downloadUrl = mainContent[1].Split(new string[] { "[downloadUrl_]", "[_downloadUrl]" }, StringSplitOptions.RemoveEmptyEntries);
                newFeature = mainContent[1].Split(new string[] { "[newFeature_]", "[_newFeature]" }, StringSplitOptions.RemoveEmptyEntries);

                sw.WriteLine("---------------WebConfigure---------------\r\n\r\n");

                sw.Write("[newVersion_]");
                sw.Write(newVersion[1]);
                sw.WriteLine("[_newVersion]\r\n");

                sw.Write("[downloadUrl_]");
                sw.Write(downloadUrl[1]);
                sw.WriteLine("[_downloadUrl]\r\n");

                sw.Write("[newFeature_]");
                sw.Write(newFeature[1]);
                sw.WriteLine("[_newFeature]\r\n");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                sw.Close();
            }


        } 
        #endregion
    }
}
