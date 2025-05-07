

using BarberConnect.Api.Context;
using BarberConnect.Api.Repositories.Interfaces;

namespace BarberConnect.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IServicoRepository? _servicoRepo;
        private IHorarioDisponivelRepository? _horarioDisponivelRepo;
        private IHistoricoCorteRepository? _IHistoricoCorteRepo;
        private IClienteRepository? _IClienteRepo;
        private IBarbeiroRepository? _IBarbeiroRepo;
        private IAvaliacaoRepository? _IAvaliacaoRepo;
        private IAgendamentoRepository? _IAgendamentoRepo;


        public AppDbContext _context;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }




        //servico
        public IServicoRepository ServicoRepository
        {
            get
            {
                return _servicoRepo = _servicoRepo ?? new ServicoRepository(_context);
            }
        }




        //HorarioDisponivel

        public IHorarioDisponivelRepository HorarioDisponivelRepository
        {
            get
            {
                return _horarioDisponivelRepo = _horarioDisponivelRepo ?? new HorarioDisponivelRepository(_context);
            }
        }





        //historicoCorte
        public IHistoricoCorteRepository HistoricoCorteRepository
        {
            get
            {
                return _IHistoricoCorteRepo = _IHistoricoCorteRepo ?? new HistoricoCorteRepository(_context);
            }
        }



        //cliente
        public IClienteRepository ClienteRepository
        {
            get
            {
                return _IClienteRepo = _IClienteRepo ?? new ClienteRepository(_context);
            }
        }



        //barbeiro
        public IBarbeiroRepository BarbeiroRepository
        {
            get
            {
                return _IBarbeiroRepo = _IBarbeiroRepo ?? new BarbeiroRepository(_context);
            }
        }




        //avaliacao
        public IAvaliacaoRepository AvaliacaoRepository
        {
            get
            {
                return _IAvaliacaoRepo = _IAvaliacaoRepo ?? new AvaliacaoRepository(_context);
            }
        }





        //agendamento
        public IAgendamentoRepository AgendamentoRepository
        {
            get
            {
                return _IAgendamentoRepo = _IAgendamentoRepo ?? new AgendamentoRepository(_context);
            }
        }







        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }



        public void Dispose()
        {
            _context.Dispose();
        }









    }
}