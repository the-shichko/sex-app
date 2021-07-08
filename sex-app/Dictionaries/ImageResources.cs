using System.Collections.Generic;
using sex_app.Service;

namespace sex_app.Dictionaries
{
    public static class ImageResources
    {
        public static readonly Dictionary<Category, List<string>> ImageDictionary = new()
        {
            {
                Category.Cunnilingus,
                new List<string>
                {
                    "110", "121", "122", "133", "134", "145", "146", "157", "158", "169", "170", "181", "182", "192",
                    "202", "212", "222", "23", "231", "237", "73"
                }
            },
            {
                Category.OralSex,
                new List<string>
                {
                    "110", "121", "122", "133", "134", "145", "146", "157", "158", "169", "170", "181", "182", "192",
                    "202", "212", "222", "23", "231", "237", "73"
                }
            },
            {
                Category.Blowjob,
                new List<string>
                {
                    "121", "133", "145", "157", "169", "182", "23", "73", "193", "203", "232", "238"
                }
            },
            {
                Category.Position69,
                new List<string>
                {
                    "121", "133", "145", "157", "169", "182", "23", "73"
                }
            },
            {
                Category.Sex,
                new List<string>
                {
                    "1", "186", "210", "221", "235", "208", "206",
                }
            }
        };
    }
}