using System;
using System.Drawing;
using System.Drawing.Drawing2D;

class Program
{
    static void Main(string[] args)
    {
        int dist = 10;

        int columns = 80;
        int rows = 80;

        int width = (dist * columns) + 1;
        int height = (dist * rows) + 1;

        Bitmap img = new Bitmap( width, height );
        using( Graphics g = Graphics.FromImage( img ) )
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear( Color.Black );

            var rand = new Random();

            for( int x = 0; x < width; x += dist )
            {
                int offset = 0;

                if( rand.NextDouble() >= 0.5 )
                {
                    offset = dist;
                }

                for( int y = offset; y < height - dist; y += (2 * dist) )
                {
                    g.DrawLine( Pens.White, x, y, x, y + dist );
                }
            }

            for( int y = 0; y < height; y += dist )
            {
                int offset = 0;

                if( rand.NextDouble() >= 0.5 )
                {
                    offset = dist;
                }

                for( int x = offset; x < width - dist; x += (2 * dist) )
                {
                    g.DrawLine( Pens.White, x, y, x + dist, y );
                }
            }
        }


        img.Save("output.png");
    }
}