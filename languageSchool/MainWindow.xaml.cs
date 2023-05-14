using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace languageSchool
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Usluga usluga = new Usluga();
		public SchoolEntities db = new SchoolEntities();
		public MainWindow()
		{
			InitializeComponent();
			uslugi.ItemsSource = db.Usluga.ToList();
			uslugi1.ItemsSource = db.Usluga.ToList();
			all.Text = db.Usluga.Count().ToString();
			kolVo.Text = db.Usluga.Count().ToString();

		}
		public void Selected()
		{
			if (skidka.Text != "0")
			{
				string a = skidka.Text.ToString();
				string b = cost.Text.ToString();
				double c = Convert.ToDouble(a);
				int d = Convert.ToInt32(b);
				star.Content = d / (1.0 - c);
			}
			
		}
		private void admin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			admin adm = new admin();
			adm.Show();
			this.Close();
		}

		private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
		{ 
			uslugi.ItemsSource = db.Usluga.OrderBy(x => x.UslugiCost).ToList();
			kolVo.Text = db.Usluga.OrderBy(x => x.UslugiCost).Count().ToString();
		}

		private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
		{
			uslugi.ItemsSource = db.Usluga.OrderByDescending(x => x.UslugiCost).ToList();
			kolVo.Text = db.Usluga.OrderByDescending(x => x.UslugiCost).Count().ToString();
		}

		private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
		{
			uslugi.ItemsSource = db.Usluga.ToList();
			kolVo.Text = db.Usluga.Count().ToString();
		}

		private void ComboBoxItem_Selected_4(object sender, RoutedEventArgs e)
		{
			uslugi.ItemsSource = db.Usluga.Where(x => x.UslugiSkid >= 0 && x.UslugiSkid < 0.05 ).ToList();
			kolVo.Text = db.Usluga.Where(x => x.UslugiSkid >= 0 && x.UslugiSkid < 0.05).Count().ToString();
		}

		private void ComboBoxItem_Selected_5(object sender, RoutedEventArgs e)
		{
			uslugi.ItemsSource = db.Usluga.Where(x => x.UslugiSkid >= 0.05 && x.UslugiSkid < 0.15).ToList();
			kolVo.Text = db.Usluga.Where(x => x.UslugiSkid >= 0.05 && x.UslugiSkid < 0.15).Count().ToString();
		}

		private void ComboBoxItem_Selected_6(object sender, RoutedEventArgs e)
		{
			uslugi.ItemsSource = db.Usluga.Where(x => x.UslugiSkid >= 0.15 && x.UslugiSkid < 0.30).ToList();
			kolVo.Text = db.Usluga.Where(x => x.UslugiSkid >= 0.15 && x.UslugiSkid < 0.30).Count().ToString();
		}

		private void ComboBoxItem_Selected_7(object sender, RoutedEventArgs e)
		{
			uslugi.ItemsSource = db.Usluga.Where(x => x.UslugiSkid >= 0.30 && x.UslugiSkid < 0.70).ToList();
			kolVo.Text = db.Usluga.Where(x => x.UslugiSkid >= 0.30 && x.UslugiSkid < 0.70).Count().ToString();
		}

		private void ComboBoxItem_Selected_8(object sender, RoutedEventArgs e)
		{
			uslugi.ItemsSource = db.Usluga.Where(x => x.UslugiSkid >= 0.70 && x.UslugiSkid < 1).ToList();
			kolVo.Text = db.Usluga.Where(x => x.UslugiSkid >= 0.70 && x.UslugiSkid < 1).ToString();
		}

		private void ComboBoxItem_Selected_9(object sender, RoutedEventArgs e)
		{
			uslugi.ItemsSource = db.Usluga.ToList();
			kolVo.Text = db.Usluga.Count().ToString();
		}

		private void poisk_TextChanged(object sender, TextChangedEventArgs e)
		{
			using (SchoolEntities db = new SchoolEntities())
			{
				uslugi.ItemsSource = db.Usluga.ToList().Where(c => c.UslugaName.Contains(poisk.Text));
				if (poisk.Text == "все")
				{
					uslugi.ItemsSource = db.Usluga.ToList();
				}
			}
		}

		private void uslugi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var ret = (Usluga)uslugi.SelectedItem;
			admin adm = new admin(ret);
			adm.Show();
			name1.Text = ret.UslugaName.ToString();
			cost1.Text = ret.UslugiCost.ToString();
			time1.Text = ret.UslugaTime.ToString();
			skidka1.Text = ret.UslugiSkid.ToString();
			this.Close();
			
		}

		private void delete_Click(object sender, RoutedEventArgs e)
		{
			var ret = (Usluga)uslugi.SelectedItem;
			string usl = (from ut in db.UslugaClient where ut.UslName == ret.UslugaName select ut.UslName).FirstOrDefault();
			if (ret.UslugaName == usl)
			{
				MessageBox.Show("Для этой услуги есть запись невозможно удалить");
			}
			else
			{
				db.Usluga.Remove(ret);
				db.SaveChanges();
				MessageBox.Show("Удалено");
			}
		}

		private void save_Click(object sender, RoutedEventArgs e)
		{
			using (SchoolEntities db = new SchoolEntities())
			{
				if (Convert.ToInt32(time1.Text) < 14400)
				{
					Usluga us = usluga;
					us.UslugaName = name1.Text;
					us.UslugaPhoto = null;
					us.UslugaTime = Convert.ToInt32(time1.Text);
					us.UslugiCost = Convert.ToDecimal(cost1.Text);
					us.UslugiSkid = Convert.ToDouble(skidka1.Text);
					db.Usluga.AddOrUpdate(us);
					db.SaveChanges();
				}
				else { MessageBox.Show("Продолжительность не может превышать 4 часов(14400 сек)"); }
			}
			MessageBox.Show("Сохранено");
		}

		private void newUsl_Click(object sender, RoutedEventArgs e)
		{
			Type a = cost1.Text.GetType();
			
				if (db.Usluga.Any(x => x.UslugaName != name1.Text))
				{
					if (Convert.ToInt32(time1.Text) < 14400)
					{
						Usluga usl = new Usluga { UslugaName = name1.Text, UslugaPhoto = null, UslugaTime = Convert.ToInt32(time1.Text), UslugiCost = Convert.ToDecimal(cost1.Text), UslugiSkid = Convert.ToDouble(skidka1.Text) };
						db.Usluga.Add(usl);
						db.SaveChanges();
						MessageBox.Show("Услуга добавлена");
						uslugi1.ItemsSource = db.Usluga.ToList();
					}
					else { MessageBox.Show("Продолжительность не может превышать 4 часов(14400 сек)"); }
				}
				else { MessageBox.Show("Такая услуга уже существует"); }
			}

		

		private void new_Click(object sender, RoutedEventArgs e)
		{
			admin adm = new admin();
			adm.Show();
			this.Close();
		}

		private void poisk1_TextChanged(object sender, TextChangedEventArgs e)
		{
			using (SchoolEntities db = new SchoolEntities())
			{
				uslugi1.ItemsSource = db.Usluga.ToList().Where(c => c.UslugaName.Contains(poisk1.Text));
				if (poisk1.Text == "все")
				{
					uslugi1.ItemsSource = db.Usluga.ToList();
				}
			}
		}

		private void delete1_Click(object sender, RoutedEventArgs e)
		{
			var delete = (Usluga)uslugi1.SelectedItem;
			db.Usluga.Remove(delete);
			db.SaveChanges();
			uslugi1.ItemsSource = db.Usluga.ToList() ;
			MessageBox.Show("Удалено");
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			var ret = (Usluga)uslugi1.SelectedItem;
			Zapis zap = new Zapis(ret);	
			zap.Show();
			this.Close();
		}

		private void show_Click(object sender, RoutedEventArgs e)
		{
			ShowZapis sz = new ShowZapis();
			sz.Show();
			this.Close();

		}
	}
}
