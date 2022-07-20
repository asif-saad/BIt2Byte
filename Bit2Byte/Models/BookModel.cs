using Bit2Byte.Controllers;
using Bit2Byte.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Bit2Byte.Models;

public class BookModel
{
    public int Id { get; set; }     // need this



    [StringLength(100, MinimumLength = 5)]
    [Required(ErrorMessage = "Please enter the title of your book")]
    [Display(Name = "Event Name")]
    [MyCustomValidationAttribute(text = "Testing")]
    public string Title { get; set; }  // need this





    [Required(ErrorMessage = "Please enter the author name")]
    [Display(Name = "Team Name")]
    public string Author { get; set; } // need thhis





    [StringLength(500)]
    public string Description { get; set; } // need thhis





    public string Category { get; set; }  // need this






    [Required(ErrorMessage = "Please choose the language of your book")]
    public int LanguageId { get; set; }







    [Display(Name = "Host Country")]
    public string Language { get; set; }  // need thhis









    [Required(ErrorMessage = "Please enter the total pages")]
    [Display(Name = "Merit Position")]
    public int? TotalPages { get; set; }  // need this








    [Display(Name = "Choose the cover photo of your event")]
    [Required]
    public IFormFile CoverPhoto { get; set; }








    public string CoverImageUrl { get; set; }









    [Display(Name = "Choose the gallery images of your book")]
    [Required]
    public IFormFileCollection GalleryFiles { get; set; }







    public List<GalleryModel> Gallery { get; set; }







    [Display(Name = "Upload your book in pdf format")]
    [Required]
    public IFormFile BookPdf { get; set; }






    public string BookPdfUrl { get; set; }
}
