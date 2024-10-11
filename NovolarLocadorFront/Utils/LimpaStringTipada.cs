using NovolarLocadorFront.Models;
using System.Globalization;

namespace NovolarLocadorFront.Utils
{
    public static class LimpaStringRetornaListTipadoExtension
    {
        public static List<T> Limpar<T>(this string value)
        {
            var arrayResultante = value.Split(',');
            List<T> listaResultante = new List<T>();

            foreach (var item in arrayResultante)
            {
                char[] chars = new char[] { '[', '"', ']', '\\', '/' };
                string[] strings = item.Split(chars, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item1 in strings)
                {
                    if (item1.Length > 1)
                    {
                        try
                        {
                            T itemConvertido = (T)Convert.ChangeType(item1, typeof(T), CultureInfo.InvariantCulture);
                            listaResultante.Add(itemConvertido);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            return listaResultante;
        }
    }
}
