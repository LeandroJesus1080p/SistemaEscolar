
namespace Escola.Services.ViewModels
{
    public class DisciplinaViewModel
    {
        public required string Nome { get; set; }
        public required int CargaHoraria { get; set; }
    }

    public class DisciplinaUpdateViewModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required int CargaHoraria { get; set; }
    }
}
