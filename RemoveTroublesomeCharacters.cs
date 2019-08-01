public static string RemoveTroublesomeCharacters(string inString)
{
    if (inString == null)
    {
        return null;
    }

    else
    {
        char ch;
        Regex regex = new Regex(@"[^\u0000-\u007F]", RegexOptions.IgnoreCase);
        Match charMatch = regex.Match(inString);

        for (int i = 0; i < inString.Length; i++)
        {
            ch = inString[i];
            if (char.IsControl(ch))
            {
                string matchedChar = ch.ToString();
                inString = inString.Replace(matchedChar, string.Empty);
            }
        }

        while (charMatch.Success)
        {
            string matchedChar = charMatch.ToString();
            inString = inString.Replace(matchedChar, string.Empty);
            charMatch = charMatch.NextMatch();
        }
    }       

    return inString;
}