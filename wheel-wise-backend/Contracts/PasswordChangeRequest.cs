namespace wheel_wise.Contracts;

public record PasswordChangeRequest(string ExistingPassword, string newPassword);