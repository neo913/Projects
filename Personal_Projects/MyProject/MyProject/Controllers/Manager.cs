using AutoMapper;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MyProject.Controllers
{
    public class Manager
    {
        private ApplicationDbContext ds = new ApplicationDbContext();
        public UserAccount UserAccount { get; private set; }
        public Manager()
        {
            UserAccount = new UserAccount(HttpContext.Current.User as ClaimsPrincipal);
            ds.Configuration.ProxyCreationEnabled = false;
            ds.Configuration.LazyLoadingEnabled = false;
        }
        //
        //Get All Methods

        public IEnumerable<CardWithDetails> CardGetAll()
        {
            var o = ds.Cards.Include("Customer.Accounts.Records").OrderBy(e => e.Id);

            return Mapper.Map<IEnumerable<CardWithDetails>>(o);
        }
        public IEnumerable<CustomerWithDetails> CustomerGetAll()
        {
            var o = ds.Customers.Include("Cards").Include("Accounts.Records").OrderBy(e => e.Id);
            return Mapper.Map<IEnumerable<CustomerWithDetails>>(o);
        }
        public IEnumerable<AccountWithDetails> AccountGetAll()
        {
            var o = ds.Accounts.Include("Customer.Cards").Include("Records").OrderBy(e => e.Id);
            return Mapper.Map<IEnumerable<AccountWithDetails>>(o);
        }
        public IEnumerable<RecordWithDetails> RecordGetAll()
        {
            var o = ds.Records.OrderBy(e => e.Id);
            return Mapper.Map<IEnumerable<RecordWithDetails>>(o);
        }
        
        //
        //Get All By Id Methods
        public IEnumerable<CardWithDetails> CardGetAllByCustomer(int id)
        {
            var o = CustomerGetOne(id);
            if(o == null)
            {
                return null;
            }
            else
            {
                var c = new List<CardWithDetails>();
                foreach(var item in o.Cards)
                {
                    c.Add(CardGetOne(item.Id));
                }

                return Mapper.Map<IEnumerable<CardWithDetails>>(c);
            }
        }
        public IEnumerable<AccountWithDetails> AccountGetAllByCustomer(int id)
        {
            var o = CustomerGetOne(id);
            if (o == null)
            {
                return null;
            }
            else
            {
                var c = new List<AccountWithDetails>();
                foreach (var item in o.Cards)
                {
                    c.Add(AccountGetOne(item.Id));
                }

                return Mapper.Map<IEnumerable<AccountWithDetails>>(c);
            }
        }

        //
        //Get One Methods
        public CardWithDetails CardGetOne(int id)
        {
            var o = ds.Cards.Include("Customer.Accounts.Records").SingleOrDefault(t => t.Id == id);
            if (o == null)
            {
                return null;
            }
            else
            {
                o.Employee = UserAccount.Name;
                ds.SaveChanges();
                return Mapper.Map<CardWithDetails>(o);
            }
        }
        public CustomerWithDetails CustomerGetOne(int id)
        {
            var o = ds.Customers.Include("Cards").Include("Accounts.Records").SingleOrDefault(t => t.Id == id);
            if (o == null)
            {
                return null;
            }
            else
            {
                o.Employee = UserAccount.Name;
                ds.SaveChanges();
                return Mapper.Map<CustomerWithDetails>(o);
            }
        }
        public AccountWithDetails AccountGetOne(int id)
        {
            var o = ds.Accounts.Include("Customer.Cards").Include("Records").SingleOrDefault(t => t.Id == id);
            if(o == null)
            {
                return null;
            }
            else
            {
                o.Employee = UserAccount.Name;
                ds.SaveChanges();
                return Mapper.Map<AccountWithDetails>(o);
            }
        }
        public RecordWithDetails RecordGetOne(int id)
        {
            var o = ds.Records.Include("Accounts.Customer.Cards").SingleOrDefault(t => t.Id == id);
            if(o == null)
            {
                return null;
            }
            else
            {
                o.Employee = UserAccount.Name;
                ds.SaveChanges();
                return Mapper.Map<RecordWithDetails>(o);
            }
        }

        //
        // Search Methods
        public CardWithDetails CardSearch(long Numbers)
        {
            var o = ds.Cards.Include("Customer.Accounts.Records").SingleOrDefault(t => t.Numbers == Numbers);
            if (o == null)
            {
                return null;
            }
            else
            {
                return Mapper.Map<CardWithDetails>(o);
            }
        }

        //
        //Add Methods
        public CardWithDetails CardAdd(CardAdd newItem)
        {
            var addedItem = ds.Cards.Add(Mapper.Map<Card>(newItem));
            addedItem.Numbers = newItem.Numbers;
            addedItem.CVV = newItem.CVV;
            addedItem.ValidFrom = DateTime.Now;
            addedItem.GoodThru = DateTime.Now.AddYears(3);
            addedItem.Employee = UserAccount.Name;
            
            ds.SaveChanges();

            return (addedItem == null) ? null : Mapper.Map<CardWithDetails>(addedItem);
        }

        public CustomerWithDetails CustomerAdd(CustomerAdd newItem)
        {
            var addedItem = ds.Customers.Add(Mapper.Map<Customer>(newItem));
            addedItem.Employee = UserAccount.Name;
            ds.SaveChanges();

            return Mapper.Map<CustomerWithDetails>(addedItem);
        }

        public CardWithDetails CardAddForCustomer(CardAdd newItem)
        {
            var o = ds.Customers.Find(newItem.CustomerId);
            if( o == null)
            {
                return null;
            }
            else
            {
                var addedItem = ds.Cards.Add(Mapper.Map<Card>(newItem));
                addedItem.Numbers = newItem.Numbers;
                addedItem.CVV = newItem.CVV;
                addedItem.ValidFrom = DateTime.Now;
                addedItem.GoodThru = DateTime.Now.AddYears(3);
                addedItem.Customer = o;
                addedItem.Employee = UserAccount.Name;

                ds.SaveChanges();

                return (addedItem == null) ? null : Mapper.Map<CardWithDetails>(addedItem);
            }
        }
                
        public AccountWithDetails AccountAddForCustomer(AccountAdd newItem)
        {
            var o = ds.Customers.Find(newItem.CustomerId);
            if( o == null)
            {
                return null;
            }
            else
            {
                var addedItem = ds.Accounts.Add(Mapper.Map<Account>(newItem));

                addedItem.Type = newItem.Type;
                addedItem.CurrentBalance = newItem.CurrentBalance;
                addedItem.OverDraftLimit = newItem.OverDraftLimit;
                addedItem.AvailableBalance = newItem.AvailableBalance;
                addedItem.Customer = o;
                addedItem.Status = newItem.Status;
                addedItem.Employee = UserAccount.Name;
                var tmpRecord = Mapper.Map<AccountEditForm>(addedItem);
                addedItem.Records.Add(new Record
                                        {
                                            Id = 1,
                                            Date = DateTime.Now,
                                            Balance = 0,
                                            Deposits = 0,
                                            WithDrawals = 0,
                                            Description = "New Account is Created",
                                            Employee = addedItem.Employee,
                                            AccountInfo = addedItem
                                        });

                ds.SaveChanges();
                return Mapper.Map<AccountWithDetails>(addedItem);
            }
        }

        //
        //Edit Methods (Customer only)

        public CustomerWithDetails CustomerEdit(CustomerEditForm newItem)
        {
            var o = ds.Customers.Include("Cards").Include("Accounts.Records").SingleOrDefault(i => i.Id == newItem.Id);
            if(o == null)
            {
                return null;
            }
            else
            {
                o.FirstName = newItem.FirstName;
                o.LastName = newItem.LastName;
                o.Address1 = newItem.Address1;
                o.Address2 = newItem.Address2;
                o.City = newItem.City;
                o.Province = newItem.Province;
                o.PostalCode = newItem.PostalCode;
                o.DateOfBirth = newItem.DateOfBirth;
                o.Description = newItem.Description;
                o.Employee = UserAccount.Name;

                ds.SaveChanges();

                return Mapper.Map<CustomerWithDetails>(o);
            }
        }
        public AccountWithDetails AccountEdit(AccountEditForm newItem)
        {
            var o = ds.Accounts.Include("Customer.Cards").Include("Records").SingleOrDefault(i => i.Id == newItem.Id);
            if( o == null)
            {
                return null;
            }
            else
            {
                o.Status = newItem.Status;
                o.Employee = UserAccount.Name;

                ds.SaveChanges();
                return Mapper.Map<AccountWithDetails>(o);
            }
        }
        public AccountWithDetails Transaction(AccountEditForm newItem)
        {
            var o = ds.Accounts.Include("Customer.Cards").Include("Records").SingleOrDefault(i => i.Id == newItem.Id);
            if (o == null)
            {
                return null;
            }
            else
            {
                o.CurrentBalance += newItem.Deposit;
                o.CurrentBalance -= newItem.Withdrwal;
                o.AvailableBalance = o.CurrentBalance + o.OverDraftLimit;
                o.Employee = UserAccount.Name;

                o.Records.Add(new Record
                                {
                                    Id = (ds.Records.Count() + 1),
                                    Date = DateTime.Now,
                                    Balance = o.CurrentBalance,
                                    Deposits = newItem.Deposit,
                                    WithDrawals = newItem.Withdrwal,
                                    Description = newItem.Description,
                                    Employee = o.Employee,
                                    AccountInfo = o
                                });
                
                ds.SaveChanges();
                return Mapper.Map<AccountWithDetails>(o);
            }
        }

        //
        //Delete Methods

        //
        //Search Methods
        public IEnumerable<CardWithDetails> SearchId(String str)
        {
            long l;
            long.TryParse(str, out l);
            var o = new List<CardWithDetails>();

            foreach(var item in CardGetAll())
            {
                if(item.Numbers == l || item.Customer.FirstName.Contains(str) || item.Customer.LastName.Contains(str))
                {
                    o.Add(item);
                }
            }

            return o;
        }

        //
        //Card Generator and Validation
        public long CardNumberGenerator()
        {
            Random rnd = new Random();
            long temp = 0;

            do
            {
                for (int i = 0; i < 4; i++)
                {
                    temp += rnd.Next(1, 9999);
                    temp *= 10000;
                }
                temp /= 1000;
                if (temp < 0)
                {
                    temp *= -1;
                }
            } while (ds.Cards.SingleOrDefault(i => i.Numbers == temp) == null && CardValidation(temp));
           
            return temp;
        }

        public bool CardValidation(long num)
        {
            //Inspired by my Java project
            long tnum = num;
            /* 1.From the rightmost digit, moving left, double the value of every second digit;
             For example 4012888888881881 will become 1,16,8,2,8,16,8,16,8,16,8,16,2,2,0,8*/
            List<long> tmp = new List<long>();
            while (tnum != 0)
            {
                if (tmp.Count() % 2 == 0)
                {
                    tmp.Add((tnum % 10) * 2);
                    tnum /= 10;
                }
                else
                {
                    tmp.Add(tnum % 10);
                    tnum /= 10;
                }
            }
            /* 2. Take the sum of all the digits. (If the number is greater than 9 (e.g., 8 × 2 = 16), then sum
             the digits of 16(e.g., 16: 1 + 6 = 7).*/
            long newt = 0;
            foreach (var e in tmp)
            {
                if (e > 9)
                {
                    newt += ((e % 10) + (e / 10));
                }
                else
                {
                    newt += e;
                }

            }
            /* 3. If the total modulo 10 is equal to 0 then the number is valid; else it is not valid.
             The number 4012888888881881 is valid since 90 modulo 10 is 0.*/
            // Added some ofmy logics
            if (newt % 10 == 0 && tmp.Count() == 16)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //
        // CVV Generator
        public int CVVGenerator()
        {
            Random rnd = new Random();
            int result = 0;
            while(result < 99)
            {
                result = rnd.Next(0, 999);
            }
            return result;
        }

        //
        // RoleClaim Get All
        public List<string> RoleClaimGetAllStrings()
        {
            return ds.RoleClaims.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        //
        // Regular Expression for Search
        public bool IsValid(String str)
        {
            if(str == null || str.Length < 1)
            {
                return false;
            }
            else
            {
                Regex reg = new Regex(@"^[a-zA-Z]+[\'\-]");
                return reg.IsMatch(str);
            }
        }

        //
        //Load Data
        public bool LoadData()
        {
            var user = HttpContext.Current.User.Identity.Name;
            bool done = false;

            // RoleClaims
            if (ds.RoleClaims.Count() == 0)
            {
                ds.RoleClaims.Add(new RoleClaim { Name = "Manager" });
                ds.RoleClaims.Add(new RoleClaim { Name = "Employee" });
                ds.RoleClaims.Add(new RoleClaim { Name = "Customer" });
                ds.SaveChanges();
                done = true;
            }
            return done;
        }
        //
        // Remove Data
        public bool RemoveData()
        {
            try
            {
                foreach (var e in ds.Cards)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                foreach (var e in ds.Customers)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                foreach (var e in ds.Accounts)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                foreach (var e in ds.Records)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveDataBase()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public class UserAccount
    {
        // Constructor, pass in the security principal
        public UserAccount(ClaimsPrincipal user)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                Principal = user;

                RoleClaims = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

                Name = user.Identity.Name;

                string gn = (user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value == null) ? "(empty given name)" : (user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value);
                //string gn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
                if (string.IsNullOrEmpty(gn)) { gn = "(empty given name)"; }
                GivenName = gn;

                string sn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname).Value;
                if (string.IsNullOrEmpty(sn)) { sn = "(empty surname)"; }
                Surname = sn;

                IsAuthenticated = true;
                IsAdmin = user.HasClaim(ClaimTypes.Role, "Admin") ? true : false;
            }
            else
            {
                RoleClaims = new List<string>();
                Name = "anonymous";
                GivenName = "Unauthenticated";
                Surname = "Anonymous";
                IsAuthenticated = false;
                IsAdmin = false;
            }

            NamesFirstLast = $"{GivenName} {Surname}";
            NamesLastFirst = $"{Surname}, {GivenName}";
        }

        public ClaimsPrincipal Principal { get; private set; }
        public IEnumerable<string> RoleClaims { get; private set; }

        public string Name { get; set; }

        public string GivenName { get; private set; }
        public string Surname { get; private set; }

        public string NamesFirstLast { get; private set; }
        public string NamesLastFirst { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public bool IsAdmin { get; private set; }

        public bool HasRoleClaim(string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(ClaimTypes.Role, value) ? true : false;
        }

        public bool HasClaim(string type, string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(type, value) ? true : false;
        }
    }
}