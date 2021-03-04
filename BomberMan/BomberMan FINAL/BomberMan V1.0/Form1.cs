using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
/*
 * TOOOOO DOOOOO 
 * 
 * Kick* Not Enought TIme (SWITCHED TO RNG IN GAME)
 * Stop on bombs (NOT AS SMOOTH OR THE WAY I WOULD LIKE IT TO BE, BUT IT WORKS)
 * Throw* Not Enough Time
*/

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //Pictures 
        Image bombers = Properties.Resources.bomberman;
        Image normalBomb = Properties.Resources.bomb;
        Image powerUpBomb = Properties.Resources.pBomb;
        Image powerpowerUpBomb = Properties.Resources.ppBomb;
        Image brickBreak = Properties.Resources._break;
        Image npBreakBrick = Properties.Resources.unbreak;
        Image PowerUp = Properties.Resources.pp;
        Image Explosion = Properties.Resources.explosion;
        Image FloorG = Properties.Resources.floorG;

        //Colours Used
        SolidBrush t = new SolidBrush(Color.FromArgb(100, 0, 0, 255));
        SolidBrush fader;
        SolidBrush Indigo;
        SolidBrush dO, dOO, mSel, inmSel;
        List<SolidBrush> optButt = new List<SolidBrush>();
        List<SolidBrush> optButtCon = new List<SolidBrush>();
        SolidBrush dim, fad, on, off;
        SolidBrush bla, blu, pin, tea, gre, ora, red, whi;
        List<SolidBrush> plColor = new List<SolidBrush>();
        SolidBrush rColor, team1, team2;
        SolidBrush[] color = new SolidBrush[15];       

        //Powerups
        List<Rectangle> power = new List<Rectangle>();
        List<int> pR = new List<int>();
        List<int> pC = new List<int>();
        List<int> pTemp = new List<int>();
        int pW, pH, pTR, pTC, ppTemp, y;
        List<bool> powerVis = new List<bool>();
        List<bool> plRng = new List<bool>();
        int skull= -1, puSpawnRate = 2;

        //map
        List<Rectangle> brickNB = new List<Rectangle>();
        List<Rectangle> brickB = new List<Rectangle>();
        List<Rectangle> Floor = new List<Rectangle>();
        List<int> brR = new List<int>();
        List<int> brCou = new List<int>();
        List<int> brX = new List<int>();
        List<int> brY = new List<int>();
        List<int> brbX = new List<int>();
        List<int> brbY = new List<int>();
        List<int> flX = new List<int>();
        List<int> flY = new List<int>();
        int brC, brTC, brTR, brW, brH;
        int size = 19, row = 0;
        int bTemp = 0, brCount, brbCount, fCount;
        List<bool> breaker = new List<bool>();
        int removed;
        List<int> nbCount = new List<int>();
        int nbCoTemp, nbCTemp;
        Bitmap bricky;

        //Bombs
        List<Rectangle> bomb = new List<Rectangle>();
        List<int> boC = new List<int>();
        List<int> boR = new List<int>();
        List<int> boCou = new List<int>();
        List<int> boX = new List<int>();
        List<int> boY = new List<int>();
        int boTC, boW, boH;
        int xTemp, yTemp, xPosB, yPosB;
        int eTemp, rTemp, posXTemp, posYTemp;
        List<bool> puB = new List<bool>();
        List<bool> puBB = new List<bool>();
        List<bool> puE = new List<bool>();
        List<bool> puEE = new List<bool>();

        //Explosion
        List<Rectangle> exp = new List<Rectangle>();
        List<int> expR = new List<int>();
        List<int> expCou = new List<int>();
        List<int> expX = new List<int>();
        List<int> expY = new List<int>();
        List<int> expC = new List<int>();
        List<int> expRecCou = new List<int>();
        int expTC, expTR, expW, expH;
        List<int> eSize = new List<int>();
        bool stU, stD, stL, stR;        

        //Info Models (inGame)
        List<Rectangle> playerBG = new List<Rectangle>();        
        List<Rectangle> pu = new List<Rectangle>();
        List<Rectangle> fademark = new List<Rectangle>();
        List<int> puR = new List<int>();
        List<int> puC = new List<int>();        
        int faderInt;

        //Bombermen
        List<Rectangle> Players = new List<Rectangle>();
        List<Rectangle> plHB = new List<Rectangle>();
        List<int> plR = new List<int>();
        List<int> plCou = new List<int>();
        List<int> plX = new List<int>();
        List<int> plY = new List<int>();
        List<int> plC = new List<int>();
        List<int> plSpRun = new List<int>();
        List<bool> plSp = new List<bool>();
        List<bool> plSpR = new List<bool>();
        int plSss = 12;
        int plTR, plTC;
        int plW = 30, plH = 30;
        List<bool> plUp = new List<bool>();
        List<bool> plDown = new List<bool>();
        List<bool> plLeft = new List<bool>();
        List<bool> plRight = new List<bool>();
        List<bool> plDead = new List<bool>();
        List<bool> plDeath = new List<bool>();
        List<int> plMoveSpeed = new List<int>();
        List<int> plRow = new List<int>();
        List<int> plCol = new List<int>();
        List<int> plRowT = new List<int>();
        List<int> plColT = new List<int>();
        List<int> plBoCou = new List<int>();
        List<Point> plSpawn = new List<Point>();
        List<int> colTemp = new List<int>();
        List<Rectangle> plSur = new List<Rectangle>();

        //Menu Variables
        bool gameOnOff = false, dOai;
        bool pAb = false;
        int plNum = 2, dOa = 0, dOOa = 255, mSlp = 51, xTitle = 125, menTim, mPos = -1;
        PrivateFontCollection pfd = new PrivateFontCollection();
        Image bg = Properties.Resources.bbg;
        Image oBg = Properties.Resources.sm;
        List<Rectangle> menPos = new List<Rectangle>();
        List<Rectangle> ingMen = new List<Rectangle>();
        bool inGameMenu, rdnSpawn = false, rdnCol = false;
        Point[] pl1 = new Point[4];
        Point[] pl2 = new Point[4];
        Point[] pl3 = new Point[4];
        Point[] pl4 = new Point[4];
        Point[] wpl1 = new Point[4];
        Point[] wpl2 = new Point[4];
        Point[] wpl3 = new Point[4];
        Point[] wpl4 = new Point[4];
        Rectangle back;
        bool baOn;
        List<Rectangle> optCol = new List<Rectangle>();
        List<int> plWins = new List<int>();
        int winsNeeded = 1, resettmr, winner;
        bool endTmr, won;
        List<Rectangle> optBut = new List<Rectangle>();       
        List<Rectangle> optButCon = new List<Rectangle>();

        //RNG/Skull VARIABLES
        int rndnum, mscTmr;
        int skPl = -1, spTemp, boTemp, skTime;
        Random rdn = new Random();

        //Circle Thing For Transitions
        int cX, cY, cW, cH, cc = 25;        
        bool restart, other, trans, grow, shrink, options, controls, inGame;
        bool cOn, oOn, music;       

        //Fireworks
        Rectangle[] up = new Rectangle[15];
        Rectangle[,] particle = new Rectangle[15, 40];
        int[] FWexp = new int[15];
        int[,] xVel = new int[15, 40];
        int[,] yVel = new int[15, 40];       
        int[] FWsize = new int[15];
        bool[] ep = new bool[15];
        int[] lo = new int[15];    
    
        //TEAMS
        bool teams;
        bool team12, team13, team14; 

        //Music
        WMPLib.WindowsMediaPlayer wpB1 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer wpB2 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer wpB3 = new WMPLib.WindowsMediaPlayer();
        int bWP = 1, lWP = 1;
        WMPLib.WindowsMediaPlayer wpL1 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer wpL2 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer wpL3 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer wp = new WMPLib.WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();

           

            //Start off music
            //A fewe other areas where the name will have to be changed to follow what your comp has
            //THERE IS MUSIC JUST CODE NEEDS TO BE CHANGED SO IT MATCHES LOCATION
            wp.settings.volume = 50;            
            wp.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Menu.mp3";

            //Colour Startoff
            dim = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
            fad = new SolidBrush(Color.FromArgb(175, 0, 0, 0));
            on = new SolidBrush(Color.Green);
            off = new SolidBrush(Color.Maroon);
            bla = new SolidBrush(Color.Gray);
            blu = new SolidBrush(Color.Blue);
            whi = new SolidBrush(Color.White);
            gre = new SolidBrush(Color.LimeGreen);
            red = new SolidBrush(Color.Red);
            ora = new SolidBrush(Color.Goldenrod);
            tea = new SolidBrush(Color.Aquamarine);
            pin = new SolidBrush(Color.Fuchsia);
            plColor.Add(new SolidBrush(Color.White));
            plColor.Add(new SolidBrush(Color.White));
            plColor.Add(new SolidBrush(Color.White));
            plColor.Add(new SolidBrush(Color.White));  
            dO = new SolidBrush(Color.FromArgb(dOa,255, 140, 0));
            dOO = new SolidBrush(Color.FromArgb(dOOa, 255, 255, 255));
            mSel = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
            inmSel = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
            Indigo = new SolidBrush(Color.FromArgb(75, 0, 130, 200));
            faderInt = 150;
            fader = new SolidBrush(Color.FromArgb(faderInt, 255, 255, 255));
            team1 = new SolidBrush(Color.Red);
            team2 = new SolidBrush(Color.Blue);

            colTemp.Add(0);
            colTemp.Add(1);
            colTemp.Add(2);
            colTemp.Add(3);
            colTemp.Add(4);
            colTemp.Add(5);
            colTemp.Add(6);
            colTemp.Add(7);

            //Custom Font             
            //Go into the Reseources and use the @ at the top of the finder, for me I normally had C:\Users\"NAME"|Desktop\BomberMan....\Digital-Desolation.ttf"
            pfd.AddFontFile(@"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Digital-Desolation.ttf");        

            //Player Stuff           
            plTC = 8;
            plTR = 20;
            bombers = new Bitmap(bombers, new Size(plTC * plW, plTR * plH));
            plWins.Add(0);
            plWins.Add(0);
            plWins.Add(0);
            plWins.Add(0);
            plR.Add(0);
            plC.Add(0);
            plX.Add(105 + 16 * 30);
            plY.Add(105 + 16 * 30);
            plCou.Add(0);
            Players.Add(new Rectangle(plX[0], plY[0], plW, plH));
            plUp.Add(false);
            plLeft.Add(false);
            plRight.Add(false);
            plDown.Add(false);
            plDead.Add(false);
            plSp.Add(false);
            plSpRun.Add(0);
            plMoveSpeed.Add(2);
            plSpR.Add(false);
            plCol.Add(1);
            plRow.Add(1);
            plColT.Add(1);
            plRowT.Add(1);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);   
            plHB.Add(new Rectangle(plX[0] + 5, plY[0] + 5 , 20, 20));
            plR.Add(0);
            plC.Add(1);
            plX.Add(105);
            plY.Add(105);
            plCou.Add(0);
            Players.Add(new Rectangle(plX[1], plY[1], plW, plH));
            plUp.Add(false);
            plLeft.Add(false);
            plRight.Add(false);
            plDown.Add(false);
            plDead.Add(false);
            plSp.Add(false);
            plSpRun.Add(0);
            plMoveSpeed.Add(2);
            plSpR.Add(false);
            plCol.Add(18);
            plRow.Add(18);
            plColT.Add(18);
            plRowT.Add(18);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[1] + 5, plY[1] + 5 , 20, 20));
            plR.Add(0);
            plC.Add(2);
            plX.Add(105);
            plY.Add(105 + 16 * 30);
            plCou.Add(0);
            Players.Add(new Rectangle(plX[2], plY[2], plW, plH));
            plUp.Add(false);
            plLeft.Add(false);
            plRight.Add(false);
            plDown.Add(false);
            plDead.Add(false);
            plSp.Add(false);
            plSpRun.Add(0);
            plMoveSpeed.Add(2);
            plSpR.Add(false);
            plCol.Add(1);
            plRow.Add(1);
            plColT.Add(1);
            plRowT.Add(1);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[2] + 5, plY[2] + 5, 20, 20));
            plR.Add(0);
            plC.Add(3);
            plX.Add(105 + 16 * 30);
            plY.Add(105);
            plCou.Add(0);
            Players.Add(new Rectangle(plX[3], plY[3], plW, plH));
            plUp.Add(false);
            plLeft.Add(false);
            plRight.Add(false);
            plDown.Add(false);
            plDead.Add(false);
            plSp.Add(false);
            plSpRun.Add(0);
            plMoveSpeed.Add(2);
            plSpR.Add(false);
            plCol.Add(1);
            plRow.Add(1);
            plColT.Add(1);
            plRowT.Add(1);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[3] + 5, plY[3] + 5, 20, 20));
            plSpawn.Add(new Point(plX[0], plY[0]));
            plSpawn.Add(new Point(plX[1], plY[1]));
            plSpawn.Add(new Point(plX[2], plY[2]));
            plSpawn.Add(new Point(plX[3], plY[3]));
            plSur.Add(new Rectangle(plX[0] - 5, plY[0] - 5, 40, 40));
            plSur.Add(new Rectangle(plX[1] - 5, plY[1] - 5, 40, 40));
            plSur.Add(new Rectangle(plX[2] - 5, plY[2] - 5, 40, 40));
            plSur.Add(new Rectangle(plX[3] - 5, plY[3] - 5, 40, 40));
            puBB.Add(false);
            puBB.Add(false);
            puBB.Add(false);
            puBB.Add(false);
            puB.Add(false);
            puB.Add(false);
            puB.Add(false);
            puB.Add(false);
            eSize.Add(1);
            eSize.Add(1);
            eSize.Add(1);
            eSize.Add(1);
            
            //Map Stuff
            for (int n = 0; n < 72; n++ ) 
            {                
                nbCount.Add(nbCTemp);
                nbCoTemp += 1;
                nbCTemp += 1;
                if (nbCoTemp == 22 && nbCount.Count < 53)
                {
                    nbCTemp += 8;
                    nbCoTemp -= 4;
                }
            }
            brC = 0;
            brTC = 1;
            brTR = 3;
            brW = 30;
            brH = 30;
            brickBreak = new Bitmap(brickBreak, new Size(30 * brTC, 30 * brTR));
            for (int n = 0; n < size; n++)
            {

                bTemp = 0;
                BuildBrick();
                row += 1;
            }
            brX.Shuffle();
            brY.Shuffle();


            for (int n = 0; n < brickB.Count; n++)
            {
                brickB[n] = new Rectangle(brX[n], brY[n], brW, brH);
            }
            removed = rdn.Next(15, 32);
            for (int n = 0; n < removed; n++)
            {
                brickB.RemoveAt(0);
                brX.RemoveAt(0);
                brY.RemoveAt(0);
                brR.RemoveAt(0);
                brCount -= 1;
            }
            for (int n = 0; n < brickB.Count; n++)
            {
                brickB[n] = new Rectangle(brX[n], brY[n], brW, brH);
                breaker.Add(false);
                brCou.Add(0);
            }            
            
            //Explosion Stuff 
            expTR = 4;
            expTC = 7;
            Explosion = new Bitmap(Explosion, new Size(30 * expTC, 30 * expTR));
            expW = 30;
            expH = 30;
            
            //Bomb Stuff
             boTC = 11;
            boW = 16;
            boH = 16;         

            //Powerup Stuff
            pTR = 2;
            pTC = 4;
            PowerUp = new Bitmap(PowerUp, new Size(26 * pTC, 26 * pTR));
            pW = PowerUp.Width / pTC;
            pH = PowerUp.Height / pTR;
            
            //Form Stuff        
            this.Height = 185 + row * brH;
            this.Width = 175 + row * brW;
            MaximumSize = new Size(this.Width, this.Height);
            MinimumSize = new Size(this.Width, this.Height);

            //Menu Stuff
            menPos.Add(new Rectangle(xTitle - 5, this.Height - 80, 78, 28));
            menPos.Add(new Rectangle(xTitle + 95, this.Height - 80, 113, 28));
            menPos.Add(new Rectangle(xTitle + 230, this.Height - 80, 143, 28));
            menPos.Add(new Rectangle(xTitle + 390, this.Height - 80, 68, 28));
            ingMen.Add(new Rectangle(this.Width / 2 - 70, this.Height / 2 - 95, 118, 40));
            ingMen.Add(new Rectangle(this.Width / 2 - 78, this.Height / 2 - 35, 134, 40));
            ingMen.Add(new Rectangle(this.Width / 2 - 83, this.Height / 2 + 25, 144, 40));
            pl1[0] = new Point(-50, 40);
            pl1[1] = new Point(200, 40);
            pl1[2] = new Point(215, 80);
            pl1[3] = new Point(-50, 80);
            pl2[0] = new Point(this.Width, 40);
            pl2[1] = new Point(this.Width - 230, 40);
            pl2[2] = new Point(this.Width - 255, 80);
            pl2[3] = new Point(this.Width, 80);
            pl3[0] = new Point(-50, 340);
            pl3[1] = new Point(200, 340);
            pl3[2] = new Point(215, 380);
            pl3[3] = new Point(-50, 380);
            pl4[0] = new Point(this.Width, 340);
            pl4[1] = new Point(this.Width - 230, 340);
            pl4[2] = new Point(this.Width - 255, 380);
            pl4[3] = new Point(this.Width, 380);
            wpl1[0] = new Point(-50, 30);
            wpl1[1] = new Point(210, 30);
            wpl1[2] = new Point(235, 90);
            wpl1[3] = new Point(-50, 90);
            wpl2[0] = new Point(this.Width, 30);
            wpl2[1] = new Point(this.Width - 240, 30);
            wpl2[2] = new Point(this.Width - 280, 90);
            wpl2[3] = new Point(this.Width, 90);
            wpl3[0] = new Point(-50, 330);
            wpl3[1] = new Point(210, 330);
            wpl3[2] = new Point(235, 390);
            wpl3[3] = new Point(-50, 390);
            wpl4[0] = new Point(this.Width, 330);
            wpl4[1] = new Point(this.Width - 240, 330);
            wpl4[2] = new Point(this.Width - 280, 390);
            wpl4[3] = new Point(this.Width, 390);
            back = new Rectangle(this.Width / 2 - 120, this.Height - 140, 215, 50);
            optCol.Add(new Rectangle(100, 400, 50, 50));
            optCol.Add(new Rectangle(250, 400, 50, 50));
            optCol.Add(new Rectangle(400, 400, 50, 50));
            optCol.Add(new Rectangle(550, 400, 50, 50));
            //P1 COlOR OPT
            optBut.Add(new Rectangle(70, 490, 20, 20));
            optBut.Add(new Rectangle(100, 490, 20, 20));
            optBut.Add(new Rectangle(130, 490, 20, 20));
            optBut.Add(new Rectangle(160, 490, 20, 20));
            optBut.Add(new Rectangle(70, 520, 20, 20));
            optBut.Add(new Rectangle(100, 520, 20, 20));
            optBut.Add(new Rectangle(130, 520, 20, 20));
            optBut.Add(new Rectangle(160, 520, 20, 20));
            optButt.Add(whi);
            optButt.Add(bla);
            optButt.Add(red);
            optButt.Add(ora);
            optButt.Add(gre);
            optButt.Add(tea);
            optButt.Add(blu);
            optButt.Add(pin);
            //P2 Color OPT
            optBut.Add(new Rectangle(220, 490, 20, 20));
            optBut.Add(new Rectangle(250, 490, 20, 20));
            optBut.Add(new Rectangle(280, 490, 20, 20));
            optBut.Add(new Rectangle(310, 490, 20, 20));
            optBut.Add(new Rectangle(220, 520, 20, 20));
            optBut.Add(new Rectangle(250, 520, 20, 20));
            optBut.Add(new Rectangle(280, 520, 20, 20));
            optBut.Add(new Rectangle(310, 520, 20, 20));
            optButt.Add(whi);
            optButt.Add(bla);
            optButt.Add(red);
            optButt.Add(ora);
            optButt.Add(gre);
            optButt.Add(tea);
            optButt.Add(blu);
            optButt.Add(pin);
            //P3 Color OPT
            optBut.Add(new Rectangle(370, 490, 20, 20));
            optBut.Add(new Rectangle(400, 490, 20, 20));
            optBut.Add(new Rectangle(430, 490, 20, 20));
            optBut.Add(new Rectangle(460, 490, 20, 20));
            optBut.Add(new Rectangle(370, 520, 20, 20));
            optBut.Add(new Rectangle(400, 520, 20, 20));
            optBut.Add(new Rectangle(430, 520, 20, 20));
            optBut.Add(new Rectangle(460, 520, 20, 20));
            optButt.Add(whi);
            optButt.Add(bla);
            optButt.Add(red);
            optButt.Add(ora);
            optButt.Add(gre);
            optButt.Add(tea);
            optButt.Add(blu);
            optButt.Add(pin);
            //P3 Color OPT
            optBut.Add(new Rectangle(520, 490, 20, 20));
            optBut.Add(new Rectangle(550, 490, 20, 20));
            optBut.Add(new Rectangle(580, 490, 20, 20));
            optBut.Add(new Rectangle(610, 490, 20, 20));
            optBut.Add(new Rectangle(520, 520, 20, 20));
            optBut.Add(new Rectangle(550, 520, 20, 20));
            optBut.Add(new Rectangle(580, 520, 20, 20));
            optBut.Add(new Rectangle(610, 520, 20, 20));
            optButt.Add(whi);
            optButt.Add(bla);
            optButt.Add(red);
            optButt.Add(ora);
            optButt.Add(gre);
            optButt.Add(tea);
            optButt.Add(blu);
            optButt.Add(pin);
            //Option Control BTNS
            optButCon.Add(new Rectangle(70, 95, 100, 50));
            optButCon.Add(new Rectangle(230, 95, 100, 50));
            optButCon.Add(new Rectangle(390, 95, 100, 50));
            optButCon.Add(new Rectangle(550, 95, 100, 50));
            optButCon.Add(new Rectangle(230, 175, 260, 50));
            optButCon.Add(new Rectangle(70, 175, 100, 50));
            optButCon.Add(new Rectangle(550, 175, 100, 50));
            optButCon.Add(new Rectangle(230, 255, 260, 50));
            optButCon.Add(new Rectangle(70, 255, 100, 50));
            optButCon.Add(new Rectangle(550, 255, 100, 50));
            optButtCon.Add(off);
            optButtCon.Add(off);
            optButtCon.Add(off);
            optButtCon.Add(off);
            optButtCon.Add(new SolidBrush(Color.Black));
            optButtCon.Add(off);
            optButtCon.Add(on);
            optButtCon.Add(new SolidBrush(Color.Black));
            optButtCon.Add(off);
            optButtCon.Add(on);

            //In Game ICON Stuff               
            playerBG.Add(new Rectangle(10, 10, 45, 45));
            playerBG.Add(new Rectangle(10, 95 + row * brW, 45, 45));
            playerBG.Add(new Rectangle(105 + row * brH, 10, 45, 45));
            playerBG.Add(new Rectangle(105 + row * brH, 95 + row * brW, 45, 45));
            pu.Add(new Rectangle(playerBG[0].X + 50, playerBG[0].Y, 20, 20));
            puC.Add(0);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[0].X + 75, playerBG[0].Y, 20, 20));
            puC.Add(1);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[0].X + 50, playerBG[0].Y + 25, 20, 20));
            puC.Add(2);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[0].X + 75, playerBG[0].Y + 25, 20, 20));
            puC.Add(3);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[0].X, playerBG[0].Y + 50, 20, 20));
            puC.Add(0);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[0].X, playerBG[0].Y + 75, 20, 20));
            puC.Add(1);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[0].X + 25, playerBG[0].Y + 50, 20, 20));
            puC.Add(2);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[0].X + 25, playerBG[0].Y + 75, 20, 20));
            puC.Add(3);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[1].X + 50, playerBG[1].Y, 20, 20));
            puC.Add(0);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[1].X + 75, playerBG[1].Y, 20, 20));
            puC.Add(1);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[1].X + 50, playerBG[1].Y + 25, 20, 20));
            puC.Add(2);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[1].X + 75, playerBG[1].Y + 25, 20, 20));
            puC.Add(3);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[1].X, playerBG[1].Y - 25, 20, 20));
            puC.Add(0);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[1].X, playerBG[1].Y - 50, 20, 20));
            puC.Add(1);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[1].X + 25, playerBG[1].Y - 25, 20, 20));
            puC.Add(2);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[1].X + 25, playerBG[1].Y - 50, 20, 20));
            puC.Add(3);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[2].X - 25, playerBG[2].Y, 20, 20));
            puC.Add(0);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[2].X - 50, playerBG[2].Y, 20, 20));
            puC.Add(1);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[2].X - 25, playerBG[2].Y + 25, 20, 20));
            puC.Add(2);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[2].X - 50, playerBG[2].Y + 25, 20, 20));
            puC.Add(3);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[2].X, playerBG[2].Y + 50, 20, 20));
            puC.Add(0);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[2].X, playerBG[2].Y + 75, 20, 20));
            puC.Add(1);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[2].X + 25, playerBG[2].Y + 50, 20, 20));
            puC.Add(2);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[2].X + 25, playerBG[2].Y + 75, 20, 20));
            puC.Add(3);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[3].X - 25, playerBG[3].Y, 20, 20));
            puC.Add(0);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[3].X - 50, playerBG[3].Y, 20, 20));
            puC.Add(1);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[3].X - 25, playerBG[3].Y + 25, 20, 20));
            puC.Add(2);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[3].X - 50, playerBG[3].Y + 25, 20, 20));
            puC.Add(3);
            puR.Add(0);
            pu.Add(new Rectangle(playerBG[3].X, playerBG[3].Y - 25, 20, 20));
            puC.Add(0);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[3].X, playerBG[3].Y - 50, 20, 20));
            puC.Add(1);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[3].X + 25, playerBG[3].Y - 25, 20, 20));
            puC.Add(2);
            puR.Add(1);
            pu.Add(new Rectangle(playerBG[3].X + 25, playerBG[3].Y - 50, 20, 20));
            puC.Add(3);
            puR.Add(1);
            fademark.Add(new Rectangle(playerBG[0].X + 50, playerBG[0].Y, 20, 20));
            fademark.Add(new Rectangle(playerBG[0].X + 75, playerBG[0].Y, 20, 20));
            fademark.Add(new Rectangle(playerBG[0].X + 50, playerBG[0].Y + 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[0].X + 75, playerBG[0].Y + 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[0].X, playerBG[0].Y + 50, 20, 20));
            fademark.Add(new Rectangle(playerBG[0].X, playerBG[0].Y + 75, 20, 20));
            fademark.Add(new Rectangle(playerBG[0].X + 25, playerBG[0].Y + 50, 20, 20));
            fademark.Add(new Rectangle(playerBG[0].X + 25, playerBG[0].Y + 75, 20, 20));
            fademark.Add(new Rectangle(playerBG[1].X + 50, playerBG[1].Y, 20, 20));
            fademark.Add(new Rectangle(playerBG[1].X + 75, playerBG[1].Y, 20, 20));
            fademark.Add(new Rectangle(playerBG[1].X + 50, playerBG[1].Y + 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[1].X + 75, playerBG[1].Y + 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[1].X, playerBG[1].Y - 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[1].X, playerBG[1].Y - 50, 20, 20));
            fademark.Add(new Rectangle(playerBG[1].X + 25, playerBG[1].Y - 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[1].X + 25, playerBG[1].Y - 50, 20, 20));
            fademark.Add(new Rectangle(playerBG[2].X - 25, playerBG[2].Y, 20, 20));
            fademark.Add(new Rectangle(playerBG[2].X - 50, playerBG[2].Y, 20, 20));
            fademark.Add(new Rectangle(playerBG[2].X - 25, playerBG[2].Y + 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[2].X - 50, playerBG[2].Y + 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[2].X, playerBG[2].Y + 50, 20, 20));
            fademark.Add(new Rectangle(playerBG[2].X, playerBG[2].Y + 75, 20, 20));
            fademark.Add(new Rectangle(playerBG[2].X + 25, playerBG[2].Y + 50, 20, 20));
            fademark.Add(new Rectangle(playerBG[2].X + 25, playerBG[2].Y + 75, 20, 20));
            fademark.Add(new Rectangle(playerBG[3].X - 25, playerBG[3].Y, 20, 20));
            fademark.Add(new Rectangle(playerBG[3].X - 50, playerBG[3].Y, 20, 20));
            fademark.Add(new Rectangle(playerBG[3].X - 25, playerBG[3].Y + 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[3].X - 50, playerBG[3].Y + 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[3].X, playerBG[3].Y - 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[3].X, playerBG[3].Y - 50, 20, 20));
            fademark.Add(new Rectangle(playerBG[3].X + 25, playerBG[3].Y - 25, 20, 20));
            fademark.Add(new Rectangle(playerBG[3].X + 25, playerBG[3].Y - 50, 20, 20));

            //Fireworks Stuff        
            for (int i = 0; i < 15; i++)
            {
                FWexp[i] = rdn.Next(0, this.Height - 50);
                up[i].X = rdn.Next(0, this.Width - FWsize[i]);
                up[i].Y = this.Height;

                up[i] = new Rectangle(up[i].X, up[i].Y, FWsize[i], FWsize[i]);

                for (int o = 0; o < 40; o++)
                {
                    particle[i, o] = new Rectangle(particle[i, o].X, particle[i, o].Y, FWsize[i], FWsize[i]);
                    xVel[i, o] = rdn.Next(-10, 10);
                    yVel[i, o] = rdn.Next(-10, 10);
                }
            }
            for (int i = 0; i < 15; i++)
            {
                rColor = new SolidBrush(Color.FromArgb(rdn.Next(256), rdn.Next(256), rdn.Next(256)));
                color[i] = rColor;
            }            

            DrawBackGround();

        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            mscTmr += 1;
            if (gameOnOff == false) 
            {
                if (mscTmr >= 23800)
                {
                    mscTmr = 0;
                    wp.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Menu.mp3";
                }
            }
            else
                if (won == true) 
                {
                    if (mscTmr >= 16700)
                    {
                        mscTmr = 0;
                        wp.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Cantina.mp3";
                    }
                }
                else
                    if (gameOnOff == true) 
                    {
                        if (mscTmr >= 180000)
                        {
                            mscTmr = 0;
                            wp.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Melody.mp3";
                        }
                    }
            //Matches Color To PLayer
            for (int n = 0; n < plColor.Count; n++)
            {
                if (plC[n] == 0) { plColor[n] = whi; }
                else
                    if (plC[n] == 1) { plColor[n] = bla; }
                    else
                        if (plC[n] == 2) { plColor[n] = red; }
                        else
                            if (plC[n] == 3) { plColor[n] = ora; }
                            else
                                if (plC[n] == 4) { plColor[n] = gre; }
                                else
                                    if (plC[n] == 5) { plColor[n] = tea; }
                                    else
                                        if (plC[n] == 6) { plColor[n] = blu; }
                                        else
                                            if (plC[n] == 7) { plColor[n] = pin; }
            }          
            
            //In Game Stuff
            if (gameOnOff == true && inGameMenu == false)
            {
                if (bomb.Count == 0)
                {
                    //Resets Counter for Bombs so it uses right temp values
                    boR.Clear();
                    puE.Clear();
                    puEE.Clear();
                }
                for (int n = 0; n < Players.Count; n++)
                {                   
                    if (plDeath[n] == true)
                    {
                        //Moves dead plaeyrs off screen
                        plX[n] = -500; plY[n] = -500;
                        Players[n] = new Rectangle(plX[n], plY[n], plH, plW);
                    }
                }
                for (int n = 0; n < Players.Count; n++)
                {
                    //Maxs out bomb count per player
                    if (plBoCou[n] > 10) { plBoCou[n] = 10; }
                }                
                for (int n = 0; n < Players.Count; n++)
                {        
                    //Stops players from going over Bombs and Through Walls
                    plCol[n] = (plX[n] - 65) / brW;
                    plRow[n] = (plY[n] - 65) / brH;
                    plColT[n] = (plX[n] - 55) / brW;
                    plRowT[n] = (plY[n] - 55) / brH;
                    for (int q = 0; q < brickB.Count; q++)
                    {
                        if (brickB[q].IntersectsWith(Players[n]))
                        {
                            plX[n] = plCol[n] * 30 + 75;
                            plY[n] = plRow[n] * 30 + 75;
                        }                        
                    }
                    for (int q = 0; q < bomb.Count; q++) 
                    {
                        if (bomb[q].IntersectsWith(Players[n]) && n != boR[q])
                        {
                            plX[n] = plCol[n] * 30 + 75;
                            plY[n] = plRow[n] * 30 + 75;
                        }
                    }
                }
                for (int n = 0; n < plHB.Count; n++)
                {
                    //Hitbox is smaller than character bc Character is the full Square
                    plHB[n] = new Rectangle(plX[n] + 5, plY[n] + 5, 20, 20);
                    for (int q = 0; q < exp.Count; q++)
                    {
                        if (exp[q].IntersectsWith(plHB[n]) && plDead[n] == false)
                        {
                            plDead[n] = true;
                            plR[n] = 12;
                            plCou[n] = 12;
                        }
                    }
                }
                //TO Match Speed to Sprite Sheet Quicknesss and Also only allow movements on proper rows etc
                for (int i = 0; i < Players.Count; i++)
                {
                    if (plDead[i] == false && plDeath[i] == false)
                    {
                        if (plUp[i] == true && plY[i] > 105)
                        {                            
                            plY[i] -= plMoveSpeed[i];
                        }
                        else
                            if (plDown[i] == true && plY[i] < ((row - 2) * brH) + 75)
                            {
                                plY[i] += plMoveSpeed[i];
                            }
                            else
                                if (plLeft[i] == true && plX[i] > 105)
                                {
                                    plX[i] -= plMoveSpeed[i];
                                }
                                else
                                    if (plRight[i] == true && plX[i] < ((row - 2) * brH) + 75)
                                    {
                                        plX[i] += plMoveSpeed[i];
                                    }
                        Players[i] = new Rectangle(plX[i], plY[i], plW, plH);
                        plSpRun[i] += 1;                                           
                        if (plSpRun[i] >= plSss - plMoveSpeed[i])
                        {
                            if (plDead[i] != true && plDeath[i] != true)
                            {
                                if (plUp[i] == true)
                                {
                                    if (plCou[i] == 9 && plSp[i] == false) { plCou[i] = 10; plSp[i] = true; }
                                    else
                                        if (plCou[i] == 10) { plCou[i] = 9; }
                                        else
                                            if (plCou[i] == 9 && plSp[i] == true) { plCou[i] = 11; plSp[i] = false; }
                                            else
                                                if (plCou[i] == 11) { plCou[i] = 9; }

                                    plR[i] = plCou[i] % plTR;
                                    this.Refresh();
                                }
                                if (plDown[i] == true)
                                {
                                    if (plCou[i] == 0 && plSp[i] == false) { plCou[i] = 1; plSp[i] = true; }
                                    else
                                        if (plCou[i] == 1) { plCou[i] = 0; }
                                        else
                                            if (plCou[i] == 0 && plSp[i] == true) { plCou[i] = 2; plSp[i] = false; }
                                            else
                                                if (plCou[i] == 2) { plCou[i] = 0; }

                                    plR[i] = plCou[i] % plTR;
                                    this.Refresh();
                                }
                                if (plLeft[i] == true)
                                {
                                    if (plCou[i] == 6 && plSp[i] == false) { plCou[i] = 7; plSp[i] = true; }
                                    else
                                        if (plCou[i] == 7) { plCou[i] = 6; }
                                        else
                                            if (plCou[i] == 6 && plSp[i] == true) { plCou[i] = 8; plSp[i] = false; }
                                            else
                                                if (plCou[i] == 8) { plCou[i] = 6; }

                                    plR[i] = plCou[i] % plTR;
                                    this.Refresh();
                                }
                                if (plRight[i] == true)
                                {

                                    if (plCou[i] == 3 && plSp[i] == false) { plCou[i] = 4; plSp[i] = true; }
                                    else
                                        if (plCou[i] == 4) { plCou[i] = 3; }
                                        else
                                            if (plCou[i] == 3 && plSp[i] == true) { plCou[i] = 5; plSp[i] = false; }
                                            else
                                                if (plCou[i] == 5) { plCou[i] = 3; }

                                    plR[i] = plCou[i] % plTR;
                                    this.Refresh();
                                }
                                this.Refresh();
                            }
                            plR[i] = plCou[i] % plTR;
                            plSpRun[i] = 0;
                        }
                    }
                }
                //Checks To See for a winner
                if (teams == false)
                {
                    if (plNum == 2 && endTmr == false)
                    {
                        if ((plDeath[0] == false && plDead[0] == false) && (plDeath[1] == true || plDead[1] == true))
                        {
                            winner = 1;
                            plWins[0] += 1;
                            endTmr = true;
                        }
                        else
                            if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == false && plDead[1] == false))
                            {
                                winner = 2;
                                plWins[1] += 1;
                                endTmr = true;
                            }
                            else
                                if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == true || plDead[1] == true))
                                {
                                    winner = 0;
                                    endTmr = true;
                                }
                    }
                    else
                        if (plNum == 3 && endTmr == false)
                        {
                            if ((plDeath[0] == false && plDead[0] == false) && (plDeath[1] == true || plDead[1] == true) && (plDeath[2] == true || plDead[2] == true))
                            {
                                winner = 1;
                                plWins[0] += 1;
                                endTmr = true;
                            }
                            else
                                if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == false && plDead[1] == false) && (plDeath[2] == true || plDead[2] == true))
                                {
                                    winner = 2;
                                    plWins[1] += 1;
                                    endTmr = true;
                                }
                                else
                                    if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == true || plDead[1] == true) && (plDeath[2] == false && plDead[2] == false))
                                    {
                                        winner = 3;
                                        plWins[2] += 1;
                                        endTmr = true;
                                    }
                                    else
                                        if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == true || plDead[1] == true) && (plDeath[2] == true || plDead[2] == true))
                                        {
                                            winner = 0;
                                            endTmr = true;
                                        }
                        }
                        else
                            if (plNum == 4 && endTmr == false)
                            {
                                if ((plDeath[0] == false && plDead[0] == false) && (plDeath[1] == true || plDead[1] == true) && (plDeath[2] == true || plDead[2] == true) && (plDeath[3] == true || plDead[3] == true))
                                {
                                    winner = 1;
                                    plWins[0] += 1;
                                    endTmr = true;
                                }
                                else
                                    if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == false && plDead[1] == false) && (plDeath[2] == true || plDead[2] == true) && (plDeath[3] == true || plDead[3] == true))
                                    {
                                        winner = 2;
                                        plWins[1] += 1;
                                        endTmr = true;
                                    }
                                    else
                                        if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == true || plDead[1] == true) && (plDeath[2] == false && plDead[2] == false) && (plDeath[3] == true || plDead[3] == true))
                                        {
                                            winner = 3;
                                            plWins[2] += 1;
                                            endTmr = true;
                                        }
                                        else
                                            if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == true || plDead[1] == true) && (plDeath[2] == true || plDead[2] == true) && (plDeath[3] == false && plDead[3] == false))
                                            {
                                                winner = 4;
                                                plWins[3] += 1;
                                                endTmr = true;
                                            }
                                            else
                                                if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == true || plDead[1] == true) && (plDeath[2] == true || plDead[2] == true) && (plDeath[3] == true || plDead[3] == true))
                                                {
                                                    winner = 0;
                                                    endTmr = true;
                                                }
                            }
                    //Checks to see if someone won the entire game
                    if (endTmr == true && won == false)
                    {
                        if (plWins[0] < winsNeeded && plWins[1] < winsNeeded && plWins[2] < winsNeeded && plWins[3] < winsNeeded)
                        {
                            resettmr += 1;
                            if (resettmr == 175) { resettmr = 0; endTmr = false; inGame = true; Transition(); }
                        }
                        if (plWins[0] == winsNeeded || plWins[1] == winsNeeded || plWins[2] == winsNeeded || plWins[3] == winsNeeded)
                        {
                            //Fireworks
                            fwStart();
                            //temp
                            won = true;
                            mscTmr = 0;
                            wp.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Cantina.mp3";
                        }
                    }
                }
                else
                    if (teams == true && endTmr == false)
                    {
                        if ((plDeath[0] == true || plDead[0] == true) && (plDeath[1] == true || plDead[1] == true) && (plDeath[1] == true || plDead[1] == true) && (plDeath[1] == true || plDead[1] == true))
                        {
                            winner = 0;
                            endTmr = true;
                        }
                        else
                            if (team12 == true && endTmr == false)
                            {
                                if (((plDeath[0] == false && plDead[0] == false) && (plDeath[2] == true || plDead[2] == true) && (plDeath[3] == true || plDead[3] == true)) || ((plDeath[1] == false && plDead[1] == false) && (plDeath[2] == true || plDead[2] == true) && (plDeath[3] == true || plDead[3] == true)))
                                {
                                    winner = 1;
                                    plWins[0] += 1;
                                    endTmr = true;
                                }
                                else
                                    if (((plDeath[2] == false && plDead[2] == false) && (plDeath[0] == true || plDead[0] == true) && (plDeath[1] == true || plDead[1] == true)) || ((plDeath[3] == false && plDead[3] == false) && (plDeath[0] == true || plDead[0] == true) && (plDeath[1] == true || plDead[1] == true)))
                                    {
                                        winner = 2;
                                        plWins[1] += 1;
                                        endTmr = true;
                                    }
                            }
                            else
                                if (team13 == true && endTmr == false)
                                {
                                    if (((plDeath[0] == false && plDead[0] == false) && (plDeath[2] == true || plDead[2] == true) && (plDeath[3] == true || plDead[3] == true)) || ((plDeath[2] == false && plDead[2] == false) && (plDeath[1] == true || plDead[1] == true) && (plDeath[3] == true || plDead[3] == true)))
                                    {
                                        winner = 1;
                                        plWins[0] += 1;
                                        endTmr = true;
                                    }
                                    else
                                        if (((plDeath[1] == false && plDead[1] == false) && (plDeath[0] == true || plDead[0] == true) && (plDeath[2] == true || plDead[2] == true)) || ((plDeath[3] == false && plDead[3] == false) && (plDeath[0] == true || plDead[0] == true) && (plDeath[2] == true || plDead[2] == true)))
                                        {
                                            winner = 2;
                                            plWins[1] += 1;
                                            endTmr = true;
                                        }
                                }
                                else
                                    if (team14 == true && endTmr == false)
                                    {
                                        if (((plDeath[0] == false && plDead[0] == false) && (plDeath[2] == true || plDead[2] == true) && (plDeath[3] == true || plDead[3] == true)) || ((plDeath[3] == false && plDead[3] == false) && (plDeath[1] == true || plDead[1] == true) && (plDeath[2] == true || plDead[2] == true)))
                                        {
                                            winner = 1;
                                            plWins[0] += 1;
                                            endTmr = true;
                                        }
                                        else
                                            if (((plDeath[1] == false && plDead[1] == false) && (plDeath[0] == true || plDead[0] == true) && (plDeath[3] == true || plDead[3] == true)) || ((plDeath[2] == false && plDead[2] == false) && (plDeath[0] == true || plDead[0] == true) && (plDeath[3] == true || plDead[3] == true)))
                                            {
                                                winner = 2;
                                                plWins[1] += 1;
                                                endTmr = true;
                                            }
                                    }
                    }
                        //Checks to see if someone won the entire game
                        if (endTmr == true && won == false)
                        {
                            if (plWins[0] < winsNeeded && plWins[1] < winsNeeded)
                            {
                                resettmr += 1;
                                if (resettmr == 175) { resettmr = 0; endTmr = false; inGame = true; Transition(); }
                            }
                            if (plWins[0] == winsNeeded || plWins[1] == winsNeeded)
                            {
                                //Fireworks
                                fwStart();
                                //temp
                                won = true;
                                mscTmr = 0;
                                wp.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Cantina.mp3";
                            }
                        }
                    
            }            
            this.Refresh();
        }

        private void tmrBombers_Tick(object sender, EventArgs e)
        {
            //In Game only
            if (gameOnOff == true && inGameMenu == false)
            {
                for (int n = 0; n < Players.Count; n++)
                {
                    for (int i = 0; i < power.Count; i++)
                    {
                        //Powerup Response
                        if (Players[n].IntersectsWith(power[i]) && skPl != n)
                        {
                            if (lWP == 1)
                            {
                                wpL1.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Mafia.mp3";
                                lWP += 1;
                            }
                            else
                                if (lWP == 2)
                                {
                                    wpL2.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Mafia.mp3";
                                    lWP += 1;
                                }
                                else
                                    if (lWP == 3)
                                    {
                                        wpL3.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Mafia.mp3";
                                        lWP = 1;
                                    }
                            if (pTemp[i] >= 0 && pTemp[i] <= 4)
                            {
                                puBB[n] = true;
                                puB[n] = false;
                                DrawBackGround();
                            }
                            else
                                if (pTemp[i] >= 5 && pTemp[i] <= 19)
                                {
                                    if (plMoveSpeed[n] < 10)
                                    {
                                        plMoveSpeed[n] += 1;
                                        DrawBackGround();
                                    }
                                }
                                else
                                    if (pTemp[i] >= 20 && pTemp[i] <= 34)
                                    {
                                        eSize[n] += 1;
                                        DrawBackGround();
                                    }
                                    else
                                        if (pTemp[i] >= 35 && pTemp[i] <= 49)
                                        {
                                            plBoCou[n] += 1;
                                            DrawBackGround();
                                        }
                                        else
                                            if (pTemp[i] >= 50 && pTemp[i] <= 54)
                                            {
                                                //Kick Bomb   
                                                DrawBackGround();
                                            }
                                            else
                                                if (pTemp[i] >= 60 && pTemp[i] <= 64)
                                                {
                                                    if (n == 0) { plRng[0] = true; RNG1(); }
                                                    if (n == 1) { plRng[1] = true; RNG2(); }
                                                    if (n == 2) { plRng[2] = true; RNG3(); }
                                                    if (n == 3) { plRng[3] = true; RNG4(); }
                                                }
                                                else
                                                    if (pTemp[i] >= 70 && pTemp[i] <= 84)
                                                    {
                                                        skPl = n;
                                                        spTemp = plMoveSpeed[n];
                                                        boTemp = plBoCou[n];
                                                        plMoveSpeed[n] = 1;
                                                        plBoCou[n] = 0;
                                                        DrawBackGround();
                                                    }
                                                    else
                                                        if (pTemp[i] >= 84 && pTemp[i] <= 89)
                                                        {
                                                            if (puBB[n] == false)
                                                            {
                                                                puB[n] = true;
                                                            }
                                                            DrawBackGround();
                                                        }
                            pR.RemoveAt(i);
                            pC.RemoveAt(i);
                            pTemp.RemoveAt(i);
                            powerVis.RemoveAt(i);
                            power.RemoveAt(i);
                        }
                    }
                }
                //Matches proper explosion stats to the corresponding player
                for (int i = 0; i < exp.Count; i++)
                {
                    for (int n = 0; n < bomb.Count; n++)
                    {
                        if (bomb[n].IntersectsWith(exp[i]))
                        {                            
                            if (boR[n] == 0 && plDead[0] == false && plDeath[0] == false)
                            {
                                eTemp = n;
                                boomboom1();
                            }
                            else
                                if (boR[n] == 1 && plDead[1] == false && plDeath[1] == false)
                                {
                                    eTemp = n;
                                    boomboom2();
                                }
                                else
                                    if (boR[n] == 2 && plDead[2] == false && plDeath[2] == false)
                                    {
                                        eTemp = n;
                                        boomboom3();
                                    }
                                    else
                                        if (boR[n] == 3 && plDead[3] == false && plDeath[3] == false)
                                        {
                                            eTemp = n;
                                            boomboom4();
                                        }
                                        else
                                        {
                                            puE.RemoveAt(n);
                                            puEE.RemoveAt(n);
                                            boX.RemoveAt(n);
                                            boY.RemoveAt(n);
                                            boCou.RemoveAt(n);
                                            boC.RemoveAt(n);
                                            boR.RemoveAt(n);
                                            bomb.RemoveAt(n);
                                        }
                        }
                    }
                }
                //Explosion Sprite Worker
                for (int i = 0; i < expCou.Count; i++)
                {
                    expCou[i] += 1;
                    expR[i] = expCou[i] % expTR;

                    if (expCou[i] >= expTR)
                    {
                        rTemp = i;
                        RemoveExp();
                    }                 
                 }
                //Breakable BLock SPrite WOrker
                for (int n = 0; n < brickB.Count; n++)
                {
                    if (breaker[n] == true)
                    {
                        brCou[n] += 1;
                        brR[n] = brCou[n] % brTR;
                    }
                    if (brCou[n] >= brTR)
                    {
                        y = n;
                        powerSpawn();
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //In Gmae
            if (gameOnOff == true)
            {
                for (int n = 0; n < brickB.Count; n++)
                {
                    //Breakeable Bricks
                    e.Graphics.DrawImage(brickBreak, brickB[n], new RectangleF(brC * brW, brR[n] * brH, brW, brH), GraphicsUnit.Pixel);
                }
                for (int n = 0; n < bomb.Count; n++)
                {
                    //Matches Bomb to Correct PU
                    if (puEE[n] == true)
                    {
                        e.Graphics.DrawImage(powerpowerUpBomb, bomb[n], new RectangleF(boC[n] * boW, boR[n] * boH, boW, boH), GraphicsUnit.Pixel);
                    }
                    else if (puE[n] == true)
                    {
                        e.Graphics.DrawImage(powerUpBomb, bomb[n], new RectangleF(boC[n] * boW, boR[n] * boH, boW, boH), GraphicsUnit.Pixel);
                    }
                    else
                    {
                        e.Graphics.DrawImage(normalBomb, bomb[n], new RectangleF(boC[n] * boW, boR[n] * boH, boW, boH), GraphicsUnit.Pixel);
                    }
                }
                //Draws Explosion
                for (int n = 0; n < expCou.Count; n++)
                {
                    for (int i = 0; i < exp.Count; i++)
                    {
                        e.Graphics.DrawImage(Explosion, exp[i], new RectangleF(expC[i] * expW, expR[n] * expH, expW, expH), GraphicsUnit.Pixel);
                    }
                }
                ///Draws PUS
                for (int n = 0; n < power.Count; n++)
                {
                    if (powerVis[n] == true)
                    {
                        e.Graphics.DrawImage(PowerUp, power[n], new RectangleF(pC[n] * pW, pR[n] * pH, pW, pH), GraphicsUnit.Pixel);
                    }
                }
                //Draws Players
                for (int n = 0; n < plNum; n++)
                {
                    e.Graphics.DrawImage(bombers, Players[n], new RectangleF(plC[n] * plW, plR[n] * plH, plW, plH), GraphicsUnit.Pixel);
                }
                //Draws Player on ICon SIdes
                e.Graphics.DrawImage(bombers, playerBG[0], new RectangleF(plC[0] * plW, plR[0] * plH, plW, plH), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(bombers, playerBG[1], new RectangleF(plC[1] * plW, plR[1] * plH, plW, plH), GraphicsUnit.Pixel);
                if (plNum > 2)
                {
                    e.Graphics.DrawImage(bombers, playerBG[2], new RectangleF(plC[2] * plW, plR[2] * plH, plW, plH), GraphicsUnit.Pixel);
                }
                if (plNum > 3)
                {
                    e.Graphics.DrawImage(bombers, playerBG[3], new RectangleF(plC[3] * plW, plR[3] * plH, plW, plH), GraphicsUnit.Pixel);
                }
                //Puase Menu
                if (inGameMenu == true)
                {
                    e.Graphics.FillRectangle(mSel, 0, 0, this.Width, this.Height);
                    e.Graphics.FillRectangle(Brushes.Black, this.Width / 2 - 70, this.Height / 2 - 95, 118, 40);
                    e.Graphics.FillRectangle(Brushes.Black, this.Width / 2 - 78, this.Height / 2 - 35, 134, 40);
                    e.Graphics.FillRectangle(Brushes.Black, this.Width / 2 - 83, this.Height / 2 + 25, 144, 40);
                    e.Graphics.DrawString("Resume", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, this.Width / 2 - 60, this.Height / 2 - 85);
                    e.Graphics.DrawString("Restart", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, this.Width / 2 - 68, this.Height / 2 - 25);
                    e.Graphics.DrawString("Main Menu", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, this.Width / 2 - 73, this.Height / 2 + 35);
                    if (mPos >= 0 && mPos <= 2)
                    {
                        e.Graphics.FillRectangle(inmSel, ingMen[mPos]);
                    }
                }
                if (endTmr == true)
                {
                    e.Graphics.FillRectangle(mSel, 0, 0, this.Width, this.Height);
                    if (won == true)
                    {                        
                        e.Graphics.FillRectangle(Brushes.Black, 55, this.Height / 2 - 120, 610, 70);
                        e.Graphics.FillRectangle(Brushes.Black, this.Width / 2 - 78, this.Height / 2 - 35, 134, 40);
                        e.Graphics.FillRectangle(Brushes.Black, this.Width / 2 - 83, this.Height / 2 + 25, 144, 40);
                        e.Graphics.DrawString("Restart", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, this.Width / 2 - 68, this.Height / 2 - 25);
                        e.Graphics.DrawString("Main Menu", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, this.Width / 2 - 73, this.Height / 2 + 35);
                        if (teams == false)
                        {
                            if (winner == 1)
                            {
                                e.Graphics.DrawString("PLAYER 1 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 70, this.Height / 2 - 110);
                            }
                            else
                                if (winner == 2)
                                {
                                    e.Graphics.DrawString("PLAYER 2 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 55, this.Height / 2 - 110);
                                }
                                else
                                    if (winner == 3)
                                    {
                                        e.Graphics.DrawString("PLAYER 3 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 55, this.Height / 2 - 110);
                                    }
                                    else
                                        if (winner == 4)
                                        {
                                            e.Graphics.DrawString("PLAYER 4 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 55, this.Height / 2 - 110);
                                        }
                                        else
                                            if (winner == 0)
                                            {
                                                e.Graphics.DrawString("YOU ALL LOSE", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 80, this.Height / 2 - 110);
                                            }
                        }
                        else 
                        {
                            if (winner == 1)
                            {
                                e.Graphics.DrawString("TEAM 1 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 120, this.Height / 2 - 110); ;
                            }
                            else
                                if (winner == 2)
                                {
                                    e.Graphics.DrawString("TEAM 2 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 105, this.Height / 2 - 110);
                                }
                                else
                                    if (winner == 0)
                                    {
                                        e.Graphics.DrawString("YOU ALL LOSE", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 80, this.Height / 2 - 110);
                                    }
                        }
                        if (mPos >= 1 && mPos <= 2)
                        {
                            e.Graphics.FillRectangle(inmSel, ingMen[mPos]);
                        }
                        //Fireworks
                        for (int o = 0; o < 15; o++)
                        {
                            for (int i = 0; i < 40; i++)
                            {
                                if (ep[o] == true)
                                {
                                    e.Graphics.FillRectangle(color[o], particle[o, i].X, particle[o, i].Y, FWsize[o], FWsize[o]);
                                }
                            }
                            e.Graphics.FillRectangle(color[o], up[o].X, up[o].Y, FWsize[o], FWsize[o]);
                        }
                    }
                    else
                    {
                        if (teams == false)
                        {
                            if (winner == 1)
                            {
                                e.Graphics.DrawString("PLAYER 1 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 70, this.Height / 2 - 40);
                            }
                            else
                                if (winner == 2)
                                {
                                    e.Graphics.DrawString("PLAYER 2 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 55, this.Height / 2 - 40);
                                }
                                else
                                    if (winner == 3)
                                    {
                                        e.Graphics.DrawString("PLAYER 3 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 55, this.Height / 2 - 40);
                                    }
                                    else
                                        if (winner == 4)
                                        {
                                            e.Graphics.DrawString("PLAYER 4 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 55, this.Height / 2 - 40);
                                        }
                                        else
                                            if (winner == 0)
                                            {
                                                e.Graphics.DrawString("YOU ALL LOSE", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 80, this.Height / 2 - 40);
                                            }
                        }
                        else 
                        {
                            if (winner == 1)
                            {
                                e.Graphics.DrawString("TEAM 1 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 120, this.Height / 2 - 110);
                            }
                            else
                                if (winner == 2)
                                {
                                    e.Graphics.DrawString("TEAM 2 WINS", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 105, this.Height / 2 - 110);
                                }
                                else
                                    if (winner == 0)
                                    {
                                        e.Graphics.DrawString("YOU ALL LOSE", new System.Drawing.Font(pfd.Families[0], 30), Brushes.White, 80, this.Height / 2 - 110);
                                    }
                        }
                    }
                }
            }
            //Main Menu AREA
            if (gameOnOff == false) 
            {
                if (cOn == false && oOn == false)
                {
                    e.Graphics.FillRectangle(Brushes.DarkOrange, 0, this.Height - 100, this.Width, 150);
                    if (pAb == true)
                    {
                        e.Graphics.DrawString("Press Any Button To Continue", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 150, this.Height - 75);
                        e.Graphics.FillRectangle(dO, 150, this.Height - 75, 425, 20);
                    }
                    if (pAb == false)
                    {
                        e.Graphics.DrawString("Play", new System.Drawing.Font(pfd.Families[0], 10), dOO, xTitle, this.Height - 75);
                        e.Graphics.DrawString("Options", new System.Drawing.Font(pfd.Families[0], 10), dOO, xTitle + 100, this.Height - 75);
                        e.Graphics.DrawString("Controls", new System.Drawing.Font(pfd.Families[0], 10), dOO, xTitle + 235, this.Height - 75);
                        e.Graphics.DrawString("Exit", new System.Drawing.Font(pfd.Families[0], 10), dOO, xTitle + 395, this.Height - 75);
                        if (mPos >= 0 && mPos <= 3)
                        {
                            e.Graphics.FillRectangle(mSel, menPos[mPos]);
                        }
                    }
                }

                if (cOn == true) 
                {
                    e.Graphics.FillPolygon(Brushes.Black, wpl1);
                    e.Graphics.FillPolygon(Brushes.Black, wpl2);
                    e.Graphics.FillPolygon(Brushes.Black, wpl3);
                    e.Graphics.FillPolygon(Brushes.Black, wpl4);
                    e.Graphics.FillPolygon(plColor[0], pl1);
                    e.Graphics.FillPolygon(plColor[1], pl2);
                    e.Graphics.FillPolygon(plColor[2], pl3);
                    e.Graphics.FillPolygon(plColor[3], pl4);
                    if (plC[0] == 0 || plC[0] == 5) 
                    {
                        e.Graphics.DrawString("Player 1", new System.Drawing.Font(pfd.Families[0], 10), Brushes.Black, 50, 50);
                    }
                    else
                    {
                        e.Graphics.DrawString("Player 1", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 50, 50);
                    }
                    if (plC[2] == 0 || plC[2] == 5)
                    {
                        e.Graphics.DrawString("Player 3", new System.Drawing.Font(pfd.Families[0], 10), Brushes.Black, 50, 350);
                    }
                    else
                    {
                        e.Graphics.DrawString("Player 3", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 50, 350);
                    }
                    if (plC[1] == 0 || plC[1] == 5)
                    {
                        e.Graphics.DrawString("Player 2", new System.Drawing.Font(pfd.Families[0], 10), Brushes.Black, this.Width - 200, 50);
                    }
                    else
                    {
                        e.Graphics.DrawString("Player 2", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, this.Width - 200, 50);
                    }
                    if (plC[3] == 0 || plC[3] == 5)
                    {
                        e.Graphics.DrawString("Player 4", new System.Drawing.Font(pfd.Families[0], 10), Brushes.Black, this.Width - 200, 350);
                    }
                    else
                    {
                        e.Graphics.DrawString("Player 4", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, this.Width - 200, 350);
                    }
                    e.Graphics.FillRectangle(Brushes.Black, this.Width / 2 - 120, this.Height - 140, 215, 50);
                    e.Graphics.DrawString("Back To Menu", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, this.Width / 2 - 100, this.Height - 125);
                    if (baOn == true) 
                    {
                        e.Graphics.FillRectangle(mSel, this.Width / 2 - 120, this.Height - 140, 215, 50);
                    }
                    e.Graphics.FillRectangle(Brushes.Black, 110, 150, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 110, 210, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 50, 210, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 170, 210, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 230, 150, 50, 50);
                    e.Graphics.DrawString("W", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 125, 165);
                    e.Graphics.DrawString("A", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 65, 225);
                    e.Graphics.DrawString("S", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 125, 225);
                    e.Graphics.DrawString("D", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 185, 225);
                    e.Graphics.DrawString("R", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 245, 165);
                    e.Graphics.FillRectangle(Brushes.Black, 495, 150, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 495, 210, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 435, 210, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 555, 210, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 615, 150, 50, 50);
                    e.Graphics.DrawString("UP", new System.Drawing.Font(pfd.Families[0], 8), Brushes.White, 505, 167);
                    e.Graphics.DrawString("LEFT", new System.Drawing.Font(pfd.Families[0], 5), Brushes.White, 442, 228);
                    e.Graphics.DrawString("DOWN", new System.Drawing.Font(pfd.Families[0], 5), Brushes.White, 502, 228);
                    e.Graphics.DrawString("RIGHT", new System.Drawing.Font(pfd.Families[0], 5), Brushes.White, 558, 228);
                    e.Graphics.DrawString("1", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 635, 165);
                    e.Graphics.FillRectangle(Brushes.Black, 110, 450, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 110, 510, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 50, 510, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 170, 510, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 230, 450, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 285, 285, 150, 100);
                    e.Graphics.DrawString("NUMPAD", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 310, 325);
                    e.Graphics.DrawString("-", new System.Drawing.Font(pfd.Families[0], 15), Brushes.White, 350, 350);
                    e.Graphics.DrawString("PAUSE", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 320, 300);                    
                    e.Graphics.DrawString("Y", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 125, 465);
                    e.Graphics.DrawString("G", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 65, 525);
                    e.Graphics.DrawString("H", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 125, 525);
                    e.Graphics.DrawString("J", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 185, 525);
                    e.Graphics.DrawString("I", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 245, 465);
                    e.Graphics.FillRectangle(Brushes.Black, 495, 450, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 495, 510, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 435, 510, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 555, 510, 50, 50);
                    e.Graphics.FillRectangle(Brushes.Black, 615, 450, 50, 50);
                    e.Graphics.DrawString("P", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 510, 465);
                    e.Graphics.DrawString("L", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 450, 525);
                    e.Graphics.DrawString(";", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 515, 525);
                    e.Graphics.DrawString("'", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 575, 525);
                    e.Graphics.DrawString("\\", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 630, 465);                   
                }
                if (oOn == true)
                {
                    e.Graphics.FillRectangle(Brushes.Black, this.Width / 2 - 120, this.Height - 140, 215, 50);
                    e.Graphics.DrawString("Back To Menu", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, this.Width / 2 - 100, this.Height - 125);
                    if (baOn == true)
                    {
                        e.Graphics.FillRectangle(mSel, this.Width / 2 - 120, this.Height - 140, 215, 50);
                    }
                    e.Graphics.FillRectangle(Brushes.Black, 0, 335, this.Width, 50);
                    if (teams == false)
                    {
                        e.Graphics.DrawString("Player 1", new System.Drawing.Font(pfd.Families[0], 10), plColor[0], 65, 350);
                        e.Graphics.DrawString("Player 2", new System.Drawing.Font(pfd.Families[0], 10), plColor[1], 215, 350);
                        e.Graphics.DrawString("Player 3", new System.Drawing.Font(pfd.Families[0], 10), plColor[2], 365, 350);
                        e.Graphics.DrawString("Player 4", new System.Drawing.Font(pfd.Families[0], 10), plColor[3], 515, 350);
                    }
                    else 
                    {
                        if (team12 == true)
                        {
                            e.Graphics.DrawString("Player 1", new System.Drawing.Font(pfd.Families[0], 10), team1, 65, 350);
                            e.Graphics.DrawString("Player 2", new System.Drawing.Font(pfd.Families[0], 10), team1, 215, 350);
                            e.Graphics.DrawString("Player 3", new System.Drawing.Font(pfd.Families[0], 10), team2, 365, 350);
                            e.Graphics.DrawString("Player 4", new System.Drawing.Font(pfd.Families[0], 10), team2, 515, 350);
                        }
                        else
                            if (team13 == true)
                            {
                                e.Graphics.DrawString("Player 1", new System.Drawing.Font(pfd.Families[0], 10), team1, 65, 350);
                                e.Graphics.DrawString("Player 2", new System.Drawing.Font(pfd.Families[0], 10), team2, 215, 350);
                                e.Graphics.DrawString("Player 3", new System.Drawing.Font(pfd.Families[0], 10), team1, 365, 350);
                                e.Graphics.DrawString("Player 4", new System.Drawing.Font(pfd.Families[0], 10), team2, 515, 350);
                            }
                            else
                                if (team14 == true)
                                {
                                    e.Graphics.DrawString("Player 1", new System.Drawing.Font(pfd.Families[0], 10), team1, 65, 350);
                                    e.Graphics.DrawString("Player 2", new System.Drawing.Font(pfd.Families[0], 10), team2, 215, 350);
                                    e.Graphics.DrawString("Player 3", new System.Drawing.Font(pfd.Families[0], 10), team2, 365, 350);
                                    e.Graphics.DrawString("Player 4", new System.Drawing.Font(pfd.Families[0], 10), team1, 515, 350);
                                }
                    }
                    e.Graphics.DrawImage(bombers, optCol[0], new RectangleF(plC[0] * plW, plR[0] * plH, plW, plH), GraphicsUnit.Pixel);
                    e.Graphics.DrawImage(bombers, optCol[1], new RectangleF(plC[1] * plW, plR[1] * plH, plW, plH), GraphicsUnit.Pixel);
                    e.Graphics.DrawImage(bombers, optCol[2], new RectangleF(plC[2] * plW, plR[2] * plH, plW, plH), GraphicsUnit.Pixel);
                    e.Graphics.DrawImage(bombers, optCol[3], new RectangleF(plC[3] * plW, plR[3] * plH, plW, plH), GraphicsUnit.Pixel);
                    for (int n = 0; n < optButCon.Count; n++) 
                    {                      
                            e.Graphics.FillRectangle(optButtCon[n], optButCon[n]);                    
                                                  
                    }
                    e.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, 60);
                    e.Graphics.DrawString("OPTIONS", new System.Drawing.Font(pfd.Families[0], 15), Brushes.White, 270, 15);
                    e.Graphics.DrawString("Rnd Spawn", new System.Drawing.Font(pfd.Families[0], 6), Brushes.White, 77, 115);
                    e.Graphics.DrawString("Rnd Color", new System.Drawing.Font(pfd.Families[0], 6), Brushes.White, 237, 115);
                    e.Graphics.DrawString("Power Up", new System.Drawing.Font(pfd.Families[0], 6), Brushes.White, 402, 102);
                    e.Graphics.DrawString("Cahnce", new System.Drawing.Font(pfd.Families[0], 6), Brushes.White, 407, 112);
                    e.Graphics.DrawString("Score Limit", new System.Drawing.Font(pfd.Families[0], 6), Brushes.White, 317, 182);
                    e.Graphics.DrawString("<", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 110, 192);
                    e.Graphics.DrawString(">", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 595, 192);
                    e.Graphics.DrawString("TEAMS", new System.Drawing.Font(pfd.Families[0], 7), Brushes.White, 570, 115);
                    e.Graphics.DrawString("PLAYERS", new System.Drawing.Font(pfd.Families[0], 6), Brushes.White, 327, 262);
                    e.Graphics.DrawString("<", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 110, 272);
                    e.Graphics.DrawString(">", new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 595, 272);
                    if (winsNeeded == 1)
                    {
                        e.Graphics.DrawString("" + winsNeeded, new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 357, 199);
                    }
                    else
                    {
                        e.Graphics.DrawString("" + winsNeeded, new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 355, 199);                    
                    }
                    if (plNum == 1)
                    {
                        e.Graphics.DrawString("" + plNum, new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 357, 279);
                    }
                    else
                    {
                        e.Graphics.DrawString("" + plNum, new System.Drawing.Font(pfd.Families[0], 10), Brushes.White, 355, 279);
                    }
                    if (puSpawnRate == 2)
                    {
                        e.Graphics.DrawString("50%", new System.Drawing.Font(pfd.Families[0], 7), Brushes.White, 420, 127);
                    }
                    if (puSpawnRate == 4)
                    {
                        e.Graphics.DrawString("25%", new System.Drawing.Font(pfd.Families[0], 7), Brushes.White, 420, 127);
                    }
                    if (puSpawnRate == 10)
                    {
                        e.Graphics.DrawString("10%", new System.Drawing.Font(pfd.Families[0], 7), Brushes.White, 422, 127);
                    }
                    if (puSpawnRate == 1)
                    {
                        e.Graphics.DrawString("ALMOST 100%", new System.Drawing.Font(pfd.Families[0], 5), Brushes.White, 395, 127);
                    }
                    if (mPos >= 0 && mPos <= 9 && mPos != 4 && mPos != 7)
                    {
                        e.Graphics.FillRectangle(inmSel, optButCon[mPos]);
                    }
                    e.Graphics.FillRectangle(Brushes.Black, 0, 460, this.Width, 110);
                    for (int n = 0; n < optBut.Count; n++) 
                    {                   
                         e.Graphics.FillRectangle(optButt[n], optBut[n]);                      
                    }
                    if (plC[0] < 4)
                    {
                        //P1
                        e.Graphics.DrawString("P1", new System.Drawing.Font(pfd.Families[0], 7), plColor[0], optBut[plC[0]].X, optBut[plC[0]].Y - 15);
                        e.Graphics.DrawString("P1", new System.Drawing.Font(pfd.Families[0], 7), plColor[0], optBut[plC[0] + 8].X, optBut[plC[0] + 8].Y - 15);
                        e.Graphics.DrawString("P1", new System.Drawing.Font(pfd.Families[0], 7), plColor[0], optBut[plC[0] + 16].X, optBut[plC[0] + 16].Y - 15);
                        e.Graphics.DrawString("P1", new System.Drawing.Font(pfd.Families[0], 7), plColor[0], optBut[plC[0] + 24].X, optBut[plC[0] + 24].Y - 15);
                    }
                    else 
                    {
                        //P1
                        e.Graphics.DrawString("P1", new System.Drawing.Font(pfd.Families[0], 7), plColor[0], optBut[plC[0]].X, optBut[plC[0]].Y + 25);
                        e.Graphics.DrawString("P1", new System.Drawing.Font(pfd.Families[0], 7), plColor[0], optBut[plC[0] + 8].X, optBut[plC[0] + 8].Y + 25);
                        e.Graphics.DrawString("P1", new System.Drawing.Font(pfd.Families[0], 7), plColor[0], optBut[plC[0] + 16].X, optBut[plC[0] + 16].Y + 25);
                        e.Graphics.DrawString("P1", new System.Drawing.Font(pfd.Families[0], 7), plColor[0], optBut[plC[0] + 24].X, optBut[plC[0] + 24].Y + 25);
                    }
                    if (plC[1] < 4)
                    {
                        //P2
                        e.Graphics.DrawString("P2", new System.Drawing.Font(pfd.Families[0], 7), plColor[1], optBut[plC[1]].X - 2, optBut[plC[1]].Y - 15);
                        e.Graphics.DrawString("P2", new System.Drawing.Font(pfd.Families[0], 7), plColor[1], optBut[plC[1] + 8].X -2, optBut[plC[1] + 8].Y - 15);
                        e.Graphics.DrawString("P2", new System.Drawing.Font(pfd.Families[0], 7), plColor[1], optBut[plC[1] + 16].X - 2, optBut[plC[1] + 16].Y - 15);
                        e.Graphics.DrawString("P2", new System.Drawing.Font(pfd.Families[0], 7), plColor[1], optBut[plC[1] + 24].X - 2, optBut[plC[1] + 24].Y - 15);
                    }
                    else
                    {
                        //P2
                        e.Graphics.DrawString("P2", new System.Drawing.Font(pfd.Families[0], 7), plColor[1], optBut[plC[1]].X - 2, optBut[plC[1]].Y + 25);
                        e.Graphics.DrawString("P2", new System.Drawing.Font(pfd.Families[0], 7), plColor[1], optBut[plC[1] + 8].X - 2, optBut[plC[1] + 8].Y + 25);
                        e.Graphics.DrawString("P2", new System.Drawing.Font(pfd.Families[0], 7), plColor[1], optBut[plC[1] + 16].X - 2, optBut[plC[1] + 16].Y + 25);
                        e.Graphics.DrawString("P2", new System.Drawing.Font(pfd.Families[0], 7), plColor[1], optBut[plC[1] + 24].X - 2, optBut[plC[1] + 24].Y + 25);
                    }
                    if (plC[2] < 4)
                    {
                        //P3
                        e.Graphics.DrawString("P3", new System.Drawing.Font(pfd.Families[0], 7), plColor[2], optBut[plC[2]].X - 2, optBut[plC[2]].Y - 15);
                        e.Graphics.DrawString("P3", new System.Drawing.Font(pfd.Families[0], 7), plColor[2], optBut[plC[2] + 8].X - 2, optBut[plC[2] + 8].Y - 15);
                        e.Graphics.DrawString("P3", new System.Drawing.Font(pfd.Families[0], 7), plColor[2], optBut[plC[2] + 16].X - 2, optBut[plC[2] + 16].Y - 15);
                        e.Graphics.DrawString("P3", new System.Drawing.Font(pfd.Families[0], 7), plColor[2], optBut[plC[2] + 24].X - 2, optBut[plC[2] + 24].Y - 15);
                    }
                    else
                    {
                        //P3
                        e.Graphics.DrawString("P3", new System.Drawing.Font(pfd.Families[0], 7), plColor[2], optBut[plC[2]].X - 2, optBut[plC[2]].Y + 25);
                        e.Graphics.DrawString("P3", new System.Drawing.Font(pfd.Families[0], 7), plColor[2], optBut[plC[2] + 8].X - 2, optBut[plC[2] + 8].Y + 25);
                        e.Graphics.DrawString("P3", new System.Drawing.Font(pfd.Families[0], 7), plColor[2], optBut[plC[2] + 16].X - 2, optBut[plC[2] + 16].Y + 25);
                        e.Graphics.DrawString("P3", new System.Drawing.Font(pfd.Families[0], 7), plColor[2], optBut[plC[2] + 24].X - 2, optBut[plC[2] + 24].Y + 25);
                    }
                    if (plC[3] < 4)
                    {
                        //P4
                        e.Graphics.DrawString("P4", new System.Drawing.Font(pfd.Families[0], 7), plColor[3], optBut[plC[3]].X - 2, optBut[plC[3]].Y - 15);
                        e.Graphics.DrawString("P4", new System.Drawing.Font(pfd.Families[0], 7), plColor[3], optBut[plC[3] + 8].X - 2, optBut[plC[3] + 8].Y - 15);
                        e.Graphics.DrawString("P4", new System.Drawing.Font(pfd.Families[0], 7), plColor[3], optBut[plC[3] + 16].X - 2, optBut[plC[3] + 16].Y - 15);
                        e.Graphics.DrawString("P4", new System.Drawing.Font(pfd.Families[0], 7), plColor[3], optBut[plC[3] + 24].X - 2, optBut[plC[3] + 24].Y - 15);
                    }
                    else
                    {
                        //P4
                        e.Graphics.DrawString("P4", new System.Drawing.Font(pfd.Families[0], 7), plColor[3], optBut[plC[3]].X - 2, optBut[plC[3]].Y + 25);
                        e.Graphics.DrawString("P4", new System.Drawing.Font(pfd.Families[0], 7), plColor[3], optBut[plC[3] + 8].X - 2, optBut[plC[3] + 8].Y + 25);
                        e.Graphics.DrawString("P4", new System.Drawing.Font(pfd.Families[0], 7), plColor[3], optBut[plC[3] + 16].X - 2, optBut[plC[3] + 16].Y + 25);
                        e.Graphics.DrawString("P4", new System.Drawing.Font(pfd.Families[0], 7), plColor[3], optBut[plC[3] + 24].X - 2, optBut[plC[3] + 24].Y + 25);
                    }
                }            
            }
            //Transition CIrcle
            if (trans == true) 
            {
                e.Graphics.FillEllipse(Brushes.Black, cX, cY, cW, cH);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOnOff == true && inGameMenu == false)
            {
                //Player 1
                if (plDead[0] == false && plDeath[0] == false)
                {

                    if (e.KeyData == Keys.W && plUp[0] == false && plY[0] > 105)
                    {
                        if (plCol[0] == 1 && plColT[0] == 1 || plCol[0] == 3 && plColT[0] == 3 || plCol[0] == 5 && plColT[0] == 5 || plCol[0] == 7 && plColT[0] == 7 || plCol[0] == 9 && plColT[0] == 9 || plCol[0] == 11 && plColT[0] == 11 || plCol[0] == 13 && plColT[0] == 13 || plCol[0] == 15 && plColT[0] == 15 || plCol[0] == 17 && plColT[0] == 17)
                        {
                            plX[0] = (plCol[0] * 30) + 75;
                            plCou[0] = 9;
                            plR[0] = plCou[0] % plTR;
                            plLeft[0] = false;
                            plUp[0] = true;
                            plDown[0] = false;
                            plRight[0] = false;
                        }
                    }
                    if (e.KeyData == Keys.A && plLeft[0] == false)
                    {
                        if (plRow[0] == 1 && plRowT[0] == 1 || plRow[0] == 3 && plRowT[0] == 3 || plRow[0] == 5 && plRowT[0] == 5 || plRow[0] == 7 && plRowT[0] == 7 || plRow[0] == 9 && plRowT[0] == 9 || plRow[0] == 11 && plRowT[0] == 11 || plRow[0] == 13 && plRowT[0] == 13 || plRow[0] == 15 && plRowT[0] == 15 || plRow[0] == 17 && plRowT[0] == 17)
                        {
                            plY[0] = (plRow[0] * 30) + 75;
                            plCou[0] = 6;
                            plR[0] = plCou[0] % plTR;
                            plUp[0] = false;
                            plDown[0] = false;
                            plRight[0] = false;
                            plLeft[0] = true;
                        }
                    }
                    if (e.KeyData == Keys.S && plDown[0] == false)
                    {
                        if (plCol[0] == 1 && plColT[0] == 1 || plCol[0] == 3 && plColT[0] == 3 || plCol[0] == 5 && plColT[0] == 5 || plCol[0] == 7 && plColT[0] == 7 || plCol[0] == 9 && plColT[0] == 9 || plCol[0] == 11 && plColT[0] == 11 || plCol[0] == 13 && plColT[0] == 13 || plCol[0] == 15 && plColT[0] == 15 || plCol[0] == 17 && plColT[0] == 17)
                        {
                            plX[0] = (plCol[0] * 30) + 75;
                            plCou[0] = 0;
                            plR[0] = plCou[0] % plTR;
                            plLeft[0] = false;
                            plUp[0] = false;
                            plDown[0] = true;
                            plRight[0] = false;
                        }
                    }
                    if (e.KeyData == Keys.D && plRight[0] == false)
                    {
                        if (plRow[0] == 1 && plRowT[0] == 1 || plRow[0] == 3 && plRowT[0] == 3 || plRow[0] == 5 && plRowT[0] == 5 || plRow[0] == 7 && plRowT[0] == 7 || plRow[0] == 9 && plRowT[0] == 9 || plRow[0] == 11 && plRowT[0] == 11 || plRow[0] == 13 && plRowT[0] == 13 || plRow[0] == 15 && plRowT[0] == 15 || plRow[0] == 17 && plRowT[0] == 17)
                        {
                            plY[0] = (plRow[0] * 30) + 75;
                            plCou[0] = 3;
                            plR[0] = plCou[0] % plTR;
                            plLeft[0] = false;
                            plUp[0] = false;
                            plDown[0] = false;
                            plRight[0] = true;
                        }
                    }
                    if (e.KeyData == Keys.R && plBoCou[0] > 0 && skPl != 0)
                    {
                        xTemp = Players[0].X + 15;
                        yTemp = Players[0].Y + 15;
                        plBoCou[0] -= 1;
                        AddBomb1();

                    }
                }
                //PLayer 2
                if (plDead[1] == false && plDeath[1] == false)
                {

                    if (e.KeyData == Keys.Up && plUp[1] == false)
                    {
                        if (plCol[1] == 1 && plColT[1] == 1 || plCol[1] == 3 && plColT[1] == 3 || plCol[1] == 5 && plColT[1] == 5 || plCol[1] == 7 && plColT[1] == 7 || plCol[1] == 9 && plColT[1] == 9 || plCol[1] == 11 && plColT[1] == 11 || plCol[1] == 13 && plColT[1] == 13 || plCol[1] == 15 && plColT[1] == 15 || plCol[1] == 17 && plColT[1] == 17)
                        {
                            plX[1] = (plCol[1] * 30) + 75;
                            plCou[1] = 9;
                            plR[1] = plCou[1] % plTR;
                            plLeft[1] = false;
                            plUp[1] = true;
                            plDown[1] = false;
                            plRight[1] = false;
                        }
                    }
                    if (e.KeyData == Keys.Left && plLeft[1] == false)
                    {
                        if (plRow[1] == 1 && plRowT[1] == 1 || plRow[1] == 3 && plRowT[1] == 3 || plRow[1] == 5 && plRowT[1] == 5 || plRow[1] == 7 && plRowT[1] == 7 || plRow[1] == 9 && plRowT[1] == 9 || plRow[1] == 11 && plRowT[1] == 11 || plRow[1] == 13 && plRowT[1] == 13 || plRow[1] == 15 && plRowT[1] == 15 || plRow[1] == 17 && plRowT[1] == 17)
                        {
                            plY[1] = (plRow[1] * 30) + 75;
                            plCou[1] = 6;
                            plR[1] = plCou[1] % plTR;
                            plUp[1] = false;
                            plDown[1] = false;
                            plRight[1] = false;
                            plLeft[1] = true;
                        }
                    }
                    if (e.KeyData == Keys.Down && plDown[1] == false)
                    {
                        if (plCol[1] == 1 && plColT[1] == 1 || plCol[1] == 3 && plColT[1] == 3 || plCol[1] == 5 && plColT[1] == 5 || plCol[1] == 7 && plColT[1] == 7 || plCol[1] == 9 && plColT[1] == 9 || plCol[1] == 11 && plColT[1] == 11 || plCol[1] == 13 && plColT[1] == 13 || plCol[1] == 15 && plColT[1] == 15 || plCol[1] == 17 && plColT[1] == 17)
                        {
                            plX[1] = (plCol[1] * 30) + 75;
                            plCou[1] = 1;
                            plR[1] = plCou[1] % plTR;
                            plLeft[1] = false;
                            plUp[1] = false;
                            plDown[1] = true;
                            plRight[1] = false;
                        }
                    }
                    if (e.KeyData == Keys.Right && plRight[1] == false)
                    {
                        if (plRow[1] == 1 && plRowT[1] == 1 || plRow[1] == 3 && plRowT[1] == 3 || plRow[1] == 5 && plRowT[1] == 5 || plRow[1] == 7 && plRowT[1] == 7 || plRow[1] == 9 && plRowT[1] == 9 || plRow[1] == 11 && plRowT[1] == 11 || plRow[1] == 13 && plRowT[1] == 13 || plRow[1] == 15 && plRowT[1] == 15 || plRow[1] == 17 && plRowT[1] == 17)
                        {
                            plY[1] = (plRow[1] * 30) + 75;
                            plCou[1] = 3;
                            plR[1] = plCou[1] % plTR;
                            plLeft[1] = false;
                            plUp[1] = false;
                            plDown[1] = false;
                            plRight[1] = true;
                        }
                    }
                    if (e.KeyData == Keys.NumPad1 && plBoCou[1] > 0 && skPl != 1)
                    {
                        xTemp = Players[1].X + 15;
                        yTemp = Players[1].Y + 15;
                        plBoCou[1] -= 1;
                        AddBomb2();

                    }
                }
                //PLayer 3
                if (plDead[2] == false && plDeath[2] == false && plNum >1)
                {

                    if (e.KeyData == Keys.P && plUp[2] == false)
                    {
                        if (plCol[2] == 1 && plColT[2] == 1 || plCol[2] == 3 && plColT[2] == 3 || plCol[2] == 5 && plColT[2] == 5 || plCol[2] == 7 && plColT[2] == 7 || plCol[2] == 9 && plColT[2] == 9 || plCol[2] == 11 && plColT[2] == 11 || plCol[2] == 13 && plColT[2] == 13 || plCol[2] == 15 && plColT[2] == 15 || plCol[2] == 17 && plColT[2] == 17)
                        {
                            plX[2] = (plCol[2] * 30) + 75;
                            plCou[2] = 9;
                            plR[2] = plCou[2] % plTR;
                            plLeft[2] = false;
                            plUp[2] = true;
                            plDown[2] = false;
                            plRight[2] = false;
                        }
                    }
                    if (e.KeyData == Keys.L && plLeft[2] == false)
                    {
                        if (plRow[2] == 1 && plRowT[2] == 1 || plRow[2] == 3 && plRowT[2] == 3 || plRow[2] == 5 && plRowT[2] == 5 || plRow[2] == 7 && plRowT[2] == 7 || plRow[2] == 9 && plRowT[2] == 9 || plRow[2] == 11 && plRowT[2] == 11 || plRow[2] == 13 && plRowT[2] == 13 || plRow[2] == 15 && plRowT[2] == 15 || plRow[2] == 17 && plRowT[2] == 17)
                        {
                            plY[2] = (plRow[2] * 30) + 75;
                            plCou[2] = 6;
                            plR[2] = plCou[2] % plTR;
                            plUp[2] = false;
                            plDown[2] = false;
                            plRight[2] = false;
                            plLeft[2] = true;
                        }
                    }
                    if (e.KeyData == Keys.OemSemicolon && plDown[2] == false)
                    {
                        if (plCol[2] == 1 && plColT[2] == 1 || plCol[2] == 3 && plColT[2] == 3 || plCol[2] == 5 && plColT[2] == 5 || plCol[2] == 7 && plColT[2] == 7 || plCol[2] == 9 && plColT[2] == 9 || plCol[2] == 11 && plColT[2] == 11 || plCol[2] == 13 && plColT[2] == 13 || plCol[2] == 15 && plColT[2] == 15 || plCol[2] == 17 && plColT[1] == 17)
                        {
                            plX[2] = (plCol[2] * 30) + 75;
                            plCou[2] = 1;
                            plR[2] = plCou[2] % plTR;
                            plLeft[2] = false;
                            plUp[2] = false;
                            plDown[2] = true;
                            plRight[2] = false;
                        }
                    }
                    if (e.KeyData == Keys.OemQuotes && plRight[2] == false)
                    {
                        if (plRow[2] == 1 && plRowT[2] == 1 || plRow[2] == 3 && plRowT[2] == 3 || plRow[2] == 5 && plRowT[2] == 5 || plRow[2] == 7 && plRowT[2] == 7 || plRow[2] == 9 && plRowT[2] == 9 || plRow[2] == 11 && plRowT[2] == 11 || plRow[2] == 13 && plRowT[2] == 13 || plRow[2] == 15 && plRowT[2] == 15 || plRow[2] == 17 && plRowT[2] == 17)
                        {
                            plY[2] = (plRow[2] * 30) + 75;
                            plCou[2] = 3;
                            plR[2] = plCou[2] % plTR;
                            plLeft[2] = false;
                            plUp[2] = false;
                            plDown[2] = false;
                            plRight[2] = true;
                        }
                    }
                    if (e.KeyData == Keys.OemPipe && plBoCou[2] > 0 && skPl != 2)
                    {
                        xTemp = Players[2].X + 15;
                        yTemp = Players[2].Y + 15;
                        plBoCou[2] -= 1;
                        AddBomb3();

                    }
                }
                //Player 4
                if (plDead[3] == false && plDeath[3] == false && plNum > 2)
                {

                    if (e.KeyData == Keys.Y && plUp[3] == false)
                    {
                        if (plCol[3] == 1 && plColT[3] == 1 || plCol[3] == 3 && plColT[3] == 3 || plCol[3] == 5 && plColT[3] == 5 || plCol[3] == 7 && plColT[3] == 7 || plCol[3] == 9 && plColT[3] == 9 || plCol[3] == 11 && plColT[3] == 11 || plCol[3] == 13 && plColT[3] == 13 || plCol[3] == 15 && plColT[3] == 15 || plCol[3] == 17 && plColT[3] == 17)
                        {
                            plX[3] = (plCol[3] * 30) + 75;
                            plCou[3] = 9;
                            plR[3] = plCou[3] % plTR;
                            plLeft[3] = false;
                            plUp[3] = true;
                            plDown[3] = false;
                            plRight[3] = false;
                        }
                    }
                    if (e.KeyData == Keys.G && plLeft[3] == false)
                    {
                        if (plRow[3] == 1 && plRowT[3] == 1 || plRow[3] == 3 && plRowT[3] == 3 || plRow[3] == 5 && plRowT[3] == 5 || plRow[3] == 7 && plRowT[3] == 7 || plRow[3] == 9 && plRowT[3] == 9 || plRow[3] == 11 && plRowT[3] == 11 || plRow[3] == 13 && plRowT[3] == 13 || plRow[3] == 15 && plRowT[3] == 15 || plRow[3] == 17 && plRowT[3] == 17)
                        {
                            plY[3] = (plRow[3] * 30) + 75;
                            plCou[3] = 6;
                            plR[3] = plCou[3] % plTR;
                            plUp[3] = false;
                            plDown[3] = false;
                            plRight[3] = false;
                            plLeft[3] = true;
                        }
                    }
                    if (e.KeyData == Keys.H && plDown[3] == false)
                    {
                        if (plCol[3] == 1 && plColT[3] == 1 || plCol[3] == 3 && plColT[3] == 3 || plCol[3] == 5 && plColT[3] == 5 || plCol[3] == 7 && plColT[3] == 7 || plCol[3] == 9 && plColT[3] == 9 || plCol[3] == 11 && plColT[3] == 11 || plCol[3] == 13 && plColT[3] == 13 || plCol[3] == 15 && plColT[3] == 15 || plCol[3] == 17 && plColT[3] == 17)
                        {
                            plX[3] = (plCol[3] * 30) + 75;
                            plCou[3] = 1;
                            plR[3] = plCou[3] % plTR;
                            plLeft[3] = false;
                            plUp[3] = false;
                            plDown[3] = true;
                            plRight[3] = false;
                        }
                    }
                    if (e.KeyData == Keys.J && plRight[3] == false)
                    {
                        if (plRow[3] == 1 && plRowT[3] == 1 || plRow[3] == 3 && plRowT[3] == 3 || plRow[3] == 5 && plRowT[3] == 5 || plRow[3] == 7 && plRowT[3] == 7 || plRow[3] == 9 && plRowT[3] == 9 || plRow[3] == 11 && plRowT[3] == 11 || plRow[3] == 13 && plRowT[3] == 13 || plRow[3] == 15 && plRowT[3] == 15 || plRow[3] == 17 && plRowT[3] == 17)
                        {
                            plY[3] = (plRow[3] * 30) + 75;
                            plCou[3] = 3;
                            plR[3] = plCou[3] % plTR;
                            plLeft[3] = false;
                            plUp[3] = false;
                            plDown[3] = false;
                            plRight[3] = true;
                        }
                    }
                    if (e.KeyData == Keys.I && plBoCou[3] > 0 && skPl != 3)
                    {
                        xTemp = Players[3].X + 15;
                        yTemp = Players[3].Y + 15;
                        plBoCou[3] -= 1;
                        AddBomb4();

                    }
                }
                //Pause Menu
                if (e.KeyData == Keys.Subtract) { inGameMenu = true; this.Refresh(); }                         
            }
            //Menu Flash Stuff
            if (gameOnOff == false)
            {
                if (pAb == true)
                {
                    pAb = false;
                    this.Refresh();
                }
                if (pAb == false)
                {
                    menTim = 0;
                    dOOa = 255;
                    dOO = new SolidBrush(Color.FromArgb(dOOa, 255, 255, 255));
                }               
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //P1
            if (plDead[0] == false && plDeath[0] == false)
            {
                if (e.KeyData == Keys.W)
                {
                    plUp[0] = false;
                }
                if (e.KeyData == Keys.A)
                {
                    plLeft[0] = false;
                }
                if (e.KeyData == Keys.S)
                {
                    plDown[0] = false;
                }
                if (e.KeyData == Keys.D)
                {
                    plRight[0] = false;
                }
            }
            //P2
            if (plDead[1] == false && plDeath[1] == false)
            {
                if (e.KeyData == Keys.Up)
                {
                    plUp[1] = false;
                }
                if (e.KeyData == Keys.Left)
                {
                    plLeft[1] = false;
                }
                if (e.KeyData == Keys.Down)
                {
                    plDown[1] = false;
                }
                if (e.KeyData == Keys.Right)
                {
                    plRight[1] = false;
                }
            }
            //P3
            if (plDead[2] == false && plDeath[2] == false && plNum > 1)
            {
                if (e.KeyData == Keys.P)
                {
                    plUp[2] = false;
                }
                if (e.KeyData == Keys.L)
                {
                    plLeft[2] = false;
                }
                if (e.KeyData == Keys.OemSemicolon)
                {
                    plDown[2] = false;
                }
                if (e.KeyData == Keys.OemQuotes)
                {
                    plRight[2] = false;
                }
            }
            //P4
            if (plDead[3] == false && plDeath[3] == false && plNum > 2)
            {
                if (e.KeyData == Keys.Y)
                {
                    plUp[3] = false;
                }
                if (e.KeyData == Keys.G)
                {
                    plLeft[3] = false;
                }
                if (e.KeyData == Keys.H)
                {
                    plDown[3] = false;
                }
                if (e.KeyData == Keys.J)
                {
                    plRight[3] = false;
                }
            }
        }

        private void BuildBrick() {         

            //ADD OUTLINERS
                if (row == 0 || row == 18)
                {
                    for (int n = 0; n < size; n++)
                    {
                        brbX.Add(75 + n * brW);
                        brbY.Add(75 + row * brH);
                        brickNB.Add(new Rectangle(brbX[brbCount], brbY[brbCount], brW, brH));

                        brbCount += 1;
                    }
                }
            //BREAKABLE BRICKS
                if (row == 1 || row == 17)
                {
                    for (int n = 0; n < size; n++)
                    {
                        if (bTemp == 0 || bTemp == 18)
                        {
                            brbX.Add(75 + n * brW);
                            brbY.Add(75 + row * brH);
                            brickNB.Add(new Rectangle(brbX[brbCount], brbY[brbCount], brW, brH));

                            brbCount += 1;
                        }
                        else
                            if (bTemp == 3 || bTemp == 4 || bTemp == 5 || bTemp == 6 || bTemp == 7 || bTemp == 8 || bTemp == 10 || bTemp == 11 || bTemp == 12 || bTemp == 13 || bTemp == 14 || bTemp == 15)
                            {
                                brX.Add(75 + n * brW);
                                brY.Add(75 + row * brH);
                                brR.Add(0);
                                brickB.Add(new Rectangle(brX[brCount], brY[brCount], brW, brH));
                                brCount += 1;
                            }
                        //FLOOR
                        flX.Add(75 + n * brW);
                        flY.Add(75 + row * brH);
                        Floor.Add(new Rectangle(flX[fCount], flY[fCount], brW, brH));
                        fCount += 1;
                        bTemp += 1;
                    }
                }
            //GOES BY ROW
                if (row == 4 || row == 12 || row == 14 || row == 6 || row == 10 || row == 8)
                {
                    for (int n = 0; n < size; n++)
                    {
                        if (bTemp == 0 || bTemp == 2 || bTemp == 4 || bTemp == 6 || bTemp == 8 || bTemp == 10 || bTemp == 12 || bTemp == 14 || bTemp == 16 || bTemp == 18)
                        {
                            brbX.Add(75 + n * brW);
                            brbY.Add(75 + row * brH);
                            brickNB.Add(new Rectangle(brbX[brbCount], brbY[brbCount], brW, brH));

                            brbCount += 1;
                        }
                        else
                            if (bTemp != 0 && bTemp != 18)
                            {
                                brX.Add(75 + n * brW);
                                brY.Add(75 + row * brH);
                                brR.Add(0);
                                brickB.Add(new Rectangle(brX[brCount], brY[brCount], brW, brH));
                                brCount += 1;
                            }

                        flX.Add(75 + n * brW);
                        flY.Add(75 + row * brH);
                        Floor.Add(new Rectangle(flX[fCount], flY[fCount], brW, brH));
                        fCount += 1;
                        bTemp += 1;
                    }
                }
                if (row == 2 || row == 16)
                {
                    for (int n = 0; n < size; n++)
                    {
                        if (bTemp == 0 || bTemp == 2 || bTemp == 4 || bTemp == 6 || bTemp == 8 || bTemp == 10 || bTemp == 12 || bTemp == 14 || bTemp == 16 || bTemp == 18)
                        {
                            brbX.Add(75 + n * brW);
                            brbY.Add(75 + row * brH);
                            brickNB.Add(new Rectangle(brbX[brbCount], brbY[brbCount], brW, brH));
                            brbCount += 1;
                        }
                        else
                            if (bTemp != 0 && bTemp != 18 && bTemp != 1 && bTemp != 17)
                            {
                                brX.Add(75 + n * brW);
                                brY.Add(75 + row * brH);
                                brR.Add(0);
                                brickB.Add(new Rectangle(brX[brCount], brY[brCount], brW, brH));
                                brCount += 1;
                            }
                        flX.Add(75 + n * brW);
                        flY.Add(75 + row * brH);
                        Floor.Add(new Rectangle(flX[fCount], flY[fCount], brW, brH));
                        fCount += 1;
                        bTemp += 1;
                    }
                }
                if (row == 9)
                {
                    for (int n = 0; n < size; n++)
                    {
                        if (bTemp == 0 || bTemp == 18)
                        {
                            brbX.Add(75 + n * brW);
                            brbY.Add(75 + row * brH);
                            brickNB.Add(new Rectangle(brbX[brbCount], brbY[brbCount], brW, brH));
                            brbCount += 1;
                        }
                        else
                            if (bTemp != 0 && bTemp != 1 && bTemp != 17 && bTemp != 18)
                            {
                                brX.Add(75 + n * brW);
                                brY.Add(75 + row * brH);
                                brR.Add(0);
                                brickB.Add(new Rectangle(brX[brCount], brY[brCount], brW, brH));
                                brCount += 1;
                            }
                        flX.Add(75 + n * brW);
                        flY.Add(75 + row * brH);
                        Floor.Add(new Rectangle(flX[fCount], flY[fCount], brW, brH));
                        fCount += 1;
                        bTemp += 1;
                    }
                }
                if (row == 3 || row == 5 || row == 7 || row == 11 || row == 13 || row == 15)
                {
                    for (int n = 0; n < size; n++)
                    {
                        if (bTemp == 0 || bTemp == 18)
                        {
                            brbX.Add(75 + n * brW);
                            brbY.Add(75 + row * brH);
                            brickNB.Add(new Rectangle(brbX[brbCount], brbY[brbCount], brW, brH));
                            brbCount += 1;
                        }
                        else
                            if (bTemp != 0 && bTemp != 18)
                            {
                                brX.Add(75 + n * brW);
                                brY.Add(75 + row * brH);
                                brR.Add(0);
                                brickB.Add(new Rectangle(brX[brCount], brY[brCount], brW, brH));
                                brCount += 1;
                            }
                        flX.Add(75 + n * brW);
                        flY.Add(75 + row * brH);
                        Floor.Add(new Rectangle(flX[fCount], flY[fCount], brW, brH));
                        fCount += 1;
                        bTemp += 1;
                    }
                }          
        }        

        private void powerSpawn() 
        {

            //RNG FOR IF ONE SPAWNS
            ppTemp = rdn.Next(0, puSpawnRate);
            if (ppTemp <= 0)
            {
                pTemp.Add(0);
                powerVis.Add(false);               
                pTemp[pTemp.Count - 1] = rdn.Next(0, 100);  
                //IF ONE DOES THEN RANDOM POWERUP
                if (pTemp.Count > 0)
                {
                    if (skull != -1 && pTemp[pTemp.Count - 1] >= 70 && pTemp[pTemp.Count - 1] <= 84 && ppTemp == 1)
                    {
                        while (pTemp[pTemp.Count - 1] >= 70 && pTemp[pTemp.Count - 1] <= 84)
                        {
                            pTemp[pTemp.Count - 1] = rdn.Next(0, 101);
                        }
                    }
                }
                //skull = 0;            
                powerVis[pTemp.Count - 1] = true;
                if (pTemp[pTemp.Count - 1] >= 0 && pTemp[pTemp.Count - 1] <= 4)
                {
                    pR.Add(1);
                    pC.Add(3);
                    power.Add(new Rectangle(brX[y] + 2, brY[y] + 2, pW, pH));
                }
                else
                    if (pTemp[pTemp.Count - 1] >= 5 && pTemp[pTemp.Count - 1] <= 19 || pTemp[pTemp.Count - 1] >= 90 && pTemp[pTemp.Count - 1] <= 100)
                    {
                        pR.Add(0);
                        pC.Add(0);
                        power.Add(new Rectangle(brX[y] + 2, brY[y] + 2, pW, pH));
                    }
                    else
                        if (pTemp[pTemp.Count - 1] >= 20 && pTemp[pTemp.Count - 1] <= 34)
                        {
                            pR.Add(1);
                            pC.Add(1);
                            power.Add(new Rectangle(brX[y] + 2, brY[y] + 2, pW, pH));
                        }
                        else
                            if (pTemp[pTemp.Count - 1] >= 35 && pTemp[pTemp.Count - 1] <= 49)
                            {
                                pR.Add(0);
                                pC.Add(1);
                                power.Add(new Rectangle(brX[y] + 2, brY[y] + 2, pW, pH)); 
                            }
                            else
                                if (pTemp[pTemp.Count - 1] >= 50 && pTemp[pTemp.Count - 1] <= 54)
                                {
                                    pR.Add(0);
                                    pC.Add(3);
                                    power.Add(new Rectangle(brX[y] + 2, brY[y] + 2, pW, pH));
                                }
                                else
                                    if (pTemp[pTemp.Count - 1] >= 60 && pTemp[pTemp.Count - 1] <= 64)
                                    {
                                        pR.Add(0);
                                        pC.Add(3);
                                        power.Add(new Rectangle(brX[y] + 2, brY[y] + 2, pW, pH));
                                    }
                                    else
                                        if (pTemp[pTemp.Count - 1] >= 70 && pTemp[pTemp.Count - 1] <= 84 && skull == -1)
                                        {
                                            skull = pTemp.Count - 1;
                                            pR.Add(0);
                                            pC.Add(2);
                                            power.Add(new Rectangle(brX[y] + 2, brY[y] + 2, pW, pH));
                                        }
                                        else
                                            if (pTemp[pTemp.Count - 1] >= 84 && pTemp[pTemp.Count - 1] <= 89)
                                            {
                                                pR.Add(1);
                                                pC.Add(2);
                                                power.Add(new Rectangle(brX[y] + 2, brY[y] + 2, pW, pH));
                                            }
                                            else                                                
                                                {                                                    
                                                    /*pR.RemoveAt(pTemp.Count - 1);
                                                    pC.RemoveAt(pTemp.Count - 1);*/                                                                                                   
                                                    powerVis.RemoveAt(pTemp.Count - 1); 
                                                pTemp.RemoveAt(pTemp.Count - 1);    
                                                }               
            }
            //REMOVES BROKEN BRICK
            brR.RemoveAt(y);
            brCou.RemoveAt(y);
            brX.RemoveAt(y);
            brY.RemoveAt(y);
            brickB.RemoveAt(y);
            breaker.RemoveAt(y);          
        }

        private void tmrBomb_Tick(object sender, EventArgs e)
        {
            //COUNTDOWN AND SOUND FOR BOMB
            for (int n = 0; n < bomb.Count; n++)
            {               
                  boCou[n] += 1;
                    boC[n] = boCou[n] % boTC;
                    if (boCou[n] == 4)
                    {
                        if (bWP == 1)
                        {
                            wpB1.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\EXPC.mp3";
                            bWP += 1;
                        }
                        else
                            if (bWP == 2)
                            {
                                wpB2.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\EXPC.mp3";
                                bWP += 1;
                            }
                            else
                                if (bWP == 3)
                                {
                                    wpB3.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\EXPC.mp3";
                                    bWP = 1;
                                }
                    }
                if (boCou[n] >= boTC)
                {                                  
                    if (boR[n] == 0 && plDead[0] == false && plDeath[0] == false)
                    {
                        eTemp = n;
                        boomboom1();
                    }
                    else
                        if (boR[n] == 1 && plDead[1] == false && plDeath[1] == false)
                        {
                            eTemp = n;
                            boomboom2();
                        }
                        else
                            if (boR[n] == 2 && plDead[2] == false && plDeath[2] == false)
                            {
                                eTemp = n;
                                boomboom3();
                            }
                            else
                                if (boR[n] == 3 && plDead[3] == false && plDeath[3] == false)
                                {
                                    eTemp = n;
                                    boomboom4();
                                }
                                else
                                {                                    
                                    puE.RemoveAt(n);
                                    puEE.RemoveAt(n);
                                    boX.RemoveAt(n);
                                    boY.RemoveAt(n);
                                    boCou.RemoveAt(n);
                                    boC.RemoveAt(n);
                                    boR.RemoveAt(n);
                                    bomb.RemoveAt(n);
                                }                
                }
            }            
        }

        private void AddBomb1() 
        {
            //ADDS BOMB BASED OFF OF P1 STATS            
            yPosB = (yTemp - 75) / 30;
            xPosB = (xTemp - 75) / 30;            
                boX.Add(xPosB * 30 + 82);
                boY.Add(yPosB * 30 + 82);
                boCou.Add(0);
                boC.Add(0);
                boR.Add(0);
                if (puBB[0] == true) { puEE.Add(true); puE.Add(false); } else if (puB[0] == true) { puEE.Add(false); puE.Add(true); } else { puEE.Add(false); puE.Add(false); } 
                bomb.Add(new Rectangle(boX[boX.Count - 1], boY[boY.Count - 1], boW, boH));              
                for (int n = 0; n < bomb.Count; n++)
                {
                    for (int i = 0; i < bomb.Count; i++)
                    {
                        if (n != i)
                        {
                            if (bomb[i].IntersectsWith(bomb[n]))
                            {
                                boX.RemoveAt(i);
                                boY.RemoveAt(i);
                                boCou.RemoveAt(i);
                                boC.RemoveAt(i);
                                bomb.RemoveAt(i);                                
                            }
                        }
                    }                    
                }            
        }

        private void AddBomb2()
        {
            //ADDS BOMB BASED OFF OF P2 STATS    
            yPosB = (yTemp - 75) / 30;
            xPosB = (xTemp - 75) / 30;
            boX.Add(xPosB * 30 + 82);
            boY.Add(yPosB * 30 + 82);
            boCou.Add(0);
            boC.Add(0);
            boR.Add(1);
            if (puBB[1] == true) { puEE.Add(true); puE.Add(false); } else if (puB[1] == true) { puEE.Add(false); puE.Add(true); } else { puEE.Add(false); puE.Add(false); }
            bomb.Add(new Rectangle(boX[boX.Count - 1], boY[boY.Count - 1], boW, boH));
            for (int n = 0; n < bomb.Count; n++)
            {
                for (int i = 0; i < bomb.Count; i++)
                {
                    if (n != i)
                    {
                        if (bomb[i].IntersectsWith(bomb[n]))
                        {
                            boX.RemoveAt(i);
                            boY.RemoveAt(i);
                            boCou.RemoveAt(i);
                            boC.RemoveAt(i);
                            bomb.RemoveAt(i);                            
                        }
                    }
                }
            }
        }

        private void AddBomb3()
        {
            //ADDS BOMB BASED OFF OF P3 STATS  
            yPosB = (yTemp - 75) / 30;
            xPosB = (xTemp - 75) / 30;
            boX.Add(xPosB * 30 + 82);
            boY.Add(yPosB * 30 + 82);
            boCou.Add(0);
            boC.Add(0);
            boR.Add(2);
            if (puBB[2] == true) { puEE.Add(true); puE.Add(false); } else if (puB[2] == true) { puEE.Add(false); puE.Add(true); } else { puEE.Add(false); puE.Add(false); }
            bomb.Add(new Rectangle(boX[boX.Count - 1], boY[boY.Count - 1], boW, boH));
            for (int n = 0; n < bomb.Count; n++)
            {
                for (int i = 0; i < bomb.Count; i++)
                {
                    if (n != i)
                    {
                        if (bomb[i].IntersectsWith(bomb[n]))
                        {
                            boX.RemoveAt(i);
                            boY.RemoveAt(i);
                            boCou.RemoveAt(i);
                            boC.RemoveAt(i);
                            bomb.RemoveAt(i);
                        }
                    }
                }
            }
        }

        private void AddBomb4()
        {
            //ADDS BOMB BASED OFF OF P4 STATS    
            yPosB = (yTemp - 75) / 30;
            xPosB = (xTemp - 75) / 30;
            boX.Add(xPosB * 30 + 82);
            boY.Add(yPosB * 30 + 82);
            boCou.Add(0);
            boC.Add(0);
            boR.Add(3);
            if (puBB[3] == true) { puEE.Add(true); puE.Add(false); } else if (puB[3] == true) { puEE.Add(false); puE.Add(true); } else { puEE.Add(false); puE.Add(false); }
            bomb.Add(new Rectangle(boX[boX.Count - 1], boY[boY.Count - 1], boW, boH));
            for (int n = 0; n < bomb.Count; n++)
            {
                for (int i = 0; i < bomb.Count; i++)
                {
                    if (n != i)
                    {
                        if (bomb[i].IntersectsWith(bomb[n]))
                        {
                            boX.RemoveAt(i);
                            boY.RemoveAt(i);
                            boCou.RemoveAt(i);
                            boC.RemoveAt(i);
                            bomb.RemoveAt(i);
                        }
                    }
                }
            }
        }        

        private void boomboom1() 
        {
            /*
            Didnt bother commenting this. I'll give a little run down of whats happening.
             * to Start it sets down the centre
             * then it adds each side one at a time, if the bomb is biogger than 1, then it adds each colom and each row one at a time.
             * for each one before it goes to the next, it checks for a brick, if it hits one it removes that one and stop sthe rest after it.
             * for each of these as well, they destroy powerups if they collide
             * for the half pu bomb, it only stops if it hits an indistructable wall
             * for the full pu it only stops for the outline bricks
             * int the end it adds the corner peices to make it look complete
             * its the same for all four, just had to make four so the values didnt get mixed up
            */

            expX.Add(boX[eTemp] - 7);
            expY.Add(boY[eTemp] - 7);
            expR.Add(0);
            expC.Add(0);
            expCou.Add(0);
            expRecCou.Add(0);
            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

            stU = false;
            stD = false;
            stL = false;
            stR = false;           

            posXTemp = expX[exp.Count - 1];
            posYTemp = expY[exp.Count - 1];

            expRecCou[expRecCou.Count - 1] += 1;

            if (puEE[eTemp] == false && puE[eTemp] == false)
            {
              
                if (eSize[0] > 1)
                {
                    for (int i = 1; i < eSize[0]; i++)
                    {
                        if (stU == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp - i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }
                        if (stU == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stU = true;
                                    breaker[n] = true;
                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        if (stU == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stU = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stU = true;
                                expC[expC.Count - 1] = 3;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }



                        if (stD == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp + i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stD == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stD == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stD = true;

                                expC[expC.Count - 1] = 4;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stR == false)
                        {
                            expX.Add(posXTemp + i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stR == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stR == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stR = true;

                                expC[expC.Count - 1] = 5;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stL == false)
                        {
                            expX.Add(posXTemp - i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stL == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stL == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stL = true;
                                expC[expC.Count - 1] = 6;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                    }
                }



                if (stU == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp - eSize[0] * expH);
                    expC.Add(3);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stU == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stU == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stU = true;
                        /* expX.RemoveAt(expX.Count - 1);
                         expY.RemoveAt(expY.Count - 1);
                         expC.RemoveAt(expC.Count - 1);
                         exp.RemoveAt(exp.Count - 1);
                         expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stD == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp + eSize[0] * expH);
                    expC.Add(4);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stD == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stD = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stD == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stD = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stD = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stR == false)
                {
                    expX.Add(posXTemp + eSize[0] * expW);
                    expY.Add(posYTemp);
                    expC.Add(5);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stR == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stR = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stR == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stR = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stR = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stL == false)
                {
                    expX.Add(posXTemp - eSize[0] * expW);
                    expY.Add(posYTemp);
                    expC.Add(6);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }


                if (stL == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stL = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stL == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stL = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }

                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stL = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1; */
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }
            }
            else
                if (puEE[eTemp] == true)
            {
              
                if (eSize[0] > 1)
                {
                    for (int i = 1; i < eSize[0]; i++)
                    {
                        if (stU == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp - i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }
                        if (stU == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                   
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stU == false)
                        {
                            for (int n = 1; n < nbCount.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                {
                                    stU = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }



                        if (stD == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp + i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stD == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stD == false)
                        {
                            for (int n = 1; n < nbCount.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                            

                                
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stR == false)
                        {
                            expX.Add(posXTemp + i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stR == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stR == false)
                        {
                            for (int n = 1; n < nbCount.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                               
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stL == false)
                        {
                            expX.Add(posXTemp - i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stL == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                   
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stL == false)
                        {
                            for (int n = 1; n < nbCount.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                               
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                    }
                }



                if (stU == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp - eSize[0] * expH);
                    expC.Add(3);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stU == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                           
                            breaker[n] = true;

                        }
                    }
                }
                if (stU == false)
                {
                    for (int n = 1; n < nbCount.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        
                        /* expX.RemoveAt(expX.Count - 1);
                         expY.RemoveAt(expY.Count - 1);
                         expC.RemoveAt(expC.Count - 1);
                         exp.RemoveAt(exp.Count - 1);
                         expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stD == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp + eSize[0] * expH);
                    expC.Add(4);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stD == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            
                            breaker[n] = true;

                        }
                    }
                }
                if (stD == false)
                {
                    for (int n = 1; n < nbCount.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stR == false)
                {
                    expX.Add(posXTemp + eSize[0] * expW);
                    expY.Add(posYTemp);
                    expC.Add(5);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stR == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            
                            breaker[n] = true;

                        }
                    }
                }
                if (stR == false)
                {
                    for (int n = 1; n < nbCount.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                       
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stL == false)
                {
                    expX.Add(posXTemp - eSize[0] * expW);
                    expY.Add(posYTemp);
                    expC.Add(6);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }


                if (stL == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                           
                            breaker[n] = true;

                        }
                    }
                }
                if (stL == false)
                {
                    for (int n = 1; n < nbCount.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }

                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                       
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1; */
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }
            }
                else
                    if (puE[eTemp] == true)
                    {
                     
                        if (eSize[0] > 1)
                        {
                            for (int i = 1; i < eSize[0]; i++)
                            {
                                if (stU == false)
                                {
                                    expX.Add(posXTemp);
                                    expY.Add(posYTemp - i * expH);
                                    expC.Add(1);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }
                                if (stU == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {
                                            
                                            breaker[n] = true;
                                          

                                        }
                                    }
                                }
                                if (stU == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stU = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {

                                       
                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }



                                if (stD == false)
                                {
                                    expX.Add(posXTemp);
                                    expY.Add(posYTemp + i * expH);
                                    expC.Add(1);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stD == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {
                                    

                                         
                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stD == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stD = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {

                                       
                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }


                                if (stR == false)
                                {
                                    expX.Add(posXTemp + i * expW);
                                    expY.Add(posYTemp);
                                    expC.Add(2);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stR == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {
                                     

                                           
                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stR == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stR = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {

                                       
                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }


                                if (stL == false)
                                {
                                    expX.Add(posXTemp - i * expW);
                                    expY.Add(posYTemp);
                                    expC.Add(2);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stL == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {
                                          

                                        
                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stL == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stL = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {

                                       
                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }

                            }
                        }



                        if (stU == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp - eSize[0] * expH);
                            expC.Add(3);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stU == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stU = true;

                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stU == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stU = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stU = true;
                                /* expX.RemoveAt(expX.Count - 1);
                                 expY.RemoveAt(expY.Count - 1);
                                 expC.RemoveAt(expC.Count - 1);
                                 exp.RemoveAt(exp.Count - 1);
                                 expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stD == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp + eSize[0] * expH);
                            expC.Add(4);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stD == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stD = true;

                                   
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stD == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stD = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stR == false)
                        {
                            expX.Add(posXTemp + eSize[0] * expW);
                            expY.Add(posYTemp);
                            expC.Add(5);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stR == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stR = true;

                                    
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stR == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stR = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stL == false)
                        {
                            expX.Add(posXTemp - eSize[0] * expW);
                            expY.Add(posYTemp);
                            expC.Add(6);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }


                        if (stL == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stL = true;

                                    
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stL == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }

                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stL = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1; */
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }
                    }



            plBoCou[0] += 1;
            puE.RemoveAt(eTemp);
            puEE.RemoveAt(eTemp);
            boX.RemoveAt(eTemp);
            boY.RemoveAt(eTemp);
            boCou.RemoveAt(eTemp);
            boC.RemoveAt(eTemp);
            boR.RemoveAt(eTemp);
            bomb.RemoveAt(eTemp);
            
            DrawBackGround();
        }

        private void boomboom2()
        {


            

            expX.Add(boX[eTemp] - 7);
            expY.Add(boY[eTemp] - 7);
            expR.Add(0);
            expC.Add(0);
            expCou.Add(0);
            expRecCou.Add(0);
            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

            stU = false;
            stD = false;
            stL = false;
            stR = false;

            posXTemp = expX[exp.Count - 1];
            posYTemp = expY[exp.Count - 1];

            expRecCou[expRecCou.Count - 1] += 1;

            if (puE[eTemp] == false && puEE[eTemp] == false)
            {

                if (eSize[1] > 0)
                {
                    for (int i = 1; i < eSize[1]; i++)
                    {
                        if (stU == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp - i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }
                        if (stU == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stU = true;
                                    breaker[n] = true;
                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        if (stU == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stU = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stU = true;
                                expC[expC.Count - 1] = 3;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }



                        if (stD == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp + i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stD == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stD == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stD = true;

                                expC[expC.Count - 1] = 4;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stR == false)
                        {
                            expX.Add(posXTemp + i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stR == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stR == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stR = true;

                                expC[expC.Count - 1] = 5;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stL == false)
                        {
                            expX.Add(posXTemp - i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stL == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stL == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stL = true;
                                expC[expC.Count - 1] = 6;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                    }
                }



                if (stU == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp - eSize[1] * expH);
                    expC.Add(3);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stU == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stU == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stU = true;
                        /* expX.RemoveAt(expX.Count - 1);
                         expY.RemoveAt(expY.Count - 1);
                         expC.RemoveAt(expC.Count - 1);
                         exp.RemoveAt(exp.Count - 1);
                         expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stD == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp + eSize[1] * expH);
                    expC.Add(4);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stD == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stD = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stD == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stD = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stD = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stR == false)
                {
                    expX.Add(posXTemp + eSize[1] * expW);
                    expY.Add(posYTemp);
                    expC.Add(5);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stR == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stR = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stR == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stR = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stR = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stL == false)
                {
                    expX.Add(posXTemp - eSize[1] * expW);
                    expY.Add(posYTemp);
                    expC.Add(6);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }


                if (stL == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stL = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stL == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stL = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }

                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stL = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1; */
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }
            }
            else
                if (puEE[eTemp] == true)
                {

                    if (eSize[1] > 0)
                    {
                        for (int i = 1; i < eSize[1]; i++)
                        {
                            if (stU == false)
                            {
                                expX.Add(posXTemp);
                                expY.Add(posYTemp - i * expH);
                                expC.Add(1);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }
                            if (stU == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stU == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stU = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {


                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }



                            if (stD == false)
                            {
                                expX.Add(posXTemp);
                                expY.Add(posYTemp + i * expH);
                                expC.Add(1);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }

                            if (stD == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stD == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stD = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {




                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }


                            if (stR == false)
                            {
                                expX.Add(posXTemp + i * expW);
                                expY.Add(posYTemp);
                                expC.Add(2);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }

                            if (stR == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stR == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stR = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {


                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }


                            if (stL == false)
                            {
                                expX.Add(posXTemp - i * expW);
                                expY.Add(posYTemp);
                                expC.Add(2);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }

                            if (stL == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stL == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stL = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {


                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }

                        }
                    }



                    if (stU == false)
                    {
                        expX.Add(posXTemp);
                        expY.Add(posYTemp - eSize[1] * expH);
                        expC.Add(3);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }

                    if (stU == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stU == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }
                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /* expX.RemoveAt(expX.Count - 1);
                             expY.RemoveAt(expY.Count - 1);
                             expC.RemoveAt(expC.Count - 1);
                             exp.RemoveAt(exp.Count - 1);
                             expRecCou[expRecCou.Count - 1] -= 1;*/
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }

                    if (stD == false)
                    {
                        expX.Add(posXTemp);
                        expY.Add(posYTemp + eSize[1] * expH);
                        expC.Add(4);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }

                    if (stD == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stD == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }
                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /*expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;*/
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }

                    if (stR == false)
                    {
                        expX.Add(posXTemp + eSize[1] * expW);
                        expY.Add(posYTemp);
                        expC.Add(5);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }

                    if (stR == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stR == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }
                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /*expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;*/
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }

                    if (stL == false)
                    {
                        expX.Add(posXTemp - eSize[1] * expW);
                        expY.Add(posYTemp);
                        expC.Add(6);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }


                    if (stL == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stL == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }

                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /*expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1; */
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }
                }
                else
                    if (puE[eTemp] == true)
                    {

                        if (eSize[1] > 0)
                        {
                            for (int i = 1; i < eSize[1]; i++)
                            {
                                if (stU == false)
                                {
                                    expX.Add(posXTemp);
                                    expY.Add(posYTemp - i * expH);
                                    expC.Add(1);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }
                                if (stU == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {

                                            breaker[n] = true;


                                        }
                                    }
                                }
                                if (stU == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stU = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }



                                if (stD == false)
                                {
                                    expX.Add(posXTemp);
                                    expY.Add(posYTemp + i * expH);
                                    expC.Add(1);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stD == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {



                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stD == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stD = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }


                                if (stR == false)
                                {
                                    expX.Add(posXTemp + i * expW);
                                    expY.Add(posYTemp);
                                    expC.Add(2);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stR == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {



                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stR == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stR = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }


                                if (stL == false)
                                {
                                    expX.Add(posXTemp - i * expW);
                                    expY.Add(posYTemp);
                                    expC.Add(2);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stL == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {



                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stL == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stL = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }

                            }
                        }



                        if (stU == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp - eSize[1] * expH);
                            expC.Add(3);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stU == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stU = true;

                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stU == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stU = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stU = true;
                                /* expX.RemoveAt(expX.Count - 1);
                                 expY.RemoveAt(expY.Count - 1);
                                 expC.RemoveAt(expC.Count - 1);
                                 exp.RemoveAt(exp.Count - 1);
                                 expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stD == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp + eSize[1] * expH);
                            expC.Add(4);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stD == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stD = true;


                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stD == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stD = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stR == false)
                        {
                            expX.Add(posXTemp + eSize[1] * expW);
                            expY.Add(posYTemp);
                            expC.Add(5);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stR == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stR = true;


                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stR == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stR = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stL == false)
                        {
                            expX.Add(posXTemp - eSize[1] * expW);
                            expY.Add(posYTemp);
                            expC.Add(6);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }


                        if (stL == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stL = true;


                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stL == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }

                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stL = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1; */
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }
                    }



            plBoCou[1] += 1;
            puE.RemoveAt(eTemp);
            puEE.RemoveAt(eTemp);
            boX.RemoveAt(eTemp);
            boY.RemoveAt(eTemp);
            boCou.RemoveAt(eTemp);
            boC.RemoveAt(eTemp);
            boR.RemoveAt(eTemp);
            bomb.RemoveAt(eTemp);
           
            DrawBackGround();
        }

        private void boomboom3()
        {




            expX.Add(boX[eTemp] - 7);
            expY.Add(boY[eTemp] - 7);
            expR.Add(0);
            expC.Add(0);
            expCou.Add(0);
            expRecCou.Add(0);
            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

            stU = false;
            stD = false;
            stL = false;
            stR = false;

            posXTemp = expX[exp.Count - 1];
            posYTemp = expY[exp.Count - 1];

            expRecCou[expRecCou.Count - 1] += 1;

            if (puE[eTemp] == false && puEE[eTemp] == false)
            {

                if (eSize[2] > 0)
                {
                    for (int i = 1; i < eSize[2]; i++)
                    {
                        if (stU == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp - i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }
                        if (stU == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stU = true;
                                    breaker[n] = true;
                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        if (stU == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stU = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stU = true;
                                expC[expC.Count - 1] = 3;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }



                        if (stD == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp + i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stD == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stD == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stD = true;

                                expC[expC.Count - 1] = 4;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stR == false)
                        {
                            expX.Add(posXTemp + i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stR == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stR == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stR = true;

                                expC[expC.Count - 1] = 5;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stL == false)
                        {
                            expX.Add(posXTemp - i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stL == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stL == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stL = true;
                                expC[expC.Count - 1] = 6;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                    }
                }



                if (stU == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp - eSize[2] * expH);
                    expC.Add(3);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stU == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stU == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stU = true;
                        /* expX.RemoveAt(expX.Count - 1);
                         expY.RemoveAt(expY.Count - 1);
                         expC.RemoveAt(expC.Count - 1);
                         exp.RemoveAt(exp.Count - 1);
                         expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stD == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp + eSize[2] * expH);
                    expC.Add(4);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stD == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stD = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stD == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stD = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stD = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stR == false)
                {
                    expX.Add(posXTemp + eSize[2] * expW);
                    expY.Add(posYTemp);
                    expC.Add(5);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stR == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stR = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stR == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stR = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stR = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stL == false)
                {
                    expX.Add(posXTemp - eSize[2] * expW);
                    expY.Add(posYTemp);
                    expC.Add(6);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }


                if (stL == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stL = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stL == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stL = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }

                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stL = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1; */
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }
            }
            else
                if (puEE[eTemp] == true)
                {

                    if (eSize[2] > 0)
                    {
                        for (int i = 1; i < eSize[2]; i++)
                        {
                            if (stU == false)
                            {
                                expX.Add(posXTemp);
                                expY.Add(posYTemp - i * expH);
                                expC.Add(1);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }
                            if (stU == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stU == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stU = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {


                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }



                            if (stD == false)
                            {
                                expX.Add(posXTemp);
                                expY.Add(posYTemp + i * expH);
                                expC.Add(1);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }

                            if (stD == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stD == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stD = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {




                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }


                            if (stR == false)
                            {
                                expX.Add(posXTemp + i * expW);
                                expY.Add(posYTemp);
                                expC.Add(2);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }

                            if (stR == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stR == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stR = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {


                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }


                            if (stL == false)
                            {
                                expX.Add(posXTemp - i * expW);
                                expY.Add(posYTemp);
                                expC.Add(2);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }

                            if (stL == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stL == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stL = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {


                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }

                        }
                    }



                    if (stU == false)
                    {
                        expX.Add(posXTemp);
                        expY.Add(posYTemp - eSize[2] * expH);
                        expC.Add(3);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }

                    if (stU == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stU == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }
                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /* expX.RemoveAt(expX.Count - 1);
                             expY.RemoveAt(expY.Count - 1);
                             expC.RemoveAt(expC.Count - 1);
                             exp.RemoveAt(exp.Count - 1);
                             expRecCou[expRecCou.Count - 1] -= 1;*/
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }

                    if (stD == false)
                    {
                        expX.Add(posXTemp);
                        expY.Add(posYTemp + eSize[2] * expH);
                        expC.Add(4);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }

                    if (stD == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stD == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }
                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /*expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;*/
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }

                    if (stR == false)
                    {
                        expX.Add(posXTemp + eSize[2] * expW);
                        expY.Add(posYTemp);
                        expC.Add(5);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }

                    if (stR == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stR == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }
                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /*expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;*/
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }

                    if (stL == false)
                    {
                        expX.Add(posXTemp - eSize[2] * expW);
                        expY.Add(posYTemp);
                        expC.Add(6);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }


                    if (stL == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stL == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }

                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /*expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1; */
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }
                }
                else
                    if (puE[eTemp] == true)
                    {

                        if (eSize[2] > 0)
                        {
                            for (int i = 1; i < eSize[2]; i++)
                            {
                                if (stU == false)
                                {
                                    expX.Add(posXTemp);
                                    expY.Add(posYTemp - i * expH);
                                    expC.Add(1);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }
                                if (stU == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {

                                            breaker[n] = true;


                                        }
                                    }
                                }
                                if (stU == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stU = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }



                                if (stD == false)
                                {
                                    expX.Add(posXTemp);
                                    expY.Add(posYTemp + i * expH);
                                    expC.Add(1);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stD == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {



                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stD == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stD = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }


                                if (stR == false)
                                {
                                    expX.Add(posXTemp + i * expW);
                                    expY.Add(posYTemp);
                                    expC.Add(2);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stR == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {



                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stR == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stR = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }


                                if (stL == false)
                                {
                                    expX.Add(posXTemp - i * expW);
                                    expY.Add(posYTemp);
                                    expC.Add(2);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stL == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {



                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stL == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stL = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }

                            }
                        }



                        if (stU == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp - eSize[2] * expH);
                            expC.Add(3);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stU == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stU = true;

                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stU == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stU = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stU = true;
                                /* expX.RemoveAt(expX.Count - 1);
                                 expY.RemoveAt(expY.Count - 1);
                                 expC.RemoveAt(expC.Count - 1);
                                 exp.RemoveAt(exp.Count - 1);
                                 expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stD == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp + eSize[2] * expH);
                            expC.Add(4);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stD == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stD = true;


                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stD == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stD = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stR == false)
                        {
                            expX.Add(posXTemp + eSize[2] * expW);
                            expY.Add(posYTemp);
                            expC.Add(5);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stR == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stR = true;


                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stR == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stR = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stL == false)
                        {
                            expX.Add(posXTemp - eSize[2] * expW);
                            expY.Add(posYTemp);
                            expC.Add(6);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }


                        if (stL == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stL = true;


                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stL == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }

                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stL = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1; */
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }
                    }



            plBoCou[2] += 1;
            puE.RemoveAt(eTemp);
            puEE.RemoveAt(eTemp);
            boX.RemoveAt(eTemp);
            boY.RemoveAt(eTemp);
            boCou.RemoveAt(eTemp);
            boC.RemoveAt(eTemp);
            boR.RemoveAt(eTemp);
            bomb.RemoveAt(eTemp);

            DrawBackGround();
        }

        private void boomboom4()
        {




            expX.Add(boX[eTemp] - 7);
            expY.Add(boY[eTemp] - 7);
            expR.Add(0);
            expC.Add(0);
            expCou.Add(0);
            expRecCou.Add(0);
            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

            stU = false;
            stD = false;
            stL = false;
            stR = false;

            posXTemp = expX[exp.Count - 1];
            posYTemp = expY[exp.Count - 1];

            expRecCou[expRecCou.Count - 1] += 1;

            if (puE[eTemp] == false && puEE[eTemp] == false)
            {

                if (eSize[3] > 0)
                {
                    for (int i = 1; i < eSize[3]; i++)
                    {
                        if (stU == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp - i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }
                        if (stU == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stU = true;
                                    breaker[n] = true;
                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        if (stU == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stU = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stU = true;
                                expC[expC.Count - 1] = 3;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }



                        if (stD == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp + i * expH);
                            expC.Add(1);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stD == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stD == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stD = true;

                                expC[expC.Count - 1] = 4;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stR == false)
                        {
                            expX.Add(posXTemp + i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stR == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stR == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stR = true;

                                expC[expC.Count - 1] = 5;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }


                        if (stL == false)
                        {
                            expX.Add(posXTemp - i * expW);
                            expY.Add(posYTemp);
                            expC.Add(2);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stL == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;
                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stL == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stL = true;
                                expC[expC.Count - 1] = 6;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                    }
                }



                if (stU == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp - eSize[3] * expH);
                    expC.Add(3);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stU == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stU == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stU = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stU = true;
                        /* expX.RemoveAt(expX.Count - 1);
                         expY.RemoveAt(expY.Count - 1);
                         expC.RemoveAt(expC.Count - 1);
                         exp.RemoveAt(exp.Count - 1);
                         expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stD == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp + eSize[3] * expH);
                    expC.Add(4);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stD == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stD = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stD == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stD = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stD = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stR == false)
                {
                    expX.Add(posXTemp + eSize[3] * expW);
                    expY.Add(posYTemp);
                    expC.Add(5);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stR == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stR = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stR == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stR = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }
                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stR = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1;*/
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }

                if (stL == false)
                {
                    expX.Add(posXTemp - eSize[3] * expW);
                    expY.Add(posYTemp);
                    expC.Add(6);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }


                if (stL == false)
                {
                    for (int n = 0; n < brickB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                        {
                            stL = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;
                            breaker[n] = true;

                        }
                    }
                }
                if (stL == false)
                {
                    for (int n = 1; n < brickNB.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                        {
                            stL = true;

                            expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;

                        }
                    }
                }

                for (int n = 0; n < power.Count; n++)
                {
                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                    {

                        stL = true;
                        /*expX.RemoveAt(expX.Count - 1);
                        expY.RemoveAt(expY.Count - 1);
                        expC.RemoveAt(expC.Count - 1);
                        exp.RemoveAt(exp.Count - 1);
                        expRecCou[expRecCou.Count - 1] -= 1; */
                        pR.RemoveAt(n);
                        pC.RemoveAt(n);
                        pTemp.RemoveAt(n);
                        powerVis.RemoveAt(n);
                        power.RemoveAt(n);


                    }
                }
            }
            else
                if (puEE[eTemp] == true)
                {

                    if (eSize[3] > 0)
                    {
                        for (int i = 1; i < eSize[3]; i++)
                        {
                            if (stU == false)
                            {
                                expX.Add(posXTemp);
                                expY.Add(posYTemp - i * expH);
                                expC.Add(1);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }
                            if (stU == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stU == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stU = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {


                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }



                            if (stD == false)
                            {
                                expX.Add(posXTemp);
                                expY.Add(posYTemp + i * expH);
                                expC.Add(1);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }

                            if (stD == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stD == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stD = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {




                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }


                            if (stR == false)
                            {
                                expX.Add(posXTemp + i * expW);
                                expY.Add(posYTemp);
                                expC.Add(2);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }

                            if (stR == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stR == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stR = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {


                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }


                            if (stL == false)
                            {
                                expX.Add(posXTemp - i * expW);
                                expY.Add(posYTemp);
                                expC.Add(2);
                                exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                expRecCou[expRecCou.Count - 1] += 1;
                            }

                            if (stL == false)
                            {
                                for (int n = 0; n < brickB.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                    {

                                        breaker[n] = true;

                                    }
                                }
                            }
                            if (stL == false)
                            {
                                for (int n = 1; n < nbCount.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                                    {
                                        stL = true;

                                        expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;

                                    }
                                }
                            }
                            for (int n = 0; n < power.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                {


                                    /*expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;*/
                                    pR.RemoveAt(n);
                                    pC.RemoveAt(n);
                                    pTemp.RemoveAt(n);
                                    powerVis.RemoveAt(n);
                                    power.RemoveAt(n);


                                }
                            }

                        }
                    }



                    if (stU == false)
                    {
                        expX.Add(posXTemp);
                        expY.Add(posYTemp - eSize[3] * expH);
                        expC.Add(3);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }

                    if (stU == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stU == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }
                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /* expX.RemoveAt(expX.Count - 1);
                             expY.RemoveAt(expY.Count - 1);
                             expC.RemoveAt(expC.Count - 1);
                             exp.RemoveAt(exp.Count - 1);
                             expRecCou[expRecCou.Count - 1] -= 1;*/
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }

                    if (stD == false)
                    {
                        expX.Add(posXTemp);
                        expY.Add(posYTemp + eSize[3] * expH);
                        expC.Add(4);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }

                    if (stD == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stD == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }
                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /*expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;*/
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }

                    if (stR == false)
                    {
                        expX.Add(posXTemp + eSize[3] * expW);
                        expY.Add(posYTemp);
                        expC.Add(5);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }

                    if (stR == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stR == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }
                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /*expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1;*/
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }

                    if (stL == false)
                    {
                        expX.Add(posXTemp - eSize[3] * expW);
                        expY.Add(posYTemp);
                        expC.Add(6);
                        exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                        expRecCou[expRecCou.Count - 1] += 1;
                    }


                    if (stL == false)
                    {
                        for (int n = 0; n < brickB.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                            {

                                breaker[n] = true;

                            }
                        }
                    }
                    if (stL == false)
                    {
                        for (int n = 1; n < nbCount.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(brickNB[nbCount[n]]))
                            {
                                stU = true;

                                expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;

                            }
                        }
                    }

                    for (int n = 0; n < power.Count; n++)
                    {
                        if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                        {


                            /*expX.RemoveAt(expX.Count - 1);
                            expY.RemoveAt(expY.Count - 1);
                            expC.RemoveAt(expC.Count - 1);
                            exp.RemoveAt(exp.Count - 1);
                            expRecCou[expRecCou.Count - 1] -= 1; */
                            pR.RemoveAt(n);
                            pC.RemoveAt(n);
                            pTemp.RemoveAt(n);
                            powerVis.RemoveAt(n);
                            power.RemoveAt(n);


                        }
                    }
                }
                else
                    if (puE[eTemp] == true)
                    {

                        if (eSize[3] > 0)
                        {
                            for (int i = 1; i < eSize[3]; i++)
                            {
                                if (stU == false)
                                {
                                    expX.Add(posXTemp);
                                    expY.Add(posYTemp - i * expH);
                                    expC.Add(1);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }
                                if (stU == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {

                                            breaker[n] = true;


                                        }
                                    }
                                }
                                if (stU == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stU = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }



                                if (stD == false)
                                {
                                    expX.Add(posXTemp);
                                    expY.Add(posYTemp + i * expH);
                                    expC.Add(1);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stD == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {



                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stD == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stD = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }


                                if (stR == false)
                                {
                                    expX.Add(posXTemp + i * expW);
                                    expY.Add(posYTemp);
                                    expC.Add(2);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stR == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {



                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stR == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stR = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }


                                if (stL == false)
                                {
                                    expX.Add(posXTemp - i * expW);
                                    expY.Add(posYTemp);
                                    expC.Add(2);
                                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                                    expRecCou[expRecCou.Count - 1] += 1;
                                }

                                if (stL == false)
                                {
                                    for (int n = 0; n < brickB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                        {



                                            breaker[n] = true;

                                        }
                                    }
                                }
                                if (stL == false)
                                {
                                    for (int n = 1; n < brickNB.Count; n++)
                                    {
                                        if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                        {
                                            stL = true;

                                            expX.RemoveAt(expX.Count - 1);
                                            expY.RemoveAt(expY.Count - 1);
                                            expC.RemoveAt(expC.Count - 1);
                                            exp.RemoveAt(exp.Count - 1);
                                            expRecCou[expRecCou.Count - 1] -= 1;

                                        }
                                    }
                                }
                                for (int n = 0; n < power.Count; n++)
                                {
                                    if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                                    {


                                        /*expX.RemoveAt(expX.Count - 1);
                                        expY.RemoveAt(expY.Count - 1);
                                        expC.RemoveAt(expC.Count - 1);
                                        exp.RemoveAt(exp.Count - 1);
                                        expRecCou[expRecCou.Count - 1] -= 1;*/
                                        pR.RemoveAt(n);
                                        pC.RemoveAt(n);
                                        pTemp.RemoveAt(n);
                                        powerVis.RemoveAt(n);
                                        power.RemoveAt(n);


                                    }
                                }

                            }
                        }



                        if (stU == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp - eSize[3] * expH);
                            expC.Add(3);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stU == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stU = true;

                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stU == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stU = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stU = true;
                                /* expX.RemoveAt(expX.Count - 1);
                                 expY.RemoveAt(expY.Count - 1);
                                 expC.RemoveAt(expC.Count - 1);
                                 exp.RemoveAt(exp.Count - 1);
                                 expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stD == false)
                        {
                            expX.Add(posXTemp);
                            expY.Add(posYTemp + eSize[3] * expH);
                            expC.Add(4);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stD == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stD = true;


                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stD == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stD = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stD = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stR == false)
                        {
                            expX.Add(posXTemp + eSize[3] * expW);
                            expY.Add(posYTemp);
                            expC.Add(5);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }

                        if (stR == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stR = true;


                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stR == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stR = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }
                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stR = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1;*/
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }

                        if (stL == false)
                        {
                            expX.Add(posXTemp - eSize[3] * expW);
                            expY.Add(posYTemp);
                            expC.Add(6);
                            exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                            expRecCou[expRecCou.Count - 1] += 1;
                        }


                        if (stL == false)
                        {
                            for (int n = 0; n < brickB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickB[n]))
                                {
                                    stL = true;


                                    breaker[n] = true;

                                }
                            }
                        }
                        if (stL == false)
                        {
                            for (int n = 1; n < brickNB.Count; n++)
                            {
                                if (exp[exp.Count - 1].IntersectsWith(brickNB[n]))
                                {
                                    stL = true;

                                    expX.RemoveAt(expX.Count - 1);
                                    expY.RemoveAt(expY.Count - 1);
                                    expC.RemoveAt(expC.Count - 1);
                                    exp.RemoveAt(exp.Count - 1);
                                    expRecCou[expRecCou.Count - 1] -= 1;

                                }
                            }
                        }

                        for (int n = 0; n < power.Count; n++)
                        {
                            if (exp[exp.Count - 1].IntersectsWith(power[n]) && skull != n)
                            {

                                stL = true;
                                /*expX.RemoveAt(expX.Count - 1);
                                expY.RemoveAt(expY.Count - 1);
                                expC.RemoveAt(expC.Count - 1);
                                exp.RemoveAt(exp.Count - 1);
                                expRecCou[expRecCou.Count - 1] -= 1; */
                                pR.RemoveAt(n);
                                pC.RemoveAt(n);
                                pTemp.RemoveAt(n);
                                powerVis.RemoveAt(n);
                                power.RemoveAt(n);


                            }
                        }
                    }



            plBoCou[3] += 1;
            puE.RemoveAt(eTemp);
            puEE.RemoveAt(eTemp);
            boX.RemoveAt(eTemp);
            boY.RemoveAt(eTemp);
            boCou.RemoveAt(eTemp);
            boC.RemoveAt(eTemp);
            boR.RemoveAt(eTemp);
            bomb.RemoveAt(eTemp);

            DrawBackGround();
        }

        private void RemoveExp() 
        {

            expR.RemoveAt(rTemp);
            expCou.RemoveAt(rTemp);

            for (int n = 0; n < expRecCou[rTemp]; n++) 
            {
                expX.RemoveAt(0);
                expY.RemoveAt(rTemp);
                expC.RemoveAt(rTemp);
                exp.RemoveAt(rTemp);

            }           
            expRecCou.RemoveAt(rTemp);
        }       

        private void DrawBackGround() 
        {
        //Just the back menu items so the comp doesnt lag when redrawing so often
        bricky = new Bitmap(this.Width, this.Height);
        using (Graphics gr = Graphics.FromImage(bricky))
        {

            if (gameOnOff == false && cOn == false && oOn == false) 
            {
               gr.DrawImage(bg, 0, 0, this.Width, this.Height - 50);
            }
            if (gameOnOff == false && cOn == true || gameOnOff == false && oOn == true)
            {
                gr.DrawImage(oBg, 0, 0, this.Width, this.Height);
            }
            if (gameOnOff == true)
            {
                for (int n = 0; n < Floor.Count; n++)
                {
                    gr.DrawImage(FloorG, Floor[n]);
                }
                for (int n = 0; n < brickNB.Count; n++)
                {
                    gr.DrawImage(npBreakBrick, brickNB[n]);
                }

                for (int n = 0; n < plNum * 8; n++)
                {
                    gr.DrawImage(PowerUp, pu[n], new RectangleF(puC[n] * pW, puR[n] * pH, pW, pH), GraphicsUnit.Pixel);
                }
                for (int n = 0; n < plNum; n++)
                {
                    gr.FillRectangle(Indigo, playerBG[n]);
                }

                //Player 1 INGAME
                if (plMoveSpeed[0] < 3)
                {
                    gr.FillRectangle(fader, fademark[0]);
                }
                if (plBoCou[0] < 2)
                {
                    gr.FillRectangle(fader, fademark[1]);
                }
                if (skPl != 0)
                {
                    gr.FillRectangle(fader, fademark[2]);
                }
                if (plRng[0] == false)
                {
                    gr.FillRectangle(fader, fademark[3]);
                }
                //Kick gr.FillRectangle(fader, fademark[4]);
                if (eSize[0] < 2)
                {
                    gr.FillRectangle(fader, fademark[5]);
                }
                if (puB[0] == false)
                {
                    gr.FillRectangle(fader, fademark[6]);
                }
                if (puBB[0] == false)
                {
                    gr.FillRectangle(fader, fademark[7]);
                }


                //Player 2 INGAME
                if (plMoveSpeed[1] < 3)
                {
                    gr.FillRectangle(fader, fademark[8]);
                }
                if (plBoCou[1] < 2)
                {
                    gr.FillRectangle(fader, fademark[9]);
                }
                if (skPl != 1)
                {
                    gr.FillRectangle(fader, fademark[10]);
                }
                if (plRng[1] == false)
                {
                    gr.FillRectangle(fader, fademark[11]);
                }
                //Kick gr.FillRectangle(fader, fademark[12]);
                if (eSize[1] < 2)
                {
                    gr.FillRectangle(fader, fademark[13]);
                }
                if (puB[1] == false)
                {
                    gr.FillRectangle(fader, fademark[14]);
                }
                if (puBB[1] == false)
                {
                    gr.FillRectangle(fader, fademark[15]);
                }

                if (plNum > 2)
                {
                    //Player 3 INGAME
                    if (plMoveSpeed[2] < 3)
                    {
                        gr.FillRectangle(fader, fademark[16]);
                    }
                    if (plBoCou[2] < 2)
                    {
                        gr.FillRectangle(fader, fademark[17]);
                    }
                    if (skPl != 2)
                    {
                        gr.FillRectangle(fader, fademark[18]);
                    }
                    if (plRng[2] == false)
                    {
                        gr.FillRectangle(fader, fademark[19]);
                    }
                    //Kick gr.FillRectangle(fader, fademark[20]);
                    if (eSize[2] < 2)
                    {
                        gr.FillRectangle(fader, fademark[21]);
                    }
                    if (puB[2] == false)
                    {
                        gr.FillRectangle(fader, fademark[22]);
                    }
                    if (puBB[2] == false)
                    {
                        gr.FillRectangle(fader, fademark[23]);
                    }
                }

                if (plNum > 3)
                {
                    //Player 4 INGAME
                    if (plMoveSpeed[3] < 3)
                    {
                        gr.FillRectangle(fader, fademark[24]);
                    }
                    if (plBoCou[3] < 2)
                    {
                        gr.FillRectangle(fader, fademark[25]);
                    }
                    if (skPl != 3)
                    {
                        gr.FillRectangle(fader, fademark[26]);
                    }
                    if (plRng[3] == false)
                    {
                        gr.FillRectangle(fader, fademark[27]);
                    }
                    //Kick gr.FillRectangle(fader, fademark[28]);
                    if (eSize[3] < 2)
                    {
                        gr.FillRectangle(fader, fademark[29]);
                    }
                    if (puB[3] == false)
                    {
                        gr.FillRectangle(fader, fademark[30]);
                    }
                    if (puBB[3] == false)
                    {
                        gr.FillRectangle(fader, fademark[31]);
                    }
                }
            }
                         
        }

        this.BackgroundImage = bricky;

        }

        private void tmrDead_Tick(object sender, EventArgs e)
        {
            //Death animation
            for (int n = 0; n < Players.Count; n++) 
            {
                if (plDead[n] == true && plDeath[n] == false) 
                {
                    plCou[n] += 1;
                    plR[n] = plCou[n] % plTR;
                    if (plCou[n] >= plTR)
                    {
                        plX[n] = -500;
                        plY[n] = -500;
                        plR[n] = 12;
                        plUp[n] = false;
                        plLeft[n] = false;
                        plDown[n] = false;
                        plRight[n] = false;
                        plDeath[n] = true;
                        Players[n] = new Rectangle(plX[n], plY[n], plW, plH);
                    } 
                }
            }
        }

        private void RNG1() 
        {
            //Rng For pl1, just makes it specified to one and not changed thorugh tmep val
            //0 - 4 Super Bomb
            //5 - 19 Skates
            //20 - 34 Bigger Bomb
            //35 - 49 Extra Bomb
            //50 - 59 Kick
            //60 - 69 RNG
            //70 - 84 Skull
            //84 - 89 Skatter Bomb
            //90 - 99 No Powerup
            rndnum = rdn.Next(0, 100);

            if (rndnum >= 0 && rndnum <= 19)
            {
                //Death
                for (int n = 0; n < plDead.Count; n++)
                {
                    plCou[n] = 12;
                    plDead[n] = true;
                }
            }
            else
                if (rndnum >= 10 && rndnum <= 24)
                {
                    //No PU
                    plMoveSpeed[0] = 2;
                    eSize[0] = 1;
                    plBoCou[0] = 1;
                    //Kick
                    puBB[0] = false;
                    puB[0] = false;
                }
                else
                    if (rndnum >= 25 && rndnum <= 49)
                    {
                        plCou[0] = 12;
                        plDead[0] = true;
                    }
                    else
                        if (rndnum >= 50 && rndnum <= 74)
                        {
                            //Half PU
                            plMoveSpeed[0] = 5;
                            eSize[0] = 5;
                            plBoCou[0] = 5;
                            //Kick
                            puBB[0] = false;
                            puB[0] = true;
                        }
                        else
                            if (rndnum >= 75 && rndnum <= 89)
                            {
                                //Full PU
                                plMoveSpeed[0] = 10;
                                eSize[0] = 10;
                                plBoCou[0] = 10;
                                //Kick
                                puBB[0] = true;
                                puB[0] = false;

                            }
                            else
                                if (rndnum >= 90 && rndnum <= 99)
                                {
                                    //Win
                                    for (int n = 0; n < plDead.Count; n++)
                                    {
                                        if (n != 0)
                                        {
                                            plCou[n] = 12;
                                            plDead[n] = true;
                                        }
                                    }
                                }
            DrawBackGround();

        }

        private void RNG2()
        {
            //Rng For pl1, just makes it specified to one and not changed thorugh tmep val
            //0 - 4 Super Bomb
            //5 - 19 Skates
            //20 - 34 Bigger Bomb
            //35 - 49 Extra Bomb
            //50 - 59 Kick
            //60 - 69 RNG
            //70 - 84 Skull
            //84 - 89 Skatter Bomb
            //90 - 99 No Powerup
            rndnum = rdn.Next(0, 100);

            if (rndnum >= 0 && rndnum <= 19)
            {
                //Death
                for (int n = 0; n < plDead.Count; n++)
                {
                    plCou[n] = 12;
                    plDead[n] = true;                   
                }
            }
            else
                if (rndnum >= 10 && rndnum <= 24)
                {
                    //No PU
                    plMoveSpeed[1] = 2;
                    eSize[1] = 1;
                    plBoCou[1] = 1;
                    //Kick
                    puBB[1] = false;
                    puB[1] = false;
                }
                else
                    if (rndnum >= 25 && rndnum <= 49)
                    {
                        plCou[1] = 12;
                        plDead[1] = true;                      
                    }
                    else
                        if (rndnum >= 50 && rndnum <= 74)
                        {
                            //Half PU
                            //Full PU
                            plMoveSpeed[1] = 5;
                            eSize[1] = 5;
                            plBoCou[1] = 5;
                            //Kick
                            puBB[1] = false;
                            puB[1] = true;
                        }
                        else
                            if (rndnum >= 75 && rndnum <= 89)
                            {
                                //Full PU
                                plMoveSpeed[1] = 10;
                                eSize[1] = 10;
                                plBoCou[1] = 10;
                                //Kick
                                puBB[1] = true;
                                puB[1] = false;

                            }
                            else
                                if (rndnum >= 90 && rndnum <= 99)
                                {
                                    //Win
                                    for (int n = 0; n < plDead.Count; n++)
                                    {
                                        if (n != 1)
                                        {
                                            plCou[n] = 12;
                                            plDead[n] = true;                                            
                                        }
                                    }
                                }

            DrawBackGround();
        }

        private void RNG3()
        {
            //Rng For pl1, just makes it specified to one and not changed thorugh tmep val
            //0 - 4 Super Bomb
            //5 - 19 Skates
            //20 - 34 Bigger Bomb
            //35 - 49 Extra Bomb
            //50 - 59 Kick
            //60 - 69 RNG
            //70 - 84 Skull
            //84 - 89 Skatter Bomb
            //90 - 99 No Powerup
            rndnum = rdn.Next(0, 100);

            if (rndnum >= 0 && rndnum <= 19)
            {
                //Death
                for (int n = 0; n < plDead.Count; n++)
                {
                    plCou[n] = 12;
                    plDead[n] = true;
                }
            }
            else
                if (rndnum >= 10 && rndnum <= 24)
                {
                    //No PU
                    plMoveSpeed[2] = 2;
                    eSize[2] = 1;
                    plBoCou[2] = 1;
                    //Kick
                    puBB[2] = false;
                    puB[2] = false;
                }
                else
                    if (rndnum >= 25 && rndnum <= 49)
                    {
                        plCou[2] = 12;
                        plDead[2] = true;
                    }
                    else
                        if (rndnum >= 50 && rndnum <= 74)
                        {
                            //Half PU
                            //Full PU
                            plMoveSpeed[2] = 5;
                            eSize[2] = 5;
                            plBoCou[2] = 5;
                            //Kick
                            puBB[2] = false;
                            puB[2] = true;
                        }
                        else
                            if (rndnum >= 75 && rndnum <= 89)
                            {
                                //Full PU
                                plMoveSpeed[2] = 10;
                                eSize[2] = 10;
                                plBoCou[2] = 10;
                                //Kick
                                puBB[2] = true;
                                puB[2] = false;

                            }
                            else
                                if (rndnum >= 90 && rndnum <= 99)
                                {
                                    //Win
                                    for (int n = 0; n < plDead.Count; n++)
                                    {
                                        if (n != 1)
                                        {
                                            plCou[n] = 12;
                                            plDead[n] = true;
                                        }
                                    }
                                }

            DrawBackGround();
        }

        private void RNG4()
        {
            //Rng For pl1, just makes it specified to one and not changed thorugh tmep val
            //0 - 4 Super Bomb
            //5 - 19 Skates
            //20 - 34 Bigger Bomb
            //35 - 49 Extra Bomb
            //50 - 59 Kick
            //60 - 69 RNG
            //70 - 84 Skull
            //84 - 89 Skatter Bomb
            //90 - 99 No Powerup
            rndnum = rdn.Next(0, 100);

            if (rndnum >= 0 && rndnum <= 19)
            {
                //Death
                for (int n = 0; n < plDead.Count; n++)
                {
                    plCou[n] = 12;
                    plDead[n] = true;
                }
            }
            else
                if (rndnum >= 10 && rndnum <= 24)
                {
                    //No PU
                    plMoveSpeed[3] = 2;
                    eSize[3] = 1;
                    plBoCou[3] = 1;
                    //Kick
                    puBB[3] = false;
                    puB[3] = false;
                }
                else
                    if (rndnum >= 25 && rndnum <= 49)
                    {
                        plCou[3] = 12;
                        plDead[3] = true;
                    }
                    else
                        if (rndnum >= 50 && rndnum <= 74)
                        {
                            //Half PU
                            //Full PU
                            plMoveSpeed[3] = 5;
                            eSize[3] = 5;
                            plBoCou[3] = 5;
                            //Kick
                            puBB[3] = false;
                            puB[3] = true;
                        }
                        else
                            if (rndnum >= 75 && rndnum <= 89)
                            {
                                //Full PU
                                plMoveSpeed[3] = 10;
                                eSize[3] = 10;
                                plBoCou[3] = 10;
                                //Kick
                                puBB[3] = true;
                                puB[3] = false;

                            }
                            else
                                if (rndnum >= 90 && rndnum <= 99)
                                {
                                    //Win
                                    for (int n = 0; n < plDead.Count; n++)
                                    {
                                        if (n != 1)
                                        {
                                            plCou[n] = 12;
                                            plDead[n] = true;
                                        }
                                    }
                                }

            DrawBackGround();
        }

        private void Reset() 
        {
            //Resets all varaibles
            puE.Clear();
            puEE.Clear();
            boX.Clear();
            boY.Clear();
            boCou.Clear();
            boC.Clear();
            boR.Clear();
            bomb.Clear();

           
            endTmr = false;
            brCount = 0;
            brbCount = 0;
            fCount = 0;
            skPl = -1;
            //Resets to its ready for a fresh set
            if (won == true)
            {
                plWins[0] = 0;
                plWins[1] = 0;
                plWins[2] = 0;
                plWins[3] = 0;
            }
             won = false;
            pR.Clear();
            pC.Clear();
            pTemp.Clear();
            powerVis.Clear();
            power.Clear();       

            plDead[0] = false;
            plDeath[0] = false;
            plDead[1] = false;
            plDeath[1] = false;
            plDead[2] = false;
            plDeath[2] = false;
            plDead[3] = false;
            plDeath[3] = false;

            plR.Clear();
            plX.Clear();
            plY.Clear();
            plCou.Clear();
            Players.Clear();            
            plDead.Clear();
            plSpRun.Clear();
            plMoveSpeed.Clear();
            plSpR.Clear();
            plDead.Clear();
            plSp.Clear();
            plRng.Clear();
            plBoCou.Clear();
            plHB.Clear();

            if (rdnSpawn == false)
            {
                //Random spawn
                plX.Add(105 + 16 * 30);
                plY.Add(105 + 16 * 30);
                plX.Add(105);
                plY.Add(105);
                plX.Add(105);
                plY.Add(105 + 16 * 30);
                plX.Add(105 + 16 * 30);
                plY.Add(105);


            }
            else 
            {
                plSpawn.Shuffle();

                plX.Add(plSpawn[0].X);
                plY.Add(plSpawn[0].Y);
                plX.Add(plSpawn[1].X);
                plY.Add(plSpawn[1].Y);
                plX.Add(plSpawn[2].X);
                plY.Add(plSpawn[2].Y);
                plX.Add(plSpawn[3].X);
                plY.Add(plSpawn[3].Y);
            
            }

            if (rdnCol == true) 
            {//Random colours
                colTemp.Shuffle();
                plC[0] = colTemp[0];
                plC[1] = colTemp[1];
                plC[2] = colTemp[2];
                plC[3] = colTemp[3];
            }

            plR.Add(0);
            plCou.Add(0);
            Players.Add(new Rectangle(plX[0], plY[0], plW, plH));
            plDead.Add(false);
            plSp.Add(false);
            plSpRun.Add(0);
            plMoveSpeed.Add(2);
            plSpR.Add(false);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[0] + 5, plY[0] + 5, 20, 20));
            plR.Add(0);
            plCou.Add(0);
            Players.Add(new Rectangle(plX[1], plY[1], plW, plH));
            plDead.Add(false);
            plSp.Add(false);
            plSpRun.Add(0);
            plMoveSpeed.Add(2);
            plSpR.Add(false);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[1] + 5, plY[1] + 5, 20, 20));
            plR.Add(0);
            plCou.Add(0);
            Players.Add(new Rectangle(plX[2], plY[2], plW, plH));
            plDead.Add(false);
            plSp.Add(false);
            plSpRun.Add(0);
            plMoveSpeed.Add(2);
            plSpR.Add(false);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[2] + 5, plY[2] + 5, 20, 20));
            plR.Add(0);
            plCou.Add(0);
            Players.Add(new Rectangle(plX[3], plY[3], plW, plH));
            plDead.Add(false);
            plSp.Add(false);
            plSpRun.Add(0);
            plMoveSpeed.Add(2);
            plSpR.Add(false);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[3] + 5, plY[3] + 5, 20, 20));


            plSur[0] = new Rectangle(plX[0] - 5, plY[0] - 5, 40, 40);
            plSur[1] = new Rectangle(plX[1] - 5, plY[1] - 5, 40, 40);
            plSur[2] = new Rectangle(plX[2] - 5, plY[2] - 5, 40, 40);
            plSur[3] = new Rectangle(plX[3] - 5, plY[3] - 5, 40, 40);

            nbCount.Clear();
            nbCoTemp = 0;
            nbCTemp = 0;

            for (int n = 0; n < 72; n++)
            {

                nbCount.Add(nbCTemp);
                nbCoTemp += 1;
                nbCTemp += 1;

                if (nbCoTemp == 22 && nbCount.Count < 53)
                {
                    nbCTemp += 8;
                    nbCoTemp -= 4;
                }
            }


            puB.Clear();
            puBB.Clear();
            puBB.Add(false);
            puBB.Add(false);
            puBB.Add(false);
            puBB.Add(false);
            puB.Add(false);
            puB.Add(false);
            puB.Add(false);
            puB.Add(false);
            eSize.Clear();
            eSize.Add(1);
            eSize.Add(1);
            eSize.Add(1);
            eSize.Add(1);

            row = 0;

            brickNB.Clear();
            brickB.Clear();
            Floor.Clear();
            brR.Clear();
            brCou.Clear();
            brX.Clear();
            brY.Clear();
            brbX.Clear();
            brbY.Clear();
            flX.Clear();
            flY.Clear();           
            
            

            for (int n = 0; n < size; n++)
            {

                bTemp = 0;
                BuildBrick();
                row += 1;
            }        

            
            brX.Shuffle();
            brY.Shuffle();

         

            for (int n = 0; n < brickB.Count; n++)
            {
                brickB[n] = new Rectangle(brX[n], brY[n], brW, brH);

            }


            removed = rdn.Next(15, 32);

            for (int n = 0; n < removed; n++)
            {
                brickB.RemoveAt(0);
                brX.RemoveAt(0);
                brY.RemoveAt(0);
                brR.RemoveAt(0);
                brCount -= 1;
            }

            breaker.Clear();
            brCou.Clear();

            for (int n = 0; n < brickB.Count; n++)
            {
                brickB[n] = new Rectangle(brX[n], brY[n], brW, brH);
                breaker.Add(false);
                brCou.Add(0);
            }


            for (int n = 0; n < Players.Count; n++) 
            {
                for (int i = 0; i < brickB.Count; i++)
                {
                    if (Players[n].IntersectsWith(brickB[i]))
                    {
                        brR.RemoveAt(i);
                        brCou.RemoveAt(i);
                        brX.RemoveAt(i);
                        brY.RemoveAt(i);
                        brickB.RemoveAt(i);
                        breaker.RemoveAt(i);
                    }
                }
            }


            DrawBackGround();
            this.Refresh();


        }

        private void tmrSkull_Tick(object sender, EventArgs e)
        {
            //Skull TImer, so it goes asway after 5 secs
            if (skPl != -1) 
            {
                skTime += 1;

                if (skTime == 500) 
                {                   
                    skTime = 0;
                    plMoveSpeed[skPl] = spTemp;
                    plBoCou[skPl] = boTemp;
                     skPl = -1;
                }

            
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {            
            //For clicking in menu
            if (gameOnOff == false && cOn == false && oOn == false)
            {
                if (pAb == true)
                {
                    pAb = false;
                    this.Refresh();

                }
                else
                if (pAb == false)
                {
                    menTim = 0;
                    dOOa = 255;
                    dOO = new SolidBrush(Color.FromArgb(dOOa, 255, 255, 255));
                    if (mPos == 0) { restart = true; Transition(); }
                    if (mPos == 1) { options = true; Transition(); }
                    if (mPos == 2) { controls = true; Transition(); }
                    if (mPos == 3) { this.Close(); }
                }

               
            }

            if (inGameMenu == true && gameOnOff == true || won == true && gameOnOff == true) 
            {
                if (mPos == 0) { inGameMenu = false; }
                if (mPos == 1) { restart = true; Transition(); }
                if (mPos == 2) { other = true; music = true; won = true; Transition(); }
                
            }

            if (baOn == true) { other = true; baOn = false; Transition(); }


            if (oOn == true)
            {
                //PLayer 1 Col
                for (int n = 0; n < optBut.Count; n++)
                {
                    if (optBut[n].Contains(e.Location))
                    {
                        if (n > 23)
                        {
                            if (plC[0] != n - 24 && plC[1] != n - 24 && plC[2] != n - 24)
                            {
                                plC[3] = n - 24;
                            }
                        }
                        else
                            if (n > 15)
                            {
                                if (plC[0] != n - 16 && plC[1] != n - 16 && plC[3] != n - 16)
                                {
                                    plC[2] = n - 16;
                                }
                            }
                            else
                                if (n > 7)
                                {
                                    if (plC[0] != n - 8 && plC[2] != n - 8 && plC[3] != n - 8)                                    
                                        {
                                            plC[1] = n - 8;
                                        }
                                }
                                else
                                    {
                                        if (plC[2] != n && plC[1] != n && plC[3] != n)
                                        {
                                            plC[0] = n;
                                        }
                                    }
                    }

                }

                if (mPos == 0) 
                {
                    if (rdnSpawn == false)
                    {
                        rdnSpawn = true;
                        optButtCon[0] = on;
                        this.Refresh();
                    }
                    else
                    {
                        rdnSpawn = false;
                        optButtCon[0] = off;
                        this.Refresh();
                    }                    
                }

                if (mPos == 1)
                {
                    if (rdnCol == false)
                    {
                        rdnCol = true;
                        optButtCon[1] = on;
                        this.Refresh();
                    }
                    else
                    {
                        rdnCol = false;
                        optButtCon[1] = off;
                        this.Refresh();
                    }                   
                }
                // - Meant to be for teams - PU Chance
                if (mPos == 2)
                {
                    if (puSpawnRate == 1) 
                    {
                        puSpawnRate = 2;
                        optButtCon[2] = off;
                    }
                    else
                    if (puSpawnRate == 2)
                    {
                        puSpawnRate = 4;
                        optButtCon[2] = on;
                    }
                    else
                    if (puSpawnRate == 4)
                    {
                        puSpawnRate = 10;
                        
                    }
                    else
                        if (puSpawnRate == 10)
                        {
                            puSpawnRate = 1;                           
                        }
                }

                if (mPos == 3)
                {
                    if (teams == false)
                    {
                        plNum = 4;
                        teams = true;
                        team12 = true;
                        optButtCon[3] = on;
                        this.Refresh();
                    }
                    else if(team12 == true)
                    {
                        team12 = false;
                        team13 = true;
                        this.Refresh();
                    }
                    else if (team13 == true) 
                    {
                        team13 = false;
                        team14 = true;
                        this.Refresh();
                    }
                    else if (team14 == true)
                    {
                        team14 = false;
                        teams = false;
                        optButtCon[3] = off;
                        this.Refresh();
                    }
                }

                //Score Limit
                if (mPos == 5)
                {
                    winsNeeded -= 1;
                    if (winsNeeded < 1) 
                    {
                        winsNeeded = 1;
                    }
                }
                if (mPos == 6)
                {
                    winsNeeded += 1;
                    if (winsNeeded > 9)
                    {
                        winsNeeded = 9;
                    }
                }
                //PLayer #
                if (mPos == 8)
                {
                    plNum -= 1;
                    if (plNum < 2)
                    {
                       plNum = 2;
                    }
                    if (teams == true) { plNum = 4; }
                }
                if (mPos == 9)
                {
                    plNum += 1;
                    if (plNum > 4)
                    {
                       plNum = 4;
                    }
                    if (teams == true) { plNum = 4; }
                }

            }
            
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //SO stuff gets highlighted in menu
            if (gameOnOff == false && oOn == false && cOn == false)
            {
                mPos = -1;
                for (int n = 0; n < menPos.Count; n++)
                {
                    if (menPos[n].Contains(e.Location)) { mPos = n; }
                }
                this.Refresh();
            }

            if (gameOnOff == true && inGameMenu == true || gameOnOff == true && won == true)
            {
                mPos = -1;
                for (int n = 0; n < ingMen.Count; n++)
                {
                    if (ingMen[n].Contains(e.Location)) { mPos = n;}
                }
                
            }

            if (cOn == true || oOn == true) 
            {
               
                if (back.Contains(e.Location)) { baOn = true; this.Refresh(); } else { baOn = false; this.Refresh(); }                            
            }
            if (oOn == true) 
            {
                mPos = -1;
                for (int n = 0; n < optButCon.Count; n++)
                {
                    if (optButCon[n].Contains(e.Location)) { mPos = n; }
                }  
            }

        }

        private void tmrMenu_Tick(object sender, EventArgs e)
        {
            //For while in menu so the right buttons are clicked and highlighted
            if (gameOnOff == false && cOn == false && oOn == false)
            {
                if (pAb == true)
                {
                    mSlp -= 1;

                    if (mSlp <= 0)
                    {
                        if (dOai == false)
                        {
                            dOa += 17;
                            dO = new SolidBrush(Color.FromArgb(dOa, 255, 140, 0));
                            this.Refresh();
                            if (dOa == 255) { dOai = true; }
                        }
                        else
                        {
                            dOa -= 17;
                            dO = new SolidBrush(Color.FromArgb(dOa, 255, 140, 0));
                            this.Refresh();
                            if (dOa == 0) { dOai = false; mSlp = 51; }
                        }
                    }
                }
                else
                {
                    menTim += 1;

                    if (menTim >= 1000)
                    {
                        dOOa -= 5;
                        dOO = new SolidBrush(Color.FromArgb(dOOa, 255, 255, 255));
                        this.Refresh();
                        if (dOOa == 0)
                        {
                            pAb = true; this.Refresh(); dOOa = 255; menTim = 0;
                        }
                    }
                }

                
            }
        }

        private void Transition() 
        {
            //Transition between levels/games/menus
            trans = true;
            cX = this.Width / 2;
            cY = this.Height / 2;
           
                //Makes Circle Grow
            grow = true;
                while (grow == true)
                {
                    cX -= cc;
                    cY -= cc;
                    cW += cc * 2;
                    cH += cc * 2;
                    if (cX < 0 && cY < 0 && cH > this.Height * 2 + 250 && cW > this.Width * 2 + 250) { grow = false; }
                    this.Refresh();
                }

                mPos = -1;

                if (restart == true) 
                {
                    Reset(); gameOnOff = true; DrawBackGround(); inGameMenu = false; mscTmr = 0; wp.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Melody.mp3";
                }
                if (other == true) 
                {
                    gameOnOff = false; mPos = -1; cOn = false; oOn = false; if (music == true) { mscTmr = 0; wp.URL = @"C:\Users\Cole Cadera\Desktop\BomberMan FINAL\BomberMan V1.0\Resources\Menu.mp3"; } Reset(); DrawBackGround(); this.Refresh();
                }
                if (controls == true)
                {
                    cOn = true; DrawBackGround(); this.Refresh();
                }
                if (options == true)
                {
                    oOn = true; DrawBackGround(); this.Refresh();
                }
                if (inGame == true)
                {
                    Reset(); DrawBackGround();
                }

                shrink = true;
                while (shrink == true)
                {
                    cX += cc;
                    cY += cc;
                    cW -= cc * 2;
                    cH -= cc * 2;
                    if (cW <= 0) { shrink = false; }
                    this.Refresh();
                }

                trans = false;
                restart = false;
                other = false;
                controls = false;
                options = false;
                inGame = false;
                music = false;
            
        
        }

        private void tmrFire_Tick_Tick(object sender, EventArgs e)
        {
         //Fireworks        
            for(int o = 0; o < 15; o++) {
            

            if (up[o].Y > FWexp[o])
            {
                up[o].Y = up[o].Y - 15;
              
                for (int i = 0; i < 40; i++)
                {
                    particle[o, i] = new Rectangle(up[o].X, up[o].Y, FWsize[o], FWsize[o]);
                }
            }

           if (up[o].Y <= FWexp[o]) {

               ep[o] = true;
            
            }
           if (ep[o] == true)
           {
               lo[o] = lo[o] + 1;
               for (int i = 0; i < 40; i++)
               {

                   particle[o,i].X += xVel[o,i];
                   particle[o,i].Y += yVel[o,i];

               }

               if (lo[o] == 5) {
                   FWsize[o] = FWsize[o] - 1;
                   

                   for (int i = 0; i < 40; i++)
                   {

                       if (xVel[o,i] > 1)
                       {

                           xVel[o,i] = xVel[o,i] - 1;

                       }

                       if (xVel[o,i] < -1)
                       {

                           xVel[o,i] = xVel[o,i] + 1;

                       }

                       if (yVel[o,i] <= -1)
                       {

                           yVel[o,i] = yVel[o,i] + 1;

                       }
                       if (yVel[o,i] >=  1)
                       {

                           yVel[o,i] = yVel[o,i] - 1;

                       }





                   }

                   lo[o] = 0;
               }



               
           }



           if (FWsize[o] == 0) {
               FWsize[o] = 10;
               up[o].X = rdn.Next(0, this.Width - FWsize[o]); 
               up[o].Y = this.Height;
               ep[o] = false;
               up[o] = new Rectangle(up[o].X, up[o].Y, FWsize[o], FWsize[o]);
                FWexp[o] = rdn.Next(0, this.Height - 50);
               for (int i = 0; i < 40; i++)
               {

                   particle[o,i] = new Rectangle(particle[o,i].X, particle[o,i].Y, FWsize[o], FWsize[o]);
                   xVel[o,i] = rdn.Next(-10, 10);
                   yVel[o,i] = rdn.Next(-10, 10);
rColor = new SolidBrush(Color.FromArgb(rdn.Next(256), rdn.Next(256), rdn.Next(256)));
                   color[o] = rColor;
               }
               
           
           }
            }


//this.Refresh();
         

        
        }

        private void fwStart() 
        {
            //Resets Positions for fireworks
            for (int i = 0; i < 15; i++)
            {
                FWexp[i] = rdn.Next(0, this.Height - 50);
                up[i].X = rdn.Next(0, this.Width - FWsize[i]);
                up[i].Y = this.Height;

                up[i] = new Rectangle(up[i].X, up[i].Y, FWsize[i], FWsize[i]);

                for (int o = 0; o < 40; o++)
                {

                    particle[i, o] = new Rectangle(particle[i, o].X, particle[i, o].Y, FWsize[i], FWsize[i]);
                    xVel[i, o] = rdn.Next(-10, 10);
                    yVel[i, o] = rdn.Next(-10, 10);

                }


            }



            for (int i = 0; i < 15; i++)
            {


                rColor = new SolidBrush(Color.FromArgb(rdn.Next(256), rdn.Next(256), rdn.Next(256)));
                color[i] = rColor;

            }


        }

    }
}

static class MixIt
{
    public static void Shuffle<T>(this IList<T> list)
    {
        Random r = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = r.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}