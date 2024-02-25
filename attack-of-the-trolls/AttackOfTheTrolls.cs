using System;

internal enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
internal enum Permission
{
    None = 0b000,
    Read = 0b001,
    Write = 0b010,
    Delete = 0b100,
    All = Read + Write + Delete
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.Read | Permission.Write | Permission.Delete,
            _ => Permission.None
        };
    }

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => revoke == Permission.All? Permission.None : (current ^ revoke) & current;

    public static bool Check(Permission current, Permission check) => current >= check;
}
