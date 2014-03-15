using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Tetris : Form
    {
        Label[,] bric = new Label[10, 23];
        Label[,] nextbrick=new Label[3,4];
        int[] randombrick = new int[7];
        int[] brickx=new  int[4];
        int[] bricky = new int[4];
        int brickstyle;
        int brickstate;
        int hold=-1;
        Color die = Color.Gray;
        public Tetris()
        {
            InitializeComponent();
        }
        private void Tetris_Load(object sender, EventArgs e)
        {
            for(int x=0;x<10;x++)
            {
                for(int y=0;y<23;y++)
                {
                    bric[x, y] = new Label();
                    bric[x, y].BorderStyle = BorderStyle.Fixed3D;
                    bric[x, y].Left = x *25;
                    bric[x, y].Top = y * 25-75;
                    bric[x, y].Width = bric[x, y].Height = 25;
                    this.Controls.Add(bric[x, y]);
                }
            }
            for(int x=0;x<3;x++)
            {
                for(int y=0;y<4;y++)
                {
                    nextbrick[x, y] = new Label();
                    nextbrick[x, y].BorderStyle = BorderStyle.Fixed3D;
                    nextbrick[x, y].Left = x * 25 + 280;
                    nextbrick[x, y].Top = y * 25 + 100;
                    nextbrick[x, y].Width = nextbrick[x, y].Height = 25;
                    this.Controls.Add(nextbrick[x, y]);
                }
            }
            RandomBrick();
        }

        private void Gravity_Tick(object sender, EventArgs e)
        {
            if (bricky[0] < 22 && bricky[1] < 22 && bricky[2] < 22 && bricky[3] < 22
                && bric[brickx[0], bricky[0] + 1].BackColor != die
                && bric[brickx[1], bricky[1] + 1].BackColor != die
                && bric[brickx[2], bricky[2] + 1].BackColor != die
                && bric[brickx[3], bricky[3] + 1].BackColor != die)
            {
                for (int i = 0; i < 4;i++ )
                {
                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                }
                for(int i=0;i<4;i++)
                {
                    bric[brickx[i], ++bricky[i]].BackColor = Color.Blue; 
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                    bric[brickx[i], bricky[i]].BackColor = die;
                if (bricky[0] < 4 || bricky[1] < 4 || bricky[2] < 4 || bricky[3] < 4)
                {
                    Gravity.Enabled = false;
                    MessageBox.Show("lose");
                    btnRestart.Enabled = true;
                }
                CheckAndClean();
                nextbric();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 23; y++)
                    bric[x, y].BackColor = SystemColors.Control;
            Gravity.Interval = 250;
            lblLine.Text = "0";
                    nextbric();
            Gravity.Enabled = true;
            btnRestart.Enabled = false;
        }
        private void nextbric()
        {
            if (brickstyle == 7)
            { brickstyle = 0; RandomBrick(); }
            if(brickstyle<7)
            {
                switch(randombrick[brickstyle])
                {
                    case 0://I
                        brickx[0]=4;bricky[0]=0;
                        brickx[1]=4;bricky[1]=1;
                        brickx[2]=4;bricky[2]=2;
                        brickx[3]=4;bricky[3]=3;
                        break;
                    case 1://T
                        brickx[0]=3;bricky[0]=1;
                        brickx[1]=4;bricky[1]=0;
                        brickx[2]=4;bricky[2]=1;
                        brickx[3]=5;bricky[3]=1;
                        break;
                    case 2://O
                        brickx[0]=4;bricky[0]=0;
                        brickx[1]=5;bricky[1]=0;
                        brickx[2]=4;bricky[2]=1;
                        brickx[3]=5;bricky[3]=1;
                        break;
                    case 3://L
                        brickx[0]=4;bricky[0]=0;
                        brickx[1]=4;bricky[1]=1;
                        brickx[2]=4;bricky[2]=2;
                        brickx[3]=5;bricky[3]=2;
                        break;
                    case 4://J
                        brickx[0]=4;bricky[0]=2;
                        brickx[1]=5;bricky[1]=0;
                        brickx[2]=5;bricky[2]=1;
                        brickx[3]=5;bricky[3]=2;
                        break;
                    case 5://Z
                        brickx[0]=4;bricky[0]=0;
                        brickx[1]=5;bricky[1]=0;
                        brickx[2]=5;bricky[2]=1;
                        brickx[3]=6;bricky[3]=1;
                        break;
                    case 6:
                        brickx[0]=4;bricky[0]=1;
                        brickx[1]=5;bricky[1]=0;
                        brickx[2]=5;bricky[2]=1;
                        brickx[3]=6;bricky[3]=0;
                        break;
                }
                brickstyle++;
                for (int x = 0; x < 3; x++)
                    for (int y = 0; y < 4; y++)
                        nextbrick[x, y].BackColor =SystemColors.Control;
                switch (brickstyle == 7 ? -1: randombrick[brickstyle])
                {
                    case 1://T
                        nextbrick[0,3].BackColor=Color.Blue;
                        nextbrick[1,3].BackColor=Color.Blue;
                        nextbrick[2,3].BackColor=Color.Blue;
                        nextbrick[1,2].BackColor=Color.Blue;
                        break;
                    case 2://o
                        nextbrick[0,2].BackColor=Color.Blue;
                        nextbrick[0,3].BackColor=Color.Blue;
                        nextbrick[1,2].BackColor=Color.Blue;
                        nextbrick[1,3].BackColor=Color.Blue;
                        break;
                    case 3://l
                        nextbrick[1,1].BackColor=Color.Blue;
                        nextbrick[1,2].BackColor=Color.Blue;
                        nextbrick[1,3].BackColor=Color.Blue;
                        nextbrick[2,3].BackColor=Color.Blue;
                        break;
                    case 4://j
                        nextbrick[1,1].BackColor=Color.Blue;
                        nextbrick[1,2].BackColor=Color.Blue;
                        nextbrick[1,3].BackColor=Color.Blue;
                        nextbrick[0,3].BackColor=Color.Blue;
                        break;
                    case 5://z
                        nextbrick[0,2].BackColor=Color.Blue;
                        nextbrick[1,2].BackColor=Color.Blue;
                        nextbrick[1,3].BackColor=Color.Blue;
                        nextbrick[2,3].BackColor=Color.Blue;
                        break;
                    case 6://s
                        nextbrick[0,3].BackColor=Color.Blue;
                        nextbrick[1,3].BackColor=Color.Blue;
                        nextbrick[1,2].BackColor=Color.Blue;
                        nextbrick[2,2].BackColor=Color.Blue;
                        break;
                    case 0://i
                        nextbrick[1,0].BackColor=Color.Blue;
                        nextbrick[1,1].BackColor=Color.Blue;
                        nextbrick[1,2].BackColor=Color.Blue;
                        nextbrick[1,3].BackColor=Color.Blue;
                        break;
                }
            }
            brickstate = 1;
        }
        private void keydown(object sender,KeyEventArgs e)
        {
            Gravity.Enabled = false;
            switch(e.KeyCode)
            {
                case Keys.Left:
                    if (brickx[0]>0 && brickx[1]>0 && brickx[2]>0 && brickx[3]>0
                        && bric[brickx[0]-1, bricky[0]].BackColor != die
                        && bric[brickx[1] - 1, bricky[1]].BackColor != die
                        && bric[brickx[2] - 1, bricky[2]].BackColor != die
                        && bric[brickx[3] - 1, bricky[3]].BackColor != die)
                    {
                        for (int i = 0; i < 4; i++)
                            bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                        for (int i = 0; i < 4; i++)
                            bric[--brickx[i], bricky[i]].BackColor = Color.Blue;
                    }
                    break;
                case Keys.Right:
                    if (brickx[0] < 9 && brickx[1] < 9 && brickx[2] < 9 && brickx[3] < 9
                        && bric[brickx[0] + 1, bricky[0]].BackColor != die
                        && bric[brickx[1] + 1, bricky[1]].BackColor != die
                        && bric[brickx[2] + 1, bricky[2]].BackColor != die
                        && bric[brickx[3] + 1, bricky[3]].BackColor != die)
                    {
                        for (int i = 0; i < 4; i++)
                            bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                        for (int i = 0; i < 4; i++)
                            bric[++brickx[i], bricky[i]].BackColor = Color.Blue;
                    }
                    break;
                case Keys.Up:
                    spin();
                    break;
                case Keys.Down:
                    Gravity_Tick(sender, e);
                    break;
                case Keys.Z:
                    int b = brickstyle;
                    while(b==brickstyle)
                        Gravity_Tick(sender, e);
                    break;
                case Keys.ShiftKey:
                    for (int i = 0; i < 3;i++)
                        spin();
                    break;
            }
            Gravity.Enabled = true;
        }
      private void CheckAndClean()
        {
            int clean = 0; bool c = false;
            for(int index=0;index<4;index++)
            {
                for(int i=0;i<10;i++)
                {
                    if (bric[i, bricky[index]].BackColor == die)
                        clean++;
                }
                if(clean==10)
                {
                    c = true;
                    lblLine.Text = (int.Parse(lblLine.Text) + 1).ToString();
                    Gravity.Interval -= 5;
                    for (int i = 0; i < 10; i++)
                        bric[i, bricky[index]].BackColor =SystemColors.Control;
                }
                clean = 0;
            }
            if (c == false) return;
          for(int y=21;y>3;y--)
          {
              for(int x=0;x<10;x++)
              {
                  if (bric[x, y].BackColor == die)
                  {
                      int t = y;
                      while (y < 22 && bric[x, y + 1].BackColor != die)
                      {
                          bric[x, y].BackColor = SystemColors.Control;
                          bric[x, ++y].BackColor = die;
                      }
                      y = t;
                  } 
              }
          }
        }
        private bool DownLine(int y)
      {
            for(int x=0;x<10;x++)
            {
                if (bric[x, y + 1].BackColor == die) return false;
            }
            return true;
      }
        private void spin()
        {
            switch (randombrick[brickstyle-1])
            {
                case 0:
                    switch (brickstate)
                    {
                        case 1:
                            if (brickx[0] > 0 && brickx[0] < 9 &&
                                bric[brickx[0] - 1, bricky[0] + 1].BackColor != die
                                && bric[brickx[1], bricky[1]].BackColor != die
                                && bric[brickx[2] + 1, bricky[2] - 1].BackColor != die
                                && bric[brickx[3] + 2, bricky[3] - 2].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[--brickx[0], ++bricky[0]].BackColor = Color.Blue;
                                bric[brickx[1], bricky[1]].BackColor = Color.Blue;
                                bric[++brickx[2], --bricky[2]].BackColor = Color.Blue;
                                brickx[3] += 2; bricky[3] -= 2;
                                bric[brickx[3], bricky[3]].BackColor = Color.Blue;
                                brickstate = 2;
                            }
                            break;
                        case 2:
                            if (bricky[0] < 21 &&
                                bric[brickx[0] + 1, bricky[0] - 1].BackColor != die
                                && bric[brickx[1], bricky[1]].BackColor != die
                                && bric[brickx[2] - 1, bricky[2] + 1].BackColor != die
                                && bric[brickx[3] - 2, bricky[3] + 2].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[++brickx[0], --bricky[0]].BackColor = Color.Blue;
                                bric[brickx[1], bricky[1]].BackColor = Color.Blue;
                                bric[--brickx[2], ++bricky[2]].BackColor = Color.Blue;
                                brickx[3] -= 2; bricky[3] += 2;
                                bric[brickx[3], bricky[3]].BackColor = Color.Blue;
                                brickstate = 1;
                            }
                            break;
                    }
                    break;
                case 1:
                    switch (brickstate)
                    {
                        case 1:
                            if (brickx[0] < 22 &&
                                bric[brickx[0] + 1, bricky[0] - 1].BackColor != die
                                && bric[brickx[1] + 1, bricky[1] + 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] - 1, bricky[3] + 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[++brickx[0], --bricky[0]].BackColor = Color.Blue;
                                bric[++brickx[1], ++bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[--brickx[3], ++bricky[3]].BackColor = Color.Blue;
                                brickstate = 2;
                            }
                            break;
                        case 2:
                            if (brickx[2] > 0 &&
                                bric[brickx[0] + 1, bricky[0] + 1].BackColor != die
                                && bric[brickx[1] - 1, bricky[1] + 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] - 1, bricky[3] - 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[++brickx[0], ++bricky[0]].BackColor = Color.Blue;
                                bric[--brickx[1], ++bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[--brickx[3], --bricky[3]].BackColor = Color.Blue;
                                brickstate = 3;
                            }
                            break;
                        case 3:
                            if (bric[brickx[0] - 1, bricky[0] + 1].BackColor != die
                                && bric[brickx[1] - 1, bricky[1] - 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] + 1, bricky[3] - 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[--brickx[0], ++bricky[0]].BackColor = Color.Blue;
                                bric[--brickx[1], --bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[++brickx[3], --bricky[3]].BackColor = Color.Blue;
                                brickstate = 4;
                            }
                            break;
                        case 4:
                            if (brickx[2] < 9 &&
                                bric[brickx[0] - 1, bricky[0] - 1].BackColor != die
                                && bric[brickx[1] + 1, bricky[1] - 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] + 1, bricky[3] + 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[--brickx[0], --bricky[0]].BackColor = Color.Blue;
                                bric[++brickx[1], --bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[++brickx[3], ++bricky[3]].BackColor = Color.Blue;
                                brickstate = 1;
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (brickstate)
                    {
                        case 1:
                            if (brickx[2] > 0 &&
                                bric[brickx[0] - 1, bricky[0] + 1].BackColor != die
                                && bric[brickx[1], bricky[1]].BackColor != die
                                && bric[brickx[2] + 1, bricky[2] - 1].BackColor != die
                                && bric[brickx[3], bricky[3] - 2].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[--brickx[0], ++bricky[0]].BackColor = Color.Blue;
                                bric[brickx[1], bricky[1]].BackColor = Color.Blue;
                                bric[++brickx[2], --bricky[2]].BackColor = Color.Blue;
                                bricky[3] -= 2;
                                bric[brickx[3], bricky[3]].BackColor = Color.Blue;
                                brickstate = 2;
                            }
                            break;
                        case 2:
                            if (bricky[1] < 22 &&
                                bric[brickx[0] + 1, bricky[0] + 1].BackColor != die
                                && bric[brickx[1], bricky[1]].BackColor != die
                                && bric[brickx[2] - 1, bricky[2] - 1].BackColor != die
                                && bric[brickx[3] - 2, bricky[3]].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[++brickx[0], ++bricky[0]].BackColor = Color.Blue;
                                bric[brickx[1], bricky[1]].BackColor = Color.Blue;
                                bric[--brickx[2], --bricky[2]].BackColor = Color.Blue;
                                brickx[3] -= 2;
                                bric[brickx[3], bricky[3]].BackColor = Color.Blue;
                                brickstate = 3;
                            }
                            break;
                        case 3:
                            if (brickx[1] < 9 &&
                                bric[brickx[0] + 1, bricky[0] - 1].BackColor != die
                                && bric[brickx[1], bricky[1]].BackColor != die
                                && bric[brickx[2] - 1, bricky[2] + 1].BackColor != die
                                && bric[brickx[3], bricky[3] + 2].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[++brickx[0], --bricky[0]].BackColor = Color.Blue;
                                bric[brickx[1], bricky[1]].BackColor = Color.Blue;
                                bric[--brickx[2], ++bricky[2]].BackColor = Color.Blue;
                                bricky[3] += 2;
                                bric[brickx[3], bricky[3]].BackColor = Color.Blue;
                                brickstate = 4;
                            }
                            break;
                        case 4:
                            if (bric[brickx[0] - 1, bricky[0] - 1].BackColor != die
                                && bric[brickx[1], bricky[1]].BackColor != die
                                && bric[brickx[2] + 1, bricky[2] + 1].BackColor != die
                                && bric[brickx[3] + 2, bricky[3]].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[--brickx[0], --bricky[0]].BackColor = Color.Blue;
                                bric[brickx[1], bricky[1]].BackColor = Color.Blue;
                                bric[++brickx[2], ++bricky[2]].BackColor = Color.Blue;
                                brickx[3] += 2;
                                bric[brickx[3], bricky[3]].BackColor = Color.Blue;
                                brickstate = 1;
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (brickstate)
                    {
                        case 1:
                            if (brickx[2] < 9 &&
                                bric[brickx[0], bricky[0] - 2].BackColor != die
                                && bric[brickx[1] + 1, bricky[1] + 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] - 1, bricky[3] - 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bricky[0] -= 2;
                                bric[brickx[0], bricky[0]].BackColor = Color.Blue;
                                bric[++brickx[1], ++bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[--brickx[3], --bricky[3]].BackColor = Color.Blue;
                                brickstate = 2;
                            }
                            break;
                        case 2:
                            if (bricky[2] < 22 &&
                                bric[brickx[0] + 2, bricky[0]].BackColor != die
                                && bric[brickx[1] - 1, bricky[1] + 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] + 1, bricky[3] - 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                brickx[0] += 2;
                                bric[brickx[0], bricky[0]].BackColor = Color.Blue;
                                bric[--brickx[1], ++bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[++brickx[3], --bricky[3]].BackColor = Color.Blue;
                                brickstate = 3;
                            }
                            break;
                        case 3:
                            if (brickx[2] > 0 &&
                                bric[brickx[0], bricky[0] + 2].BackColor != die
                                && bric[brickx[1] - 1, bricky[1] - 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] + 1, bricky[3] + 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bricky[0] += 2;
                                bric[brickx[0], bricky[0]].BackColor = Color.Blue;
                                bric[--brickx[1], --bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[++brickx[3], ++bricky[3]].BackColor = Color.Blue;
                                brickstate = 4;
                            }
                            break;
                        case 4:
                            if (bric[brickx[0] - 2, bricky[0]].BackColor != die
                                && bric[brickx[1] + 1, bricky[1] - 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] - 1, bricky[3] + 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                brickx[0] -= 2;
                                bric[brickx[0], bricky[0]].BackColor = Color.Blue;
                                bric[++brickx[1], --bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[--brickx[3], ++bricky[3]].BackColor = Color.Blue;
                                brickstate = 1;
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (brickstate)
                    {
                        case 1:
                            if (bricky[2] < 22 &&
                                bric[brickx[0] + 2, bricky[0]].BackColor != die
                                && bric[brickx[1] + 1, bricky[1] + 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] - 1, bricky[3] + 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                brickx[0] += 2;
                                bric[brickx[0], bricky[0]].BackColor = Color.Blue;
                                bric[++brickx[1], ++bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[--brickx[3], ++bricky[3]].BackColor = Color.Blue;
                                brickstate = 2;
                            }
                            break;
                        case 2:
                            if (brickx[0] > 0 &&
                                bric[brickx[0] - 2, bricky[0]].BackColor != die
                                && bric[brickx[1] - 1, bricky[1] - 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] + 1, bricky[3] - 1].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                brickx[0] -= 2;
                                bric[brickx[0], bricky[0]].BackColor = Color.Blue;
                                bric[--brickx[1], --bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                bric[++brickx[3], --bricky[3]].BackColor = Color.Blue;
                                brickstate = 1;
                            }
                            break;
                    }
                    break;
                case 6:
                    switch (brickstate)
                    {
                        case 1:
                            if (bricky[0] < 22 &&
                                bric[brickx[0] + 1, bricky[0] + 1].BackColor != die
                                && bric[brickx[1] - 1, bricky[1] + 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] - 2, bricky[3]].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[++brickx[0], ++bricky[0]].BackColor = Color.Blue;
                                bric[--brickx[1], ++bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                brickx[3] -= 2;
                                bric[brickx[3], bricky[3]].BackColor = Color.Blue;
                                brickstate = 2;
                            }
                            break;
                        case 2:
                            if (brickx[3] < 9 &&
                                bric[brickx[0] - 1, bricky[0] - 1].BackColor != die
                                && bric[brickx[1] + 1, bricky[1] - 1].BackColor != die
                                && bric[brickx[2], bricky[2]].BackColor != die
                                && bric[brickx[3] + 2, bricky[3]].BackColor != die)
                            {
                                for (int i = 0; i < 4; i++)
                                    bric[brickx[i], bricky[i]].BackColor = SystemColors.Control;
                                bric[--brickx[0], --bricky[0]].BackColor = Color.Blue;
                                bric[++brickx[1], --bricky[1]].BackColor = Color.Blue;
                                bric[brickx[2], bricky[2]].BackColor = Color.Blue;
                                brickx[3] += 2;
                                bric[brickx[3], bricky[3]].BackColor = Color.Blue;
                                brickstate = 1;
                            }
                            break;
                    }
                    break;
            }
        }
        private void RandomBrick()
        {
            Random R = new Random();
            for (int i = 0; i < 7; i++)
            {
                randombrick[i] = R.Next(7);
                for (int j = 0; j < i; j++)
                {
                    if (randombrick[i] == randombrick[j])
                    { i--; break; }
                }
            }
        }
    }
}
