using System.ComponentModel;

namespace StageTracker.Shared.Enums;

public enum EOfferSchedule
{
    [Description("À temps plein")]
    FULLTIME,

    [Description("À temps partiel")]
    PARTTIME,

    UNASSIGNED,
    UNKNOWN
}
