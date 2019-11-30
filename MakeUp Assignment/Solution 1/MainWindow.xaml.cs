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

namespace Solution_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> StudentNames = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFindFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "JSON files (*.json) | *.json";
            var result = dlg.ShowDialog();
            txtStudentList.Text = dlg.FileName;
            if (File.Exists(txtStudentList.Text) == true)
            {

                var lines = File.ReadAllLines(txtStudentList.Text);

                for (int i = 0; i < lines.Length; i++)
                {
                    //int number;
                    var line = lines[i];
                    var column = line.Split(',');
                    string name = column[0];
                    StudentNames.Add(name);
                }
            }
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            var random1 = new Random();
            var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
            int numgroups = int.Parse(txtGroups.Text);
            int group_num = 1;
            for (int i = 0; i < StudentNames.Count; i++)
            {
                lstGroups.Items.Add("Group" + group_num + ": " + result1[i]);
                group_num = ++group_num % numgroups;
            }
        }
    }
}
