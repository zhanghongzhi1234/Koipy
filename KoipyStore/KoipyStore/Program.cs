using System;
using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using log4net;
using System.IO;
using System.Security.Cryptography;

namespace KoipyStore
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1;
        public static string urlroot = "http://www.koipy.com";
        public static string store_user = "";
        public static string branch_id = "";
        public static string token = "";
        public static string type = "";     //扫描方式：1=kcode 2 = mobile
        public static string lang = "en_us";       //or zh_cn
        public static ProfileInfo profileInfo = new ProfileInfo();
        public static Dictionary<string, string> dicLang = new Dictionary<string, string>();
        //use 3DES加密文件的key
        public static byte[] tdesKey = { (byte)20, (byte)246, (byte)107, (byte)204,(byte)227,
                                  (byte)185, (byte)174, (byte)110, (byte)130,(byte)168,
                                  (byte)5, (byte)156, (byte)75, (byte)157,(byte)190,
                                  (byte)59, (byte)123, (byte)163, (byte)118,(byte)150,
                                  (byte)173, (byte)77, (byte)151, (byte)239};

        public static byte[] tdesIV = { (byte)210, (byte)200, (byte)8, (byte)73,
                                    (byte)123, (byte)177, (byte)219, (byte)237};

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [STAThread]
        static void Main()
        {
            //得到正在运行的例程
            log.Info("*                      START OF FILE                      *");
            log.Info("***********************************************************");
            Process instance = RunningInstance();
            if (instance == null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ReadConfigFile();
                if (File.Exists("koipy"))
                {
                    ReadTokenFile("koipy");
                }
                if (token == "")
                {
                    Form login = new LoginFrm();
                    if (login.ShowDialog() == DialogResult.OK)//登录成功就设置登录窗体的DialogResult为OK
                    {
                        Application.Run(new ProfileLoginFrm());
                    }
                }
                else
                {
                    Application.Run(new ProfileLoginFrm());
                }

            }
            else
            {
                //处理发现的例程
                HandleRunningInstance(instance);
            }
        }

        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历正在有相同名字运行的例程   
            foreach (Process process in processes)
            {
                //忽略现有的例程     
                if (process.Id != current.Id)
                {
                    //确保例程从EXE文件运行       
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "//") == current.MainModule.FileName)
                    {
                        //返回另一个例程实例         
                        return process;
                    }
                }
            }
            //没有其它的例程，返回Null   
            return null;
        }
        public static void HandleRunningInstance(Process instance)
        {
            //确保窗口没有被最小化或最大化   
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            //设置真实例程为foreground window   
            SetForegroundWindow(instance.MainWindowHandle);
        }

        // Read start.ini config file and load all language
        private static bool ReadConfigFile()
        {
            string strConfigPath = "config.ini";
            if (File.Exists(strConfigPath))
            {
                StreamReader srReadFile = new StreamReader(strConfigPath);
                try
                {   //先读取语言配置
                    while (!srReadFile.EndOfStream)
                    {
                        string strReadLine = srReadFile.ReadLine();
                        string[] sArray = strReadLine.Split('=');
                        switch (sArray[0])
                        {
                            case "lang":      //语言选项
                                lang = sArray[1];
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (System.Exception e)
                {
                    log.Error(e.ToString());
                    return false;
                }
                srReadFile.Close();// 关闭读取流文件
            }
            else
            {   //如果不存在则创建一个文件
                StreamWriter sr;
                sr = File.CreateText(strConfigPath);
                sr.WriteLine("lang=en_us");
                sr.Flush();
                sr.Close();
                return false;
            }

            //下面读取具体的语言文件，目前只支持简体中文和英文
            string strLangFile = "zh_cn.ini";
            if (File.Exists(strLangFile))
            {
                StreamReader srReadFile = new StreamReader(strLangFile);

                try
                {
                    while (!srReadFile.EndOfStream)
                    {
                        string strReadLine = srReadFile.ReadLine();
                        string[] sArray = strReadLine.Split('=');
                        if (!dicLang.ContainsKey(sArray[0]))
                        {
                            if (sArray.Length == 1)
                            {
                                dicLang.Add(sArray[0], sArray[0]);
                            }
                            else
                            {
                                dicLang.Add(sArray[0], sArray[1]);
                            }
                        }
                    }
                }
                catch (System.Exception e)
                {
                    log.Error(e.ToString());
                    return false;
                }
                srReadFile.Close();
            }
            return true;
        }

        public static string _L(string strEng)
        {
            if (lang == "zh_cn" && dicLang.ContainsKey(strEng))
            {
                return dicLang[strEng];
            }
            else
            {
                return strEng;
            }
        }

        private static void ReadTokenFile(string FileName)
        {
            //下面读取branch_id和token
            try
            {
                // Create or open the specified file. 
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(tdesKey, tdesIV),
                    CryptoStreamMode.Read);

                // Create a StreamReader using the CryptoStream.
                StreamReader srReadFile = new StreamReader(cStream);

                // Read the data from the stream
                // to decrypt it.
                while (!srReadFile.EndOfStream)
                {
                    string strReadLine = srReadFile.ReadLine();
                    string[] sArray = strReadLine.Split('=');
                    switch (sArray[0])
                    {
                        case "branch_id":      //branch_id
                            branch_id = sArray[1];
                            break;
                        case "token":      //token
                            token = sArray[1];
                            break;
                        case "store_user":      //token
                            store_user = sArray[1];
                            break;
                        default:
                            break;
                    }
                }
                // Close the streams and
                // close the file.
                srReadFile.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException e)
            {
                log.Error("A Cryptographic error occurred: " + e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                log.Error("A file access error occurred: " + e.Message);
            }
            catch (System.Exception e)
            {
                log.Error(e.ToString());
            }
        }

        public static void EncryptTextToFile(String Data, String FileName, byte[] Key, byte[] IV)
        {
            try
            {
                // Create or open the specified file.
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Create a StreamWriter using the CryptoStream.
                StreamWriter sWriter = new StreamWriter(cStream);

                // Write the data to the stream 
                // to encrypt it.
                sWriter.WriteLine(Data);

                // Close the streams and
                // close the file.
                sWriter.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file access error occurred: {0}", e.Message);
            }

        }

        public static string DecryptTextFromFile(String FileName, byte[] Key, byte[] IV)
        {
            try
            {
                // Create or open the specified file. 
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create a StreamReader using the CryptoStream.
                StreamReader sReader = new StreamReader(cStream);

                // Read the data from the stream 
                // to decrypt it.
                string val = sReader.ReadLine();

                // Close the streams and
                // close the file.
                sReader.Close();
                cStream.Close();
                fStream.Close();

                // Return the string. 
                return val;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file access error occurred: {0}", e.Message);
                return null;
            }
        }
    }
}
