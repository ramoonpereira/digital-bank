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

CREATE TABLE IF NOT EXISTS digital_account (
	id INT AUTO_INCREMENT PRIMARY KEY,
    number INT NOT NULL,
	digit CHAR(1) NOT NULL,
    customer_id INT NOT NULL,
    balance  DECIMAL(19,2),
    transfer_limit  DECIMAL(19,2),
	status BOOLEAN NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (customer_id)
        REFERENCES customers (id)
)  ENGINE=INNODB;