CREATE TABLE tbl_ads (
	ads_ID int IDENTITY(1000,1) PRIMARY KEY,
	ads_category VARCHAR (50) not null,
	ads_content VARCHAR (50) not null,
	ads_price int DEFAULT 0,
	ads_annonsor bigint FOREIGN KEY REFERENCES tbl_annonsorer(an_ID)
	

	    
);