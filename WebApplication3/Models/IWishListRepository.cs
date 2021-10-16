using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    interface IWishListRepository
    {
        List<Book> GetWishListById(int userId);

        bool addBookToWishListById(int userId, int bookId);

        bool RemoveFromWishListById(int userId, int bookId);
        bool RemoveWishListofUser(int userId);
    }
}
