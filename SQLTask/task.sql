SELECT Products.ProductName, ISNULL(Categories.CategoryName, 'Не определено')
FROM Products
         LEFT JOIN ProductCategory ON Products.ProductID = ProductCategory.ProductID
         LEFT JOIN Categories ON ProductCategory.CategoryID = Categories.CategoryID;