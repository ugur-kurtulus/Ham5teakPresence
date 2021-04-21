﻿using DiscordRPC;
using System;
using System.Windows.Forms;

namespace Ham5teakPresence
{
    public partial class Custom : Form
    {
        public Custom()
        {
            InitializeComponent();
        }

        bool inita = false;
        bool enabled = false;

        public DiscordRpcClient Client { get; private set; }

        private void Custom_Load(object sender, EventArgs e)
        {

            // loads the last form entries from settings, will apply default if none has been applied yet

            textBox1.Text = Properties.Settings.Default.appid;
            detailsbox.Text = Properties.Settings.Default.details;
            statusbox.Text = Properties.Settings.Default.status;
            largeimagetextbox.Text = Properties.Settings.Default.lit;
            largeimagekeybox.Text = Properties.Settings.Default.lik;
            smallimagetextbox.Text = Properties.Settings.Default.sit;
            smallimagekeybox.Text = Properties.Settings.Default.sik;
            button1url.Text = Properties.Settings.Default.b1u;
            button1text.Text = Properties.Settings.Default.b1t;
            button2url.Text = Properties.Settings.Default.b2u;
            button2text.Text = Properties.Settings.Default.b2t;

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms["CustomHelp"];
            if (form != null)
            {
                form = new CustomHelp();
                return;
            }
            CustomHelp chelpBox = new CustomHelp();
            chelpBox.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Defining boxes


            string appid;
            appid = textBox1.Text;
            string details;
            details = detailsbox.Text;
            string status;
            status = statusbox.Text;
            string lik;
            lik = largeimagekeybox.Text;
            string lit;
            lit = largeimagetextbox.Text;
            string sik;
            sik = smallimagekeybox.Text;
            string sit;
            sit = smallimagetextbox.Text;
            string b1t;
            b1t = button1text.Text;
            string b1u;
            b1u = button1url.Text;
            string b2t;
            b2t = button2text.Text;
            string b2u;
            b2u = button2url.Text;


            // Checks and applying of presence

            if (enabled != false)
            {
                string message1 = "Presence is already applied.";
                string title1 = "Custom Presence";
                MessageBox.Show(message1, title1);
            }
            else if (String.IsNullOrEmpty(appid))
            {

                string message1 = "Application ID must be entered.";
                string title1 = "Custom Presence";
                MessageBox.Show(message1, title1);
            }
            else if (!String.IsNullOrEmpty(b2u) && !String.IsNullOrEmpty(b1u))
            {
                enabled = true;
                inita = true;
                Client = new DiscordRpcClient(appid);
                Client.Initialize();
                Client.SetPresence(new RichPresence()
                {
                    Details = details,
                    State = status,
                    Assets = new Assets()
                    {
                        LargeImageKey = lik,
                        LargeImageText = lit,
                        SmallImageKey = sik,
                        SmallImageText = sit
                    },
                    Buttons = new DiscordRPC.Button[]
                    {
                    new DiscordRPC.Button() { Label = b1t, Url = b1u },
                    new DiscordRPC.Button() { Label = b2t, Url = b2u }
                    }
                });
                string message = "Presence has been applied.";
                string title = "Custom Presence";
                MessageBox.Show(message, title);
            }
            else if (String.IsNullOrEmpty(b2u) && String.IsNullOrEmpty(b1u))
            {
                enabled = true;
                inita = true;
                Client = new DiscordRpcClient(appid);
                Client.Initialize();
                Client.SetPresence(new RichPresence()
                {
                    Details = details,
                    State = status,
                    Assets = new Assets()
                    {
                        LargeImageKey = lik,
                        LargeImageText = lit,
                        SmallImageKey = sik,
                        SmallImageText = sit
                    }
                });
                string message = "Presence has been applied.";
                string title = "Custom Presence";
                MessageBox.Show(message, title);
            }
            else if (!String.IsNullOrEmpty(b2u) && String.IsNullOrEmpty(b1u))
            {
                enabled = true;
                inita = true;
                Client = new DiscordRpcClient(appid);
                Client.Initialize();
                Client.SetPresence(new RichPresence()
                {
                    Details = details,
                    State = status,
                    Assets = new Assets()
                    {
                        LargeImageKey = lik,
                        LargeImageText = lit,
                        SmallImageKey = sik,
                        SmallImageText = sit
                    },
                    Buttons = new DiscordRPC.Button[]
                    {
                    new DiscordRPC.Button() { Label = b2t, Url = b2u }
                    }
                });
                string message = "Presence has been applied.";
                string title = "Custom Presence";
                MessageBox.Show(message, title);
            }
            else if (String.IsNullOrEmpty(b2u) && !String.IsNullOrEmpty(b1u))
            {
                enabled = true;
                inita = true;
                Client = new DiscordRpcClient(appid);
                Client.Initialize();
                Client.SetPresence(new RichPresence()
                {
                    Details = details,
                    State = status,
                    Assets = new Assets()
                    {
                        LargeImageKey = lik,
                        LargeImageText = lit,
                        SmallImageKey = sik,
                        SmallImageText = sit
                    },
                    Buttons = new DiscordRPC.Button[]
                    {
                    new DiscordRPC.Button() { Label = b1t, Url = b1u }
                    }
                });
                string message = "Presence has been applied.";
                string title = "Custom Presence";
                MessageBox.Show(message, title);
            }

            // Form events in general


            // Saves the entries to settings

            Properties.Settings.Default.appid = textBox1.Text;
            Properties.Settings.Default.details = detailsbox.Text;
            Properties.Settings.Default.status = statusbox.Text;
            Properties.Settings.Default.lit = largeimagetextbox.Text;
            Properties.Settings.Default.lik = largeimagekeybox.Text;
            Properties.Settings.Default.sit = smallimagetextbox.Text;
            Properties.Settings.Default.sik = smallimagekeybox.Text;
            Properties.Settings.Default.b1u = button1url.Text;
            Properties.Settings.Default.b1t = button1text.Text;
            Properties.Settings.Default.b2u = button2url.Text;
            Properties.Settings.Default.b2t = button2text.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            // disables close button as long as the presence is running
            this.ControlBox = false;
        }

        private void detailsbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (inita == true)
            {
                enabled = false;
                Client.Dispose();
                this.ControlBox = true; // re-enables close button
                inita = false;
                string message2 = "Presence has been removed.";
                string title2 = "Custom Presence";
                MessageBox.Show(message2, title2);
            }
            else
            {
                string message = "Please apply a presence first.";
                string title = "Custom Presence";
                MessageBox.Show(message, title);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Beastman9095/Ham5teakPresence/wiki/Guide-To-Discord-Rich-Presences#steps");
        }
    }
}
