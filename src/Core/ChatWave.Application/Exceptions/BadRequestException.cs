namespace ChatWave.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("An bad request occured! Please try again.")
        {

        }

        public BadRequestException(string message) : base(message)
        {

        }
    }
}
