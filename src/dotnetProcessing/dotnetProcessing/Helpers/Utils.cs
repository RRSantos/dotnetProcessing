namespace dotnetProcessing.Helpers
{
    static class Utils
    {
        public static float Lerp(float start, float finish, float ammount)
        {
            return (start + (finish - start) * ammount);
        }
    }
}
