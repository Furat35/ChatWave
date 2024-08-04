using FluentValidation;

namespace ChatWave.Application.Extensions
{
    public static class CustomFluentValidationExceptionHandling
    {
        public static async Task ValidateAndThrowAsync<T>(this IValidator<T> validator, T input)
        {
            var validationResult = await validator.ValidateAsync(input);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ErrorMessage);
        }
    }
}
