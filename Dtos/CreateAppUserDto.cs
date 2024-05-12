namespace TS.Bootcamp.MinimalWebAPI.Dtos
{
    public sealed record CreateAppUserDto(string Email, string Password, string FirstName, string LastName)
    {
    }
}
