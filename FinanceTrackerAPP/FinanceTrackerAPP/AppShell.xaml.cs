using FinanceTrackerAPP.Views;
namespace FinanceTrackerAPP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("RegisterPage", typeof(Register));
            Routing.RegisterRoute("HomePage", typeof(Mainpage));
            Routing.RegisterRoute("Add_EditPage", typeof(Add_Edit));
            Routing.RegisterRoute(nameof(Loghours), typeof(Loghours));
        }
    }
}
