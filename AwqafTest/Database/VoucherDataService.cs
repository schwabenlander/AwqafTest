using System.Collections.Generic;
using System.Linq;
using AwqafTest.Models;

namespace AwqafTest.Database
{
    public class VoucherDataService : IVoucherDataService
    {
        private readonly AwqafDatabase _database;

        public VoucherDataService(AwqafDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Voucher> GetVouchers()
        {
            return _database.Vouchers.OrderBy(v => v.VoucherId);
        }

        public Voucher GetVoucherById(int id)
        {
            return _database.Vouchers.Find(id);
        }

        public int GetMaxVoucherId()
        {
            return _database.Vouchers.Any() ? _database.Vouchers.Max(v => v.VoucherId) : 0;
        }

        public Voucher AddVoucher(Voucher newVoucher)
        {
            _database.Vouchers.Add(newVoucher);

            return newVoucher;
        }

        public int Save()
        {
            return _database.SaveChanges();
        }
    }
}