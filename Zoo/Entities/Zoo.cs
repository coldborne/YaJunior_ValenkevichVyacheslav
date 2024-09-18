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

        public Aviary GetAviary(int index)
        {
            if (index >= 0 && index < _aviaries.Count)
            {
                return _aviaries[index].Copy();
            }

            return null;
        }

        public List<Aviary> GetAviaries()
        {
            return _aviaries.Copy();
        }
    }
}