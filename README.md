USE FacturaDB

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





--Insertar

ALTER PROCEDURE USP_InsertarProductos
    @name NVARCHAR(100),
    @price DECIMAL(18, 2),
    @stock INT
AS
BEGIN
    INSERT INTO Products (name, price, stock, active)
    VALUES (@name, @price, @stock, 1);
END;


--Eliminar lOGICA

CREATE PROCEDURE USP_EliminarProducto
    @product_id INT
AS
BEGIN
    update Products
	set active = 0
    WHERE product_id = @product_id;
END;
