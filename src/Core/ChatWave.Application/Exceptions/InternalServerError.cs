namespace ChatWave.Application.Exceptions
{
    public class InternalServerError : Exception
    {
        public InternalServerError() : base("An internal server error occured! Please try again.")
        {

        }

        public InternalServerError(string message) : base(message)
        {

        }
    }
}
