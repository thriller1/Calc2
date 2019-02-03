using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calc2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
        public Menu()
        {
            InitializeComponent();
        }
         
        private void BtnAllstudentsClicked(object sender, EventArgs e)
        {
            UpdateStudents o = new UpdateStudents();
            Navigation.PushAsync(o);
        }

        private void BtnInsertStudentsClicked(object sender, EventArgs e)
        {
            InsertStudents o = new InsertStudents();
            Navigation.PushAsync(o);
        }
    }
}