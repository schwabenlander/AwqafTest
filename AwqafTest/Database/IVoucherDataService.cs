using System.Collections.Generic;
using AwqafTest.Models;

namespace AwqafTest.Database
{
    public interface IVoucherDataService
    {
        IEnumerable<Voucher> GetVouchers();
        Voucher GetVoucherById(int id);
        int GetMaxVoucherId();
        Voucher AddVoucher(Voucher newVoucher);
        int Save();
    }
}