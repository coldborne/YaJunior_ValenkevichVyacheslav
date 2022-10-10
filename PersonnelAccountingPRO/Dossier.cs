namespace PersonnelAccountingPRO
{
    public class Dossier
    {
        public string Fullname { get; private set; }
        public string Position { get; private set; }
        
        public Dossier(string fullname, string position)
        {
            Fullname = fullname;
            Position = position;
        }
    }
}