using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class RoleClaim
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
    }
    public class Card
    {
        public Card()
        {
            ValidFrom = DateTime.Now;
            GoodThru = DateTime.Now.AddYears(3);
            Customer = new Customer();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public long Numbers { get; set; }
        [Required]
        public String Type { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        [Required]
        public DateTime GoodThru { get; set; }
        [Required]
        public int CVV { get; set; }
        public String Employee { get; set; }
        public Customer Customer { get; set; }
    }
    public class Customer
    {
        public Customer()
        {
            DateOfBirth = DateTime.Now.AddYears(-20);
            Cards = new List<Card>();
            Accounts = new List<Account>();
        }
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String Province { get; set; }
        public String PostalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Description { get; set; }
        public String Employee { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
    public class Account
    {
        public Account()
        {
            Customer = new Customer();
            Records = new List<Record>();
        }
        [Key]
        public int Id { get; set; }
        public String Type { get; set; }
        public Double CurrentBalance { get; set; }
        public Double AvailableBalance { get; set; }
        public Double OverDraftLimit { get; set; }
        public String Employee { get; set; }
        public Customer Customer { get; set; }
        public String Status { get; set;}
        public ICollection<Record> Records { get; set; }
    }
    public class Record
    {
        public Record()
        {
            Date = DateTime.Now;
            AccountInfo = new Account();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double WithDrawals { get; set; }
        public Double Deposits { get; set; }
        public Double Balance { get; set; }
        public String Employee { get; set; }
        public Account AccountInfo { get; set; }
        public String Description { get; set; }
    }
}