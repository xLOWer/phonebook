using DevExpress.Xpf.Core;
using students.ViewModel;

namespace students.View
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : DXWindow
    {
        public StudentView()
        {
            InitializeComponent();
            DataContext = StudentsViewModel.Create();
        }
    }
}
