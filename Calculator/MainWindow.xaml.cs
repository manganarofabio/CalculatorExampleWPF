﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double lastNumber, result;

        public MainWindow()
        {
            InitializeComponent();

            resultLabel.Content = 0;

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber)) {

                lastNumber /= 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {

                lastNumber *= -1;
                resultLabel.Content = lastNumber.ToString();



            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {

            if(sender == divideButton)
            {
                if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
                {
                    resultLabel.Content = "0";
                }

            }


        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            

            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = $"{selectedValue}";
            else
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";

        }
    }
}