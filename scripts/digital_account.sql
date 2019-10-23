CREATE TABLE IF NOT EXISTS digital_account (
	id INT AUTO_INCREMENT PRIMARY KEY,
    number INT NOT NULL,
	digit CHAR(1) NOT NULL,
    customer_id INT NOT NULL,
    balance  DECIMAL(19,2),
	status BOOLEAN NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (customer_id)
        REFERENCES customers (id)
)  ENGINE=INNODB;