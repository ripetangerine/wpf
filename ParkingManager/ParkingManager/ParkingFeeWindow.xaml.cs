using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ParkingManager
{
    /// <summary>
    /// ParkingFeeWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ParkingFeeWindow : Window
    {
        // 결과를 뷰에 돌려보낼 속성
        public int Fee10Min { get; set; }
        public int Fee1Hour { get; set; }

        public ParkingFeeWindow(int currentFee10Min, int currentFee1Hour)
        {
            InitializeComponent();
            // 생성자 : 현재 설정값을 받아서 보여줌
            txtFee10Min.Text = currentFee10Min.ToString();
            txtFee1Hour.Text = currentFee1Hour.ToString();
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            // 
            this.DialogResult = false;

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //  out : 이 변수의 겨리과를 담아줘라
            if(!int.TryParse(txtFee10Min.Text, out int fee10m))
            {
                MessageBox.Show("10분 요금에 숫자를 입력하세요", "입력오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtFee10Min.Focus();
                return;
            }
            if(!int.TryParse(txtFee1Hour!.Text, out int fee1h))
            {
                MessageBox.Show("1시간 요금에 숫자를 입력하세요", "입력오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtFee1Hour.Focus();
                return;
            }

            Fee10Min = fee10m;
            Fee1Hour = fee1h;

            this.DialogResult = true; // 대화 결과 ? 창을 닫으면서 결과를 알려줌 (true/false)
        }
    }
}
