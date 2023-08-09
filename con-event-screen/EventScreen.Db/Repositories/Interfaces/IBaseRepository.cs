namespace EventScreen.Db.Repositories.Interfaces;

public interface IBaseRepository<T>
{
	public T? Get();
	
	public T? GetCustom(Func<T, bool> match);

	public IEnumerable<T> GetAll();

	public IEnumerable<T> GetAllCustom(Func<T, bool> match);

	public T? GetOrCreate();

	public bool Update(T item);

	public bool Create(T item);

	public bool Delete(T item);
}