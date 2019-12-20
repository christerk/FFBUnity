// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Catch-all exception handler to deal with unexpected errors", Scope = "member", Target = "~M:Fumbbl.FFB.TriggerLogChanged(Fumbbl.Ffb.Dto.Report)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Simple exception handler for any connection issue", Scope = "member", Target = "~M:Fumbbl.Ffb.Networking.Connect~System.Threading.Tasks.Task")]
