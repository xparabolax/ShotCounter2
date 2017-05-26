using System;
using System.Collections.Generic;
using System.Linq;
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
            InitializeQueue();
            timer1.Start();
        }
        static HQMTeam TeamTouch;
        static Player PlayerTouch;
        static Queue<string> BQueue = new Queue<string>();
        static Queue<string> RQueue = new Queue<string>();
        static List<string> SecondA = new List<string>();
        static List<string> RGoalieList = new List<string>();
        static List<string> BGoalieList = new List<string>();
        static int QueueSize = 3;
        static Boolean GShot = false;
        static int RSave = 0, BSave = 0;

        static void InitializeQueue()
        {
                QueueAdd(RQueue, "");
                QueueAdd(RQueue, "");
                QueueAdd(RQueue, "");
                QueueAdd(BQueue, "");
                QueueAdd(BQueue, "");
                QueueAdd(BQueue, "");
        }

        static Queue<string> QueueAdd(Queue<string> score, string item)
        {
            if (score.Count == QueueSize)
            {
                score.Dequeue();
                score.Enqueue(item);
            }
            else if(score.Count < QueueSize)
            {
                score.Enqueue(item);
            }
            return score;
        }

        void GoalieTouchPuck()
        {
            if (shot == true && GameInfo.StopTime == 0)
            {
                GShot = true;
            }
            
            foreach (Player p in PlayerManager.Players)
            {
                if (p.Team == HQMTeam.Blue && Puck.Position.Z < 21.5)
                {
                    if (shot == false && GShot == true && GameInfo.StopTime == 0) //goalie has made a save
                    {
                        if (PlayerTouch.Name == p.Name) //BlueGoalie check to see if he touched puck
                        {
                            BSave++;
                            ShotCounterB++;
                            BGoalieList.Add("Blue Player: " + p.Name + " / Save number: " + BSave + " / at: " + GameTime + " of period " + GameInfo.Period);
                            GShot = false;
                            System.IO.File.WriteAllText(@"red.txt", string.Empty);
                            System.IO.File.WriteAllText(@"red.txt", ShotCounterB.ToString());
                        }
                    }
                }
                if (p.Team == HQMTeam.Red && Puck.Position.Z > 39)
                {
                    if (shot == false && GShot == true && GameInfo.StopTime == 0) //goalie has made a save
                    {
                        if (PlayerTouch.Name == p.Name) //RedGoalie check to see if he touched puck
                        {
                            RSave++;
                            ShotCounterR++;
                            RGoalieList.Add("Red Player: " + p.Name + " / Save number: " + RSave + " / at: " + GameTime + " of period " + GameInfo.Period);
                            GShot = false;
                            System.IO.File.WriteAllText(@"blue.txt", string.Empty);
                            System.IO.File.WriteAllText(@"blue.txt", ShotCounterR.ToString());
                        }
                    }
                }
            }
        }

        void TeamTouchedPuck()
        {
            foreach (Player p in PlayerManager.Players)
            {
                if ((p.StickPosition - Puck.Position).Magnitude < 0.25f)
                {
                    TeamTouch = p.Team;
                    PlayerTouch = p;
                    if (TeamTouch == HQMTeam.Blue && p.Name != BQueue.ElementAt(2))
                    {
                        if (GameInfo.GameTime > 0 && GameInfo.StopTime == 0)
                        {
                            BQueue = QueueAdd(BQueue, p.Name);
                        }
                        
                    }
                    if (TeamTouch == HQMTeam.Red && p.Name != RQueue.ElementAt(2))
                    {
                        if (GameInfo.GameTime > 0 && GameInfo.StopTime == 0)
                        {
                            RQueue = QueueAdd(RQueue, p.Name);
                        }
                       
                    }
                }
            }
        }

        static int ShotCounterR = 0, ShotCounterB = 0;
        static Boolean shot = false;
        static Boolean wrote = false;
        static Boolean assist = false;
        static float Posx=0, Posy=0, Posz=0;
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
                Time = (4.15f - Puck.Position.Z) / Velz;
                red = 1; // blue
            }

            if (Velz > 0)
            {
                Time = (56.85f - Puck.Position.Z) / Velz;
                red = 2; // red
            }


            x = Puck.Position.X + Velx * Time;
            y = Puck.Position.Y + Vely * Time;
            if (x > 13.75 && x < 16.25 && red == 1) // blue
            {
                if (y < .83)
                {
                    ShotOnNet = "true";
                    if (Puck.Position.Z < 10 && Puck.Position.Z > 3.8 && Puck.Position.X < 19 && Puck.Position.X > 11)
                    {
                        if (shot == false && GameInfo.GameTime > 0 && GameInfo.StopTime == 0)
                        {
                            if (TeamTouch == HQMTeam.Red)
                            {
                                shot = true;
                                Bshot.Add("Red Shot " + ShotCounterB + " / by " + PlayerTouch.Name + " / at " + GameTime + " of period " + GameInfo.Period);
                            }
                        }
                    }
                }
            }
            else if (x > 13.75 && x < 16.25 && red == 2) // red
            {
                if (y < .83)
                {
                    ShotOnNet = "true";
                    if (Puck.Position.Z > 51 && Puck.Position.Z < 57.2 && Puck.Position.X < 19 && Puck.Position.X > 11)
                    {
                        if (shot == false && GameInfo.GameTime > 0 && GameInfo.StopTime == 0)
                        {
                            if (TeamTouch == HQMTeam.Blue)
                            {
                                shot = true;
                                Rshot.Add("Blue Shot " + ShotCounterR + " / by " + PlayerTouch.Name + " / at " + GameTime + " of period " + GameInfo.Period);
                            }
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
            TeamTouchedPuck();
            GoalieTouchPuck();
            GameTime = (GameInfo.GameTime / 6000) + ":" + ((GameInfo.GameTime / 100) % 60).ToString("00");
            Time.Text = "Time: " + GameTime;
            RedS.Text = "Red Saves: " + RSave;
            BlueS.Text = "Blue Saves: " + BSave;
            
            
            if (GameInfo.StopTime > 0 && assist == false)
                    
            {
                if (Puck.Position.Z < 4) //scored on blue net
                {
                    SecondA.Add("Red Goal: " + RQueue.ElementAt(2) + " / Primary Assist: " + RQueue.ElementAt(1) + " / Secondary Assist: " + RQueue.ElementAt(0));
                    if (TeamTouch == HQMTeam.Red)
                    {
                        ShotCounterB++;
                        System.IO.File.WriteAllText(@"red.txt", string.Empty);
                        System.IO.File.WriteAllText(@"red.txt", ShotCounterB.ToString());
                    }
                }
                if (Puck.Position.Z > 57) //scored on red net
                {
                    SecondA.Add("Blue Goal: " + BQueue.ElementAt(2) + " / Primary Assist: " + BQueue.ElementAt(1) + " / Secondary Assist: " + BQueue.ElementAt(0));
                    if (TeamTouch == HQMTeam.Blue)
                    {
                        ShotCounterR++;
                        System.IO.File.WriteAllText(@"blue.txt", string.Empty);
                        System.IO.File.WriteAllText(@"blue.txt", ShotCounterR.ToString());
                    }
                }
                GShot = false;
                InitializeQueue();
                assist = true;
            }

            if (GameInfo.StopTime == 0)
            {
                assist = false;
            }

            if (GameInfo.Period == 0)
            {
                System.IO.File.WriteAllText(@"red.txt", "0");
                System.IO.File.WriteAllText(@"blue.txt", "0");
                ShotCounterB = 0;
                ShotCounterR = 0;
                Bshot.Clear();
                Rshot.Clear();
                InitializeQueue();
                SecondA.Clear();
                RGoalieList.Clear();
                BGoalieList.Clear();
                RSave = 0;
                BSave = 0;
                wrote = false;
            }

            TeamLT.Text = "Red Last Touch: " + RQueue.ElementAt(2) + " / " + RQueue.ElementAt(1) + " / " + RQueue.ElementAt(0);
            PersonLT.Text = "Blue Last Touch: " + BQueue.ElementAt(2) + " / " + BQueue.ElementAt(1) + " / " + BQueue.ElementAt(0);

            if (GameInfo.GameOver == 1 && wrote == false)
            {
                Writer write = new Writer();
                write.WriteLine("Red Shots: " + ShotCounterB + " Blue Shots: " + ShotCounterR + Environment.NewLine, false);
                foreach (var item in Rshot)
                {
                    write.WriteLine(item.ToString(), false);
                }
                foreach (var item2 in Bshot)
                {
                    write.WriteLine(item2.ToString(), false);
                }
                write.WriteLine("", false);
                foreach (var item3 in SecondA)
                {
                    write.WriteLine(item3.ToString(), false);
                }
                write.WriteLine("", false);
                foreach (var item4 in BGoalieList)
                {
                    write.WriteLine(item4.ToString(), false);
                }
                foreach (var item5 in RGoalieList)
                {
                    write.WriteLine(item5.ToString(), false);
                }
                write.WriteLine("Red Saves: " + RSave);
                write.WriteLine("Blue Saves: " + BSave);
                wrote = true;
            }
        }
    }
}
