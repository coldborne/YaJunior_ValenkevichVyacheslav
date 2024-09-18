namespace Aquarium
{
    public static class GeneratorFishNames
    {
        public static string GenerateFishName()
        {
            const int NameLength = 5;
            const int StartSymbolIndex = 97;
            const int EndSymbolIndex = 122;

            string name = "";

            while (name.Length < NameLength)
            {
                char symbol = (char)UserUtils.GetRandomValue(StartSymbolIndex, EndSymbolIndex + 1);

                if (char.IsLetterOrDigit(symbol))
                {
                    name += symbol;
                }
            }

            return name;
        }
    }
}