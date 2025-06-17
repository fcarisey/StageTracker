using System.ComponentModel;

namespace StageTracker.Shared.Enums;

public enum EOfferAway
{
    [Description("À distance")]
    REMOTE,

    [Description("Sur site")]
    OFFICE,

    [Description("Hybride")]
    NEUTRAL,

    UNKNOWN,
    UNASSIGNED
}
