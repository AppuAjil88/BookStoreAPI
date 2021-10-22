using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    interface IAddressRespository
    {
        Address addAddress(Address address);

        Address viewAddressByID(int id);
        List<Address> viewAddressByUserID(int id);
        bool deleteAddress(int id);
        Address updateAddress(Address address);

    }
}