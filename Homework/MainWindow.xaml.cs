using System.Windows;
using System.Xml;

namespace Homework
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// 
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// xDoc - предназначена для загрузки xml файла
		/// </summary>
		XmlDocument xDoc = new XmlDocument();

		/// <summary>
		/// метод MainWindow предназначен для инициализации компонентов прни запуске программы.
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Метод: Window_Loaded(object sender, RoutedEventArgs e)
		/// Цель: Загрузка и вывод xml файла
		/// 
		///	Результат:
		///		Вывод данных из файла xml.
		///	Вызываемые классы: XmlElment, XmlNodeList, XmlNode
		///	Описание алгоритма:
		///		Загружается xml файл, потом происходит его обработка и построчный вывод в tb
		///	Дата: 20.01.2023 Версия 1.0.0.1
		///	Автор: Гритчин И.В.
		///	Исправления:нет
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			xDoc.Load("DB.xml");
			XmlElement? xRoot = xDoc.DocumentElement;

			XmlNodeList? nodes = xRoot?.SelectNodes("*");
			if (nodes is not null)
			{
				foreach (XmlNode node in nodes)
				{
					tbXml.Text = tbXml.Text + node.OuterXml + '\n';
				}
					
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		public void XmlFilter(string filter)
		{
			if (cmbFilter.SelectedIndex == 0)
			{
				XmlElement? xRoot = xDoc.DocumentElement;
				XmlNodeList? personNodes = xRoot?.SelectNodes(filter);
				if (personNodes is not null)
				{
					foreach (XmlNode node in personNodes)
					{
						tbXml.Text = tbXml.Text + node.SelectSingleNode("@name")?.Value + '\n';
					}

				}
			}
			else if(cmbFilter.SelectedIndex == 3)
			{
				XmlElement? xRoot = xDoc.DocumentElement;
				XmlNode? Nodes = xRoot?.SelectSingleNode("//user[@name='Bill Gates']/age");
				if (Nodes is not null)
				{
						tbXml.Text = tbXml.Text + Nodes.InnerText + "\n";
				}
				XmlNode? NodesComp = xRoot?.SelectSingleNode("//user[@name='Bill Gates']/company");
				if (NodesComp is not null)
				{
						tbXml.Text = tbXml.Text + NodesComp.InnerText + "\n";
				}
				XmlNode? NodesDoB = xRoot?.SelectSingleNode("//user[@name='Bill Gates']/dateofbirth");
				if (NodesDoB is not null)
				{
					tbXml.Text = tbXml.Text + NodesDoB.InnerText + "\n";
				}
			}
			else if (cmbFilter.SelectedIndex == 4)
			{
				XmlElement? xRoot = xDoc.DocumentElement;
				XmlNode? Nodes = xRoot?.SelectSingleNode("//user[@name='Larry Page']/age");
				if (Nodes is not null)
				{
					tbXml.Text = tbXml.Text + Nodes.InnerText + "\n";
				}
				XmlNode? NodesComp = xRoot?.SelectSingleNode("//user[@name='Larry Page']/company");
				if (NodesComp is not null)
				{
					tbXml.Text = tbXml.Text + NodesComp.InnerText + "\n";
				}
				XmlNode? NodesDoB = xRoot?.SelectSingleNode("//user[@name='Larry Page']/dateofbirth");
				if (NodesDoB is not null)
				{
					tbXml.Text = tbXml.Text + NodesDoB.InnerText + "\n";
				}
			}
			else if (cmbFilter.SelectedIndex == 5)
			{
				XmlElement? xRoot = xDoc.DocumentElement;
				XmlNode? Nodes = xRoot?.SelectSingleNode("//user[@name='Tim Cook']/age");
				if (Nodes is not null)
				{
					tbXml.Text = tbXml.Text + Nodes.InnerText + "\n";
				}
				XmlNode? NodesComp = xRoot?.SelectSingleNode("//user[@name='Tim Cook']/company");
				if (NodesComp is not null)
				{
					tbXml.Text = tbXml.Text + NodesComp.InnerText + "\n";
				}//dateofbirth
				XmlNode? NodesDob = xRoot?.SelectSingleNode("//user[@name='Tim Cook']/dateofbirth");
				if (NodesDob is not null)
				{
					tbXml.Text = tbXml.Text + NodesDob.InnerText + "\n";
				}
			}
			else if (cmbFilter.SelectedIndex == 6)
			{
				XmlElement? xRoot = xDoc.DocumentElement;
				XmlNode? Nodes = xRoot?.SelectSingleNode("//user[@name='Lee Jae Young']/age");
				if (Nodes is not null)
				{
					tbXml.Text = tbXml.Text + Nodes.InnerText + "\n";
				}
				XmlNode? NodesComp = xRoot?.SelectSingleNode("//user[@name='Lee Jae Young']/company");
				if (NodesComp is not null)
				{
					tbXml.Text = tbXml.Text + NodesComp.InnerText + "\n";
				}//dateofbirth
				XmlNode? NodesDob = xRoot?.SelectSingleNode("//user[@name='Lee Jae Young']/dateofbirth");
				if (NodesDob is not null)
				{
					tbXml.Text = tbXml.Text + NodesDob.InnerText + "\n";
				}
			}
			else
			{
				XmlElement? xRoot = xDoc.DocumentElement;

				XmlNodeList? companyNodes = xRoot?.SelectNodes(filter);
				if (companyNodes is not null)
				{
					foreach (XmlNode node in companyNodes)
					{
						tbXml.Text = tbXml.Text + node.InnerText + "\n";
					}

				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConclusion_Click(object sender, RoutedEventArgs e)
		{
			tbXml.Text = "";
			switch (cmbFilter.SelectedIndex)
			{
				case 0:
					XmlFilter("user");
					break;
				case 1:
					XmlFilter("//user/age");
					break;
				case 2:
					XmlFilter("//user/company");
					break;
				case 3:
					XmlFilter("//user/company");
					break;
				case 4:
					XmlFilter("//user/company");
					break;
				case 5:
					XmlFilter("//user/company");
					break;
				case 6:
					XmlFilter("//user/company");
					break;
			}
		}
	}
}
