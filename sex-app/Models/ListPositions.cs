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
            // AddRange(items);
            AddRange(new List<PositionItem>
            {
                new()
                {
                    Activity = Activity.Men,
                    Categories = new List<Category> { Category.Sex },
                    Level = Level.Easy,
                    Locations = new List<Location> { Location.FaceToFace, Location.MenOnTop },
                    Title = "Missionary (Миссионерская)",
                    Text =
                        "Миссионерская позиция, вероятно, является наиболее распространенной "
                        + "первой позой, которую люди пробуют, что, вероятно, связано с ее простотой, " +
                        "удобством и высоким уровнем близости. Чтобы принять это положение, женщина просто ложится на спину, " +
                        "а мужчина лежит на ней лицом вниз. Хотя первоначальное прицеливание может быть для мужчины поначалу немного трудным, " +
                        "получить от нее руку помощи можно довольно легко решить эту проблему. Мы рекомендуем",
                    FileName = "missionary.png"
                },
                new()
                {
                    Activity = Activity.Men,
                    Categories = new List<Category> { Category.Sex },
                    Level = Level.Easy,
                    Locations = new List<Location> { Location.DoggyStyle, Location.MenOnKnees, Location.WomenOnKnees },
                    Title = "Doggy (Собачка)",
                    Text =
                        "Стандартный вариант стиля Doggy Style удобен, интуитивно понятен и универсален; женщина просто становится на четвереньки, а мужчина садится сзади и становится на колени. Как и в большинстве положений входа сзади, угол проникновения, как правило, очень хорошо подходит для нацеливания на точку G, поэтому мы рекомендуем женщинам изучить, как наклонять таз и выгибать спину, чтобы найти лучшие углы. Как и во всех положениях на коленях, мы рекомендуем положить подушки на пол для дополнительного комфорта, а также для точного выравнивания паха.",
                    FileName = "doggy.png"
                },
                new()
                {
                    Activity = Activity.Women,
                    Categories = new List<Category> { Category.Sex },
                    Level = Level.Easy,
                    Locations = new List<Location> { Location.WomenOnTop, Location.MenLyingDown, Location.FaceToFace },
                    Title = "Cowgirl (Постушка)",
                    Text =
                        "В очень популярной позе наездницы мужчина лежит на спине, а женщина склоняется над ним лицом к его голове. Большая часть движений происходит от женщины, поднимающей, покачивающей и / или вращающей бедра, хотя мужчина может помочь придать вещам немного аромата снизу. Игра с ее грудями - одна из замечательных особенностей этой позы, хотя просто наблюдать, как они подпрыгивают, тоже не так уж плохо, просто не поддавайтесь гипнозу! Если вы на вершине, вы можете поэкспериментировать как с откидыванием назад, как показано на рисунке, так и с наклоном вперед на груди вашего партнера, чтобы найти то, что лучше всего подходит для вас.",
                    FileName = "cowgirl.png"
                },
                new()
                {
                    Activity = Activity.Women,
                    Categories = new List<Category> { Category.Sex },
                    Level = Level.Easy,
                    Locations = new List<Location> { Location.WomenOnTop, Location.MenLyingDown, Location.FaceToFace },
                    Title = "Collapsed Cowgirl (Свернувшаяся пастушка)",
                    Text =
                        "Вариация свернутой наездницы - это в значительной степени именно то, на что это похоже. Хотите ли вы зайти поцеловаться или просто дать ногам немного отдохнуть, это отлично подходит для обоих. Движение для этой позиции обычно является командным усилием, поскольку ни один из партнеров не обладает большой подвижностью в этом раскладе. Предостережение для мужчин: будьте осторожны с зубами при выполнении более сильных ударов. Выбор времени во время поцелуя может иметь болезненные и дорогостоящие последствия! Вам также может понравиться подложить подушку под спину мужчине, чтобы наклонить его таз для более глубокого проникновения.",
                    FileName = "cowgirl2.png"
                },
                new()
                {
                    Activity = Activity.Men,
                    Categories = new List<Category> { Category.Sex },
                    Level = Level.Easy,
                    Locations = new List<Location> { Location.DoggyStyle, Location.MenOnKnees, Location.WomenOnKnees },
                    Title = "Face Down Doggy (Собачка лицом вниз)",
                    Text =
                        "В варианте «Собачий стиль» лицом вниз женщина наклоняется вперед и кладет голову на пол. Угол проникновения не идеален для попадания в точку G, но отлично подходит для удара в малоизвестное место во влагалище, называемое задним сводом, а некоторые могут даже обнаружить усиленную стимуляцию клитора. Подушки рекомендуются под ее голову, а также под колени обоих людей, что не должно вызывать удивления, поскольку мы довольно много заботимся о комфорте. ",
                    FileName = "dobby2.png"
                }
            });
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