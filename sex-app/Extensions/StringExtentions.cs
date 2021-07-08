namespace sex_app.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64(this string sender)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(sender);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}