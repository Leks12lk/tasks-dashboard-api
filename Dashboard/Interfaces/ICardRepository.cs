using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Interfaces
{
    public interface ICardRepository
    {
        IQueryable<Card> GeAllCards();
        IQueryable<Card> GetUserCards(string userId);
        Card AddCard(Card card);
        void UpdateCard(Card card);
        void DeleteCard(int id);

    }
}
