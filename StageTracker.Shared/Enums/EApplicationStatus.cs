using System.ComponentModel;

namespace StageTracker.Shared.Enums;

public enum EApplicationStatus
{
    [Description("Accepté")]
    ACCEPTED,

    [Description("Refusé")]
    REFUSED,

    [Description("En cours")]
    PROCESSING,

    UNKNOWN,
    UNASSIGNED
}
