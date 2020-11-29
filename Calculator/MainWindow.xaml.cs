using System;
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
        SelectedOperator selectedOperator;

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

            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber)) {

                switch (selectedOperator) {

                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Sub(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                   default:
                        break;

                }

                resultLabel.Content = result.ToString();
            
            }



        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {

            double tmpNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out tmpNumber)) {

                tmpNumber /= 100;
                if (lastNumber != 0)
                    tmpNumber *= lastNumber;
                resultLabel.Content = tmpNumber.ToString();
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
            result = 0;
            lastNumber = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {

            
            
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
            

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divideButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == addButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subtractButton)
                selectedOperator = SelectedOperator.Substraction;



        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if(!resultLabel.Content.ToString().Contains("."))
                resultLabel.Content = $"{resultLabel.Content}.";
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


    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double op1, double op2)
        {
            return op1 + op2;
        }

        public static double Sub(double op1, double op2)
        {
            return op1 - op2;
        }

        public static double Multiply(double op1, double op2)
        {
            return op1 * op2;
        }

        public static double Divide(double op1, double op2)
        {
            if (op2 != 0)
                return op1 / op2;
            else
            {
                MessageBox.Show("Divisiono by 0 is not allowed", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0; 
            }
        }
    }


}
