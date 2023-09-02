using EventScreen.Db.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EventScreen.Db.Repositories;

public abstract class BaseRepository<T> where T : class, new()
{
	protected bool TrySave(ApplicationDbContext db)
	{
		try
		{
			db.SaveChanges();

			return true;
		}
		catch (Exception ex)
		{
			Log.Error("Error while saving changes to Db: {Ex}", ex);
			return false;
		}
	}
	
	public T? Get()
	{
		using var db = ApplicationDbContext.Get();
		return db.Set<T>().FirstOrDefault();
	}

	public T? GetCustom(Func<T, bool> match)
	{
		using var db = ApplicationDbContext.Get();
		return db.Set<T>().FirstOrDefault(x => match.Invoke(x));
	}

	public IEnumerable<T> GetAll()
	{
		using var db = ApplicationDbContext.Get();
		return db.Set<T>().ToArray();
	}

	public IEnumerable<T> GetAllCustom(Func<T, bool> match)
	{
		using var db = ApplicationDbContext.Get();
		return db.Set<T>().Where(x => match.Invoke(x)).ToArray();
	}

	public T? GetOrCreate()
	{
		using var db = ApplicationDbContext.Get();

		var inDb = db.Set<T>().FirstOrDefault();
		if (inDb != null) return inDb;

		var toDb = new T();
		db.Add(toDb);

		return TrySave(db) ? Get()! : null;
	}

	public bool Update(T item)
	{
		using var db = ApplicationDbContext.Get();

		db.Update(item);

		return TrySave(db);
	}

	public bool Create(T item)
	{
		using var db = ApplicationDbContext.Get();

		db.Add(item);

		return TrySave(db);
	}

	public bool Delete(T item)
	{
		using var db = ApplicationDbContext.Get();

		db.Remove(item);

		return TrySave(db);
	}
}