namespace Televizor.VolgaIronHack;

public record ListView<T>(IReadOnlyCollection<T> Items, int? Page = default);