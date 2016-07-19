CREATE TABLE PROPERTY(
	PropertyID	number(8) 	not null,
	Street 		varchar2(50) 	not null,
	City 		varchar2(50)	not null,
	Province 	varchar2(2) 	not null, 
	Postal_Code	varchar2(6)	not null,
	Bedrooms	number(1)	not null,
	Bathrooms	number(1)	not null,
	ListingPrice	number(7)	not null,
	AreaID		number(8)	not null,
	AgencyID	number(8)	,
	CONSTRAINT Prop_PK Primary key(PropertyID)
);

CREATE TABLE ADVERTISEMENT(
	PropertyID	number(8)	not null,
	OutletID	number(8)	not null,
	AdvDate		date		not null,
	AdvCost		number(7)	not null,
	CONSTRAINT Adv_PK Primary key(PropertyID, OutletID, AdvDate)
);

CREATE TABLE OUTLET(
	OutletID	number(8)	not null,
	OutletName	varchar(10)	not null,
	OutletPhone	number(10)	not null,
	OutletType	varchar2(1)	not null,
	CONSTRAINT Out_PK Primary key(OutletID)
);

CREATE TABLE DEED(
	PropertyID	number(8)	not null,
	SellerID	number(8)	not null,
	OwnPct		number(4)	not null,
	BuyerID		number(8)	,
	BuyPrice	number(7)	,
	CONSTRAINT Deed_PK Primary key(PropertyID, SellerID)
);

CREATE TABLE CLIENT(
	ClientID	number(8)	not null,
	Fname		varchar2(10)	not null,
	Lname		varchar2(10)	not null,
	Phone		number(10)	not null,
	Email		varchar2(50)	,
	RefID		number(8)	,
	CONSTRAINT Cl_PK Primary key(ClientID)
);

CREATE TABLE AREA(
	AreaID		number(8)	not null,
	AreaName	varchar2(50)	not null,
	ElmSchool	varchar2(50)	,
	MidSchool	varchar2(50)	,
	HighSchool	varchar2(50)	,
	Comments	varchar2(50)	,
	CONSTRAINT Area_PK Primary key(AreaID)
);

CREATE TABLE AGENCY(
	AgencyID	number(8)	not null,
	AgencyName	varchar2(10)	not null,
	AgencyPhone	number(10)	not null,
	CONSTRAINT Agen_PK Primary key(AgencyID)
);

CREATE TABLE CONDO(
	PropertyID	number(8)	not null,
	Fee		number(7,2)	not null
);

CREATE TABLE SINGLE(
	PropertyID	number(8)	not null,
	LotSize		number(7,2)	not null
);

--ALTER PROPERTY
ALTER TABLE PROPERTY
	ADD CONSTRAINT Prop_Bed_CK CHECK (Bedrooms BETWEEN 1 AND 9);
ALTER TABLE PROPERTY
	ADD CONSTRAINT Prop_Bath_CK CHECK (BathRooms BETWEEN 1 AND 9);
ALTER TABLE PROPERTY
	ADD CONSTRAINT Prop_Price_CK CHECK (ListingPrice <= 5000000);
ALTER TABLE PROPERTY
	ADD CONSTRAINT Prop_Area_FK Foreign key(AreaID) REFERENCES AREA(AreaID);
ALTER TABLE PROPERTY
	ADD CONSTRAINT Prop_Agen_FK Foreign Key(AgencyID) REFERENCES AGENCY(AgencyID);

--ALTER ADVERTISEMENT
ALTER TABLE ADVERTISEMENT
	ADD CONSTRAINT Adv_Prop_FK Foreign key(PropertyID) REFERENCES PROPERTY(PropertyID);
ALTER TABLE ADVERTISEMENT
	ADD CONSTRAINT Adv_Out_FK Foreign key(OutletID) REFERENCES OUTLET(OutletID);
ALTER TABLE ADVERTISEMENT
	ADD CONSTRAINT Adv_Cost_CK CHECK (AdvCost > 0);

--ALTER OUTLET
ALTER TABLE OUTLET
	ADD CONSTRAINT Out_UK Unique (OutletName, OutletType);
ALTER TABLE OUTLET
	ADD CONSTRAINT OutType_CK CHECK (OutletType IN ('N', 'M', 'W', 'F'));

