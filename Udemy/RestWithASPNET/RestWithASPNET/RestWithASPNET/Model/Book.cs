using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET.Model;

[Table("book")]
public class Book
{
    [Column("id")]
    public int Id { get; set; }
    [Column("author")]
    public string? Author { get; set; }
    [Column("launch_date")]
    public DateTime Launch_Date { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
    [Column("title")]
    public string? Title { get; set; }
}
