//using CabinetManagement.Domain.Entities;
using CabinetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CabinetManagement.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    //DbSet<TodoList> TodoLists { get; }

    //DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public DbSet<Ward> Wards { get; set; }
    public DbSet<CabinetType> CabinetTypes { get; set; }
}