--ALTER DEED
ALTER TABLE DEED
	ADD CONSTRAINT Deed_Prop_FK Foreign key(PropertyID) REFERENCES PROPERTY(PropertyID);
ALTER TABLE DEED
	ADD CONSTRAINT Deed_Cl_FK1 Foreign key(SellerID) REFERENCES CLIENT(ClientID);
ALTER TABLE DEED
	ADD CONSTRAINT Deed_Pct_CK CHECK (OwnPct <= 100);
ALTER TABLE DEED
	ADD CONSTRAINT Deed_Cl_FK2 Foreign key(BuyerID) REFERENCES CLIENT(ClientID);
ALTER TABLE DEED
	ADD CONSTRAINT Deed_Price_CK CHECK (BuyPrice < 5000000);

--ALTER CLIENT
ALTER TABLE CLIENT
	ADD CONSTRAINT Cl_UK Unique (Phone, Email);
ALTER TABLE CLIENT
	ADD CONSTRAINT Cl_Ref_FK Foreign key(RefID) REFERENCES CLIENT(Email);

--ALTER AREA
ALTER TABLE AREA
	ADD CONSTRAINT Area_UK Unique (AreaName);

--ALTER AGENCY
ALTER TABLE AGENCY
	ADD CONSTRAINT Agen_UK1 Unique (AgencyName);
ALTER TABLE AGENCY
	ADD CONSTRAINT Agen_UK2 Unique (AgencyPhone);


--ALTER CONDO
ALTER TABLE CONDO
	ADD CONSTRAINT Condo_FK Foreign key(PropertyID) REFERENCES PROPERTY(PropertyID);
ALTER TABLE CONDO
	ADD CONSTRAINT Condo_Fee_CK CHECK (Fee > 0);

--ALTER SINGLE
ALTER TABLE SINGLE
	ADD CONSTRAINT Sing_FK Foreign key(PropertyID) REFERENCES PROPERTY(PropertyID);
ALTER TABLE SINGLE
	ADD CONSTRAINT Sing_Size_CK CHECK (LotSize > 0);

	
---------seungmin

--INSERT ALL
-- Client Table
INSERT  INTO    CLIENT(clientId, fName, lName, phone, email)
        VALUES  (10000001,'Seungmin','Han',4161112222,'shan42@myseneca.ca');
INSERT  INTO    CLIENT(clientId, fName, lName, phone)
        VALUES  (10000002,'Insoo','Yun',4163334444);
INSERT  INTO    CLIENT(clientId, fName, lName, phone, email,refId)
        VALUES  (10000003,'Gunwoo','Gim',4165556666,'ggim1@myseneca.ca',10000002);
-- Area Table
INSERT  INTO    AREA(areaId, areaName, elmSchool, midSchool, highSchool, comments)
        VALUES  (50000001,'Etobicoke','Etobicoke Element', 'Etobicoke Middle','Etobicok High','Nice and good area');
INSERT  INTO    AREA(areaId, areaName, elmSchool, highSchool)
        VALUES  (50000002,'York','York Element','York High');
INSERT  INTO    AREA(areaId, areaName, midSchool, highSchool, comments)
        VALUES  (50000003,'Central','Central Middle','Central High', 'Pretty okay area with good accomodations');
-- Agency Table
INSERT  INTO    AGENCY(agencyId, agencyName, agencyPhone)
        VALUES  (50000001,'Ron',6477778888);
INSERT  INTO    AGENCY(agencyId, agencyName, agencyPhone)
        VALUES  (50000002,'Chadd',6479990000);
INSERT  INTO    AGENCY(agencyId, agencyName, agencyPhone)
        VALUES  (50000003,'Harman',6472221111);
-- Outlet Table
INSERT  INTO    OUTLET(outletId, outletName, outletPhone, outletType)
        VALUES  (40000001,'TorSun',9051112222,'N');
INSERT  INTO    OUTLET(outletId, outletName, outletPhone, outletType)
        VALUES  (40000002,'Econom',9053334444,'M');
INSERT  INTO    OUTLET(outletId, outletName, outletPhone, outletType)
        VALUES  (40000003,'Flyer',9055556666,'F');
-- Property Table
INSERT  INTO    PROPERTY(propertyId, Street, city, Province, Postal_Code, bedRooms, bathRooms, ListingPrice, areaId, agencyId)
        VALUES  (50000001,'1 Rest St.','Toronto','ON','A1B2C3',3,1,458000,50000002,50000001);
