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

namespace languageSchool
{
	/// <summary>
	/// Логика взаимодействия для ShowZapis.xaml
	/// </summary>
	public partial class ShowZapis : Window
	{
		public SchoolEntities db = new SchoolEntities();
		public ShowZapis()
		{
			InitializeComponent();
			zap.ItemsSource = db.UslugaClient.OrderBy(x => x.TimeStart).ToList();
		}

		private void zap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var vib = (UslugaClient)zap.SelectedItem;
			us.Text = vib.UslName;
			surn.Text = vib.Client;
			time.Text = vib.TimeStart.ToString();
			name.Text = (from ut in db.Client where ut.Surname == vib.Client select ut.Name).FirstOrDefault();
			patr.Text = (from ut in db.Client where ut.Surname == vib.Client select ut.Patronymic).FirstOrDefault();
			email.Text = (from ut in db.Client where ut.Surname == vib.Client select ut.Email).FirstOrDefault();
			phone.Text = (from ut in db.Client where ut.Surname == vib.Client select ut.Phone).FirstOrDefault();
			ost.Text = (vib.TimeStart - DateTime.Now).ToString();
		}

		private void back_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();	
			mw.Show();
			this.Close();
		}
	}
}
