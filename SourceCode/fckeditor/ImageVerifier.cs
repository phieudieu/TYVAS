using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Security.Cryptography;

/// <summary>
/// Summary description for ImageVerifier
/// </summary>
public class ImageVerifier
{
	public ImageVerifier()
	{}

    public string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }


    public string CreateImage(string path, float height, float width)
    {
        Random r = new Random();
        string salt = CreateSalt(4);
        Bitmap bmp = new Bitmap(((int)width), ((int)height), PixelFormat.Format24bppRgb);
        Graphics g = Graphics.FromImage(bmp);
        g.TextRenderingHint = TextRenderingHint.AntiAlias;
        g.Clear(Color.Black);
        g.DrawRectangle(Pens.White, 1, 1, width - 3, height - 3);
        g.DrawRectangle(Pens.Black, 0, 0, width, height);
        System.Drawing.Drawing2D.Matrix mymat = new System.Drawing.Drawing2D.Matrix();

        for (int i = 0;i<=salt.Length -1; i++)
        {
            mymat.Reset();
            mymat.RotateAt(r.Next(-30,0),new PointF(width * ((float)(0.12 * i)),height * ((float)0.5)));
            g.Transform = mymat;
            // draw the text on our(Image)
            g.DrawString (salt[i].ToString(),new Font("Verdana",15,FontStyle.Italic),SystemBrushes.ActiveCaptionText,width * ((float)(0.12 * i)),height * ((float)0.5));
            g.ResetTransform();
        }

        bmp.Save(path, ImageFormat.Gif);
        g.Dispose();
        bmp.Dispose();

        return salt;
    }
 

}
