namespace WorldQuakeViewer2
{
    /// <summary>
    /// 色々
    /// </summary>
    internal partial class Utilities//todo:https://seismicportal.eu/eventid/ 1地震の情報比較ツール
    {
        /*例
         * catalog|url|misfit|eventid
         * UNID|https://www.seismicportal.eu/fdsnws/event/1/query?eventid=20250502_0000169&format=text|0.05557813906470339|20250502_0000169
         * EMSC|https://www.seismicportal.eu/fdsnws/event/1/query?catalog=EMSC-RTS&source_id=1803133&format=text|0.05557813906470339|1803133
         * INGV|http://webservices.ingv.it/fdsnws/event/1/query?format=text&eventId=42601572|0.3034135397007105|42601572
         * USGS|https://earthquake.usgs.gov/fdsnws/event/1/query?eventid=us7000pwkn&format=csv|0.0|us7000pwkn
         * GFZ|https://geofon.gfz-potsdam.de/fdsnws/event/1/query?format=text&eventId=gfz2025iobo|0.060557791803133934|gfz2025iobo
         * ISC|http://www.isc.ac.uk/fdsnws/event/1/query?eventid=643235302|0.08555779180313414|643235302
         */

        /// <summary>
        /// データ元の個数(null等除く)
        /// </summary>
        public static readonly int DataAuthorCount = Enum.GetValues<DataAuthor>().Length - 2;

        /// <summary>
        /// データ元別既定のURL
        /// </summary>
        public static Dictionary<DataAuthor, string> DataDefURL = new()
        {
            { DataAuthor.Other, "" },
            { DataAuthor.USGS, "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_week.geojson" },
            { DataAuthor.EMSC, "https://www.seismicportal.eu/fdsnws/event/1/query?format=text&minmag=4.5&limit=10" },
            { DataAuthor.GFZ, "https://geofon.gfz-potsdam.de/fdsnws/event/1/query?format=text&minmag=4.5&limit=10&end=" + (DateTime.Now.Year + 1) + "-12-31" },
            { DataAuthor.EarlyEst, "http://early-est.rm.ingv.it/monitor.xml" },
        };

        /// <summary>
        /// フォーマット指定の置換用
        /// </summary>
        public class FormatReplaces
        {
            /// <summary>
            /// データ元
            /// </summary>
            public string Author { get; set; } = "";

            /// <summary>
            /// 地震D
            /// </summary>
            public string ID { get; set; } = "";

            /// <summary>
            /// 震源名(日本語)
            /// </summary>
            public string HypoJP { get; set; } = "";

            /// <summary>
            /// 震源名(英語)
            /// </summary>
            public string HypoEN { get; set; } = "";

            /// <summary>
            /// 震源名(ユーザー設定(LL2FERC.csv))
            /// </summary>
            public string HypoUSER { get; set; } = "";

            /// <summary>
            /// 緯度(十進数)
            /// </summary>
            public string Lat10 { get; set; } = "";

            /// <summary>
            /// NまたはS
            /// </summary>
            public string LatNS { get; set; } = "";

            /// <summary>
            /// 北緯または南緯
            /// </summary>
            public string LatNSJP { get; set; } = "";

            /// <summary>
            /// 緯度(六十進数・度)
            /// </summary>
            public string Lat60d { get; set; } = "";

            /// <summary>
            /// 緯度(六十進数・分)
            /// </summary>
            public string Lat60m { get; set; } = "";

            /// <summary>
            /// 緯度(六十進数・秒)
            /// </summary>
            public string Lat60s { get; set; } = "";

            /// <summary>
            /// 経度(十進数)
            /// </summary>
            public string Lon10 { get; set; } = "";

            /// <summary>
            /// EまたはW
            /// </summary>
            public string LonEW { get; set; } = "";

            /// <summary>
            /// 東経または西経
            /// </summary>
            public string LonEWJP { get; set; } = "";

            /// <summary>
            /// 経度(六十進数・度)
            /// </summary>
            public string Lon60d { get; set; } = "";

            /// <summary>
            /// 経度(六十進数・分)
            /// </summary>
            public string Lon60m { get; set; } = "";

            /// <summary>
            /// 経度(六十進数・秒)
            /// </summary>
            public string Lon60s { get; set; } = "";

            /// <summary>
            /// 深さ
            /// </summary>
            public string Depth { get; set; } = "";

            /// <summary>
            /// マグニチュードの種類
            /// </summary>
            public string MagType { get; set; } = "";

            /// <summary>
            /// マグニチュード
            /// </summary>
            public string Mag { get; set; } = "";

            /// <summary>
            /// [USGSのみ]改正メルカリ震度階級
            /// </summary>
            public string MMI { get; set; } = "";

            /// <summary>
            /// [USGSのみ]改正メルカリ震度階級(アラビア数字)
            /// </summary>
            public string MMIAra { get; set; } = "";

            /// <summary>
            /// [USGSのみ]アラート(日本語)
            /// </summary>
            public string AlertJP { get; set; } = "";

            /// <summary>
            /// [USGSのみ]アラート(英語)
            /// </summary>
            public string AlertEN { get; set; } = "";

            /// <summary>
            /// [一部]データ元
            /// </summary>
            public string Source { get; set; } = "";

            /// <summary>
            /// 更新時に「更新」
            /// </summary>
            public string UpdateJP { get; set; } = "";

            /// <summary>
            /// 更新時に「update」
            /// </summary>
            public string UpdateEN { get; set; } = "";
        };

        /// <summary>
        /// 履歴保存用クラス
        /// </summary>
        /// <remarks>既定はstring:"null",double:-999,double?:null,DateTimeOffset:MinValue,DataAuthor:Null</remarks>
        public class Data
        {
            /// <summary>
            /// データ元(USGS/EMSC/EarlyEst)
            /// </summary>
            public DataAuthor Author { get; set; } = DataAuthor.Null;

            /// <summary>
            /// 地震ID(データ元間で互換性なし)
            /// </summary>
            public string ID { get; set; } = "null";

            /// <summary>
            /// 地震ID(データ元間で互換性なし)(webに飛べるID)
            /// </summary>
            public string ID2 { get; set; } = "null";

            /// <summary>
            /// 発生時刻
            /// </summary>
            public DateTimeOffset Time { get; set; } = DateTimeOffset.MinValue;

            /// <summary>
            /// 更新時刻
            /// </summary>
            public DateTimeOffset UpdtTime { get; set; } = DateTimeOffset.MinValue;

            /// <summary>
            /// 震源名
            /// </summary>
            /// <remarks>基本的に震源名更新用</remarks>
            public string Hypo { get; set; } = "null";

            /// <summary>
            /// 緯度
            /// </summary>
            public double Lat { get; set; } = -999;

            /// <summary>
            /// 経度
            /// </summary>
            public double Lon { get; set; } = -999;

            /// <summary>
            /// 深さ
            /// </summary>
            public double Depth { get; set; } = -999;

            /// <summary>
            /// マグニチュードの種類
            /// </summary>
            public string MagType { get; set; } = "null";

            /// <summary>
            /// マグニチュード
            /// </summary>
            public double Mag { get; set; } = -999;

            /// <summary>
            /// [USGSのみ]MMI
            /// </summary>
            public double? MMI { get; set; } = null;

            /// <summary>
            /// [USGSのみ]アラート
            /// </summary>
            public string Alert { get; set; } = "null";

            /// <summary>
            /// [一部のみ]データのソース
            /// </summary>
            public string Source { get; set; } = "null";
        }

    }
}