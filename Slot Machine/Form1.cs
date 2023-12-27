using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slot_Machine
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        public static long Credits = 100;
        public static long Total = 0;
        public static int bet = 5;

        public static int p1;
        public static int p2;
        public static int p3;

       

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("1.jpg");
            pictureBox2.Image = Image.FromFile("2.jpg");
            pictureBox3.Image = Image.FromFile("3.jpg");

           
        }

        

        // GENERATES RANDOM NUMBERS
        public static class Number
        {
            private static Random randomN;

            private static void Init()
            {
                if (randomN == null) randomN = new Random();
            }
            public static int Random(int min, int max)
            {
                Init();
                return randomN.Next(min, max);
            }
        }

        public static void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer("anazgul_scream.wav");
            simpleSound.Play();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (bet <=Credits )
            {
                Credits = Credits - bet;
                label1.Text = "Credits: "+ Credits.ToString();

                for(var i = 0; i < 10; i ++ )
                {
                    p1 = Number.Random(1, 4);
                    p2 = Number.Random(1, 4);
                    p3 = Number.Random(1, 4);
                }

                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = Image.FromFile(p1.ToString() + ".jpg");

                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = Image.FromFile(p2.ToString() + ".jpg");

                if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                pictureBox3.Image = Image.FromFile(p3.ToString() + ".jpg");


                Total = 0;

                //Results to payout

                if (p1 == 3 || p2 ==3 || p3==3)
                    Total = Total - 1;

                if (p1 == 1 || p2 == 1 || p2 == 1)
                    Total = Total + 2;
                               

                if (p1 == 1 & p2 == 2 & p3 == 3)
                    Total = Total + 50;

                if (p1 == 3 & p2 == 2 & p3 == 1)
                    Total = Total + 50;

                // All the same
                if (p1 == 1 & p2 == 1 & p3 == 1)
                    Total = Total + 20;

                if (p1 == 2 & p2 == 2 & p3 == 2)
                    Total = Total + 10;

                if (p1 == 3 & p2 == 3 & p3 == 3)
                    Total = Total - 25;

                Credits = Credits + Total;
                label2.Text = "Win: " + Total.ToString();
                


            }
            
                       
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Timetimer1_Tick(object sender, EventArgs e)
        {
          

            label3.Text = DateTime.Now.ToLongTimeString();

            if (Credits - bet < 0)
            {
                pictureBox1.Image = Image.FromFile("4.jpg");
                pictureBox2.Image = Image.FromFile("4.jpg");
                pictureBox3.Image = Image.FromFile("4.jpg");

               label4.Visible = true;

                this.BackgroundImage = Image.FromFile("mordor.jpg");
                playSimpleSound();
                Timetimer1.Stop();
            }

           
        }

      
    }
}
