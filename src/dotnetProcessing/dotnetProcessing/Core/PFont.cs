using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace dotnetProcessing.Core
{
    public class PFont
    {
        private static List<string> loadedFonts;
        public class Glyph
        {
            public int Height { get; private set; }
            public PImage Image { get; private set; }

            public int Index { get; private set; }

            public int LeftExtent { get; private set; }

            public int TopExtent { get; private set; }

            public int Value { get; private set; }

            public int Width { get; private set; }

            public int SetWidth { get; private set; }
        }

        public bool IsSmooth { get; private set; }
        public bool IsStream { get; private set; }
        public Font Font { get; private set; }

        public float Ascent { get; private set; }
        public float Descent { get; private set; }

        public int DefaultSize { get; private set; }

        public int GlyphCount { get; private set; }

        public string Name { get; private set; }
        public int Size { get; private set; }

        public string PostScriptName { get; private set; }

        //public object Native { get; private set; }

        public PFont(Font font, bool smooth)
        {
            Font = font;
            IsSmooth = smooth;
            IsStream = false;
            Name = Font.Name;
            Size = (int)Font.Size;
            DefaultSize = 10;
            PostScriptName = Font.Name;
            GlyphCount = 0;
            Ascent = Font.Size * Font.FontFamily.GetCellAscent(FontStyle.Regular) / Font.FontFamily.GetEmHeight(FontStyle.Regular);
            Descent = Font.Size * Font.FontFamily.GetCellDescent(FontStyle.Regular) / Font.FontFamily.GetEmHeight(FontStyle.Regular);
        }

        //GetShape(char ch)
        //GetShape(char ch, float detail)        

        //public Glyph GetGlyph(char c) { }

        //public Glyph GetGlyph(int i) {   }

        //public float GetKern(char a, char b) {}

        //public float GetCharWidth(char c) { }


        #region Static methods

        private static void loadFonts()
        {
            if (loadedFonts == null)
            {
                using (InstalledFontCollection installedFonts = new InstalledFontCollection())
                {
                    foreach (FontFamily fontFamily in installedFonts.Families)
                    {   
                        loadedFonts.Add(fontFamily.Name);
                    }
                }
            }

        }

        internal static PFont GetSystemDeafultFont()
        {
            return new PFont((Font)SystemFonts.DefaultFont.Clone(), true);
        }
        internal static Font FindFont(string fontName, float fontSize)
        {
            loadFonts();

            string enconteredFont = loadedFonts.Find(font => font == fontName);
            if (!string.IsNullOrEmpty(enconteredFont))
            {
                return new Font(enconteredFont, fontSize, FontStyle.Regular);
            }

            throw new KeyNotFoundException($"Font '{fontName}' not found!");
            
        }        

        public static List<string> List()
        {
            loadFonts();
            return new List<string>(loadedFonts);
        }

        #endregion



    }
}
