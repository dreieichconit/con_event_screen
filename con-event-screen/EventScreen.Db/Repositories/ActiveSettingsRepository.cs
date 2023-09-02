using EventScreen.Db.Data;
using EventScreen.Db.Models.Settings;
using EventScreen.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventScreen.Db.Repositories;

public class ActiveSettingsRepository : BaseRepository<ActiveSetting>, IActiveSettingsRepository
{
}