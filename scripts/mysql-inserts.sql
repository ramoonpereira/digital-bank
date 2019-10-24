INSERT INTO digitalbank.permissions
(module, permissions, `type`, created)
VALUES('pub-digitalaccount', 'pub-digitalaccount-r', 0, 1);

INSERT INTO digitalbank.customers
(name, email, password, phone, birth_date, document, status)
VALUES('Administrador', 'administrador@example.com', '035DB57C7B546F7F826E1A79919B4961AE2A1ECDEAAADB0AF38C37E06DB5E9BB', 16999999999, '2019-10-24', 12345678910, 1);

--- senha admin : abcdefgh

INSERT INTO digitalbank.customer_permissions
(customer_id, permission_id, permissions)
VALUES(1, 1, 'pub-digitalaccount-r');

INSERT INTO digitalbank.digital_account
(number, digit, customer_id,balance,transfer_limit,status)
VALUES(123, 'x', 1,100,500,1);