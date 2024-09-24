using ServisVaga.DAO;
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
using System.Windows.Shapes;

namespace ServisVaga
{
    /// <summary>
    /// Interaction logic for InsertUpdateMeriloWindow.xaml
    /// </summary>
    public partial class InsertUpdateMeriloWindow : Window
    {
        public List<Klijent> Klijenti { get; set; } = new();

        public InsertUpdateMeriloWindow()
        {
            InitializeComponent();
            Klijenti = KlijentDAO.UcitajKlijente();
            klijentiComboBox.ItemsSource = Klijenti;
        }
    }
}
