using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using sex_app.Enums;
using sex_app.Extensions;

namespace sex_app.Models
{
    //TODO Transfer to JSON
    public class ListPositions : List<PositionItem>
    {
        public ListPositions(IEnumerable<PositionItem> items)
        {
            AddRange(items);
            AddRange(new List<PositionItem>
            {
                new()
                {
                    Activity = Activity.Women,
                    Categories = new List<Category> { Category.OralSex, Category.Blowjob },
                    Level = Level.Mild,
                    Locations = new List<Location>
                        { Location.MenOnKnees, Location.WomenLyingDown },
                    Title = "Plumber Sex",
                    Text =
                        "Эта поза, получившая свое название от сходства с сантехником, залезающим под раковину, является чрезвычайно удобным способом для женщин согреть трубку. Когда мужчина стоит на четвереньках, у женщин есть отличный доступ для некоторого времени, проведенного в тишине и яичках, а также для изучения некоторых менее посещаемых дорог, хотя, вероятно, было бы неплохо постучать, прежде чем их заклеймят как нарушителя. Однако есть небольшой недостаток, или, скорее, неглубокий, так как совмещение ее рта и горла не идеально для глубокого глотания. ",
                    FileName = "blowjob4.png"
                },
                new()
                {
                    Activity = Activity.Men,
                    Categories = new List<Category> { Category.Sex },
                    Level = Level.Mild,
                    Locations = new List<Location>
                        { Location.MenStandingUp, Location.WomenStandingUp, Location.DoggyStyle, Location.MenBehind },
                    Title = "Supported Standing Doggy",
                    Text =
                        "Популярный многими вариант «Собачка» с опорой на стойку - это универсальная поза, которую большинство из нас будет часто посещать во время своей сексуальной карьеры. Особенно хорошо подходит для людей с проблемами колен, женщины, вероятно, сочтут этот вариант намного более комфортным при более сильных толчках, что намного проще с повышенной подвижностью. Небольшую регулировку высоты можно выполнить, слегка согнув колени или поставив ступни вместе, хотя предпочтительнее иметь ступенчатый стул или высокие каблуки.",
                    FileName = "doggy3.png"
                },
                new()
                {
                    Activity = Activity.Women,
                    Categories = new List<Category> { Category.Sex },
                    Level = Level.Mild,
                    Locations = new List<Location>
                        { Location.MenLyingDown, Location.WomenOnKnees, Location.Rider },
                    Title = "Rodeo",
                    Text =
                        "Во главе семейства Rodeo стандартный вариант - это классика, которая нравится большинству людей. В него очень легко попасть; мужчина просто лежит на спине, а женщина становится на колени поверх него, отвернувшись. Предлагая большую подвижность, глубину и комфорт, он также намного более устойчив к выскальзыванию из-за слишком большого бокового движения - хотя чрезмерное вытягивание может быть довольно болезненным для мужчин, поэтому женщины будьте осторожны! Мы рекомендуем женщинам поэкспериментировать, положив руки на ноги переднего мужчины, или отказаться от рук, чтобы найти то, что доставит вам наибольшее удовольствие!",
                    FileName = "sex2.png"
                }
            });

            // var json = JsonConvert.SerializeObject(this);
            // File.WriteAllText($"{Directory.GetCurrentDirectory()}\\Data\\positions.json", json);
        }
    }

    [Serializable]
    public class PositionItem
    {
        public string Title { get; init; }
        public string FileName { get; init; }
        public List<Category> Categories { get; init; }
        public List<Location> Locations { get; init; }
        public Activity Activity { get; init; }
        public Level Level { get; init; }
        public string Text { get; set; }

        public string ToTelegramMessage()
        {
            return $"*{Title}*\n\n" +
                   (Categories.Count > 0
                       ? $"Категория: {string.Join(", ", Categories.Select(x => x.GetDisplayName("_").ToLower()))}\n"
                       : null) +
                   (Locations.Count > 0
                       ? $"Положение: {string.Join(", ", Locations.Select(x => x.GetDisplayName("_").ToLower()))}\n"
                       : null) +
                   $"Активность: {Activity.GetDisplayName("_").ToLower()}\n" +
                   $"Уровень: {Level.GetDisplayName("_").ToLower()}\n";
        }
    }
}