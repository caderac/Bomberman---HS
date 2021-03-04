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
        bool skull = false;


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


        //Bombs
        List<Rectangle> bomb = new List<Rectangle>();
        List<int> boC = new List<int>();
        List<int> boCou = new List<int>();
        List<int> boX = new List<int>();
        List<int> boY = new List<int>();
        int boR, boTC, boTR, boW, boH;
        int xTemp, yTemp, xPosB, yPosB;
        bool bom = true, nobom;
        int eTemp, plTemp, rTemp, posXTemp, posYTemp;

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

        //Menu Models (inGame)
        List<Rectangle> playerBG = new List<Rectangle>();        
        List<Rectangle> pu = new List<Rectangle>();
        List<Rectangle> fademark = new List<Rectangle>();
        List<int> puR = new List<int>();
        List<int> puC = new List<int>();
        SolidBrush fader;
        int faderInt;
        



        public Form1()
        {
            InitializeComponent();

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
                  row += 1;
            }


            boR = 0;
            boTC = 6;
            boTR = 1;
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

           

        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            
            
            //0 - 4 Super Bomb
            //5 - 19 Skates
            //20 - 34 Bigger Bomb
            //35 - 49 Extra Bomb
            //50 - 59 Kick
            //60 - 69 Throw
            //70 - 84 Skull
            //84 - 89 Skatter Bomb
            //90 - 99 No Powerup



            for (int n = 0; n < power.Count; n++)
            {
                if (pTemp[n] >= 0 && pTemp[n] <= 4)
                {
                    powerVis[n] = true;
                    pR[n] = 1;
                    pC[n] = 3;
                }
                else
                    if (pTemp[n] >= 5 && pTemp[n] <= 19)
                    {
                        powerVis[n] = true;
                        pR[n] = 0;
                        pC[n] = 0;
                    }
                    else
                        if (pTemp[n] >= 20 && pTemp[n] <= 34)
                        {
                            powerVis[n] = true;
                            pR[n] = 1;
                            pC[n] = 1;
                        }
                        else
                            if (pTemp[n] >= 35 && pTemp[n] <= 49)
                            {
                                powerVis[n] = true;
                                pR[n] = 0;
                                pC[n] = 1;
                            }
                            else
                                if (pTemp[n] >= 50 && pTemp[n] <= 59)
                                {
                                    powerVis[n] = true;
                                    pR[n] = 1;
                                    pC[n] = 0;
                                }
                                else
                                    if (pTemp[n] >= 60 && pTemp[n] <= 69)
                                    {
                                        powerVis[n] = true;
                                        pR[n] = 0;
                                        pC[n] = 3;
                                    }
                                    else
                                        if (pTemp[n] >= 70 && pTemp[n] <= 84)
                                        {
                                            powerVis[n] = true;
                                            skull = true;
                                            pR[n] = 0;
                                            pC[n] = 2;
                                        }
                                        else
                                            if (pTemp[n] >= 84 && pTemp[n] <= 89)
                                            {
                                                powerVis[n] = true;
                                                pR[n] = 1;
                                                pC[n] = 2;
                                            }
                                            else
                                                if (pTemp[n] >= 90 && pTemp[n] <= 99)
                                                {
                                                    pR.RemoveAt(n);
                                                    pC.RemoveAt(n);
                                                    pTemp.RemoveAt(n);                                                    
                                                    power.RemoveAt(n);
                                                    powerVis.RemoveAt(n);
                                                }

            }

            

            

            this.Refresh();
        }

        private void tmrBombers_Tick(object sender, EventArgs e)
        {
            for (int n = 0; n < exp.Count; n++) 
            {
                for (int i = 0; i < bomb.Count; i++) 
                {
                    if(bomb[i].IntersectsWith(exp[n]) )
                    {
                        eTemp = i;
                        boomboom();
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
            for (int n = 0; n < Floor.Count; n++)
            {
                e.Graphics.DrawImage(FloorG, Floor[n]);
            }
            for (int n = 0; n < expCou.Count; n++)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    e.Graphics.DrawImage(Explosion, exp[i], new RectangleF(expC[i] * expW, expR[n] * expH, expW, expH), GraphicsUnit.Pixel);
                }
            }
            for (int n = 0; n < brickB.Count; n++)
            {
                e.Graphics.DrawImage(brickBreak, brickB[n], new RectangleF(brC * brW, brR[n] * brH, brW, brH), GraphicsUnit.Pixel); 
            }
             for (int n = 0; n < brickNB.Count; n++)
            {
                e.Graphics.DrawImage(npBreakBrick, brickNB[n]);
            }
            for (int n = 0; n < power.Count; n++) 
                {
                    if (powerVis[n] == true) 
                    {
                        e.Graphics.DrawImage(PowerUp, power[n], new RectangleF(pC[n] * pW, pR[n] * pH, pW, pH), GraphicsUnit.Pixel);
                    }
            }
            for (int n = 0; n < bomb.Count; n++)
            {
                e.Graphics.DrawImage(normalBomb, bomb[n], new RectangleF(boC[n] * boW, boR * boH, boW, boH), GraphicsUnit.Pixel);
            }

            for (int n = 0; n < pu.Count; n++)
            {                
                    e.Graphics.DrawImage(PowerUp, pu[n], new RectangleF(puC[n] * pW, puR[n] * pH, pW, pH), GraphicsUnit.Pixel);                
            }
            for (int n = 0; n < playerBG.Count; n++)
            {
                e.Graphics.FillRectangle(Brushes.Black, playerBG[n]);
            }
            for (int n = 0; n < fademark.Count; n++)
            {
                e.Graphics.FillRectangle(fader, fademark[n]);
            }
            /*for (int n = 0; n < pu.Count; n++)
            {
                e.Graphics.DrawImage(PowerUp, pu[n], new RectangleF(puC[n] * pW, puR[n] * pH, pW, pH), GraphicsUnit.Pixel);
            }*/

            


            
           
            
                e.Graphics.DrawString("" + eSize[0], new System.Drawing.Font("Lucida Console", 15), Brushes.White, this.Width - 100, 125);
                e.Graphics.DrawString("" + eSize[1], new System.Drawing.Font("Lucida Console", 15), Brushes.White, this.Width - 100, 150);
                e.Graphics.DrawString("" + eSize[2], new System.Drawing.Font("Lucida Console", 15), Brushes.White, this.Width - 100, 175);
                e.Graphics.DrawString("" + eSize[3], new System.Drawing.Font("Lucida Console", 15), Brushes.White, this.Width - 100, 200);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            
            
            if (e.KeyData == Keys.Delete) 
            {
                pTemp[0] = rdn.Next(0, 101);
            }

            if (e.KeyData == Keys.H)
            {
                eSize[0] += 1;
            }
            if (e.KeyData == Keys.J)
            {
                eSize[1] += 1;
            }
            if (e.KeyData == Keys.K)
            {
                eSize[2] += 1;
            }
            if (e.KeyData == Keys.L)
            {
                eSize[3] += 1;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

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

            if (row == 9) {

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

                xTemp = e.X;
                yTemp = e.Y;
                AddBomb();
                plTemp = rdn.Next(0, 4);

               /* if (e.X > brX[n] && e.X < brX[n] + brW && e.Y > brY[n] && e.Y < brY[n] + brH)
                {
                    breaker[n] = true;
                }*/
                
            }
        }

        private void powerSpawn() 
        {
            ppTemp = rdn.Next(0, 2);
            if (ppTemp >= 1) {
               
                pR.Add(0);
                pC.Add(0);
                pTemp.Add(0);
                powerVis.Add(false);
                pTemp[pTemp.Count -1] = rdn.Next(0, 101);
                power.Add(new Rectangle(brX[y] + 2, brY[y] + 2, pW, pH));
                
            }

            if (skull == true && pTemp[pTemp.Count - 1] >= 70 && pTemp[pTemp.Count - 1] <= 84 && ppTemp == 1) {

                while (pTemp[pTemp.Count - 1] >= 70 && pTemp[pTemp.Count - 1] <= 84) { 
                    pTemp[pTemp.Count - 1] = rdn.Next(0, 101);
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
                    eTemp = n;
                    boomboom();
                }
            }            
        }

        private void AddBomb() 
        {

            
            yPosB = (yTemp - 75) / 30;
            xPosB = (xTemp - 75) / 30;

            
                boX.Add(xPosB * 30 + 82);
                boY.Add(yPosB * 30 + 82);
                boCou.Add(0);
                boC.Add(0);
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

        private void boomboom() 
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

            if (eSize[plTemp] > 1)
            {
                for (int i = 1; i < eSize[plTemp]; i++)
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
                        for (int n = 1; n < brickB.Count; n++)
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
                        for (int n = 1; n < brickB.Count; n++)
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
                        for (int n = 1; n < brickB.Count; n++)
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
                        for (int n = 1; n < brickB.Count; n++)
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
                }
            }

                if (stU == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp - eSize[plTemp] * expH);
                    expC.Add(3);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stU == false)
                {
                    for (int n = 1; n < brickB.Count; n++)
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

                if (stD == false)
                {
                    expX.Add(posXTemp);
                    expY.Add(posYTemp + eSize[plTemp] * expH);
                    expC.Add(4);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stD == false)
                {
                    for (int n = 1; n < brickB.Count; n++)
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

                if (stR == false)
                {
                    expX.Add(posXTemp + eSize[plTemp] * expW);
                    expY.Add(posYTemp);
                    expC.Add(5);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }

                if (stR == false)
                {
                    for (int n = 1; n < brickB.Count; n++)
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

                if (stL == false)
                {
                    expX.Add(posXTemp - eSize[plTemp] * expW);
                    expY.Add(posYTemp);
                    expC.Add(6);
                    exp.Add(new Rectangle(expX[exp.Count], expY[exp.Count], expW, expH));

                    expRecCou[expRecCou.Count - 1] += 1;
                }


                if (stL == false)
                {
                    for (int n = 1; n < brickB.Count; n++)
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

            boX.RemoveAt(eTemp);
            boY.RemoveAt(eTemp);
            boCou.RemoveAt(eTemp);
            boC.RemoveAt(eTemp);
            bomb.RemoveAt(eTemp);
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
                    if (pTemp[n] >= 70 && pTemp[n] <= 84) { skull = false; }
                    pR.RemoveAt(n);
                    pC.RemoveAt(n);
                    pTemp.RemoveAt(n);
                    powerVis.RemoveAt(n);
                    power.RemoveAt(n);
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