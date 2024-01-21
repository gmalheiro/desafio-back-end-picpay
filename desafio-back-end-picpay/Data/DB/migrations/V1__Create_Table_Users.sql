CREATE TABLE Users (
    id INT PRIMARY KEY IDENTITY(1,1),
    full_name NVARCHAR(100) NOT NULL,
    email NVARCHAR(125) NOT NULL UNIQUE, 
    password NVARCHAR(MAX) NOT NULL,
    balance FLOAT NOT NULL,
    document_number NVARCHAR(18) NOT NULL UNIQUE,
    is_pessoa_fisica BIT NOT NULL
);