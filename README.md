# KoipyStore
This application is developed for [Koipy](http://www.koipy.com) company, it run in POS machine of vendors. it provide a terminal applicaton for koipy members to record their expenses record, query history record, and use their scores to enjoy the discounts.

# Summary
1. After startup, check whether the token file koipy exists in the same directory, if it exists, enter the main interface directly, otherwise enter the merchant login interface. The token approach is similar to Java's JWT client authentication, but there is no validity period. The token file is different for each merchant. After the merchant logs in, it is obtained through the api and stored locally, and it will be deleted when the merchant logs out. Every operation, except logout, must upload token, branch_id and language. Token distinguishes the merchant, branch_id distinguishes the branch of the merchant, and language determines the language returned

2. The background of the merchant login interface is K card, merchant users must log in to use

3. The waiting form is used in all places where api is requested. There are two ways of waiting for the form https://developer.aliyun.com/article/397462
a) The main thread executes the task, and the child thread ShowDialog() pops up the form, so that the entire program is blocked until the main thread finishes the task, and then kills the child thread and continues execution. Koipy uses this approach:
````C#
m_waitFrm = new WaitFrm(); //Every time you must new, create a new thread, because the thread will be terminated after CloseWait
        m_waitFrm.ShowWait();
................................
m_waitFrm.CloseWait();
this.Activate(); //Because waitingFrm is also a topmost attribute in another thread, it must be Activate first, otherwise the messagebox will bounce behind
````
b) The child thread performs tasks, the main thread ShowDialog()

4. API uses HttpWebRequest, the default is Get, or add Method="Post" to use POST method, with or without parameters are directly spelled in the url string. All api returns are json strings, branch_id and token are returned, and then a token file is created, including branch_id, token and login user name. The file uses triple data encryption, referred to as Triple DES. .net ready-made class TripleDESCryptoServiceProvider can be implemented

5. Clicking on all input boxes will pop up the full keyboard. In addition, clicking on the number input boxes will pop up 1-9 number input boxes. This is all for the touch screen. It will always be on the top before closing. There is a modeless window with everything inside. It's a button. In fact, I think we should use a modal form. Because of the modeless form, the user can still click back to the original input box to directly input, resulting in inconsistent behavior, but it is a minor problem, and generally no one does this.
When the keyboard window pops up, pay attention to the position near the clicked input box:
````C#
            TextBox txtTemp = sender as TextBox;
            m_keyboardFrm.Location = txtTemp.PointToScreen(new Point(-272, 135));
            m_keyboardFrm.Show();
            m_keyboardFrm.BringToFront();
            m_keyboardFrm.setTxtBox(txtTemp);
````
In addition, m_keyboardFrm.Hide() hides the keyboard window in the Leave function of Txtbox

6. There are 2 ways to ensure that only one process is running
a) Find the process with the same name in the system,
````C#
Process current = Process.GetCurrentProcess();
Process[] processes = Process.GetProcessesByName(current.ProcessName);
````
If there is a process, the existing process is transferred to the foreground, and if it does not exist, a new process is created.
b) Using System.Threading.Mutex, it will be detected when it is new. Mutex has a uniqueName when it is new. You can judge whether it already exists in other processes according to createdNew (false is already exist).
````C#
private Mutex mutex;
protected override void OnStartup(StartupEventArgs e)
{
    this.mutex = new Mutex(true, UniqueMutexName, out createdNew);
    GC.KeepAlive(this.mutex);
}
````
The wording of Mutex is recommended here, which is simple, clear and tall.

In addition, there are two ways to re-transfer the original process to the foreground:
a) To call the win32 API function, the return result of the previous Process.GetProcessesByName(current.ProcessName) is needed here.
````C#
public static void HandleRunningInstance(Process instance)
{
    //Ensure that the window is not minimized or maximized
    ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
    //Set the real routine to the foreground window
    SetForegroundWindow(instance.MainWindowHandle);
}
````
b) Use EventWaitHandle to continuously monitor in another thread, and restore the process window to the foreground after receiving a notification.
````C#
this.eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, UniqueEventName);
````
Then refer to AlarmAnalysis for the specific writing method. The writing method is a bit complicated. Fortunately, if there are successful examples in the future, copy it directly. The characteristic is that it is tall, and there is no need to find an existing process instance. This method is recommended.

7. The perfect solution for multi-language dynamic switching:
C# strings are all unicode, config.ini configures the currently selected language, for example, zh_cn, then zh_cn.ini configures all string mapping replacements, and the Program._L() function returns the corresponding string according to the system configuration
All forms add Reload() function, which sets all text:
````C#
public void Reload()
        {
            this.Text = Program._L("Koipy");
            lblPassword.Text = Program._L("Password") + ":";
            txtPassword.Text = "";
            btnOK.Text = Program._L("OK") + "(&O)";
        }
````
Then call it in the Form_Load() function. If there is a hidden form to show(), remember to call the Reload() function afterwards.

8. After the merchant logs in, the floating window HoverFrm is first displayed. This approach is a bit questionable (customer demand). The program exit can only be exited in the Setting form, and the password must be entered to exit. This practice is worth learning to prevent customers from turning off by mistake. Generally, the cash register is Windows, but the cashier does not have administrator rights and cannot directly kill the process.

9. The main interface is the user login interface, you can scan the k card or directly enter the K card number. The camera scanning program CamWorker.cs is a third-party library, so you don’t need to look at it carefully. You can review it later when you need it. Just remember that the QR code is actually a string. Scan the K card to get the user’s K card number. The minimum two-dimensional code is 21*21, the maximum is 177*177, the general storage information of black and white is about 10k, and the single-layer color can reach 1-2M

10. The next function can make the window unable to be killed by the user from the task manager and become a virus, haha ​​(only right-click to exit from the floating window)
````C#
private void ProfileLoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) //Note that it is UserClosing, if you use other ones, the customer will not be able to shut down
            {
                e.Cancel = true;
            }
            Hover();
        }
````
11. Except for the main form, the ShowInTaskBar of all pop-up dialogs needs to be set to False, otherwise the taskbar will display several Koipys, which seems to be incomplete, and I forgot to change LogoutFrm

12. After the user logs in, the current consumption input interface is displayed, and you can enter whether there are extra points (if you select points*2), invoice number, consumption amount, number of people, current points page and historical points page are bound together with the _Move() function Move: m_historyPerkFrm.Location = this.Location;

13. Two consumer interfaces use SplitContainer to layout, and it feels like there is no Grid convenient for wpf. In addition, I also used TableLayoutPanel, but only for data display. I found that its internal grid can be nested with other controls. I suddenly felt that it should be laid out with TableLayoutPanel instead of SplitContainer. It looks like the advantage of SplitContainer to layout is that it can be dragged, but the layout of this program is fixed.

14. The complex control used inside is DataGridView, which is an upgraded version of the previous DataGrid, and it is quite complicated to use. The ListView is lightweight. In the future, it is preferred to use ListView. If ListView can't do it, use DataGridView. DataGridView also has the data source binding function, but it feels that data source binding is only when the data is updated frequently. The update is not frequent, and there is no problem with inserting a row. Then, if there is an update, only the corresponding row or cell is updated.

15. For the pictures in the current consumption list, only the url is returned by the api, and the actual test found that only the url can not be displayed. You must use System.Net.WebRequest to read the local, and then Bitmap bmp = new Bitmap (responseStream) to use the memory image, so that it can.

16. ShowMessageBoxTimeout() can realize that after opening the messagebox for a period of time, it will be closed automatically if it is not clicked.

# License
This application is under the Apache 2.0 license. See the [LICENSE](LICENSE) file for details..