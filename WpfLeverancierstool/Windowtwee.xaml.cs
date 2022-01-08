using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using System.Windows.Shapes;

namespace WpfLeverancierstool
{
    /// <summary>
    /// Interaction logic for Windowtwee.xaml
    /// </summary>
    public partial class Windowtwee : Window
    {
        public Windowtwee(string leveranciersnaam)
        {
            InitializeComponent();
            
            AddTextboxtext1(leveranciersnaam);
            
           
        }

        private void AddTextboxtext1(string leveranciersnaam)
        {
            string strProvider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Tjitsche\\Tjitsche\\Leverancierscontractenbestand.xlsx.accdb'";
            OleDbConnection con = new OleDbConnection(strProvider);

            {
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "Select Leveranciersnaam, Contactpersoon, Telefoonnummer FROM Leveranciersgegevens WHERE Leveranciersnaam = '" + leveranciersnaam + "'";
                command.Connection = con;

                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string Leveranciersnaam = (string)reader.GetValue("Leveranciersnaam");
                    TextLev.Text = Leveranciersnaam;

                    string contactPersoon = (string)reader.GetValue("Contactpersoon");
                    TextContp.Text = contactPersoon;

                    string Telefoonnummer = (string)reader.GetValue("Telefoonnummer");
                    TextTel.Text = Telefoonnummer;
                }
            }

            {
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "Select Contractoms FROM Contracten WHERE Leveranciersnaam = '" + leveranciersnaam + "'";
                command.Connection = con;
                 var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    string Contractoms = (string)reader.GetValue("Contractoms");
                    TextContractoms.Text = Contractoms;
                }

                //string contracten maken

                reader.Close();
            }
                
            con.Close();
        }




        private void Extra_Click(object sender, RoutedEventArgs e)
        {
            string leveranciersnaam = (string)TextLev.Text;

            Windowdrie windowdrie = new Windowdrie(leveranciersnaam);
            windowdrie.Visibility = Visibility.Visible;
        }

        private void Wijz_Click(object sender, RoutedEventArgs e)
        {
            string leveranciersnaam = (string)TextLev.Text;

            Windowvijf windowvijf = new Windowvijf(leveranciersnaam);
            windowvijf.Visibility = Visibility.Visible;
            windowvijf.Show();
            
        }

        private void Verw_Click(object sender, RoutedEventArgs e)
        {
            string leveranciersnaam =(string)TextLev.Text ;

            Windowzes windowzes = new Windowzes(leveranciersnaam);
            windowzes.Visibility = Visibility.Visible;
            windowzes.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        //private void AddTextboxtext2(string Contactpersoon)
        //{
        //    string strProvider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Tjitsche\\Tjitsche\\Leverancierscontractenbestand.xlsx.accdb'";
        //    OleDbConnection con = new OleDbConnection(strProvider);

        //    OleDbCommand command = new OleDbCommand();
        //    command.CommandText = "Select Contactpersoon FROM Leveranciersgegevens WHERE Leveranciersnaam = '" + Contactpersoon + "'";
        //    command.Connection = con;

        //    con.Open();
        //    var reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        string contactpersoon = (string)reader.GetValue("Contactpersoon");
        //        TextContp.Text = Contactpersoon;
        //    }
        //    reader.Close();
        //    con.Close();

        //}

        //private void Contactpersoon_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string contactpersoon = (string)TextContp.Text;
        //}

        //private void AddTextboxtext3(string Telefoonnummer)
        //{
        //    string strProvider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Tjitsche\\Tjitsche\\Leverancierscontractenbestand.xlsx.accdb'";
        //    OleDbConnection con = new OleDbConnection(strProvider);

        //    OleDbCommand command = new OleDbCommand();
        //    command.CommandText = "Select Telefoonnummer FROM Leveranciersgegevens WHERE Leverancier = '" + Telefoonnummer + "'";
        //    command.Connection = con;

        //    con.Open();
        //    var reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        string contactpersoon = (string)reader.GetValue("Telefoonnummer");
        //        TextTel.Text = Telefoonnummer;
        //    }
        //    reader.Close();
        //    con.Close();


        //}

        //private void TextTel_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string Telefoonnummer = (string)TextTel.Text;
        //}
    }
}
