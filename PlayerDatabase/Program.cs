namespace PlayerDatabase
{
    public enum Commands : byte
    {
        First = 1,
        Second,
        Third,
        Fourth,
        Fifth
    }

    internal class Program
    {
        private static Database _database = new Database();

        private static void Main(string[] args)
        {
            _database.Work();
        }
    }
}