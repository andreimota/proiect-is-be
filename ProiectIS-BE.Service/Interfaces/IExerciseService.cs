using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Interfaces
{
    public interface IExerciseService
    {
        ICollection<Exercise> GetExercises();
        Exercise GetExercise(int exerciseId);
        Task<ExerciseResultModel> TestExercise(int userId, int exerciseId, string inputCode);
    }
}
