using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ticket_new.Models;

namespace ticket_new.Shared
{
    public static class Utils
    {
        public static string GetTicketSerializeEnum(Ticket ticket)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters ={
                    new JsonStringEnumConverter()
                }
            };
            return JsonSerializer.Serialize(ticket, options);

        }
    }
}
