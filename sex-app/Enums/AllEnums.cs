using System.ComponentModel.DataAnnotations;

namespace sex_app.Enums
{
    public enum Location
    {
        [Display(Name = "Мужчина сверху")]
        MenOnTop,
        [Display(Name = "Женщина сверху")]
        WomenOnTop,
        [Display(Name = "Мужчина сзади")]
        MenBehind,
        [Display(Name = "Реверс")]
        Reverse,
        [Display(Name = "Стоя")]
        StandingUp,
        [Display(Name = "Лежа")]
        LyingDown,
        [Display(Name = "Лицо к лицу")]
        FaceToFace,
        [Display(Name = "Наездница")]
        Rider,
        [Display(Name = "На коленях")]
        OnKnees,
        [Display(Name = "Сидя")]
        Sitting,
        [Display(Name = "Doggy style")]
        DoggyStyle
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
        ToCuddle
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
        [Display(Name = "Да")]
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