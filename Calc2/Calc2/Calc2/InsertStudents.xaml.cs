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
	public partial class InsertStudents : ContentPage
	{
        public InsertStudents()
		{
            this.BindingContext = new InsertStudentViewModel();

            InitializeComponent ();
		}

       private InsertStudentViewModel GVMInsertStudentViewModel()
        {
            return (InsertStudentViewModel)this.BindingContext;
        }
        private void BtnAddStudentsClicked(object sender, EventArgs e)
        {
          string rtnvalue= GVMInsertStudentViewModel().AddStudents();
            DisplayAlert("Info", rtnvalue, "Close");


        }
    }
}