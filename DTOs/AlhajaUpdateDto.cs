namespace RetoTecnico.DTOs
{
    public class AlhajaUpdateDto
    {
        public int AlhajaID {get; set;}
        public DateTime FechaVencimiento {get;}
        public DateTime? FechaLiquidacion {get; set;}
        public int IdEstatus {get; set;}
    }
}
