using System.Drawing.Imaging;
using System.Text;
using UOO;
using Ultima;

void Main(string? filepath)
{
    if (string.IsNullOrWhiteSpace(filepath))
    {
        filepath = @".\art.uoo";
    }
    try
    {
        UOOUnpacker uoop = new UOOUnpacker(filepath);
        uoop.SaveAllSpritesAsPng();
    }
    catch
    {
        Console.WriteLine("Couldnt load or save uoo file.");
    }
}

class UOOUnpacker {
    ArtFile artFile;
    public UOOUnpacker(string filename)
    {
        artFile = new ArtFile(filename);
    }

    public void SaveAllSpritesAsPng()
    {
        uint i = 0u;
        while (true)
        {
            var sprite = artFile.GetSprite(i);
            try
            {
                var bitmap = UOOHelper.ConstructBitmapFrom16Bits(sprite.Pixels, sprite.Width, sprite.Height);
                StringBuilder sb = new StringBuilder();
                sb.Append(i).Append(".png");
                bitmap.Save(sb.ToString(), ImageFormat.Png);
            }
            catch
            {
                Console.WriteLine("{0} not found", i);
            }
            i++;
        }
    }

    public void SaveSpriteAsPng(uint id)
    {
        var sprite = artFile.GetSprite(id);
        try
        {
            var bitmap = UOOHelper.ConstructBitmapFrom16Bits(sprite.Pixels, sprite.Width, sprite.Height);
            StringBuilder sb = new StringBuilder();
            sb.Append(id).Append(".png");
            bitmap.Save(sb.ToString(), ImageFormat.Png);
        }
        catch
        {
            Console.WriteLine("{0} not found", id);
        }
    }
}




*/