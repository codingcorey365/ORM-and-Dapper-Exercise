﻿using System.Data;
using System.Data.Common;
using Dapper;

namespace ORM_Dapper;

public class DapperDepartmentRepository : IDepartmentRepository
{

    private readonly IDbConnection _connection; // Field
    //Constructor
    public DapperDepartmentRepository(IDbConnection connection) // connection is the appsettings.
    {
        _connection = connection;
    }
    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM Departments;");
    }

    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);", new { departmentName = newDepartmentName });
    }

    public void UpdateDepartment(int id, string newName)
    {
        _connection.Execute("UPDATE departments SET Name = @newName WHERE DepartmentID = @id;", new { newName = newName, id = id });
    }
}