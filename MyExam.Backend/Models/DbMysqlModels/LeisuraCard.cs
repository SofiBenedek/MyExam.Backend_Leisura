using System;
using System.Collections.Generic;

namespace MyExam.Backend.Models.DbMysqlModels;

public partial class LeisuraCard
{
    public int Id { get; set; }

    public string EmployeeName { get; set; }

    public string IsMale { get; set; }

    public string TransactionDate { get; set; }

    public int AmountHuf { get; set; }
}
