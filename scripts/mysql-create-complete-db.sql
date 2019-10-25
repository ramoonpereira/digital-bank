CREATE TABLE IF NOT EXISTS customers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    email  VARCHAR(255) NOT NULL,
	password TEXT NOT NULL,
    phone BIGINT NOT NULL,
	birth_date DATE NOT NULL,
	document BIGINT NOT NULL,
    status BOOLEAN NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)  ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS administrators (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    email  VARCHAR(255) NOT NULL,
    password TEXT NOT NULL,
    phone BIGINT NOT NULL,
    birth_date DATE NOT NULL,
    document BIGINT NOT NULL,
    status BOOLEAN NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)  ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS permissions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    module VARCHAR(255) NOT NULL,
    permissions  TEXT NOT NULL,
	type INT NOT NULL,
	created BOOLEAN NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)  ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS customer_permissions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    permission_id INT NOT NULL,
    permissions TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (customer_id)
        REFERENCES customers (id),
	FOREIGN KEY (permission_id)
        REFERENCES permissions (id)
)  ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS administrator_permissions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    administrator_id INT NOT NULL,
    permission_id INT NOT NULL,
    permissions TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (administrator_id)
        REFERENCES administrators (id),
	FOREIGN KEY (permission_id)
        REFERENCES permissions (id)
)  ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS digital_account (
	id INT AUTO_INCREMENT PRIMARY KEY,
    number INT NOT NULL,
	digit CHAR(1) NOT NULL,
    customer_id INT NOT NULL,
    balance  DECIMAL(19,2),
    transfer_limit_transaction  DECIMAL(19,2),
    transfer_limit_transaction_day  DECIMAL(19,2),
	status BOOLEAN NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (customer_id)
        REFERENCES customers (id)
)  ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS digital_account_transactions (
	id INT AUTO_INCREMENT PRIMARY KEY,
    digital_account_sender_id INT,
    digital_account_id INT NOT NULL,
    value  DECIMAL(19,2),
	type INT NOT NULL,
	operation INT NOT NULL,
	status INT NOT NULL,
	release_at TIMESTAMP,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (digital_account_id)
        REFERENCES digital_account (id),
    FOREIGN KEY (digital_account_sender_id)
        REFERENCES digital_account (id)
)  ENGINE=INNODB;