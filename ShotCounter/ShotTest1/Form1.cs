using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HockeyEditor;

namespace ShotTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            MemoryEditor.Init(false);
            InitializeComponent();
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        static int ShotCounterR = 0, ShotCounterB = 0;
        static Boolean shot = false;
        static float Posx=0, Posy=0, Posz=0;
        static Boolean wrote = false;
        static List<string> Bshot = new List<string>();
        static List<string> Rshot = new List<string>();
        static string GameTime;
        

        static string Puckonnet()
        {
            float Velx = Puck.Position.X - Posx;
            float Vely = Puck.Position.Y - Posy;
            float Velz = Puck.Position.Z - Posz;
            Posx = Puck.Position.X;
            Posy = Puck.Position.Y;
            Posz = Puck.Position.Z;

            float Time = 0, x = 0, y = 0;
            String ShotOnNet = "false";
            int red = 0;
            if (Velz < 0)
            {
                Time = (4 - Puck.Position.Z) / Velz;
                red = 1; // blue
            }

            if (Velz > 0)
            {
                Time = (57 - Puck.Position.Z) / Velz;
                red = 2; // red
            }


            x = Puck.Position.X + Velx * Time;
            y = Puck.Position.Y + Vely * Time;
            if (x > 13.65 && x < 16.35 && red == 1) // blue
            {
                if (y < .82)
                {
                    ShotOnNet = "true";
                    if (Puck.Position.Z < 10 && Puck.Position.Z > 3.8 && Puck.Position.X < 19 && Puck.Position.X > 11)
                    {
                        if (shot == false && GameInfo.GameTime > 0 && GameInfo.StopTime == 0)
                        {
                            ShotCounterB++;
                            Bshot.Add("Blue Shot " + ShotCounterB + " at " + GameTime + " of period " + GameInfo.Period);
                            shot = true;
                        }
                    }
                }
            }
            else if (x > 13.65 && x < 16.35 && red == 2) // red
            {
                if (y < .82)
                {
                    ShotOnNet = "true";
                    if (Puck.Position.Z > 51 && Puck.Position.Z < 57.2 && Puck.Position.X < 19 && Puck.Position.X > 11)
                    {
                        if (shot == false && GameInfo.GameTime > 0 && GameInfo.StopTime == 0)
                        {
                            ShotCounterR++;
                            Rshot.Add("Red Shot " + ShotCounterR + " at " + GameTime + " of period " + GameInfo.Period);
                            shot = true;
                        }
                    }
                }
            }
            else
            {
                ShotOnNet = "False";
                shot = false;
            }
            
                return ShotOnNet;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PuckPos.Text = "PuckPos: " + (string)Puck.Position.ToString();
            Slope.Text = "Shot On Net: " + Puckonnet();
            Shots.Text = "Blue Shots: " + ShotCounterR;
            Shot2.Text = "Red Shots: " + ShotCounterB;
            GameTime = (GameInfo.GameTime / 6000) + ":" + ((GameInfo.GameTime / 100) % 60);
            Time.Text = "Time: " + GameTime;
            if (GameInfo.Period == 0)
            {
                ShotCounterB = 0;
                ShotCounterR = 0;
                //Bshot = null;
                //Rshot = null;
                wrote = false;
            }
            if (GameInfo.GameOver == 1 && wrote == false)
            {
                Writer write = new Writer();
                write.WriteLine("Red Shots: " + ShotCounterR + " Blue Shots: " + ShotCounterB + Environment.NewLine, false);
                foreach(var item in Rshot)
                {
                    write.WriteLine(item.ToString(), false);
                }
                foreach (var item2 in Bshot)
                {
                    write.WriteLine(item2.ToString(), false);
                }
                wrote = true;
            }
        }




    }
}
