create database QLGBDK
use QLGBDK

drop database QLGBDK

create table Account
(
	username varchar(50) primary key,
	pass varchar(50),
)
select * from Account
insert into Account values('admin','123')
insert into Account values('minhhieu','1899')

create table Class(
	ClassID nvarchar(10) primary key,
	TotalGoals int default 0,
	Scores int default 0
)

insert into Class values('17050201',0,0)
insert into Class values('17050202',0,0)
insert into Class values('17050203',0,0)
insert into Class values('17050204',0,0)
insert into Class values('17050205',0,0)
insert into Class values('17050206',0,0)	
insert into Class values('17050207',0,0)
insert into Class values('17050208',0,0)

create table Members(
	MemberID nvarchar(20) primary key,
	NameMember nvarchar(50),
	ClassID nvarchar(10),
	foreign key (ClassID) REFERENCES Class(ClassID)
)

insert into Members values('51702165',N'Trần Phú Quý','17050201')
insert into Members values('51702166',N'Lê Minh Hiếu','17050201')
insert into Members values('51702183',N'Nguyễn Phùng Thanh','17050201')
insert into Members values('51702026',N'Lưu Thụy Kỳ','17050201')
insert into Members values('51702016',N'Đào Gia Hiệp','17050201')
insert into Members values('51702180',N'Phạm Duy Thái','17050201')
insert into Members values('51702181',N'Nguyễn Thành Đạt','17050201')
insert into Members values('51702182',N'Nguyễn Hoàng Phúc','17050201')

insert into Members values('51702111',N'Lê Minh Tín','17050202')
insert into Members values('51702112',N'Nguyễn Văn Di','17050202')
insert into Members values('51702113',N'Trần Mỹ Dung','17050202')
insert into Members values('51702014',N'Trần Hoài Trọng','17050202')
insert into Members values('51702015',N'Đoàn Thị Đoan Trang','17050202')
insert into Members values('51702116',N'Nguyễn Hữu Khánh','17050202')
insert into Members values('51702117',N'Võ Huyền Trân','17050202')
insert into Members values('51702118',N'Vũ Ngọc Kim Chi','17050202')


insert into Members values('51702121',N'Huỳnh Thị Lâm','17050203')
insert into Members values('51702122',N'Nguyễn Văn Xệ','17050203')
insert into Members values('51702123',N'Trần Văn Bo','17050203')
insert into Members values('51702024',N'Nguyễn Ngọc Ngân','17050203')
insert into Members values('51702025',N'Trần Hồng Ngọc','17050203')
insert into Members values('51702126',N'Nguyễn Hoài Luân','17050203')
insert into Members values('51702127',N'Nguyễn Văn Kỳ','17050203')
insert into Members values('51702128',N'Hoàng Kim Mỹ Linh','17050203')


insert into Members values('51702131',N'Trần Việt Linh','17050204')
insert into Members values('51702132',N'Huỳnh Anh Tôi','17050204')
insert into Members values('51702133',N'Lê Thị Bích','17050204')
insert into Members values('51702034',N'Cẩm Lan','17050204')
insert into Members values('51702035',N'Đỗ Duy Hiệp','17050204')
insert into Members values('51702136',N'Lê Nguyễn Gia Huy','17050204')
insert into Members values('51702137',N'Trần Thị Châu','17050204')
insert into Members values('51702138',N'Kiều Anh Minh','17050204')


insert into Members values('51702141',N'Diễm Trang','17050205')
insert into Members values('51702142',N'Bùi Anh Sang','17050205')
insert into Members values('51702143',N'Lê Dương Trọng','17050205')
insert into Members values('51702044',N'Hoàng Văn Điền','17050205')
insert into Members values('51702045',N'Lý Chí Toàn','17050205')
insert into Members values('51702146',N'Nguyễn Minh Tiến','17050205')
insert into Members values('51702147',N'Đoàn Văn Bơ','17050205')
insert into Members values('51702148',N'Thanh Nhân','17050205')


insert into Members values('51702151',N'Nguyễn Hải','17050206')
insert into Members values('51702152',N'Nguyễn Dương','17050206')
insert into Members values('51702153',N'Lý Thành Đạt','17050206')
insert into Members values('51702054',N'Lê Ngọc Lan Vy','17050206')
insert into Members values('51702055',N'Công Phượng','17050206')
insert into Members values('51702156',N'Văn Đoàn','17050206')
insert into Members values('51702157',N'Thành Đạt','17050206')
insert into Members values('51702158',N'Quốc An','17050206')


insert into Members values('51702161',N'Khánh Duy','17050207')
insert into Members values('51702162',N'Thanh Ngân','17050207')
insert into Members values('51702163',N'Duy Khánh','17050207')
insert into Members values('51702064',N'Hoàng Phúc','17050207')
insert into Members values('51702065',N'Nguyễn Đức Thắng','17050207')
insert into Members values('51702167',N'Đào Duy Từ','17050207')
insert into Members values('51702168',N'Sư Vạn Hạnh','17050207')



insert into Members values('51702171',N'Nguyễn Huệ','17050208')
insert into Members values('51702172',N'An Dương Vương','17050208')
insert into Members values('51702173',N'Trần Khánh Duy','17050208')
insert into Members values('51702074',N'Lý Trọng Kiệt','17050208')
insert into Members values('51702075',N'Trần Bá Khá','17050208')
insert into Members values('51702176',N'Đặng Phúc','17050208')
insert into Members values('51702177',N'Phùng Thanh Độ','17050208')
insert into Members values('51702178',N'Lý Văn Song','17050208')

SELECT TOP(3) * FROM class ORDER BY TotalGoals, Scores,NEWID()
SELECT TOP 1 ClassID from CLASS WHERE ClassID IN (SELECT TOP(5) * FROM class ORDER BY TotalGoals, Scores)
SELECT TOP(1) ClassID from class where ClassID exists ()  ORDER BY NEWID()
DROP TABLE SORTCLASS
SELECT TOP(5) * INTO SORTCLASS FROM class ORDER BY TotalGoals, Scores
SELECT * FROM SORTCLASS
create table RoundMatch(
	roundName nvarchar(20) primary key,
	numberofteam int,
)

insert into RoundMatch values(N'Round 1',8)
insert into RoundMatch values(N'Round 2',8)
select * from RoundMatch
create table detail(
	roundName nvarchar(20),
	classA nvarchar(10),
	classB nvarchar(10),
	scoreA int,
	scoreB int,
	roundDate datetime,
	roundTime nvarchar(20),
	primary key(roundName,classA,classB),
	foreign key (roundName) REFERENCES RoundMatch(roundName),
	foreign key (classA) REFERENCES Class(ClassID),
	foreign key (classB) REFERENCES Class(ClassID),
)
drop table RoundMatch
insert detail values (N'Round 1','17050201','17050202',0,0,GETDATE(),'')
