CREATE TABLE tbl_annonsorer (
	an_ID bigint not null PRIMARY KEY,
  	an_corp bit DEFAULT 0,
    an_name VARCHAR(50) not null,
	an_srName VARCHAR (50),
	
	an_adr VARCHAR (50),
	an_poCode int,
	an_city VARCHAR (50),
	    
);