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
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SQLWhereConditionGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OnTranslateClicked(object sender, RoutedEventArgs e)
        {
            //Regex Logic to match your number type
            // Current: match digit [0-9] with exactly 14 repititions
            Regex r = new Regex(@"\d{14}");

            string CheckedText = tbxPaste.Text;

            MatchCollection mc = r.Matches(CheckedText);
            Debug.Print($"There are {mc.Count} Matches found");

            //Making a string builder to caputre the result
            StringBuilder sb = new StringBuilder();
            foreach (Match m in mc)
            {
                Debug.Print($"Caputured value: {m.Value}");
                sb.Append('"');
                sb.Append(m.Value);
                sb.Append('"');
                sb.Append(',');
            }

            //Truncate the last ',' character
            int lastindex = sb.Length;
            sb.Remove(lastindex - 1, 1);

            tbxDisplay.Text = sb.ToString();


        }

        private void OnCloseClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
