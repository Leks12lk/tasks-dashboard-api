using Dashboard.Interfaces;
using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;

namespace Dashboard.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]   
    public class CardController : ApiController
    {
        private ICardRepository repository;
        private string userId;
        private ApplicationDbContext db = new ApplicationDbContext();


        public CardController(ICardRepository repo)
        {            
            this.repository = repo;
            this.userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        }
        public Card PostAddCard(Card card)
        {
            Card model = repository.AddCard(card);
            return model;   
        }

        public IEnumerable<Card> GetCards()
        {
            List<Card> cards = repository.GetUserCards(this.userId).ToList();
            return cards;
        }

        public void PutUpdateCard(Card card)
        {
            repository.UpdateCard(card);
        }

        public void DeleteCard(int id)
        {
            repository.DeleteCard(id);
        }
    }
}
