public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public int AuthorId { get; set; } // foreign key 外键：作者ID
    public int LibraryBranchId { get; set; }

    // 导航属性：一本书有一个作者,因为不是collection，所以用单数形式
    public Author? Author { get; set; }

    // 导航属性：一本书属于一个分馆
    public LibraryBranch? LibraryBranch { get; set; }
}