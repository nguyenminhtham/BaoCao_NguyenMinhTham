create database HR 
go
use HR
go
create table Employee_2119110266(
Ma nvarchar(60), 
HoTen nvarchar(255), 
NoiSinh nvarchar(255),
MaCV nvarchar(60),
NgaySinh date, 
GioiTinh int
)

insert into Employee_2119110266 (Ma,HoTen,NgaySinh,GioiTinh,NoiSinh,MaCV) values ('53418', N'Trần Tiến','2000-10-11', 1,N'Hà Nội','IT')
insert into Employee_2119110266 (Ma,HoTen,NgaySinh,GioiTinh,NoiSinh,MaCV) values ('53416', N'Nguyễn Cường','1999-07-21', 0,N'Đắk Lắk','KT')
insert into Employee_2119110266 (Ma,HoTen,NgaySinh,GioiTinh,NoiSinh,MaCV) values ('53417', N'Nguyễn Hào','2001-12-25', 1,N'TP.Hồ Chí Minh','KSNB')

go
create table Department_2119110266(
Ma nvarchar(60), 
HoTen nvarchar(255))

insert into Department_2119110266 values ('IT', N'Công Nghệ Thông Tin')
insert into Department_2119110266 values ('KT', N'Kế toán')
insert into Department_2119110266 values ('KSNB', N'Kiểm soát nội bộ')

select*from Employee_2119110266

select*from Department_2119110266