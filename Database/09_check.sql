USE QuanLyThuVien;
GO

SELECT 
    dp.state_desc, dp.permission_name, OBJECT_NAME(dp.major_id) AS ObjectName
FROM sys.database_permissions dp
JOIN sys.database_principals pr 
    ON dp.grantee_principal_id = pr.principal_id
WHERE pr.name = 'RoleNhanVien';

SELECT 
    dp.state_desc, dp.permission_name, OBJECT_NAME(dp.major_id) AS ObjectName
FROM sys.database_permissions dp
JOIN sys.database_principals pr 
    ON dp.grantee_principal_id = pr.principal_id
WHERE pr.name = 'RoleQuanLy';

SELECT 
    dp.state_desc, dp.permission_name, OBJECT_NAME(dp.major_id) AS ObjectName
FROM sys.database_permissions dp
JOIN sys.database_principals pr 
    ON dp.grantee_principal_id = pr.principal_id
WHERE pr.name = 'RoleAdmin';

SELECT dp2.name AS RoleName, dp1.name AS UserName
FROM sys.database_role_members drm
JOIN sys.database_principals dp1 ON drm.member_principal_id = dp1.principal_id
JOIN sys.database_principals dp2 ON drm.role_principal_id = dp2.principal_id
WHERE dp1.name = 'userNV';

SELECT dp2.name AS RoleName, dp1.name AS UserName
FROM sys.database_role_members drm
JOIN sys.database_principals dp1 ON drm.member_principal_id = dp1.principal_id
JOIN sys.database_principals dp2 ON drm.role_principal_id = dp2.principal_id
WHERE dp1.name = 'userQL';

SELECT dp2.name AS RoleName, dp1.name AS UserName
FROM sys.database_role_members drm
JOIN sys.database_principals dp1 ON drm.member_principal_id = dp1.principal_id
JOIN sys.database_principals dp2 ON drm.role_principal_id = dp2.principal_id
WHERE dp1.name = 'userAD';