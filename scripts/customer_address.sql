CREATE TABLE IF NOT EXISTS customer_address (
    id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    address_line1  VARCHAR(255) NOT NULL,
    address_line2  VARCHAR(255),
    number INT,
	zipcode INT NOT NULL,
	city VARCHAR(255) NOT NULL,
    state VARCHAR(2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (customer_id)
        REFERENCES customers (id)
)  ENGINE=INNODB;