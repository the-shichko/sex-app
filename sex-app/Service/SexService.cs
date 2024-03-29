﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using sex_app.Dictionaries;
using sex_app.Enums;
using sex_app.Models;

namespace sex_app.Service
{
    public static class SexService
    {
        private static readonly string ResourcesPath = $"{Directory.GetCurrentDirectory()}\\Resources";
        private static readonly string PositionsPath = $"{Directory.GetCurrentDirectory()}\\Data\\positions.json";
        private static ListPositions _listPositions;
        private static List<int> RandomNumber { get; set; }

        public static void Init()
        {
            RandomNumber = new List<int>();
            _listPositions =
                new ListPositions(JsonConvert.DeserializeObject<List<PositionItem>>(File.ReadAllText(PositionsPath)));
        }

        /// <summary>
        /// Get path of random (message, path to file) by type
        /// </summary>
        /// <returns></returns>
        public static (string, string) GetRandomPositionNew()
        {
            var index = CustomRandom(0, _listPositions.Count - 1);
            return (_listPositions[index].ToTelegramMessage(),
                $"{ResourcesPath}\\{_listPositions[index].FileName}");
        }

        private static int CustomRandom(int from, int to)
        {
            var iterationCount = 0;
            while (true)
            {
                iterationCount++;
                if (iterationCount == 1000)
                    RandomNumber = new List<int>();

                var value = RandomNumberGenerator.GetInt32(from, to);
                if (RandomNumber.Contains(value)) continue;

                RandomNumber.Add(value);
                return value;
            }
        }


        public static (string, string) GetByFilter(Type type, string value)
        {
            List<PositionItem> filterList;
            if (FilterResources.ListOfTypeGeneric.Contains(type.Name))
            {
                var listProperties = _listPositions.Select(x => new
                    {
                        Item = x,
                        Property = x.GetType().GetProperties()
                            .FirstOrDefault(propertyInfo =>
                                propertyInfo.PropertyType == typeof(List<>).MakeGenericType(type))
                    })
                    .ToList();

                filterList = (from item in listProperties
                    let listOfItems = item.Property.GetValue(item.Item)
                    let list = (listOfItems as IEnumerable)?.OfType<object>().ToList()
                    where list != null && list.Select(x => x.ToString()).Contains(value)
                    select item.Item).ToList();
            }
            else
            {
                filterList = _listPositions.Where(x => x.GetType().GetProperties()
                        .FirstOrDefault(propertyInfo => propertyInfo.PropertyType == type)?.GetValue(x, null)
                        ?.ToString() == value)
                    .ToList();
            }

            var index = filterList.Count > 2 ? CustomRandom(0, filterList.Count - 1) : 0;
            return filterList.Any()
                ? (filterList[index].ToTelegramMessage(),
                    $"{ResourcesPath}\\{filterList[index].FileName}")
                : ("Данная поза не добавлена... Приносим извинения", $"{ResourcesPath}\\dev.jpg");
        }

        /// <summary>
        /// Get set of images for sex
        /// </summary>
        /// <param name="dictionaryFilter">Key = value of enum Category, Value = count</param>
        /// <returns>images of positions by dictionary filter</returns>
        public static IEnumerable<string> GetSexSet(Dictionary<Category, int> dictionaryFilter)
        {
            var listPaths = new List<string>();
            foreach (var (value, count) in dictionaryFilter)
            {
                for (var i = 0; i < count; i++)
                {
                    var image = GetByFilter(typeof(Category), value.ToString()).Item2;

                    if (!listPaths.Contains(image))
                        listPaths.Add(image);
                    else
                        i--;
                }
            }

            return listPaths;
        }

        public static string GetInfoByImage(string imagePath)
        {
            var imageName = imagePath.Split('\\', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            return _listPositions.FirstOrDefault(x => x.FileName == imageName)?.Text;
        }

        public static string AboutBot()
        {
            return $"Количество поз: {_listPositions.Count}";
        }
    }
}