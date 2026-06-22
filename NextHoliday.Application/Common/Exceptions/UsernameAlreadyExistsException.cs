namespace NextHoliday.Application.Common.Exceptions
{
    public class UserDataAlreadyExistsException : Exception
    {
        public UserDataAlreadyExistsException(string field, string username)
            : base($"The {field} '{username}' is already in use.") { }
    }
}
