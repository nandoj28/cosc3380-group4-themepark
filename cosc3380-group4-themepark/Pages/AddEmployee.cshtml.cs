﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;


namespace cosc3380_group4_themepark.Pages;

public class AddEmployeeModel : PageModel
{
    public void OnGet()
    {


    }

    public IActionResult OnPostAddEmployee(Employee employee)
    {
        Console.WriteLine(employee);
        if (employee.date_joined is null)
        {
            return Redirect("/Nowhere");
        }

       
        Int32 rows_affected = SqlHelper.ExecuteProcNonQuery(
          "[Theme_Park].[Proc_Add_Employee]",
          new SqlParameter("@fname", employee.fname),
          new SqlParameter("@lname", employee.lname),
          new SqlParameter("@ssn", employee.ssn),
          new SqlParameter("@gender", employee.gender),
          new SqlParameter("@address", employee.address),
          new SqlParameter("@phone", employee.phone),
          new SqlParameter("@date_joined", employee.date_joined.GetValueOrDefault()),
          new SqlParameter("@dept_id", employee.dept_id),
          new SqlParameter("@role", employee.role),
          new SqlParameter("@supervisor_ssn", employee.supervisor_ssn),
          new SqlParameter("@salaried", employee.salaried),
          new SqlParameter("@payrate", employee.payrate),
          new SqlParameter("@vacation_days", employee.vacation_days));

        return Redirect("/AddEmployee");
    }
    public class Employee
    {
        [BindProperty]
        public String lname { get; set; }

        [BindProperty]
        public String fname { get; set; }

        [BindProperty]
        public Int32 ssn { get; set; }

        [BindProperty]
        public char gender { get; set; }

        [BindProperty]
        public String address { get; set; }

        [BindProperty]
        public Int64 phone { get; set; }

        [BindProperty]
        public DateTime? date_joined { get; set; }

        [BindProperty]
        public Int32 dept_id { get; set; }

        [BindProperty]
        public String role { get; set; }

        [BindProperty]
        public Int32? supervisor_ssn { get; set; }

        [BindProperty]
        public bool salaried { get; set; }

        [BindProperty]
        public decimal? payrate { get; set; }

        [BindProperty]
        public decimal? vacation_days { get; set; }
        public Employee()

        { }
    
    }

}
