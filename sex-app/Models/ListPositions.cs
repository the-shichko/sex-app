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
                    FileName = "170.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss, AdditionalCaress.PlayWithHerAnus
                    }
                },
                new PositionItem
                {
                    Title = "Сфинкс",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "181.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss, AdditionalCaress.PlayWithHerAnus, AdditionalCaress.CrushHerBoobs
                    }
                },
                new PositionItem
                {
                    Title = "Кулон",
                    Activity = Activity.Both,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex, Category.Position69, Category.Blowjob
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.LyingDown, Location.Reverse
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "182.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss, AdditionalCaress.PlayWithHerAnus
                    }
                },
                new PositionItem
                {
                    Title = "Маяк",
                    Activity = Activity.Men,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.MenOnTop, Location.MenBehind, Location.Reverse, Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.DotP
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Middle,
                    FileName = "186.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Пиала",
                    Activity = Activity.Men,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.MenOnTop, Location.LyingDown
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "192.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss, AdditionalCaress.PlayWithHerAnus, AdditionalCaress.CrushHerBoobs
                    }
                },
                new PositionItem
                {
                    Title = "Торшер",
                    Activity = Activity.Women,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Blowjob, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.Sitting
                    },
                    Stimulations = new List<Stimulation>(),
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "193.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss, AdditionalCaress.CrushHerBoobs
                    }
                },
                new PositionItem
                {
                    Title = "Чайный пакетик",
                    Activity = Activity.Women,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Blowjob, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>(),
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "203.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Распятие",
                    Activity = Activity.Both,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.MenBehind, Location.Sitting
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.DotA, Stimulation.DotG
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.High,
                    FileName = "206.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Виолончель",
                    Activity = Activity.Men,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.MenBehind, Location.OnKnees
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.DotP
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Middle,
                    FileName = "208.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Залощница",
                    Activity = Activity.Men,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.DoggyStyle, Location.MenBehind, Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.DotG, Stimulation.DotP
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.High,
                    FileName = "210.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Колонна",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "212.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.CrushHerBoobs, AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Шишка",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.LyingDown, Location.MenOnTop, Location.MenBehind, Location.Reverse
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.DotA, Stimulation.DotG
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "221.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Орхидея",
                    Activity = Activity.Men,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "222.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Кружево",
                    Activity = Activity.Men,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "231.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.ToCuddle
                    }
                },
                new PositionItem
                {
                    Title = "Поглощение",
                    Activity = Activity.Both,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Blowjob, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>(),
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "232.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Паприка",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.DoggyStyle, Location.MenBehind, Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>()
                    {
                        Stimulation.DotG, Stimulation.DotP
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.High,
                    FileName = "235.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Медальон",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Cunnilingus, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.Sitting
                    },
                    Stimulations = new List<Stimulation>()
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "237.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.PlayWithHerAnus, AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Альбатрос",
                    Activity = Activity.Women,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Blowjob, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>(),
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "238.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Книга",
                    Activity = Activity.Both,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Blowjob, Category.OralSex, Category.Cunnilingus, Category.Position69
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.LyingDown, Location.Reverse
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "23.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.PlayWithHerAnus, AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Инь-Янь",
                    Activity = Activity.Both,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Blowjob, Category.OralSex, Category.Cunnilingus, Category.Position69
                    },
                    Locations = new List<Location>
                    {
                        Location.LyingDown, Location.MenOnTop, Location.Reverse
                    },
                    Stimulations = new List<Stimulation>
                    {
                        Stimulation.Clitoris
                    },
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "73.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.PlayWithHerAnus, AdditionalCaress.CrushHerAss
                    }
                },
                new PositionItem
                {
                    Title = "Плуг",
                    Activity = Activity.Both,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.DoggyStyle, Location.MenBehind, Location.StandingUp
                    },
                    Stimulations = new List<Stimulation>(),
                    EyeContact = BaseBool.No,
                    LevelPenetration = LevelPenetration.High,
                    FileName = "243.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Тигрица",
                    Activity = Activity.Women,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.WomenOnTop, Location.FaceToFace, Location.Rider
                    },
                    Stimulations = new List<Stimulation>()
                    {
                        Stimulation.DotP
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.High,
                    FileName = "40.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.CrushHerAss, AdditionalCaress.CrushHerBoobs, AdditionalCaress.Kiss,
                        AdditionalCaress.KissBoobs
                    }
                },
                new PositionItem
                {
                    Title = "Круассан",
                    Activity = Activity.Women,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Blowjob, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.LyingDown
                    },
                    Stimulations = new List<Stimulation>(),
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "63.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Рабыня",
                    Activity = Activity.Women,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Blowjob, Category.OralSex
                    },
                    Locations = new List<Location>
                    {
                        Location.LyingDown
                    },
                    Stimulations = new List<Stimulation>(),
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.Without,
                    FileName = "25.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Корзина",
                    Activity = Activity.Men,
                    Level = Level.Complicated,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.FaceToFace, Location.FeetOnShoulders, Location.Sitting
                    },
                    Stimulations = new List<Stimulation>()
                    {
                        Stimulation.Clitoris, Stimulation.DotP
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.High,
                    FileName = "105.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                    {
                        AdditionalCaress.Kiss, AdditionalCaress.ToCuddle
                    }
                },
                new PositionItem
                {
                    Title = "Реагент",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.LyingDown, Location.FaceToFace, Location.MenOnTop, Location.FeetOnShoulders
                    },
                    Stimulations = new List<Stimulation>()
                    {
                        Stimulation.Clitoris, Stimulation.DotP
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.High,
                    FileName = "163.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.Kiss
                    }
                },
                new PositionItem
                {
                    Title = "Реагент",
                    Activity = Activity.Men,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.LyingDown, Location.FaceToFace, Location.MenOnTop
                    },
                    Stimulations = new List<Stimulation>()
                    {
                        Stimulation.Clitoris, Stimulation.DotP
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.Middle,
                    FileName = "3.png",
                    AdditionalCaresses = new List<AdditionalCaress>
                    {
                        AdditionalCaress.Kiss
                    }
                },
                new PositionItem
                {
                    Title = "Офицерская",
                    Activity = Activity.Men,
                    Level = Level.Mild,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.LyingDown, Location.FaceToFace, Location.MenOnTop, Location.FeetOnShoulders
                    },
                    Stimulations = new List<Stimulation>()
                    {
                        Stimulation.Clitoris, Stimulation.DotP
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.High,
                    FileName = "115.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
                },
                new PositionItem
                {
                    Title = "Лотос",
                    Activity = Activity.Both,
                    Level = Level.Easy,
                    Categories = new List<Category>
                    {
                        Category.Sex
                    },
                    Locations = new List<Location>
                    {
                        Location.FaceToFace, Location.FeetOnShoulders, Location.Sitting
                    },
                    Stimulations = new List<Stimulation>()
                    {
                        Stimulation.DotP
                    },
                    EyeContact = BaseBool.MayBe,
                    LevelPenetration = LevelPenetration.High,
                    FileName = "240.png",
                    AdditionalCaresses = new List<AdditionalCaress>()
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