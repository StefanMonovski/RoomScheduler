using System;

namespace RoomScheduler.Services.Interfaces
{
    public interface IJsonExportService
    {
        void Export(string filePath, IServiceProvider serviceProvider);
    }
}
