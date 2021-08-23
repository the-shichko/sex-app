using System;
using System.Collections.Generic;
using System.Linq;
using sex_app.Enums;
using sex_app.Extensions;

namespace sex_app.Models
{
    //TODO Transfer to JSON
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
                    FileName = "doggy2.png"
                },
                new()
                {
                    Activity = Activity.Men,
                    Categories = new List<Category> { Category.Sex },
                    Level = Level.Easy,
                    Locations = new List<Location>
                        { Location.FaceToFace, Location.MenLyingDown, Location.WomenLyingDown, Location.MenOnTop },
                    Title = "Tucked Missionary",
                    Text =
                        "Близкий родственник Folded Missionary, вариант Tucked отличается тем, что ноги женщины согнуты в коленях и расположены снаружи тела мужчины. Это позволяет снизить нагрузку на мужчин, которые слишком сильно наклоняются, и намного легче добиться интимной близости без ног. Мы рекомендуем женщинам поэкспериментировать как с углом таза, так и с тем, насколько открыты ноги, чтобы найти то, что чувствует себя лучше всего. ",
                    FileName = "missionary3.png"
                },
                new()
                {
                    Activity = Activity.Men,
                    Categories = new List<Category> { Category.OralSex, Category.Cunnilingus },
                    Level = Level.Easy,
                    Locations = new List<Location>
                        { Location.MenLyingDown, Location.WomenLyingDown },
                    Title = "Eagle (Орел)",
                    Text =
                        "В (раскинутой) позе орла женщина лежит на спине, поставив ступни, а мужчина лежит лицом вниз между ее ног. Эта поза пользуется большим успехом из-за высокого уровня комфорта, но может быть немного сложно добавить аппликатуру из-за ограниченного пространства для локтей ... Тем не менее, ее грудь находится в пределах досягаемости ... что всегда является преимуществом. Вы также можете подумать о подушке под ее спиной, чтобы наклонить ее таз для лучшего доступа к ротовой полости и уменьшить нагрузку на шею мужчины.",
                    FileName = "cunnilingus.png"
                },
                new()
                {
                    Activity = Activity.Women,
                    Categories = new List<Category> { Category.OralSex, Category.Blowjob },
                    Level = Level.Easy,
                    Locations = new List<Location>
                        { Location.MenLyingDown, Location.WomenOnKnees },
                    Title = "Usual (Обычно)",
                    Text =
                        "Вероятно, самый распространенный способ исполнения фелляции, в «Обычном» есть много чего. В него легко попасть, очень удобно, и это не сильно напрягает женскую шею. Это положение можно удерживать в течение длительного периода, прежде чем потребуется сделать перерыв или сменить положение, особенно при смене рук по мере необходимости. Единственным реальным недостатком является то, что распущенные длинные волосы могут попасть в рот, поэтому мужчинам следует подумать о помощи, когда это необходимо. ",
                    FileName = "blowjob.png"
                },
                new()
                {
                    Activity = Activity.Both,
                    Categories = new List<Category> { Category.OralSex, Category.Position69 },
                    Level = Level.Easy,
                    Locations = new List<Location>
                        { Location.MenLyingDown, Location.WomenOnKnees },
                    Title = "69",
                    Text =
                        "Оригинальная поза 69, которую легко выполнять, остается одной из самых популярных поз 69. В стандартном варианте мужчина ложится на спину, а его партнер становится на колени перед его лицом и наклоняется вперед. Подушка под голову мужчине - это необходимое условие, если вы собираетесь провести какое-то время в этой позе. ",
                    FileName = "69.png"
                },
                new()
                {
                    Activity = Activity.Women,
                    Categories = new List<Category> { Category.OralSex, Category.Blowjob },
                    Level = Level.Easy,
                    Locations = new List<Location>
                        { Location.MenLyingDown, Location.WomenLyingDown },
                    Title = "Open Usual",
                    Text =
                        "Открытый Обычный - это тонкая вариация Обычного, где мужчина раздвигает ноги, а женщина лежит между ними. Несмотря на небольшую разницу на бумаге, это оказывает огромное влияние на возможное количество яичек и анальной игры. Хорошей идеей будет иметь несколько подушек под спиной мужчины, чтобы наклонить его таз и еще больше улучшить доступ.",
                    FileName = "blowjob2.png"
                },
                new()
                {
                    Activity = Activity.Women,
                    Categories = new List<Category> { Category.OralSex, Category.Blowjob },
                    Level = Level.Easy,
                    Locations = new List<Location>
                        { Location.MenSitting, Location.WomenOnKnees },
                    Title = "Sit & Blow",
                    Text =
                        "Sit & Blow - отличный способ заставить любого мужчину почувствовать себя королем замка ... и мы хотели бы думать, что это был любимый способ Билла произнести некоторые слова в овале. Легко попасть и довольно удобно, единственное, что мы действительно можем сказать, помимо шуток, - это то, что некоторые подушки на полу - это всегда умная игра, когда мы стоим на коленях.",
                    FileName = "blowjob3.png"
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