namespace NextHoliday.Application.Common.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException()
            : base("Username or password are incorrect.") { }
    }
}
