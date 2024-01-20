CREATE TABLE ShopKeeper (
    id INT PRIMARY KEY IDENTITY(1,1),
    full_name NVARCHAR(100) NOT NULL,
    email NVARCHAR(125) NOT NULL UNIQUE,
    password NVARCHAR(MAX) NOT NULL,
    balance FLOAT NOT NULL,
    cnpj NVARCHAR(18) NOT NULL UNIQUE
);