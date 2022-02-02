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
    /// Interaction logic for Windowvier.xaml
    /// </summary>
    public partial class Windowvier : Window
    {
        private string leveranciersnaam;

        public Windowvier()
        {
            InitializeComponent();
            
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string strProvider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Tjitsche\\Tjitsche\\Leverancierscontractenbestand.xlsx.accdb'";
            OleDbConnection con = new OleDbConnection(strProvider);

            OleDbCommand command = new OleDbCommand();
            command.CommandText = "Select COUNT(Leveranciersnaam) FROM Leveranciersgegevens WHERE Leveranciersnaam = '" + TextinvoegLev.Text + "'"; 
            command.Connection = con;
           
            con.Open();
            var count = (int)command.ExecuteScalar();
            if (count>0)
            {
                MessageBox.Show("Leverancier bestaat reeds in de database");return;
            }
            
            con.Close();
            
                        
            command.Connection = con;
            command.CommandText = $"insert into Leveranciersgegevens ([Leveranciersnaam],[Contactpersoon],[Telefoonnummer]) values ('" + TextinvoegLev.Text + "', '" + TextinvoegContp.Text + "', '" + TextinvoegTel.Text + "')";
            OleDbDataReader dr;
            try
            {
                con.Open();
                dr = command.ExecuteReader();
                
               
                while (dr.Read())
                {
                    string toString = (string)dr["Text"];
                    TextinvoegLev.Text = toString;
                    string toString1 = (string)(dr["Text"]);
                    TextinvoegContp.Text = toString;
                    string toString2 = (string)((dr["Text"]));
                    TextinvoegTel.Text = toString;
                }
                

                con.Close();
                
            }
           catch (Exception ex)
           { Console.WriteLine(ex.ToString()); }


            OleDbCommand cmd = new OleDbCommand();
            command.Connection = con;
            command.CommandText = $"insert into Contracten ([IDnummer],[Leveranciersnaam],[Contractoms], [Relatienummer]) values ('" + TextinvoegContractID.Text + "', '" + TextinvoegLev.Text + "', '" + TextinvoegContractoms.Text + "', '" + TextinvoegRelatienr.Text + "')";
            

            try
            {
                con.Open();
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    string toString = (string)dr["Text"];
                    TextinvoegContractID.Text = toString;
                    string toString3 = (string)(dr["Text"]);
                    TextinvoegContractoms.Text = toString;
                    string toString4 = (string)(((dr["Text"])));
                    TextinvoegRelatienr.Text = toString;

                }
                con.Close();
                MessageBox.Show("leverancier is toegevoegd");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }



        }

        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }







        
    }

    

}
