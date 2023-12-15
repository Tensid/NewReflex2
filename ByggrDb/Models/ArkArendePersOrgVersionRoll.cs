namespace ByggrDb
{
    public partial class ArkArendePersOrgVersionRoll
    {
        public int ArendePersOrgVersionId { get; set; }
        public int Rollid { get; set; }
        public DateTime? RollDatum { get; set; }

        public virtual ArkArendePersOrgVersion ArendePersOrgVersion { get; set; } = null!;
        public virtual GemPersOrgRoll Roll { get; set; } = null!;
    }
}