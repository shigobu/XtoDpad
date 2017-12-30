//#define kantan

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using vJoyInterfaceWrap;
using SlimDX.XInput;

namespace XtoDpad
{
    public partial class Form1 : Form
    {
        static public vJoy joystick;
        static public vJoy.JoystickState iReport;
        static public uint id = 1;
        long maxval;

        Controller[] Xcont = new Controller[4] { new Controller(UserIndex.One), new Controller(UserIndex.Two), new Controller(UserIndex.Three), new Controller(UserIndex.Four) };
        int selectedController = 0;
        int TriggerThreshold = 20;
        RadioButton[] PadRadiButton = new RadioButton[4];

        public Form1()
        {
            InitializeComponent();
            joystick = new vJoy();
            iReport = new vJoy.JoystickState();
        }

        bool loadingForm = false;
        //フォームロード
        private void Form1_Load(object sender, EventArgs e)
        {
            loadingForm = true;
            PadRadiButton = new RadioButton[4] { pad1RadioButton, pad2RadioButton, pad3RadioButton, pad4RadioButton };

            Screen[] s = Screen.AllScreens;
            if (s.Length > 1)
            {
                Rectangle srect = s[1].Bounds;
                this.Location = new Point(srect.X + srect.Width / 2 - this.Width / 2, srect.Y + srect.Height / 2 - this.Height / 2);
            }

            if (!joystick.vJoyEnabled())
            {
                MessageBox.Show("vJoy driver not enabled: Failed Getting vJoy attributes.");
                FormCloseOK = true;
                this.Close();
            }
            if(joystick.GetVJDButtonNumber(id) < 12)
            {
                MessageBox.Show("仮想デバイスのボタンの数が足りません。\n" +
                                "12ボタン以上に設定してください。", 
                                "エラー", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                FormCloseOK = true;
                this.Close();
            }

            VjdStat status = joystick.GetVJDStatus(id);

            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!joystick.AcquireVJD(id))))
            {
                MessageBox.Show(string.Format("Failed to acquire vJoy device number {0}.\n", id));
                this.Close();
            }
            joystick.GetVJDAxisMax(id, HID_USAGES.HID_USAGE_X, ref maxval);

            joystick.RegisterRemovalCB(ChangedCB, this);

            // Reset this device to default values
            bool ret = joystick.ResetVJD(id);

            this.Text = "XtoDpad Device[1]:OK";

