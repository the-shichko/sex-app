using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sex_app.Service
{
    public static class SexService
    {
        public static List<string> CunnilingusPositions { get; set; }
        private static Random _random;

        public static void Init()
        {
            _random = new Random();
            var resourcesPath = $"{Directory.GetCurrentDirectory()}\\Resources";

            #region init cunni

            CunnilingusPositions = Directory.GetFiles($"{resourcesPath}\\Cunnilingus").ToList();

            #endregion
        }

        /// <summary>
        /// Get path of random media by type
        /// </summary>
        /// <returns></returns>
        public static string GetRandomPosition(TypePosition position = TypePosition.All)
        {
            var needPositions = GetNeedPositions(position).ToList();

            var index = _random.Next(0, needPositions.Count - 1);
            return needPositions[index];
        }

        private static IEnumerable<string> GetNeedPositions(TypePosition position)
        {
            return position switch
            {
                TypePosition.All => throw new NotImplementedException("TypePosition.All implement"),
                TypePosition.Cunnilingus => CunnilingusPositions,
                _ => throw new ArgumentOutOfRangeException(nameof(position), position, null)
            };
        }
    }

    public enum TypePosition
    {
        All,
        Cunnilingus
    }
}