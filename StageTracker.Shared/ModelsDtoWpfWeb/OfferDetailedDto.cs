using StageTracker.Shared.Enums;

namespace StageTracker.Shared.ModelsDtoWpfWeb;

public record OfferDetailedDto(
                                int Id,
                                string Title,
                                string Description,
                                string Location,
                                string Logo = "DefaultOfferLogo.webp",
                                EOfferAway Away = EOfferAway.UNASSIGNED,
                                EOfferSchedule Schedule = EOfferSchedule.UNASSIGNED
    );
