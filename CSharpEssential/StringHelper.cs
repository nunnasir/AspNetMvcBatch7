namespace CSharpEssential;

internal static class StringHelper
{
    public static string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    //public static string ToUpperCase(this string input)
    //{
    //    return input?.ToUpper();
    //}

    public static string ToUpperCase(this string input, bool shouldTrim)
    {
        if(shouldTrim)
        {
            input = input.Trim();
        }
        return input.ToUpper();
    }
}






