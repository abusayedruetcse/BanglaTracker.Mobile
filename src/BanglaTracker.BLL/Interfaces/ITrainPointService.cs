using BanglaTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanglaTracker.BLL.Interfaces
{
    public interface ITrainPointService
    {
        Task<List<TrainPoint>> GetTrainPointsAsync();
    }
}
