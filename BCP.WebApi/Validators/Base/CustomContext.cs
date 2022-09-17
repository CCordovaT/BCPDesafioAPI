using BCP.Models;

namespace BCP.WebApi.Validators
{
    public class CustomContext
    {
        public bool ExistsErrorInSecondLevel { get; set; }
        public bool ExistsErrorInFirstLevel { get; set; }

        public Usuario Usuario { get; set; }
    }
}