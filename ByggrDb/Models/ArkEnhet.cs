namespace ByggrDb
{
    public partial class ArkEnhet
    {
        public ArkEnhet()
        {
            ArkArendes = new HashSet<ArkArende>();
            ArkEnhetHandlaggares = new HashSet<ArkEnhetHandlaggare>();
            ArkHandelses = new HashSet<ArkHandelse>();
            ArkHandlaggareRolls = new HashSet<ArkHandlaggareRoll>();
            Namnds = new HashSet<ArkNamnd>();
        }

        public int EnhetId { get; set; }
        public string Enhet { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int ProduktId { get; set; }
        public int? DiarieId { get; set; }
        public string? EnhetKod { get; set; }
        public string? OrgNr { get; set; }
        public string? PostAdress { get; set; }
        public string? PostNr { get; set; }
        public string? PostOrt { get; set; }
        public string? BesokAdress { get; set; }
        public string? TelefonNr { get; set; }
        public string? Epost { get; set; }
        public string? EnhetsLogga { get; set; }
        public string? ArendeBekraftelseText { get; set; }
        public string? Fax { get; set; }
        public string? WebbAdress { get; set; }
        public string? ArkivbildareKod { get; set; }

        public virtual ArkDiarie? Diarie { get; set; }
        public virtual ArkProdukt Produkt { get; set; } = null!;
        public virtual ICollection<ArkArende> ArkArendes { get; set; }
        public virtual ICollection<ArkEnhetHandlaggare> ArkEnhetHandlaggares { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelses { get; set; }
        public virtual ICollection<ArkHandlaggareRoll> ArkHandlaggareRolls { get; set; }

        public virtual ICollection<ArkNamnd> Namnds { get; set; }
    }
}