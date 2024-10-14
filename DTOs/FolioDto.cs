namespace RetoTecnico.DTOs
{
    public class FolioDto
    {
        public int AlhajaID {get; set;}
        public int FolioID {get; set;}
        public decimal PrecioGramo {get; set;}
        public decimal Interes {get; set;}
        public decimal MontoEmpeño {get; set;}
        public decimal MontoInteres {get; set;}
        public DateTime FechaOperacion {get; set;}
        public DateTime FechaVencimiento {get; set;}
        public DateTime? FechaLiquidacion {get; set;}
    }
}
