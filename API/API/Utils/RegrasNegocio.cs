using API.Models;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;

namespace API.Utils
{
    public class RegrasNegocio
    {
        /// <summary> 
        ///     Gera uma carteira de estudante digital.  
        /// </summary>
        /// 
        /// <param name="estudante"> 
        ///     Representa objeto do estudante.
        /// </param>
        /// 
        /// <returns>
        ///     Retorna uma imagem no formato base64 da carteira de estudante digital gerada.
        /// </returns>
        static public String GerarCarteiraEstudante(Estudante estudante)
        {
            try
            {
                var modeloCarteira = JsonConvert.DeserializeObject<ModeloCarteira.Rootobject>(File.ReadAllText(@"C:\ObjetoModeloCarteira.json"));

                modeloCarteira.Campos[0].TextContent = estudante.Nome;
                modeloCarteira.Campos[1].TextContent = estudante.Matricula;
                modeloCarteira.Campos[2].TextContent = estudante.Curso;
                modeloCarteira.Campos[3].TextContent = estudante.Instituicao;
                modeloCarteira.Campos[4].TextContent = estudante.Foto;

                Image imageModelo;

                using (MemoryStream ms = new(Convert.FromBase64String(modeloCarteira.BgImgProperties.Src)))
                {
                    imageModelo = Image.FromStream(ms);
                }

                for (int i = 0; i < modeloCarteira.Campos.Length; i++)
                {
                    if (string.Equals("Image", modeloCarteira.Campos[i].Type, StringComparison.OrdinalIgnoreCase))
                    {                       
                        try
                        {      
                            Image imgFotoPerfil;

                            using (MemoryStream ms = new(ConverterBase64eRetirarDataUriScheme(modeloCarteira.Campos[i].TextContent)))
                            {
                                imgFotoPerfil = Image.FromStream(ms);
                            }

                            Graphics graficosImgPerfil = Graphics.FromImage(imageModelo);

                            graficosImgPerfil.RotateTransform(modeloCarteira.Campos[i].Rotation);

                            graficosImgPerfil.DrawImage(imgFotoPerfil, modeloCarteira.Campos[i].ImgProperties.ImgX, modeloCarteira.Campos[i].ImgProperties.ImgY, modeloCarteira.Campos[i].ImgProperties.WidthField, modeloCarteira.Campos[i].ImgProperties.HeightField);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("A entrada de Foto não é uma string Base-64 válida.");
                        }
                    }
                    else
                    {
                        Font drawFont = new(modeloCarteira.Campos[i].Font.FontFamily,
                                        modeloCarteira.Campos[i].Font.FontSize,
                                        modeloCarteira.Campos[i].Font.FontBold | modeloCarteira.Campos[i].Font.FontItalic,
                                        GraphicsUnit.Pixel);

                        SolidBrush drawBrush = new(modeloCarteira.Campos[i].Font.FontColor);

                        Graphics graficosCampos = Graphics.FromImage(imageModelo);

                        graficosCampos.RotateTransform(modeloCarteira.Campos[i].Rotation);

                        graficosCampos.DrawString(modeloCarteira.Campos[i].TextContent, drawFont, drawBrush, modeloCarteira.Campos[i].X, modeloCarteira.Campos[i].Y);

                    }
                }

                using MemoryStream m = new MemoryStream();
                imageModelo.Save(m, ImageFormat.Png);

                return "data:image/" + imageModelo.RawFormat.ToString().ToLower() + ";base64," + Convert.ToBase64String(m.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static private byte[] ConverterBase64eRetirarDataUriScheme(string base64)
        {
            if (base64.Contains("data:image/"))
                return Convert.FromBase64String(base64.Substring(base64.IndexOf(',')).Replace(",", ""));

            return Convert.FromBase64String(base64);
        }
    }
}
