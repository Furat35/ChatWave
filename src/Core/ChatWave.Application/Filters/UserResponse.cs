using ChatWave.Application.Helpers;

namespace ChatWave.Application.Filters
{
    public class UserResponse<T> : ResponseFilter<T> where T : class, new()
    {
    }
}
