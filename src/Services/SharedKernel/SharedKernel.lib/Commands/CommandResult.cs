namespace SharedKernel.lib.Commands;

public record CommandResult(bool Success, string? ErrorMessage = null);
