namespace WorldQuakeViewer2.Utilities
{
    /// <inheritdoc/>
    public partial class Utilities
    {
        /// <summary>
        /// データ元
        /// </summary>
        public enum DataAuthor
        {
            /// <summary>
            /// 仮用
            /// </summary>
            Null = -1,
            /// <summary>
            /// 過去情報用
            /// </summary>
            Past = -2,
            /// <summary>
            /// 他(ユーザー指定)
            /// </summary>
            Other = 0,
            /// <summary>
            /// USGS
            /// </summary>
            USGS = 1,
            /// <summary>
            /// EMSC
            /// </summary>
            EMSC = 2,
            /// <summary>
            /// GFZ
            /// </summary>
            GFZ = 3,
            /// <summary>
            /// Early-est
            /// </summary>
            EarlyEst = 4
        };

        /// <summary>
        /// 表示データ元判別用
        /// </summary>
        public enum ViewData
        {
            /// <summary>
            /// 仮用
            /// </summary>
            Null = -1,

            /// <summary>
            /// 他(ユーザー指定)の最新とマップ
            /// </summary>
            Other_Latest = 01,

            /// <summary>
            /// 他(ユーザー指定)の履歴
            /// </summary>
            Other_History = 02,

            /// <summary>
            /// 他(ユーザー指定)の最新とマップと履歴
            /// </summary>
            Other_LatestHistory = 03,

            /// <summary>
            /// USGSのの最新とマップ
            /// </summary>
            USGS_Latest = 11,

            /// <summary>
            /// USGSの履歴
            /// </summary>
            USGS_History = 12,

            /// <summary>
            /// USGSの最新とマップと履歴
            /// </summary>
            USGS_LatestHistory = 13,

            /// <summary>
            /// EMSCの最新とマップ
            /// </summary>
            EMSC_Latest = 21,

            /// <summary>
            /// EMSCの履歴
            /// </summary>
            EMSC_History = 22,

            /// <summary>
            /// EMSCの最新とマップと履歴
            /// </summary>
            EMSC_LatestHistory = 23,

            /// <summary>
            /// GFZの最新とマップ
            /// </summary>
            GFZ_Latest = 31,

            /// <summary>
            /// GFZの履歴
            /// </summary>
            GFZ_History = 32,

            /// <summary>
            /// GFZの最新とマップと履歴
            /// </summary>
            GFZ_LatestHistory = 33,

            /// <summary>
            /// Early-estの最新とマップ
            /// </summary>
            EarlyEst_Latest = 41,

            /// <summary>
            /// Early-estの履歴
            /// </summary>
            EarlyEst_History = 42,

            /// <summary>
            /// Early-estの最新とマップと履歴
            /// </summary>
            EarlyEst_LatestHistory = 43,

            /// <summary>
            /// すべての最新とマップ
            /// </summary>
            All_Latest = 91,

            /// <summary>
            /// すべての履歴
            /// </summary>
            All_History = 92,

            /// <summary>
            /// すべての最新とマップと履歴
            /// </summary>
            All_LatestHistory = 93,

            /// <summary>
            /// すべての最新1つずつ
            /// </summary>
            All_LatestMulti = 94
        };

        /// <summary>
        /// ログの種類
        /// </summary>
        /// <remarks>地震ログはDataAuthor+10となるように</remarks>
        public enum LogKind
        {
            /// <summary>
            /// 実行ログ
            /// </summary>
            Exe = 1,

            /// <summary>
            /// エラーログ
            /// </summary>
            Error = 2,

            /// <summary>
            /// 地震ログ(他(ユーザー指定))
            /// </summary>
            Other = 10,

            /// <summary>
            /// 地震ログ(USGS)
            /// </summary>
            USGS = 11,

            /// <summary>
            /// 地震ログ(EMSC)
            /// </summary>
            EMSC = 12,

            /// <summary>
            /// 地震ログ(GFZ)
            /// </summary>
            GFZ = 13,

            /// <summary>
            /// 地震ログ(Early-est)
            /// </summary>
            EarlyEst = 14
        }

        /// <summary>
        /// フォーマット置換処理名
        /// </summary>
        public enum FormatProName
        {
            /// <summary>
            /// データ表示
            /// </summary>
            View = 0,

            /// <summary>
            /// 棒読みちゃん送信
            /// </summary>
            BouyomiChan = 2,

            /// <summary>
            /// Socket送信
            /// </summary>
            Socket = 3,

            /// <summary>
            /// Webhook送信
            /// </summary>
            Webhook = 4,

            /// <summary>
            /// 地震ログ保存
            /// </summary>
            LogE = 5
        }

        /// <summary>
        /// データの種類
        /// </summary>
        public enum DataProType
        {
            /// <summary>
            /// 自動判別
            /// </summary>
            Auto = 0,

            /// <summary>
            /// テキスト形式
            /// </summary>
            Text = 1,

            /// <summary>
            /// QuakeML形式
            /// </summary>
            QuakeML = 2,

            /// <summary>
            /// GeoJSON形式(自動判別)
            /// </summary>
            GeoJSON = 3,

            /// <summary>
            /// GeoJSON形式(USGS)
            /// </summary>
            GeoJSON_USGS = 31,

            /// <summary>
            /// GeoJSON形式(USGS)
            /// </summary>
            GeoJSON_EMSC = 32,
        }

        /// <summary>
        /// ID元(seismicportalのEventID用)
        /// </summary>
        public enum AuthorID
        {
            /// <summary>
            /// UNID
            /// </summary>
            UNID = 0,

            /// <summary>
            /// EMSC
            /// </summary>
            EMSC = 1,

            /// <summary>
            /// INGV
            /// </summary>
            INGV = 2,

            /// <summary>
            /// USGS
            /// </summary>
            USGS = 3,

            /// <summary>
            /// ISC
            /// </summary>
            ISC = 4
        }

        /// <summary>
        /// 設定結合ツールのSelect1がDataのときの選択肢
        /// </summary>
        public enum ConfigMerge_Select3_Data
        {
            /// <summary>
            /// 更新検知対象
            /// </summary>
            Update = 0,

            /// <summary>
            /// 音声再生
            /// </summary>
            Sound = 1,

            /// <summary>
            /// 棒読みちゃん送信
            /// </summary>
            Bouyomi = 2,

            /// <summary>
            /// socket送信
            /// </summary>
            Socket = 3,

            /// <summary>
            /// webhook送信
            /// </summary>
            Webhook = 4,

            /// <summary>
            /// ログ出力関連(地震)
            /// </summary>
            LogE = 5
        }

        /// <summary>
        /// 設定結合ツールのSelect1がViewのときの選択肢
        /// </summary>
        public enum ConfigMerge_Select3_View
        {
            /// <summary>
            /// すべて
            /// </summary>
            All = 0,
            /// <summary>
            /// 描画色
            /// </summary>
            Color = 1
        }

        /// <summary>
        /// 設定結合ツールのSelect1がOtherのときの選択肢
        /// </summary>
        public enum ConfigMerge_Select3_Other
        {
            /// <summary>
            /// すべて
            /// </summary>
            All = 0,
            /// <summary>
            /// ログ出力関連(地震除く)
            /// </summary>
            LogN = 1
        }
    }
}
