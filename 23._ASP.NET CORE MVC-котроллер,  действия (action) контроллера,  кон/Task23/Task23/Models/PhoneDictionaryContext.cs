using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task23.Models
{
    public class PhoneDictionaryContext : DbContext, IRepository<Phone>
    {
        public PhoneDictionaryContext(DbContextOptions<PhoneDictionaryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Phone> Phones { get; set; }

        public Phone Add(Phone item)
        {
            var checkPhone = Get(item.Id);
            if (checkPhone == null)
            {
                this.Phones.Add(item);
                this.SaveChanges();
                return item;
            }
            return null;
        }

        public IEnumerable<Phone> GetAllPhones()
        {
            var sortedPhones = this.Phones.Select(n => n).OrderBy(n => n.Name);
            return sortedPhones;
        }

        public Phone Remove(string id)
        {
            int ID;
            if (Int32.TryParse(id, out ID))
            {

                var checkExistPhone = Get(ID);
                if (checkExistPhone != null)
                {
                    this.Phones.Remove(checkExistPhone);
                    this.SaveChanges();
                    return checkExistPhone;
                }
            }
            return null;
        }

        public Phone Update(Phone item)
        {
            var phone = Get(item.Id);
            if (phone != null)
            {
                phone.Name = item.Name;
                phone.Phone_Number = item.Phone_Number;
                this.Phones.Attach(phone);
                this.Entry(phone).State = EntityState.Modified;
                this.SaveChanges();
                return phone;
            }
            return null;
        }

        public Phone Get(int ID)
        {
            return this.Phones.FirstOrDefault(t => t.Id == ID);
        }

    }
}
