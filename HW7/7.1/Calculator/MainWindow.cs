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
            InitializeComponent();
        }

        private void UpdateText()
        {
            OutputBox.Text = calculator.Expression;
        }

        private void EraseAll_Click(object sender, EventArgs e)
        {
            calculator.Add('c');
            UpdateText();
        }

        private void Sqrt_Click(object sender, EventArgs e)
        {
            calculator.Add('r');
            UpdateText();
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            calculator.Add('b');
            UpdateText();
        }

        private void Divivide_Click(object sender, EventArgs e)
        {
            calculator.Add('/');
            UpdateText();
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            calculator.Add('7');
            UpdateText();
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            calculator.Add('8');
            UpdateText();
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            calculator.Add('9');
            UpdateText();
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            calculator.Add('*');
            UpdateText();
        }

        private void Four_Click(object sender, EventArgs e)
        {
            calculator.Add('4');
            UpdateText();
        }

        private void Five_Click(object sender, EventArgs e)
        {
            calculator.Add('5');
            UpdateText();
        }

        private void Six_Click(object sender, EventArgs e)
        {
            calculator.Add('6');
            UpdateText();
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            calculator.Add('-');
            UpdateText();
        }

        private void One_Click(object sender, EventArgs e)
        {
            calculator.Add('1');
            UpdateText();
        }

        private void Two_Click(object sender, EventArgs e)
        {
            calculator.Add('2');
            UpdateText();
        }

        private void Three_Click(object sender, EventArgs e)
        {
            calculator.Add('3');
            UpdateText();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            calculator.Add('+');
            UpdateText();
        }

        private void Sign_Click(object sender, EventArgs e)
        {
            calculator.Add('s');
            UpdateText();
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            calculator.Add('0');
            UpdateText();
        }

        private void Point_Click(object sender, EventArgs e)
        {
            calculator.Add('.');
            UpdateText();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            calculator.Add('=');
            UpdateText();
        }

    }
}
