using System;
using System.Collections.Generic;

namespace LibraryApp.Model;

public partial class Title
{
    public int Bookid { get; set; }

    public int Id { get; set; }

    public string? Tit { get; set; }

    public byte? Lvl { get; set; }

    public byte? Sub { get; set; }

    public int RowId { get; set; }

    public virtual _0bok Book { get; set; } = null!;
}
