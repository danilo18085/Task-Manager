namespace DTO
{
    public class DTOLoginResponse
    {
        public string? Username {get; set;}
        public string? AccessToken {get; set;}
        public int ExpiresIn {get; set;}
    }
}