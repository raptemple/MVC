using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Models
{

  public class Pet
  {

    public int Id { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "{0} must be greater or equal to {1} characters in length.")]
    [Remote(action: "VerifyName", controller: "Pet")]
    public string Name { get; set; }

    [Required]
    [Range(0, 5, ErrorMessage = "{0} must be between {1} and {2} years.")]

    public string Age { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
    public string Color { get; set; }

  }
}