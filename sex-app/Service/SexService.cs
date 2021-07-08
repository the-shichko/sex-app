using System;
using System.IO;
using System.Linq;
using sex_app.Dictionaries;
using sex_app.Enums;
using sex_app.Models;

namespace sex_app.Service
{
    public static class SexService
    {
        private static Random _random;
        private static readonly string ResourcesPath = $"{Directory.GetCurrentDirectory()}\\Resources";
        private static ListPositions _listPositions;

        public static void Init()
        {
            _random = new Random();
            _listPositions = new ListPositions();
        }

        /// <summary>
        /// Get path of random media by type
        /// </summary>
        /// <returns></returns>
        public static string GetRandomPosition(Category? position = null)
        {
            var images = position != null
                ? ImageResources.ImageDictionary[position.Value]
                : ImageResources.ImageDictionary[
                    (Category) _random.Next(0, Enum.GetNames(typeof(Category)).Length) - 1];
            var needPositions =
                images.Select(x => $"{ResourcesPath}\\{x}.png").ToList();

            var index = _random.Next(0, needPositions.Count - 1);
            return needPositions[index];
        }

        public static (string, string) GetRandomPositionNew(Category? position = null)
        {
            var items = position != null
                ? _listPositions.FilterByCategory(position.Value)
                : _listPositions;

            var index = _random.Next(0, items.Count - 1);
            return (items[index].ToTelegramMessage(),
                $"{ResourcesPath}\\{items[index].FileName}");
        }
    }
}