﻿using System.ComponentModel.DataAnnotations;

namespace BusinessObject;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}