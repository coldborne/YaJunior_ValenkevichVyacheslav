using System;
using System.Collections.Generic;
using Zoo.Extensions;

namespace Zoo.Entities
{
    public class Zoo
    {
        private static Zoo s_instance;

        private List<Aviary> _aviaries;

        private Zoo(IEnumerable<Aviary> aviaries)
        {
            _aviaries = new List<Aviary>(aviaries);
        }

        private Zoo()
        {
            throw new Exception("Нельзя создать так объект");
        }

        public static Zoo Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new Zoo(new List<Aviary>());
                }

                return s_instance;
            }
        }

        public void AddAviary(Aviary aviary)
        {
            _aviaries.Add(aviary);
        }

        public bool TryGetAviary(int index, out Aviary aviary)
        {
            if (index >= 0 && index < _aviaries.Count)
            {
                aviary = _aviaries[index].Copy();
                return true;
            }

            aviary = null;
            return false;
        }

        public List<Aviary> GetAviaries()
        {
            return _aviaries.Copy();
        }
    }
}