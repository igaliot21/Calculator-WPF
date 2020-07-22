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
        double lastNumber;
        SelectedOperator SelOper;
        public MainWindow()
        {
            InitializeComponent();

            btnCE.Click += BtnCE_Click;
            btnNegative.Click += BtnNegative_Click;
            btnPercent.Click += BtnPercent_Click;
            btnEqual.Click += BtnEqual_Click;
            SelOper = SelectedOperator.None;
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            double currentNumber, result;
            
            if (double.TryParse(lblResult.Content.ToString().Replace(",","."), out currentNumber))
            {
                switch (SelOper) {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, currentNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substract(lastNumber, currentNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, currentNumber);
                        break;
                    case SelectedOperator.Divition:
                        result = SimpleMath.Divide(lastNumber, currentNumber);
                        break;
                    case SelectedOperator.None:
                        result = 0;
                        break;
                    default:
                        result = 0;
                        break;
                }
                lblResult.Content = result.ToString().Replace(",", ".");
            }
        }

        private void BtnPercent_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(lblResult.Content.ToString().Replace(",", "."), out tempNumber))
            {
                tempNumber = (lastNumber / 100);
                if (lastNumber != 0) tempNumber *= lastNumber;
                lblResult.Content = tempNumber.ToString().Replace(",", ".");
            }
        }

        private void BtnNegative_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(lblResult.Content.ToString().Replace(",", "."), out lastNumber)){
                lastNumber = lastNumber * -1;
                lblResult.Content = lastNumber.ToString().Replace(",", ".");
            }
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = 0.ToString();
            SelOper = SelectedOperator.None;
            lastNumber = 0;   
        }
        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString().Replace(",", "."), out lastNumber)){
                lblResult.Content = 0.ToString();
            }

            if (sender == btnDiv) SelOper = SelectedOperator.Divition;
            else if (sender == btnMult) SelOper = SelectedOperator.Multiplication;
            else if (sender == btnSub) SelOper = SelectedOperator.Substraction;
            else if (sender == btnSum) SelOper = SelectedOperator.Addition;
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;
            if (sender == btn1) selectedValue = 1;
            if (sender == btn2) selectedValue = 2;
            if (sender == btn3) selectedValue = 3;
            if (sender == btn4) selectedValue = 4;
            if (sender == btn5) selectedValue = 5;
            if (sender == btn6) selectedValue = 6;
            if (sender == btn7) selectedValue = 7;
            if (sender == btn8) selectedValue = 8;
            if (sender == btn9) selectedValue = 9;
            if (sender == btn0) selectedValue = 0;

            if (lblResult.Content.ToString() == "0") {
                if (selectedValue != 0) lblResult.Content = selectedValue.ToString();
            }
            else lblResult.Content += selectedValue.ToString().Replace(",", ".");
        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            if(!lblResult.Content.ToString().Replace(",", ".").Contains(".")) lblResult.Content = $"{lblResult.Content}.";
        }
    }
    public enum SelectedOperator
    {
        None,
        Addition,
        Substraction,
        Multiplication,
        Divition
    }
    public class SimpleMath {
        public static double Add(double n1, double n2) {
            return n1 + n2;
        }
        public static double Substract(double n1, double n2){
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2){
            return n1 * n2;
        }
        public static double Divide(double n1, double n2) {
            if (n2 == 0) {
                MessageBox.Show("Division by Zero it's not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            else return n1 / n2;
        }    
    }
} 