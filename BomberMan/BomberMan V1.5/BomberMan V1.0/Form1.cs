using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Image bombers = Properties.Resources.bomberman;
        Image normalBomb = Properties.Resources.bomb;
        Image powerUpBomb = Properties.Resources.pBomb;
        Image powerpowerUpBomb = Properties.Resources.ppBomb;
        Image brickBreak = Properties.Resources._break;
        Image npBreakBrick = Properties.Resources.unbreak;
        Image PowerUp = Properties.Resources.pp;
        Image Explosion = Properties.Resources.explosion;
        Image FloorG = Properties.Resources.floorG;


        SolidBrush t = new SolidBrush(Color.FromArgb(100, 0, 0, 255));


        Random rdn = new Random();
        //Powerups
        List<Rectangle> power = new List<Rectangle>();
        List<int> pR = new List<int>();
        List<int> pC = new List<int>();
        List<int> pTemp = new List<int>();
        int pW, pH, pTR, pTC, ppTemp, y;
        List<bool> powerVis = new List<bool>();
        List<bool> plRng = new List<bool>();
        int skull= -1;


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
        SolidBrush fader;
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
        List<bool> plBUp = new List<bool>();
        List<bool> plBDo = new List<bool>();
        List<bool> plBle = new List<bool>();
        List<bool> plBRi = new List<bool>();
        List<int> plBoCou = new List<int>();

        //Menu Variables
        bool gameOnOff = true;
        SolidBrush Indigo;

        //RNG/Skull VARIABLES
        int rndnum;
        int skPl = -1, spTemp, boTemp, skTime;



        public Form1()
        {
            InitializeComponent();

            Indigo = new SolidBrush(Color.FromArgb(75, 0, 130, 200));

            plTC = 8;
            plTR = 20;

            bombers = new Bitmap(bombers, new Size(plTC * plW, plTR * plH));


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
            plBDo.Add(false);
            plBle.Add(false);
            plBRi.Add(false);
            plBUp.Add(false);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);   
            plHB.Add(new Rectangle(plX[0] + 5, plY[0] + 5 , 20, 20));

            plR.Add(0);
            plC.Add(1);
            plX.Add(105);
            plY.Add(105);
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
            plCol.Add(18);
            plRow.Add(18);
            plColT.Add(18);
            plRowT.Add(18);
            plBDo.Add(false);
            plBle.Add(false);
            plBRi.Add(false);
            plBUp.Add(false);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[1] + 5, plY[1] + 5 , 20, 20));

            plR.Add(0);
            plC.Add(2);
            plX.Add(105);
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
            plBDo.Add(false);
            plBle.Add(false);
            plBRi.Add(false);
            plBUp.Add(false);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[0] + 5, plY[0] + 5, 20, 20));

            plR.Add(0);
            plC.Add(3);
            plX.Add(105 + 16 * 30);
            plY.Add(105);
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
            plBDo.Add(false);
            plBle.Add(false);
            plBRi.Add(false);
            plBUp.Add(false);
            plDeath.Add(false);
            plRng.Add(false);
            plBoCou.Add(1);
            plHB.Add(new Rectangle(plX[0] + 5, plY[0] + 5, 20, 20));


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



            puBB.Add(false);
            puBB.Add(false);
            puBB.Add(false);
            puBB.Add(false);
            puB.Add(false);
            puB.Add(false);
            puB.Add(false);
            puB.Add(false);
            
            

            faderInt = 150;

            fader = new SolidBrush(Color.FromArgb(faderInt, 255, 255, 255));
                       
            eSize.Add(1);
            eSize.Add(1);
            eSize.Add(1);
            eSize.Add(1);

            expTR = 4;
            expTC = 7;
            expW = 30;
            expH = 30;


            Explosion = new Bitmap(Explosion, new Size(30 * expTC, 30 * expTR));

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
                  row += 1;            }


            
            boTC = 11;
            boW = 16;
            boH = 16;



            pTR = 2;
            pTC = 4;

            PowerUp = new Bitmap(PowerUp, new Size(26 * pTC, 26 * pTR));

            pW = PowerUp.Width / pTC;
            pH = PowerUp.Height / pTR;
            
            this.Height = 185 + row * brH;
            this.Width = 175 + row * brW;

 
           

            

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


            DrawBackGround();

        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {          
            
           if(bomb.Count == 0) 
            {
                boR.Clear();
                puE.Clear();
                puEE.Clear();
            }

           for (int n = 0; n < Players.Count; n++) 
           {
               if (plDeath[n] == true) { plX[n] = -500; plY[n] = -500;
               Players[n] = new Rectangle(plX[n], plY[n], plH, plW);
               }
           }

            for (int n = 0; n < Players.Count; n++) 
            {
                if (plBoCou[n] > 10) { plBoCou[n] = 10; }
            }

            for (int n = 0; n < Players.Count; n++)
            {
                plBUp[n] = false;
                plBDo[n] = false;
                plBle[n] = false;
                plBRi[n] = false;
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
            }

            for (int n = 0; n < plHB.Count; n++)
            {      
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

            

            
            for (int i = 0; i < Players.Count; i++) 
            {
                if (plDead[i] == false && plDeath[i] == false)
                {
                    if (plUp[i] == true && plY[i] > 105)
                    {
                        plY[i] -= plMoveSpeed[i];
                    } else
                    if (plDown[i] == true && plY[i] < ((row - 2) * brH) + 75)
                    {
                        plY[i] += plMoveSpeed[i];

                    } else
                    if (plLeft[i] == true && plX[i] > 105)
                    {
                        plX[i] -= plMoveSpeed[i];

                    } else
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

            

            this.Refresh();
        }

        private void tmrBombers_Tick(object sender, EventArgs e)
        {
            for (int n = 0; n < Players.Count; n++)
            {
                for (int i = 0; i < power.Count; i++) 
                {                    
                    if (Players[n].IntersectsWith(power[i]) && skPl != n) 
                    {
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


            



            for (int i = 0; i < expCou.Count; i++)
            {
                expCou[i] += 1;
                expR[i] = expCou[i] % expTR;
                
                if (expCou[i] >= expTR) 
                {
                    rTemp = i;
                    RemoveExp();
                }

                //DrawExplosion();

            }
            

            for (int n = 0; n < brickB.Count; n++)
            {
                if (breaker[n] == true) {
                    brCou[n] += 1;
                    brR[n] = brCou[n] % brTR;                   
                }
                if (brCou[n] >= brTR) {                   
                    y = n;
                    powerSpawn();
                }
            }


           

            

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (gameOnOff == true)
            {
                for (int n = 0; n < brickB.Count; n++)
                {
                    e.Graphics.DrawImage(brickBreak, brickB[n], new RectangleF(brC * brW, brR[n] * brH, brW, brH), GraphicsUnit.Pixel);
                }

                
                    for (int n = 0; n < bomb.Count; n++)
                    {                       

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

                for (int n = 0; n < expCou.Count; n++)
                {
                    for (int i = 0; i < exp.Count; i++)
                    {
                        e.Graphics.DrawImage(Explosion, exp[i], new RectangleF(expC[i] * expW, expR[n] * expH, expW, expH), GraphicsUnit.Pixel);
                    }
                }

                for (int n = 0; n < power.Count; n++)
                {
                    if (powerVis[n] == true)
                    {
                        e.Graphics.DrawImage(PowerUp, power[n], new RectangleF(pC[n] * pW, pR[n] * pH, pW, pH), GraphicsUnit.Pixel);
                    }
                }


                for (int n = 0; n < Players.Count; n++)
                {
                    e.Graphics.DrawImage(bombers, Players[n], new RectangleF(plC[n] * plW, plR[n] * plH, plW, plH), GraphicsUnit.Pixel);
                }

                
                    e.Graphics.DrawImage(bombers, playerBG[0], new RectangleF(plC[0] * plW, plR[0] * plH, plW, plH), GraphicsUnit.Pixel);
                    e.Graphics.DrawImage(bombers, playerBG[2], new RectangleF(plC[1] * plW, plR[1] * plH, plW, plH), GraphicsUnit.Pixel);
                    e.Graphics.DrawImage(bombers, playerBG[1], new RectangleF(plC[2] * plW, plR[2] * plH, plW, plH), GraphicsUnit.Pixel);
                    e.Graphics.DrawImage(bombers, playerBG[3], new RectangleF(plC[3] * plW, plR[3] * plH, plW, plH), GraphicsUnit.Pixel);
                

                e.Graphics.DrawString("" + plBoCou[0], new System.Drawing.Font("Lucida Console", 15), Brushes.White, this.Width - 100, 100);
                e.Graphics.DrawString("" + plBoCou[1], new System.Drawing.Font("Lucida Console", 15), Brushes.White, this.Width - 100, 125);
                e.Graphics.DrawString("" + plBoCou[2], new System.Drawing.Font("Lucida Console", 15), Brushes.White, this.Width - 100, 175);
                e.Graphics.DrawString("" + plBoCou[3], new System.Drawing.Font("Lucida Console", 15), Brushes.White, this.Width - 100, 200);
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOnOff == true)
            {
                if (plDead[0] == false && plDeath[0] == false)
                {

                    if (e.KeyData == Keys.W && plUp[0] == false && plY[0] > 105 && plBUp[0] == false)
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
                    if (e.KeyData == Keys.A && plLeft[0] == false && plBle[0] == false)
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
                    if (e.KeyData == Keys.S && plDown[0] == false && plBDo[0] == false)
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
                    if (e.KeyData == Keys.D && plRight[0] == false && plBRi[0] == false)
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

                if (plDead[1] == false && plDeath[1] == false)
                {

                    if (e.KeyData == Keys.Up && plUp[1] == false && plY[1] > 105)
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

                if (plDead[2] == false && plDeath[2] == false)
                {

                    if (e.KeyData == Keys.P && plUp[2] == false && plY[2] > 105)
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

                if (plDead[3] == false && plDeath[3] == false)
                {

                    if (e.KeyData == Keys.Y && plUp[3] == false && plY[3] > 105)
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

                if (e.KeyData == Keys.PageUp) { Reset(); }

                

            }


            if (e.KeyCode == Keys.PageDown) 
            {
                if (gameOnOff == true)
                {
                    gameOnOff = false;
                    DrawBackGround();
                }
                else
                {
                    gameOnOff = true;
                    DrawBackGround();
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
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

            if (plDead[2] == false && plDeath[2] == false)
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

            if (plDead[3] == false && plDeath[3] == false)
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

                        flX.Add(75 + n * brW);
                        flY.Add(75 + row * brH);
                        Floor.Add(new Rectangle(flX[fCount], flY[fCount], brW, brH));
                        fCount += 1;


                        bTemp += 1;
                    }
                }

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

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            
           


            for (int n = 0; n < brickB.Count; n++) 
            {
                /*if(e.X > brbX[n] && e.X < brbX[n] + brW && e.Y > brbY[n] && e.Y < brbY[n] + brH) {                
                brickNB.RemoveAt(n);
                brbX.RemoveAt(n);
                brbY.RemoveAt(n);
                }*/

               

                /*if (e.X > brX[n] && e.X < brX[n] + brW && e.Y > brY[n] && e.Y < brY[n] + brH)
                {
                    temp = n;
                    breaker[n] = true;
                }*/
                
            }
        }

        private void powerSpawn() 
        {

            
            ppTemp = rdn.Next(0, 2);
            if (ppTemp >= 1)
            {

                pTemp.Add(0);
                powerVis.Add(false);
               
                pTemp[pTemp.Count - 1] = rdn.Next(0, 100);
                



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
                    if (pTemp[pTemp.Count - 1] >= 5 && pTemp[pTemp.Count - 1] <= 19)
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

                                    pR.Add(1);
                                    pC.Add(0);
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
                                        if (pTemp[pTemp.Count - 1] >= 70 && pTemp[pTemp.Count - 1] <= 84)
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

            brR.RemoveAt(y);
            brCou.RemoveAt(y);
            brX.RemoveAt(y);
            brY.RemoveAt(y);
            brickB.RemoveAt(y);
            breaker.RemoveAt(y);
            

        }

        private void tmrBomb_Tick(object sender, EventArgs e)
        {
            for (int n = 0; n < bomb.Count; n++)
            {
               
                  boCou[n] += 1;
                    boC[n] = boCou[n] % boTC;
                
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

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int n = 0; n < power.Count; n++) 
            {
                if (e.X > power[n].X && e.X < power[n].X + pW && e.Y > power[n].Y && e.Y < power[n].Y + pH) 
                {
                    if (pTemp[n] >= 70 && pTemp[n] <= 84) { skull = -1; }
                    pR.RemoveAt(n);
                    pC.RemoveAt(n);
                    pTemp.RemoveAt(n);
                    powerVis.RemoveAt(n);
                    power.RemoveAt(n);
                    
                }
            }
        }

        private void DrawBackGround() 
        {
        
        bricky = new Bitmap(this.Width, this.Height);
        using (Graphics gr = Graphics.FromImage(bricky))
        {
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

                for (int n = 0; n < pu.Count; n++)
                {
                    gr.DrawImage(PowerUp, pu[n], new RectangleF(puC[n] * pW, puR[n] * pH, pW, pH), GraphicsUnit.Pixel);
                }
                for (int n = 0; n < playerBG.Count; n++)
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
                    gr.FillRectangle(fader, fademark[16]);
                }
                if (plBoCou[1] < 2)
                {
                    gr.FillRectangle(fader, fademark[17]);
                }
                if (skPl != 1)
                {
                    gr.FillRectangle(fader, fademark[18]);
                }
                if (plRng[1] == false)
                {
                    gr.FillRectangle(fader, fademark[19]);
                }
                //Kick gr.FillRectangle(fader, fademark[20]);
                if (eSize[1] < 2)
                {
                    gr.FillRectangle(fader, fademark[21]);
                }
                if (puB[1] == false)
                {
                    gr.FillRectangle(fader, fademark[22]);
                }
                if (puBB[1] == false)
                {
                    gr.FillRectangle(fader, fademark[23]);
                }


                //Player 3 INGAME
                if (plMoveSpeed[2] < 3)
                {
                    gr.FillRectangle(fader, fademark[8]);
                }
                if (plBoCou[2] < 2)
                {
                    gr.FillRectangle(fader, fademark[9]);
                }
                if (skPl != 2)
                {
                    gr.FillRectangle(fader, fademark[10]);
                }
                if (plRng[2] == false)
                {
                    gr.FillRectangle(fader, fademark[11]);
                }
                //Kick gr.FillRectangle(fader, fademark[12]);
                if (eSize[2] < 2)
                {
                    gr.FillRectangle(fader, fademark[13]);
                }
                if (puB[2] == false)
                {
                    gr.FillRectangle(fader, fademark[14]);
                }
                if (puBB[2] == false)
                {
                    gr.FillRectangle(fader, fademark[15]);
                }


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

        this.BackgroundImage = bricky;

        }

        private void tmrDead_Tick(object sender, EventArgs e)
        {
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
                        plDeath[n] = true;
                        Players[n] = new Rectangle(plX[n], plY[n], plW, plH);
                    } 
                }
            }
        }

        private void RNG1() 
        {

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

        private void Reset() 
        {

            puE.Clear();
            puEE.Clear();
            boX.Clear();
            boY.Clear();
            boCou.Clear();
            boC.Clear();
            boR.Clear();
            bomb.Clear();


            brCount = 0;
            brbCount = 0;
            fCount = 0;
            skPl = -1;

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
            plC.Clear();
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

            plR.Add(0);
            plC.Add(0);
            plX.Add(105 + 16 * 30);
            plY.Add(105 + 16 * 30);
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
            plC.Add(1);
            plX.Add(105);
            plY.Add(105);
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
            plC.Add(2);
            plX.Add(105);
            plY.Add(105 + 16 * 30);
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
            plC.Add(3);
            plX.Add(105 + 16 * 30);
            plY.Add(105);
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

            nbCount.Clear();

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