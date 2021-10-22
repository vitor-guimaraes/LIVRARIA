using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Livraria.Infra.Interfaces.Commands;
using System;
using System.Text.Json.Serialization;

namespace Livraria.Domain.Commands.Input
{
    public class ApagarLivroCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id deve ser maior que zero");

                return Valid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
