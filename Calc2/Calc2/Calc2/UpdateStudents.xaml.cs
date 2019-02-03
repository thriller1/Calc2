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
            GVmUpdateStudentsViewModel().Validate();

        }
    }
}