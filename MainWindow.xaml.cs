using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private readonly StringBuilder _logBuilder = new StringBuilder();
        private const int MaxLogLines = 500;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (card.Text == "" || addr.Text == "")
            {
                MessageBox.Show("未填写数据！");
                Application.Current.Shutdown();
            }

            _logBuilder.Clear();
            log.Text = string.Empty;

            await AddLogWithDelay("[INFO] 正在连接至 dev-cdn.djiits.com:56413", 200);
            await AddLogWithDelay("[INFO] 正在连接至 dev-cdn.djiits.com:56413 [==        ]", 700);
            await AddLogWithDelay("[INFO] 正在连接至 dev-cdn.djiits.com:56413 [===       ]", 50);
            await AddLogWithDelay("[INFO] 正在连接至 dev-cdn.djiits.com:56413 [=====     ]", 120);
            await AddLogWithDelay("[INFO] 正在连接至 dev-cdn.djiits.com:56413 [=======   ]", 50);
            await AddLogWithDelay("[INFO] 正在连接至 dev-cdn.djiits.com:56413 [========= ]", 50);
            await AddLogWithDelay("[INFO] 正在连接至 dev-cdn.djiits.com:56413 [==========]", 450);

            await AddLogWithDelay("[INFO] 已获取全部个人信息。您的 DJI MAVIC 5 PRO(bushi) 将会邮寄到您家并爆炸", 50);
        }

        private async Task AddLogWithDelay(string message, int delayMs)
        {
            _logBuilder.AppendLine(message);

            if (_logBuilder.Length > MaxLogLines * 100)
            {
                var lines = _logBuilder.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                _logBuilder.Clear();
                foreach (var line in lines.Skip(lines.Length - MaxLogLines))
                {
                    _logBuilder.AppendLine(line);
                }
            }

            log.Text = _logBuilder.ToString();

            logScrollViewer.ScrollToEnd();

            await Task.Delay(delayMs);
        }
    }
}