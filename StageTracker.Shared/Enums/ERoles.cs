
using System.ComponentModel;

namespace StageTracker.Shared.Enums;

public enum ERoles
{
    [Description("Admin")]
    ADMIN,

    [Description("Enseignant")]
    TEACHER,

    [Description("Étudiant")]
    STUDENT,

    [Description("Entreprise")]
    COMPANY,

    UNASSIGNED,
    UNKNOWN
}
