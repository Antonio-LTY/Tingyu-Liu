public class LibraryBranch
{
    public int LibraryBranchId { get; set; }
    public string? BranchName { get; set; }

    // 导航属性：一个分馆有多本书
    public ICollection<Book>? Books { get; set; }
}