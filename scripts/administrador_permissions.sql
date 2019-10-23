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