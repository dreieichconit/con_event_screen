using EfExtensions.Core.Interfaces.Repository;
using Screen.Data.Models;

namespace Screen.Data.Interfaces;

public interface IConfigurationRepository : IBaseKeyedRepository<Configuration, string>;