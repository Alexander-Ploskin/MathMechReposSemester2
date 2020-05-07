using System;
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

        private void OnButton(object sender, EventArgs e)
        {
            switch ((sender as Button).Text)
            {
                case "√‎":
                    {
                        calculator.Add('r');
                        break;
                    }
                case "C":
                    {
                        calculator.Add('c');
                        break;
                    }
                case "⌫":
                    {
                        calculator.Add('b');
                        break;
                    }
                case "+/-":
                    {
                        calculator.Add('s');
                        break;
                    }
                default:
                    {
                        calculator.Add((sender as Button).Text.ToCharArray()[0]);
                        break;
                    }
            }

            UpdateText();
        }

    }
}
