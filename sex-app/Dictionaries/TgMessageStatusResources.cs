using System.Collections.Generic;
using sex_app.Enums;

namespace sex_app.Dictionaries
{
    public static class TgMessageStatusResources
    {
        public static Dictionary<StatusUser, string> Values => new()
        {
            { StatusUser.WaitAddToDo, "Отправьте текст для пополнения списка" },
            { StatusUser.WaitRemoveToDo, "Отправьте индекс для удаления из списка" },
            { StatusUser.WaitExecuteToDo, "Отправьте индекс для выполнения" },
        };
    }
}