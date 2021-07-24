using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticket_new.Models
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets(PaginParam ticketParameters);
        Ticket GetTicketById(long id);
        Ticket AddTicket(Ticket ticket);
        Ticket UpdateTicket(Ticket ticket);
        bool DeleteTicket(long id);
    }
}
