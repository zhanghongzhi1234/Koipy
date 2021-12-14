using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace KoipyStore
{
    public partial class HoverFrm : Form
    {
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键
        //bool m_bMove;//标签是否移动
        ProfileLoginFrm m_profileLoginFrm;
        DateTime m_dtMouseDown;
        DateTime m_dtMouseUp;

        public HoverFrm(ProfileLoginFrm profileLoginFrm)
        {
            InitializeComponent();
            m_profileLoginFrm = profileLoginFrm;
            showMainWindowToolStripMenuItem.Text = Program._L("Show Main Window") + "(&S)";
            aboutToolStripMenuItem.Text = Program._L("About") + "(&A)";
            exitToolStripMenuItem.Text = Program._L("Exit") + "(&E)";
            leftFlag = false;
            //m_bMove = false;
        }

        private void HoverFrm_Load(object sender, EventArgs e)
        {
            Size newSize = new Size(95, 95);
            this.MaximumSize = this.MinimumSize = newSize;
            this.Size = newSize;
//            this.TopMost = true;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = ReadPositionFile("pos");
        }

        private void HoverFrm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
                m_dtMouseDown = DateTime.Now;
            }
        }

        private void HoverFrm_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
                //m_bMove = true;
            }
        }

        private void HoverFrm_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
                m_dtMouseUp = DateTime.Now;
                TimeSpan diff1 = m_dtMouseUp - m_dtMouseDown;
                //if (m_bMove == false)
                if (diff1.TotalMilliseconds < 1000)
                {
                    m_profileLoginFrm.Show();
                    m_profileLoginFrm.Activate();
                    this.Hide();
                }
                //m_bMove = false;
            }
        }

        private void showMainWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_profileLoginFrm.Show();
            m_profileLoginFrm.Activate();
            this.Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbtBox aboutDlg = new AbtBox();
            aboutDlg.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePositionFile("pos", this.Location);
            this.Close();
            m_profileLoginFrm.CloseFrm();
        }

        private void HoverFrm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                //when invisible, save the position to pos file, because exit application don't close every from
                SavePositionFile("pos", this.Location);
            }
        }

        private void SavePositionFile(string FileName, Point location)
        {
            String strData = "X=" + location.X + "\r\nY=" + location.Y;
            //把token, branch_id写入koipy
            try
            {
                // Create or open the specified file.
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(Program.tdesKey, Program.tdesIV),
                    CryptoStreamMode.Write);

                // Create a StreamWriter using the CryptoStream.
                StreamWriter sWriter = new StreamWriter(cStream);

                // Write the data to the stream 
                // to encrypt it.
                sWriter.WriteLine(strData);

                // Close the streams and
                // close the file.
                sWriter.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException ex)
            {
                Program.log.Error("A Cryptographic error occurred: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Program.log.Error("A file access error occurred: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                Program.log.Error(ex.ToString());
            }
        }

        private Point ReadPositionFile(string FileName)
        {
            //下面读取branch_id和token
            int X = 100;
            int Y = 100;
            if (File.Exists(FileName))
            {
                try
                {
                    // Create or open the specified file. 
                    FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                    // Create a CryptoStream using the FileStream 
                    // and the passed key and initialization vector (IV).
                    CryptoStream cStream = new CryptoStream(fStream,
                        new TripleDESCryptoServiceProvider().CreateDecryptor(Program.tdesKey, Program.tdesIV),
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
                            case "X":      //branch_id
                                X = Convert.ToInt32(sArray[1]);
                                break;
                            case "Y":      //token
                                Y = Convert.ToInt32(sArray[1]);
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
                    Program.log.Error("A Cryptographic error occurred: " + e.Message);
                }
                catch (UnauthorizedAccessException e)
                {
                    Program.log.Error("A file access error occurred: " + e.Message);
                }
                catch (System.Exception e)
                {
                    Program.log.Error(e.ToString());
                }
            }
            return new Point(X, Y);
        }

        private void EncryptTextToFile(String Data, String FileName, byte[] Key, byte[] IV)
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

        private string DecryptTextFromFile(String FileName, byte[] Key, byte[] IV)
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
