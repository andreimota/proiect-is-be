using ProiectIS_BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class UserExercises
    {
        public UserExercises(int userId,int exerciseId, int score)
        {
            UserId = userId;
            ExerciseId = exerciseId;
            Score = score;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int Score { get; set; }
    }
}
