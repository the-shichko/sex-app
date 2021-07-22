using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using sex_app.Enums;
using sex_app.Extensions;
using sex_app.Models;

namespace sex_app.Service
{
    public static class SexService
    {
        private static readonly string ResourcesPath = $"{Directory.GetCurrentDirectory()}\\Resources";
        private static ListPositions _listPositions;
        private static List<int> RandomNumber { get; set; }

        public static void Init()
        {
            _listPositions = new ListPositions();
            RandomNumber = new List<int>();
        }

        /// <summary>
        /// Get path of random (message, path to file) by type
        /// </summary>
        /// <returns></returns>
        public static (string, string) GetRandomPositionNew(Category? position = null)
        {
            var items = position != null
                ? _listPositions.FilterByCategory(position.Value)
                : _listPositions;

            var index = CustomRandom(0, items.Count - 1);
            return (items[index].ToTelegramMessage(),
                $"{ResourcesPath}\\{items[index].FileName}");
        }

        private static int CustomRandom(int from, int to)
        {
            if (RandomNumber.Count > RandomNumberGenerator.GetInt32(15, 20))
                RandomNumber = new List<int>();

            while (true)
            {
                var value = RandomNumberGenerator.GetInt32(from, to);
                if (RandomNumber.Contains(value)) continue;

                RandomNumber.Add(value);
                return value;
            }
        }


        public static (string, string) GetByFilter(Type type, string value)
        {
            var test = _listPositions.Select(x => x.GetType().GetProperties()
                .FirstOrDefault(propertyInfo => propertyInfo.PropertyType == typeof(List<>).MakeGenericType(type))).ToList()
                .Select(x => x.GetValue(x, null));

            // var test2 = test.Where(x => ((List<object>) x).Select(o => ((dynamic) o).GetDisplayName()).Contains(value));


            // foreach (IList obj in test.Select(x => x.GetValue(x, null)))
            // {
            //     var a = Contains(obj);
            // }
            //
            // static bool Contains(IList list)
            // {
            //     foreach (var obj in list)
            //     {
            //         if (obj.ToString() == value)
            //             return true;
            //     }
            //
            //     return false;
            // }


            var filterList = type.IsEnum
                ? _listPositions.Where(x => x.GetType().GetProperties()
                        .FirstOrDefault(propertyInfo => propertyInfo.GetType() == type)?.GetValue(x, null)
                        .GetDisplayName()?.ToString() == value)
                    .ToList()
                : _listPositions.Where(x =>
                    x.GetType().GetProperties().FirstOrDefault(propertyInfo => propertyInfo.GetType() == type)
                        ?.GetValue(x, null)?.ToString() == value).ToList();

            var index = CustomRandom(0, filterList.Count - 1);
            return (filterList[index].ToTelegramMessage(),
                $"{ResourcesPath}\\{filterList[index].FileName}");
        }
    }
}