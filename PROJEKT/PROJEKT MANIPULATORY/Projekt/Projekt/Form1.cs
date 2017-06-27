using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;
using Driver;
using Projekt.Properties;

// dodaj zmianę prędkości 

namespace Projekt
{
    public partial class Form1 : Form
    {
        private readonly E3JManipulator manipulator;

        public Form1()
        {
            InitializeComponent();
            foreach (var port in SerialPort.GetPortNames())
            {
                comboBoxPorts.Items.Add(port);
            }
            manipulator = File.Exists("SerialSettings.json") ?
                new E3JManipulator(DriverSettings.CreateFromSettingFile()) :
                new E3JManipulator(DriverSettings.CreateDefaultSettings());
            manipulator.Port.DataReceived += Port_DataReceived;
            manipulator.Port.ConnectionStatusChanged += Port_ConnectionStatusChanged;
        }

        private void Port_ConnectionStatusChanged(object sender, ConnectionStatusChangedArgs e)
        {
            if (e.OldStatus && !e.NewStatus)
            {
                // obsłużyć rozłączenie  
            }
        }

        private void Port_DataReceived(string data)
        {
            richTextBoxRead.Text += data;
        }

        private async void SendProgram()
        {
            var programService = new ProgramService(manipulator);
            var program = new Driver.Program("test")
            {
                Content = richTextBoxRead.Text

            };
            await programService.UploadProgram(program);
            var programs = await programService.ReadProgramInfo();
            var programa = await programService.DownloadProgram(programs[0]);
            richTextBoxRead.Text = programa.Content;
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
            manipulator.GrabOpen();
        }

        private void Chw_zamk_Click(object sender, EventArgs e)
        {
            manipulator.GrabClose();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manipulator.MoveJoint(10, 0, 0, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manipulator.MoveJoint(0, -10, 0, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            manipulator.MoveJoint(0, 10, 0, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            manipulator.MoveJoint(0, 0, -10, 0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            manipulator.MoveJoint(0, 0, 10, 0, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            manipulator.MoveJoint(0, 0, 0, -10, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            manipulator.MoveJoint(0, 0, 0, 10, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            manipulator.MoveJoint(0, 0, 0, 0, -10);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            manipulator.MoveJoint(0, 0, 0, 0, 10);
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
            manipulator.DrawStraight(-10, 0, 0);
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            manipulator.DrawStraight(10, 0, 0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            manipulator.DrawStraight(0, -10, 0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            manipulator.DrawStraight(0, 10, 0);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            manipulator.DrawStraight(0, 0, -10);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            manipulator.DrawStraight(0, 0, 10);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var X = int.Parse(Osx.Text); // wybierz współrzędną osi X
            var Y = int.Parse(Osy.Text); // wybierz współrzędną osi Y
            var Z = int.Parse(Osz.Text); // wybierz współrzędną osi Z
            manipulator.MovePosition(X, Y, Z, 0, 0);
        }

        private void Con_btn_Click(object sender, EventArgs e)
        {
            SerialPort.GetPortNames();
            if (string.IsNullOrWhiteSpace(comboBoxPorts.Text))
            {
                //manipulator.Connect(comboBoxPorts.Text); // połączenia z manipulatorem 

                pictureBox1.Image = Resources.green; // zczytanie obraka
                manipulator.Settings.PortName = "COM1";
                manipulator.Settings.SaveToFile();
            }
            else
            {
                MessageBox.Show("Invalid port");
            }
        }

        private void button9_Click_1(object sender, EventArgs e) // obróć chwytak prawo/lewo
        {
            manipulator.MoveJoint(0, 0, 0, 0, -10);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void Disc_btn_Click_1(object sender, EventArgs e)
        {
            manipulator.Disconnect();
            pictureBox1.Image = Resources.red;
        }

        private void button1_Click_2(object sender, EventArgs e) // obróć robot prawo/lewo (oś 1 ) 
        {
            manipulator.MoveJoint(-10, 0, 0, 0, 0);
        }

        private void button2_Click_1(object sender, EventArgs e) // obróć robot prawo/lewo (oś 1) 
        {
            manipulator.MoveJoint(10, 0, 0, 0, 0);
        }

        private void button3_Click_1(object sender, EventArgs e) // obróć robot góra/dół (oś 2)
        {
            manipulator.MoveJoint(0, -10, 0, 0, 0);
        }

        private void button4_Click_1(object sender, EventArgs e) // obróć robot góra/dół (oś 2)
        {
            manipulator.MoveJoint(0, 10, 0, 0, 0);
        }

        private void button5_Click_1(object sender, EventArgs e) // obróć robot góra/dół (oś 3)
        {
            manipulator.MoveJoint(0, 0, -10, 0, 0);
        }

        private void button6_Click_1(object sender, EventArgs e) // obróć robot góra/dół (oś 3)
        {
            manipulator.MoveJoint(0, 0, 10, 0, 0);
        }

        private void button7_Click_1(object sender, EventArgs e) // obróć robot góra/dół (oś 4)
        {
            manipulator.MoveJoint(0, 0, 0, -10, 0);
        }

        private void button8_Click_1(object sender, EventArgs e) // obróć robot góra/dół (oś 4)
        {
            manipulator.MoveJoint(0, 0, 0, 10, 0);
        }

        private void button10_Click_1(object sender, EventArgs e) // obróć chwytak prawo/lewo(oś 2)
        {
            manipulator.MoveJoint(0, 0, 0, 0, 10);
        }

        private void Chw_Otw_Click_1(object sender, EventArgs e) // otwórz chwytak 
        {
            manipulator.GrabOpen(); // 
        }

        private void Chw_zamk_Click_1(object sender, EventArgs e) // zamknij chwytak
        {
            manipulator.GrabClose();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            manipulator.DrawStraight(-10, 0, 0);
        }

        private void button12_Click_2(object sender, EventArgs e)
        {
            manipulator.DrawStraight(10, 0, 0);
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            manipulator.DrawStraight(0, -10, 0);
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            manipulator.DrawStraight(0, 10, 0);
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            manipulator.DrawStraight(0, 0, -10);
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            manipulator.DrawStraight(0, 0, 10);
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            var X = int.Parse(Osx.Text);
            var Y = int.Parse(Osy.Text);
            var Z = int.Parse(Osz.Text);
            manipulator.MovePosition(X, Y, Z, 0, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void button18_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBoxRead_TextChanged(object sender, EventArgs e)
        {

        }

        private void uploadButton_Click(object sender, EventArgs e)
        {

            var programService = new ProgramService(manipulator);
            var program = new Driver.Program("test");
            program.Content = richTextBoxProgram.Text;          
         }

        private void runButton_Click(object sender, EventArgs e)
        {
            
            var programService = new ProgramService(manipulator);
            var programs =  programService.ReadProgramInfo();
            var programa = programService.DownloadProgram(programs[0]);
            programService.RunProgram.programa;

        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            var programService = new ProgramService(manipulator);
            programService.StopProgram();
        }

        private void Osx_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
