using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using sex_app.Dictionaries;

namespace sex_app.Service
{
    public static class SexService
    {
        private static Random _random;
        private static readonly string ResourcesPath = $"{Directory.GetCurrentDirectory()}\\Resources";

        public static void Init()
        {
            _random = new Random();
        }

        /// <summary>
        /// Get path of random media by type
        /// </summary>
        /// <returns></returns>
        public static string GetRandomPosition(Category position)
        {
            var needPositions = ImageResources.ImageDictionary[position]
                .Select(x => $"{ResourcesPath}\\{x}.png").ToList();

            var index = _random.Next(0, needPositions.Count - 1);
            return needPositions[index];
        }
    }

    public enum Category
    {
        Cunnilingus,
        OralSex,
        Position69,
        Blowjob,
        Sex
    }
}