INSERT  INTO    PROPERTY(propertyId, Street, city, Province, Postal_Code, bedRooms, bathRooms, ListingPrice, areaId)
        VALUES  (50000002,'234 Asdf Rd. Suite 123','Toronto','ON','F3B1A3',5,2,4445000,50000001);
INSERT  INTO    PROPERTY(propertyId, Street, city, Province, Postal_Code, bedRooms, bathRooms, ListingPrice, areaId, agencyId)
        VALUES  (50000003,'8 Globe Ave.','Toronto','ON','H2Z4F5',6,3,2293500,50000003,50000002);
INSERT  INTO    PROPERTY(propertyId, Street, city, Province, Postal_Code, bedRooms, bathRooms, ListingPrice, areaId)
        VALUES  (50000004,'5 Qwerty St. Suite 101','Toronto','ON','P0O9A8',2,1,3500000,50000001);
INSERT  INTO    PROPERTY(propertyId, Street, city, Province, Postal_Code, bedRooms, bathRooms, ListingPrice, areaId, agencyId)
        VALUES  (50000005,'22 Json Rd.','Toronto','ON','Q8E2W3',7,2,4500000,50000001,50000001);
INSERT  INTO    PROPERTY(propertyId, Street, city, Province, Postal_Code, bedRooms, bathRooms, ListingPrice, areaId)
        VALUES  (50000006,'45 Rdbsm St. Suite 3502','Toronto','ON','I9L0O1',6,2,3293500,50000002);
-- Advertisment Table
INSERT  INTO    ADVERTISEMENT(propertyId, outletId, advDate, advCost)
        VALUES  (50000004,40000002,'22-JAN-14',500);
INSERT  INTO    ADVERTISEMENT(propertyId, outletId, advDate, advCost)
        VALUES  (50000002,40000001,'01-MAR-15',350);
INSERT  INTO    ADVERTISEMENT(propertyId, outletId, advDate, advCost)
        VALUES  (50000005,40000003,'01-APR-15',750);
-- Condo Table
INSERT  INTO    CONDO(propertyId, fee)
        VALUES  (50000002, 500.01);
INSERT  INTO    CONDO(propertyId, fee)
        VALUES  (50000004, 1500);
INSERT  INTO    CONDO(propertyId, fee)
        VALUES  (50000006, 900);
-- Single Table
INSERT  INTO    SINGLE(propertyId, lotSize)
        VALUES  (50000001, 5500.05);
INSERT  INTO    SINGLE(propertyId, lotSize)
        VALUES  (50000003, 5000);
INSERT  INTO    SINGLE(propertyId, lotSize)
        VALUES  (50000005, 3500);
-- Deed Table
INSERT  INTO    DEED(propertyId, sellerId, ownPct)
        VALUES  (50000001, 10000001, 100);
INSERT  INTO    DEED(propertyId, sellerId, ownPct)
        VALUES  (50000002, 10000003, 50);
INSERT  INTO    DEED(propertyId, sellerId, ownPct)
        VALUES  (50000002, 10000002, 50);
INSERT  INTO    DEED(propertyId, sellerId, ownPct, buyerId, buyPrice)
        VALUES  (50000003, 10000003, 100, 10000001, 3000000);
-- View Creation
CREATE VIEW PropAreaLocSeller_vu AS (
        SELECT  AR.areaName,
                        PR.city,
                        PR.Street,
                        PR.Postal_Code,
                        PR.ListingPrice,
                        SI.lotSize,
                        CL.fName||' '|| CL.lName AS FullName,
                        CL.phone,
                        DE.ownPct,
                        AG.agencyName
        FROM    PROPERTY PR
                                                JOIN            AREA AR
                                                        ON              PR.areaId = AR.areaId
                                                JOIN            DEED DE
                                                        ON              PR.propertyId = DE.propertyId
                                                JOIN            CLIENT CL
                                                        ON              DE.sellerId = CL.clientId
                                                LEFT JOIN       SINGLE SI
                                                        ON              PR.propertyId = SI.propertyId
                                                LEFT JOIN       AGENCY AG
                                                        ON              PR.agencyId = AG.agencyId
);
SELECT  *
FROM    PropAreaLocSeller_vu
WHERE   agencyName = 'Ron'
        AND     areaName = 'York';
























