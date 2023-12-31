﻿using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ProductDAO
{
    public static List<Product> GetProducts()
    {
        var listProducts = new List<Product>();
        try
        {
            using (var context = new ApplicationDBContext())
            {
                listProducts = context.Products.ToList();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return listProducts;
    }

    public static Product FindProductById(int prodId)
    {
        Product p = new Product();
        try
        {
            using (var context = new ApplicationDBContext())
            {
                p = context.Products.SingleOrDefault(p => p.ProductId == prodId);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return p;
    }

    public static void SaveProduct(Product p)
    {
        try
        {
            using (var context = new ApplicationDBContext())
            {
                context.Products.Add(p);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static void UpdateProduct(Product p)
    {
        try
        {
            using (var context = new ApplicationDBContext())
            {
                context.Entry<Product>(p).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static void DeleteProduct(Product p)
    {
        try
        {
            using (var context = new ApplicationDBContext())
            {
                var p1 = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                context.Products.Remove(p1);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}