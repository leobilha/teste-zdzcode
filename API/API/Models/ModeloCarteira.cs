using System.Drawing;

namespace API.Models
{
    public class ModeloCarteira
    {
        public class Rootobject
        {
            public Campos[] Campos { get; set; }
            public Bgimgproperties BgImgProperties { get; set; }
        }

        public class Bgimgproperties
        {
            public string Src { get; set; }
            public float WidthImg { get; set; }
            public float HeightImg { get; set; }
        }

        public class Campos
        {
            public string Text { get; set; }
            public string Type { get; set; }
            public string MaxAndDate { get; set; }
            public bool Required { get; set; }
            public Font Font { get; set; }
            public Imgproperties ImgProperties { get; set; }
            public int Rotation { get; set; }
            public string TextContent { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
        }

        public class Font
        {
            public string FontFamily { get; set; }
            public FontStyle FontBold { get; set; }
            public FontStyle FontItalic { get; set; }
            public Color FontColor { get; set; }
            public float FontSize { get; set; }
        }

        public class Imgproperties
        {
            public float ImgX { get; set; }
            public float ImgY { get; set; }
            public float WidthField { get; set; }
            public float HeightField { get; set; }
        }
    }
}
