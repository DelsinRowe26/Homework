using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Permissions;
using System.Xml.Linq;

namespace Homework
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		XmlDocument xDoc = new XmlDocument();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			xDoc.Load("personal.xml");
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
			}
		}
	}
}
