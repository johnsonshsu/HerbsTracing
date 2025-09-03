public class vmContact
{
    [Display(Name = "ContactorName")]
    [Required(ErrorMessage = "ContactorNameErrorMessage")]
    public string ContactorName { get; set; } = "";
    [Display(Name = "ContactorEmail")]
    [Required(ErrorMessage = "ContactorEmailErrorMessage")]
    [EmailAddress(ErrorMessage = "EmailAddressErrorMessage")]
    public string ContactorEmail { get; set; } = "";
    [Display(Name = "ContactorSubject")]
    [Required(ErrorMessage = "ContactorSubjectErrorMessage")]
    public string ContactorSubject { get; set; } = "";
    [Display(Name = "ContactorMessage")]
    [Required(ErrorMessage = "ContactorMessageErrorMessage")]
    public string ContactorMessage { get; set; } = "";
}