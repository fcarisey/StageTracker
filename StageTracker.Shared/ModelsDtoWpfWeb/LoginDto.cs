using System.ComponentModel.DataAnnotations;

namespace StageTracker.Shared.ModelsDtoWpfWeb;

public record class LoginDto()
{
    [Required(ErrorMessage = "Une adresse mail est requise !")]
    [EmailAddress(ErrorMessage = "L'adresse ne correspond pas !")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Un mot de passe est requis !")]
    #if DEBUG
    #else
    [MinLength(12, ErrorMessage = "Le mot de passe ne correspond pas !")]
    #endif
    public string? Password { get; set; }
}