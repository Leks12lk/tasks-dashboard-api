using Dashboard.Interfaces;
using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Repositories
{
    public class CardRepository : ICardRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Card> GeAllCards()
        {
            var cards = db.Cards;
            return cards;
        }

        public IQueryable<Card> GetUserCards(string userId)
        {
            var cards = db.Cards.Where(item => item.List.UserId == userId);
            return cards;
        }

        public Card AddCard(Card card)
        {
            db.Cards.Add(card);
            db.SaveChanges();
            return card;
        }

        public void UpdateCard(Card card)
        {
            var old = db.Cards.Where(x => x.Id == card.Id).SingleOrDefault();
            old.Description = card.Description;
            old.TasksListId = card.TasksListId;
            db.SaveChanges();
        }


        public void DeleteCard(int id)
        {
            var card = db.Cards.Find(id);
            db.Cards.Remove(card);
            db.SaveChanges();
        }
    }
}