            this.WindowState = FormWindowState.Minimized;
            loadingForm = false;
        }

        //タイマーティック
        private void timer1_Tick(object sender, EventArgs e)
        {
            //コントローラーの接続状態確認
            for (int i = 0; i < 4; i++)
            {
                if (Xcont[i].IsConnected)
                {
                    PadRadiButton[i].BackColor = Color.Lime;
                }
                else
                {
                    PadRadiButton[i].BackColor = SystemColors.Control;
                }
            }

            //選択されているコントローラーの設定
            if (pad1RadioButton.Checked)
            {
                selectedController = 0;
            }
            else if (pad2RadioButton.Checked)
            {
                selectedController = 1;
            }
            else if (pad3RadioButton.Checked)
            {
                selectedController = 2;
            }
            else if (pad4RadioButton.Checked)
            {
                selectedController = 3;
            }

            if (!Xcont[selectedController].IsConnected)
            {
                return;
            }

            //if(!joystick.vJoyEnabled())
            //{
            //    return;
            //}

            if (!joystick.ResetVJD(id))
            {
                return;
            }

            State contState = Xcont[selectedController].GetState();
            Gamepad Xpad = contState.Gamepad;
            GamepadButtonFlags buttonFlags = Xpad.Buttons;

#if kantan
            //↓ボタン
            //A
            if (buttonFlags.HasFlag(GamepadButtonFlags.A))
            {
                joystick.SetBtn(true, id, 1);
            }
            else
            {
                joystick.SetBtn(false, id, 1);
            }
            //B
            if (buttonFlags.HasFlag(GamepadButtonFlags.B))
            {
                joystick.SetBtn(true, id, 2);
            }
            else
            {
                joystick.SetBtn(false, id, 2);
            }
            //X
            if (buttonFlags.HasFlag(GamepadButtonFlags.X))
            {
                joystick.SetBtn(true, id, 3);
            }
            else
            {
                joystick.SetBtn(false, id, 3);
            }
            //Y
            if (buttonFlags.HasFlag(GamepadButtonFlags.Y))
            {
                joystick.SetBtn(true, id, 4);
            }
            else
            {
                joystick.SetBtn(false, id, 4);
            }
            //LB
            if (buttonFlags.HasFlag(GamepadButtonFlags.LeftShoulder))
            {
                joystick.SetBtn(true, id, 5);
            }
            else
            {
                joystick.SetBtn(false, id, 5);
            }
            //RB
            if (buttonFlags.HasFlag(GamepadButtonFlags.RightShoulder))
            {
                joystick.SetBtn(true, id, 6);
            }
            else
            {
                joystick.SetBtn(false, id, 6);
            }
            //LT
            if (Xpad.LeftTrigger > TriggerThreshold)
            {
                joystick.SetBtn(true, id, 7);
            }
            else
            {
                joystick.SetBtn(false, id, 7);
            }
            //RT
            if (Xpad.RightTrigger > TriggerThreshold)
            {
                joystick.SetBtn(true, id, 8);
            }
            else
            {
                joystick.SetBtn(false, id, 8);
            }
            //back
            if (buttonFlags.HasFlag(GamepadButtonFlags.Back))
            {
                joystick.SetBtn(true, id, 9);
            }
            else
            {
                joystick.SetBtn(false, id, 9);
            }
            //start
            if (buttonFlags.HasFlag(GamepadButtonFlags.Start))
            {
                joystick.SetBtn(true, id, 10);
            }
            else
            {
                joystick.SetBtn(false, id, 10);
            }
            //LSB
            if (buttonFlags.HasFlag(GamepadButtonFlags.LeftThumb))
            {
                joystick.SetBtn(true, id, 11);
            }
            else
            {
                joystick.SetBtn(false, id, 11);
            }
            //RSB
            if (buttonFlags.HasFlag(GamepadButtonFlags.RightThumb))
            {
                joystick.SetBtn(true, id, 12);
            }
            else
            {
                joystick.SetBtn(false, id, 12);
            }
            //十字キー
            //右上
            if (buttonFlags.HasFlag(GamepadButtonFlags.DPadRight) && buttonFlags.HasFlag(GamepadButtonFlags.DPadUp))
            {
                joystick.SetContPov(4500, id, 1);
            }
            //右下
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadRight) && buttonFlags.HasFlag(GamepadButtonFlags.DPadDown))
            {
                joystick.SetContPov(13500, id, 1);
            }
            //左下
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadLeft) && buttonFlags.HasFlag(GamepadButtonFlags.DPadDown))
            {
                joystick.SetContPov(22500, id, 1);
            }
            //左上
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadLeft) && buttonFlags.HasFlag(GamepadButtonFlags.DPadUp))
            {
                joystick.SetContPov(31500, id, 1);
            }
            //上
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadUp))
            {
                joystick.SetContPov(0, id, 1);
            }
            //右
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadRight))
            {
                joystick.SetContPov(9000, id, 1);
            }
            //下
            else if (buttonFlags.HasFlag(GamepadButtonFlags.DPadDown))
            {
                joystick.SetContPov(18000, id, 1);
            }
            //左
            else if (buttonFlags.HasFlag(GamepadButtonFlags.DPadLeft))
            {
                joystick.SetContPov(27000, id, 1);
            }
            //ニュートラル
            else
            {
                joystick.SetContPov(-1, id, 1);
            }

            //アナログ
            //左横軸
            joystick.SetAxis(Xpad.LeftThumbX / 2 + (int)maxval / 2, id, HID_USAGES.HID_USAGE_X);
            //左縦軸
            joystick.SetAxis(Xpad.LeftThumbY / 2 + (int)maxval / 2, id, HID_USAGES.HID_USAGE_Y);
            //右横軸
            joystick.SetAxis(Xpad.RightThumbX / 2 + (int)maxval / 2, id, HID_USAGES.HID_USAGE_RX);
            //右縦軸
            joystick.SetAxis(Xpad.RightThumbY / 2 + (int)maxval / 2, id, HID_USAGES.HID_USAGE_RY);
