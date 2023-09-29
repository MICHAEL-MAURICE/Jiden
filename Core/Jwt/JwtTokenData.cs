namespace Core.Jwt
{
    public class JwtTokenData
    {
        
        public string UserId { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public List<Guid?> Governorates { get; set; }

    }
}
