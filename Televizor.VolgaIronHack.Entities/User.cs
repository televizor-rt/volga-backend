namespace Televizor.VolgaIronHack.Entities;

public record User(
    Guid Id,
    string SystemName,
    string DisplayName,
    string Role
);