using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    interface ICartRepository
    {
        List<Book> GetCartById(int userId);

        //bool addBookToCartById(int userId, int bookId);
        //bool addBookToCartById(CartItem cartItem);
        bool addBookToCartById(int userId, int bookId);
        bool RemoveFromCartById(int userId, int bookId);
        bool RemoveCartofUser(int userId);
    }
}
