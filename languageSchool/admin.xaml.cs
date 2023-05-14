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
	/// Логика взаимодействия для admin.xaml
	/// </summary>
	public partial class admin : Window
	{
		Usluga usluga = new Usluga();
		public admin(Usluga usluga = null)
		{
			InitializeComponent();
			this.usluga = usluga;
		}

		private void check_Click(object sender, RoutedEventArgs e)
		{
			if (kod.Text != null)
			{
				if (kod.Text == "0000")
				{
					
					MainWindow mw = new MainWindow();
					mw.Show();
					this.Close();
					MessageBox.Show("Админка активирована");
					if (usluga != null)
					{
						mw.name1.Text = usluga.UslugaName.ToString();
						mw.cost1.Text = usluga.UslugiCost.ToString();
						mw.time1.Text = usluga.UslugaTime.ToString();
						mw.skidka1.Text = usluga.UslugiSkid.ToString();

					}
					mw.adminka.IsSelected = true;
				}
				else
				{ 
					MessageBox.Show("Код неверный");
					MainWindow mw = new MainWindow();
					mw.adminka.IsEnabled = true;
				}
			}
			else { MessageBox.Show("Вы забыли ввести код"); }
        }

		private void back_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}
	}
}
