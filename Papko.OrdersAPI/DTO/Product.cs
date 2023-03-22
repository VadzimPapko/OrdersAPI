﻿namespace Papko.OrdersAPI.DTO;

public sealed class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product() => Id = Guid.NewGuid();
}