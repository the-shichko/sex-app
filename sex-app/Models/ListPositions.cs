using System;
using System.Collections.Generic;
using System.Linq;
using sex_app.Enums;
using sex_app.Extensions;

namespace sex_app.Models
{
    public class ListPositions : List<PositionItem>
    {
        public ListPositions(IEnumerable<PositionItem> items)
        {
            AddRange(items);
        }

        public List<PositionItem> FilterByCategory(Category category)
        {
            return this.Where(x => x.Categories.Contains(category)).ToList();
        }
    }

    [Serializable]
    public class PositionItem
    {
        public string Title { get; init; }
        public string FileName { get; init; }
        public List<Category> Categories { get; init; }
        public List<Location> Locations { get; init; }
        public List<Stimulation> Stimulations { get; init; }
        public LevelPenetration LevelPenetration { get; init; }
        public BaseBool EyeContact { get; init; }
        public Activity Activity { get; init; }
        public Level Level { get; init; }
        public List<AdditionalCaress> AdditionalCaresses { get; init; }

        public string ToTelegramMessage()
        {
            return $"*{Title}*\n\n" +
                   (Categories.Count > 0
                       ? $"Категория: {string.Join(", ", Categories.Select(x => x.GetDisplayName("_").ToLower()))}\n"
                       : null) +
                   (Locations.Count > 0
                       ? $"Положение: {string.Join(", ", Locations.Select(x => x.GetDisplayName("_").ToLower()))}\n"
                       : null) +
                   (Stimulations.Count > 0
                       ? $"Стимулирование: {string.Join(", ", Stimulations.Select(x => x.GetDisplayName("_").ToLower()))}\n"
                       : null) +
                   $"Проникновение: {LevelPenetration.GetDisplayName("_").ToLower()}\n" +
                   $"Зрительный контакт: {EyeContact.GetDisplayName("_").ToLower()}\n" +
                   $"Активность: {Activity.GetDisplayName("_").ToLower()}\n" +
                   $"Уровень: {Level.GetDisplayName("_").ToLower()}\n" +
                   (AdditionalCaresses.Count > 0
                       ? $"Доп.: {string.Join(", ", AdditionalCaresses.Select(x => x.GetDisplayName("_").ToLower()))}\n"
                       : null);
        }
    }
}