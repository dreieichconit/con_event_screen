namespace con_event_api.Classes;
using Newtonsoft.Json;

public class ConTable
    {

        [JsonProperty("con_table_id")]
        public string TableId { get; set; }

        [JsonProperty("con_table_name")]
        public string TableName { get; set; }

        [JsonProperty("con_table_group")]
        public string con_table_group { get; set; }

        [JsonProperty("con_table_size")]
        public string con_table_size { get; set; }

        [JsonProperty("con_convention_id")]
        public string con_convention_id { get; set; }

        [JsonProperty("con_table_enabled")]
        public string con_table_enabled { get; set; }
    }

    public class ConConventionRpgTag
    {

        [JsonProperty("con_convention_rpg_tag_assign_id")]
        public string con_convention_rpg_tag_assign_id { get; set; }

        [JsonProperty("con_convention_rpg_tag_id")]
        public string con_convention_rpg_tag_id { get; set; }
    }

    public class Game
    {

        [JsonProperty("con_convention_rpg_id")]
        public string con_convention_rpg_id { get; set; }

        [JsonProperty("con_convention_rpg_title")]
        public string con_convention_rpg_title { get; set; }

        [JsonProperty("con_convention_rpg_system")]
        public string con_convention_rpg_system { get; set; }

        [JsonProperty("con_convention_rpg_duration")]
        public string con_convention_rpg_duration { get; set; }

        [JsonProperty("con_convention_rpg_player_min")]
        public string con_convention_rpg_player_min { get; set; }

        [JsonProperty("con_convention_rpg_player_max")]
        public string con_convention_rpg_player_max { get; set; }

        [JsonProperty("con_convention_rpg_chars")]
        public string con_convention_rpg_chars { get; set; }

        [JsonProperty("con_convention_rpg_teaser")]
        public string con_convention_rpg_teaser { get; set; }

        [JsonProperty("con_convention_rpg_discord_link")]
        public object con_convention_rpg_discord_link { get; set; }

        [JsonProperty("con_convention_rpg_alias_master")]
        public object con_convention_rpg_alias_master { get; set; }

        [JsonProperty("con_convention_rpg_alias_discord")]
        public object con_convention_rpg_alias_discord { get; set; }

        [JsonProperty("con_convention_rpg_start_ts")]
        public string con_convention_rpg_start_ts { get; set; }

        [JsonProperty("con_user_full")]
        public string con_user_full { get; set; }

        [JsonProperty("con_convention_rpg_publish")]
        public string con_convention_rpg_publish { get; set; }

        [JsonProperty("con_table_id")]
        public string con_table_id { get; set; }

        [JsonProperty("con_convention_rpg_secret")]
        public string con_convention_rpg_secret { get; set; }

        [JsonProperty("con_convention_rpg_player_joined")]
        public string con_convention_rpg_player_joined { get; set; }

        [JsonProperty("con_convention_rpg_start_string")]
        public string con_convention_rpg_start_string { get; set; }

        [JsonProperty("con_table")]
        public ConTable con_table { get; set; }

        [JsonProperty("con_convention_gamemaster_online")]
        public bool con_convention_gamemaster_online { get; set; }

        [JsonProperty("con_convention_rpg_tags")]
        public IList<ConConventionRpgTag> con_convention_rpg_tags { get; set; }
    }