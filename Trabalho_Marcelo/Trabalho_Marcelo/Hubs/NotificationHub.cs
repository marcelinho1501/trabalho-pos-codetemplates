using System;
using Microsoft.AspNet.SignalR;
using Trabalho_Marcelo.Models;
using System.Linq;

namespace Trabalho_Marcelo.Hubs
{
    public class NotificationHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Chamartexto(string texto)
        {
            Clients.All.chamarTexto(texto);
        }
    }
}