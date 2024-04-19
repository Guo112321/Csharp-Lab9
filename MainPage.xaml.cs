using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    public partial class MainPage : ContentPage
    {
        double firstNumber;
        double secondNumber;
        string currentOperation = string.Empty;
        bool isOperatorSelected = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var number = button.Text;

            if (DisplayEntry.Text == "0" || isOperatorSelected)
            {
                DisplayEntry.Text = number;
                isOperatorSelected = false;
            }
            else
            {
                DisplayEntry.Text += number;
            }
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            if (!isOperatorSelected && !string.IsNullOrEmpty(DisplayEntry.Text))
            {
                firstNumber = double.Parse(DisplayEntry.Text);
                DisplayEntry.Text = ""; 
            }

            var button = (Button)sender;
            currentOperation = button.Text;
            isOperatorSelected = true;

            
            DisplayEntry.Text = $"{firstNumber} {currentOperation} ";
        }

        private void OnCalculateResult(object sender, EventArgs e)
        {
            if (!isOperatorSelected)
            {
                secondNumber = double.Parse(DisplayEntry.Text);
                DisplayEntry.Text = CalculateResult().ToString();
                currentOperation = "=";
                isOperatorSelected = false;
            }
        }

        private double CalculateResult()
        {
            double result = firstNumber; 

            switch (currentOperation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                        DisplayEntry.Text = "Cannot divide by zero";
                    break;
                default:
                    DisplayEntry.Text = "Invalid operation";
                    break;
            }

            
            firstNumber = result;
            secondNumber = 0;
            currentOperation = string.Empty;

            return result;
        }

        private void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentOperation = string.Empty;
            isOperatorSelected = false;
            DisplayEntry.Text = "0";
        }
    }
}
