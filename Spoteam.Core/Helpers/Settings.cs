// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Spoteam.Core.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string UserEmailKey = "user_email_key";
    private static readonly string UserEmailDefault = string.Empty;

    private const string UserNameKey = "user_name_key";
    private static readonly string UserNameDefault = string.Empty;

    private const string TeamIdKey = "team_id_key";
    private static readonly int TeamIdDefault = 0;

    #endregion


    public static string UserEmail
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(UserEmailKey, UserEmailDefault);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(UserEmailKey, value);
      }
    }

    public static string UserName
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(UserNameKey, UserNameDefault);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(UserNameKey, value);
      }
    }

    public static int TeamId
    {
      get
      {
        return AppSettings.GetValueOrDefault<int>(TeamIdKey, TeamIdDefault);
      }
      set
      {
        AppSettings.AddOrUpdateValue<int>(TeamIdKey, value);
      }
    }

  }
}