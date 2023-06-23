using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasCading_Project.Models;

public class StudentInfo
{
    public int Id { get; set; }
    [DisplayName("Student Name")]
    public string StudentName { get; set; } = "";
    [DisplayName("Father Name")]
    public string FatherName { get; set; } = "";
    [DisplayName("Mother Name")]
    public string MotherName { get; set; } = "";
    [DisplayName("Phone")]
    public string Phone { get; set; } = "";
    [DisplayName("Email")]
    public string Email { get; set; } = "";
    [DisplayName("Date Of Birth")]
    public DateTime DateOfBirth { get; set; }

    [ForeignKey("Country")]
    public int CountryId { get;set; }
    [ForeignKey("City")]
    public int CityId { get;set; }
    [ForeignKey("State")]
    public int StateId { get; set; }

    public Country Country { get; set; } 
    public State State { get; set; }    
    public City City { get; set; }

}
