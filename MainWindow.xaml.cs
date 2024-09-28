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
            LoadMeriloData();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertUpdateMeriloWindow insertUpdateMeriloWindow = new InsertUpdateMeriloWindow();
            insertUpdateMeriloWindow.ShowDialog();
            LoadMeriloData();

        }

        private void LoadMeriloData()
        {
            Merila = MeriloDAO.UcitajMerila();
            MerilaDataGrid.ItemsSource = Merila;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid datagrid = ((Button)sender).CommandParameter as DataGrid;
            var selectedRow = datagrid.SelectedItem;
            Merilo meriloForDeletion = selectedRow as Merilo;
            if(MeriloDAO.ObrisiMerilo(meriloForDeletion.Id) == 1)
            {
                MessageBox.Show("Uspešno brisanje merila");
            }
            else
            {
                MessageBox.Show("Došlo je do greške");
            }
            LoadMeriloData();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid datagrid = ((Button)sender).CommandParameter as DataGrid;
            var selectedRow = datagrid.SelectedItem;
            Merilo meriloForEdit = selectedRow as Merilo;
            InsertUpdateMeriloWindow insertUpdateMeriloWindow = new InsertUpdateMeriloWindow(meriloForEdit);
            insertUpdateMeriloWindow.ShowDialog();
        }
    }
}