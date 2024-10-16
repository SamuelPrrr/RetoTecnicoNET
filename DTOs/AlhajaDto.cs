namespace RetoTecnico.DTOs
{
    public class AlhajaDto
    {

        public int ClienteID {get; set;}

        public int AlhajaID {get; set;}

        public decimal PesoKG {get; set;}

        public string FolioID { get; set; }

        public decimal MontoEmpeño {get; set;}

        public decimal MontoInteres {get; set;}

        public decimal MontoDeuda {get; set;}

        public DateTime FechaOperacion {get; set;}

        public DateTime FechaVencimiento {get; set;}

        public DateTime? FechaLiquidacion {get; set;}
    }
}
