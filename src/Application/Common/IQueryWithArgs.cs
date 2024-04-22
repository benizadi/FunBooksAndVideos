namespace Application.Common;

public interface IQueryWithArgs<in TArgs, out TResult>
{
    TResult Execute(TArgs args);
}