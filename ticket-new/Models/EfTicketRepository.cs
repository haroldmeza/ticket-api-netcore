using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticket_new.Models
{
    public class EfTicketRepository : ITicketRepository
    {
        private TicketDbContext ticketDbContext;
        public EfTicketRepository(TicketDbContext ticketDbCtx)
        {
            ticketDbContext = ticketDbCtx;
        }


        public IEnumerable<Ticket> GetTickets(PaginParam ticketParameters)
        {
            return this.ticketDbContext.Tickets
                .OrderBy(t => t.Id)
                .Skip((ticketParameters.PageNumber - 1) * ticketParameters.PageSize)
                .Take(ticketParameters.PageSize)
                .ToList();
        }

        public Ticket GetTicketById(long id)
        {
            return this.ticketDbContext.Tickets.Find(id);
        }

        public Ticket AddTicket(Ticket ticket)
        {
            ticketDbContext.Tickets.Add(ticket);
            ticketDbContext.SaveChanges();
            return ticket;
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            var updatedTicket = ticketDbContext.Tickets.Find(ticket.Id);
            if(updatedTicket == null)
            {
                return null;
            }

            updatedTicket.Estatus = ticket.Estatus;
            updatedTicket.Usuario = ticket.Usuario;
            updatedTicket.FechaActualizacion = GetCurrentDateTime();

            ticketDbContext.Update(updatedTicket);
            ticketDbContext.SaveChanges();
            return updatedTicket;
        }

        public bool DeleteTicket(long id)
        {
            var deletedTicket = ticketDbContext.Tickets.Find(id);
            if(deletedTicket == null)
            {
                return false;
            }
            ticketDbContext.Tickets.Remove(deletedTicket);
            ticketDbContext.SaveChanges();
            return true;
        }

        private DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

    }
}
