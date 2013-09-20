using System;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Service
{
    public class LogAcessoService : ILogAcessoService
    {
        private readonly IRepository<LogDeAcesso> logsDeAcesso;
        public LogAcessoService(IRepository<LogDeAcesso> logsDeAcesso)
        {
            this.logsDeAcesso = logsDeAcesso;
        }

        public void Incluir(LogDeAcesso logDeAcesso)
        {
            logsDeAcesso.Add(logDeAcesso);
        }
    }
}