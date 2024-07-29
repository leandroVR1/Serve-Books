CREATE TABLE Roles(
	Id int AUTO_INCREMENT PRIMARY KEY,
 	Name varchar(50)
);


CREATE TABLE Users(
	Id int AUTO_INCREMENT PRIMARY KEY,
 	Name varchar(50),
    RolId int(11),
    FOREIGN KEY (RolId) REFERENCES Roles(Id)
); 

CREATE TABLE Authors(
	Id int AUTO_INCREMENT PRIMARY KEY,
 	Name varchar(50)
); 

CREATE TABLE Genders(
	Id int AUTO_INCREMENT PRIMARY KEY,
 	Name varchar(50)
); 


CREATE TABLE Books(
	Id int AUTO_INCREMENT PRIMARY KEY,
 	Title varchar(50),
    AuthorId int,
    GenderId int,
    PublicationDate DateTime,
    NumberCopiesAvailable int(11),
    FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
    FOREIGN KEY (GenderId) REFERENCES Genders(Id)
);


CREATE TABLE Loans(
	Id int AUTO_INCREMENT PRIMARY KEY,
 	Description varchar(50),
    BookId varchar(50),
    UserId varchar(50),
    DeliveryDate DateTime,
    DateLoan DateTime,
    FOREIGN KEY (BookId) REFERENCES Books(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

