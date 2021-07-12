using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.PaymentServices.Model
{
    public class RegistrationFee
    {
        public Guid? Id { get; set; }
        public string Fee { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
    }
}
