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

using Eszaki_kozephegyseg_kilatoi_GUI.Models;
using Microsoft.EntityFrameworkCore;

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

            this.DataContext = context.Locations.Local.ToObservableCollection();
        }

       
    }
}
