using System.Reflection.Emit;
using con_event_db.Context;
using con_event_db.Models;

namespace con_event_db.Repositories;

public static class MarqueeRepository
{
    public static IEnumerable<Marquee> Get()
    {
        using var db = ScreenDbContext.Get();
        return db.Marquees.Any() ? db.Marquees.OrderBy(x => x.Order).ToList() : new List<Marquee>();
    }

    public static void Update(IEnumerable<Marquee> marquees)
    {
        using var db = ScreenDbContext.Get();

        foreach (var marquee in marquees)
        {
            if (!db.Marquees.Contains(marquee))
            {
                db.Marquees.Add(marquee);
            }
            else
            {
                var edit = db.Marquees.First(x => x.Id == marquee.Id);
                edit.Order = marquee.Order;
                edit.Text = marquee.Text;
            }
        }

        db.SaveChanges();
    }

    public static void Delete(Marquee marquee)
    {
        using var db = ScreenDbContext.Get();

        db.Marquees.Remove(marquee);

        db.SaveChanges();
    }
}