public class Author
{
    public int AuthorId { get; set; } //{ get; set; }：这是属性的标准写法，表示可以读取（get）和设置（set）这个值。
    public string? Name { get; set; }

    // 导航属性：一个作者可以有多本书
    public ICollection<Book>? Books { get; set; } //{ get; set; }：这是属性的标准写法，表示可以读取（get）和设置（set）这个值。
}