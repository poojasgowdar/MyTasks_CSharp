﻿using System;
using System.Collections.Generic;

namespace DB_Approach.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public virtual Brand? Brand { get; set; } = null!;

    public virtual Category? Category { get; set; } = null!;
}
