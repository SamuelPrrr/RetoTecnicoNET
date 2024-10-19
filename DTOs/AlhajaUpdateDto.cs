namespace RetoTecnico.DTOs
{
    public class AlhajaUpdateDto
    {
        public int AlhajaID {get; set;}
        public decimal MontoDeuda {get; set;}
        public DateTime? FechaLiquidacion {get; set;}
        public int IdEstatus {get; set;}
    }
}
