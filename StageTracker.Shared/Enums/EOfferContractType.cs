using System.ComponentModel;

namespace StageTracker.Shared.Enums;

public enum EOfferContractType
{
    [Description("Stage")]
    INTERNSHIP,

    [Description("Alternance")]
    APPRENTICESHIP,

    UNKNOWN,
    UNASSIGNED
}
