﻿namespace Catalog.Api.Dtos;

public class ProductCreateDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string CategoryId { get; set; }
}