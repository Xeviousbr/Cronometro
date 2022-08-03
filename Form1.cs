using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PVS.MediaPlayer;

namespace Cronometro
{

    public partial class mainFrm : Form
    {
        #region FlashWindow

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }
        private const uint FLASHW_STOP = 0;
        private const uint FLASHW_CAPTION = 1;
        private const uint FLASHW_TRAY = 2;
        private const uint FLASHW_ALL = 3;
        private const uint FLASHW_TIMER = 4;
        private const uint FLASHW_TIMERNOFG = 12;

        #endregion

        // #region SOM

        //public enum PlaySoundFlags : int
        //{
        //    SND_SYNC = 0x0000,  /* play synchronously (default) */ //同步
        //    SND_ASYNC = 0x0001,  /* play asynchronously */ //异步
        //    SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
        //    SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
        //    SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
        //    SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
        //    SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
        //    SND_ALIAS = 0x00010000, /* name is a registry alias */
        //    SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
        //    SND_FILENAME = 0x00020000, /* name is file name */
        //    SND_RESOURCE = 0x00040004  /* name is resource name or atom */
        //}

        //[DllImport("winmm")]
        //public static extern bool PlaySound(string szSound, IntPtr hMod, PlaySoundFlags flags);

        // #endregion

        private Player myPlayer;

        DateTime timeStop, MomentoQueParou, TempoParadoTotal;
        TimeSpan span, spanAnt, TempTot, TempoParado;

        int IntervalG;
        int Tipo = 0;
        bool DeuMens = false;

        public mainFrm()
        {
            InitializeComponent();
            IntervalG = 500;
            TempoParadoTotal = DateTime.FromOADate(0);
            TempTot = new TimeSpan(0, 0, 0);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (this.Tipo==0)
            {
                if (radioButton2.Checked)
                    Tipo = -1;
                else
                    Tipo = 1;                    
                Iniciar();
             }
             else
             {
                if (timer1.Enabled)
                {
                    MomentoQueParou = DateTime.Now;
                    BtnStart.Text = "Continuar";
                    timer1.Stop();
                    BtnStart.Image = Cronometro.Properties.Resources.stop_wheel;
                }
                else
                {
                    TempoParado= DateTime.Now - MomentoQueParou;                    
                    TempoParadoTotal = TempoParadoTotal + TempoParado;
                    TempoParado = TimeSpan.Parse(TempoParadoTotal.ToLongTimeString());
                    BtnStart.Text = "Pausa";
                    timer1.Start();
                    BtnStart.Image = Cronometro.Properties.Resources.spinning_wheel;                
                }
            }            
        }

        private void Iniciar()
        {
            timeStop = DateTime.Now;
            BtnStart.Text = "Pausa";
            timer1.Start();
            spanAnt = span;
            BtnStart.Image = Properties.Resources.spinning_wheel;            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string Tempo;
            span = DateTime.Now.Subtract(timeStop);
            span = span.Subtract(TempoParado);
            if (this.Tipo == 1)
                span = span + spanAnt;
            else
                span = TempTot - span;
            if (timer1.Interval < 1000)
                Tempo = span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00") + ":" + span.Milliseconds.ToString("00").Substring(0, 2);
            else
                Tempo = span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00");
            if (span.Hours >0 )
                Tempo = span.Hours.ToString("00") + ":" + Tempo;
            watchLb.Text = Tempo;
            this.Text = Tempo;
            if (timer1.Interval < 1000)
                if (IntervalG < 9000)
                {
                    IntervalG++;
                    timer1.Interval = IntervalG / 10;
                }
            if (span.TotalSeconds <0)
                if (DeuMens == false)
                {
                    DeuMens = true;
                    TocaSom();
                    if (((this)).WindowState == FormWindowState.Minimized)
                        ((this)).WindowState = FormWindowState.Normal;
                    this.TopMost = true;
                    FazFlash();
                    DialogResult confirm = MessageBox.Show("Refazer a contagem?", "Tempo Alcançado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (confirm== DialogResult.No)
                        Application.Exit();
                    else
                    {
                        this.myPlayer.Stop();
                        DeuMens = false;
                        Iniciar();
                    }
                }
                else
                    TocaSom();
        }

        private void udHora_ValueChanged(object sender, EventArgs e)
        {
            int iMin = TempTot.Minutes;
            int iSeg = TempTot.Seconds;
            SetaMask((int)udHora.Value, iMin, iSeg);
        }

        private void udMin_ValueChanged(object sender, EventArgs e)
        {
            int iHora = TempTot.Hours;
            int iSeg = TempTot.Seconds;
            SetaMask(iHora, (int)udMin.Value, iSeg);
        }

        private void udSeg_ValueChanged(object sender, EventArgs e)
        {
            int iHora = TempTot.Hours;
            int iMin = TempTot.Minutes;
            SetaMask(iHora, iMin, (int)udSeg.Value);
        }

        private int Val(string Text)
        {
            int Tam = Text.Trim().Length;
            if (Tam==0)
            {
                return 0;
            } else
            {
                return int.Parse(Text);
            }
        }

        private void SetaMask(int Hora, int Min, int Seg)
        {
            TempTot = new TimeSpan(Hora, Min, Seg);
        }

        private void FazFlash()
        {
            IntPtr hWnd = this.Handle;
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMER; // FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;
            FlashWindowEx(ref fInfo);
        }

        private void ckSom_CheckedChanged(object sender, EventArgs e)
        {
            trkVol.Enabled = ckSom.Checked;
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            this.Tipo = 1;
            Iniciar();
        }

        private void TocaSom()
        {
            if (ckSom.Checked )
            {
                string s = Application.StartupPath + "\\LASER.WAV";
                if (this.myPlayer == null)
                {
                    this.myPlayer = new Player();
                    this.myPlayer.Sliders.AudioVolume = trkVol;
                }
                this.myPlayer.Play(s);                
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ckSom.Visible = false;
            trkVol.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            udHora.Visible = radioButton2.Checked;
            udMin.Visible = radioButton2.Checked;
            udSeg.Visible = radioButton2.Checked;
            ckSom.Visible = true;
            trkVol.Visible = true;
            timer1.Enabled = false;
            watchLb.Text = "";
            BtnStart.Image = Properties.Resources.stop_wheel;
            BtnStart.Text = "Iniciar";
            span = new TimeSpan(0, 0, 0);
            this.Tipo = 0;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}