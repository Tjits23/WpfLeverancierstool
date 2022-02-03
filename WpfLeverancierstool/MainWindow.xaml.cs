using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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


namespace WpfLeverancierstool
{
    /// <summary>
    /// Interaction logic for Comboboxbind.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddComboBox("Leveranciersnaam"); 
            

        }

        private void AddComboBox(string Leveranciersnaam)
        {
            string strProvider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Tjitsche\\Tjitsche\\Leverancierscontractenbestand.xlsx.accdb'";
            OleDbConnection con = new OleDbConnection(strProvider);

            OleDbCommand command = new OleDbCommand();
            command.CommandText = $"Select * from Leveranciersgegevens ORDER BY Leveranciersnaam";
            command.Connection = con;

            con.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string leveranciersNaam = (string)reader.GetValue("Leveranciersnaam");
                ComboBox1.Items.Add(leveranciersNaam);

               
                
            }
            reader.Close(); 
            con.Close();

            
        }

       
        



        private void submitButton_Click(object sender, RoutedEventArgs e)
        { 
            string Leveranciersnaam = (string)ComboBox1.SelectedItem;

            Windowtwee windowtwee = new Windowtwee(Leveranciersnaam);
            windowtwee.Visibility = Visibility.Visible;
            
        }

        private void ToevButton_Click(object sender, RoutedEventArgs e)
        {

            string leveranciersnaam = (string)ComboBox1.SelectedItem;

            Windowvier windowvier = new Windowvier();
            windowvier.Visibility = Visibility.Visible;
        }

        private void VerwButton_Click(object sender, RoutedEventArgs e)
        {
            string leveranciersnaam = (string)ComboBox1.SelectedItem.ToString();

            Windowzes windowzes = new Windowzes(leveranciersnaam);
            windowzes.Visibility = Visibility.Visible;
            //windowzes.Show();
        }
    }

    internal class leveranciersnaam
    {
    }
}




