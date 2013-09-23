namespace EOCS_CS
{
    interface IParser
    {
        bool HasMoreCommands();
        void Advance();
        Commands CommandType();
        string Symbol();
        string Dest();
        string Comp();
        string Jump();
    }
}