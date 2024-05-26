using Eszaki_kozephegyseg_kilatoi_GUI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eszaki_kozephegyseg_kilatoi_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NcmviewpointsContext context = new NcmviewpointsContext();
        public MainWindow()
        {
            InitializeComponent();

            context.Locations.Load();
            context.Viewpoints.Load();

            lb_hegysegek.ItemsSource = context.Locations.Local.ToObservableCollection();
            dg_kilatok.ItemsSource = context.Viewpoints.Local.ToObservableCollection();
        }

        private void lb_hegysegek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var kilatok = (from v in context.Viewpoints
                           where v.Location == lb_hegysegek.SelectedIndex
                           select new { v.ViewpointName, v.Description, v.Mountain, v.Height, v.Built, v.ImageUrl}
                           ).ToList();
            dg_kilatok.ItemsSource = kilatok;
        }
    }
}