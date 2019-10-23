CREATE TABLE IF NOT EXISTS digital_account_transactions (
	id INT AUTO_INCREMENT PRIMARY KEY,
    digital_account_id INT NOT NULL,
    value  DECIMAL(19,2),
	type INT NOT NULL,
	operation INT NOT NULL,
	status INT NOT NULL,
	release_at TIMESTAMP,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (digital_account_id)
        REFERENCES digital_account (id)
)  ENGINE=INNODB;