using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace QaRaNuGe
{
    public partial class Main : Form
    {
        private readonly QRNG _pqDll = new QRNG();
        private bool _bConnected;

        public Main()
        {
            InitializeComponent();
            grpRandom.Enabled = false;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Memo.Items.Clear();
            if (_bConnected == false)
            {
                try
                {
                    if (_pqDll.CheckDLL() == false)
                    {
                        MessageBox.Show(@"loading library libQRNG.dll failed", @"Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Memo.Items.Add("loading library libQRNG.dll failed");
                        Memo.Items.Add("make sure libQRNG.dll is in the same directory as QRNG.exe");
                    }
                    else
                    {
                        var strUser = new StringBuilder(32);
                        var strPass = new StringBuilder(32);
                        strUser.Insert(0, edtUser.Text);
                        strPass.Insert(0, edtPass.Text);
                        var iRet = chkSSL.Checked == false
                            ? QRNG.qrng_connect(strUser, strPass)
                            : QRNG.qrng_connect_SSL(strUser, strPass);
                        if (iRet != 0)
                        {
                            try
                            {
                                MessageBox.Show(@"can't connect: " + QRNG.qrng_error_strings[iRet], @"Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            catch
                            {
                                MessageBox.Show(@"can't connect: " + Convert.ToString(iRet), @"Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            _bConnected = true;
                            btnConnect.Text = @"Disconnect";
                            grpRandom.Enabled = true;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"loading library libQRNG.dll failed", @"Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Memo.Items.Add("loading library libQRNG.dll failed");
                    Memo.Items.Add("make sure libQRNG.dll is in the same directory as QRNG.exe");
                }
            }
            else
            {
                QRNG.qrng_disconnect();
                _bConnected = false;
                btnConnect.Text = @"Connect";
                grpRandom.Enabled = false;
                edtUser.Clear();
                edtPass.Clear();
            }
        }

        private void BtnInt_Click(object sender, EventArgs e)
        {
            int i;
            var sw = new Stopwatch();
            var iNumberOfValues = Convert.ToInt32(edtNum.Value);
            var iArray = new int[iNumberOfValues];
            var iCreatedNumbers = 0;
            Memo.Items.Clear();
            Memo.Items.Add("get " + Convert.ToString(iNumberOfValues) + " random integer values.");
            sw.Start();
            var iRet = QRNG.qrng_get_int_array(ref iArray[0], iNumberOfValues, ref iCreatedNumbers);
            sw.Stop();
            if (iRet != 0)
            {
                try
                {
                    Memo.Items.Add("can't get random numbers: " + QRNG.qrng_error_strings[iRet]);
                }
                catch
                {
                    Memo.Items.Add("can't get random numbers: " + Convert.ToString(iRet));
                }
                return;
            }
            Memo.Items.Add("got " + Convert.ToString(iCreatedNumbers) + " numbers");
            for (i = 0; i < iCreatedNumbers; i++)
                Memo.Items.Add(Convert.ToString(i) + "." + Convert.ToString((char) 9) + Convert.ToString(iArray[i]));
            Memo.Items.Add("Finished in " + Convert.ToString(sw.ElapsedMilliseconds) + " ms");
            sw.Reset();
        }

        private void BtnFloat_Click(object sender, EventArgs e)
        {
            int i;
            var sw = new Stopwatch();
            var iNumberOfValues = Convert.ToInt32(edtNum.Value);
            var fArray = new double[iNumberOfValues];
            var iCreatedNumbers = 0;
            Memo.Items.Clear();
            Memo.Items.Add("get " + Convert.ToString(iNumberOfValues) + " random float values.");
            sw.Start();
            var iRet = QRNG.qrng_get_double_array(ref fArray[0], iNumberOfValues, ref iCreatedNumbers);
            sw.Stop();
            if (iRet != 0)
                try
                {
                    Memo.Items.Add("can't get random numbers: " + QRNG.qrng_error_strings[iRet]);
                }
                catch
                {
                    Memo.Items.Add("can't get random numbers: " + Convert.ToString(iRet));
                }
            Memo.Items.Add("got " + Convert.ToString(iCreatedNumbers) + " numbers");
            for (i = 0; i < iCreatedNumbers; i++)
                Memo.Items.Add(Convert.ToString(i) + "." + Convert.ToString((char) 9) +
                               Convert.ToString(fArray[i], CultureInfo.InvariantCulture));
            Memo.Items.Add("Finished in " + Convert.ToString(sw.ElapsedMilliseconds) + " ms");
            sw.Reset();
        }

        private void BtnTesting_Click(object sender, EventArgs e)
        {
            const ushort maxrounds = 7;
            int i;
            var sw = new Stopwatch();
            Memo.Items.Clear();
            Application.DoEvents();
            Memo.Items.Add("Testing mean Values from 10 to " +
                           Convert.ToString(Math.Pow(10, maxrounds - 1), CultureInfo.InvariantCulture));
            var iNumberOfValues = Convert.ToInt32(Math.Pow(10, maxrounds));
            var fArray = new double[iNumberOfValues];
            iNumberOfValues = 1; // Count of Values to catch / test
            long aNum = 0;
            double aSum = 0;
            // Main loop
            for (i = 1; i < maxrounds; i++)
            {
                var iCreatedNumbers = 0;
                iNumberOfValues = iNumberOfValues * 10; // increase count by an order of magnitude
                sw.Start();
                var iRet = QRNG.qrng_get_double_array(ref fArray[0], iNumberOfValues, ref iCreatedNumbers);
                sw.Stop();
                if (iRet != 0)
                    try
                    {
                        Memo.Items.Add("can't get random numbers: " + QRNG.qrng_error_strings[iRet]);
                    }
                    catch
                    {
                        Memo.Items.Add("can't get random numbers: " + Convert.ToString(iRet));
                    }
                Memo.Items.Add("got " + Convert.ToString(iCreatedNumbers) + " numbers in " +
                               Convert.ToString(sw.ElapsedMilliseconds) + " ms");
                double sum = 0;
                int j;
                for (j = 0; j < iCreatedNumbers - 1; j++)
                {
                    sum = sum + fArray[j];
                    Application.DoEvents();
                }
                aSum = aSum + sum; // add to over all sum
                aNum = aNum + iCreatedNumbers; // add count to over all count
                // calculate mean
                Memo.Items.Add(Convert.ToString(iCreatedNumbers) + " Values, Mean: " +
                               Convert.ToString(sum / iCreatedNumbers, CultureInfo.InvariantCulture));
                Memo.Items.Add("");
            }
            // Calculate over all mean
            Memo.Items.Add("Finished total: " + Convert.ToString(aNum) + " Values, total Mean: " +
                           Convert.ToString(aSum / aNum, CultureInfo.InvariantCulture));
        }
    }
}