namespace beqom.Domain.Aggregate.Option
{
    public interface IOption<out T>
    {
        T FromValue();
    }
}
