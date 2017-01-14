namespace FastAndFurious.ConsoleApplication.Common.Extensions
{
    public interface IIdentifiable<TKey>
    {
        TKey Id { get; }
    }
}
