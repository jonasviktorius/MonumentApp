


Use MonumentDatabase

Go

Create table PostNrTabel(
PostNr int primary key, 
ByNavn varchar(40)
);

Create table MonumentOversigt(
Global_Id int identity(1,1) NOT NULL Primary key, 
Navn varchar(200) NOT NUll, 
Adresse varchar(255) NOT NULL, 
PostNr int,
Note varchar(255),    
Bevaringsværdi char(1) default 'Null',
constraint checkBevaringsværdi
check (Bevaringsværdi in ('A','B','C') or Bevaringsværdi is Null),

foreign key (PostNr) references PostNrTabel (PostNr)
);




create table PlaceringsTyper(
Placerings_Id int identity(1,1) not null primary key,
Placering varchar (30) not null,
);

Create table MaterialeOversigt(
Materiale_Id int not null,
Global_Id int not null,

Primary key(Materiale_Id, Global_Id)
); 



Create Table MaterialeTyper(
Materiale_Id int identity(1,1) Not null primary key,
MaterialeType varchar(30) not null,
);



Create Table SkadeTyper(
SkadeType_Id int identity(1,1) not null primary key,
SkadeType varchar(30) not null
);

create table MonumentTypeOversigt(
MonumentType_Id		int	not null,
Global_Id		int		not null,
primary key (MonumentType_Id, Global_Id)		);


create table MonumentTyper(
MonumentType_Id	int identity(1,1)	not null primary key,
MonumentType	varchar(30));

create table PlaceringsOversigt(
Placerings_Id	int		,
Global_Id		int	,	
primary key (Placerings_Id, Global_Id));

Create Table SkadeOversigt(
Skade_Id int identity (1,1) Not null primary key,
Global_Id int not null,
SkadeType_Id int not null,
ErSkadenUdbedret bit not null default (0),

foreign key (Global_Id) references MonumentOversigt (Global_Id),
foreign key (SkadeType_Id) references SkadeTyper (SkadeType_Id)
);













