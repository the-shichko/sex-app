using System.ComponentModel.DataAnnotations;

namespace sex_app.Enums
{
    public enum Location
    {
        [Display(Name = "Мужчина сверху")]
        MenOnTop,
        [Display(Name = "Женщина сверху")]
        WomenOnTop,
        // [Display(Name = "Мужчина сзади")]
        // MenBehind,
        // [Display(Name = "Реверс")]
        // Reverse,
        // [Display(Name = "Стоя")]
        // StandingUp,
        [Display(Name = "Лежа (муж.)")]
        MenLyingDown,
        [Display(Name = "Сидя (муж.)")]
        MenSitting,
        [Display(Name = "Лежа (жен.)")]
        WomenLyingDown,
        [Display(Name = "Лицо к лицу")]
        FaceToFace,
        [Display(Name = "Наездница")]
        Rider,
        [Display(Name = "Муж. на коленях")]
        MenOnKnees,
        [Display(Name = "Жен. на коленях")]
        WomenOnKnees,
        [Display(Name = "Doggy style")]
        DoggyStyle,
        [Display(Name = "Ноги на плечах")]
        FeetOnShoulders
    }

    public enum Stimulation
    {
        [Display(Name = "Точка P")]
        DotP,
        [Display(Name = "Клитор")]
        Clitoris,
        [Display(Name = "Точка A")]
        DotA,
        [Display(Name = "Точка G")]
        DotG
    }

    public enum LevelPenetration
    {
        [Display(Name = "Без проникновения")]
        Without,
        [Display(Name = "Мелкое")]
        Petty,
        [Display(Name = "Среднее")]
        Middle,
        [Display(Name = "Глубокое")]
        High
    }

    public enum AdditionalCaress
    {
        [Display(Name = "Мять её попку")]
        CrushHerAss,
        [Display(Name = "Играть с её анусом")]
        PlayWithHerAnus,
        [Display(Name = "Мять её грудь")]
        CrushHerBoobs,
        [Display(Name = "Целоваться")]
        Kiss,
        [Display(Name = "Обниматься")]
        ToCuddle,
        [Display(Name = "Целовать грудь")]
        KissBoobs
    }

    public enum Activity
    {
        [Display(Name = "Мужчина")]
        Men,
        [Display(Name = "Женщина")]
        Women,
        [Display(Name = "Оба")]
        Both
    }

    public enum BaseBool
    {
        Yea,
        [Display(Name = "Нет")]
        No,
        [Display(Name = "Возможен")]
        MayBe
    }

    public enum Level
    {
        [Display(Name = "Умеренный")]
        Mild,
        [Display(Name = "Сложный")]
        Complicated,
        [Display(Name = "Легкий")]
        Easy
    }
    
    public enum Category
    {
        [Display(Name = "Куни")]
        Cunnilingus,
        [Display(Name = "Оральный секс")]
        OralSex,
        [Display(Name = "Поза 69")]
        Position69,
        [Display(Name = "Минет")]
        Blowjob,
        [Display(Name = "Секс")]
        Sex,
    }
}