using System.Collections.Generic;

namespace Zoo
{
    public class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public void AddAviary(Aviary aviary)
        {
            _aviaries.Add(aviary);
        }

        public void Init()
        {
            Aviary capybaraAviary = AviariesGenerator.TryGenerateAviary(typeof(Capybara));
            AddAviary(capybaraAviary);
            Aviary catAviary = AviariesGenerator.TryGenerateAviary(typeof(Cat));
            AddAviary(catAviary);
            Aviary zebraAviary = AviariesGenerator.TryGenerateAviary(typeof(Zebra));
            AddAviary(zebraAviary);
            Aviary secretaryBirdAviary = AviariesGenerator.TryGenerateAviary(typeof(SecretaryBird));
            AddAviary(secretaryBirdAviary);
            Aviary platypusAviary = AviariesGenerator.TryGenerateAviary(typeof(Platypus));
            AddAviary(platypusAviary);
        }
    }
}