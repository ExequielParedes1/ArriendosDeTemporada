using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace WEBArriendoTemporada.metodos
{
    public class Redimension
    {
        public System.Drawing.Image RedimensionarImagenSubida(System.Drawing.Image ImagenOriginal, int Alto, System.Drawing.Image imagenFondo)
        {
            var Radio = (double)Alto / ImagenOriginal.Height;
            var RadioFondo = (double)Alto / imagenFondo.Height;
            var NuevoAncho = (int)(ImagenOriginal.Width * Radio);
            var NuevoAlto = (int)(imagenFondo.Height * RadioFondo);
            var NuevaImagenRefimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            var g = Graphics.FromImage(NuevaImagenRefimencionada);
            g.DrawImage(ImagenOriginal, 0, 0, NuevoAncho, NuevoAlto);
            return NuevaImagenRefimencionada;
        }
        public System.Drawing.Image RedimensionarImagen(System.Drawing.Image ImagenOriginal, int Alto)
        {
            var Radio = (double)Alto / ImagenOriginal.Height;
            var NuevoAncho = (int)(ImagenOriginal.Width * Radio);
            var NuevoAlto = (int)(ImagenOriginal.Height * Radio);
            var NuevaImagenRefimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            var g = Graphics.FromImage(NuevaImagenRefimencionada);
            g.DrawImage(ImagenOriginal, 0, 0, NuevoAncho, NuevoAlto);
            return NuevaImagenRefimencionada;
        }
        public System.Drawing.Image RedimensionarImagenFondo(System.Drawing.Image ImagenOriginal, int Alto)
        {
            var Radio = (double)Alto / ImagenOriginal.Height;
            var NuevoAncho = (int)((ImagenOriginal.Width * Radio));
            var NuevoAlto = (int)(ImagenOriginal.Height * Radio);
            var NuevaImagenRefimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            var g = Graphics.FromImage(NuevaImagenRefimencionada);
            g.DrawImage(ImagenOriginal, 0, 0, NuevoAncho, NuevoAlto);
            return NuevaImagenRefimencionada;
        }
        public double posicionAncho(System.Drawing.Image imagenFondo, System.Drawing.Image ImagenOriginal, int Alto)
        {
            var Radio = (double)Alto / ImagenOriginal.Height;
            var NuevoAncho = (int)(ImagenOriginal.Width * Radio);

            var Radio2 = (double)Alto / imagenFondo.Height;
            var NuevoAncho2 = (int)((imagenFondo.Width * Radio2));

            return NuevoAncho2 - Radio;
        }
    }
}
