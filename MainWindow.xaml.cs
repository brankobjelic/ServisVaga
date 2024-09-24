using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;
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
using ServisVaga.DAO;

namespace ServisVaga
{

    public partial class MainWindow : Window
    {
        public List<Merilo> Merila { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            DAOConnection.CreateDatabaseFile();
            Merila = MeriloDAO.UcitajMerila();
            MerilaDataGrid.ItemsSource = Merila;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertUpdateMeriloWindow insertUpdateMeriloWindow = new InsertUpdateMeriloWindow();
            insertUpdateMeriloWindow.ShowDialog();
        }
    }
}