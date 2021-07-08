using System.Collections.Generic;
using System.Linq;
using sex_app.Enums;
using sex_app.Extensions;

namespace sex_app.Models
{
    public class ListPositions : List<PositionItem>
    {
        public ListPositions()
        {
            AddRange(new[]
            {
                new PositionItem
                {
                    Title = "Челнок",
                    Activity = Activity.Women,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.LyingDown, Location.FaceToFace, Location.Rider
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.Petty,
                    FileName = "1.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.CrushHerAss,
                        AdditionalCaress.Kiss, AdditionalCaress.PlayWithHerAnus, AdditionalCaress.CrushHerBoobs
                    }
                },
                new PositionItem
                {
                    Title = "Тирамису",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.OnKnees
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "110.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.CrushHerAss,
                        AdditionalCaress.PlayWithHerAnus, AdditionalCaress.CrushHerBoobs
                    }
                },
                new PositionItem
                {
                    Title = "Указатель",
                    Activity = Activity.Both,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex, Category.Blowjob, Category.Position69
                    },
                    Locations = new List<Location>
                    {
                        Location.Reverse, Location.OnKnees
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "121.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Ластик",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.LyingDown
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "122.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Амфибия",
                    Activity = Activity.Both,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex, Category.Blowjob, Category.Position69
                    },
                    Locations = new List<Location>
                    {
                        Location.Reverse, Location.Sitting, Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "133.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss, AdditionalCaress.PlayWithHerAnus
                    }
                },
                new PositionItem
                {
                    Title = "Богиня",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.OnKnees
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "134.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerBoobs, AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Колизей",
                    Activity = Activity.Both,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex, Category.Blowjob, Category.Position69
                    },
                    Locations = new List<Location>
                    {
                        Location.Reverse, Location.Sitting, Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "145.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.PlayWithHerAnus, AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Эммануэль",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.OnKnees
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "146.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                         AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Коса",
                    Activity = Activity.Both,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex, Category.Blowjob, Category.Position69
                    },
                    Locations = new List<Location>
                    {
                        Location.Reverse, Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "157.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Петля",
                    Activity = Activity.Men,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.OnKnees
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "158.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Пальма",
                    Activity = Activity.Both,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex, Category.Blowjob, Category.Position69
                    },
                    Locations = new List<Location>
                    {
                        Location.Reverse, Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "169.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss, AdditionalCaress.CrushHerBoobs
                    }
                },
                new PositionItem
                {
                    Title = "Бархат",
                    Activity = Activity.Men,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.OnKnees
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "169.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss, AdditionalCaress.CrushHerBoobs
                    }
                }
            });
        }

        public List<PositionItem> FilterByCategory(Category category)
        {
            return this.Where(x => x.Categories.Contains(category)).ToList();
        }
    }

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
                   $"Категория: {string.Join(", ", Categories.Select(x => x.GetDisplayName("_").ToLower()))}\n" +
                   $"Положение: {string.Join(", ", Locations.Select(x => x.GetDisplayName("_").ToLower()))}\n" +
                   $"Стимулирование: {string.Join(", ", Stimulations.Select(x => x.GetDisplayName("_").ToLower()))}\n" +
                   $"Проникновение: {LevelPenetration.GetDisplayName("_").ToLower()}\n" +
                   $"Зрительный контакт: {EyeContact.GetDisplayName("_").ToLower()}\n" +
                   $"Активность: {Activity.GetDisplayName("_").ToLower()}\n" +
                   $"Уровень: {Level.GetDisplayName("_").ToLower()}\n" +
                   $"Доп.: {string.Join(", ", AdditionalCaresses.Select(x => x.GetDisplayName("_").ToLower()))}\n";
        }
    }
}