using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // 이름 또는 학번이 비어있다면 메세지 경고
            string name = txtName.Text;
            string studentId = txtStudentId.Text;
            string phone = txtPhone.Text;

            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("이름과 학번을 모두 적어주세요", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // 코드 지속 방지
            }

            string dept = ""; // 학과랑 생년월일 널처리
            if(cmbDepartment.SelectedItem is ComboBoxItem selected)
            {
                dept = selected.Content.ToString();
            }

            string birth = dpBirthday.SelectedDate?.ToString("yyyy-MM-dd") ?? "미선택";

            MessageBox.Show(
                "이름" + name + "\n학번" + studentId + "\n연락처" + phone + "\n학과" + dept + "\n생년월일" + birth
                , "등록완료");
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtStudentId.Text = "";
            txtPhone.Text = "";
            cmbDepartment.SelectedIndex = -1;
            dpBirthday.SelectedDate = null;
            txtName.Focus();
        }
    }
}