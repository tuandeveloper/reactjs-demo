using System;
using System.Collections.Generic;

namespace Report.Core.Entity
{
    public class AnnualSalaryReportData
    {
        /// <summary>
        /// Payroll list
        /// </summary>
        public List<AnnualSalaryPayroll> Payrolls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeID"></param>
        /// <param name="costCentreId"></param>
        /// <param name="payrollId"></param>
        public AnnualSalaryReportData()
        {
            var employees = new List<AnnualSalaryEmployee>
            {
                new AnnualSalaryEmployee
                {
                    EmployeeCode = "Employee01",
                    EmployeeName = "ALEXANDER MICHELLE",
                    WorkingDayGroups = new List<AnnualSalaryWorkingDayGroup>()
                    {
                        new AnnualSalaryWorkingDayGroup()
                        {
                            TimeSheetDate = DateTime.Now,
                            WorkingDays = new List<AnnualSalaryWorkingDay>()
                            {
                                new AnnualSalaryWorkingDay
                                {
                                    DateType = "Start End",
                                    StartHour = TimeSpan.FromSeconds(100),
                                    EndHour = TimeSpan.FromSeconds(100),
                                    RosterStartHour = TimeSpan.FromSeconds(100),
                                    RosterEndHour = TimeSpan.FromSeconds(100),
                                },
                                new AnnualSalaryWorkingDay
                                {
                                    DateType = "Start - End",
                                    StartHour = TimeSpan.FromSeconds(100),
                                    EndHour = TimeSpan.FromSeconds(100),
                                    RosterStartHour = TimeSpan.FromSeconds(100),
                                    RosterEndHour = TimeSpan.FromSeconds(100),
                                }
                            }
                        },
                        new AnnualSalaryWorkingDayGroup()
                        {
                            TimeSheetDate = DateTime.Now,
                            WorkingDays = new List<AnnualSalaryWorkingDay>()
                            {
                                new AnnualSalaryWorkingDay
                                {
                                    DateType = "Start End",
                                    StartHour = TimeSpan.FromSeconds(100),
                                    EndHour = TimeSpan.FromSeconds(300),
                                    RosterStartHour = TimeSpan.FromSeconds(100),
                                    RosterEndHour = TimeSpan.FromSeconds(100),
                                },
                                new AnnualSalaryWorkingDay
                                {
                                    DateType = "Break",
                                    StartHour = TimeSpan.FromSeconds(100),
                                    EndHour = TimeSpan.FromSeconds(100),
                                    RosterStartHour = TimeSpan.FromSeconds(100),
                                    RosterEndHour = TimeSpan.FromSeconds(100),
                                }
                            }
                        }
                    },

                    AnnualPenaltyRate = new AnnualSalaryPenaltyRate
                    {
                        PenaltyThreshold = 2,
                        SaturdayHour = 12,
                        SevenAmToSeventPm = 7,
                        SundayHour = 9
                    }
                },


                new AnnualSalaryEmployee
                {
                    EmployeeCode = "Employee02",
                    EmployeeName = "ALEXANDER MICHELLE",
                    WorkingDayGroups = new List<AnnualSalaryWorkingDayGroup>()
                    {
                        new AnnualSalaryWorkingDayGroup()
                        {
                            TimeSheetDate = DateTime.Now,
                            WorkingDays = new List<AnnualSalaryWorkingDay>()
                            {
                                new AnnualSalaryWorkingDay
                                {
                                    DateType = "Start End",
                                    StartHour = TimeSpan.FromSeconds(100),
                                    EndHour = TimeSpan.FromSeconds(100),
                                    RosterStartHour = TimeSpan.FromSeconds(100),
                                    RosterEndHour = TimeSpan.FromSeconds(100),
                                },
                                new AnnualSalaryWorkingDay
                                {
                                    DateType = "Start - End",
                                    StartHour = TimeSpan.FromSeconds(100),
                                    EndHour = TimeSpan.FromSeconds(100),
                                    RosterStartHour = TimeSpan.FromSeconds(100),
                                    RosterEndHour = TimeSpan.FromSeconds(100),
                                }
                            }
                        },
                        new AnnualSalaryWorkingDayGroup()
                        {
                            TimeSheetDate = DateTime.Now,
                            WorkingDays = new List<AnnualSalaryWorkingDay>()
                            {
                                new AnnualSalaryWorkingDay
                                {
                                    DateType = "Start End",
                                    StartHour = TimeSpan.FromSeconds(100),
                                    EndHour = TimeSpan.FromSeconds(100),
                                    RosterStartHour = TimeSpan.FromSeconds(100),
                                    RosterEndHour = TimeSpan.FromSeconds(100),
                                },
                                new AnnualSalaryWorkingDay
                                {
                                    DateType = "Break",
                                    StartHour = TimeSpan.FromSeconds(100),
                                    EndHour = TimeSpan.FromSeconds(100),
                                    RosterStartHour = TimeSpan.FromSeconds(100),
                                    RosterEndHour = TimeSpan.FromSeconds(100)
                                }
                            }
                        }
                    },

                    AnnualPenaltyRate = new AnnualSalaryPenaltyRate
                    {
                        PenaltyThreshold = 2,
                        SaturdayHour = 100,
                        SevenAmToSeventPm = 7,
                        SundayHour = 7
                    }
                }
            };


            Payrolls = new List<AnnualSalaryPayroll>
            {
                new AnnualSalaryPayroll
                {
                    Id = 1,
                    Start = new DateTime(2020, 7, 8),
                    End = new DateTime(2020, 7, 10),
                    Employees = employees
                },
                new AnnualSalaryPayroll
                {
                    Id = 1,
                    Start = new DateTime(2020, 7, 15),
                    End = new DateTime(2020, 7, 20),
                    Employees = employees
                }
            };
        }
    }
}
