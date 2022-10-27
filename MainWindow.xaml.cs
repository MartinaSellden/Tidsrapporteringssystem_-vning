using System;
using System.Collections.Generic;
using System.IO;
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

namespace Tidsrapporteringssystem_övning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> hoursWorked = new List<string>();
        List<string> allHoursWorked = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        public void DisplayContent()
        {
            myListbox.ItemsSource=null;
            myListbox.ItemsSource=hoursWorked;
        }
        public void DisplayContentForManagers()
        {
            myListbox2.ItemsSource=null;
            myListbox2.ItemsSource=allHoursWorked;
        }

        public void Clear()
        {
            myTextBox.Text = null;
            myDatePicker.SelectedDate = null;
            timeCombo.Text =null;
           
        }
        public void AddReport()
        {
            string tasks = myTextBox.Text;
            string date = myDatePicker.Text;
            string time = timeCombo.Text;
            string name = nameTextbox.Text;

            string output = name +" "+ date +" "+ time +" "+ tasks;

            hoursWorked.Add(output);
           
        }

        public void WriteToFile()
        {
            using (TextWriter tw = new StreamWriter("Tidsrapporting.txt",true))
            {
                foreach(var report in allHoursWorked)
                {
                    tw.WriteLine(report);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddReport();
            DisplayContent();
            Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            allHoursWorked.AddRange(hoursWorked);
            hoursWorked.Clear();
            DisplayContent();
            DisplayContentForManagers();
            nameTextbox.Text=null;
            WriteToFile();

        }
    }
}
