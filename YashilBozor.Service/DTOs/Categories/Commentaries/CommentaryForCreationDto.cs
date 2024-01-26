namespace YashilBozor.Service.DTOs.Categories.Commentaries;

public class CommentaryForCreationDto
{
    public string Comment { get; set; }
    public bool IsLiked { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
