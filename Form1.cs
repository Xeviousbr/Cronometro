using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading.Tasks;

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

        private DateTime timeStop, MomentoQueParou, TempoParadoTotal;
        private TimeSpan span, spanAnt, TempTot, TempoParado, UltSpan;
        private int IntervalG;
        private int Tipo = 0;
        private bool DeuMens = false;
        private bool X = false;

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (this.Tipo == 0)
            {
                if (radioButton2.Checked)
                    Tipo = -1;
                else
                    Tipo = 1;
                Iniciar();
                await Task.Delay(700);
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                mnMaTempo.Enabled = timer1.Enabled;
                mnMeTempo.Enabled = mnMaTempo.Enabled;
                if (timer1.Enabled)
                {
                    MomentoQueParou = DateTime.Now;
                    BtnStart.Text = "Continuar";
                    timer1.Stop();
                    BtnStart.Image = Properties.Resources.stop_wheel;
                    btReinicio.Text = "Reiniciar";
                    btReinicio.Enabled = true;
                }
                else
                {
                    TempoParado = DateTime.Now - MomentoQueParou;
                    TempoParadoTotal = TempoParadoTotal + TempoParado;
                    TempoParado = TimeSpan.Parse(TempoParadoTotal.ToLongTimeString());
                    BtnStart.Text = "Pausa";
                    timer1.Start();
                    BtnStart.Image = Properties.Resources.spinning_wheel;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MostraTempo();
            if (timer1.Interval < 1000)
                if (IntervalG < 9000)
                {
                    IntervalG++;
                    timer1.Interval = IntervalG / 10;
                }
            if (Tipo == 1)
            {
                int currentMinute = (int)span.TotalMinutes;
                if (currentMinute != lastSavedMinute) // Evita salvar repetidamente no mesmo minuto
                {
                    SalvarTempo(currentMinute);
                    lastSavedMinute = currentMinute;
                }
            }

            if (Tipo == -1)
                if (span.TotalSeconds < 0)
                    if (!DeuMens)
                    {
                        if (ckDesliga.Checked)
                        {
                            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                        }
                        DeuMens = true;
                        TocaSom();
                        if (this.WindowState == FormWindowState.Minimized)
                            this.WindowState = FormWindowState.Normal;
                        this.TopMost = true;
                        FazFlash();
                        string TempAlc = udMin.Value.ToString("00") + ":" + udSeg.Value.ToString("00");
                        if (udHora.Value > 0)
                            TempAlc += ":" + udHora.Value.ToString("00");
                        DialogResult confirm = MessageBox.Show("Refazer a contagem?", "Tempo Alcançado (" + TempAlc + ")", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        if (confirm == DialogResult.No)
                            Application.Exit();
                        else
                        {
                            TiraFlash();
                            DeuMens = false;
                            Iniciar();
                        }
                    }
                    else
                        TocaSom();
        }

        public mainFrm()
        {
            InitializeComponent();
            IntervalG = 500;
            TempoParadoTotal = DateTime.FromOADate(0);
            TempTot = new TimeSpan(0, 0, 0);
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

        private int lastSavedMinute = -1;        

        private void SalvarTempo(int minutos)
        {
            string caminhoArquivo = "CronometroLog.txt";
            string linha = $"{DateTime.Now:HH:mm:ss} - Tempo cronometrado: {minutos} minutos";

            try
            {
                File.WriteAllText(caminhoArquivo, linha);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o tempo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void TiraFlash()
        {
            IntPtr hWnd = this.Handle;
            FLASHWINFO fInfo = new FLASHWINFO();
            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_STOP; 
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;
            FlashWindowEx(ref fInfo);
        }

        private void ckSom_CheckedChanged(object sender, EventArgs e)
        {
            // trkVol.Enabled = ckSom.Checked;
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            this.Tipo = 1;
            Iniciar();
        }

        private void btReinicio_Click(object sender, EventArgs e)
        {
            if (Tipo==1)
                MomentoQueParou = DateTime.Now;
            Iniciar();
            spanAnt = new TimeSpan(0);
            btReinicio.Enabled = false;            
        }

        private void MostraTempo()
        {
            string Tempo;
            span = DateTime.Now.Subtract(timeStop);
            span = span.Subtract(TempoParado);
            if (Tipo == 1)
                span = span + spanAnt;
            else
                span = TempTot - span;
            MostraAli(span);
        }

        private void MostraAli(TimeSpan EsseSpan)
        {
            string Tempo;
            if (timer1.Interval < 1000)
                Tempo = EsseSpan.Minutes.ToString("00") + ":" + EsseSpan.Seconds.ToString("00") + ":" + EsseSpan.Milliseconds.ToString("00").Substring(0, 2);
            else
                Tempo = EsseSpan.Minutes.ToString("00") + ":" + EsseSpan.Seconds.ToString("00");
            if (span.Hours > 0)
                Tempo = span.Hours.ToString("00") + ":" + Tempo;
            watchLb.Text = Tempo;
            this.Text = Tempo;
            this.UltSpan = EsseSpan;
        }

        private void mnMaTempo_Click(object sender, EventArgs e)
        {
            X = true;
            DateTime MomentoClicado = DateTime.Now;
            FTempo TelaTempo = new FTempo();
            TelaTempo.ShowDialog(); 
            if (TelaTempo.DialogResult == DialogResult.OK)
            {
                TimeSpan TS = TelaTempo.TS;
                DateTime MomentoOK = DateTime.Now;
                TimeSpan TmpOK = MomentoClicado - MomentoOK;
                timeStop = timeStop.Add(-TS);
                TimeSpan nvTempo = span.Add(TS);
                MostraTempo();
                MostraAli(nvTempo);
            }
            TelaTempo.Dispose();
        }

        private void ckDesliga_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDesliga.Checked)
            {
                textBox1.Tag = textBox1.Text;
                textBox1.Text = "Desligar o Computador";
                textBox1.ReadOnly = true;
            } else
            {
                textBox1.Text = textBox1.Tag.ToString();
                textBox1.Tag = "";
                textBox1.ReadOnly = false;
            }
        }

        private void mnMeTempo_Click(object sender, EventArgs e)
        {            
            DateTime MomentoClicado = DateTime.Now;
            FTempo TelaTempo = new FTempo();
            TelaTempo.Text = "Informe o tempo a ser subtraído";
            TelaTempo.ShowDialog();
            if (TelaTempo.DialogResult == DialogResult.OK)
            {
                TimeSpan TS = TelaTempo.TS;
                DateTime MomentoOK = DateTime.Now;
                TimeSpan TmpOK = MomentoClicado - MomentoOK;
                timeStop = timeStop.Add(TS);
                TimeSpan nvTempo = span.Add(-TS);
                MostraTempo();
                MostraAli(nvTempo);
            }
            TelaTempo.Dispose();
        }

        private void TocaSom()
        {
            /*if (ckSom.Checked )
            {
                string s = Application.StartupPath + "\\LASER.WAV";
                 if (this.myPlayer == null)
                {
                    this.myPlayer = new Player();
                    this.myPlayer.Sliders.AudioVolume = trkVol;
                }
                this.myPlayer.Play(s); 
        }*/
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            udHora.Visible = radioButton2.Checked;
            udMin.Visible = radioButton2.Checked;
            udSeg.Visible = radioButton2.Checked;
            ckDesliga.Visible = radioButton2.Checked;
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