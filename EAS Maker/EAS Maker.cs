using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;
using System.Speech;

namespace EAS_Maker
{
    public partial class EASMaker : Form
    {
        //string[] States;
        string[] EASTYPES;
        string[] EASSENDERS;
        System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer(@"Assets\basicEOM.wav");
        System.Media.SoundPlayer simpleSound2 = new System.Media.SoundPlayer(@"Assets\basicSAMEandAttention.wav");
        System.Media.SoundPlayer simpleSound3 = new System.Media.SoundPlayer(@"Assets\EAlertS.wav");
        Point[] points = {new Point(0,0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), };
        public EASMaker()
        {
            InitializeComponent();
        }
        SpeechSynthesizer speechSynthesizerObj;
        private void Form1_Load(object sender, EventArgs e)
        {
            simpleSound.Load();
            simpleSound2.Load();
            simpleSound3.Load();
            simpleSound3.PlayLooping();
            speechSynthesizerObj = new SpeechSynthesizer();
            //States = File.ReadAllText("Assets\\States.txt").Split(new Char[] { '\r'});
            EASTYPES = File.ReadAllText("Assets\\EASTypes.txt").Split(new Char[] { '\r'});
            EASSENDERS = File.ReadAllText("Assets\\EASSenders.txt").Split(new Char[] { '\r' });
            //TODO Fix this.
            /*for (int s = 0; s < States.Length; s++)
            {
                stateDrop.Items.Add(States[s]);
            }*/
            for (int s = 0; s < EASTYPES.Length; s++)
            {
                easTypes.Items.Add(EASTYPES[s]);
            }
            for (int s = 0; s < EASSENDERS.Length; s++)
            {
                EASSenderTypes.Items.Add(EASSENDERS[s]);
            }
            Start_Speech.Enabled = false;
            maintext.Location = new Point(maintext.Location.X, maintext.Location.Y - 25);
            for(int i = 0; i < points.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        points[i-1] = label1.Location;
                    break;
                    case 2:
                        points[i-1] = label3.Location;
                    break;
                    case 3:
                        points[i-1] = label5.Location;
                    break;
                    case 4:
                        points[i-1] = easTypes.Location;
                    break;
                    case 5:
                        points[i-1] = stateDrop.Location;
                    break;
                    case 6:
                        points[i-1] = EASSenderTypes.Location;
                    break;
                    case 7:
                        points[i-1] = button1.Location;
                    break;
                    case 8:
                        points[i-1] = button2.Location;
                    break;
                    case 9:
                        points[i-1] = button3.Location;
                    break;
                    case 10:
                        points[i-1] = Apply.Location;
                    break;
                    case 11:
                        points[i-1] = Start_Speech.Location;
                    break;
                }
            }
        }

        private void stateDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            EASSenderTypes.Enabled = true;
        }

        private void easTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            stateDrop.Enabled = true;
            AlertTypeText.Text = easTypes.SelectedItem.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            maintext.Location = new Point(maintext.Location.X + 1, maintext.Location.Y);
            if(maintext.Location.X >= 780)
            {
                maintext.Location = new Point(-928, 175);
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            if (easTypes.SelectedItem != null && stateDrop.SelectedItem != null && EASSenderTypes.SelectedItem != null)
            {
                maintext.Text = "A(n) " + easTypes.SelectedItem.ToString() + " Was Issued For " + stateDrop.SelectedItem.ToString() + " ";
                Start_Speech.Enabled = true;
            }
            else
                MessageBox.Show("Select EAS Type, State, and Sender");
        }

        private void Start_Speech_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                timer1.Enabled = true;
                simpleSound2.PlaySync();
                //Asynchronously speaks the contents present in RichTextBox1   
                speechSynthesizerObj.Speak(textBox1.Text);
                simpleSound.PlaySync();
            }
            else
            {
                MessageBox.Show("No Text In Text \"Spoken Text\" Box");
            }
        }

        private void EASSenderTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            issuerText.Text = EASSenderTypes.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EAS_Editor editor = new EAS_Editor();
            editor.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Preview.Visible = true;
            label4.Visible = true;
            //Position Change
            //Labels For Dropdowns
            label1.Location = points[0];
            System.Threading.Thread.Sleep(10);
            label3.Location = points[1];
            System.Threading.Thread.Sleep(10);
            label5.Location = points[2];
            System.Threading.Thread.Sleep(10);
            //Dropdowns
            easTypes.Location = points[3];
            System.Threading.Thread.Sleep(10);
            stateDrop.Location = points[4];
            System.Threading.Thread.Sleep(10);
            EASSenderTypes.Location = points[5];
            System.Threading.Thread.Sleep(10);
            //Buttons
            button1.Location = points[6];
            System.Threading.Thread.Sleep(10);
            button2.Location = points[7];
            System.Threading.Thread.Sleep(10);
            button3.Location = points[8];
            System.Threading.Thread.Sleep(10);
            Apply.Location = points[9];
            System.Threading.Thread.Sleep(10);
            Start_Speech.Location = new Point(22, 346);
            System.Threading.Thread.Sleep(10);
            textBox1.Location = new Point(296, 301);
            System.Threading.Thread.Sleep(10);
            label2.Location = new Point(313, 264);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Preview.Visible = false;
            label4.Visible = false;
            //Position Change
            //Labels For Dropdowns
            label1.Location = new Point(12, 14);
            System.Threading.Thread.Sleep(10);
            label3.Location = new Point(12, 152);
            System.Threading.Thread.Sleep(10);
            label5.Location = new Point(12, 282);
            System.Threading.Thread.Sleep(10);
            //Dropdowns
            easTypes.Location = new Point(22, 76);
            System.Threading.Thread.Sleep(10);
            stateDrop.Location = new Point(22, 214);
            System.Threading.Thread.Sleep(10);
            EASSenderTypes.Location = new Point(22, 339);
            System.Threading.Thread.Sleep(10);
            //Buttons
            button1.Location = new Point(1109, 10);
            System.Threading.Thread.Sleep(10);
            button2.Location = new Point(1109, 106);
            System.Threading.Thread.Sleep(10);
            button3.Location = new Point(1360, 106);
            System.Threading.Thread.Sleep(10);
            Apply.Location = new Point(1153, 508);
            System.Threading.Thread.Sleep(10);
            Start_Speech.Location = new Point(1153, 568);
            System.Threading.Thread.Sleep(10);
            textBox1.Location = new Point(628, 301);
            System.Threading.Thread.Sleep(10);
            label2.Location = new Point(645, 264);
        }
    }
}
