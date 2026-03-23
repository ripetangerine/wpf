using System.Collections.ObjectModel;
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
using System.Linq;

namespace ParkingManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        int fee10Min = 1500;
        int fee1Hour = 4000;
        // 미출차 차량 목록 : 컬렉션 
        ObservableCollection<CarInfo> unsettledCars = new();
        // 입차 차량목록
        ObservableCollection<CarInfo> entryCars = new();
        int carSequence = 0; // 순번 카운터


        public MainWindow()
        {
            InitializeComponent();
            // DataGrid와 컬렉션 연결 (바인딩)
            dgUnsettledCars.ItemsSource = unsettledCars; // 해당 데이터 그리드의 속성을 정함
            dgEntryCars.ItemsSource = entryCars;

            dpDate.SelectedDate = DateTime.Today; // 오늘 날짜 기본값 
        }

        private void btnDailySettle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMonthlySettle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDiscount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFeeSetting_Click(object sender, RoutedEventArgs e)
        {
            var feeWindow = new ParkingFeeWindow(fee10Min, fee1Hour);
            feeWindow.Owner = this;

            if(feeWindow.ShowDialog() == true) // 확인을 눌렀을 때
            {
                fee10Min = feeWindow.Fee10Min;
                fee1Hour = feeWindow.Fee1Hour;

                MessageBox.Show("요금이 설정되었습니다\n"+ 
                    "10분당: " + fee10Min.ToString("NO") + "원\n" + 
                    "1시간당 : " + fee1Hour.ToString("NO") + "원", "설정완료");
            }
        }

        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {
            /*
            1. 차량 번호 가져오기
            2. 빈칸 검사
            3. 중복 검사 - 입차 차량 확인
            4. 순번 증가
            5. 새로운 CarInfo 객체 생성 
            6. 미출차 목록에 추가, DataGrid에 자동반영
            7. 입차 차량 목록에 조회
            8. 입력란 초기화 + 포커스
             */

            string carNumber = txtEntryCarNumber.Text.Trim(); // 차량번호 가져오기

            if (string.IsNullOrEmpty(carNumber)){
                MessageBox.Show("차량 번호를 입력하세요", "알림",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEntryCarNumber.Focus();
                return;
            } // 빈칸 검사

           foreach(var car in unsettledCars)
            {
                if(car.CarNumber == carNumber && car.ExitTime == null)
                {
                    MessageBox.Show("이미 입차된 차량입니다!", "중복입차", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            } // 입차된 차량 검사

            carSequence++;

            CarInfo newCar = new CarInfo
            {
                No = carSequence,
                CarNumber = carNumber,
                EntryTime = DateTime.Now

            };

            // 미출차 목록에 추가 해야함
            unsettledCars.Add(newCar);

            // 입차차량 목록에 추가
            entryCars.Add(newCar);

            // 입력란 초기화 + 포커스
            txtEntryCarNumber.Text = "";
            txtEntryCarNumber.Focus();
        }

        private void txtCarNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}