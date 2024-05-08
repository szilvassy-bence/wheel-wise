using System.ComponentModel.DataAnnotations;

namespace wheel_wise.Contracts;

public record RegistrationRequest([Required] string Email, [Required] string UserName, [Required] string Password, int ZipCode);