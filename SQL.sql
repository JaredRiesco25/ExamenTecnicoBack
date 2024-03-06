create database employees;

CREATE TABLE Employees (
    Id int NOT NULL IDENTITY(1,1),
    Nombre varchar(255) NOT NULL,
	FechaNacimiento varchar(255),
    Edad int,
	Posicion varchar(50),
	Estatus bit
    PRIMARY KEY (Id)
);

select * from employees;

create procedure EmployeesAll
as
select Id, Nombre, FechaNacimiento, Edad, Posicion, Estatus from employees
order by Id asc;

create procedure EmployeesInsert
@Nombre varchar(255),
@FechaNacimiento varchar(255),
@Edad int,
@Posicion varchar(50),
@Estatus bit = 1
as
Insert into employees (Nombre, FechaNacimiento, Edad, Posicion, Estatus) values (@Nombre, @FechaNacimiento, @Edad, @Posicion, @Estatus);

create procedure EmployeesUpdate
@Id int,
@Nombre varchar(255),
@FechaNacimiento varchar(255),
@Edad int,
@Posicion varchar(50),
@Estatus bit
as
Update employees set Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, Edad = @Edad, Posicion = @Posicion, Estatus = @Estatus
where Id = @Id;

create procedure EmployeesDelete
@Id int
as
Delete from employees 
where Id = @Id;

select * from employees;