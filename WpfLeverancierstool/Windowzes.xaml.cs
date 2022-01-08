using System;
using System.Collections.Generic;
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
    /// Interaction logic for Windowzes.xaml
    /// </summary>
    public partial class Windowzes : Window
    {
        private string leveranciersNaam;

        public Windowzes(string leveranciersNaam)
        {
            InitializeComponent();
            this.leveranciersNaam = leveranciersNaam;
            Levnaam.Text = leveranciersNaam;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string strProvider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Tjitsche\\Tjitsche\\Leverancierscontractenbestand.xlsx.accdb'";
            using (OleDbConnection con = new OleDbConnection(strProvider))

            {
                    using (OleDbCommand command = con.CreateCommand())
                    {
                    command.CommandText = "Delete FROM Leveranciersgegevens WHERE Leveranciersnaam = '" + leveranciersNaam + "'";
                        //"Leveranciersgegevens ([Leveranciersnaam],[Contactpersoon],[Telefoonnummer]) values ('" + Levnaam.Text + "', '" + Contpnaam.Text + "', '" + Telnaam.Text + "') WHERE Leveranciersnaam = '" + leveranciersNaam + "'";
                        command.Connection = con;
                        con.Open();
                        var reader = command.ExecuteReader();

                    }
            }

            using (OleDbConnection con = new OleDbConnection(strProvider))

            {
                    using (OleDbCommand command = con.CreateCommand())
                    {
                        command.CommandText = "Delete FROM Contracten WHERE Leveranciersnaam ='" + leveranciersNaam + "'";
                        command.Connection = con;
                        con.Open();
                        var reader = command.ExecuteReader();

                    }
            }
                MessageBox.Show("Leverancier is verwijderd");
            }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
    }




