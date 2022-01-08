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
    /// Interaction logic for Windowvijf.xaml
    /// </summary>
    public partial class Windowvijf : Window
    {

        private string leveranciersNaam;
        

        public Windowvijf(string leveranciersNaam)
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
                    command.CommandText = "UPDATE Leveranciersgegevens Set Contactpersoon='" + Contpnaam.Text + "', Telefoonnummer='" + Telnaam.Text + "'WHERE Leveranciersnaam = '" + leveranciersNaam + "'";
                    command.Connection = con;
                    con.Open();
                    var reader = command.ExecuteReader();
                    
                }          
            }       
            using (OleDbConnection con = new OleDbConnection(strProvider))

            {
                using (OleDbCommand command = con.CreateCommand())
                {
                    command.CommandText = "UPDATE Contracten Set Contractoms='" + Contromsnaam.Text + "', Relatienummer = '" + Relatienum.Text + "'WHERE Leveranciersnaam = '" + leveranciersNaam + "'";
                    command.Connection = con;
                    con.Open();
                    var reader = command.ExecuteReader();


                   
                }         
            }       
            MessageBox.Show("Leverancier is gewijzigd");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }       
}       







        










