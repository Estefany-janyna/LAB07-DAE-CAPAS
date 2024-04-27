USE FactureDB

CREATE PROCEDURE USP_listarProducto
AS
BEGIN
    SELECT product_id,
    name,price,stock, active
    FROM products;
END;

USP_listarProducto

CREATE PROCEDURE USP_listarProductoNombre
    @name NVARCHAR(100)
AS
BEGIN
    SELECT product_id, name, price, stock, active
    FROM Products
    WHERE name LIKE '%' + @name + '%'
END
