using StageTracker.Shared.Enums;

namespace StageTracker.Shared.ModelsEF;

public class Offer
{
    public int? Id { get; set; }
    public required string Title { get; set; }
    public required string ShortDescription { get; set; }
    public required string Description { get; set; }
    public string? Location { get; set; }
    public string? Logo { get; set; }
    public EOfferAway Away { get; set; } = EOfferAway.UNASSIGNED;
    public EOfferSchedule Schedule { get; set; } = EOfferSchedule.UNASSIGNED;
}
