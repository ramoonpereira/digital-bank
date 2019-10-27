INSERT INTO digitalbank.permissions
(module, permissions, `type`, created)
VALUES('pub-digitalaccount', 'pub-digitalaccount-r', 0, 1);

INSERT INTO digitalbank.permissions
(module, permissions, `type`, created)
VALUES('pub-transaction', 'pub-transaction-r,pub-transaction-c', 0, 1);

INSERT INTO digitalbank.permissions
(module, permissions, `type`, created)
VALUES('pub-digitalaccount', 'adm-digitalaccount-r', 1, 1);

INSERT INTO digitalbank.permissions
(module, permissions, `type`, created)
VALUES('pub-transaction', 'adm-transaction-r', 1, 1);

