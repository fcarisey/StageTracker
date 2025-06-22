using StageTracker.Shared.Enums;

namespace StageTracker.Shared.ModelsDtoWpfWeb;

public record class OfferDetailedSearchDto
{
    public string? SearchTerms { get; set; }
    public string? Location { get; set; }
    public string? Category { get; set; }
    public EOfferSchedule Schedule { get; set; } = EOfferSchedule.UNASSIGNED;
    public EOfferAway Away { get; set; } = EOfferAway.UNASSIGNED;
    public EOfferContractType ContractType { get; set; } = EOfferContractType.UNASSIGNED;
}
