using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainWindow : Form
    {
        private Calculator calculator;

        public MainWindow()
        {
            calculator = new Calculator();
            this.KeyUp += new KeyEventHandler(Calculate_Click);
            InitializeComponent();
        }

        private void ChangeText()
        {
            outputBox.Text = calculator.Number1 + calculator.Operation + calculator.Number2;
        }

        private void OnDivideClick(object sender, EventArgs e)
        {
            calculator.Add('/');
            ChangeText();
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            calculator.Add('*');
            ChangeText();
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            calculator.Add('-');
            ChangeText();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            calculator.Add('+');
            ChangeText();
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            calculator.Add('b');
            ChangeText();
        }

        private void One_Click(object sender, EventArgs e)
        {
            calculator.Add('1');
            ChangeText();
        }

        private void Two_Click(object sender, EventArgs e)
        {
            calculator.Add('2');
            ChangeText();
        }

        private void Three_Click(object sender, EventArgs e)
        {
            calculator.Add('3');
            ChangeText();
        }

        private void Four_Click(object sender, EventArgs e)
        {
            calculator.Add('4');
            ChangeText();
        }

        private void Five_Click(object sender, EventArgs e)
        {
            calculator.Add('5');
            ChangeText();
        }

        private void Six_Click(object sender, EventArgs e)
        {
            calculator.Add('6');
            ChangeText();
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            calculator.Add('7');
            ChangeText();
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            calculator.Add('8');
            ChangeText();
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            calculator.Add('9');
            ChangeText();
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            calculator.Add('0');
            ChangeText();
        }

        private void EraseAll_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            ChangeText();
        }

        private void Sign_Click(object sender, EventArgs e)
        {
            calculator.Add('s');
            ChangeText();
        }

        private void Point_Click(object sender, EventArgs e)
        {
            calculator.Add(',');
            ChangeText();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                calculator.Add('=');
                ChangeText();
            }
            catch (DivideByZeroException)
            {
                outputBox.Text = "Divide by zero!";
                calculator.Clear();
            }
        }

        private void Sqrt_Click(object sender, EventArgs e)
        {
            try
            {
                calculator.Add('√');
                ChangeText();
            }
            catch (ArithmeticException)
            {
                outputBox.Text = "Invalid input!";
                calculator.Clear();
            }
        }

    }
}
