namespace PlayerDatabase
{
    public enum Command : byte
    {
        AddPlayer = 1,
        DeletePlayer,
        BanPlayer,
        UnbanPlayer,
        Exit
    }
}