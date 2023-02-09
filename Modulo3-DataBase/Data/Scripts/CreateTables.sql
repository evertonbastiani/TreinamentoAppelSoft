CREATE TABLE tipo_veiculo(
  id int NOT NULL AUTO_INCREMENT,
  descricao varchar(45) NOT NULL UNIQUE,
  PRIMARY KEY (id)
);


CREATE TABLE veiculo (
    id int NOT NULL AUTO_INCREMENT,
    marca varchar(45) NOT NULL,
	modelo varchar(100) NOT NULL,
    placa varchar(15) NOT NULL,
    ano int,
    cor varchar(45),   
    tipo int not null,
    PRIMARY KEY (id),
    FOREIGN KEY(tipo) REFERENCES tipo_veiculo(id)
);