using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimeSearcher
{
	public partial class ErrorForm : Form
	{
		public ErrorForm(string msgText)
		{
			InitializeComponent();
			
			this.label1.Text = msgText;
		}
	}
}