#else
            vJoy.JoystickState iReport = new vJoy.JoystickState();
            iReport.bDevice = (byte)id;
            uint VJbuttonFlags = 0;

            //↓ボタン
            //A
            if (buttonFlags.HasFlag(GamepadButtonFlags.A))
            {
                VJbuttonFlags = VJbuttonFlags | 1;
            }
            //B
            if (buttonFlags.HasFlag(GamepadButtonFlags.B))
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 1;
            }
            //X
            if (buttonFlags.HasFlag(GamepadButtonFlags.X))
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 2;
            }
            //Y
            if (buttonFlags.HasFlag(GamepadButtonFlags.Y))
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 3;
            }
            //LB
            if (buttonFlags.HasFlag(GamepadButtonFlags.LeftShoulder))
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 4;
            }
            //RB
            if (buttonFlags.HasFlag(GamepadButtonFlags.RightShoulder))
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 5;
            }
            //LT
            if (Xpad.LeftTrigger > TriggerThreshold)
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 6;
            }
            //RT
            if (Xpad.RightTrigger > TriggerThreshold)
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 7;
            }
            //back
            if (buttonFlags.HasFlag(GamepadButtonFlags.Back))
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 8;
            }
            //start
            if (buttonFlags.HasFlag(GamepadButtonFlags.Start))
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 9;
            }
            //LSB
            if (buttonFlags.HasFlag(GamepadButtonFlags.LeftThumb))
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 10;
            }
            //RSB
            if (buttonFlags.HasFlag(GamepadButtonFlags.RightThumb))
            {
                VJbuttonFlags = VJbuttonFlags | 1 << 11;
            }
            //ボタンフラグ登録
            iReport.Buttons = VJbuttonFlags;
            //十字キー
            //右上
            if (buttonFlags.HasFlag(GamepadButtonFlags.DPadRight) && buttonFlags.HasFlag(GamepadButtonFlags.DPadUp))
            {
                iReport.bHats = 4500;
            }
            //右下
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadRight) && buttonFlags.HasFlag(GamepadButtonFlags.DPadDown))
            {
                iReport.bHats = 13500;
            }
            //左下
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadLeft) && buttonFlags.HasFlag(GamepadButtonFlags.DPadDown))
            {
                iReport.bHats = 22500;
            }
            //左上
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadLeft) && buttonFlags.HasFlag(GamepadButtonFlags.DPadUp))
            {
                iReport.bHats = 31500;
            }
            //上
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadUp))
            {
                joystick.SetContPov(0, id, 1);
                iReport.bHats = 0;
            }
            //右
            else if(buttonFlags.HasFlag(GamepadButtonFlags.DPadRight))
            {
                iReport.bHats = 9000;
            }
            //下
            else if (buttonFlags.HasFlag(GamepadButtonFlags.DPadDown))
            {
                iReport.bHats = 18000;
            }
            //左
            else if (buttonFlags.HasFlag(GamepadButtonFlags.DPadLeft))
            {
                iReport.bHats = 27000;
            }
            //ニュートラル
            else
            {
                iReport.bHats = 0xFFFFFFFF;
            }

            //アナログ
            //左横軸
            iReport.AxisX = Xpad.LeftThumbX / 2 + (int)maxval / 2;
            //左縦軸
            iReport.AxisY = Xpad.LeftThumbY / 2 + (int)maxval / 2;
            //右横軸
            iReport.AxisXRot = Xpad.RightThumbX / 2 + (int)maxval / 2;
            //右縦軸
            iReport.AxisYRot = Xpad.RightThumbY / 2 + (int)maxval / 2;

            //更新
            bool ret = joystick.UpdateVJD(id, ref iReport);

#endif
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            joystick.RelinquishVJD(id);
        }

        private void ChangedCB(bool Removed, bool First, object userData)
        {
            Form1 f = (Form1)userData;
            string title = "XtoDpad";

            if( !Removed && !First)
            {
                title += " Device[1]:OK";
                f.setTitle(title);
                bool ret = joystick.AcquireVJD(id);
            }
            else
            {
                title += " Device[1]:Wait...";
                f.setTitle(title);
            }
        }

        delegate void setTitleDelegate(string title);

        private void setTitle(string title)
        {
            if(InvokeRequired)
            {
                Invoke(new setTitleDelegate(setTitle),title);
                return;
            }
            this.Text = title;
        }

        //コントローラーを選択させるラジオボタンのバックカラーを変更する
        delegate void changeRadikoButtonBackColorDelegate(Color color,int index);
        
        /// <summary>
        /// ラジオボタンの背景色を変更します。
        /// </summary>
        /// <param name="color">ラジオボタンの背景色</param>
        /// <param name="index">ラジオボタンのインデックス</param>
        private void changeRadikoButtonBackColor(Color color,int index)
        {
            if (InvokeRequired)
            {
                Invoke(new changeRadikoButtonBackColorDelegate(changeRadikoButtonBackColor), color, index);
                return;
            }
            this.PadRadiButton[index].BackColor = color;
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = this.Text;
            notifyIcon1.ShowBalloonTip(10000);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                if(!loadingForm)
                {
                    notifyIcon1.BalloonTipText = "タスクトレイに格納されました";
                    notifyIcon1.ShowBalloonTip(10000);
                }
            }
            else
            {
                this.ShowInTaskbar = true;
            }
        }

        bool FormCloseOK = false;
        private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCloseOK = true;
            this.Close();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ユーザー操作のよって閉じられるとき
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!FormCloseOK)
                {
                    e.Cancel = true;
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }
    }
}
