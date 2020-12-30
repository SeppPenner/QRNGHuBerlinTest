// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QRNG
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// The random generator.
        /// </summary>
        private readonly QRNG randomGenerator = new QRNG();

        /// <summary>
        /// A value indicating whether the random number generator is connected or not.
        /// </summary>
        private bool connected;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            this.InitializeComponent();
            this.grpRandom.Enabled = false;
        }

        /// <summary>
        /// Handles the connect button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonConnectClick(object sender, EventArgs e)
        {
            this.Memo.Items.Clear();

            if (!this.connected)
            {
                try
                {
                    if (!this.randomGenerator.CheckDLL())
                    {
                        MessageBox.Show(
                            @"loading library libQRNG.dll failed",
                            @"Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        this.Memo.Items.Add("loading library libQRNG.dll failed");
                        this.Memo.Items.Add("make sure libQRNG.dll is in the same directory as QRNG.exe");
                    }
                    else
                    {
                        var strUser = new StringBuilder(32);
                        var strPass = new StringBuilder(32);
                        strUser.Insert(0, this.edtUser.Text);
                        strPass.Insert(0, this.edtPass.Text);
                        var returnValue = !this.chkSSL.Checked
                                       ? QRNG.qrng_connect(strUser, strPass)
                                       : QRNG.qrng_connect_SSL(strUser, strPass);

                        if (returnValue != 0)
                        {
                            try
                            {
                                MessageBox.Show(
                                    @"can't connect: " + QRNG.qrng_error_strings[returnValue],
                                    @"Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                            catch
                            {
                                MessageBox.Show(
                                    @"can't connect: " + Convert.ToString(returnValue),
                                    @"Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            this.connected = true;
                            this.btnConnect.Text = @"Disconnect";
                            this.grpRandom.Enabled = true;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(
                        @"loading library libQRNG.dll failed",
                        @"Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    this.Memo.Items.Add("loading library libQRNG.dll failed");
                    this.Memo.Items.Add("make sure libQRNG.dll is in the same directory as QRNG.exe");
                }
            }
            else
            {
                QRNG.qrng_disconnect();
                this.connected = false;
                this.btnConnect.Text = @"Connect";
                this.grpRandom.Enabled = false;
                this.edtUser.Clear();
                this.edtPass.Clear();
            }
        }

        /// <summary>
        /// Handles the button click to generate a new random integer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonIntegerClick(object sender, EventArgs e)
        {
            int i;
            var sw = new Stopwatch();
            var numberOfValues = Convert.ToInt32(this.edtNum.Value);
            var values = new int[numberOfValues];
            var createdNumbers = 0;
            this.Memo.Items.Clear();
            this.Memo.Items.Add("get " + Convert.ToString(numberOfValues) + " random integer values.");
            sw.Start();
            var returnValue = QRNG.qrng_get_int_array(ref values[0], numberOfValues, ref createdNumbers);
            sw.Stop();

            if (returnValue != 0)
            {
                try
                {
                    this.Memo.Items.Add("can't get random numbers: " + QRNG.qrng_error_strings[returnValue]);
                }
                catch
                {
                    this.Memo.Items.Add("can't get random numbers: " + Convert.ToString(returnValue));
                }

                return;
            }

            this.Memo.Items.Add("got " + Convert.ToString(createdNumbers) + " numbers");

            for (i = 0; i < createdNumbers; i++)
            {
                this.Memo.Items.Add(
                    Convert.ToString(i) + "." + Convert.ToString((char)9) + Convert.ToString(values[i]));
            }

            this.Memo.Items.Add("Finished in " + Convert.ToString(sw.ElapsedMilliseconds) + " ms");
            sw.Reset();
        }

        /// <summary>
        /// Handles the button click to generate a new random float.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonFloatClick(object sender, EventArgs e)
        {
            int i;
            var sw = new Stopwatch();
            var numberOfValues = Convert.ToInt32(this.edtNum.Value);
            var values = new double[numberOfValues];
            var createdNumbers = 0;
            this.Memo.Items.Clear();
            this.Memo.Items.Add("get " + Convert.ToString(numberOfValues) + " random float values.");
            sw.Start();
            var returnValue = QRNG.qrng_get_double_array(ref values[0], numberOfValues, ref createdNumbers);
            sw.Stop();

            if (returnValue != 0)
            {
                try
                {
                    this.Memo.Items.Add("can't get random numbers: " + QRNG.qrng_error_strings[returnValue]);
                }
                catch
                {
                    this.Memo.Items.Add("can't get random numbers: " + Convert.ToString(returnValue));
                }
            }

            this.Memo.Items.Add("got " + Convert.ToString(createdNumbers) + " numbers");

            for (i = 0; i < createdNumbers; i++)
            {
                this.Memo.Items.Add(
                    Convert.ToString(i) + "." + Convert.ToString((char)9) + Convert.ToString(
                        values[i],
                        CultureInfo.InvariantCulture));
            }

            this.Memo.Items.Add("Finished in " + Convert.ToString(sw.ElapsedMilliseconds) + " ms");
            sw.Reset();
        }

        /// <summary>
        /// Handles the test button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonTestingClick(object sender, EventArgs e)
        {
            const ushort MaxRounds = 7;
            int i;
            var sw = new Stopwatch();
            this.Memo.Items.Clear();
            Application.DoEvents();
            this.Memo.Items.Add(
                "Testing mean Values from 10 to " + Convert.ToString(
                    Math.Pow(10, MaxRounds - 1),
                    CultureInfo.InvariantCulture));
            var numberOfValues = Convert.ToInt32(Math.Pow(10, MaxRounds));
            var values = new double[numberOfValues];
            numberOfValues = 1; // Count of Values to catch / test
            long number = 0;
            double completeSum = 0;

            // Main loop
            for (i = 1; i < MaxRounds; i++)
            {
                var createdNumbers = 0;
                numberOfValues *= 10; // Increase count by an order of magnitude
                sw.Start();
                var returnValue = QRNG.qrng_get_double_array(ref values[0], numberOfValues, ref createdNumbers);
                sw.Stop();

                if (returnValue != 0)
                {
                    try
                    {
                        this.Memo.Items.Add("can't get random numbers: " + QRNG.qrng_error_strings[returnValue]);
                    }
                    catch
                    {
                        this.Memo.Items.Add("can't get random numbers: " + Convert.ToString(returnValue));
                    }
                }

                this.Memo.Items.Add(
                    "got " + Convert.ToString(createdNumbers) + " numbers in "
                    + Convert.ToString(sw.ElapsedMilliseconds) + " ms");
                double sum = 0;
                int j;
                for (j = 0; j < createdNumbers - 1; j++)
                {
                    sum += values[j];
                    Application.DoEvents();
                }

                completeSum += sum; // Add to over all sum
                number += createdNumbers; // Add count to over all count

                // Calculate mean
                this.Memo.Items.Add(
                    Convert.ToString(createdNumbers) + " Values, Mean: " + Convert.ToString(
                        sum / createdNumbers,
                        CultureInfo.InvariantCulture));
                this.Memo.Items.Add(string.Empty);
            }

            // Calculate over all mean
            this.Memo.Items.Add(
                "Finished total: " + Convert.ToString(number) + " Values, total Mean: "
                + Convert.ToString(completeSum / number, CultureInfo.InvariantCulture));
        }
    }
}