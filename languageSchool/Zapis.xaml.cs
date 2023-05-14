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
	/// Логика взаимодействия для Zapis.xaml
	/// </summary>
	public partial class Zapis : Window
	{
		public SchoolEntities db = new SchoolEntities();
		Usluga usluga = new Usluga();
		public Zapis(Usluga usluga = null)
		{
			InitializeComponent();
			this.usluga = usluga;
			usluugaa.Text = usluga.UslugaName;
			timing.Text = usluga.UslugaTime.ToString();
			kli.ItemsSource = db.Client.ToList();
		}

		private void zap_Click(object sender, RoutedEventArgs e)
		{
			UslugaClient uc = new UslugaClient { UslName = usluugaa.Text, Client = kli.Text, TimeStart = Convert.ToDateTime(timer.Text) };
			db.UslugaClient.Add(uc);
			db.SaveChanges();
			MessageBox.Show("Записано");
		}

		private void back_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
			mw.adminka.IsSelected = true;
		}
	}
}
