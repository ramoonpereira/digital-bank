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