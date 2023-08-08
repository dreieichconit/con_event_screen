namespace con_event_api.Classes;
using Newtonsoft.Json;

public class ConTable
    {

        [JsonProperty("con_table_id")]
        public string TableId { get; set; }

        [JsonProperty("con_table_name")]
        public string TableName { get; set; }

        [JsonProperty("con_table_group")]
        public string TableGroup { get; set; }

        [JsonProperty("con_table_size")]
        public string TableSize { get; set; }

        [JsonProperty("con_convention_id")]
        public string ConventionId { get; set; }

        [JsonProperty("con_table_enabled")]
        public string TableEnabled { get; set; }

        [JsonIgnore]
        public string FormatedTableName => TableName.Replace("Tisch", "<br/>Tisch");
    }

    public class ConConventionRpgTag
    {

        [JsonProperty("con_convention_rpg_tag_assign_id")]
        public string TagAssignId { get; set; }

        [JsonProperty("con_convention_rpg_tag_id")]
        public string TagId { get; set; }
    }

    public class Game
    {
        
        public string Free => $"{PlayersJoined}/{MaximumPlayers}";

        [JsonProperty("con_convention_rpg_id")]
        public string Id { get; set; }

        [JsonProperty("con_convention_rpg_title")]
        public string Title { get; set; }

        [JsonIgnore]
        public string FormattedTitle => Title.Length > 40 ? Title[..40] + "..." : Title;
        
        [JsonProperty("con_convention_rpg_system")]
        public string System { get; set; }

        [JsonProperty("con_convention_rpg_duration")]
        public string Duration { get; set; }

        [JsonProperty("con_convention_rpg_player_min")]
        public string MinimumPlayers { get; set; }

        [JsonProperty("con_convention_rpg_player_max")]
        public string MaximumPlayers { get; set; }

        [JsonProperty("con_convention_rpg_chars")]
        public string Characters { get; set; }

        [JsonProperty("con_convention_rpg_teaser")]
        public string Teaser { get; set; }

        [JsonProperty("con_convention_rpg_discord_link")]
        public object DiscordLink { get; set; }

        [JsonProperty("con_convention_rpg_alias_master")]
        public object GameMasterAlias { get; set; }

        [JsonProperty("con_convention_rpg_alias_discord")]
        public object GameMasterDiscordAlias { get; set; }

        [JsonProperty("con_convention_rpg_start_ts")]
        public string StartDate { get; set; }

        public DateTime StartStamp
        {
            get
            {
                try
                {
                    return TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeSeconds(int.Parse(StartDate)), TimeZoneInfo.Local).DateTime;
                }
                catch
                {
                    return DateTime.Now;
                }
            } 
        }
        

        [JsonProperty("con_user_full")]
        public string FullName { get; set; }

        [JsonProperty("con_convention_rpg_publish")]
        public string con_convention_rpg_publish { get; set; }

        [JsonProperty("con_table_id")]
        public string TableId { get; set; }

        [JsonProperty("con_convention_rpg_secret")]
        public string GameSecret { get; set; }

        [JsonProperty("con_convention_rpg_player_joined")]
        public string PlayersJoined { get; set; }

        [JsonProperty("con_convention_rpg_start_string")]
        public string FormatedStartDate { get; set; }

        [JsonProperty("con_table")]
        public ConTable Table { get; set; }

        [JsonProperty("con_convention_gamemaster_online")]
        public bool OnlineGameMaster { get; set; }

        [JsonProperty("con_convention_rpg_tags")]
        public IList<ConConventionRpgTag> Tags { get; set; }

        public bool IsPlacesLeft => int.Parse(MaximumPlayers) - int.Parse(PlayersJoined) > 0;
        
        public string TimeUntil
        {
            get
            {
                var difference = StartStamp - DateTime.Now;

                var returner = string.Empty;

                if (difference.Hours > 0) 
                    returner += $"{(difference.Hours).ToString().PadLeft(2, '0')}h ";
                if (difference.Minutes + 1 < 60)
                    returner += $"{(Math.Abs(difference.Minutes + 1)).ToString().PadLeft(2, '0')}min";

                return returner;
            }
        }
    }