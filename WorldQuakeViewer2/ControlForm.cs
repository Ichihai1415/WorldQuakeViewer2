using System.Drawing.Imaging;
using System.Media;
using System.Text;

namespace WorldQuakeViewer2
{
    public partial class ControlForm : Form
    {
        public ControlForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// バージョン(プロジェクトのバージョン、_versionも変えること)
        /// </summary>
        public const string Version = "1.0.0-α1";

        /// <summary>
        /// ダイアログ等を最前面に表示する用
        /// </summary>
        internal static Form topMost = new() { TopMost = true };

        /// <summary>
        /// 文字描画用フォント
        /// </summary>
        internal static FontFamily font = new("koruri");

        /// <summary>
        /// 震央マーク用色置換
        /// </summary>
        internal static ImageAttributes ia = new();

        /// <summary>
        /// staticでアクセスできるようにしたログ表示テキストボックス
        /// </summary>
        internal static TextBox logTextBox;

        /// <summary>
        /// 設定
        /// </summary>
        internal static Config config = new();

        /// <summary>
        /// データのリスト
        /// </summary>
        internal static Data data = new();

        /// <summary>
        /// 取得用
        /// </summary>
        internal static HttpClient client = new();

        /// <summary>
        /// 音声再生用
        /// </summary>
        internal static SoundPlayer? player = null;

        /// <summary>
        /// 実行ログの高速追加用
        /// </summary>
        internal static StringBuilder exeLogs = new();

        /// <summary>
        /// 更新処理の無効
        /// </summary>
        internal static bool noFirst = false;

        /// <summary>
        /// 表示画面の配列
        /// </summary>
        internal static List<DataView> dataViews = [];

        /// <summary>
        /// 過去情報表示画面
        /// </summary>
        internal static DataView pastDataView = new();

        /// <summary>
        /// ユーザー震央辞書
        /// </summary>
        internal static LL2FERC.LL2FERC.FromFile? hypoUser = null;

        /// <summary>
        /// 読み込み時初期化処理
        /// </summary>
        private async void CtrlForm_Load(object sender, EventArgs e)
        {

        }
    }
}
