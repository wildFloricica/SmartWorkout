using SmartWorkout.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SmartWorkout.DTOs
{
    public class UserDto
    {
        public int?  Id { get; set; }
        [Required(ErrorMessage = "Please supply first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please supply last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please supply birthday ")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Please supply gender")]
        public string Gender { get; set; }

        public bool Exist { get; set; } = true;

        public static UserDto FromEntity(User user)
        {
            return new UserDto
            {
                //Birthday
                Birthday = user.Birthday,
                Gender = user.Gender,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

    }
}
