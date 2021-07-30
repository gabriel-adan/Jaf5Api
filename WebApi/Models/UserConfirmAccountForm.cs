namespace WebApi.Models
{
    public class UserConfirmAccountForm
    {
        public string UserName { get; set; }
        public string VerifyCode { get; set; }
    }
}
