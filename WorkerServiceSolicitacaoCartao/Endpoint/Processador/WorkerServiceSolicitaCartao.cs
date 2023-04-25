using WorkerServiceSolicitacaoCartao.Domain.Core.Interfaces;

namespace WorkerServiceSolicitacaoCartao.Endpoint.Processador
{
    public class WorkerServiceSolicitaCartao : BackgroundService
    {
        private readonly ILogger<WorkerServiceSolicitaCartao> _logger;
        private IUseCaseSolicitaCartao _useCaseSolicitaCartao;

        public WorkerServiceSolicitaCartao(ILogger<WorkerServiceSolicitaCartao> logger, IUseCaseSolicitaCartao Solicita)
        {
            _useCaseSolicitaCartao= Solicita;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _useCaseSolicitaCartao.Executar();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}