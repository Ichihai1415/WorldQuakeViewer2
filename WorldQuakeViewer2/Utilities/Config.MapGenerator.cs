using System.Text.Json;
using System.Text.Json.Serialization;

namespace WorldQuakeViewer2.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class Config_MapGenerator
    {

        public C_LandOcean LandOcean { get; set; } = new C_LandOcean();


        public C_Plate Plate { get; set; } = new C_Plate();

        public C_Other Other { get; set; } = new C_Other();


        /// <summary>
        /// 
        /// </summary>
        public class C_LandOcean
        {
            /// <summary>
            /// 地表の塗りつぶし色
            /// </summary>
            public Color LandFillColor { get; set; } = Color.FromArgb(255, 100, 100, 150);

            /// <summary>
            /// 地表の境界線色
            /// </summary>
            public Color LandLineColor { get; set; } = Color.FromArgb(50, 255, 255, 255);

            /// <summary>
            /// 地表の境界線太さ
            /// </summary>
            public float LandLineWidth { get; set; } = 2f;

            /// <summary>
            /// 国境の境界線色
            /// </summary>
            public Color CountryLineColor { get; set; } = Color.FromArgb(50, 255, 255, 255);

            /// <summary>
            /// 海の塗りつぶし色
            /// </summary>
            public Color OceanFillColor { get; set; } = Color.FromArgb(255, 100, 100, 150);

            /// <summary>
            /// 池等の塗りつぶし色
            /// </summary>
            public Color LakeFillColor { get; set; } = Color.FromArgb(0, 0, 0, 0);

            /// <summary>
            /// 池等の境界線色
            /// </summary>
            public Color LakeLineColor { get; set; } = Color.FromArgb(0, 0, 0, 0);

            /// <summary>
            /// 池等の境界線太さ
            /// </summary>
            public float LakeLineWidth { get; set; } = 1f;


            /// <summary>
            /// NaturalEarth1のラスタ画像を使用するか
            /// </summary>
            public bool UseRaster_NaturalEarth1 { get; set; } = false;

            /// <summary>
            /// NaturalEarth2のラスタ画像を使用するか
            /// </summary>
            public bool UseRaster_NaturalEarth2 { get; set; } = false;

            /// <summary>
            /// GrayEarthのラスタ画像を使用するか
            /// </summary>
            public bool UseRaster_GrayEarth { get; set; } = false;

            /// <summary>
            /// OceanBottomのラスタ画像を使用するか
            /// </summary>
            public bool UseRaster_OceanBottom { get; set; } = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public class C_Plate
        {
            /// <summary>
            /// 収束境界の色
            /// </summary>
            public Color ConvergentLineColor { get; set; } = Color.FromArgb(255, 150, 0, 0);

            /// <summary>
            /// 収束境界の太さ
            /// </summary>
            public float ConvergentWidth { get; set; } = 2f;

            /// <summary>
            /// トランスフォーム断層の色
            /// </summary>
            public Color TransformLineColor { get; set; } = Color.FromArgb(255, 0, 150, 0);

            /// <summary>
            /// トランスフォーム断層の太さ
            /// </summary>
            public float TransformWidth { get; set; } = 2f;

            /// <summary>
            /// 発散境界の色
            /// </summary>
            public Color DivergentLineColor { get; set; } = Color.FromArgb(255, 0, 0, 150);

            /// <summary>
            /// 発散境界の太さ
            /// </summary>
            public float DivergentWidth { get; set; } = 2f;
        }

        /// <summary>
        /// 
        /// </summary>
        public class C_Other
        {
            /// <summary>
            /// 
            /// </summary>
            public Color GraticulesLatLon10Color { get; set; } = Color.FromArgb(100, 255, 255, 255);
            public float GraticulesLatLon10Width { get; set; } = 2f;
            public Color GraticulesLat30Color { get; set; } = Color.FromArgb(100, 255, 255, 255);
            public float GraticulesLat30Width { get; set; } = 2f;


        }
        /*既定
                ocean,255,30,30,60
                land,255,100,100,150
                land-line,50,255,255,255
                plate-convergent,255,150,0,0
                plate-transform,255,0,150,0
                plate-divergent,255,0,0,150
                graticules-normal,100,255,255,255
                graticules-lat,200,255,0,0
                graticules-lon1,200,0,0,255
                graticules-lon2,200,0,0,255
                */

        /// <summary>
        /// 設定を保存します。
        /// </summary>
        public void Save() => Utilities.SaveConfig(this, "map-generator");


        public void Load()
        {
            var config_map_tmp = Utilities.LoadConfig<MapGenerator>("map-generator");

        }
    }


    /// <summary>
    /// ColorをJSONシリアライズ/デシアライズできるようにします。
    /// </summary>
    public class JsonConverter_Color : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var colorString = reader.GetString() ?? throw new ArgumentException("値が正しくありません。");
            var argb = colorString.Replace(" ", "").Split(',');
            if (argb.Length == 3)
                return Color.FromArgb(int.Parse(argb[0]), int.Parse(argb[1]), int.Parse(argb[2]));
            else if (argb.Length == 4)
                return Color.FromArgb(int.Parse(argb[0]), int.Parse(argb[1]), int.Parse(argb[2]), int.Parse(argb[3]));
            else
                throw new ArgumentException("値が正しくありません。");
        }

        public override void Write(Utf8JsonWriter writer, Color color, JsonSerializerOptions options)
        {
            if (color.A == 255)
                writer.WriteStringValue(color.R + ", " + color.G + ", " + color.B);
            else
                writer.WriteStringValue(color.A + ", " + color.R + ", " + color.G + ", " + color.B);
        }
    }

}
