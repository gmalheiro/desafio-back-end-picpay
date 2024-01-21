INSERT INTO Users (full_name, email, password, balance, document_number, is_pessoa_fisica)
VALUES
    ('John Doe', 'john.doe@example.com', 'password123', 1000.00, '12345678909', 1), -- CPF (true)
    ('Jane Smith', 'jane.smith@example.com', 'pass456', 1500.50, '12345678000190', 0), -- CNPJ (false)
    ('Bob Johnson', 'bob.johnson@example.com', 'secret789', 2000.75, '98765432101', 1), -- CPF (true)
    ('Acme Corporation', 'info@acme.com', 'securepwd', 5000.25, '87654321000123', 0); -- CNPJ (false)