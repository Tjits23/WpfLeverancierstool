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
    /// Interaction logic for Windowdrie.xaml
    /// </summary>
    public partial class Windowdrie : Window
    {
        public Windowdrie(string leveranciersnaam)
        {
            InitializeComponent();
            AddTextboxtextLevnaam(leveranciersnaam);
        }

        private void AddTextboxtextLevnaam(string leveranciersnaam)
        {
            string strProvider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Tjitsche\\Tjitsche\\Leverancierscontractenbestand.xlsx.accdb'";
            OleDbConnection con = new OleDbConnection(strProvider);

            { OleDbCommand command = new OleDbCommand();
                command.CommandText = "Select Leveranciersnaam, IDnummer, Contractoms, Relatienummer FROM Contracten WHERE Leveranciersnaam = '" + leveranciersnaam + "'";
                command.Connection = con;

                con.Open();
                var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string Leveranciersnaam = (string)reader.GetValue("Leveranciersnaam");
                    Levnaam.Text = Leveranciersnaam;

                    string IDnummer = (string)reader["IDnummer"].ToString();
                    int IdContr = Convert.ToInt32(IDnummer);
                    long Idnummer = Convert.ToInt64(IDnummer);
                    IDnumm.Text = IDnummer;
                    //IdContr = Convert.ToInt32(reader["Id"]);

                    string Contractoms = (string)reader.GetValue("Contractoms");
                    Contractom.Text = Contractoms;

                    string Relatienummer = (string)reader["Relatienummer"].ToString();
                    int Relaties = Convert.ToInt32(Relatienummer);
                    long Relatienr = Convert.ToInt64(Relatienummer);
                    Relatie.Text = Relatienummer;


                }

                reader.Close();
                con.Close();

            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();           


        }


    }
}

