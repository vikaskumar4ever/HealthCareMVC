using SI.Meditourism.FrntMailer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.FrntMailer.Interface
{
    public interface IEmailTemplateRepository:IDisposable
    {
        EmailTemplate GetRecorodById(Guid iId);
        int InsertUpdateRecord(EmailTemplate objEmailTemplate);
    }
}
