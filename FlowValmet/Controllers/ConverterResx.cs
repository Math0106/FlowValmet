using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowValmet.Controllers
{
    internal class ConverterResx
    {

        public static Image GetIcon(string resourceName, int? width = null, int? height = null)
        {
            try
            {
                // Tenta obter diretamente como Image
                if (Properties.Resources.ResourceManager.GetObject(resourceName) is Image image)
                {
                    return ResizeImage(image, width, height);
                }

                // Se falhar, tenta como byte[]
                if (Properties.Resources.ResourceManager.GetObject(resourceName) is byte[] bytes && bytes.Length > 0)
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        var loadedImage = Image.FromStream(ms);
                        return ResizeImage(loadedImage, width, height);
                    }
                }

                throw new Exception("Recurso não encontrado ou formato inválido.");
            }
            catch (Exception ex)
            {
                // Log de erro (substitua por seu sistema de log)
                Console.WriteLine($"Erro ao carregar ícone '{resourceName}': {ex.Message}");

                // Retorna uma imagem de fallback ou null
                return CreateFallbackIcon(width ?? 32, height ?? 32);
            }
        }

        private static Image ResizeImage(Image original, int? width, int? height)
        {
            if (!width.HasValue && !height.HasValue) return original;

            var newWidth = width ?? original.Width;
            var newHeight = height ?? original.Height;

            return new Bitmap(original, new Size(newWidth, newHeight));
        }

        private static Image CreateFallbackIcon(int width, int height)
        {
            // Cria um ícone de fallback (quadrado vermelho com "X")
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                using (var pen = new Pen(Color.Red, 2))
                {
                    g.DrawRectangle(pen, 1, 1, width - 3, height - 3);
                    g.DrawLine(pen, 0, 0, width, height);
                    g.DrawLine(pen, width, 0, 0, height);
                }
            }
            return bmp;
        }
    }
}
