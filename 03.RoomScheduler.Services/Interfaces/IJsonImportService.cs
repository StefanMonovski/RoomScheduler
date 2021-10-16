using System;

namespace RoomScheduler.Services.Interfaces
{
    public interface IJsonImportService
    {
        void Import(string filePath, IServiceProvider serviceProvider);
    }
}
