using StageTracker.Shared.Enum;

namespace StageTracker.Shared.ModelsDtoWpfWeb;

public record OfferDetailedDto(int Id, string Title, string Description, string Location, string Logo, EOfferAway Away);
