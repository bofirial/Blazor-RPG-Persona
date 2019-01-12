using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Avatar
{
    public class TechnologyCharacterAvatarImageGenerator : ITechnologyCharacterAvatarImageGenerator
    {
        public TechnologyCharacterAvatarImage GenerateTechnologyCharacterAvatarImage(TechnologyCharacterAvatarModel model)
        {
            string gender = "Male";

            var avatarBase = GetEmbeddedBitmap($"TechnologyCharacterGenerator.Avatar.images.Programmer 1 - {gender} - Base.png");
            var avatarHair = GetEmbeddedBitmap($"TechnologyCharacterGenerator.Avatar.images.Programmer 1 - {gender} - Hair.png");
            var avatarSkin = GetEmbeddedBitmap($"TechnologyCharacterGenerator.Avatar.images.Programmer 1 - {gender} - Skin.png");
            var avatarMain = GetEmbeddedBitmap($"TechnologyCharacterGenerator.Avatar.images.Programmer 1 - {gender} - Main.png");
            var avatarAccent = GetEmbeddedBitmap($"TechnologyCharacterGenerator.Avatar.images.Programmer 1 - {gender} - Accent.png");

            var avatar = new Bitmap(avatarBase.Width, avatarBase.Height);

            var skinColor = new HslColor(ColorTranslator.FromHtml(model.SkinColor));
            var hairColor = new HslColor(ColorTranslator.FromHtml(model.HairColor));
            var mainColor = new HslColor(ColorTranslator.FromHtml(model.MainColor));
            var accentColor = new HslColor(ColorTranslator.FromHtml(model.AccentColor));

            for (var y = 0; y < avatarBase.Height; y++)
            {
                for (var x = 0; x < avatarBase.Width; x++)
                {
                    SetColor(avatarHair, hairColor, x, y);
                    SetColor(avatarSkin, skinColor, x, y);
                    SetColor(avatarMain, mainColor, x, y);
                    SetColor(avatarAccent, accentColor, x, y);
                }
            }

            using (var g = Graphics.FromImage(avatar))
            {
                g.DrawImage(avatarBase, new Rectangle(0, 0, avatarBase.Width, avatarBase.Height));
                g.DrawImage(avatarHair, new Rectangle(0, 0, avatarHair.Width, avatarHair.Height));
                g.DrawImage(avatarSkin, new Rectangle(0, 0, avatarSkin.Width, avatarSkin.Height));
                g.DrawImage(avatarMain, new Rectangle(0, 0, avatarMain.Width, avatarMain.Height));
                g.DrawImage(avatarAccent, new Rectangle(0, 0, avatarAccent.Width, avatarAccent.Height));
            }

            using (var stream = new MemoryStream())
            {
                avatar.Save(stream, ImageFormat.Png);

                return new TechnologyCharacterAvatarImage()
                {
                    ImageSource = $"data:image/png;base64, {Convert.ToBase64String(stream.ToArray())}"
                };
            }
        }

        public Bitmap GetEmbeddedBitmap(string name)
        {
            var foundation = this.GetType().Assembly;
            var stream = foundation.GetManifestResourceStream(name);
            return new Bitmap(stream);
        }

        public void SetColor(Bitmap image, HslColor targetColor, int x, int y)
        {
            var color = image.GetPixel(x, y);

            var newHslColor = new HslColor(targetColor.Hue,
                CalculateResultSaturationOrLuminosity(color.GetSaturation(), (float) targetColor.Saturation),
                CalculateResultSaturationOrLuminosity(color.GetBrightness(), (float)targetColor.Luminosity));
            var newColor = (Color)newHslColor;

            image.SetPixel(x, y, Color.FromArgb(color.A, newColor.R, newColor.G, newColor.B));
        }

        public float CalculateResultSaturationOrLuminosity(float templateValue, float targetValue)
        {
            return 2 * templateValue + targetValue - 1;
        }
    }
}