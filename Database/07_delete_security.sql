USE master;
GO

IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'login_user')
    DROP LOGIN login_user;
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'userNV')
    DROP LOGIN userNV;
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'userQL')
    DROP LOGIN userQL;
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'userAD')
    DROP LOGIN userAD;
GO


USE QuanLyThuVien;
GO
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'login_user')
    DROP USER login_user;
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'userNV')
    DROP USER userNV;
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'userQL')
    DROP USER userQL;
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'userAD')
    DROP USER userAD;
GO

USE QuanLyThuVien;
GO

WHILE EXISTS (
    SELECT 1 
    FROM sys.database_role_members rm
    JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
    WHERE r.name = 'RoleNhanVien'
)
BEGIN
    DECLARE @member sysname;
    SELECT TOP 1 @member = m.name
    FROM sys.database_role_members rm
    JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
    JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id
    WHERE r.name = 'RoleNhanVien';
    EXEC sp_droprolemember 'RoleNhanVien', @member;
END

-- RoleQuanLy
WHILE EXISTS (
    SELECT 1 
    FROM sys.database_role_members rm
    JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
    WHERE r.name = 'RoleQuanLy'
)
BEGIN
    DECLARE @member2 sysname;
    SELECT TOP 1 @member2 = m.name
    FROM sys.database_role_members rm
    JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
    JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id
    WHERE r.name = 'RoleQuanLy';
    EXEC sp_droprolemember 'RoleQuanLy', @member2;
END

-- RoleAdmin
WHILE EXISTS (
    SELECT 1 
    FROM sys.database_role_members rm
    JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
    WHERE r.name = 'RoleAdmin'
)
BEGIN
    DECLARE @member3 sysname;
    SELECT TOP 1 @member3 = m.name
    FROM sys.database_role_members rm
    JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
    JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id
    WHERE r.name = 'RoleAdmin';
    EXEC sp_droprolemember 'RoleAdmin', @member3;
END

-- Giờ drop role an toàn
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'RoleNhanVien' AND type = 'R')
    DROP ROLE RoleNhanVien;
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'RoleQuanLy' AND type = 'R')
    DROP ROLE RoleQuanLy;
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'RoleAdmin' AND type = 'R')
    DROP ROLE RoleAdmin;
GO