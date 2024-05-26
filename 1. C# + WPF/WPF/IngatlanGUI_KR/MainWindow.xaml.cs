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

using MySql.Data;
using MySql.Data.MySqlClient;
using RealEstates;

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connStr = "server=localhost;user=root;database=ingatlan;port=3306";

        public MainWindow()
        {
            InitializeComponent();

            List<Seller> sellers = new List<Seller>();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT s.id, s.name, s.phone FROM sellers AS s";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                
                while (rdr.Read())
                {
                    sellers.Add(new Seller() { Id = Convert.ToInt32(rdr["Id"].ToString()), Name = rdr["Name"].ToString(), Phone = rdr["Phone"].ToString() });
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

            this.Eladók.ItemsSource = sellers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT COUNT(id) AS AdCount FROM realestates WHERE sellerid = @sellerid";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@sellerid", (this.Eladók.SelectedItem as Seller).Id));
                MySqlDataReader rdr = cmd.ExecuteReader();


                rdr.Read();
                this.AdCount.Content = rdr["AdCount"].ToString();
                rdr.Close();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        }
    }
}
