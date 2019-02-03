using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calc2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateStudents : ContentPage
	{
		public UpdateStudents ()
		{
            this.BindingContext = new UpadateStudentsViewModel();
			InitializeComponent ();
		}

        private UpadateStudentsViewModel GVmUpdateStudentsViewModel()
        {
            return (UpadateStudentsViewModel)this.BindingContext;
        }

        private void BtnShowAllStudentsClicked(object sender, EventArgs e)
        {
            object bc = Listview1.ItemsSource;
            GVmUpdateStudentsViewModel().Validate();

        }

        private void Listview1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Listview1.SelectedItem == null)
            {
                return;
            }
            Student selectedstudent = Listview1.SelectedItem as Student;
            if (selectedstudent == null)
            {
                return;
            }
            DisplayAlert("Info", selectedstudent.Name, "Close");
        }
    }
}