using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Controllers
{
    //
    //Card View Models
    public class CardAdd
    {
        public CardAdd()
        {
            ValidFrom = DateTime.Now;
            GoodThru = DateTime.Now.AddYears(3);
        }
        [Display(Name ="Card Number")]
        public long Numbers { get; set; }
        [Required]
        [Display(Name = "Card Type")]
        public String Type { get; set; }
        [Required, Display(Name ="Valid From")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM}", ApplyFormatInEditMode = true)]
        public DateTime ValidFrom { get; set; }
        [Required, Display(Name ="Expire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM}", ApplyFormatInEditMode = true)]
        public DateTime GoodThru { get; set; }
        [Required]
        public int CVV { get; set; }
        [Display(Name ="Employee who worked on this Card")]
        public String Employee { get; set; }
        [Range(1, Int32.MaxValue)]
        public int CustomerId { get; set; }
        [Display(Name = "Card Holder")]
        public CustomerBase Customer { get; set; }
    }
    public class CardAddForm: CardAdd
    {
        [Key]
        [Display(Name ="Card Number")]
        public int Id { get; set; }
    }
    public class CardBase: CardAdd
    {
        [Key]
        public int Id { get; set; }
    }
    public class CardWithDetails: CardBase
    {
        [Display(Name = "Card Holder")]
        public string Cardholder
        {
            get
            {
                return Customer.FirstName + ' ' + Customer.LastName;
            }
        }
    }

    //
    //Customer View Models
    public class CustomerAdd
    {
        public CustomerAdd()
        {
            DateOfBirth = DateTime.Now.AddYears(-20);
            CardIds = new List<int>();
            AccountIds = new List<int>();

            Cards = new List<CardBase>();
            Accounts = new List<AccountBase>();
        }
        [Required, StringLength(100)]
        [Display(Name ="First Name")]
        public String FirstName { get; set; }
        [Required, StringLength(100)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        [Required, StringLength(200)]
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        [Required, StringLength(100)]
        public String City { get; set; }
        [Required, StringLength(100)]
        public String Province { get; set; }
        [Required, StringLength(100)]
        public String PostalCode { get; set; }
        [Required, Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Display(Name = "Employee who worked on this Customer")]
        public String Employee { get; set; }
        public IEnumerable<int> CardIds { get; set; }
        public IEnumerable<int> AccountIds { get; set; }
        [Display(Name = "Number of Cards on this Customer")]
        public int CardsCount { get; set; }
        public IEnumerable<CardBase> Cards { get; set; }
        [Display(Name = "Number of Accounts on this Customer")]
        public int AccountsCount { get; set; }
        public IEnumerable<AccountBase> Accounts { get; set; }
    }
    public class CustomerAddForm: CustomerAdd
    {
        [Key]
        public int Id { get; set; }

    }
    public class CustomerBase: CustomerAdd
    {
        [Key]
        public int Id { get; set; }
    }
    public class CustomerWithDetails: CustomerBase
    {
    }
    public class CustomerEdit
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Required, StringLength(100)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        [Required, StringLength(200)]
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        [Required, StringLength(100)]
        public String City { get; set; }
        [Required, StringLength(100)]
        public String Province { get; set; }
        [Required, StringLength(100)]
        public String PostalCode { get; set; }
        [Required, Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Display(Name = "Employee who worked on this Customer")]
        public String Employee { get; set; }
        public CardBase CurrentCard { get; set; }
        public AccountBase CurrentAccount { get; set; }
        public IEnumerable<int> CardIds { get; set; }
        public IEnumerable<int> AccountIds { get; set; }
    }
    public class CustomerEditForm
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Required, StringLength(100)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        [Required, StringLength(200)]
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        [Required, StringLength(100)]
        public String City { get; set; }
        [Required, StringLength(100)]
        public String Province { get; set; }
        [Required, StringLength(100)]
        public String PostalCode { get; set; }
        [Required, Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Display(Name = "Employee who worked on this Customer")]
        public String Employee { get; set; }
        public CardBase CurrentCard { get; set; }
        public AccountBase CurrentAccount { get; set; }
        public IEnumerable<int> CardIds { get; set; }
        public IEnumerable<int> AccountIds { get; set; }
    }


    //
    //Account View Models
    public class AccountAdd
    {
        public AccountAdd()
        {
            CurrentBalance = 0.00;
            AvailableBalance = CurrentBalance;
            OverDraftLimit = (AvailableBalance + 300.00);
            RecordIds = new List<int>();
            Status = "Closed";
        }
        [Display(Name ="Account Type")]
        public String Type { get; set; }
        [Display(Name = "Current Balance")][DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public Double CurrentBalance { get; set; }
        [Display(Name = "Available Balance")][DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public Double AvailableBalance { get; set; }
        [Display(Name = "Overdraft Limit")][DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public Double OverDraftLimit { get; set; }
        [Display(Name = "Employee who worked on this Account")]
        public String Employee { get; set; }
        public int CustomerId { get; set; }
        public CustomerBase Customer { get; set; }
        public String Status { get; set; }
        public ICollection<int> RecordIds { get; set; }
    }

    public class AccountAddForm: AccountAdd
    {
        [Key]
        public int Id { get; set; }
        

    }
    public class AccountBase: AccountAdd
    {
        [Key]
        public int Id { get; set; }

    }
    public class AccountWithDetails: AccountBase
    {
        public AccountWithDetails()
        {
            Records = new List<RecordBase>();
        }
        [Display(Name = "Number of Records on this Account")]
        public int RecordsCount { get; set; }
        public IEnumerable<RecordBase> Records { get; set; }
    }
    public class AccountEdit
    {
        [Required, Display(Name = "Account Type")]
        public String Type { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        [Display(Name = "Current Balance")]
        public Double CurrentBalance { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        [Display(Name = "Available Balance")]
        public Double AvailableBalance { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        [Display(Name = "Overdraft Limit")]
        public Double OverDraftLimit { get; set; }
        [Display(Name = "Employee who worked on this Account")]
        public String Employee { get; set; }
        [Range(1, Int32.MaxValue)]
        public int CustomerId { get; set; }
        [Display(Name = "Customer Name")]
        public CustomerBase CurrentCustomer { get; set; }
        public String Status { get; set; }
        public IEnumerable<int> RecordIds { get; set; }
    }
    public class AccountEditForm: AccountEdit
    {
        [Key]
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public Double Withdrwal { get; set; }
        public Double Deposit { get; set; }
        public String Description { get; set; }
    }

    //
    //Record View Models
    public class RecordAdd
    {
        public RecordAdd()
        {
            Date = DateTime.Now;
            AccountInfo = new AccountBase();
            Deposits = 0;
            WithDrawals = 0;
        }
        
        [Display(Name ="Date of Record")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public Double WithDrawals { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public Double Deposits { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public Double Balance { get; set; }
        [Display(Name = "Employee who worked on this Account")]
        public String Employee { get; set; }
        public AccountBase AccountInfo { get; set; }
        [Display(Name ="Transaction Discription")]
        public String Description { get; set; }
    }
    public class RecordAddForm: RecordAdd
    {
        [Key]
        public int Id { get; set; }
    }
    public class RecordBase: RecordAdd
    {
        [Key]
        public int Id { get; set; }
        
    }
    public class RecordWithDetails: RecordBase
    {
    }
}