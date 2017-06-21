using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using manipulatorDriver;
using ManipulatorDriver;
using Driver;

// dodaj zmianę prędkości 

namespace Projekt
{



    public partial class Form1 : Form

    {



        Driver.E3JManipulator Manipulator = new Driver.E3JManipulator();

        public Form1()
        {
            InitializeComponent();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Disc_btn_Click(object sender, EventArgs e)
        {


        }

        private void Chw_Otw_Click(object sender, EventArgs e)
        {
            Manipulator.GrabOpen();
        }

        private void Chw_zamk_Click(object sender, EventArgs e)
        {
            Manipulator.GrabClose();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manipulator.MoveJoint(10, 0, 0, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manipulator.MoveJoint(0, -10, 0, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manipulator.MoveJoint(0, 10, 0, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Manipulator.MoveJoint(0, 0, -10, 0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Manipulator.MoveJoint(0, 0, 10, 0, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Manipulator.MoveJoint(0, 0, 0, -10, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Manipulator.MoveJoint(0, 0, 0, 10, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Manipulator.MoveJoint(0, 0, 0, 0, -10);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Manipulator.MoveJoint(0, 0, 0, 0, 10);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(-10, 0, 0);
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(10, 0, 0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(0, -10, 0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(0, 10, 0);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(0, 0, -10);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(0, 0, 10);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int X = int.Parse(Osx.Text);                                            // wybierz współrzędną osi X
            int Y = int.Parse(Osy.Text);                                            // wybierz współrzędną osi Y
            int Z = int.Parse(Osz.Text);                                            // wybierz współrzędną osi Z
            Manipulator.MovePosition(X, Y, Z, 0, 0);
        }

        private void Con_btn_Click(object sender, EventArgs e)
        {
            SerialPort.GetPortNames();
            Manipulator.Connect(comboBox1.Text);                                    // połączenia z manipulatorem 

            textBox1.Text = comboBox1.Text;                                         // Connection - zielone + / czerwone - niepołączony (czerwony jest ustawiony domyślnie) 
            //      pictureBox1.Image = green;             
            pictureBox1.Image = Projekt.Properties.Resources.green;                 // zczytanie obraka

        }

        private void button9_Click_1(object sender, EventArgs e)                    // obróć chwytak prawo/lewo
        {
               Manipulator.MoveJoint(0, 0, 0, 0, -10);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Disc_btn_Click_1(object sender, EventArgs e)
        {
            Manipulator.Disconnect();
            pictureBox1.Image = Projekt.Properties.Resources.red;
        }

        private void button1_Click_2(object sender, EventArgs e)                                // obróć robot prawo/lewo (oś 1 ) 
        {
            Manipulator.MoveJoint(-10, 0, 0, 0, 0);
        }

        private void button2_Click_1(object sender, EventArgs e)                                // obróć robot prawo/lewo (oś 1) 
        {
            Manipulator.MoveJoint(10, 0, 0, 0, 0);
        }

        private void button3_Click_1(object sender, EventArgs e)                                // obróć robot góra/dół (oś 2)
        {
            Manipulator.MoveJoint(0, -10, 0, 0, 0);
        }

        private void button4_Click_1(object sender, EventArgs e)                                // obróć robot góra/dół (oś 2)
        {
            Manipulator.MoveJoint(0, 10, 0, 0, 0);
        }

        private void button5_Click_1(object sender, EventArgs e)                                   // obróć robot góra/dół (oś 3)
        {
            Manipulator.MoveJoint(0, 0, -10, 0, 0);
        }

        private void button6_Click_1(object sender, EventArgs e)                                // obróć robot góra/dół (oś 3)
        {
            Manipulator.MoveJoint(0, 0, 10, 0, 0);
        }

        private void button7_Click_1(object sender, EventArgs e)                                // obróć robot góra/dół (oś 4)
        {
               Manipulator.MoveJoint(0, 0, 0, -10, 0);
        }

        private void button8_Click_1(object sender, EventArgs e)                                // obróć robot góra/dół (oś 4)
        {
            Manipulator.MoveJoint(0, 0, 0, 10, 0);
        }

        private void button10_Click_1(object sender, EventArgs e)                                // obróć chwytak prawo/lewo(oś 2)
        {
               Manipulator.MoveJoint(0, 0, 0, 0, 10);
        }

        private void Chw_Otw_Click_1(object sender, EventArgs e)                                    // otwórz chwytak 
        {
               Manipulator.GrabOpen();                                                                 // 
        }

        private void Chw_zamk_Click_1(object sender, EventArgs e)                                   // zamknij chwytak
        {
            Manipulator.GrabClose();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(-10, 0, 0);
        }

        private void button12_Click_2(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(10, 0, 0);
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(0, -10, 0);
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(0, 10, 0);
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(0, 0, -10);
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            Manipulator.DrawStraight(0, 0, 10);
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            int X = int.Parse(Osx.Text);
            int Y = int.Parse(Osy.Text);
            int Z = int.Parse(Osz.Text);
            Manipulator.MovePosition(X, Y, Z, 0,  0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
           
        }
    }

    /* public class Listener : ManipulatorDriver.Observer

     {
         public E3JManipulator Manipulator { get; private set; }

         public Listener(E3JManipulator manipulator)
         {
             Manipulator = manipulator;
             Manipulator.Subscribe(this);
         }

         public void GetNotified(string message)
         {
             // proccess data
         }
     }*/
    public class Listener : Observer
    {
        public E3JManipulator Manipulator { get;  set; }
 
        public Listener()
        {

        }

        public void getNotified(string message)
        {
            Form1.textBox2.Text = message;
        }
    }

    public class SomeRandomShit
    {
        public E3JManipulator Manipulator { get; private set; }
        public Listener SomeListener { get; private set; }

        public SomeRandomShit()
        {
            Manipulator = new E3JManipulator();
            SomeListener = new Listener();

            SomeListener.Manipulator = Manipulator;
            Manipulator.Port.Subscribe(SomeListener);
        }

    }
